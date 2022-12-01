using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SherzadSystem.Forms
{
    public partial class ReadBook : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ReadBook(string FileName)
        {
            InitializeComponent();
            BookReader.DocumentFilePath = Environment.CurrentDirectory + @"\Assets\Books\" + FileName;
        }
    }
}