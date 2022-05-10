
namespace Test_IpAddressTable.Ver1
{
    partial class Test_IpAddressTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.IPTable = new IpAddressTable.IpAddressTable();
            this.SuspendLayout();
            // 
            // IPTable
            // 
            this.IPTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IPTable.DbProvider = null;
            this.IPTable.Location = new System.Drawing.Point(12, 12);
            this.IPTable.Name = "IPTable";
            this.IPTable.Size = new System.Drawing.Size(344, 336);
            this.IPTable.TabIndex = 1;
            // 
            // Test_IpAddressTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 360);
            this.Controls.Add(this.IPTable);
            this.Name = "Test_IpAddressTable";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private IpAddressTable.IpAddressTable IPTable;
    }
}

