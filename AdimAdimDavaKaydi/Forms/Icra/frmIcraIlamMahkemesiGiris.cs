using AdimAdimDavaKaydi.Util.Uyap;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmIcraIlamMahkemesiGiris : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Uyap GeriBildirim

        private UyapGeriBildirim _uyapBildirim;

        public UyapGeriBildirim UyapBildirim
        {
            get { return _uyapBildirim; }
            set { _uyapBildirim = value; }
        }

        #endregion Uyap GeriBildirim

        public frmIcraIlamMahkemesiGiris()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private AV001_TI_BIL_FOY foy;
        private bool isModul;

        [Browsable(false)]
        public AV001_TI_BIL_FOY Foy
        {
            get { return foy; }
            set { foy = value; }
        }

        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl1.Visible = value;
            }
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_ILAM_MAHKEMESI> MyDataSource
        {
            get { return ucIlamMahkemesi1.MyDataSource; }
            set
            {
                if (value != null)
                {
                    foreach (AV001_TI_BIL_ILAM_MAHKEMESI ilam in value)
                    {
                        ilam.ColumnChanged += ilam_ColumnChanged;
                    }
                    ucIlamMahkemesi1.MyDataSource = value;
                }
            }
        }

        private void frmIcraIlamMahkemesiGiris_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool hataVar = false;
            string Hatalar = string.Empty;
            foreach (AV001_TI_BIL_ILAM_MAHKEMESI ilam in MyDataSource)
            {
                if (!ilam.KARAR_TARIHI.HasValue)
                {
                    hataVar = true;
                    Hatalar += "Karar Tarihi Alanýný Boþ Geçmemelisiniz.!" + Environment.NewLine;
                }
            }
            if (!hataVar)
            {
                if (foy != null)
                {
                    List<String> uyapHatalar = new List<string>();

                    for (int i = 0; i < MyDataSource.Count; i++)
                    {
                        AV001_TI_BIL_ILAM_MAHKEMESI ilam = MyDataSource[i];

                        if (ilam.ILAM_TIP_ID == null)
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Ýlam Tipi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
                        if (ilam.ADLI_BIRIM_ADLIYE_ID == null)
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Ýlam Mahkemesi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
                        if (ilam.ADLI_BIRIM_NO_ID == null)
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Ýlam Görevi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
                        if (ilam.ADLI_BIRIM_GOREV_ID == null)
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Ýlam No bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ", i + 1));
                        }
                        if (string.IsNullOrEmpty(ilam.ESAS_NO.Trim()))
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Esas No bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ", i + 1));
                        }
                        if (string.IsNullOrEmpty(ilam.KARAR_NO.Trim()))
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Karar No bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
                    }

                    if (uyapHatalar.Count > 0)
                    {
                        string birlestirilmisHata = string.Empty;
                        foreach (string str in uyapHatalar)
                        {
                            birlestirilmisHata += Environment.NewLine + str;
                        }
                        DialogResult dr =
                            XtraMessageBox.Show(
                                "Aþaðýda bulunan alan(lar) Uyap için zorunludur. Boþ geçmek istediðinize emin misiniz?" +
                                birlestirilmisHata, "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.No)
                            return;
                    }

                    if (Foy.ID > 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(Foy, DeepSaveType.IncludeChildren,
                                                                         typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));
                    else
                        DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepSave(
                            Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection);

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                if (foy == null)
                {
                    DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepSave(MyDataSource);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            else if (hataVar)
            {
                MessageBox.Show(Hatalar);
            }
        }

        private void frmIcraIlamMahkemesiGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UyapBildirim != null)
                UyapBildirim.CagiranUyap.UyapGozdenGecir(UyapBildirim.IcraDosyalari, UyapBildirim.XmlDosyaYolu, UyapBildirim.geriBildirimYapilsin);
        }

        private void frmIcraIlamMahkemesiGiris_Load(object sender, EventArgs e)
        {
            if (isModul)
            {
                glueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Icra");
                glueDosya.Properties.DisplayMember = "FOY_NO";
                glueDosya.Properties.ValueMember = "ID";
            }
        }

        private void glueDosya_EditValueChanged(object sender, EventArgs e)
        {
            Foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)glueDosya.EditValue);
            MyDataSource = foy.AV001_TI_BIL_ILAM_MAHKEMESICollection;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIcraIlamMahkemesiGiris_Button_Kaydet_Click;
        }

        private void ilam_ColumnChanged(object sender, AV001_TI_BIL_ILAM_MAHKEMESIEventArgs e)
        {
            AV001_TI_BIL_ILAM_MAHKEMESI gonderen = (AV001_TI_BIL_ILAM_MAHKEMESI)sender;
            switch (e.Column)
            {
                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.BAKIYE_KARAR_HARCI_FAIZ_TIP_ID:
                    gonderen.BAKIYE_KARAR_HARCI_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                       gonderen.
                                                                                           BAKIYE_KARAR_HARCI_DOVIZ_ID,
                                                                                       DateTime.Today);

                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.ILAM_TEBLIG_GIDER_FAIZ_TIP_ID:
                    gonderen.ILAM_TEBLIG_GIDER_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                      gonderen.
                                                                                          ILAM_TEBLIG_GIDERI_DOVIZ_ID,
                                                                                      DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.ILAM_VEKALET_UCRET_FAIZ_TIP_ID:
                    gonderen.ILAM_VEKALET_UCRET_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                       gonderen.
                                                                                           ILAM_VEKALET_UCRETI_DOVIZ_ID,
                                                                                       DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.INKAR_TAZMINAT_FAIZ_TIP_ID:
                    gonderen.INKAR_TAZMINAT_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                   gonderen.INKAR_TAZMINATI_DOVIZ_ID,
                                                                                   DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.YARGILAMA_GIDERI_FAIZ_TIP_ID:
                    gonderen.YARGILAMA_GIDERI_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                     gonderen.YARGILAMA_GIDERI_DOVIZ_ID,
                                                                                     DateTime.Today);
                    break;

                case AV001_TI_BIL_ILAM_MAHKEMESIColumn.YARGITAY_ONAMA_HARCI_FAIZ_TIP_ID:
                    gonderen.YARGITAY_ONAMA_HARCI_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                                         gonderen.
                                                                                             YARGITAY_ONAMA_HARCI_DOVIZ_ID,
                                                                                         DateTime.Today);
                    break;
            }
        }
    }
}