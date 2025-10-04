using System;
using System.Collections.Generic;
using System.Linq;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmTemsilBilgileriGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private VList<TEMSIL_TARAF_SORUMLU_BIRLESIK> MyDataSource = new VList<TEMSIL_TARAF_SORUMLU_BIRLESIK>();

        public rFrmTemsilBilgileriGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();

            //View olduðundan dolayý insert ve update iþlemleri yapýlamýyor..
            ucTemsilTarafSorumluBirlesik1.FocusedRowChanged += ucTemsilTarafSorumluBirlesik1_FocusedRowChanged;
        }

        public event EventHandler<FrmVekaletDosyaKayitEventArgs> VekaletDosyaKayitTiklandi;

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem22_ItemClick;
            this.Button_Excel_Click += barButtonItem25_ItemClick;
            this.Button_Outlook_Click += barButtonItem24_ItemClick;
            this.Button_PDF_Click += barButtonItem26_ItemClick;
            this.Button_Word_Click += barButtonItem23_ItemClick;
            this.Button_Kaydet_Click += temsilKayit_ItemClick;
        }

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void barButtonItem23_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        private void barButtonItem24_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void barButtonItem25_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void barButtonItem26_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void temsilKayit_ItemClick(object sender, EventArgs e)
        {
            //TEMSÝL KAYITA GÖNDER
            frmTemsilKayit frmTemSil = new frmTemsilKayit();
            if (VekaletDosyaKayitTiklandi != null)
                VekaletDosyaKayitTiklandi(this, new FrmVekaletDosyaKayitEventArgs(frmTemSil));
            frmTemSil.Show();
        }

        private void ucTemsilTarafSorumluBirlesik1_FocusedRowChanged(AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL temsil, object ExTemsil, int RowHandle, object sender)
        {
            List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> belgeList = new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();
            foreach (NN_BELGE_TEMSIL nn in DataRepository.NN_BELGE_TEMSILProvider.GetByTEMSIL_ID(temsil.ID))
                belgeList.Add(BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(item => item.ID == nn.BELGE_ID));
            this.ucBelgeIzlemeDolasimDock1.MyDataSource = belgeList;
        }
    }
}