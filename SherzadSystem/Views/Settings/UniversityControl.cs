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
    public partial class UniversityControl : XtraUserControl
    {
        public UniversityControl()
        {
            InitializeComponent();
            GetData();
        }
        Model.Universities universities = new Model.Universities();
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if(universities.Uid != 0)
                {
                    universities.UniversityName = TxtUniversities.Text;
                    bool update = Controller.Universities.Update(universities);
                    if (!update)
                    {
                        Defaults.SimpleMessageBox("د پوهنتون نوم نه سو تغیر");
                    }
                    else
                    {
                        universities = null;
                        TxtUniversities.Text = "";
                        GetData();
                    }
                }
                else
                {
                    bool Added = Controller.Universities.AddUniversity(new Model.Universities() { UniversityName = TxtUniversities.Text });
                    if (Added)
                    {
                        TxtUniversities.Text = "";
                        GetData();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("پوهنتون نه سو ثبت");
                    }
                }
            }
        }

        bool Valid()
        {
            bool IsValid = true;
            if(TxtUniversities.Text == "" || TxtUniversities.Text == null)
            {
                IsValid = false;
                TxtUniversities.ErrorText = "د پوهنتون نوم حتمي دی";
            }
            else
            {
                TxtUniversities.ErrorText = "";
            }
            return IsValid;
        }
        void GetData()
        {
            GridUniversities.DataSource = Controller.Universities.GetUniversities();
            GridUniversities.Refresh();
            GridUniversities.RefreshDataSource();
        }
        private void ViewUsers_DoubleClick(object sender, EventArgs e)
        {
            universities = (Model.Universities)ViewUniversities.GetFocusedRow();
            TxtUniversities.Text = universities.UniversityName;
        }
    }
}
