using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.PaketKontrol;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucAlacakNedenGirisi : AvpXUserControl
    {
        public ucAlacakNedenGirisi()
        {
            InitializeComponent();
        }

        public bool isFoyNew = false;

        [Category("AlacakNeden")]
        public bool TakipsizAlacakMi { get; set; }

        private AV001_TI_BIL_FOY _foy;

        [Browsable(false)]
        public AV001_TI_BIL_FOY Foy
        {
            get { return _foy; }
            set
            {
                _foy = value;
                if (value != null && !this.DesignMode)
                {
                    if (Foy.TAKIP_TALEP_ID.HasValue && rlkAlacakNeden.DataSource != null)
                    {
                        ((rlkAlacakNeden.DataSource) as VList<per_TI_KOD_ALACAK_NEDEN>).Filter =
                            "TAKIP_TALEP_KOD_ID = " + Foy.TAKIP_TALEP_ID.Value;

                        #region <CC-20090616>

                        // nereden çaðýrýlýrsa çaðýrýlsýn Tagý H yani mutlaka görüleceklerin görünmesi için böle bir metot yazýlmýþtýr.
                        Sekillen();

                        #endregion</CC-20090616>
                    }
                }
            }
        }

        private int FormTip;
        public bool FormdaMi;

        private void Sekillen()
        {
            if (Foy.FORM_TIP_ID == null)
                Foy.FORM_TIP_ID = (int)FormTipleri.Form49;
            if (Foy.TAKIP_TALEP_ID == null)
                Foy.TAKIP_TALEP_ID = (int)TakipTalep.ADI_ALACAK_49;
            FormTip = Foy.FORM_TIP_ID.Value;
            string fTip = Foy.FORM_TIP_ID.Value.ToString();
            string tTalep = Foy.TAKIP_TALEP_ID.HasValue ? Foy.TAKIP_TALEP_ID.Value.ToString() : string.Empty;
            string I = string.Empty;
            if (fTip == "4" && tTalep == "7")
                I = "I";
            foreach (BaseRow row in RowGetir(vgAlacakNedenGirisi.Rows))
            {
                row.Visible = false;
            }
            foreach (BaseRow row in RowGetir(vgAlacakNedenGirisi.Rows))
            {
                string k = string.Empty;
                if (row.Tag != null)
                {
                    k = row.Tag.ToString();
                    if (k.ToLower() != "h")
                    {
                        List<string> degiskenler =
                            new List<string>(k.Split(new[] { '|' }, StringSplitOptions.None));
                        List<string> formTipleri =
                            new List<string>(degiskenler[0].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                        List<string> takipTalepleri =
                            new List<string>(degiskenler[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                        if (formTipleri.Contains(fTip))
                        {
                            row.Visible = true;
                        }
                        if (takipTalepleri.Contains(tTalep))
                        {
                            row.Visible = true;
                        }
                        if (takipTalepleri.Contains(I))
                        {
                            row.Visible = true;
                        }
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
            this.GetPaketForm();
        }

        private List<BaseRow> RowGetir(VGridRows mRows)
        {
            List<BaseRow> result = new List<BaseRow>();
            foreach (BaseRow row in mRows)
            {
                result.Add(row);
                result.AddRange(RowGetir(row.ChildRows));
            }
            return result;
        }

        [Browsable(false)]
        public int RecordIndex
        {
            get { return vgAlacakNedenGirisi.FocusedRecord; }
        }


        private TList<AV001_TI_BIL_FOY_TARAF> myIcraTaraf;

        public TList<AV001_TI_BIL_FOY_TARAF> MyIcraTaraf
        {
            get { return myIcraTaraf; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myIcraTaraf = value;
                }
            }
        }

        private TList<AV001_TI_BIL_ALACAK_NEDEN> _DtAlacakNeden;

        public TList<AV001_TI_BIL_ALACAK_NEDEN> DtAlacakNeden
        {
            get { return _DtAlacakNeden; }
            set
            {
                _DtAlacakNeden = value;
                if (value != null && IsLoaded)
                {
                    bndAlacakNeden.DataSource = value;

                    value.AddingNew += alacaklar_AddingNew;
                    dataNavigatorExtended1.DataSource = bndAlacakNeden;

                    #region <CC-20090616>

                    // nereden çaðýrýlýrsa çaðýrýlsýn Tagý H yani mutlaka görüleceklerin görünmesi için böle bir metot yazýlmýþtýr.
                    if (Foy != null)
                        Sekillen();

                    #endregion</CC-20090616>
                }
            }
        }

        public void AlacakNedenYapilandir()
        {
            foreach (BaseRow row in vgAlacakNedenGirisi.Rows)
            {
                if (row.Name == "AlacakNeden")
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void vgAlacakNedenGirisi_DataSourceChanged(object sender, EventArgs e)
        {
            dataNavigatorExtended1.DataSource = bndAlacakNeden;
        }

        private void InitsDoldur()
        {
            //rLueMuhatap.NullText = "Seç";
            //rlkDoviz.NullText = "Seç";
            //rlkFaizTipi.NullText = "Seç";
            //rlkDovizIslemTipi.NullText = "Seç";
            //rlkKdvTipi.NullText = "Seç";
            //rlkAlacakNeden.NullText = "Seç";
            //rlkAlacakNeden.NullText = "Seç";
            BelgeUtil.Inits.FaizTipiGetir(rlkFaizTipi);
            BelgeUtil.Inits.IcraDovizIslemTipiGetir(rlkDovizIslemTipi);
            BelgeUtil.Inits.KDVTipGetir(rlkKdvTipi);
            BelgeUtil.Inits.ParaBicimiAyarla(rudParalar);
            BelgeUtil.Inits.ParaBicimiAyarla(rudPara1);
            BelgeUtil.Inits.YuzdeBicimiAyarla(rudOranlar);
            BelgeUtil.Inits.YuzdeBicimiAyarla(rudOran1);
            BelgeUtil.Inits.YuzdeBicimiAyarla(rudKomisyonuOrani1);
            BelgeUtil.Inits.YuzdeBicimiAyarla(rudCekTazminatiOrani1);
            BelgeUtil.Inits.DovizTipGetir(rlkDoviz);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueMuhatap, null);

            if (isFoyNew)
            {
                //rLueMuhatap.Enter += delegate { BelgeUtil.Inits.perCariGetir(); };
                if (!TakipsizAlacakMi)
                    rlkAlacakNeden.Enter += delegate { BelgeUtil.Inits.AlacakNedenKodGetir(rlkAlacakNeden); };
                else
                    rlkAlacakNeden.Enter += delegate { BelgeUtil.Inits.AlacakNedenKodGetir(rlkAlacakNeden, true); };
            }
            else
            {
                //BelgeUtil.Inits.perCariGetir(rLueMuhatap);
                if (!TakipsizAlacakMi)
                    BelgeUtil.Inits.AlacakNedenKodGetir(rlkAlacakNeden);
                else
                    BelgeUtil.Inits.AlacakNedenKodGetir(rlkAlacakNeden, true);
            }
        }

        private void ucAlacakNedenGirisi_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                IsLoaded = true;
                bndAlacakNeden.DataSource = DtAlacakNeden;
                vgAlacakNedenGirisi.DataSource = bndAlacakNeden;
                extendedGridControl1.DataSource = bndAlacakNeden;
                dataNavigatorExtended1.DataSource = bndAlacakNeden;
                compVGridRecordCopy1.MyVGridControl = vgAlacakNedenGirisi;
                compGridRowCopy1.MyGridControl = extendedGridControl1;

                mrowHerAyaTazminatEkle.Visible = false;
                vgAlacakNedenGirisi.DataSourceChanged += vgAlacakNedenGirisi_DataSourceChanged;

                InitsDoldur();

                #region Ozellestirme

                if (mrowRef1Ref2Ref3.PropertiesCollection["REFERANS_NO"] != null)
                    mrowRef1Ref2Ref3.PropertiesCollection["REFERANS_NO"].Caption =
                        Kimlikci.Kimlik.IcraAnReferans.Referans1;
                if (mrowRef1Ref2Ref3.PropertiesCollection["REFERANS_NO2"] != null)
                    mrowRef1Ref2Ref3.PropertiesCollection["REFERANS_NO2"].Caption =
                        Kimlikci.Kimlik.IcraAnReferans.Referans2;
                if (mrowRef1Ref2Ref3.PropertiesCollection["REFERANS_NO3"] != null)
                    mrowRef1Ref2Ref3.PropertiesCollection["REFERANS_NO3"].Caption =
                        Kimlikci.Kimlik.IcraAnReferans.Referans3;
                if (gridView1.Columns["REFERANS_NO"] != null)
                {
                    gridView1.Columns["REFERANS_NO"].Caption = Kimlikci.Kimlik.IcraAnReferans.Referans1;
                }
                if (gridView1.Columns["REFERANS_NO2"] != null)
                {
                    gridView1.Columns["REFERANS_NO2"].Caption = Kimlikci.Kimlik.IcraAnReferans.Referans2;
                }
                if (gridView1.Columns["REFERANS_NO3"] != null)
                {
                    gridView1.Columns["REFERANS_NO3"].Caption = Kimlikci.Kimlik.IcraAnReferans.Referans3;
                }

                #endregion
            }
        }

        public void RefreshDataSource()
        {
            //TODO:Icradosya kayýtta burda bir patlama oluþtu [YILMAZ]
            try
            {
                vgAlacakNedenGirisi.Refresh();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Alacak neden deðiþtiðinde patlayan event
        /// </summary>

        #region AlacakNedenEvents

        [Category("AlacakNeden")]
        public event ChangingEventHandler AlacakNedenChanging;

        private void rLueAlacakNeden_EditValueChanging(object sender,
                                                       DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (AlacakNedenChanging != null)
            {
                AlacakNedenChanging(sender, e);
            }
        }


        private void dataNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Prev || e.Button.ButtonType == NavigatorButtonType.Next)
            {
                this.CurrentNeden.IsSelected = this.CurrentNeden.IsSelected;
            }
        }

        [Category("AlacakNeden")]
        public event IndexChangedEventHandler FocusedNedenChanged;

        /// <summary>
        /// <gkn>Form Alanlarýnýn Þekillenmesi</gkn>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void vgAlacakNedenGirisi_FocusedRecordChanged(object sender,
                                                             DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (FocusedNedenChanged != null)
            {
                if (vgAlacakNedenGirisi.LayoutStyle == DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView)
                {
                    if (CurrentNeden != null)
                        if (CurrentNeden.ALACAK_NEDEN_KOD_ID.HasValue && CurrentNeden.ALACAK_NEDEN_KOD_ID.Value > 0)
                        {
                            //CurrentNeden.ALACAK_NEDEN_KOD_IDSource == null &&
                            if (!CurrentNeden.IsNew)
                            {
                                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.
                                    DeepLoad(CurrentNeden, true, DeepLoadType.IncludeChildren,
                                             typeof(TI_KOD_ALACAK_NEDEN));
                            }
                            else if (CurrentNeden.IsNew)
                            {
                                CurrentNeden.ALACAK_NEDEN_KOD_IDSource =
                                    DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(
                                        CurrentNeden.ALACAK_NEDEN_KOD_ID.Value);
                            }
                            mrowHerAyaTazminatEkle.Visible = false;
                            mRowTazmin.Visible = false;
                            rowDuzenleme_Vade_T.Properties.Row.GetRowProperties(1).Caption = "Vade T.";
                            switch (CurrentNeden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI)
                            {
                                #region case

                                case "ÇEK":

                                    #region ÇEK

                                    rowDuzenlemeT.Visible = true;
                                    rowMuhatap.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    rowKomisyonOrani.Visible = true;
                                    rowCekTazminatOrani.Visible = true;
                                    rowFAIZ_YOK.Visible = true;
                                    KDV_KDVTIP.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    OIV.Visible = false;
                                    mrowProtestoGideri.Visible = true;
                                    rowIHTAR_TARIHI.Visible = false;
                                    IhtarGidParaB.Visible = false;
                                    mRowDamgaPulu.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    mRowDigerAlacakNeden.Visible = false;
                                    // CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;
                                    int cekTazminatkod = DataRepository.TDI_KOD_TEMINAT_TAZMINATProvider.GetByTEMINAT_TAZMINAT_ADI("ÇEK TAZMÝNAT").ID;
                                    TList<TDI_CET_TEMINAT_TAZMINAT> cekTazminat = DataRepository.TDI_CET_TEMINAT_TAZMINATProvider.GetByKATEGORI_ID(cekTazminatkod);
                                    if (cekTazminat.Count > 0)
                                    {
                                        foreach (var item in cekTazminat)
                                        {
                                            if (item.TARIH <= CurrentNeden.VADE_TARIHI)
                                                CurrentNeden.CEK_TAZMINATI_ORANI = item.ORAN;
                                        }
                                        //a.CEK_TAZMINATI_ORANI = cekTazminat[0].ORAN;
                                    }
                                    else
                                        CurrentNeden.CEK_TAZMINATI_ORANI = 5;
                                    #endregion

                                    break;
                                case "SENET":

                                    #region Senet

                                    BSMV_KKDV.Visible = false;
                                    rowMuhatap.Visible = false;
                                    rowKomisyonOrani.Visible = true;
                                    rowFAIZ_YOK.Visible = true;
                                    rowCekTazminatOrani.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    OIV.Visible = false;
                                    mrowProtestoGideri.Visible = true;
                                    rowIHTAR_TARIHI.Visible = false;
                                    rowIHTAR_TARIHI.Visible = false;
                                    IhtarGidParaB.Visible = false;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "POLÝÇE":

                                    #region Poliçe

                                    BSMV_KKDV.Visible = true;
                                    rowMuhatap.Visible = false;
                                    KDV_KDVTIP.Visible = true;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    OIV.Visible = false;
                                    mrowProtestoGideri.Visible = true;
                                    rowIHTAR_TARIHI.Visible = false;
                                    IhtarGidParaB.Visible = false;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "SÖZLEÞME":

                                    #region Sözleþme

                                    BSMV_KKDV.Visible = true;
                                    rowMuhatap.Visible = false;
                                    KDV_KDVTIP.Visible = true;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    OIV.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = true;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "YÖNETÝM GÝDERÝ":

                                    #region Yönetim Gideri

                                    mrowHerAyaTazminatEkle.Visible = true;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                    OIV.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "BANKA KREDÝ ALACAÐI":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = true;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    OIV.Visible = true;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "TELEFON FATURASI":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    OIV.Visible = true;
                                    KDV_KDVTIP.Visible = true;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "BANKA KREDÝ KARTI":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = true;
                                    OIV.Visible = true;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "ÝPOTEK":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = true;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "MENKUL REHNÝ":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "ELEKTRÝK FATURASI":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = true;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "HASAR":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = true;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "KAÇAK ELEKTRÝK FATURASI":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    // CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "TESVÝYE":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    // CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "TESCÝL":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "TEFTÝÞ":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    // CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "DÝÐER ALACAK...":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                    OIV.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mRowDigerAlacakNeden.Visible = true;
                                    // CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;

                                    #endregion

                                    break;
                                case "MER`Ý TEMÝNAT MEKTUBU":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    OIV.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = true;
                                    mRowDepoSayisi.Visible = true;
                                    mRowTazmin.Visible = true;
                                    mrowIadeSayisi.GetRowProperties(0).ReadOnly = true;
                                    mRowDepoSayisi.GetRowProperties(0).ReadOnly = true;
                                    mRowTazmin.GetRowProperties(3).ReadOnly = true;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Tazmin T.";
                                    rowMuhatap.Visible = true;
                                    mRowDigerAlacakNeden.Visible = false;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;
                                    mRowTazmin.Visible = true;
                                    rowDuzenleme_Vade_T.Properties.Row.GetRowProperties(1).Caption = "Tazmin T.";

                                    #endregion

                                    break;

                                case "VADELÝ AKREDÝTÝF":
                                case "AVAL":
                                case "BANKA KEFALETÝ":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    OIV.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Tazmin T.";
                                    rowMuhatap.Visible = false;
                                    mRowDigerAlacakNeden.Visible = false;
                                    // CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;
                                    mRowTazmin.Visible = true;
                                    rowDuzenleme_Vade_T.Properties.Row.GetRowProperties(1).Caption = "Tazmin T.";

                                    #endregion

                                    break;
                                case "ÇEK YAPRAÐI":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowIadeSayisi.Visible = true;
                                    mRowDepoSayisi.Visible = true;
                                    mRowTazmin.Visible = true;
                                    OIV.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Tazmin T.";
                                    mRowDigerAlacakNeden.Visible = false;
                                    mrowCekSorumluluk.Visible = true;
                                    mrowHarcaEsasDeger.Visible = false;
                                    mRowTazmin.Visible = true;
                                    rowDuzenleme_Vade_T.Properties.Row.GetRowProperties(1).Caption = "Tazmin T.";

                                    #endregion

                                    break;
                                case "DÝÐER DEPO":

                                    #region

                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    rowMuhatap.Visible = false;
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = true;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    OIV.Visible = true;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Tazmin T.";
                                    mRowDigerAlacakNeden.Visible = true;
                                    // CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mrowHarcaEsasDeger.Visible = false;
                                    mRowTazmin.Visible = true;
                                    rowDuzenleme_Vade_T.Properties.Row.GetRowProperties(1).Caption = "Tazmin T.";

                                    #endregion

                                    break;
                                case "TAHLÝYE":

                                    mrowHarcaEsasDeger.Properties.Caption = "Yýllýk Kira Bedeli";
                                    foreach (BaseRow row in vgAlacakNedenGirisi.Rows)
                                    {
                                        if (row.Name == "AlacakNeden" || row.Name == "mrowHarcaEsasDeger" || row.Name == "rowIHTAR_TARIHI" || row.Name == "IhtarGidParaB" || row.Name == "mrowRef1Ref2Ref3" || row.Name == "rowAciklama")
                                        {
                                            row.Visible = true;
                                        }
                                        else
                                            row.Visible = false;
                                    }
                                    break;

                                case "MENKUL TESLÝMÝ":

                                    mrowHarcaEsasDeger.Properties.Caption = "Harca Esas Deðer";

                                    #region

                                    foreach (BaseRow row in vgAlacakNedenGirisi.Rows)
                                    {
                                        if (row.Name == "AlacakNeden" || row.Name == "mrowHarcaEsasDeger" || row.Name == "rowIHTAR_TARIHI" || row.Name == "IhtarGidParaB" || row.Name == "mrowRef1Ref2Ref3" || row.Name == "rowAciklama")
                                        {
                                            row.Visible = true;
                                        }
                                        else
                                            row.Visible = false;
                                    }

                                    //rowKomisyonOrani.Visible = false;
                                    //rowCekTazminatOrani.Visible = false;
                                    //rowMuhatap.Visible = false;
                                    //BSMV_KKDV.Visible = false;
                                    //KDV_KDVTIP.Visible = false;
                                    //OIV.Visible = false;
                                    //mrowHerAyaTazminatEkle.Visible = false;
                                    //mrowProtestoGideri.Visible = false;
                                    //rowIHTAR_TARIHI.Visible = true;
                                    //IhtarGidParaB.Visible = true;
                                    //mRowDamgaPulu.Visible = false;
                                    //rowDuzenlemeT.Visible = false;
                                    //mrowIadeSayisi.Visible = false;
                                    //mRowDepoSayisi.Visible = false;
                                    //mRowDigerAlacakNeden.Visible = false;
                                    //rowDuzenleme_Vade_T.Visible = false;
                                    //rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    //rowDovizIslemTipi.Visible = false;
                                    //mrowHarcaEsasDeger.Visible = false;
                                    //IsKonTut_Birim.Visible = false;
                                    //// CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    //mrowCekSorumluluk.Visible = false;

                                    #endregion

                                    break;
                                case "ÇOCUK TESLÝMÝ":
                                case "ÇOCUKLA ÝLÝÞKÝ TESÝSÝ":
                                    foreach (BaseRow row in vgAlacakNedenGirisi.Rows)
                                    {
                                        if (row.Name == "AlacakNeden" || row.Name == "rowAciklama")
                                        {
                                            row.Visible = true;
                                        }
                                        else
                                            row.Visible = false;
                                    }

                                    #region

                                    //BSMV_KKDV.Visible = false;
                                    //rowMuhatap.Visible = false;
                                    //KDV_KDVTIP.Visible = false;
                                    //OIV.Visible = false;
                                    //mrowHerAyaTazminatEkle.Visible = false;
                                    //mrowProtestoGideri.Visible = false;
                                    //rowIHTAR_TARIHI.Visible = false;
                                    //IhtarGidParaB.Visible = false;
                                    //mRowDamgaPulu.Visible = false;
                                    //rowDuzenlemeT.Visible = false;
                                    //mrowIadeSayisi.Visible = false;
                                    //mRowDepoSayisi.Visible = false;
                                    ////rowDuzenleme_Vade_T.Visible = false;
                                    //mRowDigerAlacakNeden.Visible = false;
                                    //rowDuzenleme_Vade_T.Visible = true;
                                    //rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    //mrowHarcaEsasDeger.Visible = false;
                                    //// CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    //mrowCekSorumluluk.Visible = false;

                                    #endregion

                                    break;
                                case "TAHLÝYE TAAHHÜDÜ":
                                    foreach (BaseRow row in vgAlacakNedenGirisi.Rows)
                                    {
                                        if (row.Name == "mrowHarcaEsasDeger")
                                            row.Properties.Caption = "Yýllýk Kira Bedeli";
                                        if (row.Name == "AlacakNeden" || row.Name == "mrowHarcaEsasDeger" || row.Name == "rowIHTAR_TARIHI" || row.Name == "IhtarGidParaB" || row.Name == "mrowRef1Ref2Ref3" || row.Name == "rowAciklama")
                                        {
                                            row.Visible = true;
                                        }
                                        else
                                            row.Visible = false;
                                    }
                                    break;
                                default:

                                    #region

                                    //rowDuzenlemeT.Visible = false;
                                    rowMuhatap.Visible = false;
                                    Tutar_Birim.Visible = true;
                                    rowKomisyonOrani.Visible = false;
                                    rowCekTazminatOrani.Visible = false;
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = true;
                                    OIV.Visible = false;
                                    mrowIadeSayisi.Visible = false;
                                    mRowDepoSayisi.Visible = false;
                                    mrowHerAyaTazminatEkle.Visible = false;
                                    mrowProtestoGideri.Visible = false;
                                    rowIHTAR_TARIHI.Visible = true;
                                    IhtarGidParaB.Visible = true;
                                    mRowDamgaPulu.Visible = false;
                                    rowDuzenlemeT.Visible = false;
                                    //rowDuzenleme_Vade_T.Visible = false;
                                    mRowDigerAlacakNeden.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = true;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Vade T.";
                                    mrowHarcaEsasDeger.Visible = false;
                                    //CurrentNeden.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                    mrowCekSorumluluk.Visible = false;
                                    mRowTazmin.Visible = false;

                                    #endregion

                                    break;

                                #endregion
                            }
                            if (FormTip == (int)FormTipleri.Form49 || FormTip == (int)FormTipleri.Form151 ||
                                FormTip == (int)FormTipleri.Form50 || FormTip == (int)FormTipleri.Form201 ||
                                FormTip == (int)FormTipleri.Form152)
                            {
                                //rowIHTAR_TARIHI.Visible = true;
                                //IhtarGidParaB.Visible = true;
                            }
                            if (Kimlikci.Kimlik.SirketBilgisi.KurumsalMod == 1501)
                            {
                                if (CurrentNeden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI != "SENET" ||
                                    CurrentNeden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI != "POLÝÇE" ||
                                    CurrentNeden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI != "ÇEK")
                                {
                                    BSMV_KKDV.Visible = true;
                                    KDV_KDVTIP.Visible = true;
                                    CurrentNeden.BSMV_HESAPLANSIN = true;
                                    KDV_KDVTIP.Visible = false;
                                    OIV.Visible = false;
                                    rowDuzenleme_Vade_T.GetRowProperties(1).Caption = "Kat/Vade T.";
                                    rowDuzenlemeT.Visible = false;
                                }
                                else
                                {
                                    BSMV_KKDV.Visible = false;
                                    KDV_KDVTIP.Visible = false;
                                }
                                if (CurrentNeden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI == "ÇEK")
                                {
                                    rowDuzenlemeT.Visible = true;
                                    rowMuhatap.Visible = false;
                                    rowDuzenleme_Vade_T.Visible = false;
                                }

                                rowIHTAR_TARIHI.Visible = true;
                                IhtarGidParaB.Visible = true;
                            }
                            else if (Kimlikci.Kimlik.SirketBilgisi.KurumsalMod == 1001)
                            {
                                Tutar_Birim.PropertiesCollection["TUTARI"].Caption = "Poliçe Limiti/Tutar";
                                IsKonTut_Birim.PropertiesCollection["ISLEME_KONAN_TUTAR"].Caption = "Talep Edilen Tutar";
                            }
                            //int alacakNedenID = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByALACAK_NEDEN_KOD_ID(CurrentNeden.ALACAK_NEDEN_KOD_ID).Select(n => n.ID).FirstOrDefault();
                            TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR ayar = DataRepository.TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID).Where(n => n.FORM_TIPI_ID == _foy.FORM_TIP_ID && n.ALACAK_NEDENI_ID == CurrentNeden.ALACAK_NEDEN_KOD_ID).FirstOrDefault();

                            if (ayar != null)
                            {
                                CurrentNeden.TO_ALACAK_FAIZ_TIP_ID = ayar.TO_FAIZ_TIP_ID;
                                CurrentNeden.TO_UYGULANACAK_FAIZ_ORANI = (double)ayar.TO_FAIZ_ORAN;
                                CurrentNeden.ALACAK_FAIZ_TIP_ID = ayar.TS_FAIZ_TIP_ID;
                                CurrentNeden.UYGULANACAK_FAIZ_ORANI = (double)ayar.TS_FAIZ_TIP_ORAN;
                            }

                            if (Foy.FORM_TIP_ID == (int)FormTipleri.Form49 || Foy.FORM_TIP_ID == (int)FormTipleri.Form153 || Foy.FORM_TIP_ID == (int)FormTipleri.Form51)
                            {
                                mrowHerAyaTazminatEkle.Visible = true;
                            }

                        }
                    FocusedNedenChanged(sender, e);
                }
            }
            this.GetPaketForm();
        }

        [Category("AlacakNeden")]
        public event ValidateRecordEventHandler ValidateRecord;

        private void vgAlacakNedenGirisi_ValidateRecord(object sender, ValidateRecordEventArgs e)
        {
            if (ValidateRecord != null)
            {
                ValidateRecord(sender, e);
            }
        }

        #endregion

        public AV001_TI_BIL_ALACAK_NEDEN CurrentNeden
        {
            get
            {
                if (DtAlacakNeden != null && vgAlacakNedenGirisi.FocusedRecord > -1 && DtAlacakNeden.Count > 0)

                    return DtAlacakNeden[vgAlacakNedenGirisi.FocusedRecord];
                else if (DtAlacakNeden != null && DtAlacakNeden.Count > 0 && vgAlacakNedenGirisi.FocusedRecord > -1)
                    return DtAlacakNeden[0];
                else
                    return null;
            }
        }

        private void dataNavigator1_OnCevirClick(object sender, EventArgs e)
        {
            if (vgAlacakNedenGirisi.Visible)
            {
                vgAlacakNedenGirisi.Visible = false;
                extendedGridControl1.Visible = true;
                extendedGridControl1.BringToFront();
            }
            else
            {
                vgAlacakNedenGirisi.Visible = true;
                extendedGridControl1.Visible = false;
                vgAlacakNedenGirisi.BringToFront();
            }
        }

        private void dataNavigator1_OnListedenGetirClick(object sender, ListedenGetirEventArgs e)
        {
            if (CurrentNeden == null)
            {
                XtraMessageBox.Show("Lütfen Alacak Nedeni Seçiniz.", "Alacak Nedeni", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                return;
            }
            int? a = CurrentNeden.ALACAK_NEDEN_KOD_ID;
            int tip = 1;
            switch (a)
            {
                case (int)AvukatProLib.Extras.AlacakNeden.Cek:
                case (int)AvukatProLib.Extras.AlacakNeden.Senet:
                case (int)AvukatProLib.Extras.AlacakNeden.Police:
                case (int)AvukatProLib.Extras.AlacakNeden.Cek_35:
                case (int)AvukatProLib.Extras.AlacakNeden.Senet_38:
                case (int)AvukatProLib.Extras.AlacakNeden.Police_41:
                case (int)AvukatProLib.Extras.AlacakNeden.Cek_33:
                case (int)AvukatProLib.Extras.AlacakNeden.Senet_36:
                case (int)AvukatProLib.Extras.AlacakNeden.Police_39:
                case (int)AvukatProLib.Extras.AlacakNeden.Cek_34:
                case (int)AvukatProLib.Extras.AlacakNeden.Senet_2:
                case (int)AvukatProLib.Extras.AlacakNeden.Police_40:
                    if (a == (int)AvukatProLib.Extras.AlacakNeden.Cek ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Cek_35 ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Cek_33 ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Cek_34)
                        tip = (int)KEvrapTipi.Çek;
                    if (a == (int)AvukatProLib.Extras.AlacakNeden.Senet ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Senet_38 ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Senet_36 ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Senet_2)
                        tip = (int)KEvrapTipi.Bono;
                    if (a == (int)AvukatProLib.Extras.AlacakNeden.Police ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Police_41 ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Police_39 ||
                        a == (int)AvukatProLib.Extras.AlacakNeden.Police_40)
                        tip = (int)KEvrapTipi.Poliçe;

                    #region

                    frmEkleKiymetliEvrak frm = new frmEkleKiymetliEvrak();
                    frm.myIcra = Foy;
                    frm.myIcraATrf = Forms.Icra.frmIcraDosyaKayit.listTakipEden;
                    frm.myIcraBTrf = Forms.Icra.frmIcraDosyaKayit.listTakipEdilen;
                    frm.Tip = tip;
                    frm.alreadyAddedList = null;
                    // frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                    frm.Show();

                    #endregion

                    break;
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dr = (sender as frmEkleKiymetliEvrak).KayitBasarili;

            if (dr == DialogResult.OK)
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> ds = (sender as frmEkleKiymetliEvrak).selectedList;
                foreach (AV001_TDI_BIL_KIYMETLI_EVRAK item in ds)
                {
                    //vgAlacakNedenGirisi.DataSource = AlacakNedneOlustur(item);
                    //alacaklar = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
                    AlacakNedenOlustur(item);
                    if (Foy != null)
                        Foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK.AddRange(ds);
                }
                DtAlacakNeden = null;
                if (Foy != null)
                {
                    Foy.AV001_TI_BIL_ALACAK_NEDENCollection.Clear();
                    Foy.AV001_TI_BIL_ALACAK_NEDENCollection.AddRange(alacaklar);
                }
                DtAlacakNeden = alacaklar;
                //Ýcra dosya kaydýnda listeden getir dedikten sonra kiymetli evrak uc'sinin yüklenmesini saðlamak için eklendi. Diðer taba geçmeden uc yüklenmiyordu.
                vgAlacakNedenGirisi_ValidateRecord(this, new ValidateRecordEventArgs(0));
                //
            }
        }

        private TList<AV001_TI_BIL_ALACAK_NEDEN> alacaklar;

        public void AlacakNedenOlustur(AV001_TDI_BIL_KIYMETLI_EVRAK ds)
        {
            AV001_TI_BIL_ALACAK_NEDEN alacak = new AV001_TI_BIL_ALACAK_NEDEN();
            if (alacaklar == null)
                alacaklar = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            alacaklar.AddingNew += alacaklar_AddingNew;
            alacak = alacaklar.AddNew();

            alacak.ALACAK_NEDEN_KOD_ID = CurrentNeden.ALACAK_NEDEN_KOD_ID;
            if (ds.TUTAR_DOVIZ_ID != 1)
            {
                alacak.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL;
                alacak.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                alacak.ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                alacak.TO_UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir(alacak.ALACAK_FAIZ_TIP_ID.Value, ds.TUTAR_DOVIZ_ID, Foy != null ? Foy.TAKIP_TARIHI : DateTime.Today);
                alacak.UYGULANACAK_FAIZ_ORANI = alacak.TO_UYGULANACAK_FAIZ_ORANI;
            }
            else
            {
                alacak.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
                alacak.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                alacak.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                alacak.TO_UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir(alacak.ALACAK_FAIZ_TIP_ID.Value, ds.TUTAR_DOVIZ_ID, Foy != null ? Foy.TAKIP_TARIHI : DateTime.Today);
                alacak.UYGULANACAK_FAIZ_ORANI = alacak.TO_UYGULANACAK_FAIZ_ORANI;
            }
            //if (alacak.IsSelected != false) <gkn> amacýnýn ne olduðu anlaþýlmadý
            alacak.DUZENLENME_TARIHI = ds.EVRAK_TANZIM_TARIHI;
            alacak.VADE_TARIHI = ds.EVRAK_VADE_TARIHI;
            alacak.TUTARI = ds.TUTAR;
            alacak.ISLEME_KONAN_TUTAR = ds.TUTAR;
            alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID = ds.TUTAR_DOVIZ_ID;
            alacak.TUTAR_DOVIZ_ID = ds.TUTAR_DOVIZ_ID;
            alacak.TUTAR_DOVIZ_IDSource = ds.TUTAR_DOVIZ_IDSource;
            for (int i = 0; i < alacaklar.Count; i++)
            {
                if (alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Cek
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.CEK_151
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.CEK_152
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.CEK_201
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Cek_33
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Cek_34
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Cek_35
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.CEK_50
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Police
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.POLICE_151
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.POLICE_152
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.POLICE_201
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Police_39
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Police_40
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Police_41
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.POLICE_50
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Senet
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.SENET_151
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.SENET_152
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Senet_2
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.SENET_201
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Senet_36
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.Senet_38
                    || alacak.ALACAK_NEDEN_KOD_ID == (int)AvukatProLib.Extras.AlacakNeden.SENET_50)
                {
                    if (
                        !alacaklar[i].
                             AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.
                             Contains(ds))
                        alacak.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.Add(
                            ds);
                    else
                        return;
                }
            }
        }

        private void alacaklar_AddingNew(object sender, AddingNewEventArgs e)
        {
            #region Takipsiz Alacaklar icin Herhangi birþey yapma

            if (e.NewObject != null)
                return;

            #endregion

            AV001_TI_BIL_ALACAK_NEDEN a = new AV001_TI_BIL_ALACAK_NEDEN();

            if (Foy != null && Foy.TAKIP_TALEP_ID.HasValue)
            {
                BelgeUtil.Inits.AlacakNedenKodGetir(rlkAlacakNeden);
                (rlkAlacakNeden.DataSource as VList<per_TI_KOD_ALACAK_NEDEN>).Filter = "TAKIP_TALEP_KOD_ID = " + Foy.TAKIP_TALEP_ID.Value;
            }
            a.ColumnChanged += AlacakNedenColumnChanged;
            a.TUTAR_DOVIZ_ID = 1;
            a.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1;
            a.IHTAR_GIDERI_DOVIZ_ID = 1;
            a.PROTESTO_GIDERI_DOVIZ_ID = 1;
            a.TO_ALACAK_FAIZ_TIP_ID = 1;
            a.ALACAK_FAIZ_TIP_ID = 1;
            a.KDV_HESAPLANSIN = false;
            a.KKDV_HESAPLANSIN = false;
            a.KDV_TIP_ID = 6;
            a.TAZMINATI_DOVIZ_ID = 1;
            a.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC =
                new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
            a.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK =
                new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
            a.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW =
                new TList<AV001_TDI_BIL_SOZLESME>();
            a.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL =
                new TList<AV001_TI_BIL_GAYRIMENKUL>();
            a.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
            //Döviz iþlem tipi
            a.HESAPLAMA_MODU = 1;
            int cekTazminatkod =
                DataRepository.TDI_KOD_TEMINAT_TAZMINATProvider.GetByTEMINAT_TAZMINAT_ADI(
                    "ÇEK TAZMÝNAT").ID;
            TList<TDI_CET_TEMINAT_TAZMINAT> cekTazminat =
                DataRepository.TDI_CET_TEMINAT_TAZMINATProvider.GetByKATEGORI_ID(cekTazminatkod);
            if (cekTazminat.Count > 0)
            {
                foreach (var item in cekTazminat)
                {
                    if (item.TARIH <= a.VADE_TARIHI)
                        a.CEK_TAZMINATI_ORANI = item.ORAN;
                }
                //a.CEK_TAZMINATI_ORANI = cekTazminat[0].ORAN;
            }
            else
                a.CEK_TAZMINATI_ORANI = 5;
            a.KOMISYONU_ORANI = 0.3;

            if (Kimlikci.Kimlik.SirketBilgisi.KurumsalMod == 1501)
            {
                a.TO_ALACAK_FAIZ_TIP_ID = (byte)FaizTip.Temmerut_Faiz;
                a.ALACAK_FAIZ_TIP_ID = (byte)FaizTip.Temmerut_Faiz;
                a.BSMV_HESAPLANSIN = true;
            }

            a.KAYIT_TARIHI = DateTime.Now;
            a.KONTROL_NE_ZAMAN = DateTime.Now;
            a.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            a.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            a.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            a.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            a.HESAPLAMA_MODU = (byte)IcraDovizIslemTipi.Vade_Tarihinde_TL;
            if (Foy != null && Foy.FORM_TIP_ID.HasValue)
                switch (Foy.FORM_TIP_ID.Value)
                {
                    case 1:
                        a.SABIT_FAIZ_UYGULA = true;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        //Kenan beyin isteði üzerine deðiþtirilmiþtir.[ihsan]
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.DovizIslemTipi.VadeTarihindeYtl;
                        a.ALACAK_NEDEN_KOD_ID = (int)AvukatProLib.Extras.AlacakNeden.Police;
                        break;
                    case 2:
                        a.SABIT_FAIZ_UYGULA = true;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        //Kenan beyin isteði üzerine deðiþtirilmiþtir.[ihsan]
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.DovizIslemTipi.VadeTarihindeYtl;
                        a.ALACAK_NEDEN_KOD_ID = (int)AvukatProLib.Extras.AlacakNeden.MenkulRehni_14;
                        break;
                    case 8:
                        a.SABIT_FAIZ_UYGULA = true;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Özel_Sabit_Faiz;
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Özel_Sabit_Faiz;
                        a.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.DovizIslemTipi.VadeTarihindeYtl;
                        //Foy.AV001_TI_BIL_ALACAK_NEDENCollection[0].ALACAK_NEDEN_KOD_ID = 32;
                        break;
                    case 10:
                    case 12:
                        a.SABIT_FAIZ_UYGULA = true;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        //Kenan beyin isteði üzerine deðiþtirilmiþtir.[ihsan]
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.DovizIslemTipi.VadeTarihindeYtl;
                        a.ALACAK_NEDEN_KOD_ID = (int)AvukatProLib.Extras.AlacakNeden.Kira;

                        break;
                    case 3:
                    case 11:
                        a.SABIT_FAIZ_UYGULA = false;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                        a.ALACAK_NEDEN_KOD_ID = 14;
                        break;

                    case 4:
                        a.SABIT_FAIZ_UYGULA = false;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_NEDEN_KOD_ID = 66;
                        break;
                    case 5:
                        a.SABIT_FAIZ_UYGULA = false;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_NEDEN_KOD_ID = 31;

                        break;
                    case 6:
                        a.SABIT_FAIZ_UYGULA = false;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        //    Foy.TAKIP_TALEP_ID = 10;

                        break;
                    case 13:
                        a.SABIT_FAIZ_UYGULA = false;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_NEDEN_KOD_ID = 53;

                        break;

                    case 7:

                        a.SABIT_FAIZ_UYGULA = false;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_NEDEN_KOD_ID = 32;

                        break;
                    case 9:

                        a.SABIT_FAIZ_UYGULA = false;
                        a.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        a.ALACAK_NEDEN_KOD_ID = (int)AvukatProLib.Extras.AlacakNeden.Tahliye_Taahhudu_12;

                        break;
                }

            e.NewObject = a;
        }

        private void AlacakNedenColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN gonderen = (AV001_TI_BIL_ALACAK_NEDEN)sender;
            //if (gonderen != null)
            //    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(gonderen);
            //  DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(gonderen, true);

            #region Tutar Doviz ID

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_UYGULANACAK_FAIZ_ORANI)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = gonderen.TO_UYGULANACAK_FAIZ_ORANI;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID)
            {
                gonderen.ALACAK_FAIZ_TIP_ID = gonderen.TO_ALACAK_FAIZ_TIP_ID;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID)
            {
                if (gonderen.TUTAR_DOVIZ_ID.HasValue)
                {
                    if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID)
                    {
                        if (gonderen.TUTAR_DOVIZ_ID.Value > 1)
                        {
                            //gonderen.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Ödeme_Tarihinde_TL;
                        }
                        else
                        {
                            //gonderen.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
                        }
                    }
                    gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;
                    //gonderen.ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                    //gonderen.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                }
            }

            #endregion

            #region Tutar DovizId (FormTip = 53 Örnek ve Takip Talep = Ýþci Alacaðý

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID)
                if (Foy.FORM_TIP_ID.Value == 4 && Foy.TAKIP_TALEP_ID.Value == 6)
                {
                }

            #endregion

            #region Faiz Oranlarý Getir

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID)
            {
                gonderen.TO_UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                               gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                                                               Foy != null
                                                                                   ? Foy.TAKIP_TARIHI
                                                                                   : DateTime.Today);
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_FAIZ_TIP_ID)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                            gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                                                            Foy != null
                                                                                ? Foy.TAKIP_TARIHI
                                                                                : DateTime.Today);
            }

            #endregion

            #region Düzenleme Tarihini Vade Tarihine At

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DUZENLENME_TARIHI)
            {
                gonderen.VADE_TARIHI = (DateTime?)e.Value;
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }

            #endregion

            #region VadeTarihini FBasTar a At

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.VADE_TARIHI)
            {
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }

            #endregion

            #region Tutarý ÝþlemeKonana At

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTARI ||
                e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID ||
                e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.HESAPLAMA_MODU)
            {
                switch ((IcraDovizIslemTipi)gonderen.HESAPLAMA_MODU)
                {
                    case IcraDovizIslemTipi.Vade_Tarihinde_TL:
                        if (!gonderen.VADE_TARIHI.HasValue)
                            gonderen.VADE_TARIHI = DateTime.Today;

                        DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                        gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID,
                                                                           gonderen.VADE_TARIHI.Value, gonderen.ALACAK_NEDEN_KOD_ID);

                        gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1; //YTL
                        break;
                    case IcraDovizIslemTipi.Takip_Tarihinde_TL:
                        if (!Foy.TAKIP_TARIHI.HasValue)
                            Foy.TAKIP_TARIHI = DateTime.Today;

                        DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                        gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID,
                                                                           Foy.TAKIP_TARIHI.Value, gonderen.ALACAK_NEDEN_KOD_ID);

                        gonderen.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                        gonderen.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                        gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1; //YTL
                        break;
                    case IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL:
                        gonderen.ISLEME_KONAN_TUTAR = gonderen.TUTARI;
                        gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;

                        break;
                    default:
                        break;
                }
            }

            #endregion

            #region Alacak Nedene Göre Þekillen

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_NEDEN_KOD_ID)
            {
                vgAlacakNedenGirisi_FocusedRecordChanged(vgAlacakNedenGirisi, new IndexChangedEventArgs(vgAlacakNedenGirisi.FocusedRecord, -1));
            }

            #endregion

            #region Alacak Neden e Göre Biþiyler Yap

            if (gonderen != null)
            {
                if (gonderen.ALACAK_NEDEN_KOD_ID.HasValue)
                    mRowDigerAlacakNeden.Visible = false;
                if (gonderen.ALACAK_NEDEN_KOD_ID.HasValue)
                    switch (gonderen.ALACAK_NEDEN_KOD_ID.Value)
                    {
                        //case 51:    //Telefon Faturasý
                        case 81: //	49	KAÇAK ELEKTRÝK FATURASI
                        case 82: //	49	ELEKTRÝK FATURASI
                        case 84: //	49	TESVÝYE
                        case 88: //	49	TESCÝL
                        case 89: //	49	TEFTÝÞ
                            gonderen.KDV_HESAPLANSIN = true;
                            break;

                        case 42: //	49	TELEFON FATURASI
                        case 51: //	153	TELEFON FATURASI
                            gonderen.KDV_HESAPLANSIN = true;
                            gonderen.OIV_HESAPLANSIN = true;
                            break;
                        case 49: //KREDI KARTI
                        case 50: //KREDI ALACAÐI

                            gonderen.BSMV_HESAPLANSIN = true;
                            break;
                        case 54:
                            mRowDigerAlacakNeden.Visible = true;
                            break;
                        default:
                            //gonderen.KDV_HESAPLANSIN = false;
                            //gonderen.OIV_HESAPLANSIN = false;
                            //gonderen.BSMV_HESAPLANSIN = false;
                            break;
                    }

            #endregion

                if (gonderen.TO_ALACAK_FAIZ_TIP_ID != (int)FaizTip.Özel_Sabit_Faiz)
                {
                    gonderen.SABIT_FAIZ_UYGULA = false;
                }
                else
                    gonderen.SABIT_FAIZ_UYGULA = true;
            }
        }

        //ToDO: Resourcedda Newlenmeden dolayý hata alýyordu düzeltildi Canan ...
        public int TAKIP_TALEP_ID;

        [Browsable(false)]
        public TList<AV001_TI_BIL_ALACAK_NEDEN> SeciliNedenler { get; set; }

        private bool _ShowOnlyGridControl;

        [Browsable(true), Category("AlacakNeden")]
        public bool ShowOnlyGridControl
        {
            get { return _ShowOnlyGridControl; }
            set
            {
                _ShowOnlyGridControl = value;
                vgAlacakNedenGirisi.Visible = !value;
                extendedGridControl1.Visible = value;
            }
        }

        private Dictionary<int, string> dicFiltre = new Dictionary<int, string>();

        private void radioButtonNakti_EditValueChanging(object sender, ChangingEventArgs e)
        {
            VList<per_TI_KOD_ALACAK_NEDEN> alN = new VList<per_TI_KOD_ALACAK_NEDEN>();
            alN = rlkAlacakNeden.DataSource as VList<per_TI_KOD_ALACAK_NEDEN>;
            if (alN == null || alN.Count == 0)
            {
                if (BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur == null)
                    BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetAll();
                alN = BelgeUtil.Inits._TI_KOD_AlacakNedeniDoldur;
            }

            #region <GKN-20090905>

            //yeni yapýya geçildi

            //alN.Filter = string.Empty;
            //if ((bool)e.NewValue == false)
            //{
            //    if (!dicFiltre.ContainsValue("DEPO_ALACAGI = False"))
            //        dicFiltre.Add(2, "DEPO_ALACAGI = False");
            //}
            //else if ((bool)e.NewValue == true)
            //{
            //    if (!dicFiltre.ContainsValue("DEPO_ALACAGI = True"))
            //        dicFiltre.Add(3, "DEPO_ALACAGI = True");
            //    alN.Filter = dicFiltre[1] + dicFiltre[3];
            //}

            //if (TAKIP_TALEP_ID != 0)
            //{
            //    if (dicFiltre.ContainsKey(1))
            //        dicFiltre.Remove(1);
            //    dicFiltre.Add(1, " AND TAKIP_TALEP_KOD_ID = " + TAKIP_TALEP_ID.ToString());
            //}

            #endregion </GKN-20090905>

            string filitre = string.Format("DEPO_ALACAGI = {0}", (bool)e.NewValue);
            if (TAKIP_TALEP_ID != 0)
            {
                filitre += " AND TAKIP_TALEP_KOD_ID = " + TAKIP_TALEP_ID;

                alN.Filter = filitre;

                rlkAlacakNeden.DataSource = alN;

                CurrentNeden.IsSelected = (bool)e.NewValue;

                return;
            }

            alN.Filter = filitre;

            var gruplar = alN.GroupBy(vi => vi.ALACAK_NEDENI);

            rlkAlacakNeden.DataSource = gruplar.Select(vi => vi.First()).ToList();

            CurrentNeden.IsSelected = (bool)e.NewValue;
        }


        private void rLueMuhatap_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;

                //.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;

                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueMuhatap, null);
                                           }
                                       };
            }
        }

        private void rLueMuhatap_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (lue.Text != string.Empty)
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;

                //.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueMuhatap, null);
                                           }
                                       };
            }
        }
    }
}