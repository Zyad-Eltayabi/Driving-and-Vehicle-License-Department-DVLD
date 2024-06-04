namespace DVLD_Presentation_layer.People
{
    partial class frmAdd_EditPerson
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
            this.ucAdd_EditPerson1 = new DVLD_Presentation_layer.People.ucAdd_EditPerson();
            this.SuspendLayout();
            // 
            // ucAdd_EditPerson1
            // 
            this.ucAdd_EditPerson1.Location = new System.Drawing.Point(-7, -13);
            this.ucAdd_EditPerson1.Name = "ucAdd_EditPerson1";
            this.ucAdd_EditPerson1.Size = new System.Drawing.Size(1020, 778);
            this.ucAdd_EditPerson1.TabIndex = 0;
            // 
            // frmAdd_EditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 753);
            this.Controls.Add(this.ucAdd_EditPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAdd_EditPerson";
            this.Text = "frmAdd_EditPerson";
            this.ResumeLayout(false);

        }

        #endregion

        private ucAdd_EditPerson ucAdd_EditPerson1;
    }
}