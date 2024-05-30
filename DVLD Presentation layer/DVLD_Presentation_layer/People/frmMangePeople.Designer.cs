namespace DVLD_Presentation_layer.People
{
    partial class frmMangePeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMangePeople));
            this.ucManagePeople1 = new DVLD_Presentation_layer.People.ucManagePeople();
            this.SuspendLayout();
            // 
            // ucManagePeople1
            // 
            this.ucManagePeople1.Location = new System.Drawing.Point(-8, 5);
            this.ucManagePeople1.Name = "ucManagePeople1";
            this.ucManagePeople1.Size = new System.Drawing.Size(1200, 600);
            this.ucManagePeople1.TabIndex = 0;
            // 
            // frmMangePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.ucManagePeople1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMangePeople";
            this.Text = "Mange People";
            this.ResumeLayout(false);

        }

        #endregion

        private ucManagePeople ucManagePeople1;
    }
}