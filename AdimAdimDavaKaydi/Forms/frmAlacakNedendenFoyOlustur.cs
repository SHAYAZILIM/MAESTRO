using AdimAdimDavaKaydi.Forms.Icra;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmAlacakNedendenFoyOlustur : DevExpress.XtraEditors.XtraForm
    {
        public frmAlacakNedendenFoyOlustur()
        {
            InitializeComponent();
        }

        public frmIcraDosyaKayit frm;

        public bool IsLoaded;

        private AV001_TDIE_BIL_PROJE _MyProje;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private string formYeniTip;

        public event EventHandler<EventArgs> IcraDosyasiKaydedildi;

        private enum TakipOlusturmaYolu
        {
            TakipSecerek,
            YolSecerek
        }

        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return _MyProje; }
            set
            {
                if (value != null && IsLoaded)
                {
                    BindData();
                }
                _MyProje = value;
            }
        }

        public static bool TarafVarmi(TList<AV001_TI_BIL_FOY_TARAF> taraflar, int cariId)
        {
            bool result = false;
            foreach (AV001_TI_BIL_FOY_TARAF trf in taraflar)
            {
                if (trf.CARI_ID.HasValue && trf.CARI_ID.Value == cariId)
                    result = true;
            }
            return result;
        }

        public void BindData()
        {
            if (!bckWorker.IsBusy)
            {
                this.Enabled = false;
                bckWorker.DoWork += delegate
                                        {
                                            //Eðer proje üzerindeki alacaklar doldurulmamýþ ise.
                                            if (
                                                MyProje.
                                                    AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN
                                                    .Count == 0)
                                            {
                                                //Alacak neden ve neden taraf ayrýca taraf faiz  üzerine deepload çekiyoruz.
                                                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                                                     DeepLoadType.
                                                                                                         ExcludeChildren,
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TI_BIL_ALACAK_NEDEN
                                                                                                         >),
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TI_BIL_ALACAK_NEDEN_TARAF
                                                                                                         >),
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ
                                                                                                         >));
                                            }

                                            //Alacaklarýmýzý gride dolduruyoruz.
                                            if (
                                                MyProje.
                                                    AV001_TDI_BIL_SOZLESMECollection_From_AV001_TDIE_BIL_PROJE_SOZLESME.
                                                    Count == 0)
                                            {
                                                //Sozlesme bilgilerine deepload çekiyoruz
                                                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                                                     DeepLoadType.
                                                                                                         ExcludeChildren,
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TDI_BIL_SOZLESME
                                                                                                         >));
                                            }
                                            if (true)
                                            {
                                                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false,
                                                                                                     DeepLoadType.
                                                                                                         ExcludeChildren,
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TDI_BIL_IHTIYATI_TEDBIR
                                                                                                         >),
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TI_BIL_IHTIYATI_HACIZ
                                                                                                         >),
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TDIE_BIL_PROJE_ILAM_BILGILERI
                                                                                                         >),
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TI_BIL_ILAM_MAHKEMESI
                                                                                                         >));
                                                DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepLoad(
                                                    MyProje.
                                                        AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_From_AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR,
                                                    false, DeepLoadType.ExcludeChildren,
                                                    typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>),
                                                    typeof(TDIE_KOD_TARAF_SIFAT), typeof(AV001_TDI_BIL_CARI));
                                                DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(
                                                    MyProje.
                                                        AV001_TI_BIL_IHTIYATI_HACIZCollection_From_AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ,
                                                    false, DeepLoadType.ExcludeChildren,
                                                    typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>),
                                                    typeof(TDIE_KOD_TARAF_SIFAT), typeof(AV001_TDI_BIL_CARI));
                                                DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepLoad(
                                                    MyProje.
                                                        AV001_TI_BIL_ILAM_MAHKEMESICollection_From_AV001_TDIE_BIL_PROJE_ILAM_BILGILERI,
                                                    false, DeepLoadType.ExcludeChildren,
                                                    typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI_TARAF>),
                                                    typeof(AV001_TDI_BIL_CARI));
                                            }
                                        };

                bckWorker.RunWorkerCompleted += delegate { this.Enabled = true; };

                bckWorker.RunWorkerAsync();
            }
        }

        private int? AlacakNedenKodIdGetir(int formTipi, int alacakId)
        {
            TList<TI_KOD_ALACAK_NEDEN> aNeden =
                DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByAlacakNedenIdAndFormTipId(formTipi, alacakId);
            if (aNeden != null && aNeden.Count > 0)
                return aNeden[0].ID;
            else
                return null;
        }

        private void bandedGridView1_CellValueChanged(object sender,
                                                      DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("GC Alacaklar Cell Value Changing  {0}", DateTime.Now));

            if (e.Column == colIsSelected)
            {
                FormTipleriniAyarla();

                TaraflariAyarla();
            }
            System.Diagnostics.Debug.WriteLine(string.Format("GC Alacaklar Cell Value Changed  {0}", DateTime.Now));
        }

        private void BringToFront_MouseHover(object sender, EventArgs e)
        {
            //Control cnt = sender as Control;
            //cnt.BringToFront();
        }

        private void btnTakipAc_Click(object sender, EventArgs e)
        {
            #region <YY-20090623>

            //kontroller yapýlýyor.

            if (gcAlacaklar.DataSource != null)
            {
                var alacaklar = ((TList<AV001_TI_BIL_ALACAK_NEDEN>)gcAlacaklar.DataSource);
                if (alacaklar.FindAll(delegate(AV001_TI_BIL_ALACAK_NEDEN ndn) { return ndn.IsSelected; }).Count == 0)
                {
                    MessageBox.Show("Lütfen en az bir tane alacak seçiniz");
                    return;
                }
                if (radioGroup1.EditValue == null)
                {
                    MessageBox.Show("Lütfen bir takip yolu seçiniz");
                    return;
                }

                foreach (var grANeden in alacaklar)
                {
                    var aNeden = MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Find(item => item.ID == grANeden.ID);
                    aNeden.REFERANS_ALACAK_NEDEN_ID = grANeden.ID;//Klasörden hangi alacak nedeninden oluþturulduðunu saptayabilmek için eklendi. MB

                    aNeden.IsSelected = grANeden.IsSelected;
                    foreach (var taraf in (gcTaraflar.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>).FindAll(vi => vi.ICRA_ALACAK_NEDEN_ID == grANeden.ID))
                    {
                        if (aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

                        aNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Find(t => t.ID == taraf.ID).IsSelected = taraf.IsSelected;
                    }
                }

            #endregion <YY-20090623>

                //Takip oluþtura ilk basýldýðýnda isSelected alaný griddeki ile ayný gelmiyordu. Ondan dolayý böyle bir atama iþlemi eklendi. MB
                MyProje.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK.FindAll(vi => vi.MUNZAM_SENET_MI ?? false).ForEach(munzam =>
                    {
                        var gridMunzam = (bndMunzamSenet.DataSource as TList<AV001_TDI_BIL_KIYMETLI_EVRAK>).Find(vi => vi.ID == munzam.ID);
                        if (gridMunzam != null)
                            munzam.IsSelected = gridMunzam.IsSelected;
                    });
                MyProje.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_From_AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR.ForEach(tedbir =>
                    {
                        var gridTedbir = (gcIhtiyatiTedbir.DataSource as TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>).Find(vi => vi.ID == tedbir.ID);
                        if (gridTedbir != null)
                            tedbir.IsSelected = gridTedbir.IsSelected;
                    });
                MyProje.AV001_TI_BIL_IHTIYATI_HACIZCollection_From_AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ.ForEach(haciz =>
                {
                    var gridHaciz = (gcIhtiyatiHaciz.DataSource as TList<AV001_TI_BIL_IHTIYATI_HACIZ>).Find(vi => vi.ID == haciz.ID);
                    if (gridHaciz != null)
                        haciz.IsSelected = gridHaciz.IsSelected;
                });

                if (SozlesmeKontrolu() == DialogResult.Cancel)
                    return;

                frm = new frmIcraDosyaKayit();
                frm.IsEdit = true;
                if (gcSozlesme.DataSource != null)
                    frm.KlasorSozlesmeList = gcSozlesme.DataSource as TList<AV001_TDI_BIL_SOZLESME>;
                frm.MyProje = MyProje;
                frm.FromTipi = FormTipIdGetir();
                frm.TakipTalep = TakipTalepIdGetir();
                frm.IcraFoyKaydedildi += frm_IcraFoyKaydedildi;
                foreach (AV001_TI_BIL_ALACAK_NEDEN aNeden in alacaklar.Where(vi => vi.IsSelected))
                {
                    frm.AlacakNedenKod = AlacakNedenKodIdGetir(frm.FromTipi ?? 0, aNeden.ALACAK_NEDEN_KOD_ID ?? 0);

                    if (frm.AlacakNedenKod != null)
                        break;
                }
                frm.Show();
                this.Close();
            }
        }

        private void btnTakipYoluSec_Click(object sender, EventArgs e)
        {
            if (radioGroup1.Tag != null &&
                radioGroup1.Tag is TakipOlusturmaYolu &&
                (TakipOlusturmaYolu)radioGroup1.Tag == TakipOlusturmaYolu.YolSecerek)
            {
                for (int i = 0; i < radioGroup1.Properties.Items.Count; i++)
                {
                    radioGroup1.Properties.Items[i].Enabled = false;
                }

                radioGroup1.Tag = TakipOlusturmaYolu.TakipSecerek;
            }
            else
            {
                for (int i = 0; i < radioGroup1.Properties.Items.Count; i++)
                {
                    radioGroup1.Properties.Items[i].Enabled = true;
                }

                radioGroup1.Tag = TakipOlusturmaYolu.YolSecerek;
            }
        }

        private void cbAlacakNedenleri_CheckedChanged(object sender, EventArgs e)
        {
            if (gcAlacaklar.DataSource != null && gcAlacaklar.DataSource is TList<AV001_TI_BIL_ALACAK_NEDEN>)
            {
                var alacaklar = gcAlacaklar.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN>;

                for (int i = 0; i < alacaklar.Count; i++)
                {
                    alacaklar[i].IsSelected = cbAlacakNedenleri.Checked;
                }

                FormTipleriniAyarla();

                TaraflariAyarla();
            }

            if (cbAlacakNedenleri.Checked)
                cbAlacakNedenleri.Text = "Alacak Nedeni Seçimlerinin Tümünü Kaldýr";
            else
                cbAlacakNedenleri.Text = "Tüm Alacak Nedenlerini Seç";
        }

        private void cbTaraflar_CheckedChanged(object sender, EventArgs e)
        {
            if (gvAnTaraflar.DataSource != null && gvAnTaraflar.DataSource is TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>)
            {
                var taraflar = gvAnTaraflar.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>;
                for (int i = 0; i < taraflar.Count; i++)
                {
                    taraflar[i].IsSelected = cbTaraflar.Checked;
                }
            }

            if (cbTaraflar.Checked)
                cbTaraflar.Text = "Taraf Seçimlerinin Tümünü Kaldýr";
            else
                cbTaraflar.Text = "Taraflarýn Tümünü Seç";
        }

        private int? FormTipIdGetir()
        {
            per_TI_KOD_TAKIP_TALEP tTalep = radioGroup1.EditValue as per_TI_KOD_TAKIP_TALEP;
            if (tTalep != null)
            {
                TList<TI_KOD_FORM_TIP> formTipleri =
                    DataRepository.TI_KOD_FORM_TIPProvider.Find(String.Format("FORM_ORNEK_NO = '{0}'", tTalep.FORM_TIPI));
                if (formTipleri.Count > 0)
                {
                    return formTipleri[0].ID;
                }
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// Form tipi eðer 50-201-151-152 ise true döner deðilse false döner
        /// </summary>
        /// <param name="formTipId"></param>
        /// <returns></returns>
        private bool FormTipiKontrol(int? formTipId)
        {
            switch (formTipId)
            {
                case 2:
                case 13:
                case 14:
                case 17:
                    return true;

                default:
                    break;
            }

            return false;
        }

        private bool FormTipindeVarmi(List<String> secilenler, TI_KOD_TAKIP_TALEP tTalep)
        {
            if (secilenler.Count == 0)
                return false;

            bool alacakNedenKontrolu = false;

            foreach (string str in secilenler)
            {
                if (tTalep.TI_KOD_ALACAK_NEDENCollection.Find(TI_KOD_ALACAK_NEDENColumn.ALACAK_NEDENI, str) != null)
                    alacakNedenKontrolu = true;
            }
            if (alacakNedenKontrolu &&
                SozlesmeKosulu(tTalep)
                && IlamKosulu(tTalep))
                return true;

            return false;
        }

        private void FormTipleriniAyarla()
        {
            if (radioGroup1.Tag != null &&
                (TakipOlusturmaYolu)radioGroup1.Tag == TakipOlusturmaYolu.YolSecerek)
                return;

            System.Diagnostics.Debug.WriteLine(string.Format("Form Tipleri Ayarlanýyor {0}", DateTime.Now));

            List<string> secilenler = new List<string>();
            var alacaklar = gcAlacaklar.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN>;
            foreach (AV001_TI_BIL_ALACAK_NEDEN an in alacaklar)
            {
                if (an.IsSelected)
                {
                    if (!secilenler.Contains(an.DIGER_ALACAK_NEDENI))
                        secilenler.Add(an.DIGER_ALACAK_NEDENI);
                }
            }
            bool hicVarmi = false;
            foreach (RadioGroupItem rgi in radioGroup1.Properties.Items)
            {
                TI_KOD_TAKIP_TALEP tTalep = rgi.Value as TI_KOD_TAKIP_TALEP;
                if (tTalep != null)
                {
                    rgi.Enabled = FormTipindeVarmi(secilenler, tTalep);
                    hicVarmi = hicVarmi || rgi.Enabled;
                }
            }
            btnTakipAc.Enabled = hicVarmi;
            radioGroup1.EditValue = null;

            System.Diagnostics.Debug.WriteLine(string.Format("Form Tipleri ayarlandý {0}", DateTime.Now));
        }

        private void frm_IcraFoyKaydedildi(object sender, IcraFoyKaydedildiEventArgs e)
        {
            if (e.IcraFoy != null)
            {
                if (
                    MyProje.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.Exists(
                        delegate(AV001_TDIE_BIL_PROJE_ICRA_FOY icra) { return icra.ICRA_FOY_ID == e.IcraFoy.ID; }))
                    return;

                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(MyProje,
                                                                     DeepSaveType.IncludeChildren,
                                                                     typeof(TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK>),
                                                                     typeof(
                                                                         TList
                                                                         <AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI>));

                AV001_TDIE_BIL_PROJE_ICRA_FOY proFoy = new AV001_TDIE_BIL_PROJE_ICRA_FOY();
                proFoy.ICRA_FOY_ID = e.IcraFoy.ID;
                MyProje.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.Add(proFoy);
                foreach (var item in e.IcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    if (MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Contains(item))
                    {
                        DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.Delete(MyProje.ID, item.ID);
                    }

                    #region Hesapta senaryo deðiþikli yüzünden iptal edildi

                    //sadece takipsiz alacaklar tablosuna kayýtlý alacaklar ile hesap yapýlacaðýndan,
                    //takipbe alýnan alacaðýn takipsizler arasýndan silinmesi senaryosu iptal edilmiþtir
                    //foreach (var an in MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDENCollection)
                    //{
                    //    if (an.ALACAK_NEDEN_IDSource == null)
                    //        an.ALACAK_NEDEN_IDSource = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(an.ALACAK_NEDEN_ID);

                    //    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(an.ALACAK_NEDEN_IDSource,
                    //                            false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

                    //    if (an.ALACAK_NEDEN_IDSource.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Exists(
                    //        delegate(AV001_TI_BIL_ALACAK_NEDEN_TARAF alacakNedenTrf)
                    //    {
                    //        return (alacakNedenTrf.TARAF_SIFAT_ID == (int)TarafSifat.BORCLU);

                    //    })) continue;

                    //    SqlFilterParameterCollection col = new SqlFilterParameterCollection();
                    //    col.Add(new SqlFilterParameter(AV001_TI_BIL_ALACAK_NEDENColumn.EU_ID,an.ALACAK_NEDEN_IDSource.EU_ID.ToString(),0));

                    //    TList<AV001_TI_BIL_ALACAK_NEDEN> nedenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                    //    AvukatProLib2.Data.Bases.AV001_TI_BIL_ALACAK_NEDENProviderBase.Fill(
                    //        DataRepository.Provider.ExecuteReader(CommandType.Text,
                    //        string.Format("SELECT * FROM AV001_TI_BIL_ALACAK_NEDEN WHERE EU_ID = '{0}'", an.ALACAK_NEDEN_IDSource.EU_ID.ToString())), nedenler, 0, int.MaxValue);

                    //    //Munzam senet ile takibe konulmuþsa özel durumlar için
                    //    if (nedenler.Where(vi => vi.AN_URETIP_TIP == (byte?)AN_URETIP_TIP.SenetleTakibeKonuldu).Count() > 0)
                    //        continue;

                    //    DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.Delete(MyProje.ID, an.ALACAK_NEDEN_ID);
                    //}

                    #endregion Hesapta senaryo deðiþikli yüzünden iptal edildi

                    if (
                        MyProje.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLICollection.Exists(
                            delegate(AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI alacakNeden) { return alacakNeden.ALACAK_NEDEN_ID == item.ID; })) continue;
                    AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI tkip = new AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI();
                    tkip.PROJE_ID = MyProje.ID;
                    tkip.ALACAK_NEDEN_ID = item.ID;
                    tkip.KAYNAK_ALACAK_NEDEN_ID = item.REFERANS_ALACAK_NEDEN_ID;///Klasörden hangi alacak nedeninden oluþturulduðunu saptayabilmek için eklendi. MB
                    DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLIProvider.Save(tkip);
                }
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(MyProje, DeepSaveType.IncludeChildren,
                                                                     typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_FOY>));

                ////Klasörde ipotek ya da munzam varsa 151,152,50,201 form tiplerinde alacaklarýn sýfýrlamamasý, takip açýlan tarafa tekrar takip açýlabilmesi için eklendi. MB
                //if ((e.IcraFoy.FORM_TIP_ID != (int)FormTipleri.Form151 && e.IcraFoy.FORM_TIP_ID != (int)FormTipleri.Form152 && e.IcraFoy.FORM_TIP_ID != (int)FormTipleri.Form50 && e.IcraFoy.FORM_TIP_ID != (int)FormTipleri.Form201) || (MyProje.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TDIE_BIL_PROJE_TEMINAT.Count == 0 && MyProje.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK.FindAll(vi => vi.MUNZAM_SENET_MI ?? false).Count == 0))
                //{
                //    if (e.IcraFoy.FORM_TIP_ID != (int)FormTipleri.Form151 && e.IcraFoy.FORM_TIP_ID != (int)FormTipleri.Form152 && e.IcraFoy.FORM_TIP_ID != (int)FormTipleri.Form50 && e.IcraFoy.FORM_TIP_ID != (int)FormTipleri.Form201)
                //    {
                //        foreach (var neden in MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN)
                //        {
                //            if (neden.EU_ID.HasValue)
                //            {
                //                var alacaklar = KlasorHesapAraclari.GetAlacakNedenByEuId(neden.EU_ID.Value);

                //                var paralar =
                //                    alacaklar.Select(
                //                        vi => new ParaVeDovizId(vi.ISLEME_KONAN_TUTAR, vi.ISLEME_KONAN_TUTAR_DOVIZ_ID)).ToList();

                //                var kalan = ParaVeDovizId.Cikart(new ParaVeDovizId(neden.TUTARI, neden.TUTAR_DOVIZ_ID)
                //                                                 , ParaVeDovizId.Topla(paralar));

                //                neden.ISLEME_KONAN_TUTAR = kalan.Para;
                //                neden.ISLEME_KONAN_TUTAR_DOVIZ_ID = kalan.DovizId;
                //            }
                //        }
                //    }
                //}

                //DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.Save(
                //    MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN);

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));//Klasörde ipotek ya da munzam varsa 151,152,50,201 form tiplerinde alacaklarýn sýfýrlamamasý, takip açýlan tarafa tekrar takip açýlabilmesi için eklendi. MB

                TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ> iHacizList = new TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ>();
                TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI> iHacizTakipliList = new TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI>();

                e.IcraFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.ForEach(iHaciz =>
                    {
                        var tempIHaciz = DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZProvider.GetByPROJE_IDIHTIYATI_HACIZ_ID(MyProje.ID, iHaciz.ID);
                        if (tempIHaciz != null && iHacizList.Find(vi => vi.IHTIYATI_HACIZ_ID == tempIHaciz.IHTIYATI_HACIZ_ID) == null)
                        {
                            iHacizList.Add(tempIHaciz);

                            AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI iHacizTakipli = new AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI();
                            iHacizTakipli.IHTIYATI_HACIZ_ID = tempIHaciz.IHTIYATI_HACIZ_ID;
                            iHacizTakipli.PROJE_ID = tempIHaciz.PROJE_ID;
                            iHacizTakipli.STAMP = tempIHaciz.STAMP;
                            if (!iHacizTakipliList.Contains(iHacizTakipli))
                                iHacizTakipliList.Add(iHacizTakipli);
                        }
                    });

                TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR> iTedbirList = new TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR>();
                TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI> iTedbirTakipliList = new TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI>();

                e.IcraFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.ForEach(iTedbir =>
                {
                    var tempITedbir = DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIRProvider.GetByPROJE_IDIHTIYATI_TEDBIR_ID(MyProje.ID, iTedbir.ID);
                    if (tempITedbir != null && iTedbirList.Find(vi => vi.IHTIYATI_TEDBIR_ID == tempITedbir.IHTIYATI_TEDBIR_ID) == null)
                    {
                        iTedbirList.Add(tempITedbir);

                        AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI iTedbirTakipli = new AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI();
                        iTedbirTakipli.IHTIYATI_TEDBIR_ID = tempITedbir.IHTIYATI_TEDBIR_ID;
                        iTedbirTakipli.PROJE_ID = tempITedbir.PROJE_ID;
                        iTedbirTakipli.STAMP = tempITedbir.STAMP;
                        if (!iTedbirTakipliList.Contains(iTedbirTakipli))
                            iTedbirTakipliList.Add(iTedbirTakipli);
                    }
                });
                DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIRProvider.Delete(iTedbirList);
                DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZProvider.Delete(iHacizList);
                DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLIProvider.Save(iTedbirTakipliList);
                DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLIProvider.Save(iHacizTakipliList);

                if (IcraDosyasiKaydedildi != null)
                    IcraDosyasiKaydedildi(e.IcraFoy, new EventArgs());

                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmAlacakNedendenFoyOlustur_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Alacaklardan Takip Oluþtur Form Loading {0}", DateTime.Now));
            IsLoaded = true;
            BindData();

            BelgeUtil.Inits.perCariGetir(rlkCari);
            BelgeUtil.Inits.TarafSifatGetir(rlkTarafSifat);
            BelgeUtil.Inits.DovizTipGetir(rlkDoviz);
            BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(rlkSozlesmeAltTip);
            BelgeUtil.Inits.SozlesmeTipiGetir(rlkSozlesmeTip);
            BelgeUtil.Inits.SozlesmeSekliGetir(rlkSozlesmeTur);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlkAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlkGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rlkNo);
            BelgeUtil.Inits.KiymetliEvrakTipiGetir(rlueEvrakTur);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.ParaBicimiAyarla(rSpinTutar);

            bndAlacakNeden.DataSource = MyProje;
            if (MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Count == 0)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            gcAlacaklar.DataSource =
                ((AV001_TDIE_BIL_PROJE)bndAlacakNeden.DataSource).
                    AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN;

            if (MyProje != null)
            {
                //Sözleþme gridini dolduruyoruz.

                TList<AV001_TDI_BIL_SOZLESME> sozList = new TList<AV001_TDI_BIL_SOZLESME>();

                if (MyProje.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TDIE_BIL_PROJE_SOZLESME.Count == 0 || (MyProje.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TDIE_BIL_PROJE_TEMINAT.Count == 0))
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));//Takip oluþtura ilk basýldýðýnda collection count 0 geldiðinden DeepLoad eklendi. MB

                sozList = MyProje.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TDIE_BIL_PROJE_SOZLESME.FindAll(sozlesmeSuz);

                foreach (var item in MyProje.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TDIE_BIL_PROJE_TEMINAT)
                {
                    if (sozList.Where(vi => vi.ID == item.ID).Count() == 0)
                    {
                        sozList.Add(item);
                    }
                }

                gcSozlesme.DataSource = sozList;

                if (MyProje.AV001_TI_BIL_IHTIYATI_HACIZCollection_From_AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>));//Takip oluþtura ilk basýldýðýnda collection count 0 geldiðinden DeepLoad eklendi. MB
                gcIhtiyatiHaciz.DataSource = ((AV001_TDIE_BIL_PROJE)bndAlacakNeden.DataSource).AV001_TI_BIL_IHTIYATI_HACIZCollection_From_AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ.FindAll(hacizSuz);

                if (MyProje.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_From_AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>));//Takip oluþtura ilk basýldýðýnda collection count 0 geldiðinden DeepLoad eklendi. MB
                gcIhtiyatiTedbir.DataSource = ((AV001_TDIE_BIL_PROJE)bndAlacakNeden.DataSource).AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_From_AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR.FindAll(tedbirSuz);

                if (MyProje.AV001_TI_BIL_ILAM_MAHKEMESICollection_From_AV001_TDIE_BIL_PROJE_ILAM_BILGILERI.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));
                gcIlamBilgileri.DataSource = ((AV001_TDIE_BIL_PROJE)bndAlacakNeden.DataSource).AV001_TI_BIL_ILAM_MAHKEMESICollection_From_AV001_TDIE_BIL_PROJE_ILAM_BILGILERI.FindAll(IlamSuz);

                if (MyProje.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>)); //Takip oluþtura ilk basýldýðýnda collection count 0 geldiðinden DeepLoad eklendi. MB
                bndMunzamSenet.DataSource =
                    MyProje.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK.FindAll(
                        vi => vi.MUNZAM_SENET_MI ?? false);

                if (BelgeUtil.Inits._TakipKonusuGetir_Enter == null)
                    BelgeUtil.Inits._TakipKonusuGetir_Enter = DataRepository.per_TI_KOD_TAKIP_TALEPProvider.GetAll();
                VList<per_TI_KOD_TAKIP_TALEP> takipTalep = BelgeUtil.Inits._TakipKonusuGetir_Enter;

                if (BelgeUtil.Inits._FormTipiGetir == null)
                    BelgeUtil.Inits._FormTipiGetir = BelgeUtil.Inits.context.per_TI_KOD_FORM_TIPs.ToList();
                List<AvukatProLib.Arama.per_TI_KOD_FORM_TIP> FormTiplist = BelgeUtil.Inits._FormTipiGetir;

                foreach (per_TI_KOD_TAKIP_TALEP tTalep in takipTalep)
                {
                    foreach (AvukatProLib.Arama.per_TI_KOD_FORM_TIP item in FormTiplist)
                    {
                        if (item.FORM_ORNEK_NO == tTalep.FORM_TIPI.ToString() || item.FORM_ORNEK_NO.Contains(tTalep.FORM_TIPI.ToString()))
                            formYeniTip = item.YENI_FORM_ORNEK_NO;
                    }
                    radioGroup1.Properties.Items.Add(new RadioGroupItem(tTalep, String.Format("{0} {1}", tTalep.FORM_TIPI + " (" + formYeniTip + ")", tTalep.TALEP_ADI), false));
                }
            }
            System.Diagnostics.Debug.WriteLine(string.Format("Alacaklardan Takip Oluþtur Form Loaded {0}", DateTime.Now));
        }

        private void gcAlacaklar_MouseMove(object sender, MouseEventArgs e)
        {
            if (bvAlacaklar.ActiveEditor != null
                && bvAlacaklar.ActiveEditor.IsEditorActive)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("GC Alacaklar Editor Close {0}", DateTime.Now));

                bvAlacaklar.CloseEditor();
            }
        }

        private void gcSozlesme_MouseMove(object sender, MouseEventArgs e)
        {
            if (gvSozlesmeler.ActiveEditor != null
                && gvSozlesmeler.ActiveEditor.IsEditorActive)
            {
                gvSozlesmeler.CloseEditor();
                FormTipleriniAyarla();
            }
        }

        private bool hacizSuz(AV001_TI_BIL_IHTIYATI_HACIZ hcz)
        {
            return !hcz.ICRA_FOY_ID.HasValue;
        }

        private bool IlamKosulu(TI_KOD_TAKIP_TALEP tTalep)
        {
            var ilamlar = gcIlamBilgileri.DataSource as TList<AV001_TI_BIL_ILAM_MAHKEMESI>;

            bool ilamVar = false;
            foreach (var item in ilamlar)
            {
                if (item.IsSelected)
                    ilamVar = true;

                break;
            }

            switch (tTalep.FORM_TIPI)
            {
                case 53:
                case 55:
                case 54:
                case 56:
                    return ilamVar;

                case 151:
                case 201:
                case 49:
                case 50:
                case 163:
                case 152:
                case 51:
                case 52:
                case 153:
                case 48:
                    return !ilamVar;
            }

            //switch (tTalep.ID)
            //{
            //    case 1:
            //    case 15:
            //        return !ilamVar;
            //        //Ýlam Bilgisi Yok ise
            //        break;
            //    case 5:
            //    case 6:
            //    case 7:
            //    case 8:
            //    case 18:

            //        return ilamVar;
            //        //ilam bilgisi var ise
            //        break;
            //    case 17:
            //    case 13:
            //    case 14:
            //    case 16:
            //    case 4:
            //        return true;
            //    default:
            //        break;
            //}

            return false;
        }

        private bool IlamSuz(AV001_TI_BIL_ILAM_MAHKEMESI ýlm)
        {
            return !ýlm.ICRA_FOY_ID.HasValue;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex < 0) return;

            var secilenTalep = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value as per_TI_KOD_TAKIP_TALEP;

            if (secilenTalep == null) return;

            var alacaklar = gcAlacaklar.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN>;
            var sozlesmeler = gcSozlesme.DataSource as TList<AV001_TDI_BIL_SOZLESME>;

            //MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.Filter = string.Format("AN_URETIP_TIP = '{0}'", (int)AN_URETIP_TIP.SenetleTakibeKonuldu);

            MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.ApplyFilter(
                vi => vi.AN_URETIP_TIP != (byte)AN_URETIP_TIP.SenetleTakibeKonuldu);

            switch (secilenTalep.FORM_TIPI)
            {
                #region case

                case 49:
                case 153:

                    #region Alacak Nedeni & Taraflar

                    foreach (var alacak in alacaklar)
                    {
                        alacak.IsSelected = true;

                        //if (alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                        //    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacak, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                        //foreach (var taraf in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        //{
                        //    taraf.IsSelected = true;
                        //}
                    }

                    #endregion Alacak Nedeni & Taraflar

                    #region Sözleþme

                    foreach (var sozlesme in sozlesmeler)
                    {
                        if (sozlesme.TIP_ID == (int)SozlesmeAnaTip.Kredi_Sozlemesi)
                            sozlesme.IsSelected = true;
                        else
                            sozlesme.IsSelected = false;
                    }

                    #endregion Sözleþme

                    break;

                case 163:
                case 52:

                    string[] aNedenKod52 = new[] { "ÇEK", "BONO", "POLÝÇE" }; //çek,senet,poliçe

                    #region Alacaklar & Taraflar

                    foreach (var alacak in alacaklar)
                    {
                        if (alacak.ALACAK_NEDEN_KOD_IDSource == null)
                            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacak, false,
                                                                                      DeepLoadType.IncludeChildren,
                                                                                      typeof(TI_KOD_ALACAK_NEDEN));
                        if (alacak.ALACAK_NEDEN_KOD_IDSource == null)
                            continue;

                        alacak.IsSelected = aNedenKod52.Contains(alacak.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);

                        //foreach (var taraf in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        //{
                        //    taraf.IsSelected = alacak.IsSelected;
                        //}
                    }

                    #endregion Alacaklar & Taraflar

                    #region Sözleþmeler

                    foreach (var sozlesme in sozlesmeler)
                    {
                        sozlesme.IsSelected = false;
                    }

                    #endregion Sözleþmeler

                    break;

                case 151:
                case 152:

                    MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.ApplyFilter();

                    #region Alacak Nedeni & Taraflar

                    foreach (var alacak in alacaklar)
                    {
                        alacak.IsSelected = true;

                        //foreach (var taraf in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        //{
                        //    taraf.IsSelected = true;
                        //}
                    }

                    #endregion Alacak Nedeni & Taraflar

                    #region Sözleþme

                    int?[] sozlesmeTip151 = new int?[] { 5, 6, 8 };

                    foreach (var sozlesme in sozlesmeler)
                    {
                        sozlesme.IsSelected = sozlesmeTip151.Contains(sozlesme.ALT_TIP_ID);
                    }

                    #endregion Sözleþme

                    break;

                case 201:
                case 50:

                    #region Alacak Nedeni & Taraflar

                    MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.ApplyFilter();
                    foreach (var alacak in alacaklar)
                    {
                        alacak.IsSelected = true;

                        //foreach (var taraf in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        //{
                        //    taraf.IsSelected = true;
                        //}
                    }

                    #endregion Alacak Nedeni & Taraflar

                    #region Sözleþmeler

                    int?[] sozlesmeAltTip201 = new int?[] { 5, 6, 7, 176 };

                    foreach (var sozlesme in sozlesmeler)
                    {
                        if (sozlesme.TIP_ID == 3 && !sozlesmeAltTip201.Contains(sozlesme.ALT_TIP_ID))
                            sozlesme.IsSelected = true;
                        else
                            sozlesme.IsSelected = false;
                    }

                    #endregion Sözleþmeler

                    break;

                default:

                    #region Alacaklar & Taraflar

                    foreach (var alacak in alacaklar)
                    {
                        if (alacak.IsSelected)
                            alacak.IsSelected = false;

                        //foreach (var taraf in alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                        //{
                        //    if (taraf.IsSelected)
                        //        taraf.IsSelected = false;
                        //}
                    }

                    #endregion Alacaklar & Taraflar

                    #region Sözleþmeler

                    foreach (var sozlesme in sozlesmeler)
                    {
                        if (sozlesme.IsSelected)
                            sozlesme.IsSelected = false;
                    }

                    #endregion Sözleþmeler

                    break;

                #endregion case
            }
            btnTakipAc.Enabled = true;
            TaraflariAyarla();
        }

        private bool SozlesmeAlacakNedenKontrol(int? alacakNedenId)
        {
            if (!alacakNedenId.HasValue)
                return false;

            List<int?> liste = new List<int?>
                                   {
                                       1,

                                       //ÇEK
                                       33,

                                       //ÇEK
                                       34,

                                       //ÇEK
                                       35,

                                       //ÇEK
                                       129,

                                       //ÇEK
                                       130,

                                       //ÇEK
                                       131,

                                       //ÇEK
                                       132,

                                       //ÇEK
                                       3,

                                       //POLÝÇE
                                       39,

                                       //POLÝÇE
                                       40,

                                       //POLÝÇE
                                       41,

                                       //POLÝÇE
                                       133,

                                       //POLÝÇE
                                       134,

                                       //POLÝÇE
                                       135,

                                       //POLÝÇE
                                       136,

                                       //POLÝÇE
                                       2,

                                       //SENET
                                       36,

                                       //SENET
                                       11,

                                       //SENET
                                       38,

                                       //SENET
                                       137,

                                       //SENET
                                       138,

                                       //SENET
                                       139,

                                       //SENET
                                       140 //SENET
                                   };

            return liste.Contains(alacakNedenId);
        }

        private bool SozlesmeFormTipiKontrol(string formTipi)
        {
            List<string> lite = new List<string> { "ADÝ ALACAK", "KAMBÝYO ALACAÐI" };

            return lite.Contains(formTipi);
        }

        private DialogResult SozlesmeKontrolu()
        {
            DialogResult result = DialogResult.OK;

            ParaVeDovizId alacakToplami = new ParaVeDovizId();
            var mevcutAlacaklar = gcAlacaklar.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN>;
            if (mevcutAlacaklar != null && mevcutAlacaklar.Count > 0)
            {
                var secilenAlacaklar = mevcutAlacaklar.Where(vi => vi.IsSelected);
                if (secilenAlacaklar.Count() > 0)
                {
                    var paralar =
                        secilenAlacaklar.Select(vi => new ParaVeDovizId(vi.TUTARI, vi.TUTAR_DOVIZ_ID)).ToList();

                    alacakToplami = ParaVeDovizId.Topla(paralar);
                }
            }

            var mevcutSozlesmeler = gcSozlesme.DataSource as TList<AV001_TDI_BIL_SOZLESME>;
            if (mevcutSozlesmeler != null && mevcutSozlesmeler.Count > 0)
            {
                var secilenler = mevcutSozlesmeler.Where(vi => vi.IsSelected);

                foreach (AV001_TDI_BIL_SOZLESME sozlesme in secilenler)
                {
                    //Sözleþme taraflarýna kontrollü deepload çekiliyor.
                    if (sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count == 0)
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false,
                                                                               DeepLoadType.IncludeChildren,
                                                                               typeof(
                                                                                   TList<AV001_TDI_BIL_SOZLESME_TARAF>));

                    //Madde 1
                    if (sozlesme.TIP_ID == (int)SozlesmeAnaTip.Resmi_Senet
                        && sozlesme.REHIN_CINS_ANA_TURU == 1) // Anapara ipoteði
                    {
                        //Hiçbir kontrol yapmýyoruz
                        return DialogResult.OK;
                    } //Madde 2

                    if (sozlesme.TIP_ID == (int)SozlesmeAnaTip.Resmi_Senet
                        && sozlesme.REHIN_CINS_ANA_TURU == 0) //Limit Ýpoteði
                    {
                        ParaVeDovizId sozlesmeBedeli = new ParaVeDovizId(sozlesme.BEDELI, sozlesme.BEDELI_DOVIZ_ID);

                        if (sozlesmeBedeli.YtlHali > alacakToplami.YtlHali)
                        {
                            var rehinEdenTaraflar =
                                sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Where(vi => vi.TARAF_SIFAT_ID == 48);

                            //rehin eden

                            foreach (var rehinEden in rehinEdenTaraflar)
                            {
                                var icralar =
                                    MyProje.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Where(
                                        vi => FormTipiKontrol(vi.FORM_TIP_ID));
                                if (icralar.Count() > 0)
                                {
                                    result =
                                        MessageBox.Show(
                                            string.Format(
                                                @"Bu Boçlu ile ilgili limit ipotekli rehin sözleþmesi bulunmaktadýr
ve bu borçlunun rehin limiti alacaðýndan fazladýr
ve borçlu hakkýnda {0} nolu icra takip dosyasý ile
rehinli takip yapýldýðýndan baþka bir takip yapýlamaz",
                                                icralar.First().FOY_NO), "Dikkat", MessageBoxButtons.OKCancel);
                                }
                            }
                        }
                        else if (sozlesmeBedeli.YtlHali < alacakToplami.YtlHali) // 3. madde
                        {
                            result =
                                MessageBox.Show(
                                    string.Format(
                                        @"Bu Boçlu ile ilgili limit ipotekli rehin sözleþmesi bulunmaktadýr
ve bu borçlu ile ilgili seçtiðinz alacaklar
rehin limitinden fazladýr bu borçlu hakkýnda
bu limitle sýnýrlý olarak takip yapabilirsiniz.
kalan alacaðýnýzla ilgili genel haciz yolu yada
iflas yolu ile takip yapabilirsiniz."),
                                    "Dikkat", MessageBoxButtons.OKCancel);
                        }
                    }
                } //Madde 4-5
                if (radioGroup1.SelectedIndex > -1 &&
                    SozlesmeFormTipiKontrol(radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description))
                {
                    var secilenAlacaklar = mevcutAlacaklar.Where(vi => vi.IsSelected);

                    foreach (var item in secilenAlacaklar)
                    {
                        if (SozlesmeAlacakNedenKontrol(item.ALACAK_NEDEN_KOD_ID))
                        {
                            foreach (var kontrolItem in secilenAlacaklar)
                            {
                                if (!SozlesmeAlacakNedenKontrol(kontrolItem.ALACAK_NEDEN_KOD_ID))
                                {
                                    result = DialogResult.OK;
                                }
                            }

                            return
                                MessageBox.Show(
                                    @"Lütfen Oluþturduðunuz Bu Dosyayý
Klasördeki Ana icra Dosyasýna (Alt Dosya)
Olarak iliþkilendiriniz.
Aksi taktirde sistem bu dosyayý da ana dosya olarak kabul",
                                    "Dikkat", MessageBoxButtons.OKCancel);
                        }
                    }
                }

                //Bahattin Çelik ve Kenan Büyük'ün isteði ile kapatýldý. MB
                //                if (!SozlesmeKrediBorclusuKontrolu())
                //                {
                //                    result =
                //                        MessageBox.Show(
                //                            @"Oluþturduðunuz Dosyada Klasör Borçlusu Bulunmuyor
                //bu nedenle bu dosyayý lütfen alt dosya olarak iliþkilendiriniz.
                //Aksi taktirde sistem bu dosyayý da ana dosya olarak kabul
                //edecek ve hesabýnýz etkilenecektir.",
                //                            "Dikkat", MessageBoxButtons.OKCancel);
                //                }

                //7. madde
                {
                    var taraflar = gcTaraflar.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>;

                    if (taraflar != null && taraflar.Count > 0)
                    {
                        var secilenTaraflar = taraflar.Where(vi => vi.IsSelected);
                        if (secilenTaraflar.Count() > 0)
                        {
                            List<int?> tarafSifatlari = new List<int?> { 1, 5, 87, 88, 89, 90 }; //Alacaklýlar

                            var sifatiUyanlar = secilenTaraflar.Where(vi => !tarafSifatlari.Contains(vi.TARAF_SIFAT_ID));

                            if (sifatiUyanlar.Count() > 0)
                            {
                                //carinin Alacak nedenleri üzerindeki sorumluluk alanlarýnýn toplamýna eriþemek için
                                var tumTaraflar = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();

                                #region Tüm Taraflar Toplanýyor

                                foreach (
                                    var item in
                                        MyProje.
                                            AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI
                                    )
                                {
                                    tumTaraflar.AddRange(item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
                                }

                                #endregion Tüm Taraflar Toplanýyor

                                //carinin sözleþme ve teminatlar üzerindeki sorumluluk alanlarýnýn toplamýna eriþemek için
                                var sozlesmeTaraflari = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();

                                #region Sözleme Ve Teminat Taraflarý Toplanýyor

                                foreach (
                                    var item in
                                        MyProje.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TDIE_BIL_PROJE_SOZLESME)
                                {
                                    if (item.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count == 0)
                                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(item, false,
                                                                                               DeepLoadType.
                                                                                                   IncludeChildren,
                                                                                               typeof(
                                                                                                   TList
                                                                                                   <
                                                                                                   AV001_TDI_BIL_SOZLESME_TARAF
                                                                                                   >));

                                    sozlesmeTaraflari.AddRange(item.AV001_TDI_BIL_SOZLESME_TARAFCollection);
                                }

                                foreach (
                                    var item in
                                        MyProje.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TDIE_BIL_PROJE_TEMINAT)
                                {
                                    if (item.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count == 0)
                                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(item, false,
                                                                                               DeepLoadType.
                                                                                                   IncludeChildren,
                                                                                               typeof(
                                                                                                   TList
                                                                                                   <
                                                                                                   AV001_TDI_BIL_SOZLESME_TARAF
                                                                                                   >));

                                    sozlesmeTaraflari.AddRange(item.AV001_TDI_BIL_SOZLESME_TARAFCollection);
                                }

                                #endregion Sözleme Ve Teminat Taraflarý Toplanýyor

                                foreach (var tekTaraf in sifatiUyanlar)
                                {
                                    var alacakTaraflari =
                                        tumTaraflar.Where(vi => vi.TARAF_CARI_ID == tekTaraf.TARAF_CARI_ID);

                                    var paralarAlacakTaraflari =
                                        alacakTaraflari.Select(
                                            vi =>
                                            new ParaVeDovizId(vi.SORUMLU_OLUNAN_MIKTAR,
                                                              vi.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID)).ToList();

                                    ParaVeDovizId sorumluAlacaklarToplami = ParaVeDovizId.Topla(paralarAlacakTaraflari);

                                    if (sozlesmeTaraflari.Count > 0)
                                    {
                                        var tarafinkiler =
                                            sozlesmeTaraflari.Where(vi => vi.CARI_ID == tekTaraf.TARAF_CARI_ID);

                                        if (tarafinkiler.Count() > 0)
                                        {
                                            var paralarSozlesme =
                                                tarafinkiler.Select(
                                                    vi =>
                                                    new ParaVeDovizId((decimal)(vi.SORUMLULUK_MIKTAR ?? 0),
                                                                      vi.SORUMLULUK_MIKTAR_DOVIZ_ID)).ToList();

                                            var sorumlulukSozlesmeToplami = ParaVeDovizId.Topla(paralarSozlesme);

                                            if (sorumluAlacaklarToplami.YtlHali > sorumlulukSozlesmeToplami.YtlHali)
                                            {
                                                result =
                                                    MessageBox.Show(
                                                        string.Format(
                                                            @"{0} isimli Taraf için takipe konan dosyalar bakýmýndan
kefalet limiti aþýlmýþ olup yeni takip baþlatýlmamalýdýr.",
                                                            HesapAraclari.Icra.CariAdiGetirByCariId(
                                                                tekTaraf.TARAF_CARI_ID)), "Dikkat",
                                                        MessageBoxButtons.OKCancel);
                                            }
                                            else if (sorumluAlacaklarToplami.YtlHali < sorumlulukSozlesmeToplami.YtlHali)
                                            {
                                                ParaVeDovizId simdikiSorumluluk =
                                                    new ParaVeDovizId(tekTaraf.SORUMLU_OLUNAN_MIKTAR,
                                                                      tekTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID);

                                                var kalan = ParaVeDovizId.Cikart(sorumlulukSozlesmeToplami,
                                                                                 sorumluAlacaklarToplami);

                                                if (kalan.YtlHali < simdikiSorumluluk.YtlHali)
                                                {
                                                    result =
                                                        MessageBox.Show(
                                                            string.Format(
                                                                @"{0} isimli Taraf Ýle Ýlgili Mevcut sözleþme limitleri içerisinde,
en fazla {1} kadarlýk takip yapabilirsiniz.",
                                                                HesapAraclari.Icra.CariAdiGetirByCariId(
                                                                    tekTaraf.TARAF_CARI_ID), kalan.GetStringValue()),
                                                            "Dikkat", MessageBoxButtons.OKCancel);
                                                }
                                            }

                                            {
                                                var projeBorclusu =
                                                    tumTaraflar.Where(
                                                        vi =>
                                                        HesapAraclari.Icra.CariAdiGetirByCariId(vi.TARAF_CARI_ID) ==
                                                        MyProje.ADI);
                                                if (projeBorclusu.Count() > 0)
                                                {
                                                    var projeBorclusuParalari =
                                                        projeBorclusu.Select(
                                                            vi =>
                                                            new ParaVeDovizId(vi.SORUMLU_OLUNAN_MIKTAR,
                                                                              vi.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID)).ToList
                                                            ();

                                                    var borcluToplami = ParaVeDovizId.Topla(projeBorclusuParalari);
                                                    if (borcluToplami.YtlHali < sorumluAlacaklarToplami.YtlHali)
                                                    {
                                                        result =
                                                            MessageBox.Show(
                                                                string.Format(
                                                                    "{0} isimli taraf için Proje Borçlusunun Sorumluluðu aþýldý",
                                                                    HesapAraclari.Icra.CariAdiGetirByCariId(
                                                                        tekTaraf.TARAF_CARI_ID)), "Dikkat",
                                                                MessageBoxButtons.OKCancel);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        private bool SozlesmeKosulu(TI_KOD_TAKIP_TALEP tTalep)
        {
            var sozlesmeListesi = gcSozlesme.DataSource as TList<AV001_TDI_BIL_SOZLESME>;

            if (sozlesmeListesi.Count > 0)
            {
                var secilenSozlesmeler = sozlesmeListesi.Where(vi => vi.IsSelected && vi.ALT_TIP_ID.HasValue);

                if (secilenSozlesmeler.Count() > 0)
                {
                    foreach (var item in secilenSozlesmeler)
                    {
                        if (item.ALT_TIP_IDSource == null)
                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(item, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(TDI_KOD_SOZLESME_ALT_TIP));

                        if (item.ALT_TIP_IDSource != null
                            && item.ALT_TIP_IDSource.ILGILI_FORM_TIP_IDLERI != null)
                        {
                            List<string> liste = new List<string>();
                            liste.AddRange(item.ALT_TIP_IDSource.ILGILI_FORM_TIP_IDLERI.Split(','));

                            if (liste.Contains(tTalep.FORM_TIPI.ToString()))
                                return true;
                        }
                    }
                }
            }

            #region Eski Yapý

            /*
            foreach (var sozlesme in sozlesmeListesi)
            {
                if (sozlesme.IsSelected)
                {
                    switch (tTalep.ID)
                    {
                        case 5:  //53
                        case 6:  //53
                        case 7:  //53
                        case 8:  //53
                        case 18: //53
                        case 11: //55

                            //Todo : ÝLAM BÝLGÝSÝ VAR ÝSE
                            return false;
                            break;

                        case 1:  //49
                        case 15: //153

                            //Todo : ilam bilgisi seçili deðilse
                            return true;
                            break;

                        case 9:
                        case 10:
                        case 3:  //51
                        case 12: // 56
                            if (sozlesme.TIP_ID != 1) // kira sözleþmesi
                                return false;
                            else
                                return true;
                            break;

                        case 13: //151
                            if ((new List<int?>() {
                                5,6,8
                            }).Contains(sozlesme.ALT_TIP_ID)) //Todo : ilam bilgisi var ise
                            {
                                return true;
                            }
                            else
                                return false;

                            break;

                        case 17: //201
                            if ((new List<int?>() {
                                5,6,8
                            }).Contains(sozlesme.ALT_TIP_ID)) //Todo : ilam bilgisi var ise
                            {
                                return false;
                            }
                            else
                                return true;

                            break;

                        case 14: //152
                            if (!(new List<int?>() {
                                5,6,8
                            }).Contains(sozlesme.ALT_TIP_ID))
                            {
                                return false;
                            }
                            else
                                return true;
                            break;

                        case 2: //50
                            if ((new List<int?>() {
                                5,6,8
                            }).Contains(sozlesme.ALT_TIP_ID))
                            {
                                return false;
                            }
                            else
                                return true;
                            break;

                        case 16: //163
                        case 4: //52
                            return true;

                        default:
                            break;
                    }
                }
            }
             */

            #endregion Eski Yapý

            switch (tTalep.ID)
            {
                case 1:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 18:
                case 11:
                case 15:
                case 16:
                    return true;

                default:
                    break;
            }

            return false;
        }

        private bool sozlesmeSuz(AV001_TDI_BIL_SOZLESME soz)
        {
            return !soz.ICRA_FOY_ID.HasValue;
        }

        private int? TakipTalepIdGetir()
        {
            per_TI_KOD_TAKIP_TALEP tTalep = radioGroup1.EditValue as per_TI_KOD_TAKIP_TALEP;
            if (tTalep != null)
                return tTalep.ID;
            else
                return null;
        }

        private void TaraflariAyarla()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Taraflar Ayarlanýyor  {0}", DateTime.Now));

            TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> taraflar = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            foreach (AV001_TI_BIL_ALACAK_NEDEN an in gcAlacaklar.DataSource as TList<AV001_TI_BIL_ALACAK_NEDEN>)
            {
                if (an.IsSelected)
                {
                    if (an.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(an, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));
                    }
                    taraflar.AddRange(an.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
                }
            }
            foreach (var item in taraflar)
            {
                item.IsSelected = true;
            }
            gcTaraflar.DataSource = taraflar;

            System.Diagnostics.Debug.WriteLine(string.Format("Taraflar Ayarlandý  {0}", DateTime.Now));
        }

        private bool tedbirSuz(AV001_TDI_BIL_IHTIYATI_TEDBIR tdb)
        {
            return !tdb.ICRA_FOY_ID.HasValue && !tdb.DAVA_FOY_ID.HasValue;
        }
    }
}