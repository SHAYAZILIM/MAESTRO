using System;
using System.Collections.Generic;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmKasaGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        //private AdimAdimDavaKaydi.ExtendTool.compRibbonExtender compRibbonExtender1;
        private List<IKasali> kasali = new List<IKasali>();

        public rFrmKasaGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem22_ItemClick;
            this.Button_Excel_Click += barButtonItem25_ItemClick;
            this.Button_Outlook_Click += barButtonItem25_ItemClick;
            this.Button_PDF_Click += barButtonItem24_ItemClick;
            this.Button_Word_Click += barButtonItem23_ItemClick;
            this.Button_Kaydet_Click += barButtonItem1_ItemClick;
        }

        private void barButtonItem1_ItemClick(object sender, EventArgs e)
        {
            //AdimAdimDavaKaydi.Muhasebe.rFrmKasaKayitEkran frmKasaKayit = new AdimAdimDavaKaydi.Muhasebe.rFrmKasaKayitEkran();
            //frmKasaKayit.Show();
        }

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void barButtonItem23_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc, kasali);
        }

        private void barButtonItem24_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst, kasali);
        }

        private void barButtonItem25_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls, kasali);
        }

        private void rFrmKasaGirisEkran_Load(object sender, EventArgs e)
        {
            //Okan 02.08.2010
            ////LOAD
            //TList<AV001_TDI_BIL_KASA> kasalar = DataRepository.AV001_TDI_BIL_KASAProvider.GetAll();
            //TList<AV001_TDI_BIL_CARI_HESAP_DETAY> cariHesaplar = DataRepository.AV001_TDI_BIL_CARI_HESAP_DETAYProvider.GetAll();
            //DataRepository.AV001_TDI_BIL_CARI_HESAP_DETAYProvider.DeepLoad(cariHesaplar, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI_HESAP));

            //kasali.AddRange(kasalar.ToArray());
            //kasali.AddRange(cariHesaplar.ToArray());
            ////DATASOURCE`Ý BURDA VER

            ucKasa1.kasali = BelgeUtil.Inits.KasaBilgileriGetir();
        }
    }
}