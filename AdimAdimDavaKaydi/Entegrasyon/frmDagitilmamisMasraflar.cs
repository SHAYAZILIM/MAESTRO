using AdimAdimDavaKaydi.Entegrasyon.ClassesMasrafTahsilat;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmDagitilmamisMasraflar : Form
    {
        public frmDagitilmamisMasraflar()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDagitilmamisMasraflar_Load);
        }

        public AV001_TI_BIL_FOY BagimsizTakip { get; set; }

        public MasrafBilgisi DagitilmamisAktarilanMasraf { get; set; }

        public TList<AKT_DAGITILMAMIS_MASRAF_AVANS> DagitilmamisMasraflar { get; set; }

        public AV001_TDIE_BIL_PROJE Klasor { get; set; }

        //Eşleştirme sırasında masrafın mevcut masrafa mı yollandığı yoksa dosya üzerinde yeni masraf olarak mı oluşturulduğu bilgisini tutuyor. Yeni Kayıt = 1, Mevcut Kayıt = 0;
        public byte MasrafDurum { get; set; }

        public void CreateMasrafAvans(MasrafBilgisi currentMasraf)
        {
            AV001_TDI_BIL_MASRAF_AVANS newMasrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();

            newMasrafAvans.ESLESTI_MI = true;
            newMasrafAvans.REFERANS_NO = string.Format(@"{0}\{1}\{2}", DateTime.Today.Year, DateTime.Today.Month, Guid.NewGuid().ToString().Split('-')[0].ToUpper());
            newMasrafAvans.BORCLU_CARI_ID = DagitilmamisAktarilanMasraf.KrediBorclusuCariID;
            newMasrafAvans.CARI_ID = DagitilmamisAktarilanMasraf.MasrafYapanCariID.Value;
            newMasrafAvans.KAYIT_TARIHI = DagitilmamisAktarilanMasraf.MasrafTarihi;
            newMasrafAvans.MANUEL_KAYIT_MI = true;
            newMasrafAvans.MASRAF_AVANS_TIP = 1;//Masraf
            newMasrafAvans.CARI_HESAP_HEDEF_TIP = 2;//Borç
            if (currentMasraf != null && currentMasraf.IcraFoyID != 0)
                newMasrafAvans.ICRA_FOY_ID = currentMasraf.IcraFoyID;
            if (currentMasraf != null && currentMasraf.DavaFoyID != 0)
                newMasrafAvans.DAVA_FOY_ID = currentMasraf.DavaFoyID;
            if (currentMasraf != null && currentMasraf.SorusturmaID != 0)
                newMasrafAvans.HAZIRLIK_ID = currentMasraf.SorusturmaID;
            newMasrafAvans.AKTARILAN_TOPLAM_TUTAR = DagitilmamisAktarilanMasraf.Tutar;
            newMasrafAvans.AKTARILAN_TOPLAM_TUTAR_DOVIZ_ID = 1;//Masraflar her zaman TL olur.

            //Default Değerler
            newMasrafAvans.KAYIT_TARIHI = DateTime.Now;
            newMasrafAvans.KONTROL_NE_ZAMAN = DateTime.Now;
            newMasrafAvans.KONTROL_KIM = "AVUKATPRO";
            newMasrafAvans.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            newMasrafAvans.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            newMasrafAvans.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            newMasrafAvans.KLASOR_KODU = "GENEL";

            Forms.frmMasrafKayit frmMasraf = new AdimAdimDavaKaydi.Forms.frmMasrafKayit();
            frmMasraf.AktarimMi = true;
            frmMasraf.Masraf = newMasrafAvans;
            if (newMasrafAvans.ICRA_FOY_ID.HasValue && newMasrafAvans.ICRA_FOY_ID.Value != 0)
            {
                var proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByICRA_FOY_IDFromAV001_TDIE_BIL_PROJE_ICRA_FOY(newMasrafAvans.ICRA_FOY_ID.Value);
                if (proje.Count > 0)
                    frmMasraf.Show(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(newMasrafAvans.ICRA_FOY_ID.Value), proje[0]);
                else
                    frmMasraf.Show(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(newMasrafAvans.ICRA_FOY_ID.Value));
            }
            else if (newMasrafAvans.DAVA_FOY_ID.HasValue && newMasrafAvans.DAVA_FOY_ID.Value != 0)
            {
                var proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByDAVA_FOY_IDFromAV001_TDIE_BIL_PROJE_DAVA_FOY(newMasrafAvans.DAVA_FOY_ID.Value);
                if (proje.Count > 0)
                    frmMasraf.Show(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(newMasrafAvans.DAVA_FOY_ID.Value), proje[0]);
                else
                    frmMasraf.Show(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(newMasrafAvans.DAVA_FOY_ID.Value));
            }
            else if (newMasrafAvans.HAZIRLIK_ID.HasValue && newMasrafAvans.HAZIRLIK_ID.Value != 0)
            {
                var proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByHAZIRLIK_IDFromAV001_TDIE_BIL_PROJE_HAZIRLIK(newMasrafAvans.HAZIRLIK_ID.Value);
                if (proje.Count > 0)
                    frmMasraf.Show(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(newMasrafAvans.HAZIRLIK_ID.Value), proje[0]);
                else
                    frmMasraf.Show(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(newMasrafAvans.HAZIRLIK_ID.Value));
            }
            else if (Klasor != null)
            {
                frmMasraf.Show(Klasor);
            }
        }

        private void DragDropForListBox(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.Bitmap) == peMasrafEslestir.Image)
            {
                var focusedIndex = (sender as DevExpress.XtraEditors.ListBoxControl).IndexFromPoint((sender as DevExpress.XtraEditors.ListBoxControl).PointToClient(new Point(e.X, e.Y)));
                var focusedRecord = (sender as DevExpress.XtraEditors.ListBoxControl).GetItem(focusedIndex);

                if (DagitilmamisAktarilanMasraf == null)
                {
                    MessageBox.Show("Dağıtmak isteğiniz masrafın önce üzerine tıklayın ve sürükleyin.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (focusedRecord is MasrafBilgisi)
                {
                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    var currentMasraf = focusedRecord as MasrafBilgisi;

                    if (MasrafDurum == 0)
                    {
                        var masraf = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID(currentMasraf.ID);
                        masraf.REFERANS_NO = DagitilmamisAktarilanMasraf.ReferansNo;
                        masraf.ESLESTI_MI = true;

                        //Masraf tablosuna eklenecek eşleştiğini gösteren alan true yapılacak, kaydedilecek ve dağıtılmamış masraflar tablosundan bu kayıt silinecek.
                        var deletedDagitilmamisMasraf = DagitilmamisMasraflar.Find(vi => vi.ID == DagitilmamisAktarilanMasraf.ID);
                        DagitilmamisMasraflar.Remove(deletedDagitilmamisMasraf);

                        try
                        {
                            tran.BeginTransaction();

                            DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Save(tran, masraf);
                            DataRepository.AKT_DAGITILMAMIS_MASRAF_AVANSProvider.Delete(tran, deletedDagitilmamisMasraf);

                            tran.Commit();

                            //Eşleştirilen masraf dağıtılmamış klasör masraflarından kaldırılır.
                            ((sender as DevExpress.XtraEditors.ListBoxControl).DataSource as List<MasrafBilgisi>).Remove(currentMasraf);
                            MessageBox.Show("Eşleştirme Gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            if (tran.IsOpen) tran.Rollback();
                            BelgeUtil.ErrorHandler.Catch(this, ex);
                        }
                    }
                    else if (MasrafDurum == 1)
                    {
                        CreateMasrafAvans(currentMasraf);
                    }

                    //Eşleştirilen masraflar dağıtılmamış masraflar ve eşleştirildiği masraf bilgisinin olduğu listbox'dan kaldırılıyor.
                    (lbcDagitilmamisMasraflarAktarim.DataSource as List<MasrafBilgisi>).Remove(DagitilmamisAktarilanMasraf);
                }
                else if (focusedRecord == null && MasrafDurum == 1)//Klasör içerisinde ve alt dosyalarında masraf yok ama yeni masraf kaydı yapılma durumu
                {
                    CreateMasrafAvans(null);//Current masraf olmadığından null veriliyor.
                }
            }
        }

        private void DragOverForListBox(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)//Sağ tuş
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        public void GetKlasorMasrafListToListBox(AV001_TDIE_BIL_PROJE klasor)
        {
            #region Get Masraf List

            //Klasör, icra, dava, soruşturma dosyalarındaki EŞLEŞTİRİLMEMİŞ masraflar getirilir.

            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(klasor, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_MASRAF_AVANS>), typeof(TList<AV001_TI_BIL_FOY>), typeof(TList<AV001_TD_BIL_FOY>), typeof(TList<AV001_TD_BIL_HAZIRLIK>));

            List<MasrafBilgisi> list = new List<MasrafBilgisi>();

            klasor.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.ForEach(item =>
            {
                var masrafList = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(item.ICRA_FOY_ID).FindAll(vi => vi.ESLESTI_MI.HasValue ? !vi.ESLESTI_MI.Value : false);
                foreach (var masraf in masrafList)
                {
                    MasrafBilgisi info = new MasrafBilgisi();
                    info.ID = masraf.ID;
                    info.MasrafAciklama = string.Format("{0} referans numaralı {1} tarihli {2} TL tutarlı masraf", masraf.REFERANS_NO, masraf.KAYIT_TARIHI.ToShortDateString(), masraf.AKTARILAN_TOPLAM_TUTAR.Value.ToString());
                    info.Durum = (int)Enums.MasrafinGonderildigiDosya.Icra;
                    info.IcraFoyID = item.ICRA_FOY_ID;

                    list.Add(info);
                }
            });

            klasor.AV001_TDIE_BIL_PROJE_DAVA_FOYCollection.ForEach(item =>
            {
                var masrafList = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByDAVA_FOY_ID(item.DAVA_FOY_ID).FindAll(vi => vi.ESLESTI_MI.HasValue ? !vi.ESLESTI_MI.Value : false);
                foreach (var masraf in masrafList)
                {
                    MasrafBilgisi info = new MasrafBilgisi();
                    info.ID = masraf.ID;
                    info.MasrafAciklama = string.Format("{0} referans numaralı {1} tarihli {2} TL tutarlı masraf", masraf.REFERANS_NO, masraf.KAYIT_TARIHI.ToShortDateString(), masraf.AKTARILAN_TOPLAM_TUTAR.Value.ToString());
                    info.Durum = (int)Enums.MasrafinGonderildigiDosya.Dava;
                    info.DavaFoyID = item.DAVA_FOY_ID;

                    list.Add(info);
                }
            });

            klasor.AV001_TDIE_BIL_PROJE_HAZIRLIKCollection.ForEach(item =>
            {
                var masrafList = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByHAZIRLIK_ID(item.HAZIRLIK_ID).FindAll(vi => vi.ESLESTI_MI.HasValue ? !vi.ESLESTI_MI.Value : false);
                foreach (var masraf in masrafList)
                {
                    MasrafBilgisi info = new MasrafBilgisi();
                    info.ID = masraf.ID;
                    info.MasrafAciklama = string.Format("{0} referans numaralı {1} tarihli {2} TL tutarlı masraf", masraf.REFERANS_NO, masraf.KAYIT_TARIHI.ToShortDateString(), masraf.AKTARILAN_TOPLAM_TUTAR.Value.ToString());
                    info.Durum = (int)Enums.MasrafinGonderildigiDosya.Sorusturma;
                    info.SorusturmaID = item.HAZIRLIK_ID;

                    list.Add(info);
                }
            });

            klasor.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection.ForEach(item =>
            {
                var masraf = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID(item.MASRAF_AVANS_ID);
                if (masraf != null && masraf.ESLESTI_MI.HasValue ? !masraf.ESLESTI_MI.Value : false)
                {
                    MasrafBilgisi info = new MasrafBilgisi();
                    info.ID = masraf.ID;
                    info.MasrafAciklama = string.Format("{0} referans numaralı {1} tarihli {2} TL tutarlı masraf", masraf.REFERANS_NO, masraf.KAYIT_TARIHI.ToShortDateString(), masraf.AKTARILAN_TOPLAM_TUTAR.Value.ToString());
                    info.Durum = (int)Enums.MasrafinGonderildigiDosya.Klasor;
                    info.KlasorID = item.PROJE_ID;

                    list.Add(info);
                }
            });

            lbcDagitilmamisMasraflarKlasor.DataSource = list;
            lbcDagitilmamisMasraflarKlasor.DisplayMember = "MasrafAciklama";
            lbcDagitilmamisMasraflarKlasor.ValueMember = "ID";

            #endregion Get Masraf List
        }

        private void frmDagitilmamisMasraflar_Load(object sender, EventArgs e)
        {
            this.Width = 711;

            BelgeUtil.Inits.ProjeAdGetirYenile(lueKlasor);

            #region Klasör Masrafları list box.

            if (Klasor != null)
            {
                lueKlasor.Visible = false;
                lblKlasor.Visible = false;
                sbtnMasraflariDoldur.Visible = false;

                GetKlasorMasrafListToListBox(Klasor);
            }

            #endregion Klasör Masrafları list box.

            #region Sistemdeki dağıtılmamış masraflar

            List<MasrafBilgisi> dagitilmamisMasrafList = new List<MasrafBilgisi>();

            DagitilmamisMasraflar = DataRepository.AKT_DAGITILMAMIS_MASRAF_AVANSProvider.GetAll();//.Find(string.Format("MASRAF_TARIHI = {0}", DateTime.Now.Date.AddDays(-1))); Aktarım normal akışına geldiğinde günlük aktarım olacağından find kontrolü eklenmiş haline getirilecek.

            foreach (var item in DagitilmamisMasraflar)
            {
                MasrafBilgisi info = new MasrafBilgisi();
                info.ID = item.ID;
                if (item.MASRAF_TARIHI.HasValue)
                    info.MasrafTarihi = item.MASRAF_TARIHI.Value;
                info.ReferansNo = item.MASRAF_REFERANS_NO;
                if (item.TOPLAM_TUTAR.HasValue)
                    info.Tutar = item.TOPLAM_TUTAR.Value;
                if (item.TOPLAM_TUTAR_DOVIZ_ID.HasValue)
                    info.TutarParaBirimi = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(item.TOPLAM_TUTAR_DOVIZ_ID.Value).DOVIZ_KODU;//BelgeUtilden alınacak.
                if (item.KREDI_BORCLUSU_CARI_ID.HasValue)
                {
                    info.KrediBorclusuCariID = item.KREDI_BORCLUSU_CARI_ID.Value;

                    if (BelgeUtil.Inits._per_CariGetir == null)
                        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                    info.KrediBorclusu = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == item.KREDI_BORCLUSU_CARI_ID.Value).AD;
                }
                info.MasrafYapanCariID = item.MASRAF_YAPAN_CARI_ID;

                info.MasrafAciklama = string.Format("Kredi Müşterisi: {3}, {0} referans numaralı {1} tarihli {2} TL tutarlı masraf", info.ReferansNo, info.MasrafTarihi, info.Tutar, info.KrediBorclusu);

                dagitilmamisMasrafList.Add(info);
            }

            lbcDagitilmamisMasraflarAktarim.DataSource = dagitilmamisMasrafList;
            lbcDagitilmamisMasraflarAktarim.DisplayMember = "MasrafAciklama";
            lbcDagitilmamisMasraflarAktarim.ValueMember = "ID";

            #endregion Sistemdeki dağıtılmamış masraflar
        }

        private void lbcDagitilmamisMasraflarAktarim_MouseDown(object sender, MouseEventArgs e)
        {
            peMasrafEslestir.DoDragDrop(peMasrafEslestir.Image, DragDropEffects.All);
            this.DagitilmamisAktarilanMasraf = (sender as DevExpress.XtraEditors.ListBoxControl).SelectedItem as MasrafBilgisi;
        }

        private void lbcDavalar_DragDrop(object sender, DragEventArgs e)
        {
            DragDropForListBox(sender, e);
        }

        private void lbcDavalar_DragOver(object sender, DragEventArgs e)
        {
            DragOverForListBox(sender, e);
        }

        private void lbcKlasor_DragDrop(object sender, DragEventArgs e)
        {
            DragDropForListBox(sender, e);
        }

        private void lbcKlasor_DragOver(object sender, DragEventArgs e)
        {
            DragOverForListBox(sender, e);
        }

        private void lbcSucDuyulari_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void lbcSucDuyulari_DragOver(object sender, DragEventArgs e)
        {
            DragOverForListBox(sender, e);
        }

        private void lbcTakipler_DragDrop(object sender, DragEventArgs e)
        {
            DragDropForListBox(sender, e);
        }

        private void lbcTakipler_DragOver(object sender, DragEventArgs e)
        {
            DragOverForListBox(sender, e);
        }

        private void rgMasrafDurum_EditValueChanged(object sender, EventArgs e)
        {
            if (rgMasrafDurum.EditValue == null) return;

            MasrafDurum = Convert.ToByte(rgMasrafDurum.EditValue);
        }

        private void sbtnAltDosyalariGoster_Click(object sender, EventArgs e)
        {
            sbtnAltDosyalariGoster.Enabled = false;

            this.Width = 1192;

            //groupDagitilmamisMasraflarKlasor.Visible = false;
            //groupSucDuyurulari.Location = new Point(groupDavalar.Location.X, groupDavalar.Location.Y);
            //groupDavalar.Location = new Point(groupTakipler.Location.X, groupTakipler.Location.Y);
            //groupTakipler.Location = new Point(groupDagitilmamisMasraflarKlasor.Location.X, groupDagitilmamisMasraflarKlasor.Location.Y);

            groupTakipler.Visible = groupDavalar.Visible = groupSucDuyurulari.Visible = true;

            List<MasrafBilgisi> list = new List<MasrafBilgisi>();

            if (Klasor != null)
            {
                #region Takip

                if (Klasor.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(Klasor, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY>));

                list.AddRange(MethodsForMasrafTahsilat.GetMasrafAvansList(Klasor.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY));

                #endregion Takip

                #region Dava

                if (Klasor.AV001_TD_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(Klasor, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY>));

                list.AddRange(MethodsForMasrafTahsilat.GetMasrafAvansList(Klasor.AV001_TD_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_DAVA_FOY));

                #endregion Dava

                #region Suç Duyuruları

                if (Klasor.AV001_TD_BIL_HAZIRLIKCollection_From_AV001_TDIE_BIL_PROJE_HAZIRLIK.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(Klasor, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK>));

                list.AddRange(MethodsForMasrafTahsilat.GetMasrafAvansList(Klasor.AV001_TD_BIL_HAZIRLIKCollection_From_AV001_TDIE_BIL_PROJE_HAZIRLIK));

                #endregion Suç Duyuruları
            }
            else if (BagimsizTakip != null)
            {
                #region BagimsizTakip

                list.Add(MethodsForMasrafTahsilat.GetMasrafAvansList(BagimsizTakip));

                #endregion BagimsizTakip

                var kayitIliski = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format("KAYNAK_KAYIT_ID = {0}", BagimsizTakip.ID)).FirstOrDefault();
                if (kayitIliski != null)
                {
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(kayitIliski, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

                    foreach (var detay in kayitIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                    {
                        #region Takip

                        if (detay.HEDEF_ICRA_FOY_ID.HasValue)
                        {
                            var item = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(detay.HEDEF_ICRA_FOY_ID.Value);

                            list.Add(MethodsForMasrafTahsilat.GetMasrafAvansList(item));
                        }

                        #endregion Takip

                        #region Dava

                        if (detay.HEDEF_DAVA_FOY_ID.HasValue)
                        {
                            var item = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(detay.HEDEF_DAVA_FOY_ID.Value);

                            list.Add(MethodsForMasrafTahsilat.GetMasrafAvansList(item));
                        }

                        #endregion Dava

                        #region Suç Duyuruları

                        if (detay.HEDEF_HAZIRLIK_ID.HasValue)
                        {
                            var item = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(detay.HEDEF_HAZIRLIK_ID.Value);

                            list.Add(MethodsForMasrafTahsilat.GetMasrafAvansList(item));
                        }

                        #endregion Suç Duyuruları
                    }
                }
            }
            lbcTakipler.DataSource = list.FindAll(vi => vi.Durum == (int)Enums.MasrafinGonderildigiDosya.Icra);
            lbcTakipler.DisplayMember = "DisplayMember";
            lbcTakipler.ValueMember = "ID";

            lbcDavalar.DataSource = list.FindAll(vi => vi.Durum == (int)Enums.MasrafinGonderildigiDosya.Dava);
            lbcDavalar.DisplayMember = "DisplayMember";
            lbcDavalar.ValueMember = "ID";

            lbcSucDuyurulari.DataSource = list.FindAll(vi => vi.Durum == (int)Enums.MasrafinGonderildigiDosya.Sorusturma);
            lbcSucDuyurulari.DisplayMember = "DisplayMember";
            lbcSucDuyurulari.ValueMember = "ID";
        }

        private void sbtnMasraflariDoldur_Click(object sender, EventArgs e)
        {
            if (lueKlasor.EditValue == null) return;
            Klasor = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID((int)lueKlasor.EditValue);
            GetKlasorMasrafListToListBox(Klasor);
        }
    }
}