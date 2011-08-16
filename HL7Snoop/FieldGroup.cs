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
    public class FieldGroup
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
        /// Gets or sets the id, the HL7 location id of the field group
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name, as per the model definition
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the field list, from the HL7 message
        /// </summary>
        /// <value>
        /// The field list.
        /// </value>
        public List<object> FieldList { get; set; }
    }
}
