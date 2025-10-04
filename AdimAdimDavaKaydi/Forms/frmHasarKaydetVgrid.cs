using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmHasarKaydetVgrid : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmHasarKaydetVgrid()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private bool donecekKontrol;
        private AV001_TDI_BIL_POLICE gelenPolice = new AV001_TDI_BIL_POLICE();
        private bool isModul;

        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl1.Visible = value;
            }
        }

        public bool KontrolEt()
        {
            //HASAR_TUTARI
            //HASAR_NO
            foreach (var hasarim in ucHasarKayitvGrid1.MyDataSource)
            {
                if (hasarim.HASAR_TUTARI == decimal.MinValue || hasarim.HASAR_TUTARI == null ||
                    hasarim.HASAR_TUTARI == 0 || hasarim.HASAR_NO == null || hasarim.HASAR_NO == "" ||
                    hasarim.HASAR_NO == string.Empty)
                {
                    donecekKontrol = false;
                }
                else
                    donecekKontrol = true;
            }
            if (donecekKontrol)
                return true;
            else
                return false;
        }

        private void frmHasarKaydetVgrid_Button_Kaydet_Click(object sender, EventArgs e)
        {
            //KAYDET BUTON
            if (KontrolEt())
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        "İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine +
                        "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    try
                    {
                        tran.BeginTransaction();

                        DataRepository.AV001_TDI_BIL_POLICE_HASARProvider.DeepSave(tran, ucHasarKayitvGrid1.MyDataSource,
                                                                                   DeepSaveType.IncludeChildren,
                                                                                   typeof(AV001_TDI_BIL_POLICE));

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen)
                            tran.Rollback();

                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                else
                    XtraMessageBox.Show("Kayıt İşlemine Onay Verilmediğinden Dolayı Kayıt İşlemi Yapılamadı...");
            }
            else
                XtraMessageBox.Show("Hasar Tutarı ve Hasar No Alanları Boş Geçilemez...");
        }

        private void frmHasarKaydetVgrid_Load(object sender, EventArgs e)
        {
            //LOAD
            ucHasarKayitvGrid1.MyDataSource = new TList<AV001_TDI_BIL_POLICE_HASAR>();
            ucHasarKayitvGrid1.MyDataSource.AddNew();

            if (isModul)
            {
                //gluePolice doldurulacak.
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmHasarKaydetVgrid_Button_Kaydet_Click;
        }
    }
}