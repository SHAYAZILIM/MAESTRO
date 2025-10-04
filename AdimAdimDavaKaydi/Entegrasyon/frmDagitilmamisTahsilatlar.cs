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
    public partial class frmDagitilmamisTahsilatlar : Form
    {
        //Klasör Show metodu ile çağrıldığında sadece o klasörün bilgileri gelecek. Dışarıdan çağrıldığında sistemdeki tm klasör ve alt dosyaları gelecek.
        public frmDagitilmamisTahsilatlar()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDagitilmamisTahsilatlar_Load);
        }

        public AV001_TI_BIL_FOY BagimsizTakip { get; set; }

        public TahsilatBilgisi DagitilmamisAktarilanTahsilat { get; set; }

        public TList<AKT_DAGITILMAMIS_TAHSILATLAR> DagitilmamisTahsilatlar { get; set; }

        public AV001_TDIE_BIL_PROJE Klasor { get; set; }

        //Eşleştirme sırasında masrafın mevcut tahsilata mı yollandığı yoksa dosya üzerinde yeni tahsilat olarak mı oluşturulduğu bilgisini tutuyor. Yeni Kayıt = 1, Mevcut Kayıt = 0;
        public byte TahsilatDurum { get; set; }

        public void CreateTahsilat(TahsilatBilgisi currentTahsilat)
        {
            AV001_TI_BIL_BORCLU_ODEME newTahsilat = new AV001_TI_BIL_BORCLU_ODEME();

            newTahsilat.ESLESTI_MI = true;
            newTahsilat.ODEYEN_CARI_ID = DagitilmamisAktarilanTahsilat.KrediBorclusuCariID;
            newTahsilat.ODENEN_CARI_ID = 1906;//ING BANK A.Ş.
            newTahsilat.BORCLU_ADINA_ODEYEN_CARI_ID = DagitilmamisAktarilanTahsilat.KrediBorclusuCariID;
            if (currentTahsilat != null && currentTahsilat.IcraFoyID != 0) newTahsilat.ICRA_FOY_ID = currentTahsilat.IcraFoyID;
            newTahsilat.ODEME_TARIHI = DagitilmamisAktarilanTahsilat.TahsilatTarihi;
            newTahsilat.ODEME_MIKTAR = DagitilmamisAktarilanTahsilat.Tutar;
            newTahsilat.ODEME_MIKTAR_DOVIZ_ID = ParametreClass.MappingDovizTip(DagitilmamisAktarilanTahsilat.TutarParaBirimi);

            newTahsilat.ODEME_YER_ID = 1;//Avukata
            newTahsilat.ODEME_KIM_ADINA = 1;//Kendi Adına

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                if (Klasor != null)
                {
                    var klasorTahsilat = newTahsilat.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEMECollection.AddNew();
                    klasorTahsilat.PROJE_ID = Klasor.ID;

                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(tran, newTahsilat, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME>));
                    MessageBox.Show("Aktarılan TAHSİLAT ilgili dosyaya gönderildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.Save(tran, newTahsilat);

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void DragDropForListBox(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.Bitmap) == peTahsilatEslestir.Image)
            {
                var focusedIndex = (sender as DevExpress.XtraEditors.ListBoxControl).IndexFromPoint((sender as DevExpress.XtraEditors.ListBoxControl).PointToClient(new Point(e.X, e.Y)));
                var focusedRecord = (sender as DevExpress.XtraEditors.ListBoxControl).GetItem(focusedIndex);

                if (focusedRecord is TahsilatBilgisi)
                {
                    if (DagitilmamisAktarilanTahsilat == null)
                    {
                        MessageBox.Show("Dağıtmak isteğiniz tahsilatın önce üzerine tıklayın ve sürükleyin.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    var currentTahsilat = focusedRecord as TahsilatBilgisi;

                    if (TahsilatDurum == 0)
                    {
                        var tahsilat = DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByID(currentTahsilat.ID);
                        tahsilat.ESLESTI_MI = true;

                        //Tahsilat tablosuna eklenecek eşleştiğini gösteren alan true yapılacak, kaydedilecek ve dağıtılmamış tahsilatlar tablosundan bu kayıt silinecek.
                        var deletedDagitilmamisTahsilat = DagitilmamisTahsilatlar.Find(vi => vi.ID == DagitilmamisAktarilanTahsilat.ID);
                        DagitilmamisTahsilatlar.Remove(deletedDagitilmamisTahsilat);

                        try
                        {
                            tran.BeginTransaction();

                            DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.Save(tahsilat);
                            DataRepository.AKT_DAGITILMAMIS_TAHSILATLARProvider.Delete(deletedDagitilmamisTahsilat);

                            tran.Commit();

                            //Eşleştirilen tahsilat dağıtılmamış tahsilatlardan kaldırılır.
                            ((sender as DevExpress.XtraEditors.ListBoxControl).DataSource as List<TahsilatBilgisi>).Remove(currentTahsilat);
                            MessageBox.Show("Eşleştirme Gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            if (tran.IsOpen) tran.Rollback();
                            BelgeUtil.ErrorHandler.Catch(this, ex);
                        }
                    }
                    else if (TahsilatDurum == 1)
                    {
                        CreateTahsilat(currentTahsilat);
                    }

                    //Eşleştirilen tahsilat eşleştirildiği tahsilat bilgisinin olduğu listbox'dan kaldırılıyor.
                    (lbcDagitilmamisTahsilatlarAktarim.DataSource as List<TahsilatBilgisi>).Remove(DagitilmamisAktarilanTahsilat);
                }
                else if (focusedRecord == null && TahsilatDurum == 1)//Klasör içerisinde ve alt dosyalarında tahsilat yok ama yeni tahsilat kaydı yapılma durumu
                {
                    CreateTahsilat(null);//Current tahsilat olmadığından null veriliyor.
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

        public void GetKlasorTahsilatListToListBox(AV001_TDIE_BIL_PROJE klasor)
        {
            if (klasor != null)
            {
                #region Get Tahsilat List

                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(klasor, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME>), typeof(TList<AV001_TI_BIL_FOY>), typeof(TList<AV001_TD_BIL_FOY>), typeof(TList<AV001_TD_BIL_HAZIRLIK>));

                //Sistemdeki masraflar
                //Klasöre, tüm tahsilat bilgilerinin gelmesini sağlıyor.

                //Tahsilat tablosunda eşleşme bilgisi false olan kayıtlar burada gösterilecek.

                List<TahsilatBilgisi> tahsilatList = new List<TahsilatBilgisi>();

                klasor.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.ForEach(item =>
                {
                    //Dağıtılmamış tahsilat, yeni oluşturulacak dağıtılmamış tahsilat tablosundan alınancak.

                    var tahsilat = DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByICRA_FOY_ID(item.ICRA_FOY_ID).FirstOrDefault();
                    if (tahsilat != null)
                    {
                        TahsilatBilgisi info = new TahsilatBilgisi();
                        info.ID = tahsilat.ID;
                        info.TahsilatAciklama = string.Format("{0} tarihli {1} TL tutarlı tahsilat", tahsilat.ODEME_TARIHI.ToShortDateString(), tahsilat.ODEME_MIKTAR);
                        info.Durum = (int)Enums.MasrafinGonderildigiDosya.Icra;
                        info.IcraFoyID = item.ICRA_FOY_ID;

                        tahsilatList.Add(info);
                    }
                });

                klasor.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEMECollection.ForEach(item =>
                {
                    var tahsilat = DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByID(item.BORCLU_ODEME_ID);
                    if (tahsilat != null)
                    {
                        TahsilatBilgisi info = new TahsilatBilgisi();
                        info.ID = tahsilat.ID;
                        info.TahsilatAciklama = string.Format("{0} tarihli {1} TL tutarlı tahsilat", tahsilat.ODEME_TARIHI.ToShortDateString(), tahsilat.ODEME_MIKTAR);
                        info.Durum = (int)Enums.MasrafinGonderildigiDosya.Klasor;
                        info.KlasorID = item.PROJE_ID;

                        tahsilatList.Add(info);
                    }
                });

                lbcDagitilmamisTahsilatlarKlasor.DataSource = tahsilatList;
                lbcDagitilmamisTahsilatlarKlasor.DisplayMember = "TahsilatAciklama";
                lbcDagitilmamisTahsilatlarKlasor.ValueMember = "ID";

                #endregion Get Tahsilat List
            }
        }
        
        private void frmDagitilmamisTahsilatlar_Load(object sender, EventArgs e)
        {
            this.Width = 566;

            BelgeUtil.Inits.ProjeAdGetirYenile(lueKlasor);

            #region Klasör Tahsilatları list box.

            if (Klasor != null)
            {
                lueKlasor.Visible = false;
                lblKlasor.Visible = false;
                sbtnTahsilatlariDoldur.Visible = false;

                GetKlasorTahsilatListToListBox(Klasor);
            }

            #endregion Klasör Tahsilatları list box.

            #region Sistemdeki dağıtılmamış tahsilatlar

            List<TahsilatBilgisi> dagitilmamisTahsilatList = new List<TahsilatBilgisi>();

            DagitilmamisTahsilatlar = DataRepository.AKT_DAGITILMAMIS_TAHSILATLARProvider.GetAll();//.Find(string.Format("ODEME_TARIHI = {0}", DateTime.Now.Date.AddDays(-1))); Aktarım normal akışına geldiğinde günlük aktarım olacağından find kontrolü eklenmiş haline getirilecek.
            foreach (var item in DagitilmamisTahsilatlar)
            {
                TahsilatBilgisi info = new TahsilatBilgisi();
                if (item.ODEME_TARIHI.HasValue)
                    info.TahsilatTarihi = item.ODEME_TARIHI.Value;
                if (item.ODEME_MIKTARI.HasValue)
                    info.Tutar = item.ODEME_MIKTARI.Value;
                if (item.ODEME_MIKTARI_DOVIZ_ID.HasValue)
                    info.TutarParaBirimi = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(item.ODEME_MIKTARI_DOVIZ_ID.Value).DOVIZ_KODU;//BelgeUtilden alınacak.
                if (item.KREDI_BORCLUSU_CARI_ID.HasValue)
                {
                    info.KrediBorclusuCariID = item.KREDI_BORCLUSU_CARI_ID.Value;

                    if (BelgeUtil.Inits._per_CariGetir == null)
                        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                    info.KrediBorclusu = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == item.KREDI_BORCLUSU_CARI_ID.Value).AD;
                }

                info.TahsilatAciklama = string.Format("Kredi Müşterisi: {2},{0} tarihli {1} TL tutarlı tahsilat", info.TahsilatTarihi, info.Tutar, info.KrediBorclusu);

                dagitilmamisTahsilatList.Add(info);
            }

            lbcDagitilmamisTahsilatlarAktarim.DataSource = dagitilmamisTahsilatList;
            lbcDagitilmamisTahsilatlarAktarim.DisplayMember = "TahsilatAciklama";
            lbcDagitilmamisTahsilatlarAktarim.ValueMember = "ID";

            #endregion Sistemdeki dağıtılmamış tahsilatlar
        }

        private void lbcDagitilmamisTahsilatlarAktarim_MouseDown(object sender, MouseEventArgs e)
        {
            peTahsilatEslestir.DoDragDrop(peTahsilatEslestir.Image, DragDropEffects.All);
            this.DagitilmamisAktarilanTahsilat = (sender as DevExpress.XtraEditors.ListBoxControl).SelectedItem as TahsilatBilgisi;
        }

        private void lbcDagitilmamisTahsilatlarKlasor_DragDrop(object sender, DragEventArgs e)
        {
            DragDropForListBox(sender, e);
        }

        private void lbcDagitilmamisTahsilatlarKlasor_DragOver(object sender, DragEventArgs e)
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

        private void rgTahsilatDurum_EditValueChanged(object sender, EventArgs e)
        {
            if (rgTahsilatDurum.EditValue == null) return;

            TahsilatDurum = Convert.ToByte(rgTahsilatDurum.EditValue);
        }

        private void sbtnAltDosyalariGoster_Click(object sender, EventArgs e)
        {
            sbtnAltDosyalariGoster.Enabled = false;
            this.Width = 775;

            //lbcTakipler.Location = new Point(lbcDagitilmamisTahsilatlarKlasor.Location.X, lbcDagitilmamisTahsilatlarKlasor.Location.Y);
            //lbcDagitilmamisTahsilatlarKlasor.Visible = false;

            groupTakipler.Visible = true;

            List<TahsilatBilgisi> list = new List<TahsilatBilgisi>();

            if (Klasor != null)
            {
                #region Takip

                if (Klasor.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(Klasor, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY>));

                list.AddRange(MethodsForMasrafTahsilat.GetTahsilatList(Klasor.AV001_TI_BIL_FOYCollection_From_AV001_TDIE_BIL_PROJE_ICRA_FOY));

                #endregion Takip
            }
            else if (BagimsizTakip != null)
            {
                #region BagimsizTakip

                list.Add(MethodsForMasrafTahsilat.GetTahsilatList(BagimsizTakip));

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

                            list.Add(MethodsForMasrafTahsilat.GetTahsilatList(item));
                        }

                        #endregion Takip
                    }
                }
            }
            lbcTakipler.DataSource = list.FindAll(vi => vi.Durum == (int)Enums.MasrafinGonderildigiDosya.Icra);
            lbcTakipler.DisplayMember = "DisplayMember";
            lbcTakipler.ValueMember = "ID";
        }

        private void sbtnTahsilatlariDoldur_Click(object sender, EventArgs e)
        {
            if (lueKlasor.EditValue == null) return;
            Klasor = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID((int)lueKlasor.EditValue);
            GetKlasorTahsilatListToListBox(Klasor);
        }
    }
}