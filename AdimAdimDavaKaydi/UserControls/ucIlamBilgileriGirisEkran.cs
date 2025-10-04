using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIlamBilgileriGirisEkran : DevExpress.XtraEditors.XtraUserControl
    {
        public ucIlamBilgileriGirisEkran()
        {
            InitializeComponent();
        }

        public List<AvukatProLib.Arama.per_TI_BIL_ILAM_MAHKEMESI> MyDataSource
        {
            get
            {
                if (exGridIlamBilgileri.DataSource is List<AvukatProLib.Arama.per_TI_BIL_ILAM_MAHKEMESI>)
                    return (List<AvukatProLib.Arama.per_TI_BIL_ILAM_MAHKEMESI>)exGridIlamBilgileri.DataSource;
                return null;
            }
            set
            {
                if (value == null)
                {
                    if (exGridIlamBilgileri != null)
                    {
                        exGridIlamBilgileri.DataSource = value;
                        //extendedGridControl1.DataSource = value;
                    }
                }
                exGridIlamBilgileri.DataSource = value;
                //extendedGridControl1.DataSource = value;
            }
        }

        private void ucIlamBilgileriGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;
            /*
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.IlamTipiGetir(rLueIlamTipi);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.FaizTipiGetir(rLueFaizTip);
            BelgeUtil.Inits.CaridenFirmaGetir(rLueKurumID);
            BelgeUtil.Inits.IcraErtelenmeNedenGetir(rLueIcraErtelemeNeden);
            BelgeUtil.Inits.perCariGetir(rLueMehilIsteyenCari);
//rLueKararSonuc

            //
            BelgeUtil.Inits.AdliBirimAdliyeGetir(repositoryItemLookUpEdit1);
            BelgeUtil.Inits.AdliBirimGorevGetir(repositoryItemLookUpEdit2);
            BelgeUtil.Inits.AdliBirimNoGetir(repositoryItemLookUpEdit3);
            BelgeUtil.Inits.IlamTipiGetir(repositoryItemLookUpEdit4);
            BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit5);
            BelgeUtil.Inits.FaizTipiGetir(repositoryItemLookUpEdit6);

            //ada.AV001_TI_BIL_ALACAK_NEDENCollection
            //ada.AV001_TI_BIL_FAIZCollection
            //ada.AV001_TI_BIL_MEHILCollection
            //ada.AV001_TI_BIL_ODEME_DAGILIMCollection
            */
            exGridIlamBilgileri.ButtonCevirClick += exGridIlamBilgileri_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridIlamBilgileri_ButtonCevirClick;
        }

        private void exGridIlamBilgileri_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridIlamBilgileri.Visible)
            {
                exGridIlamBilgileri.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                exGridIlamBilgileri.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void exGridIlamBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                frmIcraIlamMahkemesiGiris IlamBilgisi = new frmIcraIlamMahkemesiGiris();
                //IlamBilgisi.MdiParent = null;
                IlamBilgisi.StartPosition = FormStartPosition.WindowsDefaultLocation;
                IlamBilgisi.MyDataSource = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();
                IlamBilgisi.IsModul = true;
                IlamBilgisi.Show();
            }
        }

        private void exGridIlamBilgileri_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                int? icraFoyId = (gridView1.GetFocusedRow() as AvukatProLib.Arama.per_TI_BIL_ILAM_MAHKEMESI).ICRA_FOY_ID;
                if (icraFoyId.HasValue)
                {
                    AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama takip = gridView1.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama;
                    AV001_TI_BIL_FOY icra = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID(icraFoyId.Value);
                    TList<AV001_TI_BIL_FOY> seciliKayitler = new TList<AV001_TI_BIL_FOY>();
                    seciliKayitler.Add(icra);
                    _frmIcraTakip frmicraTakip = new _frmIcraTakip();
                    frmicraTakip.Show(seciliKayitler);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Seçilen ilam için kayýtlý bir föy bulunumadý.", "Föy Bulunamadý");
                }
            }
        }
    }
}