using System;
using System.Windows.Forms;
using LibraryManagementCore.BookManagement.Models;
using LibraryManagementCore;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Drawing;
using System.IO;

namespace LibraryManagement
{
    public partial class frmAddNewBook : DevExpress.XtraEditors.XtraForm
    {
        private Book _book;
        private readonly Core _core;
        private byte[] _customCover = new byte[0];
        private readonly Image _defaultCover;

        public frmAddNewBook(Core core)
        {
            InitializeComponent();

            _core = core;
            _core.Localization.RegisterNewControl(btnSaveNewBook);
            _core.Localization.RegisterNewControl(btnClearNewBookFields);
            _core.Localization.ApplyLocalization();

            _defaultCover = pictureCover.Image;
        }

        private void SetBookProperties()
        {
            _book = new Book
            {
                Isbn = txtISBN.Text,
                Title = txtTitle.Text,
                Publisher = txtPublisher.Text,
                PageCount = int.Parse(txtPageCount.Text),
                AverageRating = float.Parse(txtRating.Text),
                MaturityRating = txtMaturity.Text,
                Language = txtLanguage.Text,
                Description = txtDescription.Text,
                PublishedDate = datePublishedDate.DateTime,
                Cover = _customCover
            };

            foreach (var listAuthorsItem in listAuthors.Items)
            {
                _book.Authors.Add(new Author { Name = listAuthorsItem.ToString()});
            }
        }

        private void SetFieldsValues()
        {
            txtISBN.Text = _book.Isbn;
            txtTitle.Text = _book.Title;
            txtPublisher.Text = _book.Publisher;
            txtPageCount.Text = _book.PageCount.ToString();
            txtRating.Text = _book.AverageRating.ToString(CultureInfo.InvariantCulture);
            txtMaturity.Text = _book.MaturityRating;
            txtLanguage.Text = _book.Language;
            txtDescription.Text = _book.Description;
            datePublishedDate.DateTime = _book.PublishedDate;

            listAuthors.Items.Clear();
            foreach (var author in _book.Authors)
            {
                listAuthors.Items.Add(author.Name);
            }

            pictureCover.Image = ByteToImage(_book.Cover);
        }

        private void ClearFields()
        {
            Helpers.ClearLayoutControls(layoutControlGroup1);
            listAuthors.Items.Clear();
            pictureCover.Image = _defaultCover;
        }

        private bool ValidateFields()
        {
            try
            {
                Helpers.ValidateLayoutControls(layoutControlGroup1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
            return false;
        }

        private void txtISBN_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace((sender as TextEdit)?.Text)) return;
                _book = _core.BookManager.GetBookFromApi(txtISBN.Text);
                SetFieldsValues();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Bitmap ByteToImage(byte[] image)
        {
            var mStream = new MemoryStream();
            var pData = image;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            var bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private void frmAddNewBook_Load(object sender, EventArgs e)
        {
            pictureCover.AllowDrop = true;
            pictureCover.DragEnter += DragEnter;
            pictureCover.DragDrop += DragDrop;
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (!File.Exists(files[0])) return;

            try
            {
                var img = new Bitmap(files[0]);
                pictureCover.Image?.Dispose();
                pictureCover.Image = img;

                _customCover = (byte[])new ImageConverter().ConvertTo(img, typeof(byte[]));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Could not load the image file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveNewBook_Click(object sender, EventArgs e)
        {
            // Check if the fields are empty
            if (!ValidateFields())
            {
                return;
            }

            // If _book is null, that surely means that the fields were filled manually
            if (_book == null)
            {
                SetBookProperties();
            }

            // Check if the ISBN already exists in the data base
            var book = _core.BookManager.FindBook("isbn", txtISBN.Text);
            if (book != null)
            {
                XtraMessageBox.Show("A book with the same ISBN already exist in the database!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // If the previous checks were passed, we add the new book
            _core.BookManager.AddToCollection(_book);
            ClearFields();
        }

        private void btnClearNewBookFields_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listAuthors.SelectedIndex >= 0)
            {
                listAuthors.Items.RemoveAt(listAuthors.SelectedIndex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frmAuthor = new frmEditAuthor(_core))
            {
                var result = frmAuthor.ShowDialog();
                if (result == DialogResult.OK)
                {
                    listAuthors.Items.Add(frmAuthor.Author);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (listAuthors.SelectedIndex < 0)
            {
                return;
            }

            using (var frmAuthor = new frmEditAuthor(_core))
            {
                frmAuthor.Author = listAuthors.Items[listAuthors.SelectedIndex].ToString();
                var result = frmAuthor.ShowDialog();
                if (result == DialogResult.OK)
                {
                    listAuthors.Items.Add(frmAuthor.Author);
                }
            }
        }
    }
}