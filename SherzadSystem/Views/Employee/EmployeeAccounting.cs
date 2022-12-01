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

namespace SherzadSystem.Views.Employee
{
    public partial class EmployeeAccounting : XtraUserControl
    {
        public EmployeeAccounting()
        {
            InitializeComponent();
            GetData();
            till = Controller.Accounting.GetTillValue();
            TxtTillValue.Text = Math.Round(till, 0).ToString();
        }
        decimal till = 0;
        private int Eid { get; set; }
        void GetData()
        {
            GridEmployees.DataSource = Controller.Employee.GetEmployees();
            GridEmployees.RefreshDataSource();
            GridEmployees.Refresh();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                decimal Amount = Convert.ToInt32(TxtAmount.Text);
                int Id = (int)ViewEmployees.GetFocusedRowCellValue("Eid");
                string EName = (string)ViewEmployees.GetFocusedRowCellValue("");
                string remarks = $"د {EName} په حساب کي {Amount} تحویل سوې.";
                bool AddJournal = Controller.Employee.AddJournal(Id, Amount, remarks);
                if (AddJournal)
                {
                    Defaults.SimpleMessageBox("عملیه په بریا سره اجرا سوه");
                    ClearForm();
                }else
                {
                    Defaults.SimpleMessageBox("عملیه تکمیل نه سوه");
                }
            }
        }
        void ClearForm()
        {
            TxtAmount.Text = "";
            TxtRemarks.Text = "";

            till = Controller.Accounting.GetTillValue();
            TxtTillValue.Text = Math.Round(till, 0).ToString();
        }
        bool Valid()
        {
            bool v = true;
            if (TxtAmount.Text == "" || TxtAmount.Text == null)
            {
                v = false;
                TxtAmount.ErrorText = "انتخاب سوی فیلډ حتمي دی";
            }
            else
            {
                TxtAmount.ErrorText = "";
            }
            decimal amount = Convert.ToDecimal(TxtAmount.Text);
            if(amount > till)
            {
                TxtAmount.ErrorText = $"{amount} مبلغ په دخل کي نه دی موجود";
                v = false;
            }
            else
            {
                TxtAmount.ErrorText = "";
            }

            return v;
        }

        private void GridDepartments_DoubleClick(object sender, EventArgs e)
        {
            int Eid = Convert.ToInt32(ViewEmployees.GetFocusedRowCellValue("Eid"));
        }

    }
}
