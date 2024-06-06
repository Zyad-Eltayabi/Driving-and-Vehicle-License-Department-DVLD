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
            this.ucManagePeople1.Location = new System.Drawing.Point(-31, 4);
            this.ucManagePeople1.Margin = new System.Windows.Forms.Padding(4);
            this.ucManagePeople1.Name = "ucManagePeople1";
            this.ucManagePeople1.Size = new System.Drawing.Size(1600, 744);
            this.ucManagePeople1.TabIndex = 0;
            // 
            // frmMangePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 752);
            this.Controls.Add(this.ucManagePeople1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMangePeople";
            this.Text = "Mange People";
            this.ResumeLayout(false);

        }

        #endregion

        private ucManagePeople ucManagePeople1;
    }
}