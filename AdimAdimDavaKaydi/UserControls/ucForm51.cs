using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucForm51 : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucForm51()
        {
            InitializeComponent();
            this.Load += ucForm51_Load;
        }

        private void ucForm51_Load(object sender, EventArgs e)
        {
            gwAlacakNeden.FocusedRowChanged += gwAlacakNeden_FocusedRowChanged;
            ToFaizOran.Enabled = false;
            TsFaizOran.Enabled = false;
            txtDigerAlacak.Enabled = false;
            labelControl1.Enabled = false;
            FormTipiHazýrlýk();
        }

        #region Field

        private TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
        private AV001_TI_BIL_FOY myFoy;

        #endregion

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_ALACAK_NEDEN FocusedRow
        {
            get { return (AV001_TI_BIL_ALACAK_NEDEN)gwAlacakNeden.GetFocusedRow(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenleri
        {
            get { return alacakNedenleri; }
            set { alacakNedenleri = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    LoadData();

                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.AddingNew += AV001_TI_BIL_ALACAK_NEDENCollection_AddingNew;

                    DefaultValues();
                    //if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                    //    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.AddNew();

                    //else if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count >= 1)
                    //{
                    AlacakNedenleri.AddRange(MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection);
                    gcAlacakNeden.DataSource = AlacakNedenleri;
                    ucSeriAlacakNeden1.MyDataSource = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection;
                    //}

                    //BindForm(MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[0]);

                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ColumnChanged += neden_ColumnChanged;
                    }
                }
            }
        }

        #endregion

        #region Events

        private void neden_ColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            DataChanged(sender, e);
        }

        private void obj_ColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            DataChanged(sender, e);
        }

        private void gwAlacakNeden_FocusedRowChanged(object sender,
                                                     DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN obj = FocusedRow;

            if (obj != null)
            {
                obj.ColumnChanged += obj_ColumnChanged;
            }
            AV001_TI_BIL_ALACAK_NEDEN ndn = gwAlacakNeden.GetRow(e.FocusedRowHandle) as AV001_TI_BIL_ALACAK_NEDEN;
            if (ndn != null)
            {
                ucAlacakNedenTaraf1.DtAlacakNeden = ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                ucAlacakNedenTaraf1_FocusedTarafChanged(ucAlacakNedenTaraf1,
                                                        new DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs(0,
                                                                                                                     -1));
            }
            else
            {
                ucAlacakNedenTaraf1.DtAlacakNeden = null;
                gcTarafFaiz.DataSource = null;
            }
        }

        private void AV001_TI_BIL_ALACAK_NEDENCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN addNew = new AV001_TI_BIL_ALACAK_NEDEN();

            addNew.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1;
            addNew.TUTAR_DOVIZ_ID = 1;
            addNew.TO_ALACAK_FAIZ_TIP_ID = 1;
            addNew.ALACAK_FAIZ_TIP_ID = 1;
            addNew.HESAPLAMA_MODU = (int)IcraDovizIslemTipi.Vade_Tarihinde_TL;
            addNew.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1;
            addNew.TO_ALACAK_FAIZ_TIP_ID = 1;
            addNew.ALACAK_FAIZ_TIP_ID = 1;
            addNew.SABIT_FAIZ_UYGULA = true;
            addNew.IHTAR_GIDERI_DOVIZ_ID = 1;
            addNew.PROTESTO_GIDERI_DOVIZ_ID = 1;
            addNew.KDV_TIP_ID = (int)KDVTipi.GENEL;
            if (addNew.TO_ALACAK_FAIZ_TIP_ID == 1)
                addNew.TO_UYGULANACAK_FAIZ_ORANI = 9;
            if (addNew.ALACAK_FAIZ_TIP_ID == 1)
                addNew.UYGULANACAK_FAIZ_ORANI = 9;

            e.NewObject = addNew;
        }

        private void lueAlacakNeden_EditValueChanging(object sender, ChangingEventArgs e)
        {
            FormHazirla(e);
        }

        #endregion

        #region Private Methods

        private AV001_TI_BIL_ALACAK_NEDEN AddNew()
        {
            AV001_TI_BIL_ALACAK_NEDEN neden = new AV001_TI_BIL_ALACAK_NEDEN();

            if (lueAlacakNeden.EditValue != null)
                neden.ALACAK_NEDEN_KOD_ID = (int)lueAlacakNeden.EditValue;

            if (txtDigerAlacak.Text != "")
                neden.DIGER_ALACAK_NEDENI = txtDigerAlacak.Text;

            if (dtVadeT.EditValue != null)
                neden.VADE_TARIHI = dtVadeT.DateTime;

            if (txtDigerAlacak.Text != "")
                neden.DIGER_ALACAK_NEDENI = txtDigerAlacak.Text;

            neden.HESAPLAMA_MODU = Convert.ToByte(lueDovizIslemTipi.EditValue);

            if (Tutar.EditValue != null)
                neden.TUTARI = (decimal)Tutar.EditValue;

            if (TutarDovizTip.EditValue != null)
                neden.TUTAR_DOVIZ_ID = (int)TutarDovizTip.EditValue;

            if (IslemeKonanTutar.EditValue != null)
                neden.ISLEME_KONAN_TUTAR = (decimal)IslemeKonanTutar.EditValue;

            if (TutarDovizTip2.EditValue != null)
                neden.ISLEME_KONAN_TUTAR_DOVIZ_ID = (int)TutarDovizTip2.EditValue;

            if (lueToFaizTipi.EditValue != null)
                neden.TO_ALACAK_FAIZ_TIP_ID = Convert.ToInt32(lueToFaizTipi.EditValue);

            if (ToFaizOran.EditValue != null)
                neden.TO_UYGULANACAK_FAIZ_ORANI = (Convert.ToDouble((decimal)ToFaizOran.EditValue));

            if (lueTsFaizTipi.EditValue != null)
                neden.ALACAK_FAIZ_TIP_ID = (int)lueTsFaizTipi.EditValue;

            if (TsFaizOran.EditValue != null)
                neden.UYGULANACAK_FAIZ_ORANI = (Convert.ToDouble((decimal)TsFaizOran.EditValue));

            if (IhtarGid.EditValue != null)
                neden.IHTAR_GIDERI = (decimal)IhtarGid.EditValue;

            if (txtRefNo1.Text != "")
                neden.REFERANS_NO = txtRefNo1.Text;

            if (txtAciklama.Text != "")
                neden.ACIKLAMA = txtAciklama.Text;

            neden.SABIT_FAIZ_UYGULA = sabitFaizMi.Checked;
            neden.FAIZ_BASLANGIC_TARIHI = dtVadeT.DateTime;
            neden.FAIZ_YOK = faizYok.Checked;

            AlacakNedenleri.Add(neden);

            MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(neden);

            return neden;
        }

        private void DataChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN gonderen = (AV001_TI_BIL_ALACAK_NEDEN)sender;
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID && gonderen.TO_ALACAK_FAIZ_TIP_ID != 9)
            {
                ToFaizOran.Enabled = false;
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID &&
                     gonderen.TO_ALACAK_FAIZ_TIP_ID == 9)
            {
                ToFaizOran.Enabled = true;
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_FAIZ_TIP_ID &&
                     gonderen.ALACAK_FAIZ_TIP_ID != 9)
            {
                TsFaizOran.Enabled = false;
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_FAIZ_TIP_ID &&
                     gonderen.ALACAK_FAIZ_TIP_ID == 9)
            {
                TsFaizOran.Enabled = true;
            }

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID)
            {
                gonderen.TO_UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                               gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                                                               myFoy.TAKIP_TARIHI);

                gonderen.UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                            gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                                                            myFoy.TAKIP_TARIHI);

                gonderen.ALACAK_FAIZ_TIP_ID = (int)e.Value;

                lueTsFaizTipi.EditValue = gonderen.TO_ALACAK_FAIZ_TIP_ID;

                ToFaizOran.Value = (decimal)gonderen.TO_UYGULANACAK_FAIZ_ORANI;
                TsFaizOran.Value = (decimal)gonderen.UYGULANACAK_FAIZ_ORANI;
            }

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_FAIZ_TIP_ID)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value,
                                                                            gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID,
                                                                            myFoy.TAKIP_TARIHI);
                TsFaizOran.Value = (decimal)gonderen.UYGULANACAK_FAIZ_ORANI;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.VADE_TARIHI)
            {
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTARI)
            {
                if (gonderen.TUTAR_DOVIZ_ID == 1)
                {
                    gonderen.ISLEME_KONAN_TUTAR = (decimal)e.Value;
                    IslemeKonanTutar.Value = gonderen.ISLEME_KONAN_TUTAR;
                }
                else
                {
                    DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                    gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID,
                                                                       gonderen.VADE_TARIHI.Value, gonderen.ALACAK_NEDEN_KOD_ID);
                    IslemeKonanTutar.Value = gonderen.ISLEME_KONAN_TUTAR;
                }
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_UYGULANACAK_FAIZ_ORANI &&
                gonderen.ALACAK_FAIZ_TIP_ID == 9 && gonderen.TO_ALACAK_FAIZ_TIP_ID == 9)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = (double)e.Value;
                TsFaizOran.Value = (decimal)gonderen.UYGULANACAK_FAIZ_ORANI;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID)
            {
                gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = (int)e.Value;
                TutarDovizTip2.EditValue = (int)gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                if (gonderen.TUTAR_DOVIZ_ID != 1)
                {
                    DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                    gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID,
                                                                       gonderen.VADE_TARIHI.Value, gonderen.ALACAK_NEDEN_KOD_ID);
                    IslemeKonanTutar.Value = gonderen.ISLEME_KONAN_TUTAR;
                    gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1;
                    TutarDovizTip2.EditValue = 1;
                }
                else
                {
                    gonderen.ISLEME_KONAN_TUTAR = gonderen.TUTARI;
                    IslemeKonanTutar.Value = gonderen.ISLEME_KONAN_TUTAR;
                }
            }
        }

        private int digerId;

        public void LoadData()
        {
            BelgeUtil.Inits.AlacakNedeniDoldur(new[]
                                                   {
                                                       lueAlacakNeden.Properties, rLueAlacakNeden
                                                   }, MyFoy.TAKIP_TALEP_ID.Value);

            BelgeUtil.Inits.DovizTipGetir(lueDovizIslemTipi);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizIslemTipi);
            BelgeUtil.Inits.FaizTipiGetir(lueToFaizTipi);
            BelgeUtil.Inits.FaizTipiGetir(lueTsFaizTipi);
            BelgeUtil.Inits.FaizTipiGetir(rLueFaizTipi);
            BelgeUtil.Inits.DovizTipGetir(TutarDovizTip);
            BelgeUtil.Inits.DovizTipGetir(TutarDovizTip2);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTipi);
            BelgeUtil.Inits.DovizIslemTipiGetir(lueDovizIslemTipi);
            BelgeUtil.Inits.ParaBicimiAyarla(Tutar.Properties);
            BelgeUtil.Inits.ParaBicimiAyarla(IslemeKonanTutar.Properties);
            BelgeUtil.Inits.ParaBicimiAyarla(IhtarGid.Properties);
            BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
            BelgeUtil.Inits.FaizTipiGetir(rLueFaizTipId);
        }

        private void FormHazirla(ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue != null && (int)e.NewValue == 1)
                {
                    lblVadeTarihi.Enabled = false;
                    dtVadeT.Enabled = false;
                }
                else if ((int)e.NewValue != 1)
                {
                    lblVadeTarihi.Enabled = true;
                    dtVadeT.Enabled = true;
                }

                FormTipleri f = (FormTipleri)MyFoy.FORM_TIP_ID.Value;
                FormKonusu k = (FormKonusu)MyFoy.TAKIP_TALEP_ID.Value;

                switch (f)
                {
                    case FormTipleri.Form163:
                        digerId = 75;
                        break;
                    case FormTipleri.Form52:
                        digerId = 65;
                        break;
                    case FormTipleri.Form49:
                        digerId = 54;
                        break;
                    case FormTipleri.Form153:
                        digerId = 55;
                        break;
                    case FormTipleri.Form201:
                        digerId = 76;
                        break;
                    case FormTipleri.Form53:
                        if (k == FormKonusu.Form53_NAFAKA)
                            digerId = 66;
                        if (k == FormKonusu.Form53_ISCI_ALACAGI)
                            digerId = 67;
                        if (k == FormKonusu.Form53_ISIN_YAPILMASI)
                            digerId = 68;
                        if (k == FormKonusu.Form53_IRTIFAK_HAKKI)
                            digerId = 69;
                        break;
                    case FormTipleri.Form55:
                        digerId = 11;
                        break;
                    case FormTipleri.Form51:
                        digerId = 64;
                        break;
                    case FormTipleri.Form54:
                        if (k == FormKonusu.Form54_MENKUL_TESLIMI)
                            digerId = 70;
                        if (k == FormKonusu.Form54_GAYRIMENKUL_TAHLIYE_TESLIMI)
                            digerId = 71;
                        break;
                    case FormTipleri.Form56:
                        digerId = 73;
                        break;
                    case FormTipleri.Form152:
                        digerId = 74;
                        break;
                    default:
                        break;
                }

                if (digerId > 0 && (int)e.NewValue == digerId)
                {
                    txtDigerAlacak.Enabled = true;
                    txtDigerAlacak.Text = "";
                    labelControl1.Enabled = true;
                }
                else
                {
                    txtDigerAlacak.Enabled = false;
                    txtDigerAlacak.Text = lueAlacakNeden.Text;
                    labelControl1.Enabled = false;
                }
            }
        }

        private void FormTipiHazýrlýk()
        {
            FormTipleri f = (FormTipleri)MyFoy.FORM_TIP_ID.Value;
            FormKonusu k = (FormKonusu)MyFoy.TAKIP_TALEP_ID.Value;

            #region <AC - 20090617>

            // lueAlacakNeden.Properties.DataSource view dan geldiði için TList VList olarak deðiþtirildi.
            VList<per_TI_KOD_ALACAK_NEDEN> ned = (VList<per_TI_KOD_ALACAK_NEDEN>)lueAlacakNeden.Properties.DataSource;

            #endregion </AC - 20090617>

            VList<per_TI_KOD_ALACAK_NEDEN> silinecek = new VList<per_TI_KOD_ALACAK_NEDEN>();

            switch (f)
            {
                case FormTipleri.Form51:
                    foreach (per_TI_KOD_ALACAK_NEDEN var in ned)
                    {
                        if (var.ALACAK_NEDENI.Contains("DÝÐER ALACAK..."))
                        {
                            silinecek.Add(var);
                        }
                    }

                    #region <AC - 20090618>

                    // silinecek.Count int tipinde value type dýr. Value type lar null deðer içeremez. Bu durumda aþaðýdaki kontrol yanlýþtýr.
                    // if (silinecek.Count != null)	satýrý if (silinecek.Count > 0) olarak deðiþtirildi.

                    #endregion </AC - 20090618>

                    if (silinecek.Count > 0)
                    {
                        foreach (per_TI_KOD_ALACAK_NEDEN n in silinecek)
                        {
                            ned.Remove(n);
                            lueAlacakNeden.Properties.DataSource = ned;
                            rLueAlacakNeden.DataSource = ned;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void DefaultValues()
        {
            lueDovizIslemTipi.EditValue = (int)IcraDovizIslemTipi.Vade_Tarihinde_TL;
            dtVadeT.EditValue = DateTime.Today;
            dtIhtarT.EditValue = null;
            lueAlacakNeden.EditValue = null;
            txtDigerAlacak.Enabled = false;
            TutarDovizTip.EditValue = 1;
            TutarDovizTip2.EditValue = 1;
            lueToFaizTipi.EditValue = (int)FaizTip.Yasal_Faiz;
            lueTsFaizTipi.EditValue = (int)FaizTip.Yasal_Faiz;
            txtRefNo1.Text = null;
            txtAciklama.Text = null;
            IhtarGid.Value = 0;
            Tutar.Value = 0;
            IslemeKonanTutar.Value = 0;
            ToFaizOran.Value = 9;
            TsFaizOran.Value = 9;
            txtDigerAlacak.Text = "";
        }

        #endregion

        private void btnYeniAlacakNeden_Click(object sender, EventArgs e)
        {
            if (Validator.Validate())
            {
                OnAlacakNedenEklendi(this, new AlacakNedenEklendiEventArgs(AddNew()));
                DefaultValues();
            }
            gcAlacakNeden.DataSource = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection;
        }

        private void btnAlacakNedeniSil_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_ALACAK_NEDEN> secilenler = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

            for (int j = 0; j < AlacakNedenleri.Count; j++)
            {
                if (AlacakNedenleri[j].IsSelected && !secilenler.Contains(AlacakNedenleri[j]))

                    secilenler.Add(AlacakNedenleri[j]);
            }

            if (gwAlacakNeden.SelectedRowsCount <= 0) return;

            else
            {
                DialogResult ds = XtraMessageBox.Show("Seçili kayýtlarý silmek istediðinizden emin misiniz ?",
                                                      "Silme Ýþlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ds == DialogResult.Yes)
                {
                    for (int i = 0; i < secilenler.Count; i++)
                    {
                        MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Remove(secilenler[i]);
                    }
                    if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count <= 0)
                    {
                        ucAlacakNedenTaraf1.DtAlacakNeden.Clear();
                        gcAlacakNeden.DataSource = null;
                        gcTarafFaiz.DataSource = null;
                    }
                }
            }
            AlacakNedenleri.Clear();
            AlacakNedenleri.AddRange(MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection);

            gcAlacakNeden.DataSource = AlacakNedenleri;
        }

        public event AlacakNedenEklendiEventHandler OnAlacakNedenEklendi;

        public delegate void AlacakNedenEklendiEventHandler(object sender, AlacakNedenEklendiEventArgs e);

        private void ucAlacakNedenTaraf1_FocusedTarafChanged(object sender,
                                                             DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (ucAlacakNedenTaraf1.DtAlacakNeden != null && e.NewIndex >= 0 &&
                e.NewIndex < ucAlacakNedenTaraf1.DtAlacakNeden.Count)
            {
                gcTarafFaiz.DataSource =
                    ucAlacakNedenTaraf1.DtAlacakNeden[e.NewIndex].AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection;
            }
            if (e.NewIndex < 0)
            {
                gcTarafFaiz.DataSource = null;
            }
        }

        private void lueAlacakNeden_EditValueChanged(object sender, EventArgs e)
        {
            if (digerId > 0 && Convert.ToInt32(lueAlacakNeden.EditValue) == digerId)
            {
                txtDigerAlacak.Enabled = true;
                labelControl1.Enabled = true;
                txtDigerAlacak.Text = "";
            }
            else
            {
                txtDigerAlacak.Enabled = false;
                txtDigerAlacak.Text = lueAlacakNeden.Text;
                labelControl1.Enabled = false;
            }
        }

        private void Tutar_EditValueChanged(object sender, EventArgs e)
        {
            IslemeKonanTutar.Value = Tutar.Value;
        }

        private void TutarDovizTip_EditValueChanged(object sender, EventArgs e)
        {
            if ((int)TutarDovizTip.EditValue != 1)
            {
                if (Tutar.Value > 0)
                {
                    IslemeKonanTutar.Value = DovizHelper.CevirYTL(Tutar.Value, (int)TutarDovizTip.EditValue,
                                                                  dtVadeT.DateTime);
                }
                TutarDovizTip2.EditValue = 1;
            }
            else
                TutarDovizTip2.EditValue = TutarDovizTip.EditValue;
        }

        private void lueToFaizTipi_EditValueChanged(object sender, EventArgs e)
        {
            ToFaizOran.Value =
                (decimal)
                FaizHelper.FaizOraniGetir((int)lueToFaizTipi.EditValue, (int)TutarDovizTip.EditValue,
                                          myFoy.TAKIP_TARIHI);
            TsFaizOran.Value = ToFaizOran.Value;
            if ((int)lueToFaizTipi.EditValue == 9)
                ToFaizOran.Enabled = true;
            else
            {
                ToFaizOran.Enabled = false;
            }

            lueTsFaizTipi.EditValue = lueToFaizTipi.EditValue;
        }

        private void ToFaizOran_EditValueChanged(object sender, EventArgs e)
        {
            TsFaizOran.EditValue = ToFaizOran.EditValue;
        }

        private void lueTsFaizTipi_EditValueChanged(object sender, EventArgs e)
        {
            TsFaizOran.Value =
                (decimal)
                FaizHelper.FaizOraniGetir((int)lueTsFaizTipi.EditValue, (int)TutarDovizTip2.EditValue,
                                          myFoy.TAKIP_TARIHI);
            if ((int)lueTsFaizTipi.EditValue == 9)
                TsFaizOran.Enabled = true;
            else
                TsFaizOran.Enabled = false;
        }
    }
}