using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraScheduler;
using TableConverter;
using AdimAdimDavaKaydi.IcraTakipForms;

namespace AdimAdimDavaKaydi.Is.UserControls
{
    public partial class ucIsKayitUfak : DevExpress.XtraEditors.XtraUserControl
    {
        private AvukatProLib.CompInfo SirketComp;

        public DateTime SeciliGun;

        //private AV001_TDI_BIL_IS _Is;

        //public AV001_TDI_BIL_IS Is
        //{
        //    get { return _Is; }
        //    set
        //    {
        //        _Is = value;
        //        if (_Is != null)
        //            _bndIs.DataSource = _Is;
        //    }
        //}

        public ucIsKayitUfak()
        {
            InitializeComponent();

            c_lueDosya.EditValueChanged += c_lueDosya_EditValueChanged;
            c_lueModul.EditValueChanged += c_lueModul_EditValueChanged;
        }

        #region Properties

        public static bool IsKaydedildi = true;

        public bool IsEdit;

        public int KlasorID = -1;

        private int _ModulID = 10;

        private TList<AV001_TDI_BIL_IS> _MyDataSource;

        private IEntity _OpenedRecord;

        private IEntity _Record;

        public delegate void OnSaved(IList Records, IEntity Record);

        public static event EventHandler<IsKayitEventArgs> Yenile;

        [Browsable(false)]
        public event OnSaved Saved;

        public event EventHandler<IsKayitEventArgs> YenileKayit;

        public int formTipi { get; set; }

        public bool InForm { get; set; }

        public int Modul { get; set; }

        public int ModulID
        {
            get { return _ModulID; }
            set { _ModulID = value; }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_IS> MyDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                return (TList<AV001_TDI_BIL_IS>)this._bndIs.DataSource;
            }
            set
            {
                if (DesignMode || value == null)
                {
                    return;
                }

                _MyDataSource = value;
                this._bndIs.DataSource = value;
                ProjeGetir(_MyDataSource);
                DosyaNoGetir(_MyDataSource);
            }
        }

        [Browsable(false)]
        public IEntity OpenedRecord
        {
            get { return _OpenedRecord; }
            set { _OpenedRecord = value; }
        }

        [Browsable(false)]
        public IEntity Record
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                return _Record;
            }
            set
            {
                if (DesignMode || value == null)
                    return;

                AV001_TDI_BIL_IS isim = value as AV001_TDI_BIL_IS;

                IsEdit = true;

                DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(isim, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IS_TARAF>), typeof(TList<AV001_TDI_BIL_HATIRLAT>), typeof(TList<NN_HATIRLAT_IS_TARAF>));
                c_btnKaydet.Enabled = true;
                c_btnYeni.Enabled = false;
                if (isim != null)
                {
                    this._bndIs.DataSource = new TList<AV001_TDI_BIL_IS>();
                    if (_OpenedRecord != null)
                    {
                        if (_OpenedRecord is AV001_TI_BIL_FOY)
                        {
                            c_lueDosya.EditValue = (_OpenedRecord as AV001_TI_BIL_FOY).ID;
                            ModulDosyaDisable();
                        }
                        if (_OpenedRecord is AV001_TD_BIL_FOY)
                        {
                            c_lueDosya.EditValue = (_OpenedRecord as AV001_TD_BIL_FOY).ID;
                            ModulDosyaDisable();
                        }
                        if (_OpenedRecord is AV001_TDI_BIL_SOZLESME)
                        {
                            c_lueDosya.EditValue = (_OpenedRecord as AV001_TDI_BIL_SOZLESME).ID;
                            ModulDosyaDisable();
                        }
                        if (_OpenedRecord is AV001_TD_BIL_HAZIRLIK)
                        {
                            c_lueDosya.EditValue = (_OpenedRecord as AV001_TD_BIL_HAZIRLIK).ID;
                            ModulDosyaDisable();
                        }
                    }

                    if (isim.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Count > 0)
                    {
                        hATIRLATILSIN_MICheckEdit.Checked = true;

                        foreach (var hatirlatma in isim.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA)
                        {
                            if (hatirlatma.HATIRLATMA_TIPI == "0")
                            {
                                chkEkranHatirlat.Checked = true;

                                //hatirlatma.IS_ID = myIs.ID;
                                //hatirlatma.HATIRLATSIN_MI = true;
                                //hatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                                //hatirlatma.BITIS_TARIHI = myIs.ONGORULEN_BITIS_TARIHI.Value;
                                //hatirlatma.BASLAMA_TARIHI = myIs.BASLANGIC_TARIHI.Value - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue;
                                //hatirlatma.ACIKLAMA = myIs.TEKRARLAMA_BILGISI ?? string.Empty;
                                //hatirlatma.HATIRLATMA_TIPI = "0";
                                //hatirlatma.BASLANGIC_ID = 1;
                                //hatirlatma.PERIYOD_ID = 1;
                            }
                            else if (hatirlatma.HATIRLATMA_TIPI == "1")
                            {
                                chkMailHatirlat.Checked = true;

                                //hatirlatma.IS_ID = myIs.ID;
                                //hatirlatma.HATIRLATSIN_MI = true;
                                //hatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                                //hatirlatma.BASLAMA_TARIHI = myIs.BASLANGIC_TARIHI.Value;
                                //hatirlatma.BITIS_TARIHI = myIs.ONGORULEN_BITIS_TARIHI.Value;
                                //hatirlatma.ACIKLAMA = "mail hatýrlatma";
                                //hatirlatma.HATIRLATMA_TIPI = "1";
                                //hatirlatma.BASLANGIC_ID = 1;
                                //hatirlatma.PERIYOD_ID = 1;

                                #region Mail ile iþ bildir

                                if (hatirlatma.BIR_DEFA_PATLAMASI_OLDU_MU)
                                {
                                    chkIsBildirimiMail.Checked = true;
                                    string tarafIndex = null;
                                    DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepLoad(hatirlatma, true, DeepLoadType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<AV001_TDI_BIL_IS_TARAF>));

                                    foreach (var taraf in hatirlatma.AV001_TDI_BIL_IS_TARAFCollection_From_NN_HATIRLAT_IS_TARAF)
                                    {
                                        if (taraf.IS_TARAF_ID == 1)
                                            tarafIndex += "1";
                                        else if (taraf.IS_TARAF_ID == 2)
                                            tarafIndex += "2";
                                        else if (taraf.IS_TARAF_ID == 3)
                                            tarafIndex += "3";
                                    }

                                    if (!string.IsNullOrEmpty(tarafIndex))
                                    {
                                        if (tarafIndex == "1")
                                            cbxIsiBildirMail.SelectedIndex = 0;
                                        if (tarafIndex == "2")
                                            cbxIsiBildirMail.SelectedIndex = 1;
                                        if (tarafIndex == "12" || tarafIndex == "21")
                                            cbxIsiBildirMail.SelectedIndex = 2;
                                        if (tarafIndex.Trim('1').Trim('2') == "3")
                                            cbxIsiBildirMail.SelectedIndex = 3;
                                    }
                                }

                                #endregion Mail ile iþ bildir

                                #region Mail ile tamamlandi bildir

                                if (hatirlatma.GOSTERSIN_MI_1_GUN_ONCE)
                                {
                                    chkTamamlandiMail.Checked = true;
                                    string tarafIndex = null;

                                    foreach (var taraf in hatirlatma.AV001_TDI_BIL_IS_TARAFCollection_From_NN_HATIRLAT_IS_TARAF)
                                    {
                                        if (taraf.IS_TARAF_ID == 1)
                                            tarafIndex += "1";
                                        else if (taraf.IS_TARAF_ID == 2)
                                            tarafIndex += "2";
                                        else if (taraf.IS_TARAF_ID == 3)
                                            tarafIndex += "3";
                                    }

                                    if (!string.IsNullOrEmpty(tarafIndex))
                                    {
                                        if (tarafIndex == "1")
                                            cbxTamamlandiMail.SelectedIndex = 0;
                                        if (tarafIndex == "2")
                                            cbxTamamlandiMail.SelectedIndex = 1;
                                        if (tarafIndex == "12" || tarafIndex == "21")
                                            cbxTamamlandiMail.SelectedIndex = 2;
                                        if (tarafIndex.Trim('1').Trim('2') == "3")
                                            cbxTamamlandiMail.SelectedIndex = 3;
                                    }
                                }

                                #endregion Mail ile tamamlandi bildir

                                #region Mail ile yapilmamiþsa bildir

                                if (hatirlatma.PERIYODUN_SON_PATLAMASI_OLDU_MU)
                                {
                                    chkYapilmamissaMail.Checked = true;

                                    string tarafIndex = null;

                                    foreach (var taraf in hatirlatma.AV001_TDI_BIL_IS_TARAFCollection_From_NN_HATIRLAT_IS_TARAF)
                                    {
                                        if (taraf.IS_TARAF_ID == 1)
                                            tarafIndex += "1";
                                        else if (taraf.IS_TARAF_ID == 2)
                                            tarafIndex += "2";
                                        else if (taraf.IS_TARAF_ID == 3)
                                            tarafIndex += "3";
                                    }

                                    if (!string.IsNullOrEmpty(tarafIndex))
                                    {
                                        if (tarafIndex == "1")
                                            cbxYapilmamissaMail.SelectedIndex = 0;
                                        if (tarafIndex == "2")
                                            cbxYapilmamissaMail.SelectedIndex = 1;
                                        if (tarafIndex == "12" || tarafIndex == "21")
                                            cbxYapilmamissaMail.SelectedIndex = 2;
                                        if (tarafIndex.Trim('1').Trim('2') == "3")
                                            cbxYapilmamissaMail.SelectedIndex = 3;
                                    }
                                }

                                #endregion Mail ile yapilmamiþsa bildir

                                #region Mail ile hatýrlatma bildir

                                if (!string.IsNullOrEmpty(hatirlatma.GUNLUK_UYARI_SAAT))
                                {
                                    chkHatirlatmaMail.Checked = true;

                                    teSaatMail.EditValue = hatirlatma.GUNLUK_UYARI_SAAT;
                                    seGunOnceMail.EditValue = hatirlatma.TEKRAR;

                                    string tarafIndex = null;

                                    foreach (var taraf in hatirlatma.AV001_TDI_BIL_IS_TARAFCollection_From_NN_HATIRLAT_IS_TARAF)
                                    {
                                        if (taraf.IS_TARAF_ID == 1)
                                            tarafIndex += "1";
                                        else if (taraf.IS_TARAF_ID == 2)
                                            tarafIndex += "2";
                                        else if (taraf.IS_TARAF_ID == 3)
                                            tarafIndex += "3";
                                    }

                                    if (!string.IsNullOrEmpty(tarafIndex))
                                    {
                                        if (tarafIndex == "1")
                                            cbxHatirlatmaMail.SelectedIndex = 0;
                                        if (tarafIndex == "2")
                                            cbxHatirlatmaMail.SelectedIndex = 1;
                                        if (tarafIndex == "12" || tarafIndex == "21")
                                            cbxHatirlatmaMail.SelectedIndex = 2;
                                        if (tarafIndex.Trim('1').Trim('2') == "3")
                                            cbxHatirlatmaMail.SelectedIndex = 3;
                                    }
                                }

                                #endregion Mail ile hatýrlatma bildir
                            }
                            else if (hatirlatma.HATIRLATMA_TIPI == "2")
                            {
                                chkSmsHatirlat.Checked = true;
                            }
                        }
                    }
                    if (isim.ID != 0 && isim.STAMP != 1)
                    {
                        isim.STAMP = 1;
                        DataRepository.AV001_TDI_BIL_ISProvider.Save(isim);
                    }
                    this._bndIs.Add(isim);
                    _Record = value;
                }
                else
                {
                    this._bndIs.Add(new AV001_TDI_BIL_IS());
                }
            }
        }

        #endregion Properties

        #region Events

        private void _bndIs_DataMemberChanged(object sender, EventArgs e)
        {
            var iss = _bndIs.Current as AV001_TDI_BIL_IS;

            if (iss != null)
            {
                if (!chIsDurum.Checked)
                    iss.BITIS_TARIHI = null;
            }
        }

        private void bASLANGIC_TARIHIDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (bASLANGIC_TARIHIDateEdit.EditValue == null)
                return;
            if (!string.IsNullOrEmpty(bASLANGIC_TARIHIDateEdit.EditValue.ToString()))
            {
                (_bndIs.Current as AV001_TDI_BIL_IS).BASLANGIC_TARIHI = (DateTime)bASLANGIC_TARIHIDateEdit.EditValue;
                (_bndIs.Current as AV001_TDI_BIL_IS).ONGORULEN_BITIS_TARIHI = Convert.ToDateTime(bASLANGIC_TARIHIDateEdit.EditValue).AddDays(1);
            }
        }

        private void bITIS_TARIHIDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (bITIS_TARIHIDateEdit.EditValue == null)
                return;
            if (!string.IsNullOrEmpty(bITIS_TARIHIDateEdit.EditValue.ToString()))
            {
                if (!string.IsNullOrEmpty(bASLANGIC_TARIHIDateEdit.EditValue.ToString()))
                    lblIsSure.Text = string.Format("Ýþ {0} günde yapýldý.", ((DateTime)bITIS_TARIHIDateEdit.EditValue - (DateTime)bASLANGIC_TARIHIDateEdit.EditValue).Days);
                lueBitisSaat.EditValue = DateTime.Now;
                tabHatirlatma.PageVisible = false;
                //chIsDurum.Checked = true;
            }
            else
            {
                tabHatirlatma.PageVisible = true;
                //chIsDurum.Checked = false;
            }

        }

        private void btnDurumKaydet_Click(object sender, EventArgs e)
        {
            if (IsEdit
                && gridView1.GetSelectedRows().Length > 0
                && gridView1.GetRow(gridView1.GetSelectedRows()[0]) is AV001_TDI_BIL_IS_TARAF)
            {
                AV001_TDI_BIL_IS_TARAF taraf = (AV001_TDI_BIL_IS_TARAF)gridView1.GetRow(gridView1.GetSelectedRows()[0]);
                taraf.DURUM = cmbIsinDurumu.EditValue.ToString();
                if (lueIadeNedeni.EditValue != null)
                    taraf.ISE_IADE_NEDEN_ID = (int)lueIadeNedeni.EditValue;
                taraf.DURUM_ACIKLAMA = txAciklama.Text;
                DataRepository.AV001_TDI_BIL_IS_TARAFProvider.Save(taraf);
                XtraMessageBox.Show("Kayýt Tamamlandý");
            }
        }

        private void c_btnKaydet_Click(object sender, EventArgs e)
        {
            #region <KA-20090619>

            // Kaydetmeden önce boþ alan kontrolü.

            #endregion <KA-20090619>

            if (ControlAreas())
                return;
            this.Save();
            MessageBox.Show("Kayýt Tamamlandý");
            //pnlIsDurumu.Visible = true;

            //if (!IsEdit)
            //    NewRecord();
        }

        private void c_btnYeni_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            AV001_TDI_BIL_IS isim = ((AV001_TDI_BIL_IS)_bndIs.Current);
            if (c_lueModul.EditValue != null && c_lueModul.EditValue != DBNull.Value)
                ModulID = Convert.ToInt32(c_lueModul.EditValue);
            switch (ModulID)
            {
                case 2:
                    _OpenedRecord = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);
                    if (isim != null)
                    {
                        c_leuGorev.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        isim.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        c_lueAdliye.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        isim.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        c_lueBirimNo.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        isim.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        eSAS_NOTextEdit.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).ESAS_NO;
                        isim.ESAS_NO = ((AV001_TD_BIL_FOY)_OpenedRecord).ESAS_NO;
                        lueSegment.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).SEGMENT_ID;
                    }
                    break;

                case 1:
                    _OpenedRecord = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);
                    if (isim != null)
                    {
                        c_leuGorev.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        isim.ADLI_BIRIM_GOREV_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        c_lueAdliye.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        isim.ADLI_BIRIM_ADLIYE_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        c_lueBirimNo.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        isim.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        eSAS_NOTextEdit.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).ESAS_NO;
                        isim.ESAS_NO = ((AV001_TI_BIL_FOY)_OpenedRecord).ESAS_NO;
                        isim.FORM_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).FORM_TIP_ID;
                        lueSegment.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).SEGMENT_ID;
                    }
                    break;
                default:
                    break;
            }

            c_leuGorev.Enabled = false;
            c_lueAdliye.Enabled = false;
            c_lueBirimNo.Enabled = false;
            eSAS_NOTextEdit.Enabled = false;
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

        private void c_lueOncelik_EditValueChanged(object sender, EventArgs e)
        {
            WorkCheck();
        }

        private void chIsDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chIsDurum.Checked)
            {
                (_bndIs.Current as AV001_TDI_BIL_IS).BITIS_TARIHI = DateTime.Now;
                //bITIS_TARIHIDateEdit.EditValue = DateTime.Now;
                bITIS_TARIHIDateEdit.Enabled = true;
                hATIRLATILSIN_MICheckEdit.Enabled = false;
                hATIRLATILSIN_MICheckEdit.Checked = false;
                tabHatirlatma.PageVisible = false;
            }
            else if (!chIsDurum.Checked)
            {
                (_bndIs.Current as AV001_TDI_BIL_IS).BITIS_TARIHI = null;
                //bITIS_TARIHIDateEdit.EditValue = null;
                bITIS_TARIHIDateEdit.Enabled = false;
                hATIRLATILSIN_MICheckEdit.Enabled = true;
                hATIRLATILSIN_MICheckEdit.Checked = true;
                tabHatirlatma.PageVisible = true;
            }
        }

        private void chkEkranHatirlat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEkranHatirlat.Checked)
                pnlEkranHatirlat.Enabled = true;
            else
                pnlEkranHatirlat.Enabled = false;
        }

        private void chkEpostaHatirlat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMailHatirlat.Checked)
            {
                pnlEPostaHatirlat.Enabled = true;
                chkHatirlatmaMail.Checked = true;
                chkIsBildirimiMail.Checked = true;
                chkTamamlandiMail.Checked = true;
                chkYapilmamissaMail.Checked = true;
            }
            else
                pnlEPostaHatirlat.Enabled = false;
        }

        private void chkSmsHatirlat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSmsHatirlat.Checked)
                pnlSmsHatirlat.Enabled = true;
            else
                pnlSmsHatirlat.Enabled = false;
        }

        private void cmbIsinDurumu_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue == null) return;
            switch (e.NewValue.ToString())
            {
                case "Tamamlandý":
                    hypIsinSureci.Visible = false;
                    txAciklama.Visible = true;
                    lueIadeNedeni.Visible = false;
                    btnDurumKaydet.Visible = true;
                    break;

                case "Ýade Edildi":
                    hypIsinSureci.Visible = false;
                    txAciklama.Visible = true;
                    lueIadeNedeni.Visible = true;
                    btnDurumKaydet.Visible = true;
                    break;

                case "Devam Etmekte":
                    hypIsinSureci.Visible = true;
                    txAciklama.Visible = true;
                    lueIadeNedeni.Visible = false;
                    btnDurumKaydet.Visible = true;
                    break;
                default:
                    hypIsinSureci.Visible = false;
                    lueIadeNedeni.Visible = false;
                    txAciklama.Visible = true;
                    btnDurumKaydet.Visible = false;
                    break;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (IsEdit
                && gridView1.GetSelectedRows().Length > 0
                && gridView1.GetRow(gridView1.GetSelectedRows()[0]) is AV001_TDI_BIL_IS_TARAF)
            {
                AV001_TDI_BIL_IS_TARAF taraf = (AV001_TDI_BIL_IS_TARAF)gridView1.GetRow(gridView1.GetSelectedRows()[0]);
                cmbIsinDurumu.EditValue = taraf.DURUM;
                lueIadeNedeni.EditValue = taraf.ISE_IADE_NEDEN_ID;
                txAciklama.Text = taraf.DURUM_ACIKLAMA;
            }
        }

        private void hATIRLATILSIN_MICheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (hATIRLATILSIN_MICheckEdit.Checked)
                tabHatirlatma.PageVisible = true;
            else if (!hATIRLATILSIN_MICheckEdit.Checked)
                tabHatirlatma.PageVisible = false;
        }

        private void ucBelgeKayitUfak_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            if (!IsEdit)
            {
                c_btnKaydet.Enabled = false;
                //pnlIsDurumu.Visible = false;
            }
            else
            {
                //pnlIsDurumu.Visible = true;
                BelgeUtil.Inits.IsIadeNedeniGetir(lueIadeNedeni);
            }
            if (!(this._bndIs.DataSource is TList<AV001_TDI_BIL_IS>) && !IsEdit)
                this._bndIs.DataSource = new TList<AV001_TDI_BIL_IS>();

            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(c_lueAdliye);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(c_lueBirimNo);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(c_leuGorev);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);
            AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(c_lueModul, null);
            BelgeUtil.Inits.ModulKodGetir(c_lueModul.Properties);
            AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(c_lueKategori, 6);

            BelgeUtil.Inits.IsEtiketGetir(c_lueEtiket);
            BelgeUtil.Inits.IsDurumGetir(c_lueDurum);
            BelgeUtil.Inits.IsOncelikGetir(c_lueOncelik);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari);
            BelgeUtil.Inits.IsTarafGetir(this.rlueIsTaraf);
            BelgeUtil.Inits.ProjeAdGetir(lueProje);

            if (!IsEdit)
            {
                NewRecord();
                oNGORULEN_BITIS_TARIHIDateEdit.EditValue = bASLANGIC_TARIHIDateEdit.EditValue;
            }


            #region <MB 20091204>

            //proje,dosya no bilgilerinin getirilmesi ve durum checkEdit'inin false gelmesi saðlandý
            ProjeGetir((this._bndIs.DataSource as TList<AV001_TDI_BIL_IS>));
            DosyaNoGetir((this._bndIs.DataSource as TList<AV001_TDI_BIL_IS>));

            //chIsDurum.Checked = false;
            //chIsDurum.EditValue = 0;
            //bITIS_TARIHIDateEdit.EditValue = null;
            var iss = _bndIs.Current as AV001_TDI_BIL_IS;

            if (iss != null)
            {
                chIsDurum.Checked = iss.BITIS_TARIHI.HasValue;
            }
            #endregion <MB 20091204>

            //       c_lueAdliye.EditValue = TablesColumnData.GetColumnValueByNameFromRecord(
            //           ((IEntity)((IList)c_lueAdliye.Properties.DataSource)[0]),
            //           "Id").Value;
            //       c_leuGorev.EditValue = TablesColumnData.GetColumnValueByNameFromRecord(
            //           ((IEntity)((IList)c_leuGorev.Properties.DataSource)[0]),
            //           "Id").Value;
            //       c_lueBirimNo.EditValue = TablesColumnData.GetColumnValueByNameFromRecord(
            //           ((IEntity)((IList)c_lueBirimNo.Properties.DataSource)[0]),
            //           "Id").Value;
            //       c_lueFormTipi.EditValue = TablesColumnData.GetColumnValueByNameFromRecord(
            //           ((IEntity)((IList)c_lueFormTipi.Properties.DataSource)[0]),
            //           "Id").Value;
            //       c_lueModul.EditValue = TablesColumnData.GetColumnValueByNameFromRecord(
            //((IEntity)((IList)c_lueModul.Properties.DataSource)[0]),
            //"Id").Value;
            //       c_lueKategori.EditValue = TablesColumnData.GetColumnValueByNameFromRecord(
            //((IEntity)((IList)c_lueKategori.Properties.DataSource)[0]),
            //"Id").Value;
            //       c_lueKategori.EditValue = TablesColumnData.GetColumnValueByNameFromRecord(
            //((IEntity)((IList)c_lueKategori.Properties.DataSource)[0]),
            //"Id").Value;

            HatirlatmaCheckGuncelle();
            WorkCheck();
            (_bndIs.Current as AV001_TDI_BIL_IS).DURUM = false;
            //(_bndIs.Current as AV001_TDI_BIL_IS).HATIRLATILSIN_MI = false;

            if (!IsEdit)
            {
                try
                {
                    if (SeciliGun == Convert.ToDateTime("01.01.0001 00:00:00"))
                        SeciliGun = Convert.ToDateTime(DateTime.Today.Day + "." + DateTime.Today.Month + "." + DateTime.Today.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);

                    bASLANGIC_TARIHIDateEdit.DateTime = SeciliGun;
                    (_bndIs.Current as AV001_TDI_BIL_IS).ONGORULEN_BITIS_TARIHI = bASLANGIC_TARIHIDateEdit.DateTime;
                    timeBaslangic.EditValue = SeciliGun;
                }
                catch { ;}

                //c_lueKategori.Text = "DÝÐER";
                //c_lueOncelik.Text = "ACÝL";
                //c_lueDurum.Text = "MEÞGUL";
                //c_lueEtiket.Text = "ÖNEMLÝ";

                //c_lueKategori.EditValue = 331;
                //c_lueOncelik.EditValue = 2;
                //c_lueDurum.EditValue = 3;
                //c_lueEtiket.EditValue = 2;
            }
        }

        #endregion Events

        #region Methods

        public void CheckTemizle()
        {
            chkEkranHatirlat.Checked = false;
            chkMailHatirlat.Checked = false;
            chkSmsHatirlat.Checked = false;
        }

        public bool ControlAreas()
        {
            TList<AV001_TDI_BIL_IS> ds = (TList<AV001_TDI_BIL_IS>)this._bndIs.DataSource;
            StringBuilder strBuilder = new StringBuilder();
            foreach (AV001_TDI_BIL_IS d in ds)
            {
                if (d.KONU == null)
                    strBuilder.AppendLine("Konu giriniz");
                if (d.YAPILACAK_IS == null)
                    strBuilder.AppendLine("Yapýlcak iþ giriniz");
                if (d.YER == null)
                    strBuilder.AppendLine("Yer giriniz");
                if (d.AV001_TDI_BIL_IS_TARAFCollection.Count == 0)
                    strBuilder.AppendLine("Taraflarý giriniz");
            }
            if (strBuilder.ToString().Length > 0)
            {
                MessageBox.Show(strBuilder.ToString());
                return true;
            }
            else return false;
        }

        public TList<AV001_TDI_BIL_IS_TARAF> DavaTaraflarindanAl(AV001_TD_BIL_FOY icram)
        {
            TList<AV001_TDI_BIL_IS_TARAF> isTaraflari = new TList<AV001_TDI_BIL_IS_TARAF>();
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>), typeof(TDI_KOD_ADLI_BIRIM_ADLIYE));

            AV001_TDI_BIL_IS_TARAF taraff = new AV001_TDI_BIL_IS_TARAF();
            taraff.IS_TARAF_ID = 1;
            taraff.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
            isTaraflari.Add(taraff);

            if (icram.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
            {
                AV001_TDI_BIL_IS_TARAF tarafso = new AV001_TDI_BIL_IS_TARAF();
                tarafso.IS_TARAF_ID = 2;
                tarafso.CARI_ID = icram.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => !vi.YETKILI_MI).FirstOrDefault().SORUMLU_AVUKAT_CARI_ID;
                isTaraflari.Add(tarafso);
            }

            return isTaraflari;
        }

        public TList<AV001_TDI_BIL_IS_TARAF> IcraTaraflarindanAl(AV001_TI_BIL_FOY icram)
        {
            TList<AV001_TDI_BIL_IS_TARAF> isTaraflari = new TList<AV001_TDI_BIL_IS_TARAF>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>), typeof(TDI_KOD_ADLI_BIRIM_ADLIYE));

            AV001_TDI_BIL_IS_TARAF tarafi = new AV001_TDI_BIL_IS_TARAF();
            tarafi.IS_TARAF_ID = 1;
            tarafi.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
            isTaraflari.Add(tarafi);

            AV001_TDI_BIL_IS_TARAF tarafs = new AV001_TDI_BIL_IS_TARAF();
            tarafs.IS_TARAF_ID = 2;
            tarafs.CARI_ID = icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => !vi.YETKILI_MI).FirstOrDefault().SORUMLU_AVUKAT_CARI_ID;
            isTaraflari.Add(tarafs);

            return isTaraflari;
        }

        public TList<AV001_TDI_BIL_IS_TARAF> IsTarafiAl()
        {
            TList<AV001_TDI_BIL_IS_TARAF> isTaraflari = new TList<AV001_TDI_BIL_IS_TARAF>();

            AV001_TDI_BIL_IS_TARAF tarafi = new AV001_TDI_BIL_IS_TARAF();
            tarafi.IS_TARAF_ID = 2;
            tarafi.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
            isTaraflari.Add(tarafi);

            return isTaraflari;
        }

        public void LookUpEditsDisable()
        {
            c_lueModul.Enabled = false;
            c_lueDosya.Enabled = false;
            c_leuGorev.Enabled = false;
            c_lueAdliye.Enabled = false;
            c_lueBirimNo.Enabled = false;
            eSAS_NOTextEdit.Enabled = false;
        }

        public void ModulDosyaDisable()
        {
            c_lueModul.Enabled = false;
            c_lueDosya.Enabled = false;
        }

        public void NewRecord()
        {
            _bndIs.Clear();
            c_btnKaydet.Enabled = true;
            c_btnYeni.Enabled = false;
            this._bndIs.DataSource = new TList<AV001_TDI_BIL_IS>();
            if (_OpenedRecord != null)
            {
                AV001_TDI_BIL_IS isimo = RecordGenerator.Generate.GenerateAV001_TDI_BIL_ISByRecord(_OpenedRecord);
                AV001_TDI_BIL_IS isim = ((AV001_TDI_BIL_IS)_bndIs.AddNew());
                isim.ACIKLAMA = isimo.ACIKLAMA;
                isim.ADLI_BIRIM_ADLIYE_ID = isimo.ADLI_BIRIM_ADLIYE_ID;
                isim.ADLI_BIRIM_GOREV_ID = isimo.ADLI_BIRIM_GOREV_ID;
                isim.ADLI_BIRIM_NO_ID = isimo.ADLI_BIRIM_NO_ID;
                isim.ESAS_NO = isimo.ESAS_NO;
                isim.STAMP = 0;
                isimo.STAMP = 0;
                if (isimo.FORM_ID > 0)
                    isim.FORM_ID = isimo.FORM_ID;
                isim.MODUL_ID = isimo.MODUL_ID;
                isim.REFERANS_NO = isimo.REFERANS_NO;
                isim.AJANDADA_GORUNSUN_MU = true;
                isim.HATIRLATILSIN_MI = true;
                isim.REFERANS_NO = "Y-" + DateTime.Now.Year + "~" + DateTime.Now.Ticks;
                isim.YER = "OFÝS";
                try
                {
                    isim.KATEGORI_ID =
                       (c_lueKategori.Properties.GetDataSourceRowByDisplayValue("DÝÐER") as
                        AvukatProLib2.Entities.per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI).ID;

                    isim.ONCELIK_ID =
                        (c_lueOncelik.Properties.GetDataSourceRowByDisplayValue("NORMAL") as
                         AvukatProLib2.Entities.per_TDI_KOD_IS_ONCELIK).ID;

                    isim.STATU_ID =
                        (c_lueDurum.Properties.GetDataSourceRowByDisplayValue("BOÞ") as
                         AvukatProLib2.Entities.per_TDI_KOD_IS_DURUM).ID;

                    isim.ETIKET_ID =
                        (c_lueEtiket.Properties.GetDataSourceRowByDisplayValue("ÝÞ") as
                         AvukatProLib2.Entities.per_TDI_KOD_IS_ETIKET).ID;



                    isim.BITIS_TARIHI = null;
                }
                catch
                {
                }

                if (_OpenedRecord is AV001_TI_BIL_FOY)
                {
                    LookUpEditsDisable();

                    isim.AV001_TDI_BIL_IS_TARAFCollection = IcraTaraflarindanAl((_OpenedRecord as AV001_TI_BIL_FOY));
                    isim.MODUL_ID = 1;
                    c_lueDosya.EditValue = (_OpenedRecord as AV001_TI_BIL_FOY).ID;
                    this.formTipi = (_OpenedRecord as AV001_TI_BIL_FOY).FORM_TIP_ID.Value;

                    #region <CC-20090725>

                    // patlýyordu kontrol yapýldý
                    if ((_OpenedRecord as AV001_TI_BIL_FOY).ADLI_BIRIM_ADLIYE_IDSource == null)
                        isim.YER = "";
                    else
                        isim.YER = (_OpenedRecord as AV001_TI_BIL_FOY).ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;

                    #endregion <CC-20090725>
                }
                if (_OpenedRecord is AV001_TD_BIL_FOY)
                {
                    LookUpEditsDisable();

                    isim.AV001_TDI_BIL_IS_TARAFCollection = DavaTaraflarindanAl((_OpenedRecord as AV001_TD_BIL_FOY));
                    isim.MODUL_ID = 2;
                    c_lueDosya.EditValue = (_OpenedRecord as AV001_TD_BIL_FOY).ID;
                    this.formTipi = 1;
                    if ((_OpenedRecord as AV001_TD_BIL_FOY).ADLI_BIRIM_ADLIYE_IDSource == null)
                        isim.YER = "";
                    else
                        isim.YER = (_OpenedRecord as AV001_TD_BIL_FOY).ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                }
                if (_OpenedRecord is AV001_TDI_BIL_SOZLESME)
                {
                    LookUpEditsDisable();

                    isim.AV001_TDI_BIL_IS_TARAFCollection = SozlesmeTaraflarindanAl((_OpenedRecord as AV001_TDI_BIL_SOZLESME));
                    isim.MODUL_ID = 5;
                    c_lueDosya.EditValue = (_OpenedRecord as AV001_TDI_BIL_SOZLESME).ID;
                    this.formTipi = 1;
                    isim.YER = (_OpenedRecord as AV001_TDI_BIL_SOZLESME).ADLI_BIRIM_ADLIYE_IDSource == null
                                   ? string.Empty
                                   : (_OpenedRecord as AV001_TDI_BIL_SOZLESME).ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                }
                if (_OpenedRecord is AV001_TD_BIL_HAZIRLIK)
                {
                    LookUpEditsDisable();

                    isim.AV001_TDI_BIL_IS_TARAFCollection = SorusturmaTaraflarindanAl((_OpenedRecord as AV001_TD_BIL_HAZIRLIK));
                    isim.MODUL_ID = 3;
                    c_lueDosya.EditValue = (_OpenedRecord as AV001_TD_BIL_HAZIRLIK).ID;
                    if (isim.YER != null)
                        isim.YER = (_OpenedRecord as AV001_TD_BIL_HAZIRLIK).ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                }
                if (_OpenedRecord is AV001_TD_BIL_CELSE)
                {
                    LookUpEditsDisable();
                    DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad((AV001_TD_BIL_CELSE)_OpenedRecord, false,
                                                                       DeepLoadType.IncludeChildren,
                                                                       typeof(AV001_TD_BIL_FOY));

                    isim.AV001_TDI_BIL_IS_TARAFCollection =
                        DavaTaraflarindanAl((_OpenedRecord as AV001_TD_BIL_CELSE).DAVA_FOY_IDSource);
                    isim.ACIKLAMA = (_OpenedRecord as AV001_TD_BIL_CELSE).DAVA_FOY_IDSource.ACIKLAMA;
                    isim.ADLI_BIRIM_ADLIYE_ID =
                        (_OpenedRecord as AV001_TD_BIL_CELSE).DAVA_FOY_IDSource.ADLI_BIRIM_ADLIYE_ID;
                    isim.ADLI_BIRIM_GOREV_ID =
                        (_OpenedRecord as AV001_TD_BIL_CELSE).DAVA_FOY_IDSource.ADLI_BIRIM_GOREV_ID;
                    isim.ADLI_BIRIM_NO_ID = (_OpenedRecord as AV001_TD_BIL_CELSE).DAVA_FOY_IDSource.ADLI_BIRIM_NO_ID;
                    isim.ESAS_NO = (_OpenedRecord as AV001_TD_BIL_CELSE).DAVA_FOY_IDSource.ESAS_NO;
                    if (isim.YER != null)
                        isim.YER =
                            (_OpenedRecord as AV001_TD_BIL_CELSE).DAVA_FOY_IDSource.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                }
                if (_OpenedRecord is AV001_TDI_BIL_GORUSME)
                {
                    LookUpEditsDisable();
                    DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepLoad((AV001_TDI_BIL_GORUSME)_OpenedRecord, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(AV001_TD_BIL_FOY),
                                                                          typeof(AV001_TI_BIL_FOY));

                    if ((_OpenedRecord as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource != null)
                    {
                        isim.AV001_TDI_BIL_IS_TARAFCollection =
                            DavaTaraflarindanAl((_OpenedRecord as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource);
                        isim.ACIKLAMA = (_OpenedRecord as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource.ACIKLAMA;
                        isim.ADLI_BIRIM_ADLIYE_ID =
                            (_OpenedRecord as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource.ADLI_BIRIM_ADLIYE_ID;
                        isim.ADLI_BIRIM_GOREV_ID =
                            (_OpenedRecord as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource.ADLI_BIRIM_GOREV_ID;
                        isim.ADLI_BIRIM_NO_ID =
                            (_OpenedRecord as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource.ADLI_BIRIM_NO_ID;
                        isim.ESAS_NO = (_OpenedRecord as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource.ESAS_NO;
                        if (isim.YER != null)
                            isim.YER =
                                (_OpenedRecord as AV001_TDI_BIL_GORUSME).DAVA_FOY_IDSource.ADLI_BIRIM_ADLIYE_IDSource.
                                    ADLIYE;
                    }
                    else if ((_OpenedRecord as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource != null)
                    {
                        isim.AV001_TDI_BIL_IS_TARAFCollection =
                            IcraTaraflarindanAl((_OpenedRecord as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource);
                        isim.ACIKLAMA = (_OpenedRecord as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource.ACIKLAMA;
                        isim.ADLI_BIRIM_ADLIYE_ID =
                            (_OpenedRecord as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource.ADLI_BIRIM_ADLIYE_ID;
                        isim.ADLI_BIRIM_GOREV_ID =
                            (_OpenedRecord as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource.ADLI_BIRIM_GOREV_ID;
                        isim.ADLI_BIRIM_NO_ID =
                            (_OpenedRecord as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource.ADLI_BIRIM_NO_ID;
                        isim.ESAS_NO = (_OpenedRecord as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource.ESAS_NO;
                        if (isim.YER != null)
                            isim.YER =
                                (_OpenedRecord as AV001_TDI_BIL_GORUSME).ICRA_FOY_IDSource.ADLI_BIRIM_ADLIYE_IDSource.
                                    ADLIYE;
                    }
                }

                #region <MB 20091204>

                //Durum CheckEditinin açýlýþta False gelmesi saðlandý
                isim.DURUM = false;

                #endregion <MB 20091204>

                isim.AV001_TDI_BIL_IS_TARAFCollection = IsTarafiAl();
            }
            else
            {
                AV001_TDI_BIL_IS isim = ((AV001_TDI_BIL_IS)_bndIs.AddNew());
                isim.REFERANS_NO = "Y-" + DateTime.Now.Year + "~" + DateTime.Now.Ticks;
                isim.STAMP = 0;
                if (this.formTipi > 0)
                    isim.FORM_ID = this.formTipi;
                isim.MODUL_ID = this.Modul;
                isim.AV001_TDI_BIL_IS_TARAFCollection = IsTarafiAl();
                isim.AJANDADA_GORUNSUN_MU = true;
                isim.HATIRLATILSIN_MI = true;
                isim.YER = "OFÝS";

                #region <MB 20091204>

                //Durum CheckEditinin açýlýþta False gelmesi saðlandý
                isim.DURUM = false;

                #endregion <MB 20091204>

                try
                {
                    #region <KA-20090619>

                    // Etiket,durum,oncelik ve kategori default deðerleri

                    #endregion <KA-20090619>

                    isim.KATEGORI_ID = 331;
                    //(c_lueKategori.Properties.GetDataSourceRowByDisplayValue("DÝÐER") as
                    // AvukatProLib2.Entities.per_TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI).ID;

                    isim.ONCELIK_ID = 2;
                    //(c_lueOncelik.Properties.GetDataSourceRowByDisplayValue("NORMAL") as
                    // AvukatProLib2.Entities.per_TDI_KOD_IS_ONCELIK).ID;

                    isim.STATU_ID = 1;
                    //(c_lueDurum.Properties.GetDataSourceRowByDisplayValue("BOÞ") as
                    // AvukatProLib2.Entities.per_TDI_KOD_IS_DURUM).ID;

                    isim.ETIKET_ID = 3;
                    //(c_lueEtiket.Properties.GetDataSourceRowByDisplayValue("ÝÞ") as
                    // AvukatProLib2.Entities.per_TDI_KOD_IS_ETIKET).ID;



                    isim.BITIS_TARIHI = null;
                }
                catch
                {
                }
            }
            timeBitis.EditValue = timeBaslangic.EditValue;
            oNGORULEN_BITIS_TARIHIDateEdit.EditValue = bASLANGIC_TARIHIDateEdit.EditValue;

            //c_lueKategori.Text = "DÝÐER";
            //c_lueOncelik.Text = "ACÝL";
            //c_lueDurum.Text = "MEÞGUL";
            //c_lueEtiket.Text = "ÖNEMLÝ";
        }

        public void Save()
        {
            #region <KA-20090618>

            // Combolardan gelen deðer eðer seçilmemiþ ise 0 gelmekte ve modul ve forma bu id ile kaydetmeye
            // çalýþýyor ve hata alýyordu. aþaðýdaki kodlar ile eðer deperler soforsa null yaparak hata engellendi.
            int kayitSayisi = 0;
            TList<AV001_TDI_BIL_IS> ds = (TList<AV001_TDI_BIL_IS>)this._bndIs.DataSource;
            foreach (AV001_TDI_BIL_IS d in ds)
            {
                if (c_lueModul.ItemIndex >= 0)
                {
                    d.MODUL_ID = (int?)c_lueModul.EditValue;
                }
                else if (c_lueModul.EditValue is int)
                {
                    if (Convert.ToInt32(c_lueModul.EditValue) == 0)
                        d.MODUL_ID = 7;
                    d.HER_GUN_MU = false;
                }
                else
                {
                    d.MODUL_ID = 7;
                    d.HER_GUN_MU = false;
                }

                if (c_lueKategori.ItemIndex < 0)
                    d.KATEGORI_ID = 488;

                if (chkEkranHatirlat.Checked)
                {
                    if (schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo != null)
                    {
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.DayNumber =
                            ucHatirlatmaPeriyot1.RecurrenceInfo.DayNumber;
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.Start = d.BASLANGIC_TARIHI.Value;
                        if (ucHatirlatmaPeriyot1.RecurrenceInfo.Range == RecurrenceRange.EndByDate)
                            schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.End =
                                ucHatirlatmaPeriyot1.RecurrenceInfo.End;
                        else
                            schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.End =
                                d.ONGORULEN_BITIS_TARIHI.Value;

                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.Month =
                            ucHatirlatmaPeriyot1.RecurrenceInfo.Month;
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.OccurrenceCount =
                            ucHatirlatmaPeriyot1.RecurrenceInfo.OccurrenceCount;
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.Periodicity =
                            ucHatirlatmaPeriyot1.RecurrenceInfo.Periodicity;
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.Range =
                            ucHatirlatmaPeriyot1.RecurrenceInfo.Range;
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.Type =
                            ucHatirlatmaPeriyot1.RecurrenceInfo.Type;
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.Duration =
                            schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.End.Subtract(
                                schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.Start);
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.WeekDays =
                            ucHatirlatmaPeriyot1.RecurrenceInfo.WeekDays;
                        schedulerStorage1.Appointments[kayitSayisi].RecurrenceInfo.WeekOfMonth =
                            ucHatirlatmaPeriyot1.RecurrenceInfo.WeekOfMonth;
                    }
                }
                if (hATIRLATILSIN_MICheckEdit.Checked)
                {
                    Reminder rmd = schedulerStorage1.Appointments[kayitSayisi].CreateNewReminder();
                    rmd.TimeBeforeStart = ucHatirlatmaPeriyot1.durationEdit1.EditValue == null
                                              ? new TimeSpan()
                                              : (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue;
                    rmd.AlertTime = schedulerStorage1.Appointments[kayitSayisi].Start;
                    schedulerStorage1.Appointments[kayitSayisi].Reminders.Add(rmd);
                }
                kayitSayisi++;
            }

            #endregion <KA-20090618>
            foreach (var item in ds)
            {
                if (item.ID == 0)
                    item.STAMP = 0;
            }
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);
            IsKaydedildi = true;
            TList<AV001_TDI_BIL_IS> lstIsler = (TList<AV001_TDI_BIL_IS>)this._bndIs.DataSource;

            foreach (AV001_TDI_BIL_IS myIs in lstIsler)
            {
                myIs.ACIKLAMA = myIs.YAPILACAK_IS;
                DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(myIs, false, DeepLoadType.IncludeChildren, typeof(TList<NN_IS_CARI>));
                foreach (var item in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    item.IS_ID = myIs.ID;
                }
                DataRepository.AV001_TDI_BIL_IS_TARAFProvider.DeepSave(myIs.AV001_TDI_BIL_IS_TARAFCollection);

                #region <MB-20091205>

                //iþin taraflarýnýn NN_IS_CARI tablosuna kaydedilmesi.
                if (myIs.AV001_TDI_BIL_IS_TARAFCollection != null && myIs.AV001_TDI_BIL_IS_TARAFCollection.Count >= 0)
                {
                    for (int i = 0; i < myIs.AV001_TDI_BIL_IS_TARAFCollection.Count; i++)
                    {
                        DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(myIs, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<NN_IS_CARI>));
                        NN_IS_CARI isCari = new NN_IS_CARI();
                        isCari.IS_ID = myIs.ID;
                        if (myIs.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID > 0)
                        {
                            isCari.CARI_ID = myIs.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID.Value;

                            if (myIs.NN_IS_CARICollection.Exists(delegate(NN_IS_CARI tarf)
                                    {
                                        return tarf.CARI_ID == isCari.CARI_ID;
                                    })) continue;
                            AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.DeepSave(isCari);
                        }
                    }
                }

                #endregion <MB-20091205>

                #region <CC-20090725>

                // Proje Seçilmiþse o proje NN tAblýoya Ekleniyor

                if (lueProje.ItemIndex >= 0)
                {
                    AV001_TDIE_BIL_PROJE_IS ProIs = new AV001_TDIE_BIL_PROJE_IS();
                    ProIs.IS_ID = myIs.ID;
                    ProIs.PROJE_ID = (int)lueProje.EditValue;
                    TList<AV001_TDIE_BIL_PROJE_IS> isler = DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.GetAll();
                    if (isler.Exists(delegate(AV001_TDIE_BIL_PROJE_IS tarf) { return tarf.IS_ID == ProIs.IS_ID; }))
                        continue;
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.Save(ProIs);
                }

                #endregion <CC-20090725>

                #region <MB-20091204>

                //yapýlan iþ kaydýnýn ilgili nn tablosuna kaydý.
                //if (c_lueDosya.ItemIndex >= 0)
                //{
                if (c_lueDosya.EditValue != null)
                {
                    if (c_lueModul.EditValue != null && c_lueModul.EditValue != DBNull.Value)
                        ModulID = Convert.ToInt32(c_lueModul.EditValue);
                    switch (ModulID)
                    {
                        case 1:
                            NN_IS_ICRA_FOY isIcra = new NN_IS_ICRA_FOY();
                            isIcra.ICRA_FOY_ID = (int)c_lueDosya.EditValue;
                            isIcra.IS_ID = myIs.ID;
                            TList<NN_IS_ICRA_FOY> islerIcra = DataRepository.NN_IS_ICRA_FOYProvider.GetAll();
                            if (islerIcra.Exists(delegate(NN_IS_ICRA_FOY tarf) { return tarf.IS_ID == isIcra.IS_ID; }))
                                continue;
                            AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.Save(isIcra);
                            break;

                        case 2:
                            NN_IS_DAVA_FOY isDava = new NN_IS_DAVA_FOY();
                            isDava.DAVA_FOY_ID = (int)c_lueDosya.EditValue;
                            isDava.IS_ID = myIs.ID;
                            TList<NN_IS_DAVA_FOY> islerDava = DataRepository.NN_IS_DAVA_FOYProvider.GetAll();
                            if (islerDava.Exists(delegate(NN_IS_DAVA_FOY tarf) { return tarf.IS_ID == isDava.IS_ID; }))
                                continue;
                            AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.Save(isDava);
                            break;
                        default:
                            break;
                    }

                    //}
                }

                #endregion <MB-20091204>

                NNProcess.SaveIs(myIs, OpenedRecord);
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_TARAFProvider.Save(myIs.AV001_TDI_BIL_IS_TARAFCollection);
                DataRepository.AV001_TDI_BIL_ISProvider.DeepSave(myIs, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_HATIRLAT>), typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));

                //foreach (AV001_TDI_BIL_IS_TARAF item in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //{
                if (hATIRLATILSIN_MICheckEdit.Checked && chIsDurum.Checked == false)
                {
                    #region Ekran Hatýrlatmasý

                    if (chkEkranHatirlat.Checked)
                    {
                        AV001_TDI_BIL_HATIRLAT ekranHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                        ekranHatirlatma.IS_ID = myIs.ID;
                        ekranHatirlatma.HATIRLATSIN_MI = true;
                        ekranHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                        ekranHatirlatma.BITIS_TARIHI = myIs.ONGORULEN_BITIS_TARIHI.Value;
                        ekranHatirlatma.BASLAMA_TARIHI = myIs.BASLANGIC_TARIHI.Value - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue;
                        ekranHatirlatma.ACIKLAMA = myIs.TEKRARLAMA_BILGISI ?? string.Empty;
                        ekranHatirlatma.HATIRLATMA_TIPI = "0";
                        ekranHatirlatma.BASLANGIC_ID = 1;
                        ekranHatirlatma.PERIYOD_ID = 1;

                        foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
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

                        ekranHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = myIs.ID });
                        myIs.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(ekranHatirlatma);
                        DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(myIs.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
                    }

                    #endregion Ekran Hatýrlatmasý

                    #region Mail Hatýrlatmasý

                    if (chkMailHatirlat.Checked)
                    {
                        AV001_TDI_BIL_HATIRLAT mailHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                        mailHatirlatma.IS_ID = myIs.ID;
                        mailHatirlatma.HATIRLATSIN_MI = true;
                        mailHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                        mailHatirlatma.BASLAMA_TARIHI = myIs.BASLANGIC_TARIHI.Value;
                        mailHatirlatma.BITIS_TARIHI = myIs.ONGORULEN_BITIS_TARIHI.Value;
                        mailHatirlatma.ACIKLAMA = "mail hatýrlatma";
                        mailHatirlatma.HATIRLATMA_TIPI = "1";
                        mailHatirlatma.BASLANGIC_ID = 1;
                        mailHatirlatma.PERIYOD_ID = 1;

                        if (chkIsBildirimiMail.Checked)
                        {
                            mailHatirlatma.BIR_DEFA_PATLAMASI_OLDU_MU = chkIsBildirimiMail.Checked;

                            foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                            {
                                if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                                    break;
                                switch (cbxIsiBildirMail.SelectedIndex)
                                {
                                    case 0:
                                        if (taraf.IS_TARAF_ID == 1)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 1:
                                        if (taraf.IS_TARAF_ID == 2)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 2:
                                        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 3:
                                        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (chkTamamlandiMail.Checked)
                        {
                            mailHatirlatma.GOSTERSIN_MI_1_GUN_ONCE = chkTamamlandiMail.Checked;

                            foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                            {
                                if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                                    break;
                                switch (cbxTamamlandiMail.SelectedIndex)
                                {
                                    case 0:
                                        if (taraf.IS_TARAF_ID == 1)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 1:
                                        if (taraf.IS_TARAF_ID == 2)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 2:
                                        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 3:
                                        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (chkYapilmamissaMail.Checked)
                        {
                            mailHatirlatma.PERIYODUN_SON_PATLAMASI_OLDU_MU = chkYapilmamissaMail.Checked;

                            foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                            {
                                if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                                    break;
                                switch (cbxYapilmamissaMail.SelectedIndex)
                                {
                                    case 0:
                                        if (taraf.IS_TARAF_ID == 1)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 1:
                                        if (taraf.IS_TARAF_ID == 2)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 2:
                                        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 3:
                                        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (chkHatirlatmaMail.Checked)
                        {
                            mailHatirlatma.GUNLUK_UYARI_SAAT = teSaatMail.Text.Substring(0, 5);
                            mailHatirlatma.TEKRAR = Convert.ToInt32(seGunOnceMail.EditValue);

                            foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                            {
                                if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                                    break;
                                switch (cbxHatirlatmaMail.SelectedIndex)
                                {
                                    case 0:
                                        if (taraf.IS_TARAF_ID == 1)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 1:
                                        if (taraf.IS_TARAF_ID == 2)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 2:
                                        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 3:
                                        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        mailHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = myIs.ID });
                        myIs.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(mailHatirlatma);
                        DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(myIs.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
                    }

                    #endregion Mail Hatýrlatmasý

                    #region SMS Hatýrlatmasý

                    if (chkSmsHatirlat.Checked)
                    {
                        AV001_TDI_BIL_HATIRLAT smsHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                        smsHatirlatma.IS_ID = myIs.ID;
                        smsHatirlatma.HATIRLATSIN_MI = true;
                        smsHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                        smsHatirlatma.BASLAMA_TARIHI = myIs.BASLANGIC_TARIHI.Value;
                        smsHatirlatma.BITIS_TARIHI = myIs.ONGORULEN_BITIS_TARIHI.Value;
                        smsHatirlatma.ACIKLAMA = "sms hatýrlatma";
                        smsHatirlatma.HATIRLATMA_TIPI = "2";
                        smsHatirlatma.BASLANGIC_ID = 1;
                        smsHatirlatma.PERIYOD_ID = 1;

                        if (chkIsiBildirSMS.Checked)
                        {
                            smsHatirlatma.BIR_DEFA_PATLAMASI_OLDU_MU = chkIsBildirimiMail.Checked;

                            foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                            {
                                if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                                    break;
                                switch (cbxIsiBildirSMS.SelectedIndex)
                                {
                                    case 0:
                                        if (taraf.IS_TARAF_ID == 1)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 1:
                                        if (taraf.IS_TARAF_ID == 2)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 2:
                                        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 3:
                                        smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (chkTamamlandigindaSMS.Checked)
                        {
                            smsHatirlatma.GOSTERSIN_MI_1_GUN_ONCE = chkTamamlandiMail.Checked;

                            foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                            {
                                if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                                    break;
                                switch (cbxTamamlandiðindaSMS.SelectedIndex)
                                {
                                    case 0:
                                        if (taraf.IS_TARAF_ID == 1)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 1:
                                        if (taraf.IS_TARAF_ID == 2)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 2:
                                        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 3:
                                        smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (chkYapilmamissaSMS.Checked)
                        {
                            smsHatirlatma.PERIYODUN_SON_PATLAMASI_OLDU_MU = chkYapilmamissaMail.Checked;

                            foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                            {
                                if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                                    break;
                                switch (cbxYapilmamissaSMS.SelectedIndex)
                                {
                                    case 0:
                                        if (taraf.IS_TARAF_ID == 1)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 1:
                                        if (taraf.IS_TARAF_ID == 2)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 2:
                                        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 3:
                                        smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (chkHatirlatSMS.Checked)
                        {
                            smsHatirlatma.GUNLUK_UYARI_SAAT = teSaatSMS.Text.Substring(0, 5);
                            smsHatirlatma.TEKRAR = Convert.ToInt32(seGunOnceSMS.EditValue);

                            foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                            {
                                if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                                    break;
                                switch (cbxHatirlatSMS.SelectedIndex)
                                {
                                    case 0:
                                        if (taraf.IS_TARAF_ID == 1)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 1:
                                        if (taraf.IS_TARAF_ID == 2)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 2:
                                        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;

                                    case 3:
                                        smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        smsHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = myIs.ID });
                        myIs.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(smsHatirlatma);
                        DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(myIs.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
                    }

                    #endregion SMS Hatýrlatmasý

                }

                //}
            }

            if (Yenile != null)
                Yenile(this, new IsKayitEventArgs(this._bndIs.Current as AV001_TDI_BIL_IS));
            if (YenileKayit != null)
                YenileKayit(this, new IsKayitEventArgs(this._bndIs.Current as AV001_TDI_BIL_IS));

            if (this.Saved != null)
                this.Saved(lstIsler, OpenedRecord);
        }

        public TList<AV001_TDI_BIL_IS_TARAF> SorusturmaTaraflarindanAl(AV001_TD_BIL_HAZIRLIK icram)
        {
            TList<AV001_TDI_BIL_IS_TARAF> isTaraflari = new TList<AV001_TDI_BIL_IS_TARAF>();
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>), typeof(TDI_KOD_ADLI_BIRIM_ADLIYE));

            AV001_TDI_BIL_IS_TARAF tarafi = new AV001_TDI_BIL_IS_TARAF();
            tarafi.IS_TARAF_ID = 1;
            tarafi.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
            isTaraflari.Add(tarafi);

            AV001_TDI_BIL_IS_TARAF tarafs = new AV001_TDI_BIL_IS_TARAF();
            tarafs.IS_TARAF_ID = 2;
            tarafs.CARI_ID = icram.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.FindAll(vi => vi.CARI_ID != isTaraflari[0].CARI_ID).FirstOrDefault().CARI_ID;
            isTaraflari.Add(tarafs);

            return isTaraflari;
        }

        public TList<AV001_TDI_BIL_IS_TARAF> SozlesmeTaraflarindanAl(AV001_TDI_BIL_SOZLESME icram)
        {
            AV001_TDI_BIL_SOZLESME sozlesme = new AV001_TDI_BIL_SOZLESME();

            TList<AV001_TDI_BIL_IS_TARAF> isTaraflari = new TList<AV001_TDI_BIL_IS_TARAF>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>), typeof(TDI_KOD_ADLI_BIRIM_ADLIYE));

            AV001_TDI_BIL_IS_TARAF taraff = new AV001_TDI_BIL_IS_TARAF();
            taraff.IS_TARAF_ID = 1;
            taraff.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
            isTaraflari.Add(taraff);

            AV001_TDI_BIL_IS_TARAF tarafso = new AV001_TDI_BIL_IS_TARAF();
            tarafso.IS_TARAF_ID = 2;
            tarafso.CARI_ID = icram.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.FindAll(vi => !vi.YETKILI_MI).FirstOrDefault().SORUMLU_CARI_ID;
            isTaraflari.Add(tarafso);

            return isTaraflari;
        }

        private void CheckGuncelle(int secim)
        {
            switch (secim)
            {
                case 1: chkEkranHatirlat.Checked = true;
                    break;

                case 2: chkMailHatirlat.Checked = true;
                    break;

                case 3: chkSmsHatirlat.Checked = true;
                    break;

                case 4: chkEkranHatirlat.Checked = true;
                    chkMailHatirlat.Checked = true;
                    break;

                case 5: chkEkranHatirlat.Checked = true;
                    chkSmsHatirlat.Checked = true;
                    break;

                case 6: chkMailHatirlat.Checked = true;
                    chkSmsHatirlat.Checked = true;
                    break;

                case 7: chkEkranHatirlat.Checked = true;
                    chkMailHatirlat.Checked = true;
                    chkSmsHatirlat.Checked = true;
                    break;
            }
        }

        private void HatirlatmaCheckGuncelle()
        {
            try
            {
                List<AvukatProLib.CompInfo> comp = AvukatProLib.CompInfo.CompInfoListGetir();
                SirketComp = comp[0];
            }
            catch
            {
            }
        }

        #region <MB-20091204>

        //form güncelleme modunda açýlýrken dosya no bilgisinin gelmesi için eklendi.
        private void DosyaNoGetir(TList<AV001_TDI_BIL_IS> _MyIs)
        {
            if (_MyIs.Count > 0)
            {
                //if (c_lueModul.EditValue != null && c_lueModul.EditValue != DBNull.Value)

                ModulID = (this._bndIs.Current as AV001_TDI_BIL_IS).MODUL_ID ?? 0;


                switch (ModulID)
                {
                    case 1:
                        DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(_MyIs, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<NN_IS_ICRA_FOY>));
                        TList<NN_IS_ICRA_FOY> icraDosyaNo = DataRepository.NN_IS_ICRA_FOYProvider.GetByIS_ID(_MyIs[0].ID);
                        if (icraDosyaNo.Count > 0)
                            c_lueDosya.EditValue = icraDosyaNo[0].ICRA_FOY_ID;
                        break;

                    case 2:
                        DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(_MyIs, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<NN_IS_DAVA_FOY>));
                        TList<NN_IS_DAVA_FOY> davaDosyaNo = DataRepository.NN_IS_DAVA_FOYProvider.GetByIS_ID(_MyIs[0].ID);
                        if (davaDosyaNo.Count > 0)
                            c_lueDosya.EditValue = davaDosyaNo[0].DAVA_FOY_ID;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion <MB-20091204>

        #region <MB-20091204>

        //form güncelleme modunda açýlýrken proje bilgisinin gelmesi için eklendi.
        private void ProjeGetir(TList<AV001_TDI_BIL_IS> _MyIs)
        {
            if (_MyIs.Count > 0)
            {
                #region <MB-20102701>

                //Klasör ekranýndan iþ kaydý yapýlmak istendiðinde seçili klasörün kayýt ekranýnda default gelmesi eklendi.
                if (KlasorID != -1)
                {
                    lueProje.EditValue = KlasorID;
                    lueProje.Enabled = false;
                    return;
                }

                #endregion <MB-20102701>

                DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(_MyIs, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_IS>));
                TList<AV001_TDIE_BIL_PROJE_IS> myProje =
                    DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.GetByIS_ID(_MyIs[0].ID);

                if (myProje.Count > 0)
                    lueProje.EditValue = myProje[0].PROJE_ID;
            }
        }

        #endregion <MB-20091204>

        private void WorkCheck()
        {
            switch (c_lueOncelik.ItemIndex)
            {
                case 0: CheckTemizle();
                    CheckGuncelle(SirketComp.HatirlatmaCokAcil);
                    (_bndIs.Current as AV001_TDI_BIL_IS).HATIRLATILSIN_MI = true;
                    break;

                case 1: CheckTemizle();
                    CheckGuncelle(SirketComp.HatirlatmaAcil);
                    (_bndIs.Current as AV001_TDI_BIL_IS).HATIRLATILSIN_MI = true;
                    break;

                case 3: CheckTemizle();
                    CheckGuncelle(SirketComp.HatirlatmaBekleyebilir);
                    break;
            }
        }

        #endregion Methods

        private void lueBitisSaat_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lueBitisSaat.EditValue.ToString()) || (_bndIs.Current as AV001_TDI_BIL_IS).BITIS_TARIHI == null)
                return;

            DateTime bitisTarihi = (DateTime)(_bndIs.Current as AV001_TDI_BIL_IS).BITIS_TARIHI;
            bitisTarihi = new DateTime(bitisTarihi.Year, bitisTarihi.Month, bitisTarihi.Day, Convert.ToInt32(lueBitisSaat.Text.Split(':')[0]), Convert.ToInt32(lueBitisSaat.Text.Split(':')[1]), 0);

            if ((_bndIs.Current as AV001_TDI_BIL_IS).BITIS_TARIHI != bitisTarihi)
                (_bndIs.Current as AV001_TDI_BIL_IS).BITIS_TARIHI = bitisTarihi;
        }

        private void c_lueKategori_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //c_lueKategori
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.AltKategori, 6);
                frmalt.ShowDialog();

                for (int i = 0; i < c_lueKategori.Properties.Buttons.Count; i++)
                {
                    if (c_lueKategori.Properties.Buttons[i].Tag != null)
                    {
                        if (c_lueKategori.Properties.Buttons[i].Tag.ToString() == "ekle")
                        {
                            c_lueKategori.Properties.Buttons.RemoveAt(i);
                            i = 0;
                        }
                    }
                }

                AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(c_lueKategori, 6);
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            double time = 0;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    if (timeBitis.Time > timeBaslangic.Time)
                    {
                        timeBitis.Time = timeBaslangic.Time;
                    }
                    if (Convert.ToInt32(textBox1.Text) > 0)
                    {
                        time = 0;
                        timeBitis.Time = timeBaslangic.Time;
                        time = (Convert.ToInt32(textBox1.Text));
                        DateTime gelenZaman = timeBitis.Time;
                        timeBitis.Time = gelenZaman.AddMinutes(time);
                    }
                    else if (Convert.ToInt32(textBox1.Text) == 0 || textBox1.Text == "")
                    {
                        timeBitis.Time = timeBaslangic.Time;
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void timeBitis_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    DateTime ilkdeger = timeBaslangic.Time; //1
                    DateTime sondeger = timeBitis.Time;
                    System.TimeSpan zaman; //3
                    zaman = sondeger.Subtract(ilkdeger); //4
                    int toplamdakika = Convert.ToInt32(zaman.TotalMinutes); //5
                    textBox1.Text = "";
                    textBox1.Text = toplamdakika.ToString();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}