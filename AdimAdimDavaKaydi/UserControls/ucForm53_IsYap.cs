using System;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucForm53_IsYap : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucForm53_IsYap()
        {
            InitializeComponent();
            this.Load += ucForm53_IsYap_Load;
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
                ucAlacakNedenTaraf1.DtAlacakNeden = null;
                gcTarafFaiz.DataSource = null;
            }
        }

        #endregion

        #region Private Methods

        private AV001_TI_BIL_ALACAK_NEDEN AddNew()
        {
            AV001_TI_BIL_ALACAK_NEDEN neden = new AV001_TI_BIL_ALACAK_NEDEN();

            if (lueAlacakNeden.EditValue != null)
                neden.ALACAK_NEDEN_KOD_ID = (int)lueAlacakNeden.EditValue;

            if (GUN.Value > 0)
            {
                neden.SURE_GUN = Convert.ToInt32(GUN.EditValue);
            }
            if (AY.Value > 0)
            {
                neden.SURE_AY = Convert.ToByte(AY.EditValue);
            }
            if (YIL.Value > 0)
            {
                neden.SURE_YIL = Convert.ToByte(YIL.EditValue);
            }

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
                                                       rLueAlacakNedenID,
                                                       lueAlacakNeden.Properties
                                                   }, MyFoy.TAKIP_TALEP_ID.Value);
            BelgeUtil.Inits.FaizTipiGetir(rLueFaizTipId);
        }

        public void DefaultValues()
        {
            YIL.EditValue = null;
            AY.EditValue = null;
            GUN.EditValue = null;
            lueAlacakNeden.EditValue = -1;
            txtAciklama.Text = "";
        }


        private void FormHazirla(ChangingEventArgs e)
        {
           
        }

        private void FormTipiHaz�rl�k()
        {
            FormTipleri f = (FormTipleri)MyFoy.FORM_TIP_ID.Value;
            FormKonusu k = (FormKonusu)MyFoy.TAKIP_TALEP_ID.Value;

            #region <AC - 20090618>

            // lueAlacakNeden.Properties.DataSource view dan geldi�i i�in TList VList olarak de�i�tirildi.
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
                            if (var.ALACAK_NEDENI.Contains("D��ER ALACAK..."))
                            {
                                silinecek.Add(var);
                            }
                        }

                    #region <AC - 20090618>

                    // silinecek.Count int tipinde value type d�r. Value type lar null de�er i�eremez. Bu durumda a�a��daki kontrol yanl��t�r.
                    // if (silinecek.Count != null)	sat�r� if (silinecek.Count > 0) olarak de�i�tirildi.

                    #endregion </AC - 20090618>

                    if (silinecek.Count > 0)
                    {
                        foreach (per_TI_KOD_ALACAK_NEDEN n in silinecek)
                        {
                            ned.Remove(n);
                            lueAlacakNeden.Properties.DataSource = ned;
                            rLueAlacakNedenID.DataSource = ned;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void ucForm53_IsYap_Load(object sender, EventArgs e)
        {
            gwAlacakNeden.FocusedRowChanged += gwAlacakNeden_FocusedRowChanged;
            FormTipiHaz�rl�k();
        }

        private void btnYeniAlacakNeden_Click(object sender, EventArgs e)
        {
            if (Validator.Validate())
            {
                OnAlacakNedenEklendi(this, new AlacakNedenEklendiEventArgs(AddNew()));
            }
            gcAlacakNeden.DataSource = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection;
            DefaultValues();
        }

        private void btnAlacakNedenSil_Click(object sender, EventArgs e)
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
                DialogResult ds = XtraMessageBox.Show("Se�ili kay�tlar� silmek istedi�inizden emin misiniz ?",
                                                      "Silme ��lemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void lueAlacakNeden_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            FormHazirla(e);
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
    }
}