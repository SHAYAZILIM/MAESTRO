using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmGunlukDovizKurGirisi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmGunlukDovizKurGirisi()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += new EventHandler(frmGunlukDovizKurGirisi_Load);
        }

        private List<int> idList = null;

        private void InitializeEvents()
        {
            this.Button_Kaydet_Click += new EventHandler<EventArgs>(frmGunlukDovizKurGirisi_Button_Kaydet_Click);
        }

        #region Methods

        private string GetDisplayText(int dovizID)
        {
            string text = string.Empty;

            switch (dovizID)
            {
                case 2:
                    text = "AMERİKAN DOLARI";
                    break;

                case 13:
                    text = "AVRUPA PARASI";
                    break;

                case 8:
                    text = "JAPON YENİ";
                    break;

                case 5:
                    text = "İNGİLİZ STERLİNİ";
                    break;

                case 6:
                    text = "İSVİÇRE FRANGI";
                    break;

                default:
                    break;
            }
            return text;
        }

        private void GunlukDovizGirisi()
        {
            IdListOlustur();

            TList<TDI_CET_GUNLUK_DOVIZ_KUR> money = DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Find(string.Format("TARIH = {0}", DateTime.Now.Date));
            money = money.FindAll(vi => vi.DOVIZ_ID == 2 || vi.DOVIZ_ID == 13 || vi.DOVIZ_ID == 8 || vi.DOVIZ_ID == 5 || vi.DOVIZ_ID == 6);
            money.ForEach(para =>
            {
                if (para.TL_DEGERI != 0)
                {
                    idList.Remove(idList.Find(vi => vi == para.DOVIZ_ID));
                }
            });
            if (idList.Count == 0)
                bndGunlukDovizKur.DataSource = money;
            else
                bndGunlukDovizKur.DataSource = KurOlustur(idList);
        }

        private void IdListOlustur()
        {
            idList = new List<int>();

            idList.Add(2);
            idList.Add(13);
            idList.Add(8);
            idList.Add(5);
            idList.Add(6);
        }

        private bool Kaydet(TList<TDI_CET_GUNLUK_DOVIZ_KUR> kurList)
        {
            TList<TDI_CET_GUNLUK_DOVIZ_KUR> savedKurList = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();
            kurList.ForEach(item =>
                {
                    if (item.TL_DEGERI != 0 && !savedKurList.Contains(item)) savedKurList.Add(item);
                });

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Save(tran, savedKurList);
                tran.Commit();
                AvukatProLib.Hesap.DovizHelper.YeniKurBilgisiGirildi = true;//Yeni kur bilgisi girildiğinde Hesaptaki kurların sıfırlanıp yenilerinin gelmesini sağlamak için eklendi. MB
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uDOVIZ_ID_TARIH"))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Önceden kayıtlı verilere tekrar giriş yapılamaz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if (tran.IsOpen)
                        tran.Rollback();
                    return false;
                }
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return false;
            }
        }

        private TList<TDI_CET_GUNLUK_DOVIZ_KUR> KurOlustur(List<int> idList)
        {
            TList<TDI_CET_GUNLUK_DOVIZ_KUR> dovizKurList = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();

            idList.ForEach(item =>
            {
                TDI_CET_GUNLUK_DOVIZ_KUR dovizKur = new TDI_CET_GUNLUK_DOVIZ_KUR();
                dovizKur.DOVIZ_ID = item;
                dovizKur.TARIH = DateTime.Now.Date;
                dovizKur.KONTROL_KIM = "AVUKATPRO";
                dovizKur.KONTROL_NE_ZAMAN = DateTime.Now;
                dovizKur.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                dovizKur.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                dovizKur.ADMIN_KAYIT_MI = 1; //TCMB
                dovizKur.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                if (!dovizKurList.Contains(dovizKur))
                    dovizKurList.Add(dovizKur);

                TDI_CET_GUNLUK_DOVIZ_KUR dovizKurBanka = new TDI_CET_GUNLUK_DOVIZ_KUR();
                dovizKurBanka.DOVIZ_ID = item;
                dovizKurBanka.TARIH = DateTime.Now.Date;
                dovizKurBanka.KONTROL_KIM = "AVUKATPRO";
                dovizKurBanka.KONTROL_NE_ZAMAN = DateTime.Now;
                dovizKurBanka.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                dovizKurBanka.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                dovizKurBanka.ADMIN_KAYIT_MI = 0; //BANKA
                dovizKurBanka.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                if (!dovizKurList.Contains(dovizKurBanka))
                    dovizKurList.Add(dovizKurBanka);
            });
            return dovizKurList;
        }

        #endregion Methods

        #region Events

        private void frmGunlukDovizKurGirisi_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (xtcKurBilgisi.SelectedTabPage == xtpGunlukKur)
            {
                if (Kaydet(bndGunlukDovizKur.List as TList<TDI_CET_GUNLUK_DOVIZ_KUR>))
                    DevExpress.XtraEditors.XtraMessageBox.Show("Kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Kayıt Yapılamadı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (xtcKurBilgisi.SelectedTabPage == xtpGecmisKurGirisi)
            {
                if (Kaydet(bndGecmisDovizKur.List as TList<TDI_CET_GUNLUK_DOVIZ_KUR>))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Kaydedildi. Bilgileri 'Arşiv' \r\nkısmında görebilirsiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bndGecmisDovizKur.DataSource = new TList<TDI_CET_GUNLUK_DOVIZ_KUR>();
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Kayıt Yapılamadı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmGunlukDovizKurGirisi_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.DovizTipGetir(rlueDovizTip);
            BelgeUtil.Inits.DovizTipGetir(rlueDovizArsiv);
            BelgeUtil.Inits.DovizTipGetir(rlueDovizGecmis);
            BelgeUtil.Inits.KurBilgisiGetir(rlueKurBilgisiArsiv);
            BelgeUtil.Inits.KurBilgisiGetir(rlueKurBilgisi);
            BelgeUtil.Inits.KurBilgisiGetir(rlueKurBilgisiGecmis);

            GunlukDovizGirisi();
        }

        private void gvDovizKur_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "colDOVIZ")
            {
                var row = gvDovizKur.GetRow(e.RowHandle) as TDI_CET_GUNLUK_DOVIZ_KUR;

                switch (row.DOVIZ_ID)
                {
                    case 2:
                        e.DisplayText = "AMERİKAN DOLARI";
                        break;

                    case 13:
                        e.DisplayText = "AVRUPA PARASO";
                        break;

                    case 8:
                        e.DisplayText = "JAPON YENİ";
                        break;

                    case 5:
                        e.DisplayText = "İNGİLİZ STERLİNİ";
                        break;

                    case 6:
                        e.DisplayText = "İSVİÇRE FRANGI";
                        break;

                    default:
                        break;
                }
            }
        }

        private void gvGecmisKur_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "colDOVIZGecmis")
            {
                var row = gvGecmisKur.GetRow(e.RowHandle) as TDI_CET_GUNLUK_DOVIZ_KUR;
                e.DisplayText = GetDisplayText(row.DOVIZ_ID);
            }
        }

        private void xtcKurBilgisi_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "xtpGecmisKurGirisi")
            {
                IdListOlustur();
                bndGecmisDovizKur.DataSource = KurOlustur(idList);
            }
            else if (e.Page.Name == "xtpArsivKur")
            {
                TDI_CET_GUNLUK_DOVIZ_KURQuery guery = new TDI_CET_GUNLUK_DOVIZ_KURQuery();
                guery.AppendIn(TDI_CET_GUNLUK_DOVIZ_KURColumn.DOVIZ_ID, "2,13,5,8,6");
                bndArsiv.DataSource = DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.Find(guery);
            }
        }

        #endregion Events
    }
}