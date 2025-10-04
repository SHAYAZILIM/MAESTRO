using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmHacizliMallar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmHacizliMallar()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public int hacizChildID;

        private TList<AV001_TI_BIL_HACIZ_CHILD> secilenler = new TList<AV001_TI_BIL_HACIZ_CHILD>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        [Browsable(false), Description("Seçilen haciz child kayýtlarýný döndürür.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_HACIZ_CHILD> Secilenler
        {
            get { return secilenler; }
            set { secilenler = value; }
        }

        public void Show(AV001_TI_BIL_FOY foy)
        {
            MyFoy = foy;
            this.Show();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.c_btnTamam.Text = "Gönder";
        }

        private void frmHacizliMallar_Button_Tamam_Click(object sender, EventArgs e)
        {
            //Seçilen kayýtlarý yakala.
            TList<AV001_TI_BIL_HACIZ_CHILD> result =
                gridControl1.DataSource as TList<AV001_TI_BIL_HACIZ_CHILD>;

            //Property'i set et
            //secilenler = result.FindAll("IsSelected", true);
            if (result != null)
            {
                foreach (AV001_TI_BIL_HACIZ_CHILD var in result)
                {
                    if (var.IsSelected)
                        secilenler.Add(var);
                }
            }
            this.Close();
        }

        private void frmHacizliMallar_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                initData();
                initDataSource();
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Tamam_Click += frmHacizliMallar_Button_Tamam_Click;
            this.c_btnTamam.Click += frmHacizliMallar_Button_Tamam_Click;
        }

        /// <summary>
        /// Form açýldýðýnda bir kere çalýsacak olan metodlar.
        /// </summary>
        private void initData()
        {
            BelgeUtil.Inits.ParaBicimiAyarla(rlueTutar);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
            BelgeUtil.Inits.HacizIslemDurumGetir(rlueHacizIslemDurum);
            BelgeUtil.Inits.MalKategoriGetir(rlueMalKategori);
            BelgeUtil.Inits.MalcinsGetir(rlueMalCinsi);
            BelgeUtil.Inits.MalTurGetir(rlueMalTur);
        }

        /// <summary>
        /// Foy üzerindeki hacizlerin childlarýný gridControl'a datasource olarak ata.
        /// </summary>
        /// <param name="foy">AV001_TI_BIL_FOY</param>
        private void initDataSource()
        {
            TList<AV001_TI_BIL_HACIZ_CHILD> result = new TList<AV001_TI_BIL_HACIZ_CHILD>();

            if (MyFoy == null)
            {
                if (hacizChildID != -1)
                {
                    result.Add(DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByID(hacizChildID));
                }
                else
                    result.AddRange(BelgeUtil.Inits.HacizChildGetir());
            }
            else
            {
                if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_HACIZ_MASTER>));

                for (int i = 0; i < MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count; i++)
                {
                    if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(
                            MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection[i], false, DeepLoadType.IncludeChildren,
                            typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));
                    result.AddRange
                        (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection[i].AV001_TI_BIL_HACIZ_CHILDCollection);
                }
                if (result.Count == 0)
                    XtraMessageBox.Show("Lütfen Önce Hacizli/Rehinli Mal Giriþi Yapýnýz");
            }
            gridControl1.DataSource = result;
            gridControl1.RefreshDataSource();
        }
    }
}