using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
namespace SherzadSystem
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        SplashScreenManager screen;
        public LoginForm()
        {
            screen = new SplashScreenManager(this, typeof(Loader), true, true, true);
            screen.ShowWaitForm();
            InitializeComponent();
            screen.CloseWaitForm();
            NoTime();
        }

        private void NoTime()
        {
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }
        void LogIn()
        {
            screen.ShowWaitForm();
            string UserName = txtUserName.Text;
            string Password = Defaults.CalculateMD5Hash(TxtPassword.Text);
            byte user = Controller.Authentication.GetUser(UserName, Password);

            if (user == 0)
            {
                screen.CloseWaitForm();
                Defaults.SimpleMessageBox("نوموړی یوزر غیر فعال دی");
            }
            else if (user == 2)
            {
                screen.CloseWaitForm();
                Defaults.SimpleMessageBox("نوموړی یوزر پیدا نه سو");
            }
            else if (user == 1)
            {
                screen.CloseWaitForm();
                Hide();
                MainForm main = new MainForm();
                main.ShowDialog();
            }
            else
            {
                screen.CloseWaitForm();
                Defaults.SimpleMessageBox("ډاټابېس ته لاسرسی نه کیږي");
            }
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                TxtPassword.Focus();
                TxtPassword.SelectAll();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn();
            }
        }

        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.SelectAll();
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            TxtPassword.SelectAll();
        }
    }
}