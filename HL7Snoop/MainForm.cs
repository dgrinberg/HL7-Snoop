// -----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Veraida Pty Ltd">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace HL7Snoop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using NHapi.Base.Model;
    using NHapi.Base.Parser;

    /// <summary>
    /// The main form of the application, holds the:
    ///  * text box for entering the HL7 message string
    ///  * TreeListView, for displaying the message contents
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            this.InitializeTreeList();
        }

        /// <summary>
        /// Handles the Click event of the btnParse control.
        /// Retreives the HL7 from the text box and attempts to parse it using NHapi.
        /// If successfull, it retreives all of the fields and displays them in the TreeListView
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnParse_Click(object sender, EventArgs e)
        {
            try
            {
                string hl7 = this.tbMessage.Text;

                PipeParserNew parser = new PipeParserNew();
                IMessage hl7Message;
                if (!string.IsNullOrEmpty(this.tbVersion.Text))
                {
                    hl7Message = parser.Parse(hl7, this.tbVersion.Text);
                }
                else
                {
                    hl7Message = parser.Parse(hl7);
                }

                if (hl7Message != null)
                {
                    this.lblMessageType.Text = hl7Message.GetStructureName();
                    this.lblMessageVersion.Text = hl7Message.Version;

                    FieldGroup messageGroup = new FieldGroup() { Name = hl7Message.GetStructureName() };
                    this.ProcessStructureGroup((AbstractGroup)hl7Message, messageGroup);

                    this.treeListView1.Objects = messageGroup.FieldList;
                    this.treeListView1.ExpandAll();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        #region Hl7Parsing functions

        /// <summary>
        /// Processes a structure group.
        /// A structure group is, primarily, a group of segments.  This could either be the entire
        /// message or special segments that need to be grouped together.  An example of this is
        /// the result segments (OBR, OBX and NTE), these are grouped together in the model
        /// definition (e.g. REF_I12_RESULTS_NOTES).
        /// </summary>
        /// <param name="structureGroup">The structure group.</param>
        /// <param name="parentNode">The parent node, in the TreeListView.</param>
        private void ProcessStructureGroup(AbstractGroup structureGroup, FieldGroup parentNode)
        {
            foreach (string segName in structureGroup.Names)
            {
                foreach (IStructure struc in structureGroup.GetAll(segName))
                {
                    this.ProcessStructure(struc, parentNode);
                }
            }
        }

        /// <summary>
        /// Processes the structure.
        /// A base structure can be either a segment, or segment group. This function
        /// determines which it is before passing it on.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parentNode">The parent node, in the TreeListView.</param>
        private void ProcessStructure(IStructure structure, FieldGroup parentNode)
        {
            if (structure.GetType().IsSubclassOf(typeof(AbstractSegment)))
            {
                AbstractSegment seg = (AbstractSegment)structure;
                this.ProcessSegment(seg, parentNode);
            }
            else if (structure.GetType().IsSubclassOf(typeof(AbstractGroup)))
            {
                AbstractGroup structureGroup = (AbstractGroup)structure;
                this.ProcessStructureGroup(structureGroup, parentNode);
            }
            else
            {
                parentNode.FieldList.Add(new Field() { Name = "Something Else!!!" });
            }
        }

        /// <summary>
        /// Processes the segment.
        /// Loops through all of the fields within the segment, and parsing them individually.
        /// </summary>
        /// <param name="segment">The segment.</param>
        /// <param name="parentNode">The parent node.</param>
        private void ProcessSegment(AbstractSegment segment, FieldGroup parentNode)
        {
            FieldGroup segmentNode = new FieldGroup() { Name = segment.GetStructureName() };
            int dataItemCount = 0;

            for (int i = 1; i <= segment.NumFields(); i++)
            {
                dataItemCount++;
                IType[] dataItems = segment.GetField(i);
                foreach (IType item in dataItems)
                {
                    this.ProcessField(item, segment.GetFieldDescription(i), dataItemCount.ToString(), segmentNode);
                }
            }

            this.AddChildGroup(parentNode, segmentNode);
        }

        /// <summary>
        /// Processes the field.
        /// Determines the type of field, before passing it onto the more specific parsing functions.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="fieldDescription">The field description.</param>
        /// <param name="fieldCount">The field count.</param>
        /// <param name="parentNode">The parent node.</param>
        private void ProcessField(IType item, string fieldDescription, string fieldCount, FieldGroup parentNode)
        {
            if (item.GetType().IsSubclassOf(typeof(AbstractPrimitive)))
            {
                this.ProcessPrimitiveField((AbstractPrimitive)item, fieldDescription, fieldCount, parentNode);
            }
            else if (item.GetType() == typeof(Varies))
            {
                this.ProcessVaries((Varies)item, fieldDescription, fieldCount, parentNode);
            }
            else if (item.GetType().GetInterfaces().Contains(typeof(IComposite)))
            {
                AbstractType dataType = (AbstractType)item;
                string desc = string.IsNullOrEmpty(dataType.Description) ? fieldDescription : dataType.Description;
                this.ProcessCompositeField((IComposite)item, desc, fieldCount, parentNode);
            }
        }

        /// <summary>
        /// Processes the primitive field.
        /// A primitive field is the most basic type (i.e. no composite fields).  This function retrieves the data
        /// and builds the node in the TreeListView.
        /// </summary>
        /// <param name="dataItem">The data item.</param>
        /// <param name="fieldDescription">The field description.</param>
        /// <param name="fieldCount">The field count.</param>
        /// <param name="parentNode">The parent node.</param>
        private void ProcessPrimitiveField(AbstractPrimitive dataItem, string fieldDescription, string fieldCount, FieldGroup parentNode)
        {
            string desc = fieldDescription == string.Empty ? dataItem.Description : fieldDescription;

            if (!string.IsNullOrEmpty(dataItem.Value))
            {
                parentNode.FieldList.Add(new Field() { Name = desc, Id = fieldCount, Value = dataItem.Value });
            }
        }

        /// <summary>
        /// Processes the varies.
        /// "Varies" are the data in the OBX segment, the sending application can set the type hence generically the OBX 
        /// value field is a variant type. 
        /// The "Varies" data parameter contains the data in type IType (hence being passed back to process field).
        /// </summary>
        /// <param name="varies">The varies.</param>
        /// <param name="fieldDescription">The field description.</param>
        /// <param name="fieldCount">The field count.</param>
        /// <param name="parentNode">The parent node.</param>
        private void ProcessVaries(Varies varies, string fieldDescription, string fieldCount, FieldGroup parentNode)
        {
            this.ProcessField(varies.Data, fieldDescription, fieldCount, parentNode);
        }

        /// <summary>
        /// Processes the composite field.
        /// A composite field is a group of fields, such as "Coded Entry".
        /// This function breaks up the composite field and passes each field back to "ProcessField"
        /// </summary>
        /// <param name="composite">The composite.</param>
        /// <param name="fieldDescription">The field description.</param>
        /// <param name="fieldCount">The field count.</param>
        /// <param name="parentNode">The parent node.</param>
        private void ProcessCompositeField(IComposite composite, string fieldDescription, string fieldCount, FieldGroup parentNode)
        {
            FieldGroup subParent = new FieldGroup() { Name = fieldDescription, Id = fieldCount };

            int subItemCount = 0;
            foreach (IType subItem in composite.Components)
            {
                subItemCount++;
                this.ProcessField(subItem, string.Empty, subItemCount.ToString(), subParent);
            }

            this.AddChildGroup(parentNode, subParent);
        }

        #endregion

        /// <summary>
        /// Adds the child group, to the parent node, only if the child group acutally contains fields.
        /// </summary>
        /// <param name="parentNode">The parent node.</param>
        /// <param name="childGroup">The child group.</param>
        private void AddChildGroup(FieldGroup parentNode, FieldGroup childGroup)
        {
            if (childGroup.FieldList.Count > 0)
            {
                parentNode.FieldList.Add(childGroup);
            }
        }

        /// <summary>
        /// Initializes the tree list.
        /// </summary>
        private void InitializeTreeList()
        {
            this.treeListView1.CanExpandGetter = delegate(object x)
            {
                return x is FieldGroup;
            };
            this.treeListView1.ChildrenGetter = delegate(object x)
            {
                FieldGroup grp = (FieldGroup)x;
                return grp.FieldList;
            };
        }
    }
}
