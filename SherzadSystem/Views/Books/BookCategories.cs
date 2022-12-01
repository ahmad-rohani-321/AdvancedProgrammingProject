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

namespace SherzadSystem.Views.Books
{
    public partial class BookCategories : XtraUserControl
    {
        public BookCategories()
        {
            InitializeComponent();
            
            GetBooks();
        }
        Model.BookCategories cat = null;
        private void GetBooks()
        {
            GridBooks.DataSource = Controller.Books.GetBookCategories();
            GridBooks.RefreshDataSource();
            GridBooks.Refresh();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if(cat != null )
                {
                    cat.CategoryName = TxtCatName.Text;
                    bool Update = Controller.Books.UpdateCategory(cat);
                    if (!Update)
                    {
                        Defaults.SimpleMessageBox("د کټیګوري نوم نه سو تغیر");
                    }
                    else
                    {
                        ClearForm();
                        GetBooks();
                    }
                }
                else
                {

                    string CategoryName = TxtCatName.Text;
                    bool V = Controller.Books.AddCategory(CategoryName);
                    if (V)
                    {
                        ClearForm();
                        GetBooks();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("کتاب نه سو ثبت");
                    }
                }
            }
        }

        private void ClearForm()
        {
            cat = null;
            TxtCatName.Text = "";
        }

        bool Valid()
        {
            bool v = true;
            if (TxtCatName.Text == "" || TxtCatName.Text == null)
            {
                v = false;
                TxtCatName.ErrorText = "د کتاب نوم حتمي دی";
            }
            else
            {
                TxtCatName.ErrorText = "";
            }

            
            return v;
        }

        private void GridBooks_DoubleClick(object sender, EventArgs e)
        {
            this.cat = (Model.BookCategories)ViewBooks.GetRow(ViewBooks.FocusedRowHandle);
            TxtCatName.Text = cat.CategoryName;
        }
    }
}
