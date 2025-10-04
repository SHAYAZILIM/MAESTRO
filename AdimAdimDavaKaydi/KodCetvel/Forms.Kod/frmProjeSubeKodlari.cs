using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    public partial class frmProjeSubeKodlari : Form
    {
        public frmProjeSubeKodlari()
        {
            InitializeComponent();
        }

        private void frmProjeSubeKodlari_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        public void Doldur()
        {
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(relueCariMuvekkil, AvukatProLib.Extras.CariStatu.Müvekkil);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;

            gridAdresDurumlari.DataSource = cn.GetDataTable("select ID, OZEL_KOD, CARI_ID from dbo.TDIE_KOD_PROJE_OZEL_KOD(nolock)");
        }

        private void Kaydet()
        {
            DialogResult dr = XtraMessageBox.Show("İlgili kayıtlarda yaptığınız tüm değişiklikler kaydedilecektir" + Environment.NewLine + "Onaylıyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                try
                {

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        cn.Clear();
                        bool varmi = false;
                        if (gridView1.GetRowCellValue(i, "ID") != null)
                        {
                            if (gridView1.GetRowCellValue(i, "ID") != DBNull.Value)
                            {
                                try
                                {
                                    cn.AddParams("@OZEL_KOD", gridView1.GetRowCellValue(i, "OZEL_KOD"));
                                    cn.AddParams("@CARI_ID", gridView1.GetRowCellValue(i, "CARI_ID"));
                                    cn.AddParams("@ID", gridView1.GetRowCellValue(i, "ID"));
                                    cn.ExcuteQuery("update dbo.TDIE_KOD_PROJE_OZEL_KOD set OZEL_KOD=@OZEL_KOD, CARI_ID=@CARI_ID where ID=@ID");
                                }
                                catch { ;}
                            }
                        }

                        if (!varmi)
                        {
                            try
                            {
                                varmi = true;
                                cn.AddParams("@OZEL_KOD", gridView1.GetRowCellValue(i, "OZEL_KOD"));
                                cn.AddParams("@CARI_ID", gridView1.GetRowCellValue(i, "CARI_ID"));

                                cn.ExcuteQuery("insert into dbo.TDIE_KOD_PROJE_OZEL_KOD (OZEL_KOD, KONTROL_KIM, KAYIT_TARIHI, STAMP, ADMIN_KAYIT_MI, KONTROL_KIM_ID, CARI_ID) values (@OZEL_KOD, 'AVUKATPRO', getdate(), 1, 1, NULL, @CARI_ID)");
                            }
                            catch { ;}                            
                        }
                    }
                    //XtraMessageBox.Show("Adres Türleri Kaydedilmiştir...");
                }
                catch 
                {
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
    }
}
