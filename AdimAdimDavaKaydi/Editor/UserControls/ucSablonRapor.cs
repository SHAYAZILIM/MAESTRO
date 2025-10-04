using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSablonRapor : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSablonRapor()
        {
            InitializeComponent();
        }

        private bool _ButtonsVisible;
        private TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI> _yazdirmaAyarDataSource;
        private List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> SablonRaporDataSource = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
        private List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> updatedSablonList = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();

        public bool ButtonsVisible
        {
            get { return _ButtonsVisible; }
            set
            {
                _ButtonsVisible = value;
                this.simpleButton1.Visible = value;
                this.simpleButton2.Visible = value;
            }
        }

        [Browsable(false)]
        public List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> MyDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (gridSablonRapor.DataSource is List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)
                    return (List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)gridSablonRapor.DataSource;

                return null;
            }
            set
            {
                if (DesignMode)
                {
                    return;
                }
                gridSablonRapor.DataSource = value;
            }
        }

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI> YazdirmaAyarDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                return _yazdirmaAyarDataSource;
            }
            set
            {
                if (DesignMode) return;
                _yazdirmaAyarDataSource = value;

                if (value != null && !DesignMode)
                {
                    this.MyDataSource = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
                    for (int i = 0; i < value.Count; i++)
                    {
                        if (BelgeUtil.Inits._SablonRaporGetir != null)
                            this.MyDataSource.Add(
                                BelgeUtil.Inits._SablonRaporGetir.Find(item => item.ID == value[i].SABLON_ID));
                        else
                            this.MyDataSource.Add(
                                BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Where(item => item.ID == value[i].SABLON_ID).First());
                    }
                }
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!updatedSablonList.Contains((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)e.Row))
            {
                updatedSablonList.Add((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)e.Row);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //SÝl
            DialogResult res = MessageBox.Show("Kayýt silinsin mi?", "Sil", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    (gridSablonRapor.DataSource as List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>).Remove(
                        ((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)gridView1.GetFocusedRow()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //KAYDET
            DialogResult res = MessageBox.Show("Deðiþiklikler kaydeilsin mi?", "Kaydet", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    //DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.Save((gridSablonRapor.DataSource as List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>));
                    foreach (var item in updatedSablonList)
                    {
                        BelgeUtil.Inits.context.AV001_TDIE_BIL_SABLON_RAPOR_Update_New(item.ID, item.AD, item.ACIKLAMA,
                                                                                       item.RAPOR_TIP_ID,
                                                                                       item.ADLI_BIRIM_BOLUM_ID,
                                                                                       item.KATEGORI_ID,
                                                                                       item.DOSYA_ADRES, item.MODUL_ID,
                                                                                       item.FORM_ORNEK_ID,
                                                                                       item.TAKIP_TALEP_KONU_ID,
                                                                                       item.DAVA_TALEP_ID,
                                                                                       item.ADLI_BIRIM_GOREV_ID,
                                                                                       item.SOZLESME_TIP_ID,
                                                                                       item.DAVA_NEDEN_ID, item.DIL_ID,
                                                                                       item.SEKTOR_ID,
                                                                                       item.DEGISKENI_VARMI);
                    }
                    updatedSablonList.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ucSablonRapor_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode)
            {
                return;
            }
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.DilKodGetir(rLuedil);
                BelgeUtil.Inits.DavaAdi(rLueDavaNeden);
                BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTip);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.FormTipiGetir(rLueFormOrnekNo);
                BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolum);
                BelgeUtil.Inits.ModulKodGetir(rLueModul);
                BelgeUtil.Inits.DavaTalepKodGetir(rLueDavaTalep);
                BelgeUtil.Inits.TakipKonusuGetir(rLueTakipTalepKonu);
                BelgeUtil.Inits.SablonAltKategoriGetir(rLueKategori);
                BelgeUtil.Inits.SablonRaporTipGetir(rLueRaporTip);
                BelgeUtil.Inits.SektorKodGetir(rLueSektor);

                gridView1.RowUpdated += gridView1_RowUpdated;
            }
        }
    }
}