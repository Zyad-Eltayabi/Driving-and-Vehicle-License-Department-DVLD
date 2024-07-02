namespace DVLD_Presentation_layer.MainScreen
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDrivingLicensesServices = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsManageApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalDrivingLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDetainLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsManageApplicationsTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.menuStrip1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsApplication,
            this.tsPeople,
            this.tsDrivers,
            this.tsUsers,
            this.tsAccountSettings});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 68);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1426, 89);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsApplication
            // 
            this.tsApplication.AutoSize = false;
            this.tsApplication.AutoToolTip = true;
            this.tsApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDrivingLicensesServices,
            this.tsManageApplications,
            this.tsDetainLicenses,
            this.tsManageApplicationsTypes,
            this.tsManageTestTypes});
            this.tsApplication.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.tsApplication.Image = ((System.Drawing.Image)(resources.GetObject("tsApplication.Image")));
            this.tsApplication.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tsApplication.Name = "tsApplication";
            this.tsApplication.Size = new System.Drawing.Size(250, 65);
            this.tsApplication.Text = "Applications";
            this.tsApplication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsDrivingLicensesServices
            // 
            this.tsDrivingLicensesServices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem});
            this.tsDrivingLicensesServices.Image = ((System.Drawing.Image)(resources.GetObject("tsDrivingLicensesServices.Image")));
            this.tsDrivingLicensesServices.Name = "tsDrivingLicensesServices";
            this.tsDrivingLicensesServices.Size = new System.Drawing.Size(429, 56);
            this.tsDrivingLicensesServices.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newDrivingLicenseToolStripMenuItem.Image")));
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(334, 36);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localLicenseToolStripMenuItem.Image")));
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(337, 36);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("internationalLicenseToolStripMenuItem.Image")));
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(337, 36);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // tsManageApplications
            // 
            this.tsManageApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationToolStripMenuItem,
            this.internationalDrivingLicenseApplicationToolStripMenuItem});
            this.tsManageApplications.Image = ((System.Drawing.Image)(resources.GetObject("tsManageApplications.Image")));
            this.tsManageApplications.Name = "tsManageApplications";
            this.tsManageApplications.Size = new System.Drawing.Size(429, 56);
            this.tsManageApplications.Text = "Manage Applications";
            // 
            // localDrivingLicenseApplicationToolStripMenuItem
            // 
            this.localDrivingLicenseApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localDrivingLicenseApplicationToolStripMenuItem.Image")));
            this.localDrivingLicenseApplicationToolStripMenuItem.Name = "localDrivingLicenseApplicationToolStripMenuItem";
            this.localDrivingLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(585, 56);
            this.localDrivingLicenseApplicationToolStripMenuItem.Text = "Local Driving License Application";
            this.localDrivingLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // internationalDrivingLicenseApplicationToolStripMenuItem
            // 
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("internationalDrivingLicenseApplicationToolStripMenuItem.Image")));
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Name = "internationalDrivingLicenseApplicationToolStripMenuItem";
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(585, 56);
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Text = "International Driving License Application";
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.internationalDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // tsDetainLicenses
            // 
            this.tsDetainLicenses.Image = ((System.Drawing.Image)(resources.GetObject("tsDetainLicenses.Image")));
            this.tsDetainLicenses.Name = "tsDetainLicenses";
            this.tsDetainLicenses.Size = new System.Drawing.Size(429, 56);
            this.tsDetainLicenses.Text = "Detain Licenses";
            // 
            // tsManageApplicationsTypes
            // 
            this.tsManageApplicationsTypes.Image = ((System.Drawing.Image)(resources.GetObject("tsManageApplicationsTypes.Image")));
            this.tsManageApplicationsTypes.Name = "tsManageApplicationsTypes";
            this.tsManageApplicationsTypes.Size = new System.Drawing.Size(429, 56);
            this.tsManageApplicationsTypes.Text = "Manage Application Types";
            this.tsManageApplicationsTypes.Click += new System.EventHandler(this.tsManageApplicationsTypes_Click);
            // 
            // tsManageTestTypes
            // 
            this.tsManageTestTypes.Image = ((System.Drawing.Image)(resources.GetObject("tsManageTestTypes.Image")));
            this.tsManageTestTypes.Name = "tsManageTestTypes";
            this.tsManageTestTypes.Size = new System.Drawing.Size(429, 56);
            this.tsManageTestTypes.Text = "Manage Test Types";
            this.tsManageTestTypes.Click += new System.EventHandler(this.tsManageTestTypes_Click);
            // 
            // tsPeople
            // 
            this.tsPeople.AutoSize = false;
            this.tsPeople.AutoToolTip = true;
            this.tsPeople.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPeople.Image = ((System.Drawing.Image)(resources.GetObject("tsPeople.Image")));
            this.tsPeople.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tsPeople.Name = "tsPeople";
            this.tsPeople.Size = new System.Drawing.Size(230, 65);
            this.tsPeople.Text = "People";
            this.tsPeople.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsPeople.Click += new System.EventHandler(this.tsPeople_Click);
            // 
            // tsDrivers
            // 
            this.tsDrivers.AutoSize = false;
            this.tsDrivers.AutoToolTip = true;
            this.tsDrivers.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.tsDrivers.Image = ((System.Drawing.Image)(resources.GetObject("tsDrivers.Image")));
            this.tsDrivers.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tsDrivers.Name = "tsDrivers";
            this.tsDrivers.Size = new System.Drawing.Size(230, 65);
            this.tsDrivers.Text = "Drivers";
            this.tsDrivers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsDrivers.Click += new System.EventHandler(this.tsDrivers_Click);
            // 
            // tsUsers
            // 
            this.tsUsers.AutoSize = false;
            this.tsUsers.AutoToolTip = true;
            this.tsUsers.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.tsUsers.Image = global::DVLD_Presentation_layer.Properties.Resources.admin;
            this.tsUsers.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tsUsers.Name = "tsUsers";
            this.tsUsers.Size = new System.Drawing.Size(230, 65);
            this.tsUsers.Text = "Users";
            this.tsUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsUsers.Click += new System.EventHandler(this.tsUsers_Click);
            // 
            // tsAccountSettings
            // 
            this.tsAccountSettings.AutoSize = false;
            this.tsAccountSettings.AutoToolTip = true;
            this.tsAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.tsAccountSettings.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.tsAccountSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsAccountSettings.Image")));
            this.tsAccountSettings.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tsAccountSettings.Name = "tsAccountSettings";
            this.tsAccountSettings.Size = new System.Drawing.Size(360, 65);
            this.tsAccountSettings.Text = "Account Settings";
            this.tsAccountSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(308, 36);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePasswordToolStripMenuItem.Image")));
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(308, 36);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("signOutToolStripMenuItem.Image")));
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(308, 36);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1417, 73);
            this.guna2Panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::DVLD_Presentation_layer.Properties.Resources.close;
            this.btnClose.ImageSize = new System.Drawing.Size(50, 50);
            this.btnClose.Location = new System.Drawing.Point(1360, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 73);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::DVLD_Presentation_layer.Properties.Resources.hands_3410350;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(4, 0);
            this.guna2CirclePictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(75, 73);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1417, 706);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainScreen";
            this.Text = "test";
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsUsers;
        private System.Windows.Forms.ToolStripMenuItem tsApplication;
        private System.Windows.Forms.ToolStripMenuItem tsDrivingLicensesServices;
        private System.Windows.Forms.ToolStripMenuItem tsPeople;
        private System.Windows.Forms.ToolStripMenuItem tsDrivers;
        private System.Windows.Forms.ToolStripMenuItem tsAccountSettings;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.ToolStripMenuItem tsManageApplications;
        private System.Windows.Forms.ToolStripMenuItem tsManageApplicationsTypes;
        private System.Windows.Forms.ToolStripMenuItem tsManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsDetainLicenses;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalDrivingLicenseApplicationToolStripMenuItem;
    }
}