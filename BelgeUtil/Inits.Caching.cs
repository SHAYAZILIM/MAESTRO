using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BelgeUtil
{
    public partial class Inits
    {
        public static Dictionary<CacheHelper.CacheType, CacheHelper> _CachedDatas = new Dictionary<CacheHelper.CacheType, CacheHelper>();

        public static TList<TDI_KOD_TEMINAT_TAZMINAT> _TeminatTazminat;

        //
        ///<summary>
        /// TDI_KOD_IS_GOREV_TIP
        /// </summary>
        /// <param name="rlue"></param>
        private static VList<per_TDI_KOD_IS_GOREV_TIP> _GorevTipGetir;

        private static List<AvukatProLib.Arama.per_TD_KOD_KANIT_TIP> _KanitTipGetir;

        private static List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT> _TarafSifatGetirSikayet;

        public static void BelgeTurleriResimliGetir(RepositoryItemImageComboBox combo)
        {
            ImageList lstImg = new ImageList();
            combo.Items.AddRange(GetBelgeTurResimliGetir(lstImg).ToArray());
            combo.SmallImages = lstImg;
            combo.LargeImages = lstImg;
            combo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static void BindeYuzdeGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("BindeYuzde");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.BindeYuzde tipi in Enum.GetValues(typeof(AvukatProLib.Extras.BindeYuzde)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Binde Yüzde"));
        }

        public static void DavaTipleriResimliGetir(RepositoryItemImageComboBox combo)
        {
            DavaTipleriResimliGetir_Enter(combo, EventArgs.Empty);
        }

        public static void DavaTipleriResimliGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemImageComboBox combo = (sender is ImageComboBoxEdit) ? (sender as ImageComboBoxEdit).Properties : sender as RepositoryItemImageComboBox;
            if (combo.Items.Count == 0)
            {
                ImageList lstImg = new ImageList();
                combo.Items.AddRange(GetDavaTipResimliGetir(lstImg).ToArray());
                combo.SmallImages = lstImg;
                combo.LargeImages = lstImg;
                combo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
            }
        }

        public static Image[] GetBelgeImagess()
        {
            List<Image> lstKateGoriImages = new List<Image>();
            Image img = AdimAdimDavaKaydi.Properties.Resources.dilekce40;
            img.Tag = 1;
            return lstKateGoriImages.ToArray();
        }

        public static object GetCachedData(CacheHelper.CacheType type)
        {
            switch (type)
            {
                case CacheHelper.CacheType.CariFull:
                    object o = getDataFromCache(type);
                    if (o != null)
                        return o;
                    else
                    {
                        _CachedDatas.Add(type, new CacheHelper(CacheHelper.CacheDelay, AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetAll()));
                        return getDataFromCache(type);
                    }
                case CacheHelper.CacheType.CariAvukat:
                    return null;

                case CacheHelper.CacheType.CariBilirkisi:
                    object o2 = getDataFromCache(type);
                    if (o2 != null)
                        return o2;
                    else
                    {
                        _CachedDatas.Add(type, new CacheHelper(CacheHelper.CacheDelay, AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Find("BILIRKISI_MI='TRUE'")
                            ));
                        return getDataFromCache(type);
                    }
                default:
                    return null;
            }
        }

        public static void GorevTipGetir(RepositoryItemLookUpEdit rlue)
        {
            if (_GorevTipGetir == null)
            {
                _GorevTipGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_IS_GOREV_TIPProvider.GetAll();
            }
            rlue.DataSource = _GorevTipGetir;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "AD";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("AD", "Görev Tipi", 100));
        }

        public static void GorevTipGetir(LookUpEdit lue)
        {
            GorevTipGetir(lue.Properties);
        }

        public static void ItirazBeyanSekliGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("YetkiKullanmaTipi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.ItirazBeyanSekli tipi in Enum.GetValues(typeof(AvukatProLib.Extras.ItirazBeyanSekli)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ýtiraz Beyan Þekli"));
        }

        public static void IzlensinmiResimler(RepositoryItemImageComboBox rLueIzleResimli)
        {
            ImageList ýmageList1 = GetImageList(1);
            rLueIzleResimli.Items.AddRange(new ImageComboBoxItem[] {
                new ImageComboBoxItem(false, 0),
                new ImageComboBoxItem(true, 1) });
            rLueIzleResimli.SmallImages = ýmageList1;
            rLueIzleResimli.LargeImages = ýmageList1;
            rLueIzleResimli.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static void KanitTipleriResimliGetir(RepositoryItemImageComboBox combo)
        {
            ImageList lstImg = new ImageList();
            combo.Items.AddRange(GetKanitTipResimliGetir(lstImg).ToArray());
            combo.SmallImages = lstImg;
            combo.LargeImages = lstImg;
            combo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static void KilitliResimler(RepositoryItemImageComboBox rLueKilitlimiResimli)
        {
            ImageList imageList1 = GetImageList(3);
            rLueKilitlimiResimli.Items.AddRange(new ImageComboBoxItem[] {
                new ImageComboBoxItem(false, 0),
                new ImageComboBoxItem(true, 1) });
            rLueKilitlimiResimli.SmallImages = imageList1;
            rLueKilitlimiResimli.LargeImages = imageList1;
            rLueKilitlimiResimli.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static void OnemliResimler(RepositoryItemImageComboBox rLueOnemliResimli)
        {
            ImageList imageList1 = GetImageList(2);
            rLueOnemliResimli.Items.AddRange(new ImageComboBoxItem[] {
                new ImageComboBoxItem(false, 0),
                new ImageComboBoxItem(true, 1) });
            rLueOnemliResimli.SmallImages = imageList1;
            rLueOnemliResimli.LargeImages = imageList1;
            rLueOnemliResimli.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static void ParaBicimiAyarla(SpinEdit rud)
        {
            rud.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //rud.Properties.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            rud.Properties.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            rud.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.Properties.EditFormat.FormatString = "###,###,###,###,##0.00";
            // #,##0.00
        }

        public static void SetLookupByEnum(RepositoryItemLookUpEdit rlue, Type enumType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ad", typeof(string));
            dt.Columns.Add("Deger", typeof(int));

            string[] enums = Enum.GetNames(enumType);
            for (int i = 0; i < enums.Length; i++)
            {
                string deger = "";
                if (enums[i].Contains("_"))
                {
                    deger = enums[i].Replace("_", "");
                }
                else
                {
                    deger = enums[i];
                }

                dt.Rows.Add(deger, (int)Enum.Parse(enumType, enums[i]));
            }
            rlue.Columns.Add(new LookUpColumnInfo("Ad"));
            rlue.DataSource = dt;
            rlue.DisplayMember = "Ad";
            rlue.ValueMember = "Deger";
        }

        public static void SorumluTipGetir(LookUpEdit lue)
        {
            DataTable dt = new DataTable("SorumluTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.SorumluTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.SorumluTip)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Sorumlu Tipi"));
        }

        public static void SozlesmeTarafKoduGetir(RepositoryItemLookUpEdit lue)
        {
            TList<AvukatProLib2.Entities.TDI_KOD_TARAF> myList = AvukatProLib2.Data.DataRepository.TDI_KOD_TARAFProvider.GetAll();
            myList.ForEach(delegate(TDI_KOD_TARAF obj)
            {
                if (obj.KOD == "K")
                    obj.IsSelected = true;
                else
                {
                    obj.IsSelected = false;
                }
            }
                );
            lue.DataSource = myList;
            lue.NullText = "Seç";
            lue.DisplayMember = "KOD";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("TIP", 30, "Taraf Kodu"));
        }

        public static void SozlesmeTarafSifatGetir(RepositoryItemLookUpEdit rlue)
        {
            VList<per_TDI_KOD_SOZLESME_TARAF_SIFAT> sifat = AvukatProLib2.Data.DataRepository.per_TDI_KOD_SOZLESME_TARAF_SIFATProvider.GetAll();
            rlue.DataSource = sifat;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "TARAF_SIFAT";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("TARAF_SIFAT", "Taraf Sýfat", 100));
        }

        public static void TakipTalepleriResimliGetir(RepositoryItemImageComboBox combo)
        {
            ImageList lstImg = new ImageList();
            combo.Items.AddRange(GetTakipTalepResimliGetir(lstImg).ToArray());
            combo.SmallImages = lstImg;
            combo.LargeImages = lstImg;
            combo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near;
        }

        public static void TarafSifatGetirSikayetEden(RepositoryItemLookUpEdit rlue)
        {
            if (_TarafSifatGetirSikayet == null)
            {
                _TarafSifatGetirSikayet = context.per_TDIE_KOD_TARAF_SIFATs.Where(item => item.ADLI_BIRIM_BOLUM_ID == 1 || item.ADLI_BIRIM_BOLUM_ID == 8).ToList();
            }
            var secilenler = _TarafSifatGetirSikayet.Where(vi => vi.HANGI_TARAF_NO == 3).ToList();
            rlue.DataSource = secilenler;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "SIFAT";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf Sýfat", 100));
        }

        public static void TarafSifatGetirSikayetEdilen(RepositoryItemLookUpEdit rlue)
        {
            if (_TarafSifatGetirSikayet == null)
            {
                _TarafSifatGetirSikayet = context.per_TDIE_KOD_TARAF_SIFATs.Where(item => item.ADLI_BIRIM_BOLUM_ID == 1 || item.ADLI_BIRIM_BOLUM_ID == 8).ToList();
            }
            var secilenler = _TarafSifatGetirSikayet.Where(vi => vi.HANGI_TARAF_NO == 4 || vi.HANGI_TARAF_NO == 3).ToList();
            rlue.DataSource = secilenler;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "SIFAT";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf Sýfat", 100));
        }

        //}
        public static void TemiznatTazminatKodGetir(RepositoryItemLookUpEdit lue)
        {
            if (_TeminatTazminat == null)
            {
                _TeminatTazminat = DataRepository.TDI_KOD_TEMINAT_TAZMINATProvider.GetAll();
            }
            lue.DataSource = _TeminatTazminat;
            lue.DisplayMember = "TEMINAT_TAZMINAT_ADI";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("TEMINAT_TAZMINAT_ADI", 30, "Teminat Tazminat"));
        }

        public static void YuzdeBicimiAyarla(SpinEdit rud)
        {
            rud.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.Properties.DisplayFormat.FormatString = "\'%\'##0.##";
            rud.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.Properties.EditFormat.FormatString = "\'%\'##0.##";
        }

        /// <summary>
        /// Belge Türlerini iconlarý ile getiriyoruz
        /// </summary>
        /// <returns></returns>
        private static Image[] GetBelgeImages()
        {
            List<Image> lstKateGoriImages = new List<Image>();
            Image img = AdimAdimDavaKaydi.Properties.Resources.dilekce40;
            img.Tag = 1;
            Image img2 = AdimAdimDavaKaydi.Properties.Resources.Ýcra_formu;
            img2.Tag = 2;

            //Image img3 = AdimAdimDavaKaydi.Properties.Resources.ihtarname;
            //img3.Tag = 3;
            Image img4 = AdimAdimDavaKaydi.Properties.Resources.mektup_40;
            img4.Tag = 4;
            Image img5 = AdimAdimDavaKaydi.Properties.Resources.muzekkere;
            img5.Tag = 5;
            Image img6 = AdimAdimDavaKaydi.Properties.Resources.Talep;
            img6.Tag = 6;
            Image img7 = AdimAdimDavaKaydi.Properties.Resources.diger;
            img7.Tag = 7;
            Image img8 = AdimAdimDavaKaydi.Properties.Resources.vekalet;
            img8.Tag = 8;
            Image img9 = AdimAdimDavaKaydi.Properties.Resources.rapor_40;
            img9.Tag = 9;
            Image img10 = AdimAdimDavaKaydi.Properties.Resources.bilifkisi_raposu;
            img10.Tag = 10;
            Image img11 = AdimAdimDavaKaydi.Properties.Resources.kanit;
            img11.Tag = 11;
            Image img12 = AdimAdimDavaKaydi.Properties.Resources.kanit_listesi;
            img12.Tag = 12;
            Image img13 = AdimAdimDavaKaydi.Properties.Resources.mustenidat_dayanak40;
            img13.Tag = 13;
            Image img14 = AdimAdimDavaKaydi.Properties.Resources.durusma_zapti;
            img14.Tag = 14;
            Image img15 = AdimAdimDavaKaydi.Properties.Resources.resim;
            img15.Tag = 18;
            Image img16 = AdimAdimDavaKaydi.Properties.Resources.e_mail;
            img16.Tag = 20;
            lstKateGoriImages.Add(img);
            lstKateGoriImages.Add(img2);

            // lstKateGoriImages.Add(img3);
            lstKateGoriImages.Add(img4);
            lstKateGoriImages.Add(img5);
            lstKateGoriImages.Add(img6);
            lstKateGoriImages.Add(img7);
            lstKateGoriImages.Add(img8);
            lstKateGoriImages.Add(img9);
            lstKateGoriImages.Add(img10);
            lstKateGoriImages.Add(img11);
            lstKateGoriImages.Add(img12);
            lstKateGoriImages.Add(img13);
            lstKateGoriImages.Add(img14);
            lstKateGoriImages.Add(img15);
            lstKateGoriImages.Add(img16);

            return lstKateGoriImages.ToArray();
        }

        private static List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> GetBelgeTurResimliGetir(ImageList lstImg)
        {
            List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> ktg = new List<DevExpress.XtraEditors.Controls.ImageComboBoxItem>();
            Image[] lstKateGoriImages = GetBelgeImages();
            TList<AvukatProLib2.Entities.TDIE_KOD_BELGE_TUR> lstKategori = AvukatProLib2.Data.DataRepository.TDIE_KOD_BELGE_TURProvider.GetAll();
            for (int i = 0; i < lstKategori.Count; i++)
            {
                for (int y = 0; y < lstKateGoriImages.Length; y++)
                {
                    if (((int)lstKateGoriImages[y].Tag) == lstKategori[i].ID)
                    {
                        lstImg.Images.Add(lstKateGoriImages[y]);
                        ktg.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(lstKategori[i].BELGE_TURU, lstKategori[i].ID, i));
                    }
                }
            }
            return ktg;
        }

        private static object getDataFromCache(CacheHelper.CacheType type)
        {
            if (_CachedDatas.ContainsKey(type))
            {
                if (_CachedDatas[type].CacheTime > DateTime.Now)
                {
                    return _CachedDatas[type].CachedObject;
                }
                else
                {
                    _CachedDatas.Remove(type);
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Dava Tiplerini Resimleri ile getiriyoruz
        /// </summary>
        /// <returns></returns>
        private static Image[] GetDavaTipImages()
        {
            List<Image> lstKateGoriImages = new List<Image>();
            Image img = AdimAdimDavaKaydi.Properties.Resources.ceza40;
            img.Tag = 1;
            Image img2 = AdimAdimDavaKaydi.Properties.Resources.hukuk40;
            img2.Tag = 2;
            Image img3 = AdimAdimDavaKaydi.Properties.Resources.icra_ceza40;
            img3.Tag = 13;
            Image img4 = AdimAdimDavaKaydi.Properties.Resources.icra_hukuk40;
            img4.Tag = 23;
            Image img5 = AdimAdimDavaKaydi.Properties.Resources.idare40;
            img5.Tag = 5;
            Image img6 = AdimAdimDavaKaydi.Properties.Resources.Noter40;
            img6.Tag = 9;
            Image img7 = AdimAdimDavaKaydi.Properties.Resources.savcilik_40;
            img7.Tag = 10;
            Image img8 = AdimAdimDavaKaydi.Properties.Resources.vergi_40;
            img8.Tag = 7;
            Image img9 = AdimAdimDavaKaydi.Properties.Resources.asliye_ceza40;
            img9.Tag = 6;
            lstKateGoriImages.Add(img);
            lstKateGoriImages.Add(img2);
            lstKateGoriImages.Add(img3);
            lstKateGoriImages.Add(img4);
            lstKateGoriImages.Add(img5);
            lstKateGoriImages.Add(img6);
            lstKateGoriImages.Add(img7);
            lstKateGoriImages.Add(img8);
            lstKateGoriImages.Add(img9);

            return lstKateGoriImages.ToArray();
        }

        private static List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> GetDavaTipResimliGetir(ImageList lstImg)
        {
            List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> ktg = new List<DevExpress.XtraEditors.Controls.ImageComboBoxItem>();
            Image[] lstKateGoriImages = GetDavaTipImages();
            TList<AvukatProLib2.Entities.TDI_KOD_ADLI_BIRIM_BOLUM> lstKategori = AvukatProLib2.Data.DataRepository.TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetAll();
            int indexInList = 0;
            for (int i = 0; i < lstKategori.Count; i++)
            {
                for (int y = 0; y < lstKateGoriImages.Length; y++)
                {
                    if (((int)lstKateGoriImages[y].Tag) == lstKategori[i].ID)
                    {
                        lstImg.Images.Add(lstKateGoriImages[y]);
                        ktg.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(lstKategori[i].BIRIM, lstKategori[i].ID, indexInList));
                        indexInList++;
                    }
                }
            }
            return ktg;
        }

        /// <summary>
        ///tipe gore resimler
        /// </summary>
        /// <param name="resimTipi">1 : izlensin mi  2 : onelimi 3: kilitli  4: dosya uzantýlarý </param>
        /// <returns></returns>
        private static ImageList GetImageList(int resimTipi)
        {
            ImageList imageList1 = new ImageList();
            imageList1.TransparentColor = System.Drawing.Color.Transparent;

            if (resimTipi == 1)
            {
                imageList1.Images.Add("izle", AdimAdimDavaKaydi.Properties.Resources.Izlensinmi);
                imageList1.Images.Add("izleme", AdimAdimDavaKaydi.Properties.Resources.Izlensinmimesin);
            }
            else if (resimTipi == 2)
            {
                imageList1.Images.Add("onemsiz", AdimAdimDavaKaydi.Properties.Resources.unlemOnemsiz);
                imageList1.Images.Add("onemli", AdimAdimDavaKaydi.Properties.Resources.unlem);
            }
            else if (resimTipi == 3)
            {
                imageList1.Images.Add("kilitsiz", AdimAdimDavaKaydi.Properties.Resources.KilitAcik);
                imageList1.Images.Add("kilitli", AdimAdimDavaKaydi.Properties.Resources.Kilitli);
            }
            else if (resimTipi == 4)
            {
                imageList1.Images.Add("pst", AdimAdimDavaKaydi.Properties.Resources.e_mail);
                imageList1.Images.Add("htm", AdimAdimDavaKaydi.Properties.Resources.EXPLORER);
                imageList1.Images.Add("html", AdimAdimDavaKaydi.Properties.Resources.EXPLORER);
                imageList1.Images.Add("mdb", AdimAdimDavaKaydi.Properties.Resources.Microsoft_Office_Access18x18);
                imageList1.Images.Add("pst", AdimAdimDavaKaydi.Properties.Resources.Microsoft_Office_Outlook18x18);
                imageList1.Images.Add("jpg", AdimAdimDavaKaydi.Properties.Resources.resim);
                imageList1.Images.Add("jpeg", AdimAdimDavaKaydi.Properties.Resources.resim);
                imageList1.Images.Add("gif", AdimAdimDavaKaydi.Properties.Resources.resim);
                imageList1.Images.Add("png", AdimAdimDavaKaydi.Properties.Resources.resim);
                imageList1.Images.Add("ico", AdimAdimDavaKaydi.Properties.Resources.resim);
                imageList1.Images.Add("bmp", AdimAdimDavaKaydi.Properties.Resources.resim);
                imageList1.Images.Add("wma", AdimAdimDavaKaydi.Properties.Resources.ses_dosyasi40);
                imageList1.Images.Add("wax", AdimAdimDavaKaydi.Properties.Resources.ses_dosyasi40);
                imageList1.Images.Add("wma", AdimAdimDavaKaydi.Properties.Resources.ses_dosyasi40);
                imageList1.Images.Add("mp3", AdimAdimDavaKaydi.Properties.Resources.ses_dosyasi40);
                imageList1.Images.Add("mp4", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("wmx", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("wmv", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("asf", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("avi", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("mpeg", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("mpeg4", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("mpg", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("pst", AdimAdimDavaKaydi.Properties.Resources.video);
                imageList1.Images.Add("xml", AdimAdimDavaKaydi.Properties.Resources.XML_kare_22x22);
                imageList1.Images.Add("xst", AdimAdimDavaKaydi.Properties.Resources.XML_kare_22x22);
                imageList1.Images.Add("xaml", AdimAdimDavaKaydi.Properties.Resources.XML_kare_22x22);
                imageList1.Images.Add("dtd", AdimAdimDavaKaydi.Properties.Resources.XML_kare_22x22);
                imageList1.Images.Add("docx", AdimAdimDavaKaydi.Properties.Resources.word07);
                imageList1.Images.Add("xlsx", AdimAdimDavaKaydi.Properties.Resources.Exce07);
                imageList1.Images.Add("xls", AdimAdimDavaKaydi.Properties.Resources.excel03);
                imageList1.Images.Add("doc", AdimAdimDavaKaydi.Properties.Resources.word03);
                imageList1.Images.Add("pdf", AdimAdimDavaKaydi.Properties.Resources.pdf_40x40);
                imageList1.Images.Add("log", AdimAdimDavaKaydi.Properties.Resources.log_icon);
                imageList1.Images.Add("txt", AdimAdimDavaKaydi.Properties.Resources.TXT);
                imageList1.Images.Add("rtf", AdimAdimDavaKaydi.Properties.Resources.rtf);
                imageList1.Images.Add("msg", AdimAdimDavaKaydi.Properties.Resources.Mail2_40X40);
            }
            return imageList1;
        }

        /// <summary>
        /// Kanýt Tipleri Resimli Getiriliyor
        /// </summary>
        /// <returns></returns>
        private static Image[] GetKanitTipImages()
        {
            List<Image> lstKateGoriImages = new List<Image>();
            Image img = AdimAdimDavaKaydi.Properties.Resources.ses_dosyasi40;
            img.Tag = 1;
            Image img2 = AdimAdimDavaKaydi.Properties.Resources.ses_dosyasi40;
            img2.Tag = 2;
            Image img3 = AdimAdimDavaKaydi.Properties.Resources.video;
            img3.Tag = 4;
            Image img4 = AdimAdimDavaKaydi.Properties.Resources.kamera40x40;
            img4.Tag = 7;
            Image img5 = AdimAdimDavaKaydi.Properties.Resources.kambiyo_alacagi;
            img5.Tag = 9;
            Image img6 = AdimAdimDavaKaydi.Properties.Resources.mektup_40;
            img6.Tag = 10;
            Image img7 = AdimAdimDavaKaydi.Properties.Resources.resim;
            img7.Tag = 13;
            Image img8 = AdimAdimDavaKaydi.Properties.Resources.muvekkil_sozlesmesi40x40;
            img8.Tag = 14;
            Image img9 = AdimAdimDavaKaydi.Properties.Resources.personel_isleri;
            img9.Tag = 15;
            Image img10 = AdimAdimDavaKaydi.Properties.Resources.durusma_zapti;
            img10.Tag = 16;
            Image img11 = AdimAdimDavaKaydi.Properties.Resources.ilamlý_alacak40;
            img11.Tag = 17;
            Image img12 = AdimAdimDavaKaydi.Properties.Resources.video;
            img12.Tag = 18;
            Image img13 = AdimAdimDavaKaydi.Properties.Resources.Ýcra_formu;
            img13.Tag = 19;
            Image img14 = AdimAdimDavaKaydi.Properties.Resources.ihtarname1;
            img14.Tag = 21;
            Image img15 = AdimAdimDavaKaydi.Properties.Resources.ilam_40x40;
            img15.Tag = 22;
            Image img16 = AdimAdimDavaKaydi.Properties.Resources.Izlensinmi;
            img16.Tag = 23;
            Image img17 = AdimAdimDavaKaydi.Properties.Resources.ses_dosyasi40;
            img17.Tag = 24;
            Image img18 = AdimAdimDavaKaydi.Properties.Resources.video;
            img18.Tag = 25;
            Image img19 = AdimAdimDavaKaydi.Properties.Resources.diger;
            img19.Tag = 5;
            Image img20 = AdimAdimDavaKaydi.Properties.Resources.Noter40;
            img20.Tag = 11;
            Image img21 = AdimAdimDavaKaydi.Properties.Resources.imza_ekle40x40;
            img21.Tag = 12;
            Image img22 = AdimAdimDavaKaydi.Properties.Resources.mahkeme_40x40;
            img22.Tag = 3;
            Image img23 = AdimAdimDavaKaydi.Properties.Resources.canta40x40;
            img23.Tag = 10001;
            Image img24 = AdimAdimDavaKaydi.Properties.Resources.savcilik_40x40;
            img24.Tag = 10002;
            Image img25 = AdimAdimDavaKaydi.Properties.Resources.fax40;
            img25.Tag = 6;
            Image img26 = AdimAdimDavaKaydi.Properties.Resources.yemin;
            img26.Tag = 20;

            lstKateGoriImages.Add(img);
            lstKateGoriImages.Add(img2);
            lstKateGoriImages.Add(img3);
            lstKateGoriImages.Add(img4);
            lstKateGoriImages.Add(img5);
            lstKateGoriImages.Add(img6);
            lstKateGoriImages.Add(img7);
            lstKateGoriImages.Add(img8);
            lstKateGoriImages.Add(img9);
            lstKateGoriImages.Add(img10);
            lstKateGoriImages.Add(img11);
            lstKateGoriImages.Add(img12);
            lstKateGoriImages.Add(img13);
            lstKateGoriImages.Add(img14);
            lstKateGoriImages.Add(img15);
            lstKateGoriImages.Add(img16);
            lstKateGoriImages.Add(img17);
            lstKateGoriImages.Add(img18);
            lstKateGoriImages.Add(img19);
            lstKateGoriImages.Add(img20);
            lstKateGoriImages.Add(img21);
            lstKateGoriImages.Add(img22);
            lstKateGoriImages.Add(img23);
            lstKateGoriImages.Add(img24);
            lstKateGoriImages.Add(img25);
            lstKateGoriImages.Add(img26);

            return lstKateGoriImages.ToArray();
        }

        private static List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> GetKanitTipResimliGetir(ImageList lstImg)
        {
            List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> ktg = new List<DevExpress.XtraEditors.Controls.ImageComboBoxItem>();
            Image[] lstKateGoriImages = GetKanitTipImages();
            if (_KanitTipGetir == null)
            {
                _KanitTipGetir = context.per_TD_KOD_KANIT_TIPs.ToList();
            }
            int indexInList = 0;
            for (int i = 0; i < _KanitTipGetir.Count; i++)
            {
                for (int y = 0; y < lstKateGoriImages.Length; y++)
                {
                    if (((int)lstKateGoriImages[y].Tag) == _KanitTipGetir[i].ID)
                    {
                        lstImg.Images.Add(lstKateGoriImages[y]);
                        ktg.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(_KanitTipGetir[i].KANIT_TIP, _KanitTipGetir[i].ID, indexInList));
                        indexInList++;
                    }
                }
            }
            return ktg;
        }

        /// <summary>
        /// Takip Konusu Resimleri ile getiriyoruz
        /// </summary>
        /// <returns></returns>
        private static Image[] GetTakipTalepImages()
        {
            List<Image> lstKateGoriImages = new List<Image>();
            Image img = AdimAdimDavaKaydi.Properties.Resources.adi_alacak;
            img.Tag = 1;
            Image img2 = AdimAdimDavaKaydi.Properties.Resources.rehin;
            img2.Tag = 2;
            Image img3 = AdimAdimDavaKaydi.Properties.Resources.adi_alacak;
            img3.Tag = 3;
            Image img4 = AdimAdimDavaKaydi.Properties.Resources.kambiyo_alacagi;
            img4.Tag = 4;
            Image img5 = AdimAdimDavaKaydi.Properties.Resources.nafaka;
            img5.Tag = 5;
            Image img6 = AdimAdimDavaKaydi.Properties.Resources.isci_alacagi;
            img6.Tag = 6;
            Image img7 = AdimAdimDavaKaydi.Properties.Resources.isin_yapilmasi;
            img7.Tag = 7;
            Image img8 = AdimAdimDavaKaydi.Properties.Resources.irtifak;
            img8.Tag = 8;
            Image img9 = AdimAdimDavaKaydi.Properties.Resources.menkul_teslimi;
            img9.Tag = 9;
            Image img10 = AdimAdimDavaKaydi.Properties.Resources.gayrimenkul_teslimi40;
            img10.Tag = 10;
            Image img11 = AdimAdimDavaKaydi.Properties.Resources.nafaka;
            img11.Tag = 11;
            Image img12 = AdimAdimDavaKaydi.Properties.Resources.yazili_sozlesme_ile_tahliye;
            img12.Tag = 12;
            Image img13 = AdimAdimDavaKaydi.Properties.Resources.ipotek;
            img13.Tag = 13;
            Image img14 = AdimAdimDavaKaydi.Properties.Resources.ipotek;
            img14.Tag = 14;
            Image img15 = AdimAdimDavaKaydi.Properties.Resources.adi_alacak;
            img15.Tag = 15;
            Image img16 = AdimAdimDavaKaydi.Properties.Resources.kambiyo_alacagi;
            img16.Tag = 16;
            Image img17 = AdimAdimDavaKaydi.Properties.Resources.rehin;
            img17.Tag = 17;
            Image img18 = AdimAdimDavaKaydi.Properties.Resources.ilamlý_alacak40;
            img18.Tag = 18;
            lstKateGoriImages.Add(img);
            lstKateGoriImages.Add(img2);
            lstKateGoriImages.Add(img3);
            lstKateGoriImages.Add(img4);
            lstKateGoriImages.Add(img5);
            lstKateGoriImages.Add(img6);
            lstKateGoriImages.Add(img7);
            lstKateGoriImages.Add(img8);
            lstKateGoriImages.Add(img9);
            lstKateGoriImages.Add(img10);
            lstKateGoriImages.Add(img11);
            lstKateGoriImages.Add(img12);
            lstKateGoriImages.Add(img13);
            lstKateGoriImages.Add(img14);
            lstKateGoriImages.Add(img15);
            lstKateGoriImages.Add(img16);
            lstKateGoriImages.Add(img17);
            lstKateGoriImages.Add(img18);
            return lstKateGoriImages.ToArray();
        }

        private static List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> GetTakipTalepResimliGetir(ImageList lstImg)
        {
            List<DevExpress.XtraEditors.Controls.ImageComboBoxItem> ktg = new List<DevExpress.XtraEditors.Controls.ImageComboBoxItem>();
            Image[] lstKateGoriImages = GetTakipTalepImages();
            TList<AvukatProLib2.Entities.TI_KOD_TAKIP_TALEP> lstKategori = AvukatProLib2.Data.DataRepository.TI_KOD_TAKIP_TALEPProvider.GetAll();
            int indexInList = 0;
            for (int i = 0; i < lstKategori.Count; i++)
            {
                for (int y = 0; y < lstKateGoriImages.Length; y++)
                {
                    if (((int)lstKateGoriImages[y].Tag) == lstKategori[i].ID)
                    {
                        lstImg.Images.Add(lstKateGoriImages[y]);
                        ktg.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(lstKategori[i].TALEP_ADI, lstKategori[i].ID, indexInList));
                        indexInList++;
                    }
                }
            }
            return ktg;
        }

        //public static void ItirazBeyanSekliGetir(RepositoryItemLookUpEdit lue)
        //{
        //    DataTable dt = new DataTable("YetkiKullanmaTipi");
        //    dt.Columns.Add("ID");
        //    dt.Columns.Add("ACIKLAMA");
        //    foreach (AvukatProLib.Extras.ItirazBeyanSekli tipi in Enum.GetValues(typeof(AvukatProLib.Extras.ItirazBeyanSekli)))
        //    {
        //        dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
        //    }
        //    lue.Properties.DataSource = dt;
        //    lue.Properties.DisplayMember = "ACIKLAMA";
        //    lue.Properties.NullText = "Seç";
        //    lue.Properties.ValueMember = "ID";
        //    lue.Properties.Columns.Clear();
        //    lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ýtiraz Beyan Þekli"));
    }

    #region Events

    public class DavaFoyKaydedildiEventArgs : EventArgs
    {
        public DavaFoyKaydedildiEventArgs(AV001_TD_BIL_FOY mFoy)
        {
            _DavaFoy = mFoy;
        }

        private AV001_TD_BIL_FOY _DavaFoy;

        public AV001_TD_BIL_FOY DavaFoy
        {
            get { return _DavaFoy; }
            set { _DavaFoy = value; }
        }
    }

    public class GayrimenkulKaydedildiEventArgs : EventArgs
    {
        public GayrimenkulKaydedildiEventArgs(TList<AV001_TI_BIL_GAYRIMENKUL> mFoy)
        {
            _gayriFoy = mFoy;
        }

        private TList<AV001_TI_BIL_GAYRIMENKUL> _gayriFoy;

        public TList<AV001_TI_BIL_GAYRIMENKUL> GayriFoy
        {
            get { return _gayriFoy; }
            set { _gayriFoy = value; }
        }
    }

    public class HazirlikSikayetKaydedildiEventArgs : EventArgs
    {
        public HazirlikSikayetKaydedildiEventArgs(AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN mFoy)
        {
            _Foy = mFoy;
        }

        private AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN _Foy;

        public AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN Foy
        {
            get { return _Foy; }
            set { _Foy = value; }
        }
    }

    public class HazirlikSurecKaydedildiEventArgs : EventArgs
    {
        public HazirlikSurecKaydedildiEventArgs(AV001_TD_BIL_HAZIRLIK_SUREC mFoy)
        {
            _Foy = mFoy;
        }

        private AV001_TD_BIL_HAZIRLIK_SUREC _Foy;

        public AV001_TD_BIL_HAZIRLIK_SUREC Foy
        {
            get { return _Foy; }
            set { _Foy = value; }
        }
    }

    public class HukukMuhasebesiEventArgs : EventArgs
    {
        public HukukMuhasebesiEventArgs(AV001_TDI_BIL_MASRAF_AVANS myMasraf)
        {
            _MyMasraf = myMasraf;
        }

        private AV001_TDI_BIL_MASRAF_AVANS _MyMasraf;

        public AV001_TDI_BIL_MASRAF_AVANS MyMasraf
        {
            get { return _MyMasraf; }
            set { _MyMasraf = value; }
        }
    }

    public class IcraFoyKaydedildiEventArgs : EventArgs
    {
        public IcraFoyKaydedildiEventArgs(AV001_TI_BIL_FOY mFoy)
        {
            _IcraFoy = mFoy;
        }

        private AV001_TI_BIL_FOY _IcraFoy;

        public AV001_TI_BIL_FOY IcraFoy
        {
            get { return _IcraFoy; }
            set { _IcraFoy = value; }
        }
    }

    public class IsKayitEventArgs : EventArgs
    {
        public IsKayitEventArgs(AV001_TDI_BIL_IS myIs)
        {
            _MyIs = myIs;
        }

        private AV001_TDI_BIL_IS _MyIs;

        public AV001_TDI_BIL_IS MyIs
        {
            get { return _MyIs; }
            set { _MyIs = value; }
        }
    }

    public class KiymetliEvrakKaydedildiEventArgs : EventArgs
    {
        public KiymetliEvrakKaydedildiEventArgs(TList<AV001_TDI_BIL_KIYMETLI_EVRAK> mFoy)
        {
            _kiymetliFoy = mFoy;
        }

        private TList<AV001_TDI_BIL_KIYMETLI_EVRAK> _kiymetliFoy;

        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> KiymetliFoy
        {
            get { return _kiymetliFoy; }
            set { _kiymetliFoy = value; }
        }
    }

    public class PersonelNeredeKaydedildiEventArgs : EventArgs
    {
        public PersonelNeredeKaydedildiEventArgs(TList<AV001_TDIE_BIL_KIM_NEREDE> personel)
        {
            _personel = personel;
        }

        private TList<AV001_TDIE_BIL_KIM_NEREDE> _personel;

        public TList<AV001_TDIE_BIL_KIM_NEREDE> Personel
        {
            get { return _personel; }
            set { _personel = value; }
        }
    }

    public class SikKullanilanEventArgs : EventArgs
    {
        public SikKullanilanEventArgs(AV001_TDIE_BIL_SIK_KULLANILAN mySikKullanilan)
        {
            _MySikKullanilan = mySikKullanilan;
        }

        private AV001_TDIE_BIL_SIK_KULLANILAN _MySikKullanilan;

        public AV001_TDIE_BIL_SIK_KULLANILAN MySikKullanilan
        {
            get { return _MySikKullanilan; }
            set { _MySikKullanilan = value; }
        }
    }

    public class SorusturmaFoyKaydedildiEventArgs : EventArgs
    {
        public SorusturmaFoyKaydedildiEventArgs(AV001_TD_BIL_HAZIRLIK mFoy)
        {
            _SorusturmaFoy = mFoy;
        }

        private AV001_TD_BIL_HAZIRLIK _SorusturmaFoy;

        public AV001_TD_BIL_HAZIRLIK SorusturmaFoy
        {
            get { return _SorusturmaFoy; }
            set { _SorusturmaFoy = value; }
        }
    }

    public class TebligatKaydedildiEventArgs : EventArgs
    {
        public TebligatKaydedildiEventArgs(AV001_TDI_BIL_TEBLIGAT mFoy)
        {
            _Tebligat = mFoy;
        }

        private AV001_TDI_BIL_TEBLIGAT _Tebligat;

        public AV001_TDI_BIL_TEBLIGAT Tebligat
        {
            get { return _Tebligat; }
            set { _Tebligat = value; }
        }
    }

    #endregion Events
}