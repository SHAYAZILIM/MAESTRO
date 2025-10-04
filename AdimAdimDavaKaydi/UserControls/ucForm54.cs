using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucForm54 : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucForm54()
        {
            InitializeComponent();
            this.Load += ucForm54_Load;
        }

        private void ucForm54_Load(object sender, EventArgs e)
        {
            gwAlacakNeden.FocusedRowChanged += gwAlacakNeden_FocusedRowChanged;
            FormTipiHazýrlýk();
        }

        #region Fields

        private AV001_TI_BIL_FOY myFoy;
        private TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenleri = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

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
                    DefaultValues();
                    LoadData();

                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.AddingNew += AV001_TI_BIL_ALACAK_NEDENCollection_AddingNew;

                    AlacakNedenleri.AddRange(MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection);
                    gcAlacakNeden.DataSource = AlacakNedenleri;
                    ucSeriAlacakNeden1.MyDataSource = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection;
                }
            }
        }

        #endregion

        #region Events

        private void gwAlacakNeden_FocusedRowChanged(object sender,
                                                     DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
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
                ucAlacakNedenTaraf1.DtAlacakNeden.Clear();
                gcTarafFaiz.DataSource = null;
            }
        }

        private void AV001_TI_BIL_ALACAK_NEDENCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN addNew = new AV001_TI_BIL_ALACAK_NEDEN();
            txtDigerAlacak.Enabled = false;
            addNew.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1;
            addNew.TUTAR_DOVIZ_ID = 1;
            addNew.TO_ALACAK_FAIZ_TIP_ID = 1;
            addNew.ALACAK_FAIZ_TIP_ID = 1;
            addNew.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1;
            addNew.TO_ALACAK_FAIZ_TIP_ID = 1;
            addNew.ALACAK_FAIZ_TIP_ID = 1;
            addNew.SABIT_FAIZ_UYGULA = true;
            addNew.IHTAR_GIDERI_DOVIZ_ID = 1;
            addNew.PROTESTO_GIDERI_DOVIZ_ID = 1;

            if (addNew.TO_ALACAK_FAIZ_TIP_ID == 1)
                addNew.TO_UYGULANACAK_FAIZ_ORANI = 9;
            if (addNew.ALACAK_FAIZ_TIP_ID == 1)
                addNew.UYGULANACAK_FAIZ_ORANI = 9;

            e.NewObject = addNew;
        }

        #endregion

        #region Private Methods

        private AV001_TI_BIL_ALACAK_NEDEN AddNew()
        {
            AV001_TI_BIL_ALACAK_NEDEN neden = new AV001_TI_BIL_ALACAK_NEDEN();

            if (lueAlacakNeden.EditValue != null)
                neden.ALACAK_NEDEN_KOD_ID = (int)lueAlacakNeden.EditValue;

            if (IslemeKonanTutar.EditValue != null)
                neden.ISLEME_KONAN_TUTAR = (decimal)IslemeKonanTutar.EditValue;

            if (txtDigerAlacak.Text != null)
                neden.DIGER_ALACAK_NEDENI = txtDigerAlacak.Text;

            if (TutarDovizTip2.EditValue != null)
                neden.ISLEME_KONAN_TUTAR_DOVIZ_ID = (int)TutarDovizTip2.EditValue;

            if (txtRefNo1.Text != "")
                neden.REFERANS_NO = txtRefNo1.Text;

            if (txtAciklama.Text != "")
                neden.ACIKLAMA = txtAciklama.Text;

            AlacakNedenleri.Add(neden);

            MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(neden);

            return neden;
        }

        public void LoadData()
        {
            BelgeUtil.Inits.AlacakNedeniDoldur(new[]
                                                   {
                                                       lueAlacakNeden.Properties,
                                                       rLueAlacakNeden
                                                   }, MyFoy.TAKIP_TALEP_ID.Value);

            BelgeUtil.Inits.DovizTipGetir(rLueDovizTipi);
            BelgeUtil.Inits.DovizTipGetir(TutarDovizTip2);
            BelgeUtil.Inits.ParaBicimiAyarla(IslemeKonanTutar.Properties);
            BelgeUtil.Inits.ParaBicimiAyarla(repositoryItemSpinEdit1);
        }

        private void DefaultValues()
        {
            lueAlacakNeden.EditValue = -1;
            TutarDovizTip2.EditValue = 1;
            txtRefNo1.Text = "";
            txtAciklama.Text = "";
            txtDigerAlacak.Text = "";
            IslemeKonanTutar.Text = "";
        }

        private int digerId;

        private void FormHazirla(ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
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
                    labelControl1.Enabled = true;
                }
                else
                {
                    txtDigerAlacak.Enabled = false;
                    labelControl1.Enabled = false;
                }
            }
        }

        private void FormTipiHazýrlýk()
        {
            FormTipleri f = (FormTipleri)MyFoy.FORM_TIP_ID.Value;
            FormKonusu k = (FormKonusu)MyFoy.TAKIP_TALEP_ID.Value;

            #region <AC - 20090618>

            // lueAlacakNeden.Properties.DataSource view dan geldiði için TList VList olarak deðiþtirildi.
            VList<per_TI_KOD_ALACAK_NEDEN> ned = (VList<per_TI_KOD_ALACAK_NEDEN>)lueAlacakNeden.Properties.DataSource;
            VList<per_TI_KOD_ALACAK_NEDEN> silinecek = new VList<per_TI_KOD_ALACAK_NEDEN>();

            #endregion </AC - 20090618>

            switch (f)
            {
                case FormTipleri.Form54:
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
                            txtDigerAlacak.Visible = false;
                            labelControl1.Visible = false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void btnYeniAlacakNeden_Click(object sender, EventArgs e)
        {
            //Burada Yapýlan Kontrole Göre kullanýcýya uyarý vermeliyiz.
            if (Validator.Validate())
            {
                //MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Clear();

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
                        myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Remove(secilenler[i]);
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
            if (digerId > 0 && (int)lueAlacakNeden.EditValue == digerId)
            {
                txtDigerAlacak.Enabled = true;
                labelControl1.Enabled = true;
                txtDigerAlacak.Text = "";
            }
            else
            {
                txtDigerAlacak.Enabled = false;
                labelControl1.Enabled = false;
                txtDigerAlacak.Text = lueAlacakNeden.Text;
            }
        }

        private void lueAlacakNeden_EditValueChanging(object sender, ChangingEventArgs e)
        {
            FormHazirla(e);
        }
    }
}