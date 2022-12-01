using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace SherzadSystem.Views.Books
{
    public partial class Books : XtraUserControl
    {
        public Books()
        {
            InitializeComponent();
            TxtCat.Properties.DataSource = Controller.Books.GetBookCategories();
            TxtCat.Refresh();
            GetBooks();
        }
        Model.Books Book = new Model.Books();
        string FilePath = "";
        private void GetBooks()
        {
            GridBooks.DataSource = Controller.Books.GetBooks();
            GridBooks.RefreshDataSource();
            GridBooks.Refresh();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if(Book.Bid != 0)
                {
                    Book.BookName = TxtBookName.Text;
                    Book.BookAuthor = TxtBookAuthor.Text;
                    Book.PublishYear = Convert.ToInt32(TxtPublishYear.Text);
                    Book.PublishingIndustry = TxtPublishingIndustry.Text;
                    Book.Cate_id = Convert.ToInt32(TxtCat.EditValue);
                    bool Update = Controller.Books.Update(Book);
                    if (!Update)
                    {
                        Defaults.SimpleMessageBox("د کتاب معلومات نه سوه تغیر");
                    }
                    else
                    {
                        ClearForm();
                        GetBooks();
                    }
                }
                else
                {
                    var book = new Model.Books();
                    book.BookName = TxtBookName.Text;
                    book.BookAuthor = TxtBookAuthor.Text;
                    book.Cate_id = Convert.ToInt32(TxtCat.EditValue);
                    book.BookFile = TxtReadFile.Text;
                    book.PublishingIndustry = TxtPublishingIndustry.Text;
                    book.PublishYear = Convert.ToInt32(TxtPublishYear.Text);
                    bool V = Controller.Books.AddBook(book, TxtReadFile.Text, FilePath);
                    if (V)
                    {
                        ClearForm();
                        GetBooks();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("کتاب ثبت نه سو");
                    }
                }
            }
        }

        private void ClearForm()
        {
            Book = null;
            TxtBookName.Text = "";
            TxtBookAuthor.Text = "";
            TxtPublishYear.Text = "";
            TxtPublishingIndustry.Text = "";
        }

        bool Valid()
        {
            bool v = true;
            if (TxtBookName.Text == "" || TxtBookName.Text == null)
            {
                v = false;
                TxtBookName.ErrorText = "د کتاب نوم حتمي دی";
            }
            else
            {
                TxtBookName.ErrorText = "";
            }

            if (TxtBookAuthor.Text == "" || TxtBookAuthor.Text == null)
            {
                v = false;
                TxtBookAuthor.ErrorText = "د کتاب لیکوال حتمي دی";
            }
            else
            {
                TxtBookAuthor.ErrorText = "";
            }

            if (TxtPublishYear.Text == "" || TxtPublishYear.Text == null)
            {
                v = false;
                TxtPublishYear.ErrorText = "د چاپ کال حتمي دی";
            }
            else
            {
                TxtPublishYear.ErrorText = "";
            }

            if (TxtPublishingIndustry.Text == "" || TxtPublishingIndustry.Text == null)
            {
                v = false;
                TxtPublishingIndustry.ErrorText = "د چاپ مطبوعه حتمي دی";
            }
            else
            {
                TxtPublishingIndustry.ErrorText = "";
            }
            if(TxtCat.EditValue == null || TxtCat.EditValue.Equals(0))
            {
                TxtCat.ErrorText = "کټیګوري نوم  حتمي دی";
                v = false;
            }
            else
            {
                TxtCat.ErrorText = "";
            }
            return v;
        }

        private void GridBooks_DoubleClick(object sender, EventArgs e)
        {
            this.Book = (Model.Books)ViewBooks.GetRow(ViewBooks.FocusedRowHandle);
            TxtBookName.Text = Book.BookName;
            TxtBookAuthor.Text = Book.BookAuthor;
            TxtPublishYear.Text = Book.PublishYear.ToString();
            TxtPublishingIndustry.Text = Book.PublishingIndustry;
            TxtCat.EditValue = Book.Cate_id;
        }

        private void TxtReadFile_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "PDF files (*.pdf)|*.pdf";
            DialogResult rd = opd.ShowDialog();
            if(rd == DialogResult.OK)
            {
                TxtReadFile.Text = opd.SafeFileName;
                this.FilePath = opd.FileName;
            }
        }

        private void BtnReadBook_Click(object sender, EventArgs e)
        {
            string file = (string)ViewBooks.GetFocusedRowCellValue("BookFile");
            using (Forms.ReadBook r = new Forms.ReadBook(file))
            {
                
                if(file == null || !File.Exists(Environment.CurrentDirectory + @"\Assets\Books\" + file))
                {
                    Defaults.SimpleMessageBox("فایل نه دی موجود");
                }
                else
                {
                    r.ShowDialog();
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GridBooks.DataSource = Controller.Books.GetBooks(TxtSearch.Text);
        }
    }
}
