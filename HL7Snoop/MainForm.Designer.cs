// -----------------------------------------------------------------------
// <copyright file="MainForm.Designer.cs" company="Veraida Pty Ltd">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace HL7Snoop
{
    /// <summary>
    /// The MainForm designer partial - describes all of the visual components on the form.
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnParse;

        private BrightIdeasSoftware.HeaderFormatStyle headerFormatStyle1;

        private BrightIdeasSoftware.TreeListView treeListView1;

        private BrightIdeasSoftware.OLVColumn colName;

        private BrightIdeasSoftware.OLVColumn colId;

        private BrightIdeasSoftware.OLVColumn colValue;

        private System.Windows.Forms.Label lblMessageType;

        private System.Windows.Forms.Label lblMessageVersion;

        private System.Windows.Forms.TextBox tbMessage;

        private System.Windows.Forms.TextBox tbVersion;

        private System.Windows.Forms.Label label1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle4 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle5 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle6 = new BrightIdeasSoftware.HeaderStateStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnParse = new System.Windows.Forms.Button();
            this.headerFormatStyle1 = new BrightIdeasSoftware.HeaderFormatStyle();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lblMessageType = new System.Windows.Forms.Label();
            this.lblMessageVersion = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParse.Location = new System.Drawing.Point(621, 3);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 0;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // headerFormatStyle1
            // 
            this.headerFormatStyle1.Hot = headerStateStyle4;
            this.headerFormatStyle1.Normal = headerStateStyle5;
            this.headerFormatStyle1.Pressed = headerStateStyle6;
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.colName);
            this.treeListView1.AllColumns.Add(this.colId);
            this.treeListView1.AllColumns.Add(this.colValue);
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView1.CheckBoxes = false;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colId,
            this.colValue});
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.GridLines = true;
            this.treeListView1.Location = new System.Drawing.Point(11, 253);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(685, 310);
            this.treeListView1.TabIndex = 6;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // colName
            // 
            this.colName.AspectName = "Name";
            this.colName.Text = "Name";
            this.colName.Width = 240;
            // 
            // colId
            // 
            this.colId.AspectName = "Id";
            this.colId.Text = "Id";
            // 
            // colValue
            // 
            this.colValue.AspectName = "Value";
            this.colValue.FillsFreeSpace = true;
            this.colValue.Text = "Value";
            this.colValue.Width = 180;
            // 
            // lblMessageType
            // 
            this.lblMessageType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessageType.AutoSize = true;
            this.lblMessageType.Location = new System.Drawing.Point(11, 233);
            this.lblMessageType.Name = "lblMessageType";
            this.lblMessageType.Size = new System.Drawing.Size(0, 13);
            this.lblMessageType.TabIndex = 7;
            this.lblMessageType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMessageVersion
            // 
            this.lblMessageVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessageVersion.AutoSize = true;
            this.lblMessageVersion.Location = new System.Drawing.Point(642, 232);
            this.lblMessageVersion.Name = "lblMessageVersion";
            this.lblMessageVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMessageVersion.Size = new System.Drawing.Size(0, 13);
            this.lblMessageVersion.TabIndex = 8;
            this.lblMessageVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.Location = new System.Drawing.Point(14, 32);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMessage.Size = new System.Drawing.Size(681, 197);
            this.tbMessage.TabIndex = 9;
            this.tbMessage.WordWrap = false;
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(515, 5);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(100, 20);
            this.tbVersion.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Version:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 575);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lblMessageVersion);
            this.Controls.Add(this.lblMessageType);
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.btnParse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "NHapi HL7 Snoop";
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}