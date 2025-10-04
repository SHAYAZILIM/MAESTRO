using System;
using System.ComponentModel;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIcraTeminatMektup : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucIcraTeminatMektup()
        {
            if (DesignMode) InitializeComponent();
            this.Load += this.ucIcraTeminatMektup_Load;
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_TEMINAT_MEKTUP> MyDataSource
        {
            get
            {
                if (exGridTeminatMektup.DataSource is TList<AV001_TDI_BIL_TEMINAT_MEKTUP>)
                    return (TList<AV001_TDI_BIL_TEMINAT_MEKTUP>)exGridTeminatMektup.DataSource;
                return null;
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    exGridTeminatMektup.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy { get; set; }

        private void ucIcraTeminatMektup_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            InitsDoldur();

            exGridTeminatMektup.ButtonCevirClick += exGridTeminatMektup_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridTeminatMektup_ButtonCevirClick;
            if (MyIcraFoy != null)
            {
                MyDataSource = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("ICRA_FOY_ID = " + MyIcraFoy.ID);
                //MyDataSource = BelgeUtil.Inits.perTeminatMektupGetirByfoy(MyIcraFoy.ID);
            }
        }

        private bool initsLoaded;

        private void InitsDoldur()
        {
            if (!initsLoaded)
            {
                BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTip);
                BelgeUtil.Inits.TeminatMektupKonuGetir(rLueMektupKonu);
                BelgeUtil.Inits.BankaGetir(rLueBanka);
                BelgeUtil.Inits.BankaDirekSubeIsmiGetir(rLueBankaSubesi);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.TeminatMektupDurumGetir(rLueTeminatDurum);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                //
                BelgeUtil.Inits.TeminatTipGetir(repositoryItemLookUpEdit1);
                BelgeUtil.Inits.TeminatMektupKonuGetir(repositoryItemLookUpEdit2);
                BelgeUtil.Inits.BankaGetir(repositoryItemLookUpEdit3);
                BelgeUtil.Inits.BankaDirekSubeIsmiGetir(repositoryItemLookUpEdit4);
                BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit5);
                BelgeUtil.Inits.TeminatMektupDurumGetir(repositoryItemLookUpEdit6);
            }
        }

        private void exGridTeminatMektup_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridTeminatMektup.Visible)
            {
                exGridTeminatMektup.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                exGridTeminatMektup.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void exGridTeminatMektup_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if ((int)e.Button.Tag == 1)//Yeni Kayýt
            {
                AdimAdimDavaKaydi.Forms.Dava.rFrmTeminatBilgileriKaydet frmTeminatKefalet = new AdimAdimDavaKaydi.Forms.Dava.rFrmTeminatBilgileriKaydet();
                frmTeminatKefalet.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmTeminatKefalet_FormClosed);
                frmTeminatKefalet.Show(MyIcraFoy);
            }
            else if ((int)e.Button.Tag == 2)//Düzenle
            {
                TList<AV001_TDI_BIL_TEMINAT_MEKTUP> DvList = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();
                DvList.Add(gridView1.GetFocusedRow() as AV001_TDI_BIL_TEMINAT_MEKTUP);
                AdimAdimDavaKaydi.Forms.Dava.rFrmTeminatBilgileriKaydet frm = new AdimAdimDavaKaydi.Forms.Dava.rFrmTeminatBilgileriKaydet();
                frm.AddNewList = DvList;
                frm.FormClosed += frmTeminatKefalet_FormClosed;
                frm.Show(MyIcraFoy);
            }
        }

        private void frmTeminatKefalet_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            MyDataSource = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Find("ICRA_FOY_ID = " + MyIcraFoy.ID);
            exGridTeminatMektup.DataSource = MyDataSource;
        }
    }
}