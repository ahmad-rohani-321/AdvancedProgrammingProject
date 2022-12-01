using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using FarsiLibrary.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SherzadSystem
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        #region Codes
        DevExpress.XtraSplashScreen.SplashScreenManager splash;
        public MainForm()
        {
            splash = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Loader), true, true, true);
            splash.ShowWaitForm();
            InitializeComponent();
            splash.CloseWaitForm();
            var people = new Views.People.NewPeople();
            FillDashboard(people);
            Timer t = new Timer();
            t.Start();
            t.Interval = 1000;
            t.Tick += T_Tick;
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Text = "شېرزاد ګروپ | نېټه او وخت: " + PersianDate.Now.ToString("F");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Defaults.YesNoMessaegBox("غواړئ سافټوېر بند کړئ") != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Generated Methods
        private void BtnMonographReport_Click(object sender, EventArgs e)
        {
            var Monographs = new Views.Report.MonographReport();
            FillDashboard(Monographs);
        }
        private void BtnLiteratureReport_Click(object sender, EventArgs e)
        {
            var Literature = new Views.Report.LiteratureReport();
            FillDashboard(Literature);
        }
        private void BtnEmployeeReport_Click(object sender, EventArgs e)
        {
            var Employee = new Views.Report.EmployeeReport();
            FillDashboard(Employee);
        }

        private void BtnJournalReport_Click(object sender, EventArgs e)
        {
            var Journal = new Views.Report.JournalReport();
            FillDashboard(Journal);
        }
        private void BtnPeople_Click(object sender, EventArgs e)
        {
            var people = new Views.People.NewPeople();
            FillDashboard(people);
        }
        private void BtnEmpAccounting_Click(object sender, EventArgs e)
        {
            var journal = new Views.Employee.EmployeeAccounting();
            FillDashboard(journal);
        }
        private void BtnJournal_Click(object sender, EventArgs e)
        {
            int CountEx = Controller.ERCodes.GetAllExpenseCodes().Count();
            int CountRe = Controller.ERCodes.GetAllRevenueCodes().Count();
            if (CountEx > 0 && CountRe > 0)
            {
                var journal = new Views.Accounting.JournalEntryControl();
                FillDashboard(journal);
            }
            else
            {
                Defaults.SimpleMessageBox("د عوایدو او مصارفو کوډونه نه دي ثبت سوي");
            }
        }
        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            var SaveEmployee = new Views.Employee.SaveEmployee();
            FillDashboard(SaveEmployee);
        }
        private void BtnERCodes_Click(object sender, EventArgs e)
        {
            var ExpenceRevenueCodes = new Views.Settings.ERCodes();
            FillDashboard(ExpenceRevenueCodes);
        }

        private void BtnAllWritings_Click(object sender, EventArgs e)
        {
            var DashboardControl = new Views.Literature.OldLiterature();
            FillDashboard(DashboardControl);
        }
        private void BtnNewWriting_Click(object sender, EventArgs e)
        {
            var DashboardControl = new Views.Literature.NewLiteratureControl();
            FillDashboard(DashboardControl);
        }
        private void UsersBtn_Click(object sender, EventArgs e)
        {
            var DashboardControl = new Views.Settings.UsersControl();
            FillDashboard(DashboardControl);
        }
        private void UniversitiesBtn_Click(object sender, EventArgs e)
        {
            var DashboardControl = new Views.Settings.UniversityControl();
            FillDashboard(DashboardControl);
        }
        private void FacultyBtn_Click(object sender, EventArgs e)
        {
            var DashboardControl = new Views.Settings.FacultyControl();
            FillDashboard(DashboardControl);
        }
        private void DepartmentBtn_Click(object sender, EventArgs e)
        {
            var DashboardControl = new Views.Settings.DepartmentControl();
            FillDashboard(DashboardControl);
        }
        private void NewMonographBtn_Click(object sender, EventArgs e)
        {
            int deps = Controller.Departments.CountOfDepartments();
            int Facs = Controller.Faculty.CountOfFaculties();
            int Uns = Controller.Universities.CountOfUniversities();
            if (deps != 0 && Facs != 0 && Uns != 0)
            {
                var DashboardControl = new Views.Monographs.NewMonographControl();
                FillDashboard(DashboardControl);
            }
            else
            {
                Defaults.SimpleMessageBox("پوهنتون، پوهنځی او یا هم څانګي نه دي ثبت سوي");
            }
        }
        private void BtnOldMonographs_Click(object sender, EventArgs e)
        {
            var OldMonographs = new Views.Monographs.OldMonographs();
            FillDashboard(OldMonographs);
        }

        private void BtnBooks_Click(object sender, EventArgs e)
        {
            int cont = ((List<Model.BookCategories>)Controller.Books.GetBookCategories()).Count();
            if (cont <= 0)
            {
                Defaults.SimpleMessageBox("د کتابونو کټیګورئ مو نه دي ثبت کړي");
            } else
            {
                var books = new Views.Books.Books();
                FillDashboard(books);
            }
        }
        private void BtnBookCategories_Click(object sender, EventArgs e)
        {
            var cats = new Views.Books.BookCategories();
            FillDashboard(cats);
        }
        #endregion

        #region Methods
        private void FillDashboard(XtraUserControl Control)
        {
            splash.ShowWaitForm();
            Control.Dock = DockStyle.Fill;
            Control.Visible = true;
            this.MainContainer.Controls.Clear();
            this.MainContainer.Controls.Add(Control);
            splash.CloseWaitForm();
        }

        #endregion

    }
}