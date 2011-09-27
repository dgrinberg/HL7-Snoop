// -----------------------------------------------------------------------
// <copyright file="FieldGroup.cs" company="Veraida Pty Ltd">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace HL7Snoop
{
    using System.Collections.Generic;

    /// <summary>
    /// A collection of fields, for display in TreeListView
    /// </summary>
    public class FieldGroup : Field
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldGroup"/> class.
        ///  * Initializes the FieldList list.
        /// </summary>
        public FieldGroup()
        {
            this.FieldList = new List<object>();
        }


        /// <summary>
        /// Gets or sets the field list, from the HL7 message
        /// </summary>
        /// <value>
        /// The field list.
        /// </value>
        public List<object> FieldList { get; set; }
    }
}
