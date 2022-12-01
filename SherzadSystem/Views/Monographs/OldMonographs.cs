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

namespace SherzadSystem.Views.Monographs
{
    public partial class OldMonographs : XtraUserControl
    {
        public OldMonographs()
        {
            InitializeComponent();
            GridMonographs.DataSource = Controller.Monograph.GetMonographs();
        }
        int rowid = 0;
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if (ValidCalculation())
                {
                    decimal recived = Convert.ToDecimal(TxtRecived.Text);
                    decimal discount = Convert.ToDecimal(TxtDiscount.Text);
                    object UID = ViewMonographs.GetFocusedRowCellValue("UniqueId");
                    string remarks = "د " + UID + " نمبر مونوګراف له طریقه " + recived + " مبلغ تادیه سو.";
                    bool Add = Controller.Monograph.AddJournal(rowid, discount, recived, remarks);


                    GridMonographs.DataSource = Controller.Monograph.GetMonographs();
                    GridMonographs.RefreshDataSource();
                    GridMonographs.Refresh();
                    ClearForm();
                }
            }
        }

        private void ClearForm()
        {
            rowid = 0;
            TxtDiscount.Text = "0";
            TxtRecived.Text = "0";
            TxtTotal.Text = "0";
            LabelDepositAmount.Visible = false;
        }

        bool ValidCalculation()
        {
            bool ret = true;
            decimal total = Convert.ToDecimal(TxtTotal.Text);
            decimal recived = Convert.ToDecimal(TxtRecived.Text);
            decimal discount = Convert.ToDecimal(TxtDiscount.Text);

            if ((total - (recived + discount)) < 0)
            {
                TxtTotal.ErrorText = "رسید/تخفیف باید تر مجموعه قیمت نه سي اضافه";
                ret = false;
            }
            else
            {
                TxtTotal.ErrorText = "";
            }
            return ret;
        }
        
        bool Valid()
        {
            bool v = true;
            if(TxtRecived.Text == null || TxtRecived.Text == "")
            {
                v = false;
                TxtRecived.ErrorText = "دلته تر صفر کم قیمت نه منل کیږي";
            }
            else
            {
                TxtRecived.ErrorText = "";
            }
            if (TxtDiscount.Text == null || TxtDiscount.Text == "")
            {
                v = false;
                TxtRecived.ErrorText = "دلته تر صفر کم قیمت نه منل کیږي";
            }
            else
            {
                TxtRecived.ErrorText = "";
            }
            return v;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if(TxtSearch.Text != null || TxtSearch.Text != "")
            {
                TxtSearch.ErrorText = "";
                GridMonographs.DataSource = Controller.Monograph.GetMonographBySearch(TxtSearch.Text);
                GridMonographs.RefreshDataSource();
                GridMonographs.Refresh();
            }
            else
            {
                TxtSearch.ErrorText = "د موضوع عنوان ولیکئ";
            }
        }
        private void GridMonographs_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                decimal price = Convert.ToDecimal(ViewMonographs.GetFocusedRowCellValue("totalPrice"));
                TxtTotal.Text = Math.Round(price).ToString();

                decimal recieved = Convert.ToDecimal(ViewMonographs.GetFocusedRowCellValue("totalRecived"));
                decimal discount = Convert.ToDecimal(ViewMonographs.GetFocusedRowCellValue("totalDiscount"));

                if ((recieved + discount) != 0)
                {
                    LabelDepositAmount.Text = "باقي مبلغ: " + (price - (recieved + discount)).ToString();
                    LabelDepositAmount.Visible = true;
                }
                else
                {
                    LabelDepositAmount.Visible = false;
                }
                this.rowid = (int)ViewMonographs.GetFocusedRowCellValue("Mid");
            }
            catch
            { }
        }

    }
}
