using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class rFrmMehil : Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY _myFoy;

        private TList<AV001_TI_BIL_MEHIL> myDataSource;

        public rFrmMehil()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += rFrmMehil_Load;
            this.FormClosed += rFrmMehil_FormClosed;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_MEHIL> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                myDataSource = value;
                if (!DesignMode)
                {
                    if (myDataSource == null)
                        myDataSource = new TList<AV001_TI_BIL_MEHIL>();
                    dataNavigatorExtended1.DataSource = myDataSource;
                    vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                    gridControl1.DataSource = dataNavigatorExtended1.DataSource;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (value != null)
                {
                    BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rLueBorclu });
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        public void Show(AV001_TI_BIL_FOY MyFoy)
        {
            this.MyFoy = MyFoy;
            this.Show();
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vGridControl1.Visible)
            {
                vGridControl1.Visible = false;
                gridControl1.Visible = true;
                gridControl1.BringToFront();
            }
            else if (gridControl1.Visible)
            {
                vGridControl1.Visible = true;
                gridControl1.Visible = false;
                vGridControl1.BringToFront();
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmMehil_Button_Kaydet_Click;
        }

        private void rFrmMehil_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                    "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rFrmMehil_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null) return;
            ucIcraTarafGelismeleri.MehilTarihiHesapla(MyGelisme, MyFoy);
        }

        private void rFrmMehil_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (MyFoy == null)
                {
                    BelgeUtil.Inits.perCariGetir(rLueBorclu);
                }
            }
        }

        private bool Save()
        {
            bool sonuc = false;

            if (MyFoy != null)
            {
                MyDataSource.ForEach(delegate(AV001_TI_BIL_MEHIL h) { h.ICRA_FOY_ID = MyFoy.ID; });
            }
            MyFoy.AV001_TI_BIL_MEHILCollection.AddRange(MyDataSource);

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();
                DataRepository.AV001_TI_BIL_MEHILProvider.DeepSave(trans, MyDataSource);
                trans.Commit();
                sonuc = true;
                ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return false;
            }
            finally
            {
                trans.Dispose();
            }
            return sonuc;
        }
    }
}