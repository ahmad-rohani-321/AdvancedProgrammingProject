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
    public partial class SaveEmployee : XtraUserControl
    {
        public SaveEmployee()
        {
            InitializeComponent();
            GetData();
        }
        void GetData()
        {
            GridEmployees.DataSource = Controller.Employee.GetEmployees();
            GridEmployees.RefreshDataSource();
            GridEmployees.Refresh();
        }
        Model.Employees employees = new Model.Employees();
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if(employees.Eid != 0)
                {
                    employees.FullName = TxtFullName.Text;
                    employees.FatherName = TxtFatherName.Text;
                    employees.PhoneNo = TxtPhoneNo.Text;
                    employees.Job = TxtJob.Text;
                    employees.remarks = TxtRemarks.Text;
                    employees.branch = TxtBranch.Text;
                    bool u = Controller.Employee.Update(employees);
                    if (!u)
                    {
                        Defaults.SimpleMessageBox("د کارمند معلومات نه سو تغیر");
                    }
                    else
                    {
                        ClearForm();
                        employees = null;
                        GetData();
                    }
                }
                else
                {
                    Model.Employees emp = new Model.Employees();
                    emp.FullName = TxtFullName.Text;
                    emp.FatherName = TxtFatherName.Text;
                    emp.PhoneNo = TxtPhoneNo.Text;
                    emp.Job = TxtJob.Text;
                    emp.remarks = TxtRemarks.Text;
                    emp.branch = TxtBranch.Text;

                    bool V = Controller.Employee.Add(emp);
                    if (V)
                    {
                        ClearForm();
                        GetData();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("کارمند نه سو ثبت");
                    }
                }
            }
        }
        void ClearForm()
        {
            TxtFullName.Text = "";
            TxtFatherName.Text = "";
            TxtBranch.Text = "";
            TxtJob.Text = "";
            TxtPhoneNo.Text = "";
            TxtRemarks.Text = "";
        }
        bool Valid()
        {
            bool v = true;
            if (TxtFullName.Text == "" || TxtFullName.Text == null)
            {
                v = false;
                TxtFullName.ErrorText = "انتخاب سوی فیلډ حتمي دی";
            }
            else
            {
                TxtFullName.ErrorText = "";
            }

            if (TxtFatherName.Text == "" || TxtFatherName.Text == null)
            {
                v = false;
                TxtFatherName.ErrorText = "انتخاب سوی فیلډ حتمي دی";
            }
            else
            {
                TxtFatherName.ErrorText = "";
            }

            if (TxtPhoneNo.Text == "" || TxtPhoneNo.Text == null)
            {
                v = false;
                TxtPhoneNo.ErrorText = "انتخاب سوی فیلډ حتمي دی";
            }
            else
            {
                TxtPhoneNo.ErrorText = "";
            }

            if (TxtJob.Text == "" || TxtJob.Text == null)
            {
                v = false;
                TxtJob.ErrorText = "انتخاب سوی فیلډ حتمي دی";
            }
            else
            {
                TxtJob.ErrorText = "";
            }
            return v;
        }

        private void GridDepartments_DoubleClick(object sender, EventArgs e)
        {
            employees = (Model.Employees)ViewEmployees.GetRow(ViewEmployees.FocusedRowHandle);
            TxtFullName.Text = employees.FullName;
            TxtFatherName.Text = employees.FatherName;
            TxtBranch.Text = employees.branch;
            TxtJob.Text = employees.Job;
            TxtPhoneNo.Text = employees.PhoneNo;
            TxtRemarks.Text = employees.remarks;
        }

    }
}
