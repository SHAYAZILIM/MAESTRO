using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmMuzzamSenetGiris : DevExpress.XtraEditors.XtraForm
    {
        public frmMuzzamSenetGiris()
        {
            InitializeComponent();
        }

        #region Properties

        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        private TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> Taraflar { get; set; }

        #endregion Properties

        #region Methots

        public DialogResult ShowDialog(AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE proje)
        {
            MyProje = proje;
            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> muhattaplarListesi = GetTebligatMuhattaplariByProje(proje);

            var taraflar = (from i in muhattaplarListesi
                            select new AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF
                                       {
                                           TARAF_CARI_ID = i.MUHATAP_CARI_ID,
                                           TARAF_TIP_ID = 6 //Borçlu
                                       }).ToList();

            Taraflar = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>();
            Taraflar.AddRange(taraflar);

            return this.ShowDialog();
        }

        private TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> GetTebligatMuhattaplariByProje(
            AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE proje)
        {
            var muhattaplarListesi = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
            if (proje.AV001_TDI_BIL_TEBLIGATCollection_From_AV001_TDIE_BIL_PROJE_IHTARNAME.Count == 0)
            {
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_TEBLIGAT>));
            }

            foreach (var item in proje.AV001_TDI_BIL_TEBLIGATCollection_From_AV001_TDIE_BIL_PROJE_IHTARNAME)
            {
                if (item.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count == 0)
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>
                                                                               ));

                muhattaplarListesi.AddRange(item.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection);
            }

            return muhattaplarListesi;
        }

        private void Inits()
        {
            BelgeUtil.Inits.perCariGetir(rLueCari);
            BelgeUtil.Inits.KiymetliEvrakTarafTipGetir(rLueKETarafSifat);
            BelgeUtil.Inits.KiymetliEvrakTipiGetir(EVRAK_TUR_IDLookUpEdit);
            BelgeUtil.Inits.ParaBicimiAyarla(TUTARSpinEdit);
            BelgeUtil.Inits.DovizTipGetir(TUTAR_DOVIZ_IDLookUpEdit);
        }

        /// <summary>
        /// Giriş yapılan kontrollerin durumlarını ayarlıyor
        /// </summary>
        /// <param name="rOnly"></param>
        private void SetControlReadOnly(bool rOnly)
        {
            dataLayoutControl1.OptionsView.IsReadOnly = rOnly
                                                            ? DevExpress.Utils.DefaultBoolean.True
                                                            : DevExpress.Utils.DefaultBoolean.False;

            //   dataNavigator1.Enabled = !rOnly;
            gcKiymetliEvrakTaraf.Enabled = !rOnly;
        }

        //Uyap için boş geçilemez alanlarda uyarı görünmesi için eklenmiştir.

        #region <MB-20091226>

        private void BindErrorProviders()
        {
            dxErrorProvider1.SetError(EVRAK_TANZIM_TARIHIDateEdit, "Tanzim Tarihi Uyap için Zorunlu Alandır.",
                                      DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            dxErrorProvider1.SetError(EVRAK_VADE_TARIHIDateEdit, "Vade Tarihi Uyap için Zorunlu Alandır.",
                                      DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            dxErrorProvider1.SetError(TUTARSpinEdit, "Tutar Uyap için Zorunlu Alandır.",
                                      DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
        }

        #endregion <MB-20091226>

        #endregion Methots

        #region Events

        public event EventHandler<EventArgs> KaydetButtonClick;

        private void bndKiymetliEvrak_AddingNew(object sender, AddingNewEventArgs e)
        {
            var evrak = new AV001_TDI_BIL_KIYMETLI_EVRAK();

            evrak.EVRAK_TUR_ID = 2;
            evrak.MUNZAM_SENET_MI = true;

            evrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddRange(Taraflar.Copy());
            evrak.NE_SEKILDE_AHZOLUNDUGU = (int)AvukatProLib.Extras.KEvrakAhzolunmaSekli.Nakten;
            e.NewObject = evrak;

            SetControlReadOnly(false);
        }

        private void bndKiymetliEvrak_CurrentChanged(object sender, EventArgs e)
        {
            if (bndKiymetliEvrak.Count == 0)
                SetControlReadOnly(true);
        }

        private void frmMuzzamSenetGiris_Load(object sender, EventArgs e)
        {
            Inits();

            BindErrorProviders();

            dataNavigator1.Buttons.DoClick(dataNavigator1.Buttons.Append);
        }

        private void tBtnKaydet_Click(object sender, EventArgs e)
        {
            if (MyProje != null)
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> evrakListesi = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

                foreach (var item in bndKiymetliEvrak.List)
                {
                    var kEvrak = item as AV001_TDI_BIL_KIYMETLI_EVRAK;

                    evrakListesi.Add(kEvrak);

                    // MyProje.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK.Add(kEvrak);
                }
                TransactionManager tm = new TransactionManager(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    //Kıymetli Evrak kaydında uyap kontrollerinin kontrolü.

                    #region <MB-20091226>

                    List<String> uyapBosAlanlar = new List<string>();

                    for (int i = 0; i < bndKiymetliEvrak.Count; i++)
                    {
                        AV001_TDI_BIL_KIYMETLI_EVRAK kiymetliEvrak =
                            bndKiymetliEvrak.Current as AV001_TDI_BIL_KIYMETLI_EVRAK;

                        if (!kiymetliEvrak.EVRAK_TANZIM_TARIHI.HasValue)
                        {
                            uyapBosAlanlar.Add(
                                String.Format(
                                    "{0} numaralı kayıtta Tanzim Tarihi bölümü Uyap için zorunlu alandır. Boş geçilmiş",
                                    i + 1));
                        }
                        if (kiymetliEvrak.TUTAR == null)
                        {
                            uyapBosAlanlar.Add(
                                String.Format(
                                    "{0} numaralı kayıtta Tutar bölümü Uyap için zorunlu alandır. Boş geçilmiş", i + 1));
                        }
                        if (kiymetliEvrak.EVRAK_TUR_ID == (int)EvrakTurleri.BONO ||
                            kiymetliEvrak.EVRAK_TUR_ID == (int)EvrakTurleri.POLİÇE)
                        {
                            if (!kiymetliEvrak.EVRAK_VADE_TARIHI.HasValue)
                            {
                                uyapBosAlanlar.Add(
                                    String.Format(
                                        "{0} numaralı kayıtta Vade tarihi bölümü Uyap için zorunlu alandır. Boş geçilmiş",
                                        i + 1));
                            }
                        }
                    }
                    if (uyapBosAlanlar.Count > 0)
                    {
                        string birlestirilmisHata = string.Empty;
                        foreach (string str in uyapBosAlanlar)
                        {
                            birlestirilmisHata += Environment.NewLine + str;
                        }
                        DialogResult dr =
                            XtraMessageBox.Show(
                                "Aşağıda bulunan alan(lar) Uyap için zorunludur. Boş geçmek istediğinize emin misiniz?" +
                                birlestirilmisHata, "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.No)
                            return;
                    }

                    #endregion <MB-20091226>

                    tm.BeginTransaction();

                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(tm, evrakListesi);
                    TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK> nnListesi =
                        new TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK>();

                    foreach (var item in evrakListesi)
                    {
                        var nn = nnListesi.AddNew();

                        nn.KIYMETLI_EVRAK_ID = item.ID;
                        nn.PROJE_ID = MyProje.ID;
                    }

                    DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.DeepSave(tm, nnListesi);

                    tm.Commit();
                }
                catch (Exception ex)
                {
                    if (tm.IsOpen)
                        tm.Rollback();

                    foreach (var item in evrakListesi)
                    {
                        MyProje.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK.Remove(
                            item);
                    }
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            if (KaydetButtonClick != null)
                KaydetButtonClick(this, new EventArgs());

            MessageBox.Show("Kayıt Tamamlandı");

            this.Close();
        }

        #endregion Events
    }
}