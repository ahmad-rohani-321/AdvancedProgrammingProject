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

namespace SherzadSystem.Views.People
{
    public partial class NewPeople : XtraUserControl
    {
        public NewPeople()
        {
            InitializeComponent();
            TxtProvinnce.Properties.Items.AddRange(Defaults.Provinces);
            ImagePicker.Image = SherzadSystem.Properties.Resources.PicIcon;
            GetData();
        }
        void GetData()
        {
            GridPeople.DataSource = Controller.Person.GetAllPeople();
            GridPeople.RefreshDataSource();
            GridPeople.Refresh();
        }
        Model.PersonInformation person { get; set; }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if (person != null)
                {
                    person.FirstName = TxtFirstName.Text;
                    person.LastName = TxtLastName.Text;
                    person.FatherName = TxtFatherName.Text;
                    person.Phone = TxtPhone.Text;
                    person.Province = TxtProvinnce.SelectedText;
                    person.Photo = Defaults.ConvertToBytes(ImagePicker.Image);

                    bool u = Controller.Person.Update(person);
                    if (!u)
                    {
                        Defaults.SimpleMessageBox("د محصل معلومات نه سو تغیر");
                    }
                    else
                    {
                        ClearForm();
                        person = null;
                        GetData();
                    }
                }
                else
                {
                    Model.PersonInformation p = new Model.PersonInformation();
                    p.FirstName = TxtFirstName.Text;
                    p.LastName = TxtLastName.Text;
                    p.Phone = TxtPhone.Text;
                    p.FatherName = TxtFatherName.Text;
                    p.CreationDate = DateTime.Now;
                    p.Province = TxtProvinnce.SelectedText;
                    p.Photo = Defaults.ConvertToBytes(ImagePicker.Image);

                    var V = Controller.Person.AddPerson(p);
                    if (V != null)
                    {
                        ClearForm();
                        GetData();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("محصل نه سو ثبت");
                    }
                }
            }
        }
        void ClearForm()
        {
            TxtFirstName.Text = "";
            TxtLastName.Text = "";
            TxtProvinnce.Text = "";
            TxtFatherName.Text = "";
            TxtPhone.Text = "";
            ImagePicker.Image = Properties.Resources.PicIcon;
        }
        bool Valid()
        {
            bool v = true;
            if (TxtFirstName.Text == "" || TxtFirstName.Text == null)
            {
                v = false;
                TxtFirstName.ErrorText = "انتخاب سوی فیلډ حتمي دی";
            }
            else
            {
                TxtFirstName.ErrorText = "";
            }

            if (TxtLastName.Text == "" || TxtLastName.Text == null)
            {
                v = false;
                TxtLastName.ErrorText = "انتخاب سوی فیلډ حتمي دی";
            }
            else
            {
                TxtLastName.ErrorText = "";
            }

            if (TxtPhone.Text == "" || TxtPhone.Text == null)
            {
                v = false;
                TxtPhone.ErrorText = "انتخاب سوی فیلډ حتمي دی";
            }
            else
            {
                TxtPhone.ErrorText = "";
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
            return v;
        }

        private void GridDepartments_DoubleClick(object sender, EventArgs e)
        {
            person = (Model.PersonInformation)ViewPeople.GetRow(ViewPeople.FocusedRowHandle);
            TxtFirstName.Text = person.FirstName;
            TxtLastName.Text = person.LastName;
            TxtFatherName.Text = person.FatherName;
            TxtPhone.Text = person.Phone;
            TxtProvinnce.SelectedText = person.Province;
            ImagePicker.Image = Defaults.ConvertToImage(person.Photo);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string SearchString = TxtSearch.Text;
            GridPeople.DataSource = Controller.Person.GetAllPeople(SearchString);
            GridPeople.Refresh();
        }
    }
}
