using AdimAdimDavaKaydi.Belge.Util;
using AdimAdimDavaKaydi.IcraTakipForms;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace AdimAdimDavaKaydi.Belge.UserControls
{
    public partial class ucBelgeKayitUfak : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBelgeKayitUfak()
        {
            InitializeComponent();

            this.Load += ucBelgeKayitUfak_Load;
        }
        private List<string> _FileName = new List<string>();
        public List<string> FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        public bool CelseEkranindanmi;

        public bool IsLoaded;

        public bool ModulDosya;

        public int ModulID;

        public int TabloID;

        public string TabloName = string.Empty;

        private TList<AV001_TDIE_BIL_BELGE> _MyDataSource;

        private IEntity _Openedrecord;

        private int _Position;

        private IEntity _record;

        private bool duzenle;

        private int kayitSayisi;

        public delegate void New(AV001_TDIE_BIL_BELGE belge, object sender);

        public delegate void OnSaved(IList Records, IEntity Record);

        public event EventHandler<BelgeKaydedildiEventArgs> BelgeKaydedildi;

        public event New OnNew;

        [Browsable(false)]
        public event OnSaved Saved;

        [Browsable(false)]
        public AV001_TDIE_BIL_BELGE Current
        {
            get { return (AV001_TDIE_BIL_BELGE)this.c_bndBelge.Current; }
        }

        public bool Duzenle
        {
            get { return duzenle; }
            set
            {
                duzenle = value;
                if (value)
                {
                    xtraTabControl1.Enabled = true;
                    c_btnYeni.Enabled = false;
                    c_btnKaydet.Enabled = true;
                }
                else
                {
                    xtraTabControl1.Enabled = false;
                    c_btnYeni.Enabled = true;
                    c_btnKaydet.Enabled = false;
                }
            }
        }

        public AV001_TDI_BIL_IS HatirlatilcakIs { get; set; }

        public bool InForm { get; set; }

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_BELGE> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;

                //Duzenle = true;//ARCH
                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        public IEntity OpenedRecord
        {
            get
            {
                if (this.DesignMode)
                    return null;

                return _Openedrecord;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    _Openedrecord = value;
                    c_lueModul.Enabled = false;
                    c_lueDosya.Enabled = false;

                    #region <MB-20100621>

                    //ÝBB bu alanlarýn deðiþtirilebilir olmasýný talep ettiði için disable iþlemi kaldýrýldý.
                    //c_lueAdliye.Enabled = false;
                    //c_lueBirimNo.Enabled = false;
                    //c_leuGorev.Enabled = false;
                    //eSAS_NOTextEdit1.Enabled = false;

                    #endregion <MB-20100621>
                }
            }
        }

        public int Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
                if (IsLoaded)
                    this.c_bndBelge.Position = value;
            }
        }

        [Browsable(false)]
        public IEntity Record
        {
            get { return _record; }
            set
            {
                _record = value;
                if (value != null && !IsLoaded)
                {
                    //    this.MyDataSource = new TList<AV001_TDIE_BIL_BELGE>();
                    //    this.MyDataSource.Add(RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord(this._record));
                    //    this.panelControl1.Visible = true;

                    AV001_TDIE_BIL_BELGE belgem = value as AV001_TDIE_BIL_BELGE;

                    if (belgem != null)
                    {
                        if (belgem.ID != 0 && belgem.STAMP != 1)
                        {
                            belgem.STAMP = 1;
                            DataRepository.AV001_TDIE_BIL_BELGEProvider.Save(belgem);
                        }
                        if (OpenedRecord != null)
                        {
                            AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(c_lueModul.Properties, null);
                            dOSYA_ADITextEdit1.Text = belgem.DOSYA_ADI;
                            bELGE_ADITextEdit1.Text = belgem.BELGE_ADI;
                            ModulDosya = true;
                            if (OpenedRecord is AV001_TI_BIL_FOY)
                            {
                                c_lueModul.EditValue = 1;
                                c_lueDosya.EditValue = (OpenedRecord as AV001_TI_BIL_FOY).ID;
                                ModulDosyaDisable();
                            }
                            else if (OpenedRecord is AV001_TD_BIL_FOY)
                            {
                                c_lueModul.EditValue = 2;

                                //if (c_lueDosya.Properties.DataSource == null)       //ARCH
                                //{                                                   //ARCH
                                //    var foyList = new TList<AV001_TD_BIL_FOY>();    //ARCH
                                //    foyList.Add(OpenedRecord as AV001_TD_BIL_FOY);  //ARCH
                                //    c_lueDosya.Properties.DataSource = foyList;     //ARCH
                                //}                                                   //ARCH
                                c_lueDosya.EditValue = (OpenedRecord as AV001_TD_BIL_FOY).ID;
                                ModulDosyaDisable();
                            }
                            else if (OpenedRecord is AV001_TD_BIL_HAZIRLIK)
                            {
                                c_lueModul.EditValue = 3;
                                c_lueDosya.EditValue = (OpenedRecord as AV001_TD_BIL_HAZIRLIK).ID;
                                ModulDosyaDisable();
                            }
                            else if (OpenedRecord is AV001_TDI_BIL_SOZLESME)
                            {
                                c_lueModul.EditValue = 5;
                                c_lueDosya.EditValue = (OpenedRecord as AV001_TDI_BIL_SOZLESME).ID;
                                ModulDosyaDisable();
                            }

                            //else if (OpenedRecord is AV001_TDIE_BIL_PROJE)
                            //{
                            //    c_lueModul.EditValue = 11;
                            //    c_lueDosya.EditValue = (OpenedRecord as AV001_TDIE_BIL_PROJE).ID;
                            //    ModulDosyaDisable();
                            //}
                        }
                    }
                }
            }
        }

        public Control RecordNo
        {
            get
            {
                if (this.DesignMode)
                    return null;

                //return panelControl1;
                return null;
            }
        }

        public Control SelectRecord
        {
            get
            {
                if (this.DesignMode)
                    return null;
                //return panelControl2;
                return null;
            }
        }

        public SimpleButton SelectRecordButton
        {
            get
            {
                if (this.DesignMode)
                    return null;

                return simpleButton1;
            }
        }

        public static string BelgeNoGetir()
        {
            string yeniBelgeNo = string.Empty;
            var enSonBelgeNo = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, "select 'B-' + CONVERT(VARCHAR(4),YEAR(GETDATE())) + '~' + max(SUBSTRING(BELGE_NO,8,LEN(BELGE_NO)-7)) from AV001_TDIE_BIL_BELGE WHERE BELGE_NO LIKE '%~%'");

            if (enSonBelgeNo != null && !string.IsNullOrEmpty(enSonBelgeNo.ToString()) /* && enSonBelgeNo.ToString().Contains("B-20") */)
            {
                string[] dizi = enSonBelgeNo.ToString().Split('~');

                int yeniBelgeNoSayi = 0;
                int.TryParse(dizi[1], out yeniBelgeNoSayi);

                if (yeniBelgeNoSayi == 0)
                    yeniBelgeNoSayi = 10000;
                else
                    yeniBelgeNoSayi++;
                yeniBelgeNo = String.Format("B-{0}~{1}", DateTime.Today.Year, yeniBelgeNoSayi);

                return yeniBelgeNo;
            }
            else
            {
                yeniBelgeNo = String.Format("B-{0}~{1}", DateTime.Today.Year, "10000");

                return yeniBelgeNo;
            }
        }

        public void BindData()
        {
            if (DesignMode || MyDataSource == null)
            {
                return;
            }
            this.c_bndBelge.DataSource = MyDataSource;

            setKayitSayisi();
        }

        public AV001_TDI_BIL_IS IsKaydet()
        {
            AV001_TDIE_BIL_BELGE belge = ((TList<AV001_TDIE_BIL_BELGE>)this.c_bndBelge.DataSource)[0];
            AV001_TDI_BIL_IS ds = new AV001_TDI_BIL_IS();
            TList<AV001_TDI_BIL_IS> isler = new TList<AV001_TDI_BIL_IS>();

            if (belge.ID == 0)
                belge.STAMP = 0;

            ds.ACIKLAMA = belge.BELGE_NO + "Nolu belgenin iþ kaydý.";
            ds.YAPILACAK_IS = belge.BELGE_NO + "Nolu belgenin iþ kaydý.";
            ds.KATEGORI_ID = 883;
            ds.ADLI_BIRIM_ADLIYE_ID = belge.ADLI_BIRIM_ADLIYE_ID;
            ds.ADLI_BIRIM_GOREV_ID = belge.ADLI_BIRIM_GOREV_ID;
            ds.ADLI_BIRIM_NO_ID = belge.ADLI_BIRIM_NO_ID;
            ds.AJANDADA_GORUNSUN_MU = true;
            ds.BASLANGIC_TARIHI = bASLANGIC_TARIHIDateEdit.DateTime.Add(timeBaslangic.Time.TimeOfDay);
            ds.ESAS_NO = belge.ESAS_NO;
            ds.HATIRLATILSIN_MI = hATIRLATILSIN_MICheckEdit.Checked;
            ds.KONU = string.Format("{0} nolu Belge kaydý", belge.BELGE_NO);
            //ds.ONGORULEN_BITIS_TARIHI = oNGORULEN_BITIS_TARIHIDateEdit.DateTime.Add(timeBitis.Time.TimeOfDay);
            ds.ONGORULEN_BITIS_TARIHI = oNGORULEN_BITIS_TARIHIDateEdit.DateTime.Add(timeBitis.Time.TimeOfDay);

            ds.REFERANS_NO = belge.BELGE_REFERANS_NO;
            ds.AV001_TDI_BIL_IS_TARAFCollection = (TList<AV001_TDI_BIL_IS_TARAF>)aV001TDIBILISTARAFCollectionBindingSource.DataSource;
            ds.MODUL_ID = (int)AvukatProLib.Extras.Modul.Belge;
            ds.STAMP = 0;
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);

            if (isler != null && isler.Count > 0)
            {
                ds.TEKRARLAMA_BILGISI = isler[0].TEKRARLAMA_BILGISI;
                ds.HATIRLATMA_BILGISI = isler[0].HATIRLATMA_BILGISI;
            }

            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);

            if (OpenedRecord != null)
            {
                switch (OpenedRecord.TableName)
                {
                    case "AV001_TI_BIL_FOY":
                        NN_IS_ICRA_FOY isIcra = new NN_IS_ICRA_FOY();
                        isIcra.ICRA_FOY_ID = (OpenedRecord as AV001_TI_BIL_FOY).ID;
                        isIcra.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.Save(isIcra);
                        break;

                    case "AV001_TD_BIL_FOY":
                        NN_IS_DAVA_FOY isDava = new NN_IS_DAVA_FOY();
                        isDava.DAVA_FOY_ID = (OpenedRecord as AV001_TD_BIL_FOY).ID;
                        isDava.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.Save(isDava);
                        break;
                    case "AV001_TD_BIL_HAZIRLIK":
                        NN_IS_HAZIRLIK isHazirlik = new NN_IS_HAZIRLIK();
                        isHazirlik.HAZIRLIK_ID = (OpenedRecord as AV001_TD_BIL_HAZIRLIK).ID;
                        isHazirlik.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_HAZIRLIKProvider.Save(isHazirlik);
                        break;

                    case "AV001_TDI_BIL_SOZLESME":
                        NN_IS_SOZLESME isSozlesme = new NN_IS_SOZLESME();
                        isSozlesme.SOZLESME_ID = (OpenedRecord as AV001_TDI_BIL_SOZLESME).ID;
                        isSozlesme.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_SOZLESMEProvider.Save(isSozlesme);
                        break;

                    default:
                        break;
                }
            }

            //IEntity MyRecord;
            NNProcess.SaveIs(ds, (IEntity)c_bndBelge.Current);

            foreach (var item in ds.AV001_TDI_BIL_IS_TARAFCollection)
            {
                item.IS_ID = ds.ID;
            }
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_TARAFProvider.Save(ds.AV001_TDI_BIL_IS_TARAFCollection);

            if (ds.AV001_TDI_BIL_IS_TARAFCollection != null && ds.AV001_TDI_BIL_IS_TARAFCollection.Count >= 0)
            {
                for (int i = 0; i < ds.AV001_TDI_BIL_IS_TARAFCollection.Count; i++)
                {
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(ds, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<NN_IS_CARI>));
                    NN_IS_CARI isCari = new NN_IS_CARI();
                    isCari.IS_ID = ds.ID;
                    if (ds.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID > 0)
                    {
                        isCari.CARI_ID = ds.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID.Value;

                        if (
                            ds.NN_IS_CARICollection.Exists(
                                delegate(NN_IS_CARI tarf)
                                {
                                    return tarf.CARI_ID == isCari.CARI_ID; // && tarf.IS_ID==isCari.IS_ID;
                                })) continue;
                        AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.DeepSave(isCari);
                    }
                }
            }
            DataRepository.AV001_TDI_BIL_ISProvider.DeepSave(ds, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_HATIRLAT>), typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));

            #region Ekran Hatýrlatmasý

            if (chkEkran.Checked)
            {
                AV001_TDI_BIL_HATIRLAT ekranHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                ekranHatirlatma.IS_ID = ds.ID;
                ekranHatirlatma.HATIRLATSIN_MI = true;
                ekranHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                ekranHatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                ekranHatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                ekranHatirlatma.ACIKLAMA = ds.TEKRARLAMA_BILGISI ?? string.Empty;
                ekranHatirlatma.HATIRLATMA_TIPI = "0";
                ekranHatirlatma.BASLANGIC_ID = 1;
                ekranHatirlatma.PERIYOD_ID = 1;
                ekranHatirlatma.TEKRAR = 1;
                ekranHatirlatma.GUNLUK_UYARI_SAAT = (ds.BASLANGIC_TARIHI.Value - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue).ToShortTimeString();

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    switch (ucHatirlatmaPeriyot1.cbxHatirlatmaEkran.SelectedIndex)
                    {
                        case 0:
                            if (taraf.IS_TARAF_ID == 1)
                                ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                            break;

                        case 1:
                            if (taraf.IS_TARAF_ID == 2)
                                ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                            break;

                        case 2:
                            if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                            break;

                        case 3:
                            ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                            break;

                        default:
                            break;
                    }
                }

                ekranHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = ds.ID });
                ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(ekranHatirlatma);
                DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
            }

            #endregion Ekran Hatýrlatmasý

            #region Mail Hatýrlatmasý

            if (chkMail.Checked)
            {
                AV001_TDI_BIL_HATIRLAT mailHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                mailHatirlatma.IS_ID = ds.ID;
                mailHatirlatma.HATIRLATSIN_MI = true;
                mailHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                mailHatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                mailHatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                mailHatirlatma.ACIKLAMA = "mail hatýrlatma";
                mailHatirlatma.HATIRLATMA_TIPI = "1";
                mailHatirlatma.BASLANGIC_ID = 1;
                mailHatirlatma.PERIYOD_ID = 1;

                mailHatirlatma.TEKRAR = 1;
                mailHatirlatma.GUNLUK_UYARI_SAAT = (ds.BASLANGIC_TARIHI.Value - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue).ToShortTimeString();

                //if (chkIsBildir.Checked)
                //{
                mailHatirlatma.BIR_DEFA_PATLAMASI_OLDU_MU = true;

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    //switch (cbxIsiBildirMail.SelectedIndex)
                    //{
                    //case 0:
                    //    if (taraf.IS_TARAF_ID == 1)
                    //        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //    break;

                    //case 1:
                    //    if (taraf.IS_TARAF_ID == 2)
                    //        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //    break;

                    //case 2:
                    //    if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                    //        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //    break;

                    //case 3:
                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //    break;
                    //default:
                    //    break;
                    //}
                }
                //}

                //if (chkTamamlandiMail.Checked)
                //{
                //    mailHatirlatma.GOSTERSIN_MI_1_GUN_ONCE = chkTamamlandiMail.Checked;

                //    foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //    {
                //        if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                //            break;
                //        switch (cbxTamamlandiMail.SelectedIndex)
                //        {
                //            case 0:
                //                if (taraf.IS_TARAF_ID == 1)
                //                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 1:
                //                if (taraf.IS_TARAF_ID == 2)
                //                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 2:
                //                if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                //                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 3:
                //                mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}

                //if (chkYapilmamissaMail.Checked)
                //{
                //mailHatirlatma.PERIYODUN_SON_PATLAMASI_OLDU_MU = true;

                //foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //{
                //    if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                //        break;
                //    switch (cbxYapilmamissaMail.SelectedIndex)
                //    {
                //        case 0:
                //            if (taraf.IS_TARAF_ID == 1)
                //                mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //            break;

                //        case 1:
                //            if (taraf.IS_TARAF_ID == 2)
                //                mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //            break;

                //        case 2:
                //            if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                //                mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //            break;

                //        case 3:
                //            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //            break;
                //        default:
                //            break;
                //    }
                //}
                //}

                //if (chkHatirlatmaMail.Checked)
                //{
                //mailHatirlatma.GUNLUK_UYARI_SAAT = durationEdit1.Text.Substring(0, 5);
                mailHatirlatma.TEKRAR = 1;

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    //switch (cbxHatirlatmaMail.SelectedIndex)
                    //{
                    //    case 0:
                    //        if (taraf.IS_TARAF_ID == 1)
                    //            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 1:
                    //        if (taraf.IS_TARAF_ID == 2)
                    //            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 2:
                    //        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                    //            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 3:
                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                //}

                mailHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = ds.ID });
                ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(mailHatirlatma);
                DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
            }

            #endregion Mail Hatýrlatmasý

            #region SMS Hatýrlatmasý

            if (chkSms.Checked)
            {
                AV001_TDI_BIL_HATIRLAT smsHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                smsHatirlatma.IS_ID = ds.ID;
                smsHatirlatma.HATIRLATSIN_MI = true;
                smsHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                smsHatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                smsHatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                smsHatirlatma.ACIKLAMA = "sms hatýrlatma";
                smsHatirlatma.HATIRLATMA_TIPI = "2";
                smsHatirlatma.BASLANGIC_ID = 1;
                smsHatirlatma.PERIYOD_ID = 1;

                smsHatirlatma.TEKRAR = 1;
                smsHatirlatma.GUNLUK_UYARI_SAAT = (ds.BASLANGIC_TARIHI.Value - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue).ToShortTimeString();

                //if (chkIsiBildirSMS.Checked)
                //{
                smsHatirlatma.BIR_DEFA_PATLAMASI_OLDU_MU = true;

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    //switch (cbxIsiBildirSMS.SelectedIndex)
                    //{
                    //    case 0:
                    //        if (taraf.IS_TARAF_ID == 1)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 1:
                    //        if (taraf.IS_TARAF_ID == 2)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 2:
                    //        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 3:
                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                //}

                //if (chkTamamlandigindaSMS.Checked)
                //{
                //    smsHatirlatma.GOSTERSIN_MI_1_GUN_ONCE = chkTamamlandiMail.Checked;

                //    foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //    {
                //        if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                //            break;
                //        switch (cbxTamamlandiðindaSMS.SelectedIndex)
                //        {
                //            case 0:
                //                if (taraf.IS_TARAF_ID == 1)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 1:
                //                if (taraf.IS_TARAF_ID == 2)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 2:
                //                if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 3:
                //                smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}

                //if (chkYapilmamissaSMS.Checked)
                //{
                //    smsHatirlatma.PERIYODUN_SON_PATLAMASI_OLDU_MU = chkYapilmamissaMail.Checked;

                //    foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //    {
                //        if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                //            break;
                //        switch (cbxYapilmamissaSMS.SelectedIndex)
                //        {
                //            case 0:
                //                if (taraf.IS_TARAF_ID == 1)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 1:
                //                if (taraf.IS_TARAF_ID == 2)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 2:
                //                if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 3:
                //                smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}

                //if (chkHatirlatSMS.Checked)
                //{
                //smsHatirlatma.GUNLUK_UYARI_SAAT = durationEdit1.Text.Substring(0, 5);
                smsHatirlatma.TEKRAR = 1;

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    //switch (cbxHatirlatSMS.SelectedIndex)
                    //{
                    //    case 0:
                    //        if (taraf.IS_TARAF_ID == 1)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 1:
                    //        if (taraf.IS_TARAF_ID == 2)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 2:
                    //        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 3:
                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                //}

                smsHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = ds.ID });
                ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(smsHatirlatma);
                DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
            }

            #endregion SMS Hatýrlatmasý


            return ds;
        }

        public void KayitIlistir(object sender, EventArgs e)
        {
            AV001_TDIE_BIL_BELGE belge = MyDataSource[0]; //((AV001_TDIE_BIL_BELGE)c_bndBelge.Current);
            if (c_lueDosya.EditValue != null && belge != null)
            {
                try
                {
                    if (c_lueModul.EditValue != null && c_lueModul.EditValue != DBNull.Value)
                        ModulID = Convert.ToInt32(c_lueModul.EditValue);
                    switch (ModulID)
                    {
                        #region Soruþturma Modülünün Belge Kayýt Ekranýna Taraf Bilgilerini Getirmesi (ARCH)

                        case 3:
                            OpenedRecord = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)c_lueDosya.EditValue);

                            eSAS_NOTextEdit1.EditValue = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).HAZIRLIK_ESAS_NO;
                            belge.ESAS_NO = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).HAZIRLIK_ESAS_NO;

                            c_lueAdliye.EditValue = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad((AV001_TD_BIL_HAZIRLIK)OpenedRecord, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();//control
                            foreach (var item in ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                            {
                                AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                trf.CARI_ID = item.CARI_ID;
                                trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                            }
                            ucTaraf1.Record = belge;
                            break;

                        #endregion Soruþturma Modülünün Belge Kayýt Ekranýna Taraf Bilgilerini Getirmesi (ARCH)

                        case 2:
                            OpenedRecord = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);

                            eSAS_NOTextEdit1.EditValue = ((AV001_TD_BIL_FOY)OpenedRecord).ESAS_NO;
                            belge.ESAS_NO = ((AV001_TD_BIL_FOY)OpenedRecord).ESAS_NO;

                            c_lueAdliye.EditValue = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad((AV001_TD_BIL_FOY)OpenedRecord, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TD_BIL_FOY_TARAF>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();
                            foreach (var item in ((AV001_TD_BIL_FOY)OpenedRecord).AV001_TD_BIL_FOY_TARAFCollection)
                            {
                                if (item.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.DAVACI)
                                {
                                    AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                    trf.CARI_ID = item.CARI_ID;
                                    trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                    belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                                }
                                if (item.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.DAVALI)
                                {
                                    AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                    trf.CARI_ID = item.CARI_ID;
                                    trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                    belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                                }
                            }
                            ucTaraf1.Record = belge;
                            break;

                        case 1:
                            OpenedRecord = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);

                            eSAS_NOTextEdit1.EditValue = ((AV001_TI_BIL_FOY)OpenedRecord).ESAS_NO;
                            belge.ESAS_NO = ((AV001_TI_BIL_FOY)OpenedRecord).ESAS_NO;

                            c_lueAdliye.EditValue = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad((AV001_TI_BIL_FOY)OpenedRecord, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();
                            foreach (var item in ((AV001_TI_BIL_FOY)OpenedRecord).AV001_TI_BIL_FOY_TARAFCollection)
                            {
                                if (item.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)
                                {
                                    AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                    trf.CARI_ID = item.CARI_ID;
                                    trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                    belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                                }
                                if (item.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.BORCLU)
                                {
                                    AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                    trf.CARI_ID = item.CARI_ID;
                                    trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                    belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                                }
                            }

                            ucTaraf1.Record = belge;
                            break;

                        case 12:
                            OpenedRecord =
                                DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad((AV001_TDI_BIL_TEMSIL)OpenedRecord,
                                                                                 false, DeepLoadType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();
                            foreach (
                                var item in ((AV001_TDI_BIL_TEMSIL)OpenedRecord).AV001_TDI_BIL_TEMSIL_TARAFCollection)
                            {
                                AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                trf.CARI_ID = item.TARAF_CARI_ID;
                                belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                            }
                            break;

                        case 5:
                            OpenedRecord =
                                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(
                                (AV001_TDI_BIL_SOZLESME)OpenedRecord, false, DeepLoadType.IncludeChildren,
                                typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();
                            foreach (
                                var item in
                                    ((AV001_TDI_BIL_SOZLESME)OpenedRecord).AV001_TDI_BIL_SOZLESME_TARAFCollection)
                            {
                                AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                trf.CARI_ID = item.CARI_ID;
                                trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                            }

                            break;

                        case 13:
                            OpenedRecord =
                                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID =
                                ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID =
                                ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_GOREV_ID;
                            break;

                        case 14:
                            OpenedRecord =
                                DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID =
                                ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID =
                                ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_GOREV_ID;
                            break;

                        case 15:
                            OpenedRecord = DataRepository.AV001_TD_BIL_CELSEProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_GOREV_ID;
                            break;

                        case 16:
                            OpenedRecord =
                                DataRepository.AV001_TDI_BIL_FATURAProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.Enabled = true;
                            c_lueBirimNo.Enabled = true;
                            c_leuGorev.Enabled = true;
                            break;

                        case 17:
                            OpenedRecord =
                                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.Enabled = true;
                            c_lueBirimNo.Enabled = true;
                            c_leuGorev.Enabled = true;
                            break;

                        case 11:
                            OpenedRecord =
                                DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID((int)c_lueDosya.EditValue);
                            break;

                        default:
                            break;
                    }
                    c_lueModul.Enabled = true;
                    c_lueDosya.Enabled = true;

                    #region <MB-20100621>

                    //ÝBB bu alanlarýn deðiþtirilebilir olmasýný talep ettiði için disable iþlemi kaldýrýldý.
                    //if (ModulID != 16 || ModulID != 17)
                    //{
                    //c_lueAdliye.Enabled = false;
                    //c_lueBirimNo.Enabled = false;
                    //c_leuGorev.Enabled = false;
                    //eSAS_NOTextEdit1.Enabled = false;
                    //}

                    #endregion <MB-20100621>
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        public void ModulDosyaDisable()
        {
            c_lueModul.Enabled = false;
            c_lueDosya.Enabled = false;
        }

        public void NewRecord()
        {
            if (_Openedrecord != null)
            {
                AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();

                blg = RecordGenerator.Generate.GenerateAV001_TDIE_BIL_BELGEByRecord(_Openedrecord);
                blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                blg.YAZILMA_TARIHI = DateTime.Now;
                blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                blg.STAMP = 0;
                if (CelseEkranindanmi)
                    blg.BELGE_TUR_ID = 17; //DURUÞMA ZAPTI
                else
                    blg.BELGE_TUR_ID = 7;
                blg.BELGE_NO = BelgeNoGetir();

                //string strBelgeNo = "B"+
                switch (_Openedrecord.TableName)
                {
                    case "AV001_TI_BIL_FOY":
                        c_lueModul.EditValue = 1;
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Icra, false);
                        c_lueDosya.EditValue = ((AV001_TI_BIL_FOY)_Openedrecord).ID;

                        //blg.NN_BELGE_ICRACollection.Add(new NN_BELGE_ICRA() { ICRA_FOY_ID = ((AV001_TI_BIL_FOY)_Openedrecord).ID });
                        break;

                    case "AV001_TD_BIL_FOY":
                        c_lueModul.EditValue = 2;
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Dava, false);
                        c_lueDosya.EditValue = ((AV001_TD_BIL_FOY)_Openedrecord).ID;

                        //blg.NN_BELGE_DAVACollection.Add(new NN_BELGE_DAVA() { DAVA_FOY_ID = ((AV001_TD_BIL_FOY)_Openedrecord).ID });
                        break;

                    case "AV001_TDIE_BIL_PROJE":
                        c_lueModul.EditValue = 11; //Klasör

                        //AdimAdimDavaKaydi.Util.Inits.ProjeAdGetirYenile(c_lueDosya);
                        c_lueDosya.EditValue = ((AV001_TDIE_BIL_PROJE)_Openedrecord).ID;
                        break;

                    default:
                        break;
                }
                this.c_bndBelge.Add(blg);
                this.OnNew(blg, this);
            }
            else
            {
                AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                blg.BELGE_TUR_ID = 7;
                blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                blg.YAZILMA_TARIHI = DateTime.Now;
                blg.BELGE_NO = BelgeNoGetir();
                blg.STAMP = 0;
                this.c_bndBelge.Add(blg);
                this.OnNew(blg, this);
            }
            this.c_bndBelge.MoveLast();
            setKayitSayisi();
        }

        public void Save(AV001_TDIE_BIL_BELGE belgeSave)
        {
            try
            {
                //TList<AV001_TDIE_BIL_BELGE> lstBelgeler = (TList<AV001_TDIE_BIL_BELGE>)this.c_bndBelge.DataSource;

                if (string.IsNullOrEmpty(belgeSave.BELGE_REFERANS_NO))
                    return;
                //lstBelgeler.Remove(belgeSave);

                TList<AV001_TDIE_BIL_BELGE_TARAF> belgeTrf = new TList<AV001_TDIE_BIL_BELGE_TARAF>();

                foreach (var item in belgeSave.AV001_TDIE_BIL_BELGE_TARAFCollection)
                    if (item.CARI_ID > 0 && item.SIFAT_ID > 0)
                        belgeTrf.Add(item);

                if (string.IsNullOrEmpty(belgeSave.BELGE_ADI) && belgeSave.AV001_TDIE_BIL_BELGE_TARAFCollection.Count > 0)
                {
                    var belgeTaraf = belgeSave.AV001_TDIE_BIL_BELGE_TARAFCollection[0].CARI_IDSource;
                    if (belgeTaraf == null && belgeSave.AV001_TDIE_BIL_BELGE_TARAFCollection[0].CARI_ID.HasValue)
                        belgeTaraf = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(belgeSave.AV001_TDIE_BIL_BELGE_TARAFCollection[0].CARI_ID.Value);
                    if (belgeTaraf != null)
                    {
                        belgeSave.BELGE_ADI = string.Format("{0}-{1}-{2}", belgeTaraf.VERGI_NO, belgeTaraf.AD, belgeSave.DOSYA_ADI);
                    }
                }

                belgeSave.AV001_TDIE_BIL_BELGE_TARAFCollection = null;
                belgeSave.AV001_TDIE_BIL_BELGE_TARAFCollection = belgeTrf;


                #region <MB-20100621>

                //Belge kaydý sýrasýnda BELGE_NO bilgisinin unique olmasýný saðlamak için tekrardan kontrol eklendi.
                if (DataRepository.AV001_TDIE_BIL_BELGEProvider.Find(string.Format("BELGE_NO = {0}", belgeSave.BELGE_NO)).Count > 0)
                    belgeSave.BELGE_NO = BelgeNoGetir();

                #endregion <MB-20100621>

                dOSYA_ADITextEdit1.Text = belgeSave.DOSYA_ADI;
                string[] names = dOSYA_ADITextEdit1.Text.Split('.');

                AV001_TDIE_BIL_BELGE blg = null;
                if (belgeSave != null)
                    blg = belgeSave;

                if (System.IO.File.Exists(blg.DOSYA_ADI) && blg != null)
                {
                    System.IO.FileStream fss = new System.IO.FileStream(blg.DOSYA_ADI, System.IO.FileMode.Open);
                    byte[] veri = new byte[fss.Length];
                    fss.Read(veri, 0, veri.Length);
                    blg.ICERIK = veri;
                    fss.Close();
                }

                belgeSave.DOKUMAN_UZANTI = Path.GetExtension(belgeSave.DOSYA_ADI).Replace(".", "");

                belgeSave.YIL = txtYil.Text;
                belgeSave.SAYI = (int)spinSayi.Value;
                belgeSave.BARKOD_NO = txtBarkodNo.Text;
                if (txtSorumlu.Tag != null)
                    belgeSave.BELGEYI_YAZAN_ID = (int)txtSorumlu.Tag;

                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepSave(belgeSave, AvukatProLib2.Data.DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>));


                if (OpenedRecord != null)
                {

                    Util.NNProcess.SaveBelge(belgeSave, OpenedRecord);
                }
                else if (c_lueDosya.EditValue != null && vTIICRADOSYALARBindingSource.Current != null && string.IsNullOrEmpty(vTIICRADOSYALARBindingSource.Current.GetType().GetProperty("TableName").GetValue(vTIICRADOSYALARBindingSource.Current, null).ToString()))
                    Util.NNProcess.SaveBelge(belgeSave, vTIICRADOSYALARBindingSource.Current.GetType().GetProperty("TableName").GetValue(vTIICRADOSYALARBindingSource.Current, null).ToString(), int.Parse(vTIICRADOSYALARBindingSource.Current.GetType().GetProperty("ID").GetValue(vTIICRADOSYALARBindingSource.Current, null).ToString()));

                #region <CC-20090627>

                // o an kaydedilen belgenin dolaþim collectionu  gönderilecek
                //if (BelgeKaydedildi != null)
                //    BelgeKaydedildi(this, new BelgeKaydedildiEventArgs(belgeSave));

                #endregion <CC-20090627>


                if (chkYapilacakIs.Checked)
                {
                    HatirlatilcakIs = IsKaydet();
                    belgeSave.AV001_TDI_BIL_ISCollection_From_NN_IS_BELGE.Add(HatirlatilcakIs);
                }
                if (Saved != null)
                    Saved(new List<AV001_TDIE_BIL_BELGE>() { belgeSave }, belgeSave);

                XtraMessageBox.Show(string.Format("{0} nolu Belge Baþarýyla Kaydedilmiþtir.", belgeSave.BELGE_NO));
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void aV001_TDIE_BIL_BELGEBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (this.c_bndBelge.Current != null)
            {
                this.ucTaraf1.Record = (AV001_TDIE_BIL_BELGE)this.c_bndBelge.Current;
            }
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(c_lueOzelKod1, 1, AvukatProLib.Extras.Modul.Belge);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(c_lueOzelKod2, 2, AvukatProLib.Extras.Modul.Belge);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(c_lueOzelKod3, 3, AvukatProLib.Extras.Modul.Belge);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(c_lueOzelKod4, 4, AvukatProLib.Extras.Modul.Belge);
        }

        //            (c_lueOzelKod4.Properties.DataSource as VList<per_AV001_TDIE_KOD_OZEL_KOD>).Add(BelgeUtil.Inits.GetBelgeOzelKodViewItem(Ozel_Kod));
        //            XtraMessageBox.Show("Özel Kod Kaydý Baþarýyla Tamamlanmýþtýr");
        //        }
        //    }
        //    catch
        //    {
        //        XtraMessageBox.Show("Kayýt Esnasýnda Bir hata Olmuþtur");
        //    }
        //}
        private void btnHatirlatma_Click(object sender, EventArgs e)
        {
            if (HatirlatilcakIs == null)
                return;

            Is.Forms.frmIsKayitUfak frm = new Is.Forms.frmIsKayitUfak();
            frm.Record = HatirlatilcakIs;
            frm.Show();
        }

        private void c_btnKaydet_Click(object sender, EventArgs e)
        {
            c_btnKaydet.Enabled = false;
            c_btnYeni.Enabled = true;
            AV001_TDIE_BIL_BELGE belge = ((AV001_TDIE_BIL_BELGE)c_bndBelge.Current);
            AV001_TDIE_BIL_BELGE belgeold = null;
            if (openFileDialog1.FileNames.Length != 0 && FileName.Count != 0)
            {
                List<string> filenames = new List<string>();
                if (openFileDialog1.FileNames.Length > 0)
                    filenames = openFileDialog1.FileNames.ToList();
                else if (FileName.Count > 0)
                    filenames = FileName;
                foreach (var item in filenames)
                {
                    if (string.IsNullOrEmpty(item))
                        continue;
                    if (!File.Exists(item))
                        continue;
                    if (belgeold != null)
                    {
                        belgeold.DOSYA_ADI = item;
                        this.Save(belgeold);
                        belgeold = AvukatProLib2.Entities.EntityHelper.Clone<AV001_TDIE_BIL_BELGE>(belge);
                        belgeold.EntityState = EntityState.Added;
                        foreach (var taraf in belgeold.AV001_TDIE_BIL_BELGE_TARAFCollection)
                        {
                            taraf.EntityState = EntityState.Added;
                        }
                        belgeold.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                    }
                    else
                    {
                        belge.DOSYA_ADI = item;
                        this.Save(belge);

                        belgeold = AvukatProLib2.Entities.EntityHelper.Clone<AV001_TDIE_BIL_BELGE>(belge);
                        belgeold.EntityState = EntityState.Added;
                        foreach (var taraf in belgeold.AV001_TDIE_BIL_BELGE_TARAFCollection)
                        {
                            taraf.EntityState = EntityState.Added;
                        }
                        belgeold.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();

                    }
                    btnHatirlatma.Enabled = true;
                }
            }
            else if (dOSYA_ADITextEdit1.Text != "")
            {
                string dOSYA_ADIText_Path = dOSYA_ADITextEdit1.Text;
                if (belgeold != null)
                {
                    belgeold.DOSYA_ADI = dOSYA_ADIText_Path;
                    this.Save(belgeold);
                    belgeold = AvukatProLib2.Entities.EntityHelper.Clone<AV001_TDIE_BIL_BELGE>(belge);
                    belgeold.EntityState = EntityState.Added;
                    foreach (var taraf in belgeold.AV001_TDIE_BIL_BELGE_TARAFCollection)
                    {
                        taraf.EntityState = EntityState.Added;
                    }
                    belgeold.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                }
                else
                {
                    belge.DOSYA_ADI = dOSYA_ADIText_Path;
                    this.Save(belge);

                    belgeold = AvukatProLib2.Entities.EntityHelper.Clone<AV001_TDIE_BIL_BELGE>(belge);
                    belgeold.EntityState = EntityState.Added;
                    foreach (var taraf in belgeold.AV001_TDIE_BIL_BELGE_TARAFCollection)
                    {
                        taraf.EntityState = EntityState.Added;
                    }
                    belgeold.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                }
                btnHatirlatma.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen dosya adý alanýný doldurunuz.");
            }
            //xtraTabControl1.Enabled = false;
        }

        private void c_lueBelgeTur_Enter(object sender, EventArgs e)
        {
            c_lueBelgeTur.Properties.Buttons[1].Tag = "Ekle";
        }

        private void c_lueBelgeTur_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "Ekle")
            {
                frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.BelgeTuru, -1);
                frmalt.ShowDialog();

                AvukatPro.Services.Implementations.DevExpressService.BelgeTuruDoldur(c_lueBelgeTur.Properties);
                e.Button.Tag = null;
                //LookUpEdit lue = sender as LookUpEdit;
                //if (!string.IsNullOrEmpty(lue.Text))
                //{
                //    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                //    TDIE_KOD_BELGE_TUR turum = new TDIE_KOD_BELGE_TUR();

                //    turum.BELGE_TURU = lue.Text;
                //    turum.KONTROL_KIM = "AVUKATPRO";
                //    turum.KONTROL_KIM_ID = 1;
                //    turum.KONTROL_NE_ZAMAN = DateTime.Now;
                //    turum.KONTROL_VERSIYON = 1;
                //    turum.SUBE_KODU = 1;
                //    turum.ADMIN_KAYIT_MI = 1;
                //    turum.STAMP = 1;

                //    try
                //    {
                //        tran.BeginTransaction();
                //        DataRepository.TDIE_KOD_BELGE_TURProvider.Save(turum);
                //        tran.Commit();

                //        XtraMessageBox.Show("Yeni Belge Türü kaydý tamamlandý.", "BÝLGÝ", MessageBoxButtons.OK,
                //                            MessageBoxIcon.Information);
                //        lue.Properties.DataSource = null;
                //        BelgeUtil.Inits.BelgeTurGetir(lue.Properties);
                //    }
                //    catch (Exception ex)
                //    {
                //        if (tran.IsOpen)
                //            tran.Rollback();
                //        BelgeUtil.ErrorHandler.Catch(this, ex);
                //    }
                //}
            }
        }

        private void c_lueBelgeTur_Validated(object sender, EventArgs e)
        {
            c_lueBelgeTur.Properties.Buttons[1].Tag = "Ekle";
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            txtSorumlu.Text = "";
            txtSorumlu.Tag = null;

            AV001_TDIE_BIL_BELGE belge = ((AV001_TDIE_BIL_BELGE)c_bndBelge.Current);
            if (c_lueDosya.EditValue != null && belge != null)
            {
                try
                {
                    if (c_lueModul.EditValue != null && c_lueModul.EditValue != DBNull.Value)
                        ModulID = Convert.ToInt32(c_lueModul.EditValue);
                    switch (ModulID)
                    {
                        #region Soruþturma Modülünün Belge Kayýt Ekranýna Taraf Bilgilerini Getirmesi (ARCH)

                        case 3:
                            OpenedRecord = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)c_lueDosya.EditValue);

                            eSAS_NOTextEdit1.EditValue = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).HAZIRLIK_ESAS_NO;
                            belge.ESAS_NO = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).HAZIRLIK_ESAS_NO;

                            c_lueAdliye.EditValue = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad((AV001_TD_BIL_HAZIRLIK)OpenedRecord, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>), typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();//control
                            foreach (var item in ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                            {
                                AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                trf.CARI_ID = item.CARI_ID;
                                trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                trf.KODU = Convert.ToByte(item.TARAF_KODU);
                                belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);


                            }
                            foreach (var item in ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).AV001_TD_BIL_HAZIRLIK_SORUMLUCollection)
                            {
                                AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                                trf.CARI_ID = item.CARI_ID;
                                trf.IS_TARAF_ID = 2;
                                aV001TDIBILISTARAFCollectionBindingSource.Add(trf);
                            }
                            ucTaraf1.Record = belge;
                            break;

                        #endregion Soruþturma Modülünün Belge Kayýt Ekranýna Taraf Bilgilerini Getirmesi (ARCH)

                        case 2:
                            OpenedRecord = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);

                            eSAS_NOTextEdit1.EditValue = ((AV001_TD_BIL_FOY)OpenedRecord).ESAS_NO;
                            belge.ESAS_NO = ((AV001_TD_BIL_FOY)OpenedRecord).ESAS_NO;

                            c_lueAdliye.EditValue = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_FOY)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad((AV001_TD_BIL_FOY)OpenedRecord, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();
                            foreach (var item in ((AV001_TD_BIL_FOY)OpenedRecord).AV001_TD_BIL_FOY_TARAFCollection)
                            {
                                //if (item.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.DAVACI)
                                //{
                                AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                trf.CARI_ID = item.CARI_ID;
                                trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                trf.KODU = Convert.ToByte(item.TARAF_KODU);
                                belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                                //}
                                //if (item.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.DAVALI)
                                //{
                                //    AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                //    trf.CARI_ID = item.CARI_ID;
                                //    trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                //    trf.KODU = Convert.ToByte(item.TARAF_KODU);
                                //    belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                                //}
                            }
                            foreach (var item in ((AV001_TD_BIL_FOY)OpenedRecord).AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                                trf.CARI_ID = item.SORUMLU_AVUKAT_CARI_ID;
                                trf.IS_TARAF_ID = 2;
                                aV001TDIBILISTARAFCollectionBindingSource.Add(trf);
                            }
                            ucTaraf1.Record = belge;

                            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad((AV001_TD_BIL_FOY)OpenedRecord, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
                            if (((AV001_TD_BIL_FOY)OpenedRecord).AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
                            {
                                try
                                {
                                    txtSorumlu.Tag = ((AV001_TD_BIL_FOY)OpenedRecord).AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID;
                                    txtSorumlu.Text = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)txtSorumlu.Tag).AD;
                                }
                                catch { ;}
                            }
                            break;

                        case 1:
                            OpenedRecord = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);

                            eSAS_NOTextEdit1.EditValue = ((AV001_TI_BIL_FOY)OpenedRecord).ESAS_NO;
                            belge.ESAS_NO = ((AV001_TI_BIL_FOY)OpenedRecord).ESAS_NO;

                            c_lueAdliye.EditValue = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TI_BIL_FOY)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad((AV001_TI_BIL_FOY)OpenedRecord, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();
                            foreach (var item in ((AV001_TI_BIL_FOY)OpenedRecord).AV001_TI_BIL_FOY_TARAFCollection)
                            {

                                AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                trf.CARI_ID = item.CARI_ID;
                                trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                trf.KODU = Convert.ToByte(item.TARAF_KODU);
                                belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);

                            }
                            foreach (var item in ((AV001_TI_BIL_FOY)OpenedRecord).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                            {
                                AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                                trf.CARI_ID = item.SORUMLU_AVUKAT_CARI_ID;
                                trf.IS_TARAF_ID = 2;
                                aV001TDIBILISTARAFCollectionBindingSource.Add(trf);
                            }
                            ucTaraf1.Record = belge;

                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad((AV001_TI_BIL_FOY)OpenedRecord, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                            if (((AV001_TI_BIL_FOY)OpenedRecord).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
                            {
                                try
                                {
                                    txtSorumlu.Tag = ((AV001_TI_BIL_FOY)OpenedRecord).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID;
                                    txtSorumlu.Text = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)txtSorumlu.Tag).AD;
                                }
                                catch { ;}
                            }

                            break;

                        case 12:
                            OpenedRecord =
                                DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TDI_BIL_TEMSIL)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad((AV001_TDI_BIL_TEMSIL)OpenedRecord,
                                                                                 false, DeepLoadType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList<AV001_TDI_BIL_TEMSIL_TARAF>), typeof(
                                                                                     TList<AV001_TDI_BIL_TEMSIL_AVUKAT>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();
                            foreach (
                                var item in ((AV001_TDI_BIL_TEMSIL)OpenedRecord).AV001_TDI_BIL_TEMSIL_TARAFCollection)
                            {
                                AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                trf.CARI_ID = item.TARAF_CARI_ID;
                                belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                            }
                            foreach (var item in ((AV001_TDI_BIL_TEMSIL)OpenedRecord).AV001_TDI_BIL_TEMSIL_AVUKATCollection)
                            {
                                AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                                trf.CARI_ID = item.AVUKAT_CARI_ID;
                                trf.IS_TARAF_ID = 2;
                                aV001TDIBILISTARAFCollectionBindingSource.Add(trf);
                            }
                            ucTaraf1.Record = belge;//ARCH
                            break;

                        case 5:
                            OpenedRecord =
                                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).ADLI_BIRIM_GOREV_ID;

                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(
                                (AV001_TDI_BIL_SOZLESME)OpenedRecord, false, DeepLoadType.IncludeChildren,
                                typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>));
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Clear();
                            foreach (
                                var item in
                                    ((AV001_TDI_BIL_SOZLESME)OpenedRecord).AV001_TDI_BIL_SOZLESME_TARAFCollection)
                            {
                                AV001_TDIE_BIL_BELGE_TARAF trf = new AV001_TDIE_BIL_BELGE_TARAF();
                                trf.CARI_ID = item.CARI_ID;
                                trf.SIFAT_ID = item.TARAF_SIFAT_ID;
                                trf.KODU = Convert.ToByte(item.TARAF_KODU);
                                belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Add(trf);
                            }
                            foreach (var item in ((AV001_TDI_BIL_SOZLESME)OpenedRecord).AV001_TDI_BIL_SOZLESME_SORUMLUCollection)
                            {
                                AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                                trf.CARI_ID = item.SORUMLU_CARI_ID;
                                trf.IS_TARAF_ID = 2;
                                aV001TDIBILISTARAFCollectionBindingSource.Add(trf);
                            }
                            ucTaraf1.Record = belge;//ARCH

                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad((AV001_TDI_BIL_SOZLESME)OpenedRecord, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>));
                            if (((AV001_TDI_BIL_SOZLESME)OpenedRecord).AV001_TDI_BIL_SOZLESME_SORUMLUCollection.Count > 0)
                            {
                                try
                                {
                                    txtSorumlu.Tag = ((AV001_TDI_BIL_SOZLESME)OpenedRecord).AV001_TDI_BIL_SOZLESME_SORUMLUCollection[0].SORUMLU_CARI_ID;
                                    txtSorumlu.Text = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)txtSorumlu.Tag).AD;
                                }
                                catch { ;}
                            }
                            break;

                        case 13:
                            OpenedRecord =
                                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID =
                                ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID =
                                ((AV001_TI_BIL_HACIZ_MASTER)OpenedRecord).HM_ADLI_BIRIM_GOREV_ID;
                            ucTaraf1.Record = belge;//ARCH
                            break;

                        case 14:
                            OpenedRecord =
                                DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID =
                                ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID =
                                ((AV001_TI_BIL_SATIS_MASTER)OpenedRecord).SM_ADLI_BIRIM_GOREV_ID;
                            ucTaraf1.Record = belge;//ARCH
                            break;

                        case 15:
                            OpenedRecord = DataRepository.AV001_TD_BIL_CELSEProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.EditValue = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_ADLIYE_ID;
                            belge.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_ADLIYE_ID;

                            c_lueBirimNo.EditValue = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_NO_ID;
                            belge.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_NO_ID;

                            c_leuGorev.EditValue = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_GOREV_ID;
                            belge.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_CELSE)OpenedRecord).DavaADLI_BIRIM_GOREV_ID;
                            ucTaraf1.Record = belge;//ARCH
                            break;

                        case 16:
                            OpenedRecord =
                                DataRepository.AV001_TDI_BIL_FATURAProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.Enabled = true;
                            c_lueBirimNo.Enabled = true;
                            c_leuGorev.Enabled = true;
                            break;

                        case 17:
                            OpenedRecord =
                                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID((int)c_lueDosya.EditValue);
                            c_lueAdliye.Enabled = true;
                            c_lueBirimNo.Enabled = true;
                            c_leuGorev.Enabled = true;
                            break;

                        case 11:
                            OpenedRecord =
                                DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID((int)c_lueDosya.EditValue);
                            break;

                        default:

                            break;
                    }
                    c_lueModul.Enabled = true;
                    c_lueDosya.Enabled = true;

                    #region <MB-20100621>

                    //ÝBB bu alanlarýn deðiþtirilebilir olmasýný talep ettiði için disable iþlemi kaldýrýldý.
                    //if (ModulID != 16 || ModulID != 17)
                    //{
                    //c_lueAdliye.Enabled = false;
                    //c_lueBirimNo.Enabled = false;
                    //c_leuGorev.Enabled = false;
                    //eSAS_NOTextEdit1.Enabled = false;
                    //}

                    #endregion <MB-20100621>
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            xtraTabPage4.PageVisible = chkYapilacakIs.Checked;
        }
        private void chkYapilacakIs_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkYapilacakIs.Checked)
            {
                xtraTabPage4.PageVisible = true;
                chkMail.Checked = true;
                checkEdit1.Checked = true;
                hATIRLATILSIN_MICheckEdit.Checked = true;
            }
            else
                xtraTabPage4.PageVisible = false;
        }
        private void dOSYA_ADITextEdit1_TextChanged(object sender, EventArgs e)
        {
            //if (dOSYA_ADITextEdit1.Text == string.Empty)
            //{
            //    return;
            //}
            //try
            //{
            //    if (Current.ICERIK == null)
            //    {
            //        Current.ICERIK = Tools.GetBytesFromFile(dOSYA_ADITextEdit1.Text);
            //string[] names = dOSYA_ADITextEdit1.Text.Split('.');
            //if (names.Length > 1)
            //{
            //    Current.DOKUMAN_UZANTI = names[names.Length - 1];
            //}
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show("Dosya okuma esnasýnda hatalar oluþtu....");
            //}
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void hATIRLATILSIN_MICheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = hATIRLATILSIN_MICheckEdit.Checked;
            durationEdit1.SelectedIndex = 0;
        }

        private void LookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (c_lueModul.Text == "Icra")
            //    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            //else if (c_lueModul.Text == "Dava")
            //    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            //else if (c_lueModul.Text == "Soruþturma")
            //    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            //else if (c_lueModul.Text == "Sözleþme")
            //    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);

            //c_lueDosya.Enabled = true;
        }

        private void lueOzelKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
        }

        private void setKayitSayisi()
        {
            if (c_bndBelge.Count > 1)
                c_bndBelge.RemoveAt(1);
            kayitSayisi = this.c_bndBelge.Count;
        }

        private void ucBelgeKayitUfak_Load(object sender, EventArgs e)
        {
            this.OnNew += ucBelgeKayitUfak_OnNew;
            IsLoaded = true;
            bASLANGIC_TARIHIDateEdit.DateTime = DateTime.Today;
            oNGORULEN_BITIS_TARIHIDateEdit.DateTime = DateTime.Today.AddDays(1);
            if (DesignMode)
            {
                return;
            }
            if (this.MyDataSource == null || !(this.MyDataSource is TList<AV001_TDIE_BIL_BELGE>))
            {
                this.MyDataSource = new TList<AV001_TDIE_BIL_BELGE>();
            }

            setKayitSayisi();

            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(c_lueAdliye);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(c_lueBirimNo);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(c_leuGorev.Properties);
            AvukatPro.Services.Implementations.DevExpressService.BelgeTuruDoldur(c_lueBelgeTur.Properties);

            BindOzelKod();
            c_lueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            c_lueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            c_lueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            c_lueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);

            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(this.repositoryItemLookUpEdit2);
            BelgeUtil.Inits.IsTarafGetir(this.repositoryItemLookUpEdit1);
            AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(c_lueModul.Properties, null);

            aV001TDIBILISTARAFCollectionBindingSource.DataSource = new TList<AV001_TDI_BIL_IS_TARAF>();
            BindData();
            this.c_bndBelge.Position = Position;
            if (Duzenle)
            {
                xtraTabControl1.Enabled = true;
                c_btnYeni.Enabled = false;
                c_btnKaydet.Enabled = true;
            }

            xtraTabControl1.Enabled = true;
            c_btnYeni.Enabled = false;
            c_btnYeni.Visible = false;
            c_btnKaydet.Enabled = true;
            NewRecord();
            c_lueDosya.Properties.NullText = "Dosya Seçiniz";
            //c_lueDosya.EditValue = 1074;

            //c_lueModul.EditValue = ModulID;

            if (MyDataSource != null && MyDataSource.Count > 0)
            {
                try
                {
                    txtSorumlu.Tag = MyDataSource[0].BELGEYI_YAZAN_ID;
                    txtSorumlu.Text = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(MyDataSource[0].BELGEYI_YAZAN_ID.Value).AD;
                }
                catch { ;}
            }

            AV001_TDIE_BIL_BELGE bel = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(((AV001_TDIE_BIL_BELGE)c_bndBelge.Current).ID);
            if (bel != null)
            {
                if (bel.ADLI_BIRIM_ADLIYE_ID.HasValue)
                {
                    c_lueAdliye.EditValue = bel.ADLI_BIRIM_ADLIYE_ID.Value;
                    MyDataSource[0].ADLI_BIRIM_ADLIYE_ID = bel.ADLI_BIRIM_ADLIYE_ID.Value;
                }
                if (bel.ADLI_BIRIM_GOREV_ID.HasValue)
                {
                    c_leuGorev.EditValue = bel.ADLI_BIRIM_GOREV_ID.Value;
                    MyDataSource[0].ADLI_BIRIM_GOREV_ID = bel.ADLI_BIRIM_GOREV_ID.Value;
                }
                if (bel.ADLI_BIRIM_NO_ID.HasValue)
                {
                    c_lueBirimNo.EditValue = bel.ADLI_BIRIM_NO_ID.Value;
                    MyDataSource[0].ADLI_BIRIM_NO_ID = bel.ADLI_BIRIM_NO_ID.Value;
                }
                if (!string.IsNullOrEmpty(bel.ESAS_NO))
                {
                    eSAS_NOTextEdit1.EditValue = bel.ESAS_NO;
                    MyDataSource[0].ESAS_NO = bel.ESAS_NO;
                }

            }
            if (FileName.Count > 0)
            {
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(FileName[0]);
                dOSYA_ADITextEdit1.EditValue = string.Join(",", FileName.Select(q => Path.GetFileName(q)).ToArray());
            }

            oZEL_KOD_1_IDLabel1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
            oZEL_KOD_2_IDLabel1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
            oZEL_KOD_3_IDLabel1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
            oZEL_KOD_4_IDLabel1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;

        }
        private void ucBelgeKayitUfak_OnNew(AV001_TDIE_BIL_BELGE belge, object sender)
        {
        }

        public class BelgeKaydedildiEventArgs : EventArgs
        {
            public BelgeKaydedildiEventArgs(AV001_TDIE_BIL_BELGE belge)
            {
                Belge = belge;
            }

            public AV001_TDIE_BIL_BELGE Belge { get; set; }
        }

        //private void simpleButton2_Click(object sender, EventArgs e)
        //{

        //}

        //private void simpleButton3_Click(object sender, EventArgs e)
        //{
        //}

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (FileName.Count > 0)
            {
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(FileName[0]);
            }
            openFileDialog1.ShowDialog();

            dOSYA_ADITextEdit1.Text = string.Join(",", openFileDialog1.FileNames.Select(q => Path.GetFileName(q)).ToArray());
            Current.DOSYA_ADI = openFileDialog1.FileName;
        }

        private void dOSYA_ADITextEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dOSYA_ADITextEdit1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dOSYA_ADITextEdit1_Click(object sender, EventArgs e)
        {

        }

        private void c_lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (c_lueModul.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (c_lueModul.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (c_lueModul.Text == "Soruþturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (c_lueModul.Text == "Sözleþme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);

            c_lueDosya.Enabled = true;
        }


        //private void c_lueOzelKod1_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
        //    {
        //        try
        //        {
        //            LookUpEdit lue = sender as LookUpEdit;
        //            AV001_TDIE_KOD_OZEL_KOD Ozel_Kod = new AV001_TDIE_KOD_OZEL_KOD();
        //            if (!string.IsNullOrEmpty(lue.Text))
        //            {
        //                Ozel_Kod.KOD = lue.Text;
        //                DataRepository.AV001_TDIE_KOD_OZEL_KODProvider.DeepSave(Ozel_Kod);
        //            }
        //            (c_lueOzelKod1.Properties.DataSource as VList<per_AV001_TDIE_KOD_OZEL_KOD>).Add(BelgeUtil.Inits.GetBelgeOzelKodViewItem(Ozel_Kod));
        //            XtraMessageBox.Show("Özel Kod Kaydý Baþarýyla Tamamlanmýþtýr");
        //        }
        //        catch
        //        {
        //            XtraMessageBox.Show("Kayýt Esnasýnda Bir hata Olmuþtur");
        //        }
        //    }
        //}

        //private void c_lueOzelKod2_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
        //    {
        //        try
        //        {
        //            LookUpEdit lue = sender as LookUpEdit;
        //            AV001_TDIE_KOD_OZEL_KOD Ozel_Kod = new AV001_TDIE_KOD_OZEL_KOD();

        //            if (!string.IsNullOrEmpty(lue.Text))
        //            {
        //                Ozel_Kod.KOD = lue.Text;
        //                DataRepository.AV001_TDIE_KOD_OZEL_KODProvider.DeepSave(Ozel_Kod);
        //            }
        //            (c_lueOzelKod2.Properties.DataSource as VList<per_AV001_TDIE_KOD_OZEL_KOD>).Add(BelgeUtil.Inits.GetBelgeOzelKodViewItem(Ozel_Kod));
        //            XtraMessageBox.Show("Özel Kod Kaydý Baþarýyla Tamamlanmýþtýr");
        //        }
        //        catch
        //        {
        //            XtraMessageBox.Show("Kayýt Esnasýnda Bir hata Olmuþtur");
        //        }
        //    }
        //}

        //private void c_lueOzelKod3_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
        //    {
        //        try
        //        {
        //            LookUpEdit lue = sender as LookUpEdit;
        //            AV001_TDIE_KOD_OZEL_KOD Ozel_Kod = new AV001_TDIE_KOD_OZEL_KOD();
        //            if (!string.IsNullOrEmpty(lue.Text))
        //            {
        //                Ozel_Kod.KOD = lue.Text;
        //                DataRepository.AV001_TDIE_KOD_OZEL_KODProvider.DeepSave(Ozel_Kod);
        //            }
        //            (c_lueOzelKod3.Properties.DataSource as VList<per_AV001_TDIE_KOD_OZEL_KOD>).Add(BelgeUtil.Inits.GetBelgeOzelKodViewItem(Ozel_Kod));

        //            XtraMessageBox.Show("Özel Kod Kaydý Baþarýyla Tamamlanmýþtýr");
        //        }
        //        catch
        //        {
        //            XtraMessageBox.Show("Kayýt Esnasýnda Bir hata Olmuþtur");
        //        }
        //    }
        //}

        //private void c_lueOzelKod4_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
        //    {
        //        try
        //        {
        //            LookUpEdit lue = sender as LookUpEdit;
        //            AV001_TDIE_KOD_OZEL_KOD Ozel_Kod = new AV001_TDIE_KOD_OZEL_KOD();
        //            if (!string.IsNullOrEmpty(lue.Text))
        //            {
        //                Ozel_Kod.KOD = lue.Text;
        //                DataRepository.AV001_TDIE_KOD_OZEL_KODProvider.DeepSave(Ozel_Kod);
        //            }
        //            (c_lueOzelKod4.Properties.DataSource as VList<per_AV001_TDIE_KOD_OZEL_KOD>).Add(BelgeUtil.Inits.GetBelgeOzelKodViewItem(Ozel_Kod));
        //            XtraMessageBox.Show("Özel Kod Kaydý Baþarýyla Tamamlanmýþtýr");
        //        }
        //        catch
        //        {
        //            XtraMessageBox.Show("Kayýt Esnasýnda Bir hata Olmuþtur");
        //        }
        //    }
        //}

        //private void c_lueOzelKod1_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    try
        //    {
        //        LookUpEdit lue = sender as LookUpEdit;
        //        AV001_TDIE_KOD_OZEL_KOD Ozel_Kod = new AV001_TDIE_KOD_OZEL_KOD();
        //        if (!string.IsNullOrEmpty(lue.Text))
        //        {
        //            Ozel_Kod.KOD = lue.Text;
        //            DataRepository.AV001_TDIE_KOD_OZEL_KODProvider.DeepSave(Ozel_Kod);

        //            (c_lueOzelKod1.Properties.DataSource as VList<per_AV001_TDIE_KOD_OZEL_KOD>).Add(BelgeUtil.Inits.GetBelgeOzelKodViewItem(Ozel_Kod));
        //            XtraMessageBox.Show("Özel Kod Kaydý Baþarýyla Tamamlanmýþtýr");
        //        }
        //    }
        //    catch
        //    {
        //        XtraMessageBox.Show("Kayýt Esnasýnda Bir hata Olmuþtur");
        //    }
        //}

        //private void c_lueOzelKod2_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    try
        //    {
        //        LookUpEdit lue = sender as LookUpEdit;
        //        AV001_TDIE_KOD_OZEL_KOD Ozel_Kod = new AV001_TDIE_KOD_OZEL_KOD();
        //        if (!string.IsNullOrEmpty(lue.Text))
        //        {
        //            Ozel_Kod.KOD = lue.Text;
        //            DataRepository.AV001_TDIE_KOD_OZEL_KODProvider.DeepSave(Ozel_Kod);

        //            (c_lueOzelKod2.Properties.DataSource as VList<per_AV001_TDIE_KOD_OZEL_KOD>).Add(BelgeUtil.Inits.GetBelgeOzelKodViewItem(Ozel_Kod));
        //            XtraMessageBox.Show("Özel Kod Kaydý Baþarýyla Tamamlanmýþtýr");
        //        }
        //    }
        //    catch
        //    {
        //        XtraMessageBox.Show("Kayýt Esnasýnda Bir hata Olmuþtur");
        //    }
        //}

        //private void c_lueOzelKod3_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    try
        //    {
        //        LookUpEdit lue = sender as LookUpEdit;
        //        AV001_TDIE_KOD_OZEL_KOD Ozel_Kod = new AV001_TDIE_KOD_OZEL_KOD();
        //        if (!string.IsNullOrEmpty(lue.Text))
        //        {
        //            Ozel_Kod.KOD = lue.Text;
        //            DataRepository.AV001_TDIE_KOD_OZEL_KODProvider.DeepSave(Ozel_Kod);

        //            (c_lueOzelKod3.Properties.DataSource as VList<per_AV001_TDIE_KOD_OZEL_KOD>).Add(BelgeUtil.Inits.GetBelgeOzelKodViewItem(Ozel_Kod));
        //            XtraMessageBox.Show("Özel Kod Kaydý Baþarýyla Tamamlanmýþtýr");
        //        }
        //    }
        //    catch
        //    {
        //        XtraMessageBox.Show("Kayýt Esnasýnda Bir hata Olmuþtur");
        //    }
        //}

        //private void c_lueOzelKod4_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        //{
        //    try
        //    {
        //        LookUpEdit lue = sender as LookUpEdit;
        //        AV001_TDIE_KOD_OZEL_KOD Ozel_Kod = new AV001_TDIE_KOD_OZEL_KOD();
        //        if (!string.IsNullOrEmpty(lue.Text))
        //        {
        //            Ozel_Kod.KOD = lue.Text;
        //            DataRepository.AV001_TDIE_KOD_OZEL_KODProvider.DeepSave(Ozel_Kod);
        private void OfficeClear()
        {
            try
            {
                Process[] workers = Process.GetProcessesByName("EXCEL");
                foreach (Process worker in workers)
                {
                    worker.Kill();
                    worker.WaitForExit();
                    worker.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}