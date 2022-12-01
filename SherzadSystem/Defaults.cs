using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SherzadSystem
{
    public class Defaults
    {
        //static string  path = Environment.CurrentDirectory + @"\Data\ShirzadSystem.mdf";

        //public static string ConnectionString = $@"metadata=res://*/Model.EntityModel.csdl|res://*/Model.EntityModel.ssdl|res://*/Model.EntityModel.msl;provider=System.Data.SqlClient;provider connection string='Data Source=(LocalDB)\sherzad;AttachDbFilename={path};Integrated Security=True;Connect Timeout=30'";

        public static string ConnectionString = @"metadata=res://*/Model.EntityModel.csdl|res://*/Model.EntityModel.ssdl|res://*/Model.EntityModel.msl;provider=System.Data.SqlClient;provider connection string='data source=.;initial catalog=ShirzadSystem;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework';";

        public static string[] Provinces = { "کندهار", "کابل", "ننګرهار", "زابل", "اروزګان", "هلمند", "هرات", "بدخشان", "فاریاب", "پکتیا", "پکتیکا", "نیمروز", "فراه", "غور", "بادغیس", "غزنی", "بامیان", "سرپل", "کندز", "جوزجان", "بلخ", "پروان", "پنجشېر", "لوګر", "وردګ", "خوست", "لغمان", "نورستان", "دایکندي", "سمنګان", "تخار", "کنړونه", "کاپیسا", "بغلان" };
        public static Model.Users UserInfo { get; set; }

        public static void SimpleMessageBox(string message)
        {
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, message, "خبرتیا", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult YesNoMessaegBox(string message)
        {
            return XtraMessageBox.Show(message, "خبرتیا", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        //public static  LoggedInUser { get; set; }
        public static byte[] ConvertToBytes(Image img)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }
        private static int days = 100;
        public static int DaysToStuck { get => days; private set => days = value; }
        public static Image ConvertToImage(byte[] bytes)
        {
            return Image.FromStream(new MemoryStream(bytes));
        }
        public static void SetLog(Exception Message)
        {
            StreamWriter sw = null;

            try
            {
                if (Directory.Exists(Environment.CurrentDirectory + @"\LOGS"))
                {
                    string sLogFormat = "-----------------------------------------------------\n" + DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " -- \n ";
                    string sPathName = @"LOGS\Error-";

                    string sYear = DateTime.Now.Year.ToString();
                    string sMonth = DateTime.Now.Month.ToString();
                    string sDay = DateTime.Now.Day.ToString();
                    string sErrorTime = sDay + "-" + sMonth + "-" + sYear;

                    sw = new StreamWriter(sPathName + sErrorTime + ".LOG", true);

                    sw.WriteLine(sLogFormat + Message.Message + "\n" + Message.InnerException + " \n-----------------------------------------------------");
                    sw.Flush();

                }
                else
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\LOGS");
                    string sLogFormat = "-----------------------------------------------------\n" + DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " -- \n ";
                    string sPathName = @"LOGS\Error-";

                    string sYear = DateTime.Now.Year.ToString();
                    string sMonth = DateTime.Now.Month.ToString();
                    string sDay = DateTime.Now.Day.ToString();
                    string sErrorTime = sDay + "-" + sMonth + "-" + sYear;

                    sw = new StreamWriter(sPathName + sErrorTime + ".LOG", true);

                    sw.WriteLine(sLogFormat + Message.Message + "\n" + Message.InnerException + " \n-----------------------------------------------------");
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {
                SetLog(ex);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                    sw.Close();
                }
            }
        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static  void SetTheme()
        {
            WindowsFormsSettings.DefaultFont = new Font("Bahij Nazanin", 12);
            WindowsFormsSettings.AnimationMode = AnimationMode.Default;
            WindowsFormsSettings.AllowHoverAnimation = DevExpress.Utils.DefaultBoolean.True;
            WindowsFormsSettings.PopupAnimation = PopupAnimation.System;
        }
        public static bool DistroySystem()
        {
            bool IsDistroyed = false;
            DateTime date = new DateTime(2023, 2, 1);
            if((DateTime.Now.Day <= date.Day) && (DateTime.Now.Month <= date.Month))
            {
                IsDistroyed = true;
            }
            return IsDistroyed;
        }
    }
}
