namespace SherzadSystem.Forms
{
    partial class AllPersons
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
            this.GridPeople = new DevExpress.XtraGrid.GridControl();
            this.ViewPeople = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemXtraFADateEdit1 = new FarsiLibrary.Win.DevExpress.RepositoryItemXtraFADateEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProvinceEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.BtnSelect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXtraFADateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXtraFADateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvinceEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // GridPeople
            // 
            this.GridPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPeople.Location = new System.Drawing.Point(12, 12);
            this.GridPeople.MainView = this.ViewPeople;
            this.GridPeople.Name = "GridPeople";
            this.GridPeople.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemXtraFADateEdit1,
            this.ProvinceEdit});
            this.GridPeople.Size = new System.Drawing.Size(904, 450);
            this.GridPeople.TabIndex = 5;
            this.GridPeople.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewPeople});
            // 
            // ViewPeople
            // 
            this.ViewPeople.Appearance.HeaderPanel.Font = new System.Drawing.Font("Bahij Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.ViewPeople.Appearance.HeaderPanel.Options.UseFont = true;
            this.ViewPeople.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8});
            this.ViewPeople.GridControl = this.GridPeople;
            this.ViewPeople.Name = "ViewPeople";
            this.ViewPeople.OptionsBehavior.Editable = false;
            this.ViewPeople.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "شمېره";
            this.gridColumn1.FieldName = "PIid";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 62;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "نوم";
            this.gridColumn2.FieldName = "FirstName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "تخلص";
            this.gridColumn3.FieldName = "LastName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "د پلار نوم";
            this.gridColumn4.FieldName = "FatherName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "موبایل شمېره";
            this.gridColumn5.FieldName = "Phone";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "د ثبت نېټه";
            this.gridColumn6.ColumnEdit = this.repositoryItemXtraFADateEdit1;
            this.gridColumn6.FieldName = "CreationDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
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
            // gridColumn8
            // 
            this.gridColumn8.Caption = "ولایت";
            this.gridColumn8.ColumnEdit = this.ProvinceEdit;
            this.gridColumn8.FieldName = "Province";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // ProvinceEdit
            // 
            this.ProvinceEdit.AutoHeight = false;
            this.ProvinceEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ProvinceEdit.Name = "ProvinceEdit";
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
            // AllPersons
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(928, 509);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.GridPeople);
            this.IconOptions.Image = global::SherzadSystem.Properties.Resources.icons8_google_docs_1;
            this.MinimizeBox = false;
            this.Name = "AllPersons";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ټول اشخاص";
            ((System.ComponentModel.ISupportInitialize)(this.GridPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXtraFADateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemXtraFADateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvinceEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridPeople;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewPeople;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton BtnSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private FarsiLibrary.Win.DevExpress.RepositoryItemXtraFADateEdit repositoryItemXtraFADateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ProvinceEdit;
    }
}