using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmPoliceHasarGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private string AcenteNo;

        private string AcenteUnvani;

        private DateTime? BaslangicTarihi;

        private string BelgeNo;

        private DateTime? BitisTarihi;

        private int? PoliceBransID;

        private string PoliceNo;

        private int? SigortaciCariID;

        private int? SigortaEttirenCariID;

        private int? SigortaliCariID;

        public rFrmPoliceHasarGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public TList<AV001_TDI_BIL_POLICE> MyDataSourcePolice { get; set; }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem22_ItemClick;
            this.Button_Excel_Click += barButtonItem25_ItemClick;
            this.Button_Outlook_Click += barButtonItem24_ItemClick;
            this.Button_PDF_Click += barButtonItem26_ItemClick;
            this.Button_Word_Click += barButtonItem23_ItemClick;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        public void PoliceHasarKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine
                    + "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_POLICEProvider.DeepSave(tran, MyDataSourcePolice);
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
            catch 
            {
            }
        }

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void barButtonItem23_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        private void barButtonItem24_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void barButtonItem25_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void barButtonItem26_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        //TList<AV001_TDI_BIL_POLICE> MyDataSourcePolice = new TList<AV001_TDI_BIL_POLICE>();
        //TList<AV001_TDI_BIL_POLICE_HASAR> MyDataSourceHasar = new TList<AV001_TDI_BIL_POLICE_HASAR>();
        //private TList<AV001_TDI_BIL_POLICE_HASAR> _MyDataSourceHasar;

        //public TList<AV001_TDI_BIL_POLICE_HASAR> MyDataSourceHasar
        //{
        //    get { return MyDataSourceHasar; }
        //    set
        //    {
        //        _MyDataSourceHasar = value;

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            PoliceHasarKaydet();
        }

        private void dtBaslangicTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaslangicTarihi.EditValue != null)
                BaslangicTarihi = (DateTime?)dtBaslangicTarihi.EditValue;
            else
                BaslangicTarihi = null;
        }

        private void dtBitisTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBitisTarihi.EditValue != null)
                BitisTarihi = (DateTime?)dtBitisTarihi.EditValue;
            else
                BitisTarihi = null;
        }

        private void luePoliceBransID_EditValueChanged(object sender, EventArgs e)
        {
            if (luePoliceBransID.EditValue != null)
                PoliceBransID = (int)luePoliceBransID.EditValue;
            else
                PoliceBransID = null;
        }

        private void lueSigortaciCariID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSigortaciCariID.EditValue != null)
                SigortaciCariID = (int)lueSigortaciCariID.EditValue;
            else
                SigortaciCariID = null;
        }

        private void lueSigortaEttirenCariID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSigortaEttirenCariID.EditValue != null)
                SigortaEttirenCariID = (int)lueSigortaEttirenCariID.EditValue;
            else
                SigortaEttirenCariID = null;
        }

        private void lueSigortaliCariID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSigortaliCariID.EditValue != null)
                SigortaliCariID = (int)lueSigortaliCariID.EditValue;
            else
                SigortaliCariID = null;
        }

        //    }
        //}
        private void rFrmPoliceHasarGirisEkran_Load(object sender, EventArgs e)
        {
            //LOAD

            MyDataSourcePolice = new TList<AV001_TDI_BIL_POLICE>();
            ucPoliceBilgileri1.MyDataSource = MyDataSourcePolice;

            lueSigortaciCariID.Properties.NullText = "Seç";
            lueSigortaciCariID.Enter += delegate { BelgeUtil.Inits.perCariGetir(lueSigortaciCariID); };

            lueSigortaEttirenCariID.Properties.NullText = "Seç";
            lueSigortaEttirenCariID.Enter += delegate { BelgeUtil.Inits.perCariGetir(lueSigortaEttirenCariID); };

            lueSigortaliCariID.Properties.NullText = "Seç";
            lueSigortaliCariID.Enter += delegate { BelgeUtil.Inits.perCariGetir(lueSigortaliCariID); };

            luePoliceBransID.Properties.NullText = "Seç";
            luePoliceBransID.Enter += delegate { BelgeUtil.Inits.PoliceBransGetir(luePoliceBransID); };
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_POLICE> PoliceBilgileriList = new TList<AV001_TDI_BIL_POLICE>();
            PoliceBilgileriList = DataRepository.AV001_TDI_BIL_POLICEProvider.GetByFiltre(SigortaciCariID,
                                                                                          SigortaEttirenCariID,
                                                                                          SigortaliCariID, PoliceNo,
                                                                                          PoliceBransID, BaslangicTarihi,
                                                                                          BitisTarihi, null, BelgeNo,
                                                                                          AcenteNo, AcenteUnvani);
            ucPoliceBilgileri1.MyDataSource = PoliceBilgileriList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(layoutControl1.Controls);
            ucPoliceBilgileri1.MyDataSource = null;
        }

        private void txtAcenteNo_EditValueChanged(object sender, EventArgs e)
        {
            AcenteNo = "%" + txtAcenteNo.Text + "%";
            if (txtAcenteNo.Text == string.Empty)
                AcenteNo = null;
        }

        private void txtAcenteUnvani_EditValueChanged(object sender, EventArgs e)
        {
            AcenteUnvani = "%" + txtAcenteUnvani.Text + "%";
            if (txtAcenteUnvani.Text == string.Empty)
                AcenteUnvani = null;
        }

        private void txtBelgeNo_EditValueChanged(object sender, EventArgs e)
        {
            BelgeNo = "%" + txtBelgeNo.Text + "%";
            if (txtBelgeNo.Text == string.Empty)
                BelgeNo = null;
        }

        private void txtPoliceNo_EditValueChanged(object sender, EventArgs e)
        {
            PoliceNo = "%" + txtPoliceNo.Text + "%";
            if (txtPoliceNo.Text == string.Empty)
                PoliceNo = null;
        }
    }
}