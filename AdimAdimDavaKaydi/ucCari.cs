using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi
{
    public partial class ucCari : DevExpress.XtraEditors.XtraUserControl
    {
        public static MemoryStream MyLayout;

        public bool aramadanMiGeliyor;

        public bool IsimBilgisiGuncellendi = false;

        private AV001_TDI_BIL_CARI _MyCari;

        private MultiEditorRow merow1;

        private MultiEditorRow merow2;

        private AV001_TDI_BIL_CARI tmpCari = new AV001_TDI_BIL_CARI();

        public ucCari()
        {
            InitializeComponent();
            rlkMeslek.CloseUp += rlkMeslek_CloseUp;
            vgCari.FocusedRecordChanged += vGridFocusedCariChanged;
        }

        public event IndexChangedEventHandler FocusedCariChanged;

        public AV001_TDI_BIL_CARI CurrentCari
        {
            get
            {
                if (vgCari.FocusedRecord > -1 && MyDataSource != null)
                {
                    return MyDataSource[vgCari.FocusedRecord];
                }
                return null;
            }
        }

        public AV001_TDI_BIL_CARI MyCari
        {
            get
            {
                return _MyCari;
            }
            set
            {
                _MyCari = value;
                if (value != null)
                {
                    value.ColumnChanged += myCari_ColumnChanged;
                    if (value.IL_ID.HasValue)
                        BelgeUtil.Inits.IlceGetirIleGore(rlkAdresIlce, value.IL_ID.Value);
                    if (value.IL2_ID.HasValue)
                        BelgeUtil.Inits.IlceGetirIleGore(rlueIlce2, value.IL2_ID.Value);
                    if (value.IL3_ID.HasValue)
                        BelgeUtil.Inits.IlceGetirIleGore(rlueIlce3, value.IL3_ID.Value);

                    pnlUnvanUpdate.Visible = true;
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_CARI> MyDataSource
        {
            get
            {
                if (vgCari.DataSource is TList<AV001_TDI_BIL_CARI>)
                    return (TList<AV001_TDI_BIL_CARI>)this.vgCari.DataSource;
                return null;
            }
            set
            {
                this.vgCari.DataSource = gcCari.DataSource = value;
                if (value != null)
                {
                    MyDataSource.AddingNew += mydatatableAddingNewItem;
                }
            }
        }

        public void vGridFocusedCariChanged(object sender, DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (FocusedCariChanged != null)
                FocusedCariChanged(sender, e);
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (gcCari.Visible)
            {
                gcCari.Visible = false;
                dataNavigatorExtended1.Visible = true;
                vgCari.Visible = true;
            }
            else
            {
                gcCari.Visible = true;
            }
        }

        private void initKontrol()
        {
            //Tıklayınca Dolu Gelecekler
            rlkCari.NullText = "Seç";
            rlkBanka.NullText = "Seç";
            rlkMeslek.NullText = "Seç";
            rlkAdresIl.NullText = "Seç";
            rlkAdresIlce.NullText = "Seç";
            rlueIl2.NullText = "Seç";
            rlueIl3.NullText = "Seç";
            rlueIlce2.NullText = "Seç";
            rlueIlce3.NullText = "Seç";
            rLueSahisDurumGetir.NullText = "Seç";
            rLueAdresDurum.NullText = "Seç";
            rlkBankaSube.NullText = "Seç";
            rLueDilSecim2.NullText = "Seç";
            rlkOkul.NullText = "Seç";
            //Dolu gelecekler
            rlkAdresTur.NullText = "Seç";
            rlkAdresUlke.NullText = "Seç";
            rlkFirmaTur.NullText = "Seç";
            rlkOzelKod.NullText = "Seç";
            rlkIsSozlesme.NullText = "Seç";
            rlkYCariUnvan.NullText = "Seç";
            rlkTicariSicilYeriIlce.NullText = "Seç";
            rlkAktifAdres.NullText = "Seç";
            rlkCariTip.NullText = "Seç";
            rlkIsSozlesme.NullText = "Seç";
            rLueTemsilTipi.NullText = "Seç";
            rtxtStringAlan.NullText = "Seç";

            BelgeUtil.Inits.AdresTurGetir(rlkAdresTur);
            BelgeUtil.Inits.UlkeGetir(rlkAdresUlke);
            BelgeUtil.Inits.UlkeGetir(rlueUlke2);
            BelgeUtil.Inits.UlkeGetir(rlueUlke3);
            BelgeUtil.Inits.FirmaTurGetir(rlkFirmaTur);
            BelgeUtil.Inits.CariOzelKodGetir(rlkOzelKod);
            BelgeUtil.Inits.IsSozlesmeGetir(rlkIsSozlesme);
            BelgeUtil.Inits.CariUnvanGetir(rlkYCariUnvan);
            BelgeUtil.Inits.IlceGetirOzetli(rlkTicariSicilYeriIlce);
            BelgeUtil.Inits.CariAktifAdresGetir(rlkAktifAdres);
            BelgeUtil.Inits.CariTipiGetir(rlkCariTip);
            BelgeUtil.Inits.IsSozlesmeGetir(rlkIsSozlesme);
            BelgeUtil.Inits.CariTemsilTipiGetir(rLueTemsilTipi);
            BelgeUtil.Inits.GetBuyukHarfByRepositoryTextEdit(rtxtStringAlan);
            rowStatuChk.Properties.FieldName = "STATU";
            StatuDoldur(rchklSahisStatuleri);

            if ((this.ParentForm as frmCariGenelGiris).YeniKayitMi)
            {
                rlkCari.Enter += delegate { BelgeUtil.Inits.perCariGetir2(rlkCari); };
                rlkBanka.Enter += delegate { BelgeUtil.Inits.BankaGetir(rlkBanka); };
                rlkMeslek.Enter += delegate { BelgeUtil.Inits.MeslekGetir(rlkMeslek); };
                rlkAdresIl.Enter += delegate { BelgeUtil.Inits.IlGetir(rlkAdresIl); };
                rlueIl2.Enter += delegate { BelgeUtil.Inits.IlGetir(rlueIl2); };
                rlueIl3.Enter += delegate { BelgeUtil.Inits.IlGetir(rlueIl3); };
                rlkAdresIlce.Enter += delegate { BelgeUtil.Inits.IlceGetirTumu(rlkAdresIlce); };
                rlueIlce2.Enter += delegate { BelgeUtil.Inits.IlceGetirTumu(rlueIlce2); };
                rlueIlce3.Enter += delegate { BelgeUtil.Inits.IlceGetirTumu(rlueIlce3); };
                rLueSahisDurumGetir.Enter += delegate { BelgeUtil.Inits.SahisDurumGetir(rLueSahisDurumGetir); };
                rLueAdresDurum.Enter += delegate { BelgeUtil.Inits.AdresDurumGetir(rLueAdresDurum); };
                rlkBankaSube.Enter += delegate { BelgeUtil.Inits.BankaSubeGetir(rlkBankaSube); };
                rLueDilSecim2.Enter += delegate { BelgeUtil.Inits.DilKodGetir(rLueDilSecim2); };
                rlkOkul.Enter += delegate { BelgeUtil.Inits.OkulGetir(rlkOkul); };
            }
            else
            {
                BelgeUtil.Inits.perCariGetir2(rlkCari);
                BelgeUtil.Inits.BankaGetir(rlkBanka);
                BelgeUtil.Inits.MeslekGetir(rlkMeslek);
                BelgeUtil.Inits.IlGetir(rlkAdresIl);
                BelgeUtil.Inits.IlGetir(rlueIl2);
                BelgeUtil.Inits.IlGetir(rlueIl3);
                BelgeUtil.Inits.IlceGetirTumu(rlkAdresIlce);
                BelgeUtil.Inits.IlceGetirTumu(rlueIlce2);
                BelgeUtil.Inits.IlceGetirTumu(rlueIlce3);
                BelgeUtil.Inits.SahisDurumGetir(rLueSahisDurumGetir);
                BelgeUtil.Inits.AdresDurumGetir(rLueAdresDurum);
                BelgeUtil.Inits.BankaSubeGetir(rlkBankaSube);
                BelgeUtil.Inits.DilKodGetir(rLueDilSecim2);
                BelgeUtil.Inits.OkulGetir(rlkOkul);
            }

            if (ucCari.MyLayout != null)
            {
                ucCari.MyLayout.Position = 0;
                vgCari.RestoreLayoutFromStream(ucCari.MyLayout);
            }
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp.Properties.DisplayMember.Contains("KOD") && e.IsTypedValue)
            {
                try
                {
                    AV001_TDI_KOD_CARI_OZEL ozel = new AV001_TDI_KOD_CARI_OZEL();
                    ozel.KOD = e.TypedValue;
                    DataRepository.AV001_TDI_KOD_CARI_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_CARI_OZEL>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod başarıyla eklenmiştir.");
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
            if (e.SenderLookUp.Properties.Name != null && e.SenderLookUp.Properties.Name.Contains("rlkCari"))
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                if (e.IsTypedValue)
                    frm.tmpCariAd = e.TypedValue;

                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          DialogResult dr = frm.KayitBasarili;
                                          if (dr == System.Windows.Forms.DialogResult.OK)
                                          {
                                              BelgeUtil.Inits.perCariGetir(e.SenderLookUp.Properties);
                                          }
                                      };
            }
        }

        private void myCari_ColumnChanged(object sender, AV001_TDI_BIL_CARIEventArgs e)
        {
            AV001_TDI_BIL_CARI myCari = (AV001_TDI_BIL_CARI)sender;
            if (e.Column == AV001_TDI_BIL_CARIColumn.FIRMA_MI)
            {
                crowFirma.Visible = myCari.FIRMA_MI;
                if (myCari.FIRMA_MI == false)
                {
                    rowVERGI_NO_KULLANIYOR_MU.Visible = true;
                    crowFirma.Visible = false;
                    crowMeslek.Visible = true;
                    crowDigerBilgiler.Visible = true;
                    vgCari.Rows["mrowVergiDaireNo"].Appearance.BackColor = System.Drawing.Color.White;
                    vgCari.Rows["mrowVergiDaireNo"].Properties.ImageIndex = -1;
                }
                else
                {
                    rowVERGI_NO_KULLANIYOR_MU.Visible = true;
                    crowFirma.Visible = true;
                    crowFirma.Expanded = true;
                    crowMeslek.Visible = false;
                    crowDigerBilgiler.Visible = false;
                    vgCari.Rows["mrowVergiDaireNo"].Appearance.BackColor = System.Drawing.Color.FromArgb(((((255)))),
                                                                                                         ((((128)))),
                                                                                                         ((((0)))));
                    vgCari.Rows["mrowVergiDaireNo"].Properties.ImageIndex = 0;
                }
            }

            else if (e.Column == AV001_TDI_BIL_CARIColumn.MUVEKKIL_MI || e.Column == AV001_TDI_BIL_CARIColumn.PERSONEL_MI)
            {
                myCari.KARSI_TARAF_MI = false;
            }

            else if (e.Column == AV001_TDI_BIL_CARIColumn.AD)
            {
                if (myCari.FIRMA_MI)
                    myCari.UNVAN = e.Value.ToString();
            }
            else if (e.Column == AV001_TDI_BIL_CARIColumn.IL_ID)
                BelgeUtil.Inits.IlceGetirIleGore(rlkAdresIlce, (int)e.Value);
            else if (e.Column == AV001_TDI_BIL_CARIColumn.IL2_ID)
                BelgeUtil.Inits.IlceGetirIleGore(rlueIlce2, (int)e.Value);
            else if (e.Column == AV001_TDI_BIL_CARIColumn.IL3_ID)
                BelgeUtil.Inits.IlceGetirIleGore(rlueIlce3, (int)e.Value);
            else if (e.Column == AV001_TDI_BIL_CARIColumn.ULKE_ID)
                BelgeUtil.Inits.IlGetirUlkeyeGore(rlkAdresIl, (int)e.Value);
            else if (e.Column == AV001_TDI_BIL_CARIColumn.ULKE2_ID)
                BelgeUtil.Inits.IlGetirUlkeyeGore(rlueIl2, (int)e.Value);
            else if (e.Column == AV001_TDI_BIL_CARIColumn.ULKE3_ID)
                BelgeUtil.Inits.IlGetirUlkeyeGore(rlueIl3, (int)e.Value);
            else if (e.Column == AV001_TDI_BIL_CARIColumn.SAHIS_DURUM_ID)//İflas ve Tasfiye durumlarında adın başına istenen bilginin yazılmasını sağlamak için eklendi. MB
            {
                if ((int)e.Value == 8)//İflas Etmiştir
                {
                    var unvanDegisikligi = myCari.AV001_TDI_BIL_CARI_UNVAN_DEGISIKLIKCollection.AddNew();
                    unvanDegisikligi.ESKI_UNVAN = myCari.AD;

                    myCari.AD = "MÜFLİS " + myCari.AD;
                    IsimBilgisiGuncellendi = true;
                }
                else if ((int)e.Value == 9)//Tasfiye Olmuştur
                {
                    var unvanDegisikligi = myCari.AV001_TDI_BIL_CARI_UNVAN_DEGISIKLIKCollection.AddNew();
                    unvanDegisikligi.ESKI_UNVAN = myCari.AD;

                    myCari.AD = "TASFİYE HALİNDE " + myCari.AD;
                    IsimBilgisiGuncellendi = true;
                }
            }
        }

        private void mydatatableAddingNewItem(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_CARI myCari = (AV001_TDI_BIL_CARI)e.NewObject;
            if (myCari == null)
                myCari = new AV001_TDI_BIL_CARI();

            myCari.KOD = BelgeUtil.Inits.CariYeniKodGetir();
            //if (BelgeUtil.Inits._per_CariGetir == null)
            //    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
            //var kod = BelgeUtil.Inits._per_CariGetir.OrderByDescending(vi => vi.ID).FirstOrDefault().KOD;
            //myCari.KOD = (Convert.ToInt32(kod) + 2).ToString();

            //rowVERGI_NO_KULLANIYOR_MU.Visible = myCari.FIRMA_MI;
            rowVERGI_NO_KULLANIYOR_MU.Visible = true;

            myCari.ColumnChanged += myCari_ColumnChanged;
            e.NewObject = myCari;
        }

        private void popupConEditUnvanUpdate_Click(object sender, EventArgs e)
        {
            DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(MyCari, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_UNVAN_DEGISIKLIK>));
            gcEskiUnvanlar.DataSource = MyCari.AV001_TDI_BIL_CARI_UNVAN_DEGISIKLIKCollection;

            AV001_TDI_BIL_CARI_UNVAN_DEGISIKLIK unvanUpdate = MyCari.AV001_TDI_BIL_CARI_UNVAN_DEGISIKLIKCollection.AddNew();
            unvanUpdate.ESKI_UNVAN = MyCari.AD;
        }

        private void rchklSahisStatuleri_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (MyDataSource != null && MyDataSource.Count > 0)
            {
                AV001_TDI_BIL_CARI cari = MyDataSource[0];
                cari.AVUKAT_MI = false;
                cari.MUVEKKIL_MI = false;
                cari.KARSI_TARAF_MI = false;
                cari.PERSONEL_MI = false;
                cari.KURUM_AVUKATI_MI = false;
                cari.AVUKAT_ORTAKLIGI_MI = false;
                cari.BILIRKISI_MI = false;
                cari.ADLI_BIRIM_MI = false;
                cari.ADLI_PERSONEL_MI = false;
                cari.HARCDAN_MUAF_MI = false;

                foreach (string s in e.NewValue.ToString().Split(','))
                {
                    if (s.Trim() == "Avukat")
                        cari.AVUKAT_MI = true;
                    else if (s.Trim() == "Müvekkil")
                        cari.MUVEKKIL_MI = true;
                    else if (s.Trim() == "Karşı Taraf")
                        cari.KARSI_TARAF_MI = true;
                    else if (s.Trim() == "Personel")
                        cari.PERSONEL_MI = true;
                    else if (s.Trim() == "Kurum Avukatı")
                        cari.KURUM_AVUKATI_MI = true;
                    else if (s.Trim() == "Avukat Ortaklığı")
                        cari.AVUKAT_ORTAKLIGI_MI = true;
                    else if (s.Trim() == "Bilirkişi")
                        cari.BILIRKISI_MI = true;
                    else if (s.Trim() == "Adli Birim")
                        cari.ADLI_BIRIM_MI = true;
                    else if (s.Trim() == "Adli Personel")
                        cari.ADLI_PERSONEL_MI = true;
                    else if (s.Trim() == "Harçdan Muaf")
                        cari.HARCDAN_MUAF_MI = true;
                }

                if (cari.AVUKAT_MI && cari.PERSONEL_MI)
                {
                    vgCari.Rows["mrowVergiDaireNo"].Appearance.BackColor = System.Drawing.Color.FromArgb(((((255)))),
                                                                                                         ((((128)))),
                                                                                                         ((((0)))));
                    vgCari.Rows["mrowVergiDaireNo"].Properties.ImageIndex = 0;

                    vgCari.Rows["rowSG_NO"].Appearance.BackColor = System.Drawing.Color.FromArgb(((((255)))),
                                                                                                 ((((128)))), ((((0)))));
                    vgCari.Rows["rowSG_NO"].Properties.ImageIndex = 0;
                }

                else
                {
                    vgCari.Rows["mrowVergiDaireNo"].Appearance.BackColor = System.Drawing.Color.White;
                    vgCari.Rows["mrowVergiDaireNo"].Properties.ImageIndex = -1;

                    vgCari.Rows["rowSG_NO"].Appearance.BackColor = System.Drawing.Color.White;
                    vgCari.Rows["rowSG_NO"].Properties.ImageIndex = -1;
                }
            }
        }

        private void rlkMeslek_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //AV001_TDI_BIL_MASRAF_AVANS_DETAY drt = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();

            //MESLEK Seçili ise
            if (e.Value != null)
            {
                int meslekID = Convert.ToInt32(e.Value);
                if (meslekID != 3)
                {
                    if (vgCari.Rows["mrowAOrtSicilNoBaroBSicilNo"] is MultiEditorRow ||
                        vgCari.Rows["mrowKayitliOlduguBaroSicilNo"] is MultiEditorRow)
                    {
                        merow1 = (MultiEditorRow)vgCari.Rows["mrowAOrtSicilNoBaroBSicilNo"];
                        merow2 = (MultiEditorRow)vgCari.Rows["mrowKayitliOlduguBaroSicilNo"];
                        merow1.Visible = false;
                        merow2.PropertiesCollection["KAYITLI_OLDUGU_BARO"].ReadOnly = true;
                        merow2.PropertiesCollection["BARO_SICIL_NO"].Caption = "Meslek Sicil No";
                    }
                }
                else
                {
                    if (merow1 != null & merow2 != null)
                    {
                        merow1.Visible = true;
                        merow2.PropertiesCollection["KAYITLI_OLDUGU_BARO"].ReadOnly = false;
                        merow2.PropertiesCollection["BARO_SICIL_NO"].Caption = "Baro Sicil No";
                    }
                }
            }
        }

        private void rpctResim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                e.NewValue = ResimAraclari.ResmiBoyutlandir(e.NewValue as byte[], new Size(70, 78));
            }
        }

        private void sbtnUpdateUnvan_Click(object sender, EventArgs e)
        {
            MyCari.AD = txtYeniUnvan.Text.ToUpper();
        }

        private void StatuDoldur(RepositoryItemCheckedComboBoxEdit cmb)
        {
            cmb.Items.Clear();
            cmb.AutoHeight = true;
            foreach (string st in Enum.GetNames(typeof(AvukatProLib.Extras.CariStatu)))
            {
                cmb.Items.Add(st.Replace("_", " "));
            }
        }

        private void ucCari_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (!aramadanMiGeliyor)
                    MyDataSource = new TList<AV001_TDI_BIL_CARI>();

                initKontrol();
            }
        }

        private void vgCari_ValidateRecord(object sender, ValidateRecordEventArgs e)
        {
            if (e.RecordIndex >= 0)
            {
                AV001_TDI_BIL_CARI cari = (vgCari.DataSource as TList<AV001_TDI_BIL_CARI>)[e.RecordIndex];
                DavaCreated dc = new DavaCreated();
                cari.ADRES_1 = dc.IlkHarfiBuyut(cari.ADRES_1);
                cari.ADRES_2 = dc.IlkHarfiBuyut(cari.ADRES_2);
                cari.ADRES_3 = dc.IlkHarfiBuyut(cari.ADRES_3);
                cari.ADRES2_1 = dc.IlkHarfiBuyut(cari.ADRES2_1);
                cari.ADRES2_2 = dc.IlkHarfiBuyut(cari.ADRES2_2);
                cari.ADRES2_3 = dc.IlkHarfiBuyut(cari.ADRES2_3);
            }
        }
    }
}