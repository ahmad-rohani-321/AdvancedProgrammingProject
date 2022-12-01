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
    public partial class LiteratureReport : XtraUserControl
    {
        public LiteratureReport()
        {
            InitializeComponent();
            SelectPerson.Properties.DataSource = Controller.Person.GetAllPeople();
            SelectPerson.Properties.ValueMember = "PIid";
            SelectPerson.Properties.DisplayMember = "FirstName";

            GridMonographs.DataSource = Controller.Literature.GetLiteratureReport();

            StartDate.DateTime = DateTime.Now.AddDays(-30);
            EndDate.DateTime = DateTime.Now;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string[] ItemsInString = SelectPerson.EditValue.ToString().Split(','); ;
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
                GridMonographs.DataSource = Controller.Literature.GetLiteratureReport(StartDate.DateTime, EndDate.DateTime, ItemsList.ToArray());
                GridMonographs.RefreshDataSource();
                GridMonographs.Refresh();
            }
        }
        bool Valid()
        {
            bool IsTrue = true;
            if(SelectPerson.Text == "" || SelectPerson.Text == null)
            {
                SelectPerson.ErrorText = "شخص مو نه دی انتخاب کړئ";
                IsTrue = false;
            }
            else
            {
                SelectPerson.ErrorText = "";
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
