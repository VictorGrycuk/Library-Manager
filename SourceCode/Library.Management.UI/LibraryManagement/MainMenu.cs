using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using LibraryManagementCore;
using DevExpress.XtraEditors;

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
            if (_core.LoggedUser.Configuration?.Language != null)
            {
                _core.Localization.SetLocalization(_core.Localization.CurrentLocalization);
            }

            _core.Localization.RegisterNewControl(btnAddNewBook);
            _core.Localization.RegisterNewControl(btnBookCollection);
            _core.Localization.RegisterNewControl(pageBookManagement);
            _core.Localization.RegisterNewControl(lblLoggedAs);
            _core.Localization.ApplyLocalization();

            lblLoggedAs.Caption = lblLoggedAs.Caption.Replace("{0}", _core.LoggedUser.Username);

            // We get the system skin
            lookAndFeel.LookAndFeel.SetSkinStyle(_core.LoggedUser.Configuration?.Theme);

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

        private void btnAddNewUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new frmUserForm(_core))
            {
                frm.ShowDialog();
            }
        }

        private void skinRibbonGallery_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            
        }

        private void skinRibbonGallery_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            _core.LoggedUser.Configuration.Theme = e.Item.Tag.ToString();
            _core.UserManagement.UpdateUser(_core.LoggedUser);
        }

        private void btnExportDB_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (var sf = new SaveFileDialog())
                {
                    sf.FileName = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                    sf.Filter = "Database Object (*.db)|*.db";
                    sf.DefaultExt = ".json";
                    sf.AddExtension = true;

                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(Helpers.LoadLocalConfiguration().Database, sf.FileName);
                        XtraMessageBox.Show("The database was exported successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Something went wrong!\n" + ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}