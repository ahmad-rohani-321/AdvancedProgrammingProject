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
using System.Text.RegularExpressions;

namespace SherzadSystem.Views.Report
{
    public partial class EmployeeReport : XtraUserControl
    {
        public EmployeeReport()
        {
            InitializeComponent();
            SelectERType.Properties.DataSource = Controller.Employee.GetEmployees();
            SelectERType.Properties.ValueMember = "Eid";
            SelectERType.Properties.DisplayMember = "FullName";

            GridJournal.DataSource = Controller.Employee.GetEmployeeAccounting();

            StartDate.DateTime = DateTime.Now.AddDays(-30);
            EndDate.DateTime = DateTime.Now;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string[] ItemsInString = SelectERType.EditValue.ToString().Split(','); ;
            List<int> ItemsList = new List<int>();
            foreach (string ch in ItemsInString)
            {
                Regex regex = new Regex("[^0 - 9]");
                if (regex.IsMatch(ch))
                {
                    ItemsList.Add(Convert.ToInt32(ch));
                }
            }
            if (Valid())
            {
                GridJournal.DataSource = Controller.Employee.GetEmployeeAccounting(StartDate.DateTime, EndDate.DateTime, ItemsList.ToArray());
                GridJournal.RefreshDataSource();
                GridJournal.Refresh();
            }
        }
        bool Valid()
        {
            bool IsTrue = true;
            if(SelectERType.Text == "" || SelectERType.Text == null)
            {
                SelectERType.ErrorText = "کارمند مو نه دی انتخاب کړئ";
                IsTrue = false;
            }
            else
            {
                SelectERType.ErrorText = "";
            }

            if (StartDate.DateTime > EndDate.DateTime)
            {
                StartDate.ErrorText = "د شروع نېته باید د ختم د نېټې څخه وروسته نه وي";
                IsTrue = false;
            }
            else
            {
                StartDate.ErrorText = "";
            }
            return IsTrue;
        }
    }
}
