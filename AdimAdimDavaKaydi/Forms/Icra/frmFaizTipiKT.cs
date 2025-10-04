using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmFaizTipiKT : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmFaizTipiKT()
        {
            InitializeComponent();
            this.Load += frmFaizTipiKT_Load;
            spinFaizHarc.ValueChanged += spinFaizHarc_ValueChanged;
            spinAsilAlacak.ValueChanged += spinAsilAlacak_ValueChanged;
            InitializeEvents();
        }

        public DialogResult KayitBasarili = DialogResult.No;

        public AV001_TI_KOD_HESAP_TIP KaydedilenTip { get; set; }

        /// <summary>
        /// lBoxAsilAlacak ListBoxuna Asıl Alacakları listesini Basar
        /// </summary>
        private void AsilAlacakListesi()
        {
            TList<TDI_KOD_MAHSUP_KATEGORI> asilAlacakList =
                DataRepository.TDI_KOD_MAHSUP_KATEGORIProvider.Find("MODUL = '1' AND ALACAK_TIPI = '1'");
            lBoxAsilAlacak.DataSource = asilAlacakList;
            lBoxAsilAlacak.DisplayMember = "MAHSUP_KATEGORI";
            lBoxAsilAlacak.ValueMember = "ID";
        }

        private void btnAsilAlacakAsagi_Click(object sender, EventArgs e)
        {
            TList<TDI_KOD_MAHSUP_KATEGORI> faizList = lBoxAsilAlacak.DataSource as TList<TDI_KOD_MAHSUP_KATEGORI>;
            int index = lBoxAsilAlacak.SelectedIndex;
            TDI_KOD_MAHSUP_KATEGORI secilenKategori = faizList[index];

            if (index < faizList.Count - 1)
            {
                faizList.Remove(secilenKategori);

                faizList.Insert(index + 1, secilenKategori);
                lBoxAsilAlacak.SelectedIndex = index + 1;
            }
        }

        private void btnAsilAlacakYukari_Click(object sender, EventArgs e)
        {
            TList<TDI_KOD_MAHSUP_KATEGORI> faizList = lBoxAsilAlacak.DataSource as TList<TDI_KOD_MAHSUP_KATEGORI>;
            int index = lBoxAsilAlacak.SelectedIndex;
            TDI_KOD_MAHSUP_KATEGORI secilenKategori = faizList[index];

            if (index > 0)
            {
                faizList.Remove(secilenKategori);

                faizList.Insert(index - 1, secilenKategori);
                lBoxAsilAlacak.SelectedIndex = index - 1;
            }
        }

        private void btnFaizAsagi_Click(object sender, EventArgs e)
        {
            TList<TDI_KOD_MAHSUP_KATEGORI> faizList = lBoxFaiz.DataSource as TList<TDI_KOD_MAHSUP_KATEGORI>;
            int index = lBoxFaiz.SelectedIndex;
            TDI_KOD_MAHSUP_KATEGORI secilenKategori = faizList[index];

            if (index < faizList.Count - 1)
            {
                faizList.Remove(secilenKategori);

                faizList.Insert(index + 1, secilenKategori);
                lBoxFaiz.SelectedIndex = index + 1;
            }
        }

        private void btnFaizYukari_Click(object sender, EventArgs e)
        {
            TList<TDI_KOD_MAHSUP_KATEGORI> faizList = lBoxFaiz.DataSource as TList<TDI_KOD_MAHSUP_KATEGORI>;
            int index = lBoxFaiz.SelectedIndex;
            TDI_KOD_MAHSUP_KATEGORI secilenKategori = faizList[index];

            if (index > 0)
            {
                faizList.Remove(secilenKategori);

                faizList.Insert(index - 1, secilenKategori);
                lBoxFaiz.SelectedIndex = index - 1;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            AV001_TI_KOD_HESAP_TIP tip = new AV001_TI_KOD_HESAP_TIP();
            tip.ASIL_ALACAK_ORANI = Convert.ToDouble(spinAsilAlacak.Value);
            tip.DIGER_ALACAK_ORANI = Convert.ToDouble(spinFaizHarc.Value);
            tip.HESAP_TIP = tBoxHesapTip.Text;

            TList<TDI_KOD_MAHSUP_KATEGORI> faizListe = lBoxFaiz.DataSource as TList<TDI_KOD_MAHSUP_KATEGORI>;
            TList<TDI_KOD_MAHSUP_KATEGORI> asilAlacakListe = lBoxAsilAlacak.DataSource as TList<TDI_KOD_MAHSUP_KATEGORI>;

            for (int i = 0; i < faizListe.Count; i++)
            {
                AV001_TI_KOD_HESAP_TIP_SIRA sira = new AV001_TI_KOD_HESAP_TIP_SIRA();
                sira.MAHSUP_KATEGORI_ID = faizListe[i].ID;
                sira.SIRA_NO = i + 1;

                tip.AV001_TI_KOD_HESAP_TIP_SIRACollection.Add(sira);
            }

            for (int i = 0; i < asilAlacakListe.Count; i++)
            {
                AV001_TI_KOD_HESAP_TIP_SIRA sira = new AV001_TI_KOD_HESAP_TIP_SIRA();
                sira.MAHSUP_KATEGORI_ID = asilAlacakListe[i].ID;
                sira.SIRA_NO = i + 1;

                tip.AV001_TI_KOD_HESAP_TIP_SIRACollection.Add(sira);
            }

            DataRepository.AV001_TI_KOD_HESAP_TIPProvider.DeepSave(tip);

            KaydedilenTip = tip;
            BelgeUtil.Inits.KayitliHesapTipleriGetir(lueKayitliHesapTipi);
            KayitBasarili = DialogResult.OK;
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// lBoxFaiz ListBoxuna Faiz tipleri listesini Basar
        /// </summary>
        private void FaizListesi()
        {
            TList<TDI_KOD_MAHSUP_KATEGORI> faizList =
                DataRepository.TDI_KOD_MAHSUP_KATEGORIProvider.Find("MODUL ='1' AND ALACAK_TIPI='2'");
            lBoxFaiz.DataSource = faizList;
            lBoxFaiz.DisplayMember = "MAHSUP_KATEGORI";
            lBoxFaiz.ValueMember = "ID";
        }

        private void frmFaizTipiKT_Load(object sender, EventArgs e)
        {
            FaizListesi();

            AsilAlacakListesi();

            BelgeUtil.Inits.KayitliHesapTipleriGetir(lueKayitliHesapTipi);
        }

        private void InitializeEvents()
        {
            this.Button_Kaydet_Click += btnKaydet_Click;
        }

        private void lueKayitliHesapTipi_EditValueChanged(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt32(lueKayitliHesapTipi.EditValue);
            TList<AV001_TI_KOD_HESAP_TIP> liste =
                lueKayitliHesapTipi.Properties.DataSource as TList<AV001_TI_KOD_HESAP_TIP>;

            DataRepository.AV001_TI_KOD_HESAP_TIPProvider.DeepLoad(liste, false, DeepLoadType.IncludeChildren,
                                                                   typeof(TList<AV001_TI_KOD_HESAP_TIP_SIRA>),
                                                                   typeof(TDI_KOD_MAHSUP_KATEGORI));

            AV001_TI_KOD_HESAP_TIP secilenTip = liste.Find("ID", secilenId);
            TList<TDI_KOD_MAHSUP_KATEGORI> asilAlacakListesi = new TList<TDI_KOD_MAHSUP_KATEGORI>();
            TList<TDI_KOD_MAHSUP_KATEGORI> faizListesi = new TList<TDI_KOD_MAHSUP_KATEGORI>();

            secilenTip.AV001_TI_KOD_HESAP_TIP_SIRACollection.Sort("SIRA_NO");

            foreach (AV001_TI_KOD_HESAP_TIP_SIRA sira in secilenTip.AV001_TI_KOD_HESAP_TIP_SIRACollection)
            {
                if (sira.MAHSUP_KATEGORI_IDSource == null)
                {
                    DataRepository.AV001_TI_KOD_HESAP_TIP_SIRAProvider.DeepLoad(sira, false,
                                                                                DeepLoadType.IncludeChildren,
                                                                                typeof(TDI_KOD_MAHSUP_KATEGORI));
                }

                if (sira.MAHSUP_KATEGORI_IDSource.ALACAK_TIPI != null)
                {
                    if (sira.MAHSUP_KATEGORI_IDSource.ALACAK_TIPI == 1)
                    {
                        asilAlacakListesi.Add(sira.MAHSUP_KATEGORI_IDSource);
                    }
                    else if (sira.MAHSUP_KATEGORI_IDSource.ALACAK_TIPI == 2)
                    {
                        faizListesi.Add(sira.MAHSUP_KATEGORI_IDSource);
                    }
                }
            }

            lBoxAsilAlacak.DataSource = asilAlacakListesi;
            lBoxFaiz.DataSource = faizListesi;
            spinAsilAlacak.Value = Convert.ToDecimal(secilenTip.ASIL_ALACAK_ORANI);
            spinFaizHarc.Value = Convert.ToDecimal(secilenTip.DIGER_ALACAK_ORANI);
        }

        /// <summary>
        /// lueKayiyliHesapTipi lookupEditine Kayıtlı Hesap Tiplerini Doldurur
        /// </summary>
        ///
        private void spinAsilAlacak_ValueChanged(object sender, EventArgs e)
        {
            if (spinAsilAlacak.Value > 100)
            {
                spinAsilAlacak.Value = 100;
            }
            else if (spinAsilAlacak.Value < 0)
            {
                spinAsilAlacak.Value = 0;
            }

            int faizDegeri = 100 - (int)spinAsilAlacak.Value;
            if (faizDegeri == spinFaizHarc.Value) return;

            else spinFaizHarc.Value = faizDegeri;
        }

        private void spinFaizHarc_ValueChanged(object sender, EventArgs e)
        {
            if (spinFaizHarc.Value > 100)
            {
                spinFaizHarc.Value = 100;
            }
            else if (spinFaizHarc.Value < 0)
            {
                spinFaizHarc.Value = 0;
            }

            int faizDegeri = 100 - (int)spinFaizHarc.Value;
            if (faizDegeri == spinAsilAlacak.Value) return;

            else spinAsilAlacak.Value = faizDegeri;
        }
    }
}