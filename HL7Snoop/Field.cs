// -----------------------------------------------------------------------
// <copyright file="Field.cs" company="Veraida Pty Ltd">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace HL7Snoop
{
    /// <summary>
    /// A simple representation of a HL7 field, for display in the TreeListView
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Gets or sets the id, field location id
        /// </summary>
        /// <value>
        /// The id
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
        /// Gets or sets the value, from the HL7 message.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
    }
}
