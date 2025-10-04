using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmKiymetliEvrakGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private int? BankaID;

        private string BankaSubeKodu;

        private BackgroundWorker bckWorker;

        private string CekNo;

        private int? EvrakTurID;

        private string HesapNo;

        private int? IlkAlacakliID;

        private int? IlkBorcluID;

        private DateTime? KayitTarihi;

        private TList<AV001_TDI_BIL_KIYMETLI_EVRAK> MyDataSource = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

        private DateTime? SorulduguTarih;

        private int? SubeID;

        private DateTime? TanzimTarihi;

        private bool? Teminatmi;

        private DateTime? VadeTarihi;

        public rFrmKiymetliEvrakGirisEkran()
        {
            this.Load += rFrmKiymetliEvrakGirisEkran_Load;
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem18_ItemClick;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
        }

        public void KiymetliEvrakKaydet()
        {
            DialogResult dr =
                XtraMessageBox.Show(
                    "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(tran, MyDataSource);
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            bckWorker = new BackgroundWorker();
            bckWorker.DoWork += delegate
                                    {
                                        MyDataSource = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                                        DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(MyDataSource, true,
                                                                                                     DeepLoadType.
                                                                                                         IncludeChildren,
                                                                                                     typeof(
                                                                                                         TList
                                                                                                         <
                                                                                                         AV001_TDI_BIL_KIYMETLI_EVRAK_SUREC
                                                                                                         >));

                                        foreach (AV001_TDI_BIL_KIYMETLI_EVRAK var in MyDataSource)
                                        {
                                            if (var.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection != null)
                                            {
                                                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.DeepLoad(
                                                    var.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection, false,
                                                    DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                                            }
                                        }
                                    };
            bckWorker.RunWorkerCompleted += delegate
                                                {
                                                    this.ucKiymetliEvrakGiris1 =
                                                        new AdimAdimDavaKaydi.UserControls.ucKiymetliEvrakGiris();
                                                    this.nvbControlArama.Controls.Add(this.ucKiymetliEvrakGiris1);

                                                    //
                                                    // ucKiymetliEvrakGiris1
                                                    //
                                                    this.ucKiymetliEvrakGiris1.Dock =
                                                        System.Windows.Forms.DockStyle.Fill;
                                                    this.ucKiymetliEvrakGiris1.Location = new System.Drawing.Point(0, 0);

                                                    this.ucKiymetliEvrakGiris1.Name = "ucKiymetliEvrakGiris1";
                                                    this.ucKiymetliEvrakGiris1.Size = new System.Drawing.Size(922, 604);
                                                    this.ucKiymetliEvrakGiris1.TabIndex = 3;

                                                    ucKiymetliEvrakGiris1.MyDataSource = MyDataSource;
                                                    this.Enabled = true;
                                                };
            bckWorker.RunWorkerAsync();
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

        private void barButtonItem18_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void barButtonItem19_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc);
        }

        private void barButtonItem20_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst);
        }

        private void barButtonItem21_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls);
        }

        private void barButtonItem22_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf);
        }

        private void barButtonItem3_ItemClick(object sender, EventArgs e)
        {
            //KAYDET   KIYMETLÝ EVRAK

            KiymetliEvrakKaydet();
        }

        private void dtKayitTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKayitTarihi.EditValue != null)
                KayitTarihi = (DateTime?)dtKayitTarihi.EditValue;
            else
                KayitTarihi = null;
        }

        private void dtSorulduguTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (dtSorulduguTarih.EditValue != null)
                SorulduguTarih = (DateTime?)dtSorulduguTarih.EditValue;
            else
                SorulduguTarih = null;
        }

        private void dtTanzimTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTanzimTarihi.EditValue != null)
                TanzimTarihi = (DateTime?)dtTanzimTarihi.EditValue;
            else
                TanzimTarihi = null;
        }

        private void dtVadeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtVadeTarihi.EditValue != null)
                VadeTarihi = (DateTime?)dtVadeTarihi.EditValue;
            else
                VadeTarihi = null;
        }

        private void lueBankaID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBankaID.EditValue != null)
                BankaID = (int)lueBankaID.EditValue;
            else
                BankaID = null;
        }

        private void lueEvrakTurID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueEvrakTurID.EditValue != null)
                EvrakTurID = (int)lueEvrakTurID.EditValue;
            else
                EvrakTurID = null;
        }

        private void lueIlkAlacakliID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIlkAlacakliID.EditValue != null)
                IlkAlacakliID = (int)lueIlkAlacakliID.EditValue;
            else
                IlkAlacakliID = null;
        }

        private void lueIlkBorcluID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIlkBorcluID.EditValue != null)
                IlkBorcluID = (int)lueIlkBorcluID.EditValue;
            else
                IlkBorcluID = null;
        }

        private void lueSubeID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubeID.EditValue != null)
                SubeID = (int)lueSubeID.EditValue;
            else
                SubeID = null;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value == null)
            {
                Teminatmi = null;
            }
            else
            {
                Teminatmi = Convert.ToBoolean(radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value);
            }
        }

        private void rFrmKiymetliEvrakGirisEkran_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            InitializeComponent();
            InitializeEvents();

            lueEvrakTurID.Properties.NullText = "Seç";
            lueEvrakTurID.Enter += delegate { BelgeUtil.Inits.KiymetliEvrakTipiGetir(lueEvrakTurID); };

            lueBankaID.Properties.NullText = "Seç";
            lueBankaID.Enter += delegate { BelgeUtil.Inits.BankaGetir(lueBankaID); };

            lueSubeID.Properties.NullText = "Seç";
            lueSubeID.Enter += delegate { BelgeUtil.Inits.SubeKodGetir(lueSubeID.Properties); };

            lueIlkAlacakliID.Properties.NullText = "Seç";
            lueIlkAlacakliID.Enter += delegate { BelgeUtil.Inits.perCariGetir(lueIlkAlacakliID); };

            lueIlkBorcluID.Properties.NullText = "Seç";
            lueIlkBorcluID.Enter += delegate { BelgeUtil.Inits.perCariGetir(lueIlkBorcluID); };
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_KIYMETLI_EVRAK> KiymetliEvrakList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
            KiymetliEvrakList = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByFiltre(EvrakTurID, KayitTarihi,
                                                                                                VadeTarihi, TanzimTarihi,
                                                                                                null, BankaID, SubeID,
                                                                                                BankaSubeKodu, HesapNo,
                                                                                                CekNo, SorulduguTarih,
                                                                                                null, null, null,
                                                                                                IlkAlacakliID,
                                                                                                IlkBorcluID, null,
                                                                                                Teminatmi, null);
            ucKiymetliEvrakGiris1.MyDataSource = KiymetliEvrakList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(lCntrlKiymetliEvrak.Controls);
            ucKiymetliEvrakGiris1.MyDataSource = null;
        }

        private void txtCekNo_TextChanged(object sender, EventArgs e)
        {
            CekNo = "%" + txtCekNo.Text + "%";
            if (txtCekNo.Text == string.Empty)
                CekNo = null;
        }

        private void txtHesapNo_TextChanged(object sender, EventArgs e)
        {
            HesapNo = "%" + txtHesapNo.Text + "%";
            if (txtHesapNo.Text == string.Empty)
                HesapNo = null;
        }
    }
}