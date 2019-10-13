namespace LibraryManagement
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::LibraryManagement.Splash), true, false);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.lblLoggedAs = new DevExpress.XtraBars.BarStaticItem();
            this.btnAddNewBook = new DevExpress.XtraBars.BarButtonItem();
            this.btnBookCollection = new DevExpress.XtraBars.BarButtonItem();
            this.btnLanguageConfiguration = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonMainMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageBookManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageMembersManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageReservationManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonConfiguration = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageLocalization = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockBookSearch = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridBookTable = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dockAddNewBook = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnReadFromCamera = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtRating = new DevExpress.XtraEditors.TextEdit();
            this.txtLanguage = new DevExpress.XtraEditors.TextEdit();
            this.txtMaturity = new DevExpress.XtraEditors.TextEdit();
            this.listAuthors = new DevExpress.XtraEditors.ListBoxControl();
            this.txtISBN = new DevExpress.XtraEditors.ButtonEdit();
            this.txtPageCount = new DevExpress.XtraEditors.TextEdit();
            this.txtPublisher = new DevExpress.XtraEditors.TextEdit();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutBookTitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutISBN = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Description = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dockBookSearch.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.dockAddNewBook.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRating.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaturity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listAuthors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtISBN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPublisher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBookTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutISBN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Description)).BeginInit();
            this.SuspendLayout();
            // 
            // splashManager
            // 
            splashManager.ClosingDelay = 1000;
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.lblLoggedAs,
            this.btnAddNewBook,
            this.btnBookCollection,
            this.btnLanguageConfiguration});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 7;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonMainMenu,
            this.ribbonConfiguration});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(790, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // lblLoggedAs
            // 
            this.lblLoggedAs.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblLoggedAs.Caption = "barStaticItem1";
            this.lblLoggedAs.Id = 1;
            this.lblLoggedAs.Name = "lblLoggedAs";
            this.lblLoggedAs.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnAddNewBook
            // 
            this.btnAddNewBook.Caption = "Add New Book";
            this.btnAddNewBook.Id = 2;
            this.btnAddNewBook.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddNewBook.LargeGlyph")));
            this.btnAddNewBook.Name = "btnAddNewBook";
            this.btnAddNewBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddNewBook_ItemClick);
            // 
            // btnBookCollection
            // 
            this.btnBookCollection.Caption = "Book Collection";
            this.btnBookCollection.Id = 3;
            this.btnBookCollection.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBookCollection.LargeGlyph")));
            this.btnBookCollection.Name = "btnBookCollection";
            this.btnBookCollection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearchBook_ItemClick);
            // 
            // btnLanguageConfiguration
            // 
            this.btnLanguageConfiguration.Caption = "Language Configuration";
            this.btnLanguageConfiguration.Id = 4;
            this.btnLanguageConfiguration.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLanguageConfiguration.LargeGlyph")));
            this.btnLanguageConfiguration.Name = "btnLanguageConfiguration";
            this.btnLanguageConfiguration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLanguageConfiguration_ItemClick);
            // 
            // ribbonMainMenu
            // 
            this.ribbonMainMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pageBookManagement,
            this.pageMembersManagement,
            this.pageReservationManagement});
            this.ribbonMainMenu.Name = "ribbonMainMenu";
            this.ribbonMainMenu.Text = "Main Menu";
            // 
            // pageBookManagement
            // 
            this.pageBookManagement.ItemLinks.Add(this.btnAddNewBook);
            this.pageBookManagement.ItemLinks.Add(this.btnBookCollection);
            this.pageBookManagement.Name = "pageBookManagement";
            this.pageBookManagement.Text = "Book Management";
            // 
            // pageMembersManagement
            // 
            this.pageMembersManagement.Name = "pageMembersManagement";
            this.pageMembersManagement.Text = "Members Management";
            // 
            // pageReservationManagement
            // 
            this.pageReservationManagement.Name = "pageReservationManagement";
            this.pageReservationManagement.Text = "Reservation Management";
            // 
            // ribbonConfiguration
            // 
            this.ribbonConfiguration.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.pageLocalization});
            this.ribbonConfiguration.Name = "ribbonConfiguration";
            this.ribbonConfiguration.Text = "Configuration";
            // 
            // pageLocalization
            // 
            this.pageLocalization.ItemLinks.Add(this.btnLanguageConfiguration);
            this.pageLocalization.Name = "pageLocalization";
            this.pageLocalization.Text = "Localization";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lblLoggedAs);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 568);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(790, 31);
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockBookSearch,
            this.dockAddNewBook});
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockBookSearch
            // 
            this.dockBookSearch.Controls.Add(this.controlContainer1);
            this.dockBookSearch.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockBookSearch.FloatLocation = new System.Drawing.Point(3992, 1418);
            this.dockBookSearch.FloatSize = new System.Drawing.Size(720, 480);
            this.dockBookSearch.FloatVertical = true;
            this.dockBookSearch.ID = new System.Guid("351efbe3-0f33-4963-8c66-9c9584616624");
            this.dockBookSearch.Location = new System.Drawing.Point(-32768, -32768);
            this.dockBookSearch.Name = "dockBookSearch";
            this.dockBookSearch.OriginalSize = new System.Drawing.Size(720, 382);
            this.dockBookSearch.SavedIndex = 0;
            this.dockBookSearch.Size = new System.Drawing.Size(720, 480);
            this.dockBookSearch.Text = "Book Search";
            this.dockBookSearch.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.gridBookTable);
            this.controlContainer1.Location = new System.Drawing.Point(3, 22);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(714, 455);
            this.controlContainer1.TabIndex = 0;
            // 
            // gridBookTable
            // 
            this.gridBookTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBookTable.Location = new System.Drawing.Point(0, 0);
            this.gridBookTable.MainView = this.gridView1;
            this.gridBookTable.MenuManager = this.ribbon;
            this.gridBookTable.Name = "gridBookTable";
            this.gridBookTable.Size = new System.Drawing.Size(714, 455);
            this.gridBookTable.TabIndex = 4;
            this.gridBookTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridBookTable;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            // 
            // dockAddNewBook
            // 
            this.dockAddNewBook.Controls.Add(this.dockPanel1_Container);
            this.dockAddNewBook.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockAddNewBook.FloatLocation = new System.Drawing.Point(4467, 1446);
            this.dockAddNewBook.FloatSize = new System.Drawing.Size(570, 365);
            this.dockAddNewBook.ID = new System.Guid("afc126e4-c747-4b34-a9e6-33f3ef5bd800");
            this.dockAddNewBook.Location = new System.Drawing.Point(-32768, -32768);
            this.dockAddNewBook.Name = "dockAddNewBook";
            this.dockAddNewBook.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.None;
            this.dockAddNewBook.Options.ShowMaximizeButton = false;
            this.dockAddNewBook.OriginalSize = new System.Drawing.Size(590, 200);
            this.dockAddNewBook.SavedIndex = 0;
            this.dockAddNewBook.Size = new System.Drawing.Size(570, 365);
            this.dockAddNewBook.Text = "Add new Book";
            this.dockAddNewBook.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnReadFromCamera);
            this.dockPanel1_Container.Controls.Add(this.btnClear);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.picCover);
            this.dockPanel1_Container.Controls.Add(this.layoutControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 22);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(564, 340);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnReadFromCamera
            // 
            this.btnReadFromCamera.Location = new System.Drawing.Point(79, 309);
            this.btnReadFromCamera.Name = "btnReadFromCamera";
            this.btnReadFromCamera.Size = new System.Drawing.Size(75, 23);
            this.btnReadFromCamera.TabIndex = 4;
            this.btnReadFromCamera.Text = "Read ISBN";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(160, 309);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(241, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picCover
            // 
            this.picCover.Location = new System.Drawing.Point(322, 13);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(229, 290);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCover.TabIndex = 3;
            this.picCover.TabStop = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.txtRating);
            this.layoutControl1.Controls.Add(this.txtLanguage);
            this.layoutControl1.Controls.Add(this.txtMaturity);
            this.layoutControl1.Controls.Add(this.listAuthors);
            this.layoutControl1.Controls.Add(this.txtISBN);
            this.layoutControl1.Controls.Add(this.txtPageCount);
            this.layoutControl1.Controls.Add(this.txtPublisher);
            this.layoutControl1.Controls.Add(this.txtTitle);
            this.layoutControl1.Location = new System.Drawing.Point(8, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(4676, 1258, 550, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(320, 312);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(71, 200);
            this.txtDescription.MenuManager = this.ribbon;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(237, 100);
            this.txtDescription.StyleController = this.layoutControl1;
            this.txtDescription.TabIndex = 2;
            // 
            // txtRating
            // 
            this.txtRating.EditValue = "";
            this.txtRating.Location = new System.Drawing.Point(221, 152);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(87, 20);
            this.txtRating.StyleController = this.layoutControl1;
            this.txtRating.TabIndex = 3;
            // 
            // txtLanguage
            // 
            this.txtLanguage.EditValue = "";
            this.txtLanguage.Location = new System.Drawing.Point(221, 176);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(87, 20);
            this.txtLanguage.StyleController = this.layoutControl1;
            this.txtLanguage.TabIndex = 3;
            // 
            // txtMaturity
            // 
            this.txtMaturity.EditValue = "";
            this.txtMaturity.Location = new System.Drawing.Point(71, 176);
            this.txtMaturity.Name = "txtMaturity";
            this.txtMaturity.Size = new System.Drawing.Size(87, 20);
            this.txtMaturity.StyleController = this.layoutControl1;
            this.txtMaturity.TabIndex = 3;
            // 
            // listAuthors
            // 
            this.listAuthors.Location = new System.Drawing.Point(71, 60);
            this.listAuthors.Name = "listAuthors";
            this.listAuthors.Size = new System.Drawing.Size(237, 64);
            this.listAuthors.StyleController = this.layoutControl1;
            this.listAuthors.TabIndex = 2;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(71, 12);
            this.txtISBN.MenuManager = this.ribbon;
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.txtISBN.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtISBN_Properties_ButtonClick);
            this.txtISBN.Size = new System.Drawing.Size(237, 20);
            this.txtISBN.StyleController = this.layoutControl1;
            this.txtISBN.TabIndex = 4;
            // 
            // txtPageCount
            // 
            this.txtPageCount.EditValue = "";
            this.txtPageCount.Location = new System.Drawing.Point(71, 152);
            this.txtPageCount.Name = "txtPageCount";
            this.txtPageCount.Size = new System.Drawing.Size(87, 20);
            this.txtPageCount.StyleController = this.layoutControl1;
            this.txtPageCount.TabIndex = 3;
            // 
            // txtPublisher
            // 
            this.txtPublisher.EditValue = "";
            this.txtPublisher.Location = new System.Drawing.Point(71, 128);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(237, 20);
            this.txtPublisher.StyleController = this.layoutControl1;
            this.txtPublisher.TabIndex = 3;
            // 
            // txtTitle
            // 
            this.txtTitle.EditValue = "";
            this.txtTitle.Location = new System.Drawing.Point(71, 36);
            this.txtTitle.MenuManager = this.ribbon;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(237, 20);
            this.txtTitle.StyleController = this.layoutControl1;
            this.txtTitle.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutBookTitle,
            this.layoutISBN,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.Description});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(320, 312);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutBookTitle
            // 
            this.layoutBookTitle.Control = this.txtTitle;
            this.layoutBookTitle.Location = new System.Drawing.Point(0, 24);
            this.layoutBookTitle.Name = "layoutBookTitle";
            this.layoutBookTitle.Size = new System.Drawing.Size(300, 24);
            this.layoutBookTitle.Text = "Book Title";
            this.layoutBookTitle.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutISBN
            // 
            this.layoutISBN.Control = this.txtISBN;
            this.layoutISBN.Location = new System.Drawing.Point(0, 0);
            this.layoutISBN.Name = "layoutISBN";
            this.layoutISBN.Size = new System.Drawing.Size(300, 24);
            this.layoutISBN.Text = "ISBN";
            this.layoutISBN.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.listAuthors;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 68);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(114, 68);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(300, 68);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Author/s";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtPublisher;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem4.Text = "Publisher";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPageCount;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 140);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem5.Text = "Page Count";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtRating;
            this.layoutControlItem6.Location = new System.Drawing.Point(150, 140);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem6.Text = "Rating";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtMaturity;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 164);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem7.Text = "Maturity";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtLanguage;
            this.layoutControlItem8.Location = new System.Drawing.Point(150, 164);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem8.Text = "Language";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(56, 13);
            // 
            // Description
            // 
            this.Description.Control = this.txtDescription;
            this.Description.Location = new System.Drawing.Point(0, 188);
            this.Description.MinSize = new System.Drawing.Size(74, 20);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(300, 104);
            this.Description.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Description.TextSize = new System.Drawing.Size(56, 13);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 599);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "MainMenu";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dockBookSearch.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBookTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.dockAddNewBook.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRating.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaturity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listAuthors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtISBN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPublisher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBookTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutISBN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Description)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonMainMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageBookManagement;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem lblLoggedAs;
        private DevExpress.XtraBars.BarButtonItem btnAddNewBook;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonConfiguration;
        private DevExpress.XtraBars.BarButtonItem btnBookCollection;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockAddNewBook;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtRating;
        private DevExpress.XtraEditors.TextEdit txtLanguage;
        private DevExpress.XtraEditors.TextEdit txtMaturity;
        private DevExpress.XtraEditors.ListBoxControl listAuthors;
        private DevExpress.XtraEditors.ButtonEdit txtISBN;
        private DevExpress.XtraEditors.TextEdit txtPageCount;
        private DevExpress.XtraEditors.TextEdit txtPublisher;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutBookTitle;
        private DevExpress.XtraLayout.LayoutControlItem layoutISBN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem Description;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.PictureBox picCover;
        private DevExpress.XtraGrid.GridControl gridBookTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Docking.DockPanel dockBookSearch;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.SimpleButton btnReadFromCamera;
        private DevExpress.XtraBars.BarButtonItem btnLanguageConfiguration;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageLocalization;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageMembersManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageReservationManagement;
    }
}