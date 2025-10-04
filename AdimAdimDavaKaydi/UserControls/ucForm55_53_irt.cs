using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucForm55_53_irt : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucForm55_53_irt()
        {
            InitializeComponent();
            this.Load += ucForm55_53_irt_Load;
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
                    LoadData();
                    DefaultValues();
                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.AddingNew += AV001_TI_BIL_ALACAK_NEDENCollection_AddingNew;

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

        private void DefaultValues()
        {
            lueAlacakNeden.EditValue = null;
            txtAciklama.Text = null;
            txtDigerAlacak.Text = "";
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
                ucAlacakNedenTaraf1.DtAlacakNeden.Clear();
                gcTarafFaiz.DataSource = null;
            }
        }

        private void AV001_TI_BIL_ALACAK_NEDENCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN addNew = new AV001_TI_BIL_ALACAK_NEDEN();
            txtDigerAlacak.Enabled = false;
            addNew.ALACAK_FAIZ_TIP_ID = 1;
            if (addNew.TO_ALACAK_FAIZ_TIP_ID == 1)
                addNew.TO_UYGULANACAK_FAIZ_ORANI = 9;
            if (addNew.ALACAK_FAIZ_TIP_ID == 1)
                addNew.UYGULANACAK_FAIZ_ORANI = 9;

            e.NewObject = addNew;
        }

        #endregion

        #region Private Methods

        public void LoadData()
        {
            BelgeUtil.Inits.AlacakNedeniDoldur(new[]
                                                   {
                                                       lueAlacakNeden.Properties,
                                                       rLueAlacakNeden
                                                   }, MyFoy.TAKIP_TALEP_ID.Value);
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
                case FormTipleri.Form53:
                    if (k != FormKonusu.Form53_NAFAKA && k != FormKonusu.Form53_ILAMLI_ALACAK &&
                        k != FormKonusu.Form53_ISCI_ALACAGI)
                        foreach (per_TI_KOD_ALACAK_NEDEN var in ned)
                        {
                            if (var.ALACAK_NEDENI.Contains("DÝÐER ALACAK..."))
                            {
                                silinecek.Add(var);
                            }
                        }
                    if (silinecek.Count > 0)
                    {
                        foreach (per_TI_KOD_ALACAK_NEDEN n in silinecek)
                        {
                            ned.Remove(n);
                            lueAlacakNeden.Properties.DataSource = ned;
                            labelControl1.Visible = false;
                            txtDigerAlacak.Visible = false;
                            rLueAlacakNeden.DataSource = ned;
                        }
                    }
                    break;
                case FormTipleri.Form55:
                    foreach (per_TI_KOD_ALACAK_NEDEN var in ned)
                    {
                        if (var.ALACAK_NEDENI.Contains("DÝÐER ALACAK..."))
                        {
                            silinecek.Add(var);
                        }
                    }
                    if (silinecek.Count > 0)
                    {
                        foreach (per_TI_KOD_ALACAK_NEDEN n in silinecek)
                        {
                            ned.Remove(n);
                            lueAlacakNeden.Properties.DataSource = ned;
                            labelControl1.Visible = false;
                            txtDigerAlacak.Visible = false;
                            rLueAlacakNeden.DataSource = ned;
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private AV001_TI_BIL_ALACAK_NEDEN AddNew()
        {
            AV001_TI_BIL_ALACAK_NEDEN neden = new AV001_TI_BIL_ALACAK_NEDEN();

            if (lueAlacakNeden.EditValue != null)
                neden.ALACAK_NEDEN_KOD_ID = (int)lueAlacakNeden.EditValue;
            if (txtDigerAlacak.Text != "")
                neden.DIGER_ALACAK_NEDENI = txtDigerAlacak.Text;

            AlacakNedenleri.Add(neden);

            MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(neden);

            return neden;
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
                        digerId = 72;
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

        private void DataChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN gonderen = (AV001_TI_BIL_ALACAK_NEDEN)sender;

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.VADE_TARIHI)
            {
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTARI)
            {
                gonderen.ISLEME_KONAN_TUTAR = (decimal)e.Value;
            }
            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_UYGULANACAK_FAIZ_ORANI &&
                gonderen.ALACAK_FAIZ_TIP_ID == 9 && gonderen.TO_ALACAK_FAIZ_TIP_ID == 9)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = (double)e.Value;
            }
        }

        #endregion

        private void ucForm55_53_irt_Load(object sender, EventArgs e)
        {
            gwAlacakNeden.FocusedRowChanged += gwAlacakNeden_FocusedRowChanged;
            FormTipiHazýrlýk();
        }

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

        private void lueAlacakNeden_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            FormHazirla(e);
        }

        private void lueAlacakNeden_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAlacakNeden.EditValue != null)
            {
                if (digerId > 0 && (int)lueAlacakNeden.EditValue == digerId)
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
    }
}