using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucKimNeredeBilgileri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKimNeredeBilgileri()
        {
            InitializeComponent();
        }

        public bool ArsivMi { get; set; }

        private AvukatProLib.Arama.AvpDataContext db =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        private List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE> _myDataSource;

        [Browsable(false)]
        public List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE> MyDataSource
        {
            get
            {
                if (exGridKimNErede.DataSource is List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE>)
                    return (List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE>)exGridKimNErede.DataSource;
                return _myDataSource;
            }
            set
            {
                _myDataSource = value;
                if (_myDataSource == null)
                    _myDataSource = new List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE>();

                exGridKimNErede.DataSource = _myDataSource;
            }
        }

        public void LookupsFiil()
        {
            BelgeUtil.Inits.GetCariImages(cmpImgPersonel);
            //Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            //Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            //Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            //Inits.MuhasebeHareketAltKategori(rLueIsKategoriId);
        }

        private void ucKimNeredeBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            LookupsFiil();
        }

        private void exGridKimNErede_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;
            if (e.Button.Tag.ToString() == "FormAc")
            {
                Forms.frmKimNeredeEkleme kimNerede = new AdimAdimDavaKaydi.Forms.frmKimNeredeEkleme();
                kimNerede.AddNewList = new TList<AV001_TDIE_BIL_KIM_NEREDE>();
                kimNerede.AddNewList.AddNew();
                //kimNerede.MdiParent = null;
                kimNerede.StartPosition = FormStartPosition.WindowsDefaultLocation;
                kimNerede.FormClosed += kimNerede_FormClosed;
                kimNerede.Show();
            }
            if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                Forms.frmKimNeredeEkleme kimNerede = new AdimAdimDavaKaydi.Forms.frmKimNeredeEkleme();
                if (kimNerede.AddNewList == null)
                    kimNerede.AddNewList = new TList<AV001_TDIE_BIL_KIM_NEREDE>();
                kimNerede.AddNewList.Add(
                    DataRepository.AV001_TDIE_BIL_KIM_NEREDEProvider.GetByID(MyDataSource[gridView1.FocusedRowHandle].ID));
                //kimNerede.MdiParent = null;
                kimNerede.StartPosition = FormStartPosition.WindowsDefaultLocation;
                kimNerede.FormClosed += kimNerede_FormClosed;
                kimNerede.Show();
            }
        }

        private void kimNerede_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.ArsivMi)
            {
                List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE> kimNerede =
                    AvukatProLib.Arama.R_KIM_NEREDESorgu.GetByFiltre(null, null, null, null, null, null,
                                                                     AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                exGridKimNErede.DataSource = kimNerede;
            }
            else
            {
                List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE> kimNerede =
                    AvukatProLib.Arama.R_KIM_NEREDESorgu.GetByFiltre(null, DateTime.Now.Date, null, null, null, null,
                                                                     AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                exGridKimNErede.DataSource = kimNerede;
            }
        }
    }
}