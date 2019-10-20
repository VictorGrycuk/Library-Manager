using System;
using System.Linq;
using DevExpress.Data;
using DevExpress.XtraBars;
using LibraryManagementCore;

namespace LibraryManagement
{
    public partial class MainMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly Core _core;

        public MainMenu(Core libraryCore)
        {
            _core = libraryCore;

            InitializeComponent();

            // Localization Configuration
            _core.Localization.RegisterNewControl(btnAddNewBook);
            _core.Localization.RegisterNewControl(btnBookCollection);
            _core.Localization.RegisterNewControl(pageBookManagement);
            _core.Localization.RegisterNewControl(lblLoggedAs);
            _core.Localization.ApplyLocalization();

            lblLoggedAs.Caption = lblLoggedAs.Caption.Replace("{0}", _core.LoggedUser.Username);

            // Add the custom column 'Authors'
            gridBookTable.DataSource = _core.BookManager.GetAll();
            var unbound = gridView1.Columns.AddField("Authors");
            unbound.UnboundType = UnboundColumnType.String;
            unbound.VisibleIndex = gridView1.Columns.Count;
        }

        private void btnAddNewBook_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmAddNewBook(_core))
            {
                frm.ShowDialog();
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "Authors" || !e.IsGetData) return;
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var id = (Guid)view?.GetListSourceRowCellValue(e.ListSourceRowIndex, "Id");
            var author = _core.BookManager.GetAll().First(x => x.Id == id);
            var names = author.Authors.Select(x => x.Name).ToArray();
            e.Value = string.Join(", ", names);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }

        private void btnLanguageConfiguration_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmLanguageConfig(_core))
            {
                frm.ShowDialog();
            }
        }
    }
}