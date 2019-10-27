using System;
using System.Windows.Forms;
using LibraryManagementCore;

namespace LibraryManagement
{
    public partial class frmEditAuthor : DevExpress.XtraEditors.XtraForm
    {
        private readonly Core _core;
        public string Author;

        public frmEditAuthor(Core core)
        {
            _core = core;
            InitializeComponent();

            var test =_core.BookManager.GetAllAuthors();
            lookUpAuthors.Properties.DataSource = test;
            lookUpAuthors.Properties.DisplayMember = "Name";
        }

        private void frmEditAuthor_Load(object sender, EventArgs e)
        {
            lookUpAuthors.Properties.PopulateColumns();
            lookUpAuthors.Properties.Columns["Id"].Visible = false;
            lookUpAuthors.Text = Author;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Author = lookUpAuthors.Text;
            DialogResult = DialogResult.OK;
        }
    }
}