namespace LibraryManagement
{
    partial class frmLanguageConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLanguageConfig));
            this.lblAvailableLanguage = new DevExpress.XtraEditors.LabelControl();
            this.comboAvailableLangauges = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnApplyLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportLocalization = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportLocalization = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.comboAvailableLangauges.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAvailableLanguage
            // 
            this.lblAvailableLanguage.Location = new System.Drawing.Point(3, 3);
            this.lblAvailableLanguage.Name = "lblAvailableLanguage";
            this.lblAvailableLanguage.Size = new System.Drawing.Size(102, 13);
            this.lblAvailableLanguage.TabIndex = 0;
            this.lblAvailableLanguage.Text = "Available Languages:";
            // 
            // comboAvailableLangauges
            // 
            this.comboAvailableLangauges.Location = new System.Drawing.Point(111, 3);
            this.comboAvailableLangauges.Name = "comboAvailableLangauges";
            this.comboAvailableLangauges.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboAvailableLangauges.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboAvailableLangauges.Size = new System.Drawing.Size(108, 20);
            this.comboAvailableLangauges.TabIndex = 0;
            // 
            // btnApplyLanguage
            // 
            this.btnApplyLanguage.Image = ((System.Drawing.Image)(resources.GetObject("btnApplyLanguage.Image")));
            this.btnApplyLanguage.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnApplyLanguage.Location = new System.Drawing.Point(317, 12);
            this.btnApplyLanguage.Name = "btnApplyLanguage";
            this.btnApplyLanguage.Size = new System.Drawing.Size(96, 55);
            this.btnApplyLanguage.TabIndex = 1;
            this.btnApplyLanguage.Text = "Apply Language";
            this.btnApplyLanguage.Click += new System.EventHandler(this.btnApplyLanguage_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblAvailableLanguage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboAvailableLangauges, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnExportLocalization
            // 
            this.btnExportLocalization.Image = ((System.Drawing.Image)(resources.GetObject("btnExportLocalization.Image")));
            this.btnExportLocalization.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExportLocalization.Location = new System.Drawing.Point(317, 134);
            this.btnExportLocalization.Name = "btnExportLocalization";
            this.btnExportLocalization.Size = new System.Drawing.Size(96, 55);
            this.btnExportLocalization.TabIndex = 3;
            this.btnExportLocalization.Text = "Export Language";
            this.btnExportLocalization.Click += new System.EventHandler(this.btnExportLocalization_Click);
            // 
            // btnImportLocalization
            // 
            this.btnImportLocalization.Image = ((System.Drawing.Image)(resources.GetObject("btnImportLocalization.Image")));
            this.btnImportLocalization.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnImportLocalization.Location = new System.Drawing.Point(317, 73);
            this.btnImportLocalization.Name = "btnImportLocalization";
            this.btnImportLocalization.Size = new System.Drawing.Size(96, 55);
            this.btnImportLocalization.TabIndex = 2;
            this.btnImportLocalization.Text = "Import Language";
            this.btnImportLocalization.Click += new System.EventHandler(this.btnImportLocalization_Click);
            // 
            // frmLanguageConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 201);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnImportLocalization);
            this.Controls.Add(this.btnExportLocalization);
            this.Controls.Add(this.btnApplyLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLanguageConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LanguageConfig";
            this.Load += new System.EventHandler(this.frmLanguageConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboAvailableLangauges.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblAvailableLanguage;
        private DevExpress.XtraEditors.ComboBoxEdit comboAvailableLangauges;
        private DevExpress.XtraEditors.SimpleButton btnApplyLanguage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExportLocalization;
        private DevExpress.XtraEditors.SimpleButton btnImportLocalization;
    }
}