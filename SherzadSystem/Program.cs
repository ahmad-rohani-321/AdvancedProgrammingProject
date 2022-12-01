using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Threading;
using System.Globalization;

namespace SherzadSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Defaults.DistroySystem() != true)
            {
                //Thread.CurrentThread.CurrentUICulture = new PersianCultureInfo();
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
                Defaults.SetTheme();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm());
            }
            else
            {
                throw new Exception("The Sherzad System Cannot be Started");
            }
        }
    }
}