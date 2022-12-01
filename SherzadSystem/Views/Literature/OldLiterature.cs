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

namespace SherzadSystem.Views.Literature
{
    public partial class OldLiterature : XtraUserControl
    {
        public OldLiterature()
        {
            InitializeComponent();
            GridLiterature.DataSource = Controller.Literature.GetWritings();
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
                    object UID = ViewLiterature.GetFocusedRowCellValue("UniqueId");
                    string remarks = "د " + UID + " نمبر لیکني له طریقه " + recived + " مبلغ تادیه سو.";
                    bool Add = Controller.Literature.AddJournal(rowid, discount, recived, remarks);


                    GridLiterature.DataSource = Controller.Literature.GetWritings();
                    GridLiterature.RefreshDataSource();
                    GridLiterature.Refresh();
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
                TxtTotal.ErrorText = "رسید/تخفیف باید تر مجموعه قیمت اضافه نه سي";
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
                GridLiterature.DataSource = Controller.Literature.GetLiteratureBySearch(TxtSearch.Text);
                GridLiterature.RefreshDataSource();
                GridLiterature.Refresh();
            }
            else
            {
                TxtSearch.ErrorText = "د موضوع عنوان ولیکئ";
            }
        }
        private void GridMonographs_DoubleClick(object sender, EventArgs e)
        {
            decimal price = Convert.ToDecimal(ViewLiterature.GetFocusedRowCellValue("TotalAmount"));
            TxtTotal.Text = Math.Round(price).ToString();

            decimal recieved = Convert.ToDecimal(ViewLiterature.GetFocusedRowCellValue("TotalRecived"));
            decimal discount = Convert.ToDecimal(ViewLiterature.GetFocusedRowCellValue("TotalDiscount"));

            if((recieved + discount) != 0)
            {
                LabelDepositAmount.Text = "باقي مبلغ: " + Math.Round((price - (recieved + discount)), 0).ToString();
                LabelDepositAmount.Visible = true;
            }
            else
            {
                LabelDepositAmount.Visible = false;
            }
            this.rowid = (int)ViewLiterature.GetFocusedRowCellValue("Lid");
        }

    }
}
