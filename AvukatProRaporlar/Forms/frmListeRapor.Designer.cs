//using AdimAdimDavaKaydi.Util;

using AvukatProRaporlar.Lib;
namespace AvukatProRaporlar.Forms
{
    partial class frmListeRapor
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
            this.components = new System.ComponentModel.Container();
            this.gridListeControl = new AvukatProRaporlar.Raport.Util.ExtendedGridControl();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rlkDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridListeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.compGridDovizSummary1 = new AvukatProRaporlar.Raport.Util.compGridDovizSummary(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridListeControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkDurum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListeView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridListeControl
            // 
            this.gridListeControl.CustomButtonlarGorunmesin = false;
            this.gridListeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListeControl.DoNotExtendEmbedNavigator = false;
            this.gridListeControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridListeControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridListeControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridListeControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridListeControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridListeControl.ExternalRepository = this.persistentRepository1;
            this.gridListeControl.FilterText = null;
            this.gridListeControl.FilterValue = null;
            this.gridListeControl.GridsFilterControl = null;
            this.gridListeControl.Location = new System.Drawing.Point(0, 0);
            this.gridListeControl.MainView = this.gridListeView;
            this.gridListeControl.MyGridStyle = null;
            this.gridListeControl.Name = "gridListeControl";
            this.gridListeControl.ShowRowNumbers = false;
            this.gridListeControl.Size = new System.Drawing.Size(816, 326);
            this.gridListeControl.TabIndex = 2;
            this.gridListeControl.TemizleKaldirGorunsunmu = false;
            this.gridListeControl.UniqueId = "2d7c0b7b-caf9-456c-ac1d-364e5a5216a8";
            this.gridListeControl.UseEmbeddedNavigator = true;
            this.gridListeControl.UseHyperDragDrop = false;
            this.gridListeControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridListeView});
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkDurum});
            // 
            // rlkDurum
            // 
            this.rlkDurum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkDurum.DisplayMember = "DURUM";
            this.rlkDurum.Name = "rlkDurum";
            this.rlkDurum.ValueMember = "DURUM";
            // 
            // gridListeView
            // 
            this.gridListeView.GridControl = this.gridListeControl;
            this.gridListeView.IndicatorWidth = 20;
            this.gridListeView.Name = "gridListeView";
            this.gridListeView.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridListeView.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridListeView.OptionsView.ColumnAutoWidth = false;
            this.gridListeView.OptionsView.ShowAutoFilterRow = true;
            this.gridListeView.OptionsView.ShowFooter = true;
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = true;
            this.compGridDovizSummary1.MyGridView = this.gridListeView;
            // 
            // frmListeRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 326);
            this.Controls.Add(this.gridListeControl);
            this.Name = "frmListeRapor";
            this.Text = "frmListeRapor";
            ((System.ComponentModel.ISupportInitialize)(this.gridListeControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkDurum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridListeView;
        private AvukatProRaporlar.Raport.Util.ExtendedGridControl gridListeControl;
        
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkDurum;
        private AvukatProRaporlar.Raport.Util.compGridDovizSummary compGridDovizSummary1;

    }
}