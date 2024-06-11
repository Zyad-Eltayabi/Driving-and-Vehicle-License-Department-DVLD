namespace DVLD_Presentation_layer.Users
{
    partial class frmAddNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewUser));
            this.label1 = new System.Windows.Forms.Label();
            this.tbForm = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.ucAddUserWithFilter1 = new DVLD_Presentation_layer.People.ucAddUserWithFilter();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.tbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIsActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.tbForm.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(540, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add New User";
            // 
            // tbForm
            // 
            this.tbForm.Controls.Add(this.tabPage1);
            this.tbForm.Controls.Add(this.tabPage2);
            this.tbForm.ItemSize = new System.Drawing.Size(180, 40);
            this.tbForm.Location = new System.Drawing.Point(106, 87);
            this.tbForm.Name = "tbForm";
            this.tbForm.SelectedIndex = 0;
            this.tbForm.Size = new System.Drawing.Size(1123, 743);
            this.tbForm.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tbForm.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tbForm.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbForm.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tbForm.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tbForm.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tbForm.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbForm.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbForm.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tbForm.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbForm.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tbForm.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tbForm.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbForm.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tbForm.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tbForm.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tbForm.TabIndex = 3;
            this.tbForm.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbForm.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tbForm.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbForm_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.ucAddUserWithFilter1);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1115, 695);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BorderRadius = 15;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(916, 637);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(180, 45);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ucAddUserWithFilter1
            // 
            this.ucAddUserWithFilter1.Location = new System.Drawing.Point(6, 41);
            this.ucAddUserWithFilter1.Name = "ucAddUserWithFilter1";
            this.ucAddUserWithFilter1.Size = new System.Drawing.Size(1104, 590);
            this.ucAddUserWithFilter1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbIsActive);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.tbPassword);
            this.tabPage2.Controls.Add(this.guna2PictureBox4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbUserName);
            this.tabPage2.Controls.Add(this.guna2PictureBox3);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.guna2PictureBox1);
            this.tabPage2.Controls.Add(this.lbID);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1115, 695);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Login Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 15;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(467, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 45);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassword.DefaultText = "";
            this.tbPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassword.Location = new System.Drawing.Point(549, 302);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '\0';
            this.tbPassword.PlaceholderText = "";
            this.tbPassword.SelectedText = "";
            this.tbPassword.Size = new System.Drawing.Size(229, 29);
            this.tbPassword.TabIndex = 27;
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox4.Image")));
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(500, 302);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(46, 30);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox4.TabIndex = 26;
            this.guna2PictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Signika", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(336, 304);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 27);
            this.label4.TabIndex = 25;
            this.label4.Text = "Password";
            // 
            // tbUserName
            // 
            this.tbUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUserName.DefaultText = "";
            this.tbUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUserName.Location = new System.Drawing.Point(549, 252);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.PasswordChar = '\0';
            this.tbUserName.PlaceholderText = "";
            this.tbUserName.SelectedText = "";
            this.tbUserName.Size = new System.Drawing.Size(229, 29);
            this.tbUserName.TabIndex = 24;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox3.Image")));
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(500, 251);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(46, 30);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 23;
            this.guna2PictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Signika", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(336, 253);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 27);
            this.label3.TabIndex = 22;
            this.label3.Text = "User Name : ";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(500, 204);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(46, 30);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 21;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Signika", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.ForeColor = System.Drawing.Color.Black;
            this.lbID.Location = new System.Drawing.Point(575, 206);
            this.lbID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(34, 27);
            this.lbID.TabIndex = 20;
            this.lbID.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Signika", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(336, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 27);
            this.label2.TabIndex = 19;
            this.label2.Text = "User ID : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Signika", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(336, 357);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 27);
            this.label5.TabIndex = 25;
            this.label5.Text = "Is Active";
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsActive.CheckedState.BorderRadius = 0;
            this.cbIsActive.CheckedState.BorderThickness = 0;
            this.cbIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsActive.Location = new System.Drawing.Point(514, 367);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(18, 17);
            this.cbIsActive.TabIndex = 29;
            this.cbIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbIsActive.UncheckedState.BorderRadius = 0;
            this.cbIsActive.UncheckedState.BorderThickness = 0;
            this.cbIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // frmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 917);
            this.Controls.Add(this.tbForm);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewUser";
            this.Text = "Add New User";
            this.tbForm.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TabControl tbForm;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private People.ucAddUserWithFilter ucAddUserWithFilter1;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox tbUserName;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2CheckBox cbIsActive;
    }
}