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
    public partial class NewMonographControl : XtraUserControl
    {
        Model.PersonInformation Person { get; set; }
        
        public NewMonographControl()
        {
            InitializeComponent();
            this.SaveMonograph.CustomizeCommandButtons += SaveMonograph_CustomizeCommandButtons;
            Picture.Image = SherzadSystem.Properties.Resources.PicIcon;
            this.TxtProvince.Properties.Items.AddRange(Defaults.Provinces);

            // load All Universities
            TxtUniversity.Properties.DataSource = Controller.Universities.GetUniversities();
            TxtUniversity.Properties.DisplayMember = "UniversityName";
            TxtUniversity.Properties.ValueMember = "Uid";
            TxtUniversity.EditValue = TxtUniversity.Properties.GetKeyValue(0);

            // Load All Departments 
            TxtDepartment.Properties.DataSource = Controller.Departments.GetAllDepartment();
            TxtDepartment.Properties.DisplayMember = "DepartmentName";
            TxtDepartment.Properties.ValueMember = "Did";
            TxtDepartment.EditValue = TxtDepartment.Properties.GetKeyValue(0);

            // Load All Faculties
            TxtFaculty.Properties.DataSource = Controller.Faculty.GetAllFculties();
            TxtFaculty.Properties.DisplayMember = "FacultyName";
            TxtFaculty.Properties.ValueMember = "Fid";
            TxtFaculty.EditValue = TxtFaculty.Properties.GetKeyValue(0);

            TxtSerialNo.EditValue = Controller.Monograph.GetLastUniqueId().ToString();

            SaveStudent.AllowNext = false;
        }


        private void SaveMonograph_CustomizeCommandButtons(object sender, DevExpress.XtraWizard.CustomizeCommandButtonsEventArgs e)
        {
            e.CancelButton.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidMan())
            {
                Model.PersonInformation personInformation = new Model.PersonInformation();
                personInformation.FirstName = txtFirstName.Text;
                personInformation.LastName = TxtLastName.Text;
                personInformation.FatherName = TxtFatherName.Text;
                personInformation.Phone = TxtPhone.Text;
                personInformation.Photo = Defaults.ConvertToBytes(Picture.Image);
                personInformation.CreationDate = DateTime.Now;
                personInformation.Province = TxtProvince.SelectedText;

                Person = Controller.Person.AddPerson(personInformation);

                TxtPersonFullName.Text = Person.FirstName + " " + Person.LastName;
                TxtPersonFatherName.Text = Person.FatherName;

                if (Person.PIid != 0)
                {
                    DisablePerson();
                    SaveStudent.AllowNext = true;
                }
                else
                {
                    Defaults.SimpleMessageBox("شخص نه سو ثبت");
                }
            }
        }

        void DisablePerson()
        {
            AddOld.Enabled = false;

            txtFirstName.Enabled = false;
            TxtLastName.Enabled = false;
            TxtFatherName.Enabled = false;
            TxtPhone.Enabled = false;
            Picture.Enabled = false;
            TxtProvince.Enabled = false;
            BtnSave.Enabled = false;
        }

        bool ValidMan()
        {
            bool ret = true;
            if(txtFirstName.Text == "" || txtFirstName.Text == null)
            {
                txtFirstName.ErrorText = "نوم حتمي دی";
                ret = false;
            }
            else
            {
                txtFirstName.ErrorText = "";
            }

            if (TxtLastName.Text == "" || TxtLastName.Text == null)
            {
                TxtLastName.ErrorText = "تخلص حتمي دی";
                ret = false;
            }
            else
            {
                TxtLastName.ErrorText = "";
            }

            if (TxtFatherName.Text == "" || TxtFatherName.Text == null)
            {
                TxtFatherName.ErrorText = "د پلارنوم حتمي دی";
                ret = false;
            }
            else
            {
                TxtFatherName.ErrorText = "";
            }

            if (TxtPhone.Text == "" || TxtPhone.Text == null)
            {
                TxtPhone.ErrorText = "د موبایل شمېره حتمي دی";
                ret = false;
            }
            else
            {
                TxtPhone.ErrorText = "";
            }

            if (TxtProvince.Text == "" || TxtProvince.Text == null)
            {
                TxtProvince.ErrorText = "د ولایت نوم حتمي دی";
                ret = false;
            }
            else
            {
                TxtProvince.ErrorText = "";
            }
            return ret;
        }
        bool ValidMon()
        {
            bool ret = true;
            if(TxtSerialNo.Text == null || TxtSerialNo.Text == "")
            {
                TxtSerialNo.ErrorText = "مسلسل شمېره حتمي ده";
                ret = false;
            }
            else
            {
                TxtSerialNo.ErrorText = "";
            }

            if (TxtYear.Text == null || TxtYear.Text == "")
            {
                TxtYear.ErrorText = "عنوان حتمي دی";
                ret = false;
            }
            else
            {
                TxtYear.ErrorText = "";
            }

            if (TxtFaculty.Text == null)
            {
                TxtFaculty.ErrorText = "پوهنځی انتخاب کړئ";
                ret = false;
            }
            else
            {
                TxtFaculty.ErrorText = "";
            }

            if (TxtUniversity.Text == null )
            {
                TxtUniversity.ErrorText = "پوهنتون انتخاب کړئ";
                ret = false;
            }
            else
            {
                TxtUniversity.ErrorText = "";
            }

            if (TxtDepartment.Text == null )
            {
                TxtDepartment.ErrorText = "ځانګه انتخاب کړئ";
                ret = false;
            }
            else
            {
                TxtDepartment.ErrorText = "";
            }

            if (TxtAmount.Text == null || TxtAmount.Text == "")
            {
                TxtAmount.ErrorText = "مبلغ ولیکئ";
                ret = false;

            }
            else
            {
                TxtAmount.ErrorText = "";
            }

            return ret;

        }

        private void BtnSaveMonograph_Click(object sender, EventArgs e)
        {
            if (ValidMon())
            {
                Model.Monograph monograph = new Model.Monograph();
                monograph.CreationDate = DateTime.Now;
                monograph.Year = Convert.ToInt32(TxtYear.EditValue);
                monograph.DepartmentId = Convert.ToInt32(TxtDepartment.EditValue);
                monograph.UniversityId = Convert.ToInt32(TxtUniversity.EditValue);
                monograph.FacultyId = Convert.ToInt32(TxtFaculty.EditValue);
                monograph.UniqueId = Convert.ToInt32(TxtSerialNo.EditValue);
                monograph.Title = TxtTitle.Text;
                monograph.PersonId = Person.PIid;
                monograph.remarks = TxtRemarks.Text;
                monograph.totalPrice = Convert.ToDecimal(TxtAmount.EditValue);
                monograph.totalRecived = 0;
                monograph.totalDiscount = 0;

                bool Add = Controller.Monograph.AddMonograph(monograph);
                if (Add)
                {
                    ClearFormSaveMonograph();
                    Defaults.SimpleMessageBox("عملیه په بریا سره اجرا سوه");
                }
                else
                {
                    Defaults.SimpleMessageBox("عملیه تکمیل نه سوه");
                }
            }
        }

        private void ClearFormSaveMonograph()
        {
            TxtRemarks.Text = "";
            TxtPersonFatherName.Text = "";
            TxtPersonFullName.Text = "";
            TxtYear.Text = "";
            TxtAmount.EditValue = 0;
            TxtYear.Text = "0";
            TxtSerialNo.EditValue = Controller.Monograph.GetLastUniqueId();
        }

        private void AddOld_Click(object sender, EventArgs e)
        {
            Forms.AllPersons all = new Forms.AllPersons();
            all.ShowDialog();
            if(all.DialogResult == DialogResult.OK)
            {
                Person = Controller.Person.GetPerson(all.PersonId);
                txtFirstName.Text = Person.FirstName;
                TxtLastName.Text = Person.LastName;
                TxtPhone.Text = Person.Phone;
                TxtFatherName.Text = Person.FatherName;
                TxtProvince.SelectedText = Person.Province;
                Picture.Image = Defaults.ConvertToImage(Person.Photo);

                TxtPersonFullName.Text = Person.FirstName + " " + Person.LastName;
                TxtPersonFatherName.Text = Person.FatherName;
                DisablePerson();
                SaveStudent.AllowNext = true;
            }
            all.Dispose();
        }

        private void OldMonographs_Click(object sender, EventArgs e)
        {
            Forms.AllMonographs all = new Forms.AllMonographs();
            all.ShowDialog();
            if (all.DialogResult == DialogResult.OK)
            {
                var get = Controller.Monograph.GetMonograph(all.MonographsID);
                if (get != null)
                {
                    TxtTitle.Text = get.Title;
                    TxtAmount.Text = get.totalPrice.ToString();
                }
            }
            all.Dispose();
        }
    }
}
