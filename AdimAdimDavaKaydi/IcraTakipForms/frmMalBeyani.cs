using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;

//using AvukatProLib.Controls;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmMalBeyani : Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY myFoy;

        private AV001_TI_BIL_FOY_TARAF_GELISME myGelisme;

        public frmMalBeyani()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += new EventHandler(frmMalBeyani_Load);
            this.FormClosing += new FormClosingEventHandler(frmMalBeyani_FormClosing);
            this.FormClosed += new FormClosedEventHandler(frmMalBeyani_FormClosed);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new RepositoryItemLookUpEdit[] { rLueCari });

                    dataNavigatorExtended1.DataSource = MyFoy.AV001_TI_BIL_MAL_BEYANICollection;
                    vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                    gridControl1.DataSource = dataNavigatorExtended1.DataSource;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme
        {
            get { return myGelisme; }
            set { myGelisme = value; }
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += new EventHandler<EventArgs>(frmMalBeyani_Button_Kaydet_Click);
        }

        public void Show(AV001_TI_BIL_FOY entity)
        {
            MyFoy = entity;

            this.Show();
        }
                
        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vGridControl1.Visible == true)
            {
                vGridControl1.Visible = false;
                gridControl1.Visible = true;
                gridControl1.BringToFront();
            }
            else if (gridControl1.Visible == true)
            {
                vGridControl1.Visible = true;
                gridControl1.Visible = false;
                vGridControl1.BringToFront();
            }
        }

        private void frmMalBeyani_Button_Kaydet_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMalBeyani_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null) return;

            ucIcraTarafGelismeleri.MalBeyaniTarihiHesapla(MyGelisme, MyFoy);
        }

        private void frmMalBeyani_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void frmMalBeyani_Load(object sender, EventArgs e)
        {
        }
    }
}