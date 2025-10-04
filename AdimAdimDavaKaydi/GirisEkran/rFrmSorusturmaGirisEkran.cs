using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.UserControls;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Nodes;
using AdimAdimDavaKaydi.UserControls.ucRapor;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmSorusturmaGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public bool? secim;

        private DataTable _MyDataSourceDeep;

        private int? Adliye;


        private int? DosyaDurum;

        private string DosyaNo;

        private string EsasNo;

        private rFrmSorusturmaTakip frmSorusTakip;

        private int? Konu;

        private VList<R_SORUSTURMA_GENEL_ARAMA> listem = new VList<R_SORUSTURMA_GENEL_ARAMA>();

        private ImageList myImageList = new ImageList();


        private int? OzelKod1;

        private int? OzelKod2;

        private int? OzelKod3;

        private int? OzelKod4;

        private int? SorumluAvukat;

        private int? SorusturmaDurumu;

        private DateTime? SorusturmaTarihi;

        private int? Taraf;

        public rFrmSorusturmaGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
            xtraTabControl1.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;
            rgDurum.SelectedIndexChanged += rgDurum_SelectedIndexChanged;
            rgLeyh.SelectedIndexChanged += rgLeyh_SelectedIndexChanged;
            btnAsamaSorgula.Click += btnAsamaSorgula_Click;
            chBoxAsamalarTumu.CheckedChanged += chBoxAsamalarTumu_CheckedChanged;
            btnAra.Click += btnAra_Click;
            btnTumKosullariTemizle.Click += btnTumKosullariTemizle_Click;
            tlSorusturmaAsamalar.AfterCheckNode += tlSorusturmaAsamalar_AfterCheckNode;

            #region Merkez Harici Görünmeyecekler (PRATÝK ARAMA - PÝVOT)

            if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null &&
                AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
            {
                //Abdurrahim Kaplan:
                //dockPanel1.Visibility = DockVisibility.Hidden;
                //satýrý hata verdiðinden try catch bloðuna alýndý.
                //begin
                try
                {
                    dockPanel1.Visibility = DockVisibility.Hidden;
                }
                catch { }

                //end

                dockPanel1.Enabled = false;
            }

            #endregion Merkez Harici Görünmeyecekler (PRATÝK ARAMA - PÝVOT)
        }

        public DataTable MyDataSourceDeep
        {
            get { return _MyDataSourceDeep; }
            set
            {
                _MyDataSourceDeep = value;
                BindData();
            }
        }

        private DataTable _ProjeTable
        {
            get
            {
                DataTable result = new DataTable("Asama");
                result.Columns.Add("ADI");
                return result;
            }
        }

        public void AramalarýTemizleGenel()
        {
            FormlariTemizle(nvbgrpGenelAramaBilgileri.Controls);
            //FormlariTemizle(grpSikayetNedenleri.Controls);
            rgLeyh.SelectedIndex = 3;
            ucHazirlik1.MyDataSource = MyDataSourceDeep;
            rgZamanDilimi.SelectedIndex = 6;
        }

        public void BindData()
        {
            ucHazirlik1.MyDataSource = MyDataSourceDeep;
        }

        public void EditorAc()
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        public void FoyCikis()
        {
            DialogResult dr = XtraMessageBox.Show("Soruþturma ekraný kapatýlacak. Çýkmak istediðinizden emin misiniz?",
                                                  "Çýkýþ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                this.Close();
        }

        public void FoyuAc()
        {
            TakibeGonder();
        }

        public void FoyuYenile()
        {
            this.ucHazirlik1.gridHazirlik.RefreshDataSource();
        }

        public void GelismisAramaSorgula()
        {
            try
            {
                DataTable dt = new DataTable();

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                string where = " where a.ID<>-1";

                if (lueOzelKod1_2.EditValue != null)
                {
                    cn.AddParams("@OZEL_KOD1", lueOzelKod1_2.EditValue);
                    where += " and a.OZEL_KOD1=@OZEL_KOD1";
                }

                if (lueOzelKod2_2.EditValue != null)
                {
                    cn.AddParams("@OZEL_KOD2", lueOzelKod2_2.EditValue);
                    where += " and a.OZEL_KOD2=@OZEL_KOD2";
                }

                if (lueOzelKod3_2.EditValue != null)
                {
                    cn.AddParams("@OZEL_KOD3", lueOzelKod3_2.EditValue);
                    where += " and a.OZEL_KOD3=@OZEL_KOD3";
                }

                if (lueOzelKod4_2.EditValue != null)
                {
                    cn.AddParams("@OZEL_KOD4", lueOzelKod4_2.EditValue);
                    where += " and a.OZEL_KOD4=@OZEL_KOD4";
                }

                if (!string.IsNullOrEmpty(txtRef1_2.Text))
                {
                    cn.AddParams("@REFERANS_NO", txtRef1_2.Text);
                    where += " and a.REFERANS_NO=@REFERANS_NO";
                }

                if (!string.IsNullOrEmpty(txtRef2_2.Text))
                {
                    cn.AddParams("@REFERANS_NO2", txtRef2_2.Text);
                    where += " and a.REFERANS_NO2=@REFERANS_NO2";
                }

                if (!string.IsNullOrEmpty(txtRef3_2.Text))
                {
                    cn.AddParams("@REFERANS_NO3", txtRef3_2.Text);
                    where += " and a.REFERANS_NO3=@REFERANS_NO3";
                }

                if (dtSorusturmaTarihi.DateTime.ToShortDateString() != "01.01.0001")
                {
                    cn.AddParams("@SIKAYET_TARIHI", dtSorusturmaTarihi.DateTime);
                    where += " and a.SIKAYET_TARIHI=@SIKAYET_TARIHI";
                }

                if (lueKonu2.EditValue != null)
                {
                    cn.AddParams("@SIKAYET_KONU", lueKonu2.EditValue);
                    where += " and a.SIKAYET_KONU=@SIKAYET_KONU";
                }

                if (lueSorumluAvukat2.EditValue != null)
                {
                    cn.AddParams("@SORUMLU_AVUKAT_CARI_ID", lueSorumluAvukat2.EditValue);
                    where += " and a.SORUMLU_AVUKAT_CARI_ID=@SORUMLU_AVUKAT_CARI_ID";
                }

                if (!string.IsNullOrEmpty(txtEsasNo2.Text))
                {
                    cn.AddParams("@HAZIRLIK_ESAS_NO", txtEsasNo2.Text);
                    where += " and a.HAZIRLIK_ESAS_NO like '%' + @HAZIRLIK_ESAS_NO + '%'";
                }

                if (!string.IsNullOrEmpty(txtDosyaNo2.Text))
                {
                    cn.AddParams("@HAZIRLIK_NO", txtDosyaNo2.Text);
                    where += " and a.HAZIRLIK_NO like '%' + @HAZIRLIK_NO + '%'";
                }

                if (lueAdliye2.EditValue != null)
                {
                    cn.AddParams("@ADLI_BIRIM_ADLIYE", lueAdliye2.EditValue);
                    where += " and a.ADLI_BIRIM_ADLIYE=@ADLI_BIRIM_ADLIYE";
                }

                if (lueTarafAdi2.EditValue != null)
                {
                    if (!string.IsNullOrEmpty(lueTarafAdi2.EditValue.ToString()))
                    {
                        cn.AddParams("@TARAF", lueTarafAdi2.EditValue);
                        where += " and (a.TAKIP_EDEN_CARI_ID=@TARAF or a.TAKIP_EDILEN_CARI_ID=@TARAF)"; 
                    }
                }                

                if (rgDurum.SelectedIndex == 0)
                    where += " and b.DOSYA_DURUM_ID = 1";
                else if (rgDurum.SelectedIndex == 1)
                    where += " and b.DOSYA_DURUM_ID <> 1";

                if (lueDosyaDurum.EditValue != null)
                {
                    cn.AddParams("@HAZIRLIK_DURUM_ID", lueDosyaDurum.EditValue);
                    where += " and b.HAZIRLIK_DURUM_ID=@HAZIRLIK_DURUM_ID";
                }

                if (lueDurum2.EditValue != null)
                {
                    cn.AddParams("@DOSYA_DURUM_ID", lueDurum2.EditValue);
                    where += " and b.DOSYA_DURUM_ID=@DOSYA_DURUM_ID";
                }

                if (rgLeyh.SelectedIndex == 0)
                    where += " (SELECT HANGI_TARAFI FROM dbo.TDIE_KOD_TARAF_SIFAT WHERE ID = (SELECT top(1)TARAF_SIFAT_ID FROM dbo.AV001_TD_BIL_HAZIRLIK_TARAF WHERE HAZIRLIK_ID=A.ID AND TARAF_KODU=1))='DAVA EDEN'";
                else if (rgLeyh.SelectedIndex == 1)
                    where += " (SELECT HANGI_TARAFI FROM dbo.TDIE_KOD_TARAF_SIFAT WHERE ID = (SELECT top(1)TARAF_SIFAT_ID FROM dbo.AV001_TD_BIL_HAZIRLIK_TARAF WHERE HAZIRLIK_ID=A.ID AND TARAF_KODU=1))='DAVA EDÝLEN'";

                if (rgDosyalar.SelectedIndex == 0)
                    where += " and b.DOSYA_DURUM_ID = 2 and a.SORUMLU_AVUKAT_CARI_ID=" + Kimlikci.Kimlik.Cari_ID;
                else if (rgDosyalar.SelectedIndex == 1)
                    where += " and a.SORUMLU_AVUKAT_CARI_ID=" + Kimlikci.Kimlik.Cari_ID;

                if (dtSorusturmaTarihi.DateTime.ToShortDateString() == "01.01.0001")
                {
                    if (rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString() != "Tumu")
                        where += Metotlar.ZamanDilimiParametresiOlustur(cn, "SIKAYET_TARIHI", rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString()).Replace(" SIKAYET_TARIHI", " a.SIKAYET_TARIHI");
                }

                dt = cn.GetDataTable("select convert(bit, 0) as IsSelected, a.TAKIP_EDEN_CARI, a.TAKIP_EDILEN, a.TAKIP_EDEN_TARAF_SIFAT, a.TAKIP_EDILEN_TARAF_SIFAT, a.TAKIP_EDEN_TARAF_KODU, a.TAKIP_EDILEN_TARAF_KODU, a.IZLEYEN_AVUKAT, a.SORUMLU_SAVCI1, a.SORUMLU_SAVCI2, a.KONTROL_KIM, a.KAYIT_TARIHI, a.ACIKLAMA, a.REFERANS_NO3, a.REFERANS_NO2, a.HAZIRLIK_ESAS_NO, a.HAZIRLIK_TARIH, a.SIKAYET_TARIHI, a.HAZIRLIK_NO, a.SORUMLU_AVUKAT_CARI_ID, a.SORUMLU_AVUKAT, a.SIKAYET_KONU, a.HAZIRLIK_DURUM, a.ADLI_BIRIM_ADLIYE, a.ADLI_BIRIM_GOREV, a.ADLI_BIRIM_NO, a.ID, a.TAKIP_EDEN_CARI_ID, a.TAKIP_EDILEN_CARI_ID, a.IZLEYEN_AVUKAT_CARI_ID, a.OZEL_KOD1, a.OZEL_KOD2, a.OZEL_KOD3, a.OZEL_KOD4, a.REFERANS_NO, b.ESKI_RAF_NO from R_SORUSTURMA_GENEL_ARAMA(nolock) a INNER JOIN dbo.AV001_TD_BIL_HAZIRLIK(nolock) b ON b.ID=a.ID" + where);

                ucHazirlik1.MyDataSource = dt;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        public void LoadData()
        {
            //lueOzelDosyaDurumu2.Properties.NullText = "Seç";
            //lueOzelDosyaDurumu2.Enter += delegate { BelgeUtil.Inits.FoyOzelDurumGetir(lueOzelDosyaDurumu2); };

            lueDosyaDurum.Properties.NullText = "Seç";
            lueDosyaDurum.Enter += delegate { BelgeUtil.Inits.HazirlikDurumGetir(lueDosyaDurum); };

            //lueSikayetNedenKodId.Properties.NullText = "Seç";
            //lueSikayetNedenKodId.Enter += delegate { BelgeUtil.Inits.HazirlikSikayetNedenGetir(lueSikayetNedenKodId); };

            //lueSube2.Properties.NullText = "Seç";
            //lueSube2.Enter += delegate { BelgeUtil.Inits.BankaSubeGetir(lueSube2); };

            //lueDosyaninYeri2.Properties.NullText = "Seç";
            //lueDosyaninYeri2.Enter += delegate { BelgeUtil.Inits.FoyYeriGetir(lueDosyaninYeri2); };

            //lueDosyaBirim2.Properties.NullText = "Seç";
            //lueDosyaBirim2.Enter += delegate { BelgeUtil.Inits.FoyBirimGetirEdit(lueDosyaBirim2); };

            //lueTahsilatDurumu2.Properties.NullText = "Seç";
            //lueTahsilatDurumu2.Enter += delegate { BelgeUtil.Inits.TahsilatdurumGetir(lueTahsilatDurumu2); };

            //lueKrediGrubu2.Properties.NullText = "Seç";
            //lueKrediGrubu2.Enter += delegate { BelgeUtil.Inits.KrediGrubu(lueKrediGrubu2); };

            //lueKrediTipi2.Properties.NullText = "Seç";
            //lueKrediTipi2.Enter += delegate { BelgeUtil.Inits.KrediTipiGetir(lueKrediTipi2); };

            lueAdliye2.Properties.NullText = "Seç";
            lueAdliye2.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye2); };

            lueTarafAdi2.Enter += delegate { AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTarafAdi2, null); };

            //lueBanka2.Properties.NullText = "Seç";
            //lueBanka2.Enter += delegate { BelgeUtil.Inits.BankaGetir(lueBanka2); };

            lueSorumluAvukat2.Properties.NullText = "Seç";
            lueSorumluAvukat2.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAvukat2); };

            lueKonu2.Properties.NullText = "Seç";
            lueKonu2.Enter += delegate { BelgeUtil.Inits.SikayetKonuDavaTalepCezaGetir(lueKonu2, "C"); };

            //lueDurum2.Properties.NullText = "Seç";
            //lueDurum2.Enter += delegate { BelgeUtil.Inits.FoyDurumGetir(lueDurum2); };

            //lueKarsiTarafVekili.Properties.NullText = "Seç";
            //lueKarsiTarafVekili.Enter += delegate { BelgeUtil.Inits.CariAvukatGetir(lueKarsiTarafVekili.Properties); };

            lueOzelKod1_2.Properties.NullText = "Seç";
            lueOzelKod1_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1_2, 1, Modul.Sorusturma); };

            lueOzelKod2_2.Properties.NullText = "Seç";
            lueOzelKod2_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2_2, 2, Modul.Sorusturma); };

            lueOzelKod3_2.Properties.NullText = "Seç";
            lueOzelKod3_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3_2, 3, Modul.Sorusturma); };

            lueOzelKod4_2.Properties.NullText = "Seç";
            lueOzelKod4_2.Enter += delegate { BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4_2, 4, Modul.Sorusturma); };
        }

        public void TakibeGonder()
        {
            try
            {
                if (tabSorusturmaArama.SelectedTabPage == tabpGelismisArama)
                {
                    // rFrmSorusturmaTakip frmSorusTakip = new rFrmSorusturmaTakip();
                    listem = ucHazirlikArama.GetSelectedFoy(ucHazirlik1.MyDataSource);

                    TList<AV001_TD_BIL_HAZIRLIK> foyList = new TList<AV001_TD_BIL_HAZIRLIK>();
                    foreach (var item in listem)
                    {
                        foyList.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(item.ID));
                    }
                    if (foyList.Count > 0)
                    {
                        if (frmSorusTakip == null || frmSorusTakip.IsDisposed)
                        {
                            frmSorusTakip = new rFrmSorusturmaTakip();
                        }
                        frmSorusTakip.Show(foyList);
                    }
                    else
                    {
                        DialogResult dr =
                            XtraMessageBox.Show(
                                "Seçilen kayýt yok. Bütün kayýtlarý açmak istediðinizden emin misiniz?", "Foy Arama",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            //listem = ucHazirlik1.MyDataSource;
                            TList<AV001_TD_BIL_HAZIRLIK> foyList2 = new TList<AV001_TD_BIL_HAZIRLIK>();
                            foreach (DataRow item in ucHazirlik1.MyDataSource.Rows)
                            {
                                foyList2.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(DataRepository.R_SORUSTURMA_GENEL_ARAMAProvider.Get("Id=" + item["Id"].ToString(), "Id")[0].ID));
                            }
                            if (frmSorusTakip == null || frmSorusTakip.IsDisposed)
                            {
                                frmSorusTakip = new rFrmSorusturmaTakip();
                            }
                            frmSorusTakip.Show(foyList2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        public void YeniFoy()
        {
            AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris frm = new rfrmSorusturmaGiris();
            frm.Show();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ucHazirlik1 = new AdimAdimDavaKaydi.UserControls.ucHazirlikArama();
            this.navBarGroupControlContainer1.Controls.Add(this.ucHazirlik1);

            //
            // ucHazirlik1
            //
            this.ucHazirlik1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHazirlik1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                            System.Drawing.FontStyle.Regular,
                                                            System.Drawing.GraphicsUnit.Point, ((162)));
            this.ucHazirlik1.Location = new System.Drawing.Point(0, 0);

            this.ucHazirlik1.Name = "ucHazirlik1";
            this.ucHazirlik1.Size = new System.Drawing.Size(982, 280);
            this.ucHazirlik1.TabIndex = 3;

            //LOAD

            ucHazirlik1.KayitSilindi += ucHazirlik1_KayitSilindi;
            BindData();

            BackgroundWorker bWorker = new BackgroundWorker();
            bWorker.DoWork += delegate { AsamaDoldur(); };
            bWorker.RunWorkerAsync();

            LoadData();

            //TARIH         :  10 Eylül 2009 Perþembe
            //KODU YAZAN    :  Mehmet Emin AYDOÐDU
            //NEDENI        :  Özel Kodlar ve Referans Baþlýklarýnýn Veri Tabnýndan Alýnmasý
            //Mehmet Begin

            #region Ozellestirme

            lblRef1.Text = Kimlikci.Kimlik.SorusturmaReferans.Referans1;
            lblRef2.Text = Kimlikci.Kimlik.SorusturmaReferans.Referans2;
            lblRef3.Text = Kimlikci.Kimlik.SorusturmaReferans.Referans3;
            lblSorOzelKod1.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod1;
            lblSorOzelKod2.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod2;
            lblSorOzelKod3.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod3;
            lblSorOzelKod4.Text = Kimlikci.Kimlik.SorusturmaOzelKod.OzelKod4;
            //lblSorNedRef1.Text = Kimlikci.Kimlik.SorusturmaReferans.Referans1;
            //lblSorNedRef2.Text = Kimlikci.Kimlik.SorusturmaReferans.Referans2;

            //TARIH         :  29 Eylül 2009 Çarþamba
            //KODU YAZAN    :  Mehmet Emin AYDOÐDU
            //NEDENI        :   Baþlýklarýn Veri Tabnýndan Alýnmasý
            //Mehmet Begin

            #region

            //lblBanka.Text = Kimlikci.Kimlik.OrtakOzelDurum.Banka;
            //lblSube.Text = Kimlikci.Kimlik.OrtakOzelDurum.Sube;
            //lblFoyYeri.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyYeri;
            //lblDosyaBirim.Text = Kimlikci.Kimlik.OrtakOzelDurum.FoyBirim;
            //lblTahsilatDurum.Text = Kimlikci.Kimlik.OrtakOzelDurum.Tahsilat;
            //lblKrediGrubu.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediGrup;
            //lblKrediTip.Text = Kimlikci.Kimlik.OrtakOzelDurum.KrediTip;
            //lblKlasor1.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor1;
            //lblKlasor2.Text = Kimlikci.Kimlik.OrtakOzelDurum.Klasor2;

            #endregion Ozellestirme

            //Mehmet End

            #endregion

            if (SorumluAvukat == null)
                SorumluAvukat = AvukatProLib.Kimlik.CurrentCariId;
            if (SorusturmaDurumu == null)
                SorusturmaDurumu = (int?)FoyDurum.FAAL;
            rgDosyalar.EditValue = 1;

            #region Captionlar

            //try
            //{
            //    foreach (GridColumn item in ucHazirlik1.gwHazirlik.Columns)
            //    {
            //        if (item.Name.Contains("colREFERANS_NO1"))
            //            item.Caption = Kimlikci.Kimlik.SorusturmaReferans.Referans1;
            //        if (item.Name.Contains("colREFERANS_NO2"))
            //            item.Caption = Kimlikci.Kimlik.SorusturmaReferans.Referans2;
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

            #endregion

            //Mehmet End

            #region Paket Yetkilendirmesi

            //TODO: [PAKET] Dava giris arama ekran
            //Root eleman
            //CS_KOD_FORM_LISTESI csKodFormListesi = new CS_KOD_FORM_LISTESI();

            //csKodFormListesi = AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.GirisEkran.rFrmSorusturmaGirisEkran", "Root", 0, "Sorusturma Arama");

            //int roodID = csKodFormListesi.ID;

            //AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.GirisEkran.rFrmSorusturmaGirisEkran", hideContainerLeft.Name, roodID, "Sorusturma Aþama");

            foreach (XtraTabPage tp in tabSorusturmaArama.TabPages)
            {
                //////Yetkilendir
                //csKodFormListesi = AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.GirisEkran.rFrmSorusturmaGirisEkran", tp.Name, roodID, "Sorusturma Arama " + tp.Text);
            }
            foreach (XtraTabPage tp in xtraTabControl1.TabPages)
            {
                //////Yetkilendir
                //csKodFormListesi = AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.GirisEkran.rFrmSorusturmaGirisEkran", tp.Name, roodID, "Sorusturma Aþama " + tp.Text);
            }

            #endregion


            BelgeUtil.Inits.FoyDurumGetir(lueDurum2);
            lueDurum2.EditValue = 2;
        }

        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        ((DateEdit)con).EditValue = null;
                    }
                    else if (con is TextEdit)
                    {
                        con.Text = string.Empty;
                    }
                }
            }
            catch 
            {
            }
        }

        private void AramaYap(AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf secTaraf,
                              AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur secTur)
        {
            TList<TDIE_KOD_ASAMA> asamaList = new TList<TDIE_KOD_ASAMA>();
            TList<TDIE_KOD_ASAMA_ALT> altAsamaList = new TList<TDIE_KOD_ASAMA_ALT>();

            if (secTur == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur.AnaAsama)
            {
                if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Karsi)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTaraf(txtArama.Text, "K");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Muvekkil)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTaraf(txtArama.Text, "M");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Mudurluk)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByMahkemeMi(txtArama.Text, true);
                }

                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Tumu)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTumu(txtArama.Text);
                }
            }

            else if (secTur == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur.AltAsama)
            {
                if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Karsi)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTaraf(txtArama.Text, "K");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Muvekkil)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTaraf(txtArama.Text, "M");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Mudurluk)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByMahkemeMi(txtArama.Text, true);
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Tumu)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTumu(txtArama.Text);
                }
            }

            AsamaDoldur(asamaList);

            if (asamaList.Count == 0)
            {
                XtraMessageBox.Show("Aradýðýnýz kriterlere uyan aþama bulunamadý.", "Arama Sonucu", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                ucHazirlik1.MyDataSource = null;
                MyDataSourceDeep = null;
            }

            tlSorusturmaAsamalar.Nodes.TreeList.ExpandAll();
        }

        private void AsamaDoldur()
        {
            TList<TDIE_KOD_ASAMA> asamalar = DataRepository.TDIE_KOD_ASAMAProvider.GetByASAMA_MODUL_ID(3);
            DataRepository.TDIE_KOD_ASAMAProvider.DeepLoad(asamalar, true, DeepLoadType.IncludeChildren,
                                                           typeof(TList<TDIE_KOD_ASAMA_ALT>));

            foreach (TDIE_KOD_ASAMA asama in asamalar)
            {
                TreeListNode tn = tlSorusturmaAsamalar.AppendNode(dataRowYap(asama.ASAMA_ADI), null);
                tn.Tag = asama;
                if (asama.SIMGE != null)
                {
                    Image img = Image.FromStream(new System.IO.MemoryStream(asama.SIMGE));
                    int imgYeri = myImageList.Images.Add(img, Color.Transparent);

                    tn.StateImageIndex = imgYeri;
                }

                foreach (TDIE_KOD_ASAMA_ALT altAsama in asama.TDIE_KOD_ASAMA_ALTCollection)
                {
                    TreeListNode tn2 = tlSorusturmaAsamalar.AppendNode(dataRowYap(altAsama.ALT_ASAMA_ADI), tn, altAsama);
                    if (altAsama.SIMGE != null)
                    {
                        Image img2 = Image.FromStream(new System.IO.MemoryStream(altAsama.SIMGE));
                        int imgYeri2 = myImageList.Images.Add(img2, Color.Transparent);
                        tn2.StateImageIndex = imgYeri2;
                    }
                }
            }
        }

        private void AsamaDoldur(TList<TDIE_KOD_ASAMA> asamaList)
        {
            if (asamaList == null)
                asamaList = DataRepository.TDIE_KOD_ASAMAProvider.GetByASAMA_MODUL_ID(1);

            DataRepository.TDIE_KOD_ASAMAProvider.DeepLoad(asamaList, true, DeepLoadType.IncludeChildren,
                                                           typeof(TList<TDIE_KOD_ASAMA_ALT>));

            asamaList.Sort("SIRA_NO ASC");

            tlSorusturmaAsamalar.Nodes.Clear();
            foreach (TDIE_KOD_ASAMA asama in asamaList)
            {
                TreeListNode tn = tlSorusturmaAsamalar.AppendNode(dataRowYap(asama.ASAMA_ADI), null);
                tn.Tag = asama;
                if (asama.SIMGE != null)
                {
                    Image img = Image.FromStream(new System.IO.MemoryStream(asama.SIMGE));
                    int imgYeri = myImageList.Images.Add(img, Color.Transparent);

                    tn.StateImageIndex = imgYeri;
                }

                asama.TDIE_KOD_ASAMA_ALTCollection.Sort("SIRA_NO ASC");

                foreach (TDIE_KOD_ASAMA_ALT altAsama in asama.TDIE_KOD_ASAMA_ALTCollection)
                {
                    TreeListNode tn2 = tlSorusturmaAsamalar.AppendNode(dataRowYap(altAsama.ALT_ASAMA_ADI), tn, altAsama);
                    tn2.Tag = altAsama;

                    if (altAsama.SIMGE != null)
                    {
                        Image img2 = Image.FromStream(new System.IO.MemoryStream(altAsama.SIMGE));
                        int imgYeri2 = myImageList.Images.Add(img2, Color.Transparent);
                        tn2.StateImageIndex = imgYeri2;
                    }
                }
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtArama.Text == string.Empty) AsamaDoldur(null);

            AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf taraf =
                (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf)
                rgTaraf.Properties.Items.GetItemIndexByValue(rgTaraf.SelectedIndex);
            AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur tur =
                (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur)
                rgTur.Properties.Items.GetItemIndexByValue(rgTur.SelectedIndex);

            AramaYap(taraf, tur);
        }

        private void btnAramaKriterleriniTemizle2_Click(object sender, EventArgs e)
        {
            AramalarýTemizleGenel();

            //xTabDetayArama
            foreach (Control item in nvbgrpGenelAramaBilgileri.Controls)
            {
                if (item is LookUpEdit)
                    ((LookUpEdit)item).EditValue = null;
                else if (item is TextEdit)
                    ((TextEdit)item).Text = "";
                else if (item is DateEdit)
                    ((DateEdit)item).ResetText();
                else if (item is ComboBoxEdit)
                    ((ComboBoxEdit)item).SelectedIndex = -1;
                else if (item is CheckBox)
                    ((CheckBox)item).Checked = false;
                else if (item is CheckEdit)
                    ((CheckEdit)item).Checked = false;
            }
        }

        private void btnAsamaSorgula_Click(object sender, EventArgs e)
        {
            string secilenUstler = string.Empty;
            string secilenlerAltlar = string.Empty;
            for (int i = 0; i < tlSorusturmaAsamalar.Nodes.Count; i++)
            {
                if (tlSorusturmaAsamalar.Nodes[i].Checked)
                {
                    TDIE_KOD_ASAMA ust = tlSorusturmaAsamalar.Nodes[i].Tag as TDIE_KOD_ASAMA;

                    if (ust != null)
                    {
                        secilenUstler += ust.ID + ",";
                    }
                    for (int y = 0; y < tlSorusturmaAsamalar.Nodes[i].Nodes.Count; y++)
                    {
                        if (tlSorusturmaAsamalar.Nodes[i].Nodes[y].Checked)
                        {
                            TDIE_KOD_ASAMA_ALT asamaAlt =
                                tlSorusturmaAsamalar.Nodes[i].Nodes[y].Tag as TDIE_KOD_ASAMA_ALT;
                            if (asamaAlt != null)
                            {
                                secilenlerAltlar += asamaAlt.ID + ",";
                            }
                        }
                    }
                }
            }
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            GelismisAramaSorgula();
        }

        private void btnTumKosullariTemizle_Click(object sender, EventArgs e)
        {
            TLSorusturmaSecimleriniDuzenle(false);
            rgDurum.SelectedIndex = 2;
            rgLeyh.SelectedIndex = 2;
            rgDurum_SelectedIndexChanged(rgDurum, new EventArgs());
            rgLeyh_SelectedIndexChanged(rgLeyh, new EventArgs());
            txtArama.Text = string.Empty;
            ucHazirlik1.FilitreleriTemizle();
        }

        private void chBoxAsamalarTumu_CheckedChanged(object sender, EventArgs e)
        {
            TLSorusturmaSecimleriniDuzenle(chBoxAsamalarTumu.Checked);
        }

        private DataRow dataRowYap(string adi)
        {
            DataRow dr = _ProjeTable.NewRow();
            dr["ADI"] = adi;
            return dr;
        }

        //private void dateOlaySucTarih2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (dateOlaySucTarih2.EditValue != null)
        //        OlaySucTarihi = (DateTime)dateOlaySucTarih2.EditValue;
        //    else
        //        OlaySucTarihi = null;
        //}

        private void dtSorusturmaTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtSorusturmaTarihi.EditValue != null)
            {
                if (string.IsNullOrEmpty(dtSorusturmaTarihi.Text))
                    SorusturmaTarihi = null;
                else
                    SorusturmaTarihi = (DateTime)dtSorusturmaTarihi.EditValue;
            }
            else
                SorusturmaTarihi = null;
        }

        //private void dtTarih2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (dtTarih2.EditValue != null)
        //        SikayetTarihi = (DateTime)dtTarih2.EditValue;
        //    else
        //        SikayetTarihi = null;
        //}

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Ac_Click += rFrmSorusturmaGirisEkran_Button_Ac_Click;
            this.Button_Yeni_Click += rFrmSorusturmaGirisEkran_Button_Yeni_Click;
            this.Button_Editor_Click += rFrmSorusturmaGirisEkran_Button_Editor_Click;
            this.Button_Yeniden_Click += rFrmSorusturmaGirisEkran_Button_Yeniden_Click;
        }

        private void lueAdliye2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliye2.EditValue != null)
                Adliye = (int)lueAdliye2.EditValue;
            else
                Adliye = null;
        }

        //private void lueBanka2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueBanka2.EditValue != null)
        //        Banka = (int)lueBanka2.EditValue;
        //    else
        //        Banka = null;
        //}



        private void lueDosyaDurum_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosyaDurum.EditValue != null)
            {
                DosyaDurum = (int)lueDosyaDurum.EditValue;
            }
            else
                DosyaDurum = null;
        }

        //private void lueDosyaninYeri2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueDosyaninYeri2.EditValue != null)
        //        FoyYeri = (int)lueDosyaninYeri2.EditValue;
        //    else
        //        FoyYeri = null;
        //}

        //private void lueDosyDurumu2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueOzelDosyaDurumu2.EditValue != null)
        //        FoyOzelDurum = (int)lueOzelDosyaDurumu2.EditValue;
        //    else
        //        FoyOzelDurum = null;
        //}

        private void lueDurum2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDurum2.EditValue != null)
                SorusturmaDurumu = (int)lueDurum2.EditValue;
            else
                SorusturmaDurumu = null;
        }

        //private void lueKarsiTarafVekili_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueKarsiTarafVekili.EditValue != null)
        //        KarsiTarafVekili = (int)lueKarsiTarafVekili.EditValue;
        //    else
        //        KarsiTarafVekili = null;
        //}

        private void lueKonu2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueKonu2.EditValue != null)
                Konu = (int)lueKonu2.EditValue;
            else
                Konu = null;
        }

        //private void lueKrediGrubu2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueKrediGrubu2.EditValue != null)
        //        KrediGrubu = (int)lueKrediGrubu2.EditValue;
        //    else
        //        KrediGrubu = null;
        //}

        //private void lueKrediTipi2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueKrediTipi2.EditValue != null)
        //        KrediTipi = (int)lueKrediTipi2.EditValue;
        //    else
        //        KrediTipi = null;
        //}

        private void lueOzelKod1_2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod1_2.EditValue != null)
                OzelKod1 = (int)lueOzelKod1_2.EditValue;
            else
                OzelKod1 = null;
        }

        private void lueOzelKod2_2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod2_2.EditValue != null)
                OzelKod2 = (int)lueOzelKod2_2.EditValue;
            else
                OzelKod2 = null;
        }

        private void lueOzelKod3_2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod3_2.EditValue != null)
                OzelKod3 = (int)lueOzelKod3_2.EditValue;
            else
                OzelKod3 = null;
        }

        private void lueOzelKod4_2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod4_2.EditValue != null)
                OzelKod4 = (int)lueOzelKod4_2.EditValue;
            else
                OzelKod4 = null;
        }

        //private void lueSikayetNedenKodId_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueSikayetNedenKodId.EditValue != null)
        //        SikayetNedenKod = (int)lueSikayetNedenKodId.EditValue;
        //    else
        //        SikayetNedenKod = null;
        //}

        private void lueSorumluAvukat2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSorumluAvukat2.EditValue != null)
                SorumluAvukat = (int)lueSorumluAvukat2.EditValue;
            else
                SorumluAvukat = null;
        }

        //private void lueSube2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueSube2.EditValue != null)
        //        Sube = (int)lueSube2.EditValue;
        //    else
        //        Sube = null;
        //}

        //private void lueTahsilatDurumu2_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueTahsilatDurumu2.EditValue != null)
        //        TahsilatDurum = (int)lueTahsilatDurumu2.EditValue;
        //    else
        //        TahsilatDurum = null;
        //}

        private void lueTarafAdi2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTarafAdi2.EditValue != null)
                Taraf = (int)lueTarafAdi2.EditValue;
            else
                Taraf = null;
        }

        private void rFrmSorusturmaGirisEkran_Button_Ac_Click(object sender, EventArgs e)
        {
            FoyuAc();
        }

        private void rFrmSorusturmaGirisEkran_Button_Editor_Click(object sender, EventArgs e)
        {
            EditorAc();
        }

        private void rFrmSorusturmaGirisEkran_Button_Yeni_Click(object sender, EventArgs e)
        {
            YeniFoy();
        }

        private void rFrmSorusturmaGirisEkran_Button_Yeniden_Click(object sender, EventArgs e)
        {
            FoyuYenile();
        }

        private void rgDosyalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)rgDosyalar.EditValue == 1)
            {
                SorumluAvukat = AvukatProLib.Kimlik.CurrentCariId;
                SorusturmaDurumu = (int?)FoyDurum.EVRAK;
            }
            if ((int)rgDosyalar.EditValue == 2)
            {
                SorumluAvukat = AvukatProLib.Kimlik.CurrentCariId;
                SorusturmaDurumu = null;
            }
            if ((int)rgDosyalar.EditValue == 3)
            {
                SorumluAvukat = null;
                SorusturmaDurumu = null;
            }
        }

        private void rgDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secim = int.Parse(rgDurum.Properties.Items[rgDurum.SelectedIndex].Value.ToString());

            switch (secim)
            {
                case 0:
                    ucHazirlik1.gwHazirlik.ActiveFilter.Add(ucHazirlik1.colHAZIRLIK_DURUM,
                                                            new DevExpress.XtraGrid.Columns.ColumnFilterInfo(""));
                    break;

                case 1:
                    ucHazirlik1.gwHazirlik.ActiveFilter.Add(ucHazirlik1.colHAZIRLIK_DURUM,
                                                            new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                                "[HAZIRLIK_DURUM] == EVRAK"));
                    break;

                case 2:
                    ucHazirlik1.gwHazirlik.ActiveFilter.Add(ucHazirlik1.colHAZIRLIK_DURUM,
                                                            new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                                                                "[HAZIRLIK_DURUM] == DERDEST"));
                    break;
                default:
                    break;
            }
        }

        private void rgLeyh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rgLeyh.Properties.Items[rgLeyh.SelectedIndex].Value == "null")
                {
                    secim = null;
                }
                else
                {
                    secim = Convert.ToBoolean(rgLeyh.Properties.Items[rgLeyh.SelectedIndex].Value);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TakibeGonder();
        }

        private void tlSorusturmaAsamalar_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = e.Node.Checked;
            }

            if (e.Node.ParentNode != null)
            {
                if (e.Node.Checked)
                {
                    e.Node.ParentNode.Checked = true;
                }
                else
                {
                    bool checkKaldir = false;
                    for (int i = 0; i < e.Node.ParentNode.Nodes.Count; i++)
                    {
                        if (e.Node.ParentNode.Nodes[i].Checked)
                        {
                            checkKaldir = true;
                        }
                    }
                    e.Node.ParentNode.Checked = checkKaldir;
                }
            }
        }

        private void TLSorusturmaSecimleriniDuzenle(bool chck)
        {
            for (int i = 0; i < tlSorusturmaAsamalar.Nodes.Count; i++)
            {
                tlSorusturmaAsamalar.Nodes[i].Checked = chck;
                for (int y = 0; y < tlSorusturmaAsamalar.Nodes[i].Nodes.Count; y++)
                {
                    tlSorusturmaAsamalar.Nodes[i].Nodes[y].Checked = chck;
                }
            }
        }

        //private void txtAnRef1_2_TextChanged(object sender, EventArgs e)
        //{
        //    SnRef1 = "%" + txtAnRef1_2.Text + "%";
        //    if (txtAnRef1_2.Text == string.Empty)
        //        SnRef1 = null;
        //}

        //private void txtAnRef2_2_TextChanged(object sender, EventArgs e)
        //{
        //    SnRef2 = "%" + txtAnRef2_2.Text + "%";
        //    if (txtAnRef2_2.Text == string.Empty)
        //        SnRef2 = null;
        //}

        private void txtDosyaNo2_TextChanged(object sender, EventArgs e)
        {
            DosyaNo = "%" + txtDosyaNo2.Text + "%";
            if (txtDosyaNo2.Text == string.Empty)
                DosyaNo = null;
            else
                DosyaNo = null;
        }

        private void txtEsasNo2_TextChanged(object sender, EventArgs e)
        {
            EsasNo = '%' + txtEsasNo2.Text + '%';
            if (txtEsasNo2.Text == string.Empty)
                EsasNo = null;
        }

        //private void txtKlasor1_2_TextChanged(object sender, EventArgs e)
        //{
        //    Klasor1 = "%" + txtKlasor1_2.Text + "%";
        //    if (txtKlasor1_2.Text == string.Empty)
        //        Klasor1 = null;
        //}

        //private void txtKlasor2_2_TextChanged(object sender, EventArgs e)
        //{
        //    Klasor2 = "%" + txtKlasor2_2.Text + "%";
        //    if (txtKlasor2_2.Text == string.Empty)
        //        Klasor2 = null;
        //}

        //private void txtRef1_2_TextChanged(object sender, EventArgs e)
        //{
        //    Ref1 = "%" + txtAnRef1_2.Text + "%";
        //    if (txtAnRef1_2.Text == string.Empty)
        //        Ref1 = null;
        //}

        //private void txtRef2_2_TextChanged(object sender, EventArgs e)
        //{
        //    Ref2 = "%" + txtAnRef2_2.Text + "%";
        //    if (txtAnRef2_2.Text == string.Empty)
        //        Ref2 = null;
        //}

        //private void txtRef3_2_TextChanged(object sender, EventArgs e)
        //{
        //    Ref3 = "%" + txtRef3_2.Text + "%";
        //    if (txtRef3_2.Text == string.Empty)
        //        Ref3 = null;
        //}

        private void ucHazirlik1_KayitSilindi(object sender, EventArgs e)
        {
            GelismisAramaSorgula();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabArama)
            {
                splitContainerControl1.Panel2.Controls.Add(pnTreeList);
            }
            else if (e.Page == tabAsamalar)
            {
                tabAsamalar.Controls.Add(pnTreeList);
            }
        }

        private void tabSorusturmaArama_Click(object sender, EventArgs e)
        {
            if (tabSorusturmaArama.SelectedTabPageIndex == 1)
            {
                if (tabPivotRapor.Controls.Count == 0)
                {
                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    ucPivotChart pGcIcraRapor = new ucPivotChart();
                    pGcIcraRapor.MySorusturma = cn.GetDataTable("select * from R_SORUSTURMA_PIVOT(nolock)");
                    pGcIcraRapor.Dock = DockStyle.Fill;
                    tabPivotRapor.Controls.Add(pGcIcraRapor);
                }
            }
        }

        #region Overriden methods

        #endregion

        #region IslemMethodlari

        #endregion
    }
}