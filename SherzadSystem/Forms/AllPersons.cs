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
    public partial class AllPersons : XtraForm
    {
        public AllPersons()
        {
            InitializeComponent();
            this.ProvinceEdit.Items.AddRange(Defaults.Provinces);
            GridPeople.DataSource = Controller.Person.GetAllPeople();
            GridPeople.RefreshDataSource();
            GridPeople.Refresh();

            BtnSelect.Click += BtnSelect_Click;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (ViewPeople.GetFocusedRowCellValue("PIid") != null)
            {
                PersonId = (int)ViewPeople.GetFocusedRowCellValue("PIid");
                this.DialogResult = DialogResult.OK;
            }
        }


        internal int PersonId { get; private set; }
    }
}