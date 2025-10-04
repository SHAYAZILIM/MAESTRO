using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class rfrmHasarGirisEkrani : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public rfrmHasarGirisEkrani()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private TList<AV001_TDI_BIL_POLICE_HASAR> _MyDataSource;

        private int? DosyaDurumID;

        private string HasarNo;

        private int? RucuDurumID;

        private DateTime? Tarih;

        private int? TeminatAltTipID;

        public TList<AV001_TDI_BIL_POLICE_HASAR> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                ucHasarBilgileri1.MyDataSource = MyDataSource;
            }
        }

        public void PoliceHasarKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine
                    + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();

                    //DataRepository.AV001_TDI_BIL_POLICEProvider.DeepSave(tran, MyDataSourcePolice);
                    DataRepository.AV001_TDI_BIL_POLICE_HASARProvider.DeepSave(tran, MyDataSource);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        ((DateEdit)con).EditValue = null;
                    }
                    else if (con is TextEdit)
                    {
                        con.Text = string.Empty;
                    }
                    else if (con is SpinEdit)
                    {
                        (con as SpinEdit).EditValue = null;
                    }
                }
            }
            catch (Exception )
            {
            }
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            PoliceHasarKaydet();
        }

        private void dtTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih.EditValue != null)
                Tarih = (DateTime?)dtTarih.EditValue;
            else
                Tarih = null;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void lueDosyaDurumID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDosyaDurumID.EditValue != null)
                DosyaDurumID = (int)lueDosyaDurumID.EditValue;
            else
                DosyaDurumID = null;
        }

        private void lueRucuDurumID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueRucuDurumID.EditValue != null)
                RucuDurumID = (int)lueRucuDurumID.EditValue;
            else
                RucuDurumID = null;
        }

        private void lueTeminatAltTipID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTeminatAltTipID.EditValue != null)
                TeminatAltTipID = (int)lueTeminatAltTipID.EditValue;
            else
                TeminatAltTipID = null;
        }

        private void rfrmHasarGirisEkrani_Load(object sender, EventArgs e)
        {
            MyDataSource = DataRepository.AV001_TDI_BIL_POLICE_HASARProvider.GetAll();
            ucHasarBilgileri1.MyDataSource = MyDataSource;

            lueTeminatAltTipID.Properties.NullText = "Seç";
            lueTeminatAltTipID.Enter += delegate { BelgeUtil.Inits.TeminatAltTipGetir(lueTeminatAltTipID); };

            lueRucuDurumID.Properties.NullText = "Seç";
            lueRucuDurumID.Enter += delegate { BelgeUtil.Inits.FoyDurumGetir(lueRucuDurumID); };

            lueDosyaDurumID.Properties.NullText = "Seç";
            lueDosyaDurumID.Enter += delegate { BelgeUtil.Inits.DosyaDurumGetir(lueDosyaDurumID); };
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_POLICE_HASAR> HasarBilgileriList = new TList<AV001_TDI_BIL_POLICE_HASAR>();
            HasarBilgileriList = DataRepository.AV001_TDI_BIL_POLICE_HASARProvider.GetByFiltre(HasarNo, TeminatAltTipID,
                                                                                               null, Tarih, RucuDurumID,
                                                                                               DosyaDurumID);
            ucHasarBilgileri1.MyDataSource = HasarBilgileriList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(lCntrlHasar.Controls);
            ucHasarBilgileri1.MyDataSource = null;
        }

        private void txtHasarNo_EditValueChanged(object sender, EventArgs e)
        {
            HasarNo = "%" + txtHasarNo.Text + "%";
            if (txtHasarNo.Text == string.Empty)
                HasarNo = null;
        }
    }
}