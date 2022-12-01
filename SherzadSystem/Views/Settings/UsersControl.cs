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
    public partial class UsersControl : XtraUserControl
    {
        public UsersControl()
        {
            InitializeComponent();
            GetData();
        }
        Model.Users user = new Model.Users();
        #region By Hand Code
        void GetData()
        {
            GridUsers.DataSource = Controller.Authentication.GetAllUsers();
            GridUsers.RefreshDataSource();
            GridUsers.Refresh();
        }
        void ClearForm()
        {
            TxtUserFirstName.Text = "";
            TxtUserName.Text = "";
            TxtPassword.Text = "";
            BtnOnOff.IsOn = true;
        }
        bool Valid()
        {
            bool Valid = true;
            // username
            if(TxtUserFirstName.Text == "" || TxtUserFirstName.Text == null)
            {
                TxtUserFirstName.ErrorText = "دغه فیلډ حتمي دی";
                Valid = false;
            }
            else
            {
                TxtUserFirstName.ErrorText = "";
            }

            if (TxtUserName.Text == "" || TxtUserName.Text == null)
            {
                TxtUserName.ErrorText = "دغه فیلډ حتمي دی";
                Valid = false;
            }
            else
            {
                TxtUserName.ErrorText = "";
            }

            if (TxtPassword.Text == "" || TxtPassword.Text == null)
            {
                TxtPassword.ErrorText = "دغه فیلډ حتمي دی";
                Valid = false;
            }
            else
            {
                TxtPassword.ErrorText = "";
            }
            return Valid;
        }
        #endregion
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if (user.Uid != 0)
                {
                    user.Name = TxtUserFirstName.Text;
                    user.UserName = TxtUserName.Text;
                    user.Password = Defaults.CalculateMD5Hash(TxtPassword.Text);
                    user.IsDeleted = BtnOnOff.IsOn == true ? false : true;

                    bool updated = Controller.Authentication.IsUpdated(user);
                    if (!updated)
                    {
                        Defaults.SimpleMessageBox("د یوزر معلومات نه سوه ثبت");
                    }
                    else
                    {
                        ClearForm();
                        user = null;
                        GetData();
                    }
                }
                else
                {
                    Model.Users users = new Model.Users();
                    users.Name = TxtUserFirstName.Text;
                    users.UserName = TxtUserName.Text;
                    users.Password = Defaults.CalculateMD5Hash(TxtPassword.Text);
                    users.IsDeleted = BtnOnOff.IsOn;
                    bool isAdded = Controller.Authentication.isAdded(users);
                    if (isAdded)
                    {
                        ClearForm();
                        GetData();
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("یوزر نه سو اضافه");
                    }
                }
            }
        }


        private void GridUsers_DoubleClick(object sender, EventArgs e)
        {
            user = (Model.Users)ViewUsers.GetFocusedRow();
            TxtUserFirstName.Text = user.Name;
            TxtUserName.Text = user.UserName;
            BtnOnOff.IsOn = user.IsDeleted;
        }
    }
}
