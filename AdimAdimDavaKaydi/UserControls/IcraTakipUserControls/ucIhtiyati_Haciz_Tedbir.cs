using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucIhtiyati_Haciz_Tedbir : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        private object dt;

        private TList<AV001_TI_BIL_IHTIYATI_HACIZ> ihtiyatiHaciz = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();

        private TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> ihtiyatiTedbir = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();

        public ucIhtiyati_Haciz_Tedbir()
        {
            InitializeComponent();
            this.Load += ucIhtiyati_Haciz_Tedbir_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_IHTIYATI_HACIZ> DsHaciz
        {
            get
            {
                if (gcHaciz.DataSource is TList<AV001_TI_BIL_IHTIYATI_HACIZ>)
                    return (TList<AV001_TI_BIL_IHTIYATI_HACIZ>)gcHaciz.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    gcHaciz.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> DsTedbir
        {
            get
            {
                if (gcTedbir.DataSource is TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>)
                    return (TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>)gcTedbir.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                    gcTedbir.DataSource = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyDataSource { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }
        
        private void Binding(object DataSource)
        {
            lueAdliBirimAdliye.DataBindings.Clear();
            lueAdliBirimAdliye.DataBindings.Add("EditValue", DataSource, "ADLI_BIRIM_ADLIYE_ID", true);

            lueGorev.DataBindings.Clear();
            lueGorev.DataBindings.Add("EditValue", DataSource, "ADLI_BIRIM_GOREV_ID", true);

            txtEsasNo.DataBindings.Clear();
            txtEsasNo.DataBindings.Add("TEXT", DataSource, "ESAS_NO", true);

            lueBirimNo.DataBindings.Clear();
            lueBirimNo.DataBindings.Add("EditValue", DataSource, "BIRIM_NO", true);

            txtKararNo.DataBindings.Clear();
            txtKararNo.DataBindings.Add("TEXT", DataSource, "KARAR_NO", true);

            lueTeminatTuru.DataBindings.Clear();
            if (dt is AV001_TDI_BIL_IHTIYATI_TEDBIR)
                lueTeminatTuru.DataBindings.Add("EditValue", DataSource, "TEMINAT_TUR_ID", true);

            if (dt is AV001_TI_BIL_IHTIYATI_HACIZ)
                lueTeminatTuru.DataBindings.Add("EditValue", DataSource, "TEMINAT_TURU_ID", true);

            dtTalepT.DataBindings.Clear();
            dtTalepT.DataBindings.Add("EditValue", DataSource, "TALEP_TARIHI", true);

            dtKararT.DataBindings.Clear();
            dtKararT.DataBindings.Add("EditValue", DataSource, "KARAR_TARIHI", true);

            dtCevirmeT.DataBindings.Clear();

            if (dt is AV001_TDI_BIL_IHTIYATI_TEDBIR)
                dtCevirmeT.DataBindings.Add("EditValue", DataSource, "K_D_CEVIRME_TARIHI", true);

            if (dt is AV001_TI_BIL_IHTIYATI_HACIZ)
                dtCevirmeT.DataBindings.Add("EditValue", DataSource, "K_H_CEVIRME_TARIHI", true);

            Tutar.DataBindings.Clear();
            Tutar.DataBindings.Add("EditValue", DataSource, "TEMINAT_TUTARI", true);

            lueDoviz.DataBindings.Clear();
            lueDoviz.DataBindings.Add("EditValue", DataSource, "TEMINAT_TUTARI_DOVIZ_ID", true);

            txtAciklama.DataBindings.Clear();
            txtAciklama.DataBindings.Add("TEXT", DataSource, "ACIKLAMA", true);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count > 0)
            {
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ADLI_BIRIM_ADLIYE_ID = 0;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].BIRIM_NO = string.Empty;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ESAS_NO = string.Empty;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].KARAR_NO = string.Empty;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].TEMINAT_TURU_ID = null;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].TALEP_TARIHI = null;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].KARAR_TARIHI = null;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].K_H_CEVIRME_TARIHI = null;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].TEMINAT_TUTARI = 0;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].TEMINAT_TUTARI_DOVIZ_ID = null;
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ACIKLAMA = string.Empty;
            }

            if (MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.Count > 0)
            {
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].ADLI_BIRIM_ADLIYE_ID = 0;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].BIRIM_NO = string.Empty;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].ESAS_NO = string.Empty;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].KARAR_NO = string.Empty;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].TEMINAT_TUR_ID = null;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].KARAR_TARIHI = null;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].K_D_CEVIRME_TARIHI = null;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].TEMINAT_TUTARI = 0;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].TEMINAT_TUTARI_DOVIZ_ID = null;
                MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection[0].ACIKLAMA = string.Empty;
            }
        }

        private void DataSourceHazirla()
        {
            if (radioGroup4.SelectedIndex == 0)
            {
                dt = new AV001_TI_BIL_IHTIYATI_HACIZ();

                DsHaciz = MyDataSource.AV001_TI_BIL_IHTIYATI_HACIZCollection;

                if (DsHaciz.Count == 0)
                    MyDataSource.AV001_TI_BIL_IHTIYATI_HACIZCollection.AddNew();

                gcHaciz.Visible = true;
                gcTedbir.Visible = false;
                gcHaciz.Dock = DockStyle.Fill;

                Binding(DsHaciz);
            }
            else if (radioGroup4.SelectedIndex == 1)
            {
                dt = new AV001_TDI_BIL_IHTIYATI_TEDBIR();

                DsTedbir = MyDataSource.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;

                if (DsTedbir.Count == 0)
                    MyDataSource.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.AddNew();

                gcTedbir.Visible = true;
                gcHaciz.Visible = false;
                gcTedbir.Dock = DockStyle.Fill;

                Binding(DsTedbir);
            }
        }

        private void LoadData()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(lueGorev);
            BelgeUtil.Inits.TeminatTuruGetir(lueTeminatTuru.Properties);
            BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTur);
            BelgeUtil.Inits.DovizTipGetir(lueDoviz);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimID);
            BelgeUtil.Inits.AdliBirimNoGetir(lueBirimNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
            BelgeUtil.Inits.ParaBicimiAyarla(rTutar);
        }

        private void radioGroup4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSourceHazirla();
        }

        private void ucIhtiyati_Haciz_Tedbir_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            LoadData();

            radioGroup4.SelectedIndex = 0;
        }

        #region Events

        //void lueDoviz_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        DsHaciz[0].TEMINAT_TUTARI_DOVIZ_ID = (int)e.NewValue;

        //        if (DsTedbir != null)
        //            DsTedbir[0].TEMINAT_TUTARI_DOVIZ_ID = (int)e.NewValue;
        //    }
        //}

        ////void txtNo_TextChanged(object sender, EventArgs e)
        ////{
        ////    if (txtNo.Text != "")
        ////    {
        ////        DsHaciz[0].BIRIM_NO = txtNo.Text;

        ////        if (DsTedbir != null)
        ////            DsTedbir[0].BIRIM_NO = txtNo.Text;
        ////    }
        ////    else
        ////        DsHaciz[0].BIRIM_NO = "";

        ////}

        //void txtKararNo_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtKararNo.Text != "")
        //    {
        //        DsHaciz[0].KARAR_NO = txtKararNo.Text;

        //        if (DsTedbir != null)
        //            DsTedbir[0].KARAR_NO = txtKararNo.Text;
        //    }
        //    else
        //        DsHaciz[0].KARAR_NO = string.Empty;
        //}

        //void txtEsasNo_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtEsasNo.Text != "")
        //    {
        //        DsHaciz[0].ESAS_NO = txtEsasNo.Text;

        //        if (DsTedbir != null)
        //            DsTedbir[0].ESAS_NO = txtEsasNo.Text;
        //    }
        //    else
        //        DsHaciz[0].ESAS_NO = string.Empty;
        //}

        //void Tutar_TextChanged(object sender, EventArgs e)
        //{
        //    if (Tutar.Value != null)
        //    {
        //        DsHaciz[0].TEMINAT_TUTARI = Tutar.Value;

        //        if (DsTedbir != null)
        //            DsTedbir[0].TEMINAT_TUTARI = Tutar.Value;
        //    }
        //}

        //void txtAciklama_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtAciklama.Text != "")
        //    {
        //        DsHaciz[0].ACIKLAMA = txtAciklama.Text;

        //        if (DsTedbir != null)
        //            DsTedbir[0].ACIKLAMA = txtAciklama.Text;
        //    }
        //}

        //void dtKararT_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        DsHaciz[0].KARAR_TARIHI = dtKararT.DateTime;

        //        if (DsTedbir != null)
        //            DsTedbir[0].KARAR_TARIHI = dtKararT.DateTime;
        //    }
        //}

        //void dtCevirmeT_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        DsHaciz[0].K_H_CEVIRME_TARIHI = dtCevirmeT.DateTime;

        //        if (DsTedbir != null)
        //            DsTedbir[0].K_D_CEVIRME_TARIHI = dtCevirmeT.DateTime;
        //    }
        //}

        //void dtTalepT_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        DsHaciz[0].TALEP_TARIHI = dtTalepT.DateTime;

        //        if (DsTedbir != null)
        //            DsTedbir[0].TALEP_TARIHI = dtTalepT.DateTime;
        //    }
        //}

        //void lueTeminatTuru_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        DsHaciz[0].TEMINAT_TURU_ID = (int)e.NewValue;

        //        if (DsTedbir != null)
        //            DsTedbir[0].TEMINAT_TUR_ID = (int)e.NewValue;
        //    }
        //}

        //void lueGorev_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        DsHaciz[0].ADLI_BIRIM_GOREV_ID = (int)e.NewValue;

        //        if (DsTedbir != null)
        //            DsTedbir[0].ADLI_BIRIM_GOREV_ID = (int)e.NewValue;
        //    }
        //}

        //void lueAdliBirimAdliye_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        //{
        //    if (e.NewValue != null)
        //    {
        //        DsHaciz[0].ADLI_BIRIM_ADLIYE_ID = (int)e.NewValue;

        //        if (DsTedbir != null)
        //            DsTedbir[0].ADLI_BIRIM_ADLIYE_ID = (int)e.NewValue;
        //    }
        //}

        #endregion Events
    }
}