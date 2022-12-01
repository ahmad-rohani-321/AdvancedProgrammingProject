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
    public partial class FacultyControl : XtraUserControl
    {
        public FacultyControl()
        {
            InitializeComponent();

            GetData();
        }
        Model.Faculties faculties = new Model.Faculties();
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {

                if(faculties.Fid != 0)
                {
                    faculties.FacultyName = TxtFacultyName.Text;
                    bool u = Controller.Faculty.Update(faculties);
                    if (!u)
                    {
                        Defaults.SimpleMessageBox("د پوهنځی نوم نه سو تغیر");
                    }
                    else
                    {
                        faculties = null; 
                        GetData();
                    }
                }
                else
                {
                    bool AddF = Controller.Faculty.AddFaculty(new Model.Faculties { FacultyName = TxtFacultyName.Text });
                    if (AddF)
                    {
                        GetData();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("پوهنځی نه سوه ثبت");
                    }
                }
            }
        }

        bool Valid()
        {
            bool ret = true;
            if(TxtFacultyName.Text == null || TxtFacultyName.Text == "")
            {
                TxtFacultyName.ErrorText = "د پوهنځی نوم حتمي دی";
                ret = false;
            }
            else
            {
                TxtFacultyName.ErrorText = "";
            }
            return ret;
        }
        void GetData()
        {
            GridFaculties.DataSource = Controller.Faculty.GetAllFculties();
            TxtFacultyName.Text = "";
            GridFaculties.Refresh();
            GridFaculties.RefreshDataSource();
        }
        private void GridFaculties_DoubleClick(object sender, EventArgs e)
        {
            faculties = (Model.Faculties)ViewUsers.GetFocusedRow();
            TxtFacultyName.Text = faculties.FacultyName;
        }
    }
}
