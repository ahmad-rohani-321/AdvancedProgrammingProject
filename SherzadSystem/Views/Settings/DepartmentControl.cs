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

namespace SherzadSystem.Views.Settings
{
    public partial class DepartmentControl : XtraUserControl
    {
        public DepartmentControl()
        {
            InitializeComponent();
            GetData();
        }
        void GetData()
        {
            GridDepartments.DataSource = Controller.Departments.GetAllDepartment();
            GridDepartments.RefreshDataSource();
            GridDepartments.Refresh();
        }
        Model.Departments departments = new Model.Departments();
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if(departments.Did != 0)
                {
                    departments.DepartmentName = TxtDepartment.Text;
                    bool u = Controller.Departments.Update(departments);
                    if (!u)
                    {
                        Defaults.SimpleMessageBox("د څانګي نوم نه سو تغیر");
                    }
                    else
                    {
                        TxtDepartment.Text = "";
                        departments = null;
                        GetData();
                    }
                }
                else
                {
                    bool V = Controller.Departments.Add(TxtDepartment.Text);
                    if (V)
                    {
                        TxtDepartment.Text = "";
                        GetData();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("څانګه نه سوه ثبت");
                    }
                }
            }
        }
        bool Valid()
        {
            bool v = true;
            if(TxtDepartment.Text == "" || TxtDepartment.Text == null)
            {
                v = false;
                TxtDepartment.ErrorText = "د څانګي نوم حتمي دی";
            }
            else
            {
                TxtDepartment.ErrorText = "";
            }
            return v;
        }

        private void GridDepartments_DoubleClick(object sender, EventArgs e)
        {
            departments = (Model.Departments)ViewDepartments.GetRow(ViewDepartments.FocusedRowHandle);
            TxtDepartment.Text = departments.DepartmentName;
        }
    }
}
