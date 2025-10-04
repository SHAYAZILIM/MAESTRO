using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.AramaUserKontrol
{
    public partial class ucTemsilBilgisiArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucTemsilBilgisiArama()
        {
            InitializeComponent();
            gridView1.DoubleClick += gridView1_DoubleClick;
        }

        public delegate void OnFocusedRowChanged(
            AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL temsil, object ExTemsil, int RowHandle, object sender);

        public event OnFocusedRowChanged FocusedRowChanged;

        public List<AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL> MyDataSource
        {
            get
            {
                if (exGridTemsilTarafSorumlu.DataSource is List<AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL>)
                    return (List<AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL>)exGridTemsilTarafSorumlu.DataSource;
                return null;
            }
            set { exGridTemsilTarafSorumlu.DataSource = value; }
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
                        (con).ResetText();
                    }

                    else if (con is SpinEdit)
                    {
                        ((SpinEdit)con).EditValue = null;
                    }
                    else if (con is CheckEdit)
                    {
                        ((CheckEdit)con).Checked = false;
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

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            MyDataSource = AvukatProLib.Arama.R_TEMSIL_ARAMASorgu.GetByFiltreView(Taraf, Avukat, EvrakSorumlu, Yevmiye,
                                                                                  Tarh, BelgeSayi, DosyaNo, BirimGorev,
                                                                                  BirimNo, Adliye, TemsilTur,
                                                                                  TemsilSekli,
                                                                                  AvukatProLib.Kimlik.SirketBilgisi.
                                                                                      ConStr);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(lCntrlVekalet.Controls);
            MyDataSource = null;
        }

        private void exGridTemsilTarafSorumlu_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "FormdanEkle")
                {
                    frmTemsilKayit frm = new frmTemsilKayit();

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();

                    //KayitTamamlandi(this, new EventArgs());
                }

                #region <MB-20101002> Düzenleme İşlemi.

                else if (e.Button.Tag.ToString() == "KaydiDuzenle")
                {
                    frmTemsilKayit tKayit = new frmTemsilKayit();
                    TList<AV001_TDI_BIL_TEMSIL> liste = new TList<AV001_TDI_BIL_TEMSIL>();
                    AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL vekalet = new AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL();
                    AV001_TDI_BIL_TEMSIL temsil = new AV001_TDI_BIL_TEMSIL();
                    vekalet = gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL;

                    temsil = DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID(vekalet.ID);
                    liste.Add(temsil);
                    tKayit.MyDataSource = liste;
                    tKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    tKayit.FormClosed += kayitSil_FormClosed;
                    tKayit.Show();
                }

                #endregion <MB-20101002> Düzenleme İşlemi.

                else if (e.Button.Tag.ToString() == "KayitSil")
                {
                    AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL vekil = gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL;
                    string Foy_no = vekil.DOSYA_NO;
                    frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_TEMSIL", "ID = " + vekil.ID.ToString());
                    kayitSil.FormClosed += new FormClosedEventHandler(kayitSil_FormClosed);
                    if (kayitSil.ShowDialog() == DialogResult.OK)
                    {
                        //if (KayitSilindi != null)
                        //    KayitSilindi(this, new EventArgs());

                        XtraMessageBox.Show(Foy_no + " ' kayit  Silinmiştir");
                    }
                }
            }
        }

        private void exGridTemsilTarafSorumlu_DoubleClick(object sender, EventArgs e)
        {
            #region <MB-20101002> Düzenleme İşlemi.

            if (gridView1.FocusedRowHandle >= 0)
            {
                frmTemsilKayit tKayit = new frmTemsilKayit();

                var vekaletList = exGridTemsilTarafSorumlu.DataSource as List<AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL>;
                TList<AV001_TDI_BIL_TEMSIL> liste = new TList<AV001_TDI_BIL_TEMSIL>();
                AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL vekalet = new AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL();
                AV001_TDI_BIL_TEMSIL temsil = new AV001_TDI_BIL_TEMSIL();

                vekalet = vekaletList[gridView1.FocusedRowHandle];
                temsil = DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID(vekalet.ID);
                liste.Add(temsil);

                tKayit.MyDataSource = liste;

                //tKayit.MdiParent = null;
                tKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                tKayit.FormClosed += kayitSil_FormClosed;
                tKayit.Show();
            }

            #endregion <MB-20101002> Düzenleme İşlemi.
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            object rowData = gridView1.GetRow(gridView1.FocusedRowHandle);
            object exRowData = null;

            if (rowData is AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL)
            {
                if (FocusedRowChanged != null)
                {
                    FocusedRowChanged((AvukatProLib.Arama.AV001_TDI_BIL_TEMSIL)rowData, exRowData,
                                      gridView1.FocusedRowHandle, this);
                }
            }
        }

        #region Kriterler

        private int? Adliye;
        private int? Avukat;
        private string BelgeSayi;
        private int? BirimGorev;
        private int? BirimNo;
        private string DosyaNo;
        private int? EvrakSorumlu;
        private int? Taraf;
        private DateTime? Tarh;
        private int? TemsilSekli;

        private int? TemsilTur;

        private string Yevmiye;

        private void dtTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih.EditValue != null)
                Tarh = (DateTime?)dtTarih.EditValue;
            else
                Tarh = null;
        }

        private void lueAdliye_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliye.EditValue != null)
                Adliye = (int?)lueAdliye.EditValue;
            else
                Adliye = null;
        }

        private void lueAvukat_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAvukat.EditValue != null)
                Avukat = (int?)lueAvukat.EditValue;
            else
                Avukat = null;
        }

        private void lueBirimNo_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBirimNo.EditValue != null)
                BirimNo = (int?)lueBirimNo.EditValue;
            else
                BirimNo = null;
        }

        private void lueEvrakSorumlu_EditValueChanged(object sender, EventArgs e)
        {
            if (lueEvrakSorumlu.EditValue != null)
                EvrakSorumlu = (int?)lueEvrakSorumlu.EditValue;
            else
                EvrakSorumlu = null;
        }

        private void lueGorev_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGorev.EditValue != null)
                BirimGorev = (int?)lueGorev.EditValue;
            else
                BirimGorev = null;
        }

        private void lueTaraf_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTaraf.EditValue != null)
                Taraf = (int?)lueTaraf.EditValue;
            else
                Taraf = null;
        }

        private void lueTemsilSekli_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTemsilSekli.EditValue != null)
                TemsilSekli = (int?)lueTemsilSekli.EditValue;
            else
                TemsilSekli = null;
        }

        private void lueTemsilTur_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTemsilTur.EditValue != null)
                TemsilTur = (int?)lueTemsilTur.EditValue;
            else
                TemsilTur = null;
        }

        private void txtBelgeSayiBilgisi_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBelgeSayiBilgisi.Text))
                BelgeSayi = txtBelgeSayiBilgisi.Text;
            else
                BelgeSayi = null;
        }

        private void txtDosyaNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDosyaNo.Text))
                DosyaNo = txtDosyaNo.Text;
            else
                DosyaNo = null;
        }

        private void txtYevmiye_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtYevmiye.Text))
                Yevmiye = txtYevmiye.Text;
            else
                Yevmiye = null;
        }

        #endregion Kriterler

        private void InitsDoldur()
        {
            lueTemsilTur.Properties.NullText = "Seç";
            lueTemsilSekli.Properties.NullText = "Seç";

            //dolu gelecek için
            rlueYetkiKullanmaSekli.NullText = "Seç";
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueAdliye);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueAvukat, AvukatProLib.Extras.CariStatu.Avukat);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueBirimNo);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueEvrakSorumlu, AvukatProLib.Extras.CariStatu.Personel);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(lueGorev);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTaraf, null);
            lueTemsilTur.Enter += BelgeUtil.Inits.TemsilTuruGetir_Enter;
            lueTemsilSekli.Enter += BelgeUtil.Inits.TemsilSekilGetir_Enter;
            BelgeUtil.Inits.TemsilYetkiKullanmaTipiGetir(rlueYetkiKullanmaSekli);
        }

        private void kayitSil_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyDataSource = AvukatProLib.Arama.R_TEMSIL_ARAMASorgu.GetByFiltreView(Taraf, Avukat, EvrakSorumlu, Yevmiye,
                                                                                  Tarh, BelgeSayi, DosyaNo, BirimGorev,
                                                                                  BirimNo, Adliye, TemsilTur,
                                                                                  TemsilSekli,
                                                                                  AvukatProLib.Kimlik.SirketBilgisi.
                                                                                      ConStr);
        }

        private void ucTemsilBilgisiArama_Load(object sender, EventArgs e)
        {
            InitsDoldur();
        }
    }
}