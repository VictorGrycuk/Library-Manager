namespace LibraryManagement
{
    partial class frmUserForm
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
            this.layoutControlUser = new DevExpress.XtraLayout.LayoutControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroupUser = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutGroupSystemInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutGroupPersonalInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblLastName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlUser)).BeginInit();
            this.layoutControlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGroupSystemInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGroupPersonalInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlUser
            // 
            this.layoutControlUser.Controls.Add(this.btnClear);
            this.layoutControlUser.Controls.Add(this.btnSave);
            this.layoutControlUser.Controls.Add(this.txtPassword);
            this.layoutControlUser.Controls.Add(this.txtLastName);
            this.layoutControlUser.Controls.Add(this.txtName);
            this.layoutControlUser.Controls.Add(this.txtUsername);
            this.layoutControlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlUser.Location = new System.Drawing.Point(0, 0);
            this.layoutControlUser.Name = "layoutControlUser";
            this.layoutControlUser.Root = this.layoutControlGroupUser;
            this.layoutControlUser.Size = new System.Drawing.Size(272, 228);
            this.layoutControlUser.TabIndex = 0;
            this.layoutControlUser.Text = "layoutControl1";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 192);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(122, 22);
            this.btnClear.StyleController = this.layoutControlUser;
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 22);
            this.btnSave.StyleController = this.layoutControlUser;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(77, 156);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(171, 20);
            this.txtPassword.StyleController = this.layoutControlUser;
            this.txtPassword.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(77, 66);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(171, 20);
            this.txtLastName.StyleController = this.layoutControlUser;
            this.txtLastName.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(171, 20);
            this.txtName.StyleController = this.layoutControlUser;
            this.txtName.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(77, 132);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(171, 20);
            this.txtUsername.StyleController = this.layoutControlUser;
            this.txtUsername.TabIndex = 1;
            // 
            // layoutControlGroupUser
            // 
            this.layoutControlGroupUser.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupUser.GroupBordersVisible = false;
            this.layoutControlGroupUser.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutGroupSystemInformation,
            this.layoutGroupPersonalInformation,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroupUser.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupUser.Name = "layoutControlGroupUser";
            this.layoutControlGroupUser.Size = new System.Drawing.Size(272, 228);
            this.layoutControlGroupUser.TextVisible = false;
            // 
            // layoutGroupSystemInformation
            // 
            this.layoutGroupSystemInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblUserName,
            this.lblPassword});
            this.layoutGroupSystemInformation.Location = new System.Drawing.Point(0, 90);
            this.layoutGroupSystemInformation.Name = "layoutGroupSystemInformation";
            this.layoutGroupSystemInformation.Size = new System.Drawing.Size(252, 90);
            this.layoutGroupSystemInformation.Text = "System Information";
            // 
            // lblUserName
            // 
            this.lblUserName.Control = this.txtUsername;
            this.lblUserName.Location = new System.Drawing.Point(0, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(228, 24);
            this.lblUserName.Text = "Username";
            this.lblUserName.TextSize = new System.Drawing.Size(50, 13);
            // 
            // lblPassword
            // 
            this.lblPassword.Control = this.txtPassword;
            this.lblPassword.Location = new System.Drawing.Point(0, 24);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(228, 24);
            this.lblPassword.Text = "Password";
            this.lblPassword.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutGroupPersonalInformation
            // 
            this.layoutGroupPersonalInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblName,
            this.lblLastName});
            this.layoutGroupPersonalInformation.Location = new System.Drawing.Point(0, 0);
            this.layoutGroupPersonalInformation.Name = "layoutGroupPersonalInformation";
            this.layoutGroupPersonalInformation.Size = new System.Drawing.Size(252, 90);
            this.layoutGroupPersonalInformation.Text = "Personal Information";
            // 
            // lblName
            // 
            this.lblName.Control = this.txtName;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(228, 24);
            this.lblName.Text = "Name";
            this.lblName.TextSize = new System.Drawing.Size(50, 13);
            // 
            // lblLastName
            // 
            this.lblLastName.Control = this.txtLastName;
            this.lblLastName.Location = new System.Drawing.Point(0, 24);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(228, 24);
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnSave;
            this.layoutControlItem5.Location = new System.Drawing.Point(126, 180);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(126, 28);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnClear;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 180);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(126, 28);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 228);
            this.Controls.Add(this.layoutControlUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUserForm";
            this.Load += new System.EventHandler(this.frmUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlUser)).EndInit();
            this.layoutControlUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGroupSystemInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGroupPersonalInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlUser;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupUser;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraLayout.LayoutControlItem lblUserName;
        private DevExpress.XtraLayout.LayoutControlItem lblName;
        private DevExpress.XtraLayout.LayoutControlItem lblLastName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraLayout.LayoutControlGroup layoutGroupSystemInformation;
        private DevExpress.XtraLayout.LayoutControlItem lblPassword;
        private DevExpress.XtraLayout.LayoutControlGroup layoutGroupPersonalInformation;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}