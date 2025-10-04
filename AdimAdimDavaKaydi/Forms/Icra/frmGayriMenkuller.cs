using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmGayriMenkuller : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmGayriMenkuller()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += frmGayriMenkuller_Load;
            this.gcGayriMenkul.ButtonClick += gcGayriMenkul_ButtonClick;
        }

        public string TarafId;

        private TList<AV001_TI_BIL_GAYRIMENKUL> secilenler = new TList<AV001_TI_BIL_GAYRIMENKUL>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        [Browsable(false), Description("Seçilen gayrimenkul kayýtlarýný döndürür.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_GAYRIMENKUL> Secilenler
        {
            get { return secilenler; }
            set { secilenler = value; }
        }

        private void btnKaydetCik_ItemClick(object sender, EventArgs e)
        {
            foreach (AV001_TI_BIL_GAYRIMENKUL menkul in gcGayriMenkul.DataSource as TList<AV001_TI_BIL_GAYRIMENKUL>)
            {
                if (menkul.IsSelected)
                    Secilenler.Add(menkul);
            }

            if (Secilenler.Count == 0)
                XtraMessageBox.Show("Seçilen kayýt yok.Lütfen gayrimenkul kaydý seçiniz", "Uyarý", MessageBoxButtons.
                                                                                                       OK,
                                    MessageBoxIcon.Information);
            else
                this.Close();
        }
        
        private void frmGayriMenkuller_Load(object sender, EventArgs e)
        {
            initData();

            BelgeUtil.Inits.IlGetir(rLueIlID);
            BelgeUtil.Inits.IlceGetirOzetli(rLueIlceID);
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
            BelgeUtil.Inits.MalKategoriGetir(rLueMalKategori);
            BelgeUtil.Inits.MalTurGetir(rLueMalTur);
            BelgeUtil.Inits.MalcinsGetir(rLueMalCins);
            BelgeUtil.Inits.BirimKodGetir(rLueMalBirimID);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.UlkeGetir(rLueUlke);
            BelgeUtil.Inits.TespitOzelKodGetir(rLueOzelKod);
        }

        private void gcGayriMenkul_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "frmGayriMenkul")
            {
                frmGayriMenkulGirisi frm = new frmGayriMenkulGirisi();
                frm.MyFoy = this.MyFoy;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();

                if (frm.AddNewList.Count > 0)
                {
                    Refresh(frm.AddNewList);
                }
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydetCik_ItemClick;
        }

        private void initData()
        {
            TList<AV001_TI_BIL_GAYRIMENKUL> result = null;
            if (string.IsNullOrEmpty(TarafId))
            {
                result = BelgeUtil.Inits.GayrimenkulGetir();
            }
            else
            {
                result = AvukatProLib2.Data.Bases.AV001_TI_BIL_GAYRIMENKULProviderBaseCore.Fill(
                    DataRepository.Provider.ExecuteReader("_AV001_TI_BIL_GAYRIMENKUL_GetByBorcluTarafId", TarafId),
                    new TList<AV001_TI_BIL_GAYRIMENKUL>(), 0, int.MaxValue);
            }
            gcGayriMenkul.DataSource = result;

            ((TList<AV001_TI_BIL_GAYRIMENKUL>)gcGayriMenkul.DataSource).ForEach(
                delegate(AV001_TI_BIL_GAYRIMENKUL menkul) { menkul.PropertyChanged += menkul_PropertyChanged; });
        }

        private void menkul_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            gcGayriMenkul.Refresh();
        }

        private void Refresh(TList<AV001_TI_BIL_GAYRIMENKUL> mList)
        {
            ((TList<AV001_TI_BIL_GAYRIMENKUL>)gcGayriMenkul.DataSource).AddRange(mList);
            gcGayriMenkul.Refresh();
            gcGayriMenkul.RefreshDataSource();
        }
    }
}