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
            this.btnAddNewUser = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGallery = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonMainMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageBookManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageMembersManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageReservationManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonConfiguration = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.pageUserManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageLocalization = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockBookSearch = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridBookTable = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dockBookSearch.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.btnLanguageConfiguration,
            this.btnAddNewUser,
            this.skinRibbonGallery});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
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
            // 
            // btnLanguageConfiguration
            // 
            this.btnLanguageConfiguration.Caption = "Language Configuration";
            this.btnLanguageConfiguration.Id = 4;
            this.btnLanguageConfiguration.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLanguageConfiguration.LargeGlyph")));
            this.btnLanguageConfiguration.Name = "btnLanguageConfiguration";
            this.btnLanguageConfiguration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLanguageConfiguration_ItemClick);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Caption = "Add New User";
            this.btnAddNewUser.Id = 7;
            this.btnAddNewUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddNewUser.LargeGlyph")));
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddNewUser_ItemClick);
            // 
            // skinRibbonGallery
            // 
            this.skinRibbonGallery.Caption = "skinRibbonGalleryBarItem1";
            // 
            // 
            // 
            this.skinRibbonGallery.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGallery_Gallery_ItemClick);
            this.skinRibbonGallery.Id = 8;
            this.skinRibbonGallery.Name = "skinRibbonGallery";
            this.skinRibbonGallery.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGallery_GalleryItemClick);
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
            this.pageUserManagement,
            this.pageLocalization});
            this.ribbonConfiguration.Name = "ribbonConfiguration";
            this.ribbonConfiguration.Text = "Configuration";
            // 
            // pageUserManagement
            // 
            this.pageUserManagement.ItemLinks.Add(this.btnAddNewUser);
            this.pageUserManagement.Name = "pageUserManagement";
            this.pageUserManagement.Text = "User Management";
            // 
            // pageLocalization
            // 
            this.pageLocalization.ItemLinks.Add(this.btnLanguageConfiguration);
            this.pageLocalization.ItemLinks.Add(this.skinRibbonGallery);
            this.pageLocalization.Name = "pageLocalization";
            this.pageLocalization.Text = "Customization";
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
            this.dockBookSearch});
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
        private DevExpress.XtraGrid.GridControl gridBookTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Docking.DockPanel dockBookSearch;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.BarButtonItem btnLanguageConfiguration;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageLocalization;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageMembersManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageReservationManagement;
        private DevExpress.XtraBars.BarButtonItem btnAddNewUser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup pageUserManagement;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGallery;
        private DevExpress.LookAndFeel.DefaultLookAndFeel lookAndFeel;
    }
}