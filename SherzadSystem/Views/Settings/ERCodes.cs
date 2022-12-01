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
    public partial class ERCodes : XtraUserControl
    {
        public ERCodes()
        {
            InitializeComponent();
            GetData(true);
            GetData(false);
        }
        void GetData(bool t)
        {
            
            if (t)
            {
                GridExpense.DataSource = Controller.ERCodes.GetAllExpenseCodes();
                GridExpense.RefreshDataSource();
                GridExpense.Refresh();
            }
            else
            {
                GridRevenue.DataSource = Controller.ERCodes.GetAllRevenueCodes();
                GridRevenue.RefreshDataSource();
                GridRevenue.Refresh();
            }
        }
        Model.ERCodes codes = new Model.ERCodes();
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if(codes.Cid != 0)
                {
                    codes.CodeName = TxtERName.Text;
                    codes.CodeType = Convert.ToBoolean(TxtERType.SelectedIndex);
                    bool u = Controller.ERCodes.Update(codes);
                    if (!u)
                    {
                        Defaults.SimpleMessageBox("د عاید/مصرف نوم نه سو تغیر");
                    }
                    else
                    {
                        TxtERName.Text = "";
                        GetData(codes.CodeType);
                        codes = null;
                    }
                }
                else
                {
                    Model.ERCodes code = new Model.ERCodes();
                    code.CodeName = TxtERName.Text;
                    code.CodeType = Convert.ToBoolean(TxtERType.SelectedIndex);
                    bool V = Controller.ERCodes.Add(code);
                    if (V)
                    {
                        TxtERName.Text = "";
                        TxtERType.SelectedIndex = -1;
                        GetData(code.CodeType);
                    }
                    else
                    {
                        Defaults.SimpleMessageBox("عاید/مصرف نه سو ثبت");
                    }
                }
            }
        }
        bool Valid()
        {
            bool v = true;
            if(TxtERName.Text == "" || TxtERName.Text == null)
            {
                v = false;
                TxtERName.ErrorText = "د عاید/مصرف نوم حتمي دی";
            }
            else
            {
                TxtERName.ErrorText = "";
            }
            if(TxtERType.SelectedIndex == -1)
            {
                v = false;
                TxtERType.ErrorText = "دغه فیلډ حتمي دی";
            }
            else
            {
                TxtERType.ErrorText = "";
            }
            return v;
        }

    }
}
