namespace DVLD_Presentation_layer.Users
{
    partial class frmShowUserDetails
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
            this.ucChangePassword1 = new DVLD_Presentation_layer.Users.ucChangePassword();
            this.SuspendLayout();
            // 
            // ucChangePassword1
            // 
            this.ucChangePassword1.Location = new System.Drawing.Point(1, 3);
            this.ucChangePassword1.Name = "ucChangePassword1";
            this.ucChangePassword1.Size = new System.Drawing.Size(1105, 694);
            this.ucChangePassword1.TabIndex = 0;
            // 
            // frmShowUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 698);
            this.Controls.Add(this.ucChangePassword1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowUserDetails";
            this.Text = "ShowUserDetails";
            this.Load += new System.EventHandler(this.frmShowUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucChangePassword ucChangePassword1;
    }
}