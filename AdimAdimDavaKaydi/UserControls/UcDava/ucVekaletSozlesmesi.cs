using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucVekaletSozlesmesi : AvpXUserControl
    {
        public ucVekaletSozlesmesi()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucVekaletSozlesmesi_Load;
        }

        private AV001_TD_BIL_FOY myDavaFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                myDavaFoy = value;
                if (value != null)
                    MyDataSource = value.VEKALET_SOZLESME_IDSource;
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy { get; set; }

        private AV001_TD_BIL_VEKALET_SOZLESME _MyDataSource;

        [Browsable(false)]
        public AV001_TD_BIL_VEKALET_SOZLESME MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (MyDataSource == null) return;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource == null)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyDavaFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof (AV001_TD_BIL_VEKALET_SOZLESME));
                MyDataSource = MyDavaFoy.VEKALET_SOZLESME_IDSource;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource == null && IsLoaded)
            {
                if (MyDavaFoy.VEKALET_SOZLESME_IDSource == null)
                {
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyDavaFoy, true, DeepLoadType.IncludeChildren,
                                                                     typeof (AV001_TD_BIL_VEKALET_SOZLESME));
                    MyDataSource = MyDavaFoy.VEKALET_SOZLESME_IDSource;
                }
            }
        }

        #region <MB-20100308> LOAD

        private void ucVekaletSozlesmesi_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;

            InitsDoldur();
            BindData();

            SetParameters(true, 85);

            if (MyIcraFoy != null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof (AV001_TI_BIL_VEKALET_SOZLESME));
                if (MyIcraFoy.VEKALET_SOZLESME_IDSource == null)
                    MyIcraFoy.VEKALET_SOZLESME_IDSource = new AV001_TI_BIL_VEKALET_SOZLESME();
                bndVekaletSozlesme.DataSource = MyIcraFoy.VEKALET_SOZLESME_IDSource;
            }
            else if (MyDavaFoy != null)
            {
                //yap�lacak dava Binding 
                //if (MyDavaFoy.VEKALET_SOZLESME_IDSource == null)
                //    MyDavaFoy.VEKALET_SOZLESME_IDSource = new AV001_TD_BIL_VEKALET_SOZLESME();
                //bndVekaletSozlesme.DataSource = MyDavaFoy.VEKALET_SOZLESME_IDSource;
            }
            BindVekaletSozlesmeDetayGrid();
           
        }

        private bool initsFilled;

        private void InitsDoldur()
        {
            if (!initsFilled)
            {
                BelgeUtil.Inits.DovizTipGetir(lueSabitTutarDoviz);
                BelgeUtil.Inits.SozlesmeKategorisiGetir(lueSozlesmeKategori.Properties);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueKategoriID);

                initsFilled = true;
            }
        }

        private void BindVekaletSozlesmeDetayGrid()
        {
            AV001_TI_BIL_VEKALET_SOZLESME sozlesme = bndVekaletSozlesme.Current as AV001_TI_BIL_VEKALET_SOZLESME;

            if (sozlesme != null)
            {
                DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepLoad(sozlesme, false,
                                                                              DeepLoadType.IncludeChildren,
                                                                              typeof (
                                                                                  TList
                                                                                  <AV001_TI_BIL_VEKALET_SOZLESME_DETAY>));

                if (
                    !sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection.Exists(
                        vi => vi.VEKALET_SOZLESME_ID == sozlesme.ID))
                {
                    var detay =
                        sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection.Where(
                            vi => vi.VEKALET_SOZLESME_ID == sozlesme.ID);
                    TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> altKategoriler =
                        DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(17);

                    #region <MB-20100803> Alt Kategorilerin S�ralanmas�

                    TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> sortedAltKategoriler =
                        new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
                    myList.ForEach(item =>
                                       {
                                           TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI tmpItem =
                                               altKategoriler.Find(kat => kat.ALT_KATEGORI == item);
                                           if (tmpItem != null) sortedAltKategoriler.Add(tmpItem);
                                       }
                        );

                    #endregion

                    var kayitlar = sortedAltKategoriler.Select(vi => new AV001_TI_BIL_VEKALET_SOZLESME_DETAY
                                                                         {
                                                                             VEKALET_SOZLESME_ID = sozlesme.ID,
                                                                             MUHASEBE_ALT_TUR_ID = vi.ID,
                                                                             KAYIT_TARIHI = DateTime.Now,
                                                                             KONTROL_NE_ZAMAN = DateTime.Now,
                                                                             KONTROL_KIM = "AVUKATPRO",
                                                                             KONTROL_KIM_ID =
                                                                                 AvukatProLib.Kimlik.Bilgi.ID,
                                                                             KONTROL_VERSIYON =
                                                                                 AvukatProLib.Kimlik.
                                                                                 DefaultKontrolVersiyon,
                                                                             STAMP = AvukatProLib.Kimlik.DefaultStamp,
                                                                             KLASOR_KODU = "GENEL"
                                                                         }).ToList();

                    sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection.Clear();
                    sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection.AddRange(kayitlar);
                    gcSozlesmeDetay.DataSource = sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection;

                    DataRepository.AV001_TI_BIL_VEKALET_SOZLESME_DETAYProvider.Save(
                        sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection);
                }
                else
                    gcSozlesmeDetay.DataSource = sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection;
            }
        }

        #region <MB-2010308> Detay Gridi

        //Detay gridinin headerlar�n�n Vertical g�r�nmesini sa�l�yor.
        private bool vertical;

        private void SetParameters(bool vertical, int h)
        {
            this.vertical = vertical;
            gvSozlesmeDetay.ColumnPanelRowHeight = h;
        }

        private void gvSozlesmeDetay_CustomDrawColumnHeader(object sender,
                                                            DevExpress.XtraGrid.Views.Grid.
                                                                ColumnHeaderCustomDrawEventArgs e)
        {
            Rectangle r = e.Info.CaptionRect;
            e.Info.Caption = "";
            e.Painter.DrawObject(e.Info);
            if (e.Column != null)
            {
                System.Drawing.Drawing2D.GraphicsState state = e.Graphics.Save();
                StringFormat sf = new StringFormat();
                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.FormatFlags |= StringFormatFlags.NoWrap;
                if (vertical)
                    sf.FormatFlags |= StringFormatFlags.DirectionVertical;

                e.Graphics.DrawString(e.Column.GetTextCaption(), e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                                      r, sf);
                e.Graphics.Restore(state);
            }
            e.Handled = true;
        }

        #endregion

        #region <MB-20100803> Alt Kategorilerin S�ras�

        private List<string> myList = new[]
                                          {
                                              "ASIL ALACAK",
                                              "��LEM�� FA�Z",
                                              "BSMV TAK�P �NCES�",
                                              "KKDF TAK�P �NCES�",
                                              "��V TAK�P �NCES�",
                                              "KDV TAK�P �NCES�",
                                              "�HT�YAT� HAC�Z VEKALET �CRET�",
                                              "�HT�YAT� HAC�Z G�DER�",
                                              "�HT�YAT� TEDB�R VEKALET �CRET�",
                                              "�HT�YAT� TEDB�R G�DER�",
                                              "�LAM VEKALET �CRET�",
                                              "�LAM TEBL�� G�DER�",
                                              "�LAM �NKAR TAZM�NATI",
                                              "�LAM G�DER",
                                              "�LAM YARGILAMA G�DER�",
                                              "�LAM BAK�YE KARAR HARCI",
                                              "�EK TAZM�NATI",
                                              "YARGITAY ONAMA HARCI",
                                              "KOM�SYON",
                                              "�ZEL TUTAR 1",
                                              "�ZEL TUTAR 2",
                                              "�ZEL TUTAR 3",
                                              "�ZEL TAZM�NAT",
                                              "PROTESTO G�DER�",
                                              "�HTAR G�DER�",
                                              "DAMGA PULU",
                                              "SONRAK� FA�Z",
                                              "BSMV TAK�P SONRASI",
                                              "KDV TAK�P SONRASI",
                                              "��V TAK�P SONRASI",
                                              "SONRAK� TAZM�NATLAR",
                                              "B�R�KM�� NAFAKALAR",
                                              "TAK�P VEKALET �CRET�",
                                              "TAHL�YE VEKALET �CRET�",
                                              "DAVA VEKALET �CRET�",
                                              "TAHL�YE DAVASI VEKALET �CRET�",
                                              "�CRA �NKAR TAZM�NATI",
                                              "DAVA �NKAR TAZM�NATI",
                                              "TEBL�GAT G�DER�",
                                              "D��ER G�DER",
                                              "DAVA G�DER�",
                                              "TAHS�L HARCI",
                                              "TAHL�YE DAVASI G�DER�",
                                              "KALAN TAHS�L HARCI",
                                              "MENKUL TESL�M HARCI",
                                              "CEZAEV� HARCI",
                                              "TAHL�YE HARCI"
                                          }.ToList();

        #endregion

        #endregion

        //#region <MB-20100309> Hesap ��lemleri

        //private void MuvekkilHesabiVekaletUcretiDegistir(ParaVeDovizId toplamTutar)
        //{
        //    TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        //    try
        //    {
        //        var muvekkilHesap =
        //            DataRepository.AV001_TI_BIL_MUVEKKIL_HESAPProvider.GetByICRA_FOY_ID(MyIcraFoy.ID).FirstOrDefault();

        //        if (muvekkilHesap == null)
        //        {
        //            UserControls.IcraTakipUserControls.TreeMuvekkilHesabi muvekkilHesabi =
        //                new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.TreeMuvekkilHesabi(MyIcraFoy);
        //            muvekkilHesap = muvekkilHesabi.GetMuvekkilHesap(MyIcraFoy);
        //        }

        //        muvekkilHesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplamTutar.Para;
        //        muvekkilHesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplamTutar.DovizId;

        //        trans.BeginTransaction();
        //        DataRepository.AV001_TI_BIL_MUVEKKIL_HESAPProvider.Save(trans, muvekkilHesap);
        //        trans.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans.IsOpen)
        //            trans.Rollback();
        //    }
        //}

        ////Faiz Oran� tipine G�re Foy tablosundaki de�erlerin i�lenmesi ve Toplam Vekalet S�zle�mesi de�erinin bulunmas�.
        //private ParaVeDovizId FaizOranlariHesapla(AV001_TI_BIL_FOY foy)
        //{
        //    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
        //                                                     typeof (TList<AV001_TI_BIL_HACIZ_MASTER>),
        //                                                     typeof (TList<AV001_TI_BIL_SATIS_MASTER>),
        //                                                     typeof (TList<AV001_TI_BIL_DUSME_YENILEME>));

        //    AV001_TI_BIL_VEKALET_SOZLESME vekaletSozlesme = bndVekaletSozlesme.Current as AV001_TI_BIL_VEKALET_SOZLESME;

        //    DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepLoad(vekaletSozlesme, false,
        //                                                                  DeepLoadType.IncludeChildren,
        //                                                                  typeof (
        //                                                                      TList<AV001_TI_BIL_VEKALET_SOZLESME_DETAY>
        //                                                                      ));

        //    if (foy.ACIZ_TARIHI.HasValue)
        //    {
        //        //Aciz

        //        List<ParaVeDovizId> acizListe = new List<ParaVeDovizId>();

        //        foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //        {
        //            ParaVeDovizId foyAcizDegeri = KategoriDegeri(item, MyIcraFoy);
        //            double acizOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //            decimal acizTutari = foyAcizDegeri.Para*(decimal) acizOrani/100;
        //            ParaVeDovizId sonuc = new ParaVeDovizId(acizTutari, foyAcizDegeri.DovizId);

        //            if (acizTutari != 0 && sonuc.Para != 0)
        //                acizListe.Add(sonuc);
        //        }

        //        var toplam = ParaVeDovizId.Topla(acizListe);

        //        MuvekkilHesabiVekaletUcretiDegistir(toplam);

        //        return toplam;
        //    }
        //    else if (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Count > 0)
        //    {
        //        if (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI.HasValue &&
        //            foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI.HasValue)
        //        {
        //            if (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI <
        //                foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI ||
        //                (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI.HasValue &&
        //                 !foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI.HasValue))
        //            {
        //                //D��me

        //                List<ParaVeDovizId> dusmeListe = new List<ParaVeDovizId>();

        //                foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //                {
        //                    ParaVeDovizId foyDusmeDegeri = KategoriDegeri(item, MyIcraFoy);
        //                    double dusmeOrani =
        //                        SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //                    decimal dusmeTutari = foyDusmeDegeri.Para*(decimal) dusmeOrani/100;
        //                    ParaVeDovizId sonuc = new ParaVeDovizId(dusmeTutari, foyDusmeDegeri.DovizId);

        //                    if (dusmeTutari != 0 && sonuc.Para != 0)
        //                        dusmeListe.Add(sonuc);
        //                }

        //                var toplam = ParaVeDovizId.Topla(dusmeListe);

        //                MuvekkilHesabiVekaletUcretiDegistir(toplam);

        //                return toplam;
        //            }
        //        }
        //    }
        //    else if (foy.FOY_FERAGAT_TARIHI.HasValue)
        //    {
        //        //Feragat

        //        List<ParaVeDovizId> feragatListe = new List<ParaVeDovizId>();

        //        foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //        {
        //            ParaVeDovizId foyFeragatDegeri = KategoriDegeri(item, MyIcraFoy);
        //            double feragatOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //            decimal feragatTutari = foyFeragatDegeri.Para*(decimal) feragatOrani/100;
        //            ParaVeDovizId sonuc = new ParaVeDovizId(feragatTutari, foyFeragatDegeri.DovizId);

        //            if (feragatTutari != 0 && sonuc.Para != 0)
        //                feragatListe.Add(sonuc);
        //        }

        //        var toplam = ParaVeDovizId.Topla(feragatListe);

        //        MuvekkilHesabiVekaletUcretiDegistir(toplam);

        //        return toplam;
        //    }
        //    else if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count != 0 ||
        //             foy.AV001_TI_BIL_HACIZ_MASTERCollection != null)
        //    {
        //        if (foy.AV001_TI_BIL_SATIS_MASTERCollection != null &&
        //            foy.AV001_TI_BIL_SATIS_MASTERCollection.Count > 0)
        //        {
        //            //Sat�� Sonras� �nfaz

        //            List<ParaVeDovizId> satisSonraiInfazListe = new List<ParaVeDovizId>();

        //            foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //            {
        //                ParaVeDovizId foySatisSonrasiInfazDegeri = KategoriDegeri(item, MyIcraFoy);
        //                double satisSonrasiFaizOrani =
        //                    SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //                decimal satisSonrasiFaizTutari = foySatisSonrasiInfazDegeri.Para*
        //                                                 (decimal) satisSonrasiFaizOrani/100;
        //                ParaVeDovizId sonuc = new ParaVeDovizId(satisSonrasiFaizTutari,
        //                                                        foySatisSonrasiInfazDegeri.DovizId);

        //                if (satisSonrasiFaizTutari != 0 && sonuc.Para != 0)
        //                    satisSonraiInfazListe.Add(sonuc);
        //            }

        //            var toplam = ParaVeDovizId.Topla(satisSonraiInfazListe);

        //            MuvekkilHesabiVekaletUcretiDegistir(toplam);

        //            return toplam;
        //        }
        //        else
        //        {
        //            //Sat�� �ncesi �nfaz

        //            List<ParaVeDovizId> satisOncesiInfazListe = new List<ParaVeDovizId>();

        //            foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //            {
        //                ParaVeDovizId foySatisOncesiInfazDegeri = KategoriDegeri(item, MyIcraFoy);
        //                double acizOrani =
        //                    SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //                decimal foySatisOncesiTutari = foySatisOncesiInfazDegeri.Para*(decimal) acizOrani/100;
        //                ParaVeDovizId sonuc = new ParaVeDovizId(foySatisOncesiTutari,
        //                                                        foySatisOncesiInfazDegeri.DovizId);

        //                if (foySatisOncesiTutari != 0 && sonuc.Para != 0)
        //                    satisOncesiInfazListe.Add(sonuc);
        //            }

        //            var toplam = ParaVeDovizId.Topla(satisOncesiInfazListe);

        //            MuvekkilHesabiVekaletUcretiDegistir(toplam);

        //            return toplam;
        //        }
        //    }
        //    else if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count == 0 ||
        //             foy.AV001_TI_BIL_HACIZ_MASTERCollection == null)
        //    {
        //        //Haciz �ncesi �nfaz

        //        List<ParaVeDovizId> hacizOncesiInfazListe = new List<ParaVeDovizId>();

        //        foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //        {
        //            ParaVeDovizId foyHacizOncesiInfazDegeri = KategoriDegeri(item, MyIcraFoy);
        //            double hacizOncesiInfazOrani =
        //                SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //            decimal hacizOncesiInfazTutari = foyHacizOncesiInfazDegeri.Para*
        //                                             (decimal) hacizOncesiInfazOrani/100;
        //            ParaVeDovizId sonuc = new ParaVeDovizId(hacizOncesiInfazTutari,
        //                                                    foyHacizOncesiInfazDegeri.DovizId);

        //            if (hacizOncesiInfazTutari != 0 && sonuc.Para != 0)
        //                hacizOncesiInfazListe.Add(sonuc);
        //        }

        //        var toplam = ParaVeDovizId.Topla(hacizOncesiInfazListe);

        //        MuvekkilHesabiVekaletUcretiDegistir(toplam);

        //        return toplam;
        //    }
        //    return new ParaVeDovizId();
        //}

        ////Se�ili Kategorinin Foy tablosundaki de�eri
        //private ParaVeDovizId KategoriDegeri(AV001_TI_BIL_VEKALET_SOZLESME_DETAY detay, AV001_TI_BIL_FOY foy)
        //{
        //    ParaVeDovizId tutar = new ParaVeDovizId();

        //    if (!detay.MUHASEBE_ALT_TUR_ID.HasValue) return tutar;

        //    switch (detay.MUHASEBE_ALT_TUR_ID)
        //    {
        //        case (int) TakipAlacaklariAltKategoriler.ASIL_ALACAK:
        //            tutar.Para = foy.ASIL_ALACAK;
        //            tutar.DovizId = foy.ASIL_ALACAK_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.��LEM��_FA�Z:
        //            tutar.Para = foy.ISLEMIS_FAIZ;
        //            tutar.DovizId = foy.ISLEMIS_FAIZ_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.BSMV_TAK�P_�NCES�:
        //            tutar.Para = foy.BSMV_TO;
        //            tutar.DovizId = foy.BSMV_TO_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.KKDF_TAK�P_�NCES�:
        //            tutar.Para = foy.KKDV_TO;
        //            tutar.DovizId = foy.KKDV_TO_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.��V_TAK�P_�NCES�:
        //            tutar.Para = foy.OIV_TO;
        //            tutar.DovizId = foy.OIV_TO_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.KDV_TAK�P_�NCES�:
        //            tutar.Para = foy.KDV_TO;
        //            tutar.DovizId = foy.KDV_TO_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�HT�YAT�_HAC�Z_VEKALET_�CRET�:
        //            tutar.Para = foy.IH_VEKALET_UCRETI;
        //            tutar.DovizId = foy.IH_VEKALET_UCRETI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�HT�YAT�_HAC�Z_G�DER�:
        //            tutar.Para = foy.IH_GIDERI;
        //            tutar.DovizId = foy.IH_GIDERI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�HT�YAT�_TEDB�R_VEKALET_�CRET�:
        //            tutar.Para = foy.IT_VEKALET_UCRETI;
        //            tutar.DovizId = foy.IT_VEKALET_UCRETI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�HT�YAT�_TEDB�R_G�DER�:
        //            tutar.Para = foy.IT_GIDERI;
        //            tutar.DovizId = foy.IT_GIDERI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�LAM_VEKALET_�CRET�:
        //            tutar.Para = foy.ILAM_VEK_UCR;
        //            tutar.DovizId = foy.ILAM_VEK_UCR_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�LAM_TEBL��_G�DER�:
        //            tutar.Para = foy.ILAM_TEBLIG_GIDERI;
        //            tutar.DovizId = foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�LAM_�NKAR_TAZM�NATI:
        //            tutar.Para = foy.ILAM_INKAR_TAZMINATI;
        //            tutar.DovizId = foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�LAM_G�DER:
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�LAM_YARGILAMA_G�DER�:
        //            tutar.Para = foy.ILAM_YARGILAMA_GIDERI;
        //            tutar.DovizId = foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�LAM_BAK�YE_KARAR_HARCI:
        //            tutar.Para = foy.ILAM_BK_YARG_ONAMA;
        //            tutar.DovizId = foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�EK_TAZM�NATI:
        //            tutar.Para = foy.KARSILIKSIZ_CEK_TAZMINATI;
        //            tutar.DovizId = foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.YARGITAY_ONAMA_HARCI:
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.KOM�SYON:
        //            tutar.Para = foy.CEK_KOMISYONU;
        //            tutar.DovizId = foy.CEK_KOMISYONU_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�ZEL_TUTAR_1:
        //            tutar.Para = foy.OZEL_TUTAR1;
        //            tutar.DovizId = foy.OZEL_TUTAR1_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�ZEL_TUTAR_2:
        //            tutar.Para = foy.OZEL_TUTAR2;
        //            tutar.DovizId = foy.OZEL_TUTAR2_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�ZEL_TUTAR_3:
        //            tutar.Para = foy.OZEL_TUTAR3;
        //            tutar.DovizId = foy.OZEL_TUTAR3_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�ZEL_TAZM�NAT:
        //            tutar.Para = foy.OZEL_TAZMINAT;
        //            tutar.DovizId = foy.OZEL_TAZMINAT_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.PROTESTO_G�DER�:
        //            tutar.Para = foy.PROTESTO_GIDERI;
        //            tutar.DovizId = foy.PROTESTO_GIDERI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�HTAR_G�DER�:
        //            tutar.Para = foy.IHTAR_GIDERI;
        //            tutar.DovizId = foy.IHTAR_GIDERI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.DAMGA_PULU:
        //            tutar.Para = foy.DAMGA_PULU;
        //            tutar.DovizId = foy.DAMGA_PULU_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.SONRAK�_FA�Z:
        //            tutar.Para = foy.SONRAKI_FAIZ;
        //            tutar.DovizId = foy.SONRAKI_FAIZ_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.BSMV_TAK�P_SONRASI:
        //            tutar.Para = foy.BSMV_TS;
        //            tutar.DovizId = foy.BSMV_TS_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.KDV_TAK�P_SONRASI:
        //            tutar.Para = foy.KDV_TS;
        //            tutar.DovizId = foy.KDV_TS_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.��V_TAK�P_SONRASI:
        //            tutar.Para = foy.OIV_TS;
        //            tutar.DovizId = foy.OIV_TS_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.SONRAK�_TAZM�NATLAR:
        //            tutar.Para = foy.SONRAKI_TAZMINAT;
        //            tutar.DovizId = foy.SONRAKI_TAZMINAT_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.B�R�KM��_NAFAKALAR:
        //            tutar.Para = foy.BIRIKMIS_NAFAKA;
        //            tutar.DovizId = foy.BIRIKMIS_NAFAKA_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.TAK�P_VEKALET_�CRET�:
        //            tutar.Para = foy.TAKIP_VEKALET_UCRETI;
        //            tutar.DovizId = foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.TAHL�YE_VEKALET_�CRETI:
        //            tutar.Para = foy.TAHLIYE_VEK_UCR;
        //            tutar.DovizId = foy.TAHLIYE_VEK_UCR_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.DAVA_VEKALET_�CRET�:
        //            tutar.Para = foy.DAVA_VEKALET_UCRETI;
        //            tutar.DovizId = foy.DAVA_VEKALET_UCRETI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.TAHL�YE_DAVASI_VEKALET_�CRET�:
        //            tutar.Para = foy.TD_VEK_UCR;
        //            tutar.DovizId = foy.TD_VEK_UCR_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.�CRA_�NKAR_TAZM�NATI:
        //            tutar.Para = foy.ICRA_INKAR_TAZMINATI;
        //            tutar.DovizId = foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.DAVA_�NKAR_TAZM�NATI:
        //            tutar.Para = foy.DAVA_INKAR_TAZMINATI;
        //            tutar.DovizId = foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.TEBL�GAT_G�DER�:
        //            tutar.Para = foy.ILK_TEBLIGAT_GIDERI;
        //            tutar.DovizId = foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.D��ER_G�DER:
        //            tutar.Para = foy.DIGER_GIDERLER;
        //            tutar.DovizId = foy.DIGER_GIDERLER_DOVIZ_ID.Value;
        //            break;
        //            //case (int)TakipAlacaklariAltKategoriler.DAVA_G�DER�:
        //            //    tutar.Para = foy.DAVA_GIDERLERI;
        //            //    tutar.DovizId = foy.DAVA_GIDERLERI_DOVIZ_ID.Value;
        //            //    break;
        //            //case (int)TakipAlacaklariAltKategoriler.TAHS�L_HARCI:
        //            //    tutar.Para = foy.ODENEN_TAHSIL_HARCI;
        //            //    tutar.DovizId = foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID.Value;
        //            //    break;
        //        case (int) TakipAlacaklariAltKategoriler.TAHL�YE_DAVASI_G�DER�:
        //            tutar.Para = foy.TD_GIDERI;
        //            tutar.DovizId = foy.TD_GIDERI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.KALAN_TAHS�L_HARCI:
        //            tutar.Para = foy.KALAN_TAHSIL_HARCI;
        //            tutar.DovizId = foy.KALAN_TAHSIL_HARCI_DOVIZ_ID.Value;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.MENKUL_TESL�M_HARCI:
        //            tutar.Para = foy.TESLIM_HARCI;
        //            tutar.DovizId = foy.TESLIM_HARCI_DOVIZ_ID;
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.CEZAEV�_HARCI:
        //            break;
        //        case (int) TakipAlacaklariAltKategoriler.TAHL�YE_HARCI:
        //            tutar.Para = foy.TAHLIYE_HARCI;
        //            tutar.DovizId = foy.TAHLIYE_HARCI_DOVIZ_ID;
        //            break;
        //        default:
        //            break;
        //    }
        //    return tutar;
        //}

        ////Vekalet S�zle�me Detaydaki se�ili Kategori
        //private AV001_TI_BIL_VEKALET_SOZLESME_DETAY SeciliDetayKategorisi(int sozlesmeID, int? kategoriID)
        //{
        //    AV001_TI_BIL_VEKALET_SOZLESME_DETAY detay =
        //        DataRepository.AV001_TI_BIL_VEKALET_SOZLESME_DETAYProvider.GetByVEKALET_SOZLESME_ID(sozlesmeID).Where(
        //            vi => vi.MUHASEBE_ALT_TUR_ID == kategoriID.Value).FirstOrDefault();

        //    return detay;
        //}

        //#endregion

        #region <MB-20100308> Kay�t ��lemi

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                var vekaletSozlesme = bndVekaletSozlesme.Current as AV001_TI_BIL_VEKALET_SOZLESME;

                vekaletSozlesme.FAIZ_BASLANGIC_TARIHI = DateTime.Now;
                vekaletSozlesme.SOZLESME_TARIHI = DateTime.Now;
                vekaletSozlesme.KAYIT_TARIHI = DateTime.Now;
                vekaletSozlesme.KONTROL_NE_ZAMAN = DateTime.Now;
                vekaletSozlesme.KONTROL_KIM = "AVUKATPRO";
                vekaletSozlesme.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                vekaletSozlesme.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                vekaletSozlesme.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                vekaletSozlesme.KLASOR_KODU = "GENEL";

                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepSave(tran, vekaletSozlesme,
                                                                              DeepSaveType.IncludeChildren,
                                                                              typeof (
                                                                                  TList
                                                                                  <AV001_TI_BIL_VEKALET_SOZLESME_DETAY>));
                DataRepository.AV001_TI_BIL_FOYProvider.Save(tran, MyIcraFoy);

                tran.Commit();

                //Hesap
                //FaizOranlariHesapla(MyIcraFoy);

                XtraMessageBox.Show("Kay�t i�lemi ba�ar� ile ger�ekle�tirildi.", "B�LG�", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        #endregion

        #region <MB-20100309> Takip Alacaklar� Enum

        public enum TakipAlacaklariAltKategoriler
        {
            ASIL_ALACAK = 507,
            ��LEM��_FA�Z = 537,
            BSMV_TAK�P_�NCES� = 865,
            KKDF_TAK�P_�NCES� = 866,
            ��V_TAK�P_�NCES� = 867,
            KDV_TAK�P_�NCES� = 868,
            �HT�YAT�_HAC�Z_VEKALET_�CRET� = 549,
            �HT�YAT�_HAC�Z_G�DER� = 854,
            �HT�YAT�_TEDB�R_VEKALET_�CRET�,
            �HT�YAT�_TEDB�R_G�DER�,
            �LAM_VEKALET_�CRET� = 553,
            �LAM_TEBL��_G�DER� = 864,
            �LAM_�NKAR_TAZM�NATI = 536,
            �LAM_G�DER = 534,
            �LAM_YARGILAMA_G�DER� = 863,
            �LAM_BAK�YE_KARAR_HARCI = 862,
            �EK_TAZM�NATI = 530,
            YARGITAY_ONAMA_HARCI = 547,
            KOM�SYON = 538,
            �ZEL_TUTAR_1 = 540,
            �ZEL_TUTAR_2 = 541,
            �ZEL_TUTAR_3 = 542,
            �ZEL_TAZM�NAT = 539,
            PROTESTO_G�DER� = 543,
            �HTAR_G�DER� = 533,
            DAMGA_PULU = 853,
            SONRAK�_FA�Z = 544,
            BSMV_TAK�P_SONRASI = 869,
            KDV_TAK�P_SONRASI = 871,
            ��V_TAK�P_SONRASI = 870,
            SONRAK�_TAZM�NATLAR = 545,
            B�R�KM��_NAFAKALAR = 529,
            TAK�P_VEKALET_�CRET� = 548,
            TAHL�YE_VEKALET_�CRETI = 550,
            DAVA_VEKALET_�CRET� = 551,
            TAHL�YE_DAVASI_VEKALET_�CRET� = 552,
            �CRA_�NKAR_TAZM�NATI = 532,
            DAVA_�NKAR_TAZM�NATI = 531,
            TEBL�GAT_G�DER� = 546,
            D��ER_G�DER = 857,
            DAVA_G�DER� = 856,
            TAHS�L_HARCI = 855,
            TAHL�YE_DAVASI_G�DER� = 858,
            KALAN_TAHS�L_HARCI = 872,
            MENKUL_TESL�M_HARCI = 860,
            CEZAEV�_HARCI = 859,
            TAHL�YE_HARCI = 861
        }

        #endregion

       
    }
}