namespace SherzadSystem.Forms
{
    partial class AllMonographs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridMonographs = new DevExpress.XtraGrid.GridControl();
            this.ViewMonographs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemXtraFADateEdit1 = new FarsiLibrary.Win.DevExpress.RepositoryItemXtraFADateEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.TxtSearch = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.GridMonographs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewMonographs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXtraFADateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXtraFADateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSearch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GridMonographs
            // 
            this.GridMonographs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridMonographs.Location = new System.Drawing.Point(12, 41);
            this.GridMonographs.MainView = this.ViewMonographs;
            this.GridMonographs.Name = "GridMonographs";
            this.GridMonographs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemXtraFADateEdit1});
            this.GridMonographs.Size = new System.Drawing.Size(904, 421);
            this.GridMonographs.TabIndex = 5;
            this.GridMonographs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewMonographs});
            // 
            // ViewMonographs
            // 
            this.ViewMonographs.Appearance.HeaderPanel.Font = new System.Drawing.Font("Bahij Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.ViewMonographs.Appearance.HeaderPanel.Options.UseFont = true;
            this.ViewMonographs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.ViewMonographs.GridControl = this.GridMonographs;
            this.ViewMonographs.Name = "ViewMonographs";
            this.ViewMonographs.OptionsBehavior.Editable = false;
            this.ViewMonographs.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "Mid";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "شمېره";
            this.gridColumn2.FieldName = "UniqueId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "عنوان";
            this.gridColumn3.FieldName = "Title";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "کال";
            this.gridColumn4.FieldName = "Year";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ثبت نېټه";
            this.gridColumn5.ColumnEdit = this.repositoryItemXtraFADateEdit1;
            this.gridColumn5.FieldName = "CreationDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // repositoryItemXtraFADateEdit1
            // 
            this.repositoryItemXtraFADateEdit1.AutoHeight = false;
            this.repositoryItemXtraFADateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemXtraFADateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemXtraFADateEdit1.Name = "repositoryItemXtraFADateEdit1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "مبلغ";
            this.gridColumn6.DisplayFormat.FormatString = "0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "totalPrice";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "تخفیف";
            this.gridColumn7.DisplayFormat.FormatString = "0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "totalDiscount";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "رسید";
            this.gridColumn8.DisplayFormat.FormatString = "0";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "totalRecived";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "ملاحظات";
            this.gridColumn9.FieldName = "remarks";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            // 
            // BtnSelect
            // 
            this.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelect.Appearance.Font = new System.Drawing.Font("Bahij Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.BtnSelect.Appearance.Options.UseFont = true;
            this.BtnSelect.ImageOptions.Image = global::SherzadSystem.Properties.Resources.SelectIcon;
            this.BtnSelect.Location = new System.Drawing.Point(786, 468);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(130, 34);
            this.BtnSelect.TabIndex = 6;
            this.BtnSelect.Text = "انتخاب";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearch.Appearance.Font = new System.Drawing.Font("Bahij Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.BtnSearch.Appearance.Options.UseFont = true;
            this.BtnSearch.ImageOptions.Image = global::SherzadSystem.Properties.Resources.SearchIcon;
            this.BtnSearch.Location = new System.Drawing.Point(571, 5);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(105, 30);
            this.BtnSearch.TabIndex = 15;
            this.BtnSearch.Text = "پلټنه";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSearch.Location = new System.Drawing.Point(682, 5);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Properties.Appearance.Font = new System.Drawing.Font("Bahij Nazanin", 11F);
            this.TxtSearch.Properties.Appearance.Options.UseFont = true;
            this.TxtSearch.Size = new System.Drawing.Size(234, 30);
            this.TxtSearch.TabIndex = 16;
            // 
            // AllMonographs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(928, 509);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.GridMonographs);
            this.IconOptions.Image = global::SherzadSystem.Properties.Resources.icons8_google_docs_1;
            this.MinimizeBox = false;
            this.Name = "AllMonographs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ټول مونوګرافونه";
            ((System.ComponentModel.ISupportInitialize)(this.GridMonographs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewMonographs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXtraFADateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXtraFADateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSearch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridMonographs;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewMonographs;
        private DevExpress.XtraEditors.SimpleButton BtnSelect;
        private FarsiLibrary.Win.DevExpress.RepositoryItemXtraFADateEdit repositoryItemXtraFADateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton BtnSearch;
        private DevExpress.XtraEditors.TextEdit TxtSearch;
    }
}