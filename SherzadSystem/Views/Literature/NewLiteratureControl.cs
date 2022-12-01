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
    public partial class NewLiteratureControl : XtraUserControl
    {
        Model.PersonInformation Person { get; set; }
        
        public NewLiteratureControl()
        {
            InitializeComponent();
            this.SaveMonograph.CustomizeCommandButtons += SaveMonograph_CustomizeCommandButtons;
            Picture.Image = SherzadSystem.Properties.Resources.PicIcon;
            this.TxtProvince.Properties.Items.AddRange(Defaults.Provinces);


            TxtSerialNo.EditValue = Controller.Literature.GetLastUniqueId().ToString();

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

            if (TxtTitle.Text == null || TxtTitle.Text == "")
            {
                TxtTitle.ErrorText = "عنوان ولیکئ";
                ret = false;
            }
            else
            {
                TxtTitle.ErrorText = "";
            }

            if (TxtAmount.Text == null || TxtAmount.Text == "" || TxtAmount.Text == "0")
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
                Model.Literature l = new Model.Literature();
                l.CreationDate = DateTime.Now;
                l.UniqueId = Convert.ToInt32(TxtSerialNo.EditValue);
                l.LiteratureName = TxtTitle.Text;
                l.Person = Person.PIid;
                l.remarks = TxtRemarks.Text;
                l.TotalAmount = Convert.ToDecimal(TxtAmount.EditValue);
                l.TotalRecived = 0;
                l.TotalDiscount = 0;

                bool Add = Controller.Literature.Add(l);
                if (Add)
                {
                    ClearFormSaveLiterature();
                    Defaults.SimpleMessageBox("عملیه په بریا سره اجرا سوه");
                }
                else
                {
                    Defaults.SimpleMessageBox("عملیه تکمیل نه سوه");
                }
            }
        }

        private void ClearFormSaveLiterature()
        {
            TxtRemarks.Text = "";
            TxtPersonFatherName.Text = "";
            TxtPersonFullName.Text = "";
            TxtTitle.Text = "";
            TxtAmount.EditValue = 0;
            TxtSerialNo.EditValue = Controller.Literature.GetLastUniqueId();
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

    }
}
