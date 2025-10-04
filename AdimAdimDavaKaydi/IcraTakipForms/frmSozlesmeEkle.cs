using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmSozlesmeEkle : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _foy;

        private AV001_TI_BIL_ALACAK_NEDEN focusNeden = new AV001_TI_BIL_ALACAK_NEDEN();

        private bool kaydedildi;

        public frmSozlesmeEkle()
        {
            InitializeComponent();
            InitialzeEvents();
        }

        public AV001_TI_BIL_FOY Foy
        {
            get { return _foy; }
            set
            {
                _foy = value;
                if (value != null)
                {
                    BindAlacakNeden(Foy);
                }
            }
        }

        public void InitialzeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSozlesmeEkle_Button_Kaydet_Click;
        }

        public void Show(AV001_TI_BIL_FOY senderFoy)
        {
            Foy = senderFoy;

            this.Show();
        }

        private void BindAlacakNeden(AV001_TI_BIL_FOY foy)
        {
            try
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDI_BIL_SOZLESME>));
                ucSozlesmeBilgileri1.MyIcraFoy = foy;
                ucSozlesmeBilgileri1.MyDataSource = foy.AV001_TDI_BIL_SOZLESMECollection;
                bndAlacakNeden.DataSource = foy.AV001_TI_BIL_ALACAK_NEDENCollection;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (CikisKontroluYap())
            {
                DialogResult ds =
                    XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedilmeyecek, çýkmak istediðinizden emin misiniz?",
                                        "Vazgeç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ds == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource).Count; i++)
                        {
                            for (int j = 0;
                                 j <
                                 ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                                     AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.Count;
                                 j++)
                            {
                                if (
                                    ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                                        AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[j].
                                        IsNew)
                                    ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                                        AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.
                                        RemoveAt(j);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }

            this.Close();
        }

        private void btnKaydetCik_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            this.Close();
        }

        private bool CikisKontroluYap()
        {
            try
            {
                for (int i = 0; i < ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource).Count; i++)
                {
                    for (int j = 0;
                         j <
                         ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                             AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.Count;
                         j++)
                    {
                        if (
                            (((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                                AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[j].IsNew)
                            ||
                            (((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                                AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[j].IsDirty))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            return false;
        }

        private void frmSozlesmeEkle_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                kaydedildi = true;
                XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kayýt Esnasýnda Hata Oluþtu." + Environment.NewLine + "Dosya Kaydedilemedi.",
                                    "Kayýt",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                kaydedildi = false;
            }
        }

        private void frmSozlesmeEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;
            if (!CikisKontroluYap())
            {
                DialogResult ds =
                    XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedilmeyecek, çýkmak istediðinizden emin misiniz?",
                                        "Vazgeç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ds == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource).Count; i++)
                        {
                            for (int j = 0;
                                 j <
                                 ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                                     AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.Count;
                                 j++)
                            {
                                if (
                                    ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                                        AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW[j].
                                        IsNew)
                                    ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[i].
                                        AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.
                                        RemoveAt(j);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                else if (ds == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void frmSozlesmeEkle_Load(object sender, EventArgs e)
        {
            if (Foy != null)
            {
                BelgeUtil.Inits.AlacakNedenKodGetir((FormTipleri)Foy.FORM_TIP_ID.Value, rLueAlacakNeden, Foy);
            }
            BelgeUtil.Inits.ParaBicimiAyarla(rTutar);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
        }

        private void gwAlacak_FocusedRowChanged(object sender,
                                                DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle >= 0)
                {
                    focusNeden = ((TList<AV001_TI_BIL_ALACAK_NEDEN>)bndAlacakNeden.DataSource)[e.FocusedRowHandle];

                    //focusNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.AddingNew += new AddingNewEventHandler(Sozlesme_AddingNew);
                    ucSozlesmeBilgileri1.MyIcraFoy = Foy;
                    ucSozlesmeBilgileri1.MyDataSource =
                        focusNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                List<String> uyapHatalar = new List<string>();

                for (int i = 0; i < ucSozlesmeBilgileri1.MyDataSource.Count; i++)
                {
                    AV001_TDI_BIL_SOZLESME sozlesme = ucSozlesmeBilgileri1.MyDataSource[i];
                    if (sozlesme.TIP_ID.Value == (int)SozlesmeAnaTip.Kira_Sozlemesi)
                    {
                        if (!sozlesme.BASLANGIC_TARIHI.HasValue)
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Baþlangýç Tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
                        if (!sozlesme.BITIS_TARIHI.HasValue)
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Bitiþ Tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
                        if (sozlesme.BEDELI == null)
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Bedeli bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ", i + 1));
                        }

                        if (String.IsNullOrEmpty(sozlesme.TAHLIYE_ADRESI.Trim()))
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralý kayýtta Tahliye Adresi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                    i + 1));
                        }
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
                        return false;
                }

                trans.BeginTransaction();
                TList<AV001_TDI_BIL_SOZLESME> sozlist = ucSozlesmeBilgileri1.MyDataSource;
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, sozlist);
                foreach (AV001_TDI_BIL_SOZLESME sozlesme in sozlist)
                {
                    NN_ICRA_SOZLESME soz = Foy.NN_ICRA_SOZLESMECollection.AddNew();
                    soz.SOZLESME_ID = sozlesme.ID;
                    soz.ICRA_FOY_ID = Foy.ID;
                    Foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Add(sozlesme);
                    DataRepository.NN_ICRA_SOZLESMEProvider.DeepSave(trans, soz);
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }

            return true;
        }
    }
}