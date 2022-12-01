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
    public partial class AllMonographs : XtraForm
    {
        public AllMonographs()
        {
            InitializeComponent();


            GridMonographs.DataSource = Controller.Monograph.GetAllMonographs();
            GridMonographs.RefreshDataSource();
            GridMonographs.Refresh();

            BtnSelect.Click += BtnSelect_Click;
            BtnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtSearch.Text != null || TxtSearch.Text != "")
            {
                TxtSearch.ErrorText = "";
                GridMonographs.DataSource = Controller.Monograph.GetAllMonographs(TxtSearch.Text);
                GridMonographs.RefreshDataSource();
                GridMonographs.Refresh();
            }
            else
            {
                TxtSearch.ErrorText = "د پلټني لپاره کلیدي حروف ولیکئ";
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (ViewMonographs.GetFocusedRowCellValue("Mid") != null)
            {
                MonographsID = (int)ViewMonographs.GetFocusedRowCellValue("Mid");
                this.DialogResult = DialogResult.OK;
            }
        }


        internal int MonographsID { get; private set; }

    }
}