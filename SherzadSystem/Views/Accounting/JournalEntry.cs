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

namespace SherzadSystem.Views.Accounting
{
    public partial class JournalEntryControl : XtraUserControl
    {
        public JournalEntryControl()
        {
            InitializeComponent();
            Callendar.DateTime = DateTime.Now;
            TillAmount = Controller.Accounting.GetTillValue();
            TxtTillValue.Text = TillAmount.ToString();
        }
        decimal TillAmount = 0;
        private void CheckRevenue_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckRevenue.Checked)
            {
                CheckExpense.Checked = false;
                ListERCodes.Properties.DataSource = Controller.ERCodes.GetAllRevenueCodes();
                ListERCodes.Refresh();
            }
        }

        private void CheckExpense_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckExpense.Checked)
            {
                CheckRevenue.Checked = false;
                ListERCodes.Properties.DataSource = Controller.ERCodes.GetAllExpenseCodes();
                ListERCodes.Refresh();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if (CheckRevenue.Checked)
                {
                    decimal Amount = Convert.ToDecimal(TxtAmount.Text);
                    int ERCode = (int)ListERCodes.EditValue;
                    string remarks = "د " + ListERCodes.Text + " له طریقه " + TxtAmount.Text + " رسیدګي ترسره سوه. : " + TxtRemarks.Text;
                    bool AddJournalEntry = Controller.Accounting.InsertJournalEntry(Amount, ERCode, true, remarks);
                    if (AddJournalEntry)
                    {
                        Defaults.SimpleMessageBox("عملیه په بریا سره اجرا سوه");
                        ClearForm();
                    }else
                    {
                        Defaults.SimpleMessageBox("عملیه تکمیل نه سوه");
                    }

                }
                else if (CheckExpense.Checked)
                {
                    decimal Amount = Convert.ToDecimal(TxtAmount.Text);
                    int ERCode = (int)ListERCodes.EditValue;
                    string remarks = "د " + ListERCodes.Text + " له طریقه " + TxtAmount.Text + " بردګي ترسره سوه. : " + TxtRemarks.Text;
                    bool AddJournalEntry = Controller.Accounting.InsertJournalEntry(Amount, ERCode, false, remarks);
                    if (AddJournalEntry)
                    {
                        Defaults.SimpleMessageBox("عملیه په بریا سره اجرا سوه");
                        ClearForm();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("عملیه تکمیل نه سوه");
                    }
                }
            }
        }
        bool Valid()
        {
            bool ret = true;
            if (CheckRevenue.Checked == false && CheckExpense.Checked == false)
            {
                Defaults.SimpleMessageBox("د روزنامچې ډول مو نه دی انتخاب کړی");
                ret = false;
            }
            if(ListERCodes.EditValue == null)
            {
                ListERCodes.ErrorText = "د عاید / مصرف ډول انتخاب کړئ";
                ret = false;
            }else
            {
                ListERCodes.ErrorText = "";
            }
            if(TxtAmount.Text == null || TxtAmount.Text == "" || TxtAmount.Text == "0")
            {
                TxtAmount.ErrorText = "مبلغ باید تر صفر لوړ وی";
                ret = false;
            }
            else
            {
                TxtAmount.ErrorText = "";
            }
            if (CheckExpense.Checked && TillAmount <= 0)
            {
                Defaults.SimpleMessageBox("په دخل کي د ورکړي لپاره کافي مبلغ نه دی موجود");
                ret = false;
            }
            else if(CheckExpense.Checked && Convert.ToDecimal(TxtAmount.Text) > TillAmount)
            {
                TxtAmount.ErrorText = "په دخل کي په کافي اندازه مبلغ نه دی موجود";
                ret = false;
            }
            return ret;
        }

        void ClearForm()
        {
            CheckRevenue.Checked = false;
            CheckExpense.Checked = false;
            ListERCodes.Properties.DataSource = null;
            ListERCodes.Refresh();
            TxtTillValue.Text = Controller.Accounting.GetTillValue().ToString();
            TxtAmount.Text = 0.ToString();
            TxtRemarks.Text = "";
        }
    }
}
