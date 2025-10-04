using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;

namespace ImportExportWithSelection.Import
{
    public partial class frmIletisimBilgilrindenAl : DevExpress.XtraEditors.XtraForm
    {
        public frmIletisimBilgilrindenAl()
        {
            InitializeComponent();
        }

        private List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM> secilenIletisims = new List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM>();

        public TList<AV001_TDI_BIL_CARI_ALT> SelectedCariAlt { get; set; }

        private void frmIletisimBilgilrindenAl_Load(object sender, EventArgs e)
        {
            this.ucIletisimBilgileri1.MyDataSource = BelgeUtil.Inits.IletisimBilgileriGetir();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            secilenIletisims = ucIletisimBilgileri1.GetSelectedIletisims(ucIletisimBilgileri1.MyDataSource);

            foreach (var iletisimim in secilenIletisims)
            {
                AV001_TDI_BIL_CARI_ALT yeniCariAltim = new AV001_TDI_BIL_CARI_ALT();
                yeniCariAltim.AD = iletisimim.ADI;
                yeniCariAltim.ADRES_1 = iletisimim.ADRES_1 ?? "-";
                yeniCariAltim.ADRES_2 = iletisimim.ADRES_2 ?? "-";
                yeniCariAltim.ADRES_3 = iletisimim.ADRES_3 ?? "-";
                yeniCariAltim.IL_ID = iletisimim.IL_ID;
                yeniCariAltim.ILCE_ID = iletisimim.ILCE_ID;
                yeniCariAltim.ULKE_ID = iletisimim.ULKE_ID;
                yeniCariAltim.TEL_1 = iletisimim.TEL_1 ?? "-";
                yeniCariAltim.TEL_2 = iletisimim.TEL_2 ?? "-";
                yeniCariAltim.EMAIL_1 = iletisimim.EMAIL_1 ?? "-";
                yeniCariAltim.EMAIL_2 = iletisimim.EMAIL_2 ?? "-";
                yeniCariAltim.FAX = iletisimim.FAX ?? "-";
                yeniCariAltim.CEP_TEL = iletisimim.CEP_TEL ?? "-";
                SelectedCariAlt.Add(yeniCariAltim);
            }
        }
    }
}