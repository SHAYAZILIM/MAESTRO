using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmIcraHesaplanmisFaizGiris : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIcraHesaplanmisFaizGiris()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public AV001_TI_BIL_FOY MyDataSource
        {
            set { ucFoy1.MyDataSource = value; }
            get { return ucFoy1.MyDataSource; }
        }

        private void frmIcraHesaplanmisFaizGiris_Button_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                AV001_TI_BIL_FOY ff = ucFoy1.MyDataSource;
                string msg;
                if (ff.OZEL_TAZMINAT_FAIZ_ISLESINMI)
                {
                    msg = "Özel Tazminat";
                    if (!ff.OZEL_TAZMINAT_DOVIZ_ID.HasValue)
                        throw new Exception(msg + " faiz hesaplamasý için doviz tipi seçilmelidir.");
                    if (!ff.OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI.HasValue)
                        throw new Exception(msg + " faiz hesaplamasý için faiz baþlangýç tarihi girilmelidir.");
                    if (ff.OZEL_TAZMINAT == 0)
                        throw new Exception(msg + " faiz hesaplamasý için tutar girilmelidir.");
                }
                if (ff.OZEL_TUTAR1_FAIZ_ISLESINMI)
                {
                    msg = "Özel Tutar 1";

                    if (!ff.OZEL_TUTAR1_DOVIZ_ID.HasValue)
                        throw new Exception(msg + " faiz hesaplamasý için doviz tipi seçilmelidir.");
                    if (!ff.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI.HasValue)
                        throw new Exception(msg + " faiz hesaplamasý için faiz baþlangýç tarihi girilmelidir.");
                    if (ff.OZEL_TUTAR1 == 0)
                        throw new Exception(msg + " faiz hesaplamasý için tutar girilmelidir.");
                    if (!ff.OZEL_TUTAR1_KONU_ID.HasValue)
                        throw new Exception(msg + " için bir konu belirtilmelidir.");
                }
                if (ff.OZEL_TUTAR2_FAIZ_ISLESINMI)
                {
                    msg = "Özel Tutar 2";

                    if (!ff.OZEL_TUTAR2_DOVIZ_ID.HasValue)
                        throw new Exception(msg + " faiz hesaplamasý için doviz tipi seçilmelidir.");
                    if (!ff.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI.HasValue)
                        throw new Exception(msg + " faiz hesaplamasý için faiz baþlangýç tarihi girilmelidir.");
                    if (ff.OZEL_TUTAR2 == 0)
                        throw new Exception(msg + " faiz hesaplamasý için tutar girilmelidir.");
                    if (!ff.OZEL_TUTAR2_KONU_ID.HasValue)
                        throw new Exception(msg + " için bir konu belirtilmelidir.");
                }
                if (ff.OZEL_TUTAR3_FAIZ_ISLESINMI)
                {
                    msg = "Özel Tutar 3";

                    if (!ff.OZEL_TUTAR3_DOVIZ_ID.HasValue)
                        throw new Exception(msg + " faiz hesaplamasý için doviz tipi seçilmelidir.");
                    if (!ff.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI.HasValue)
                        throw new Exception(msg + " faiz hesaplamasý için faiz baþlangýç tarihi girilmelidir.");
                    if (ff.OZEL_TUTAR3 == 0)
                        throw new Exception(msg + " faiz hesaplamasý için tutar girilmelidir.");
                    if (!ff.OZEL_TUTAR3_KONU_ID.HasValue)
                        throw new Exception(msg + " için bir konu belirtilmelidir.");
                }

                DataRepository.AV001_TI_BIL_FOYProvider.Save(ff);
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmIcraHesaplanmisFaizGiris_Button_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                AV001_TI_BIL_FOY ff = ucFoy1.MyDataSource;

                ff.HESAPLANMIS_FAIZ = 0;
                ff.HESAPLANMIS_FAIZ_DOVIZ_ID = 1;
                ff.HESAPLANMIS_KKDF = 0;
                ff.HESAPLANMIS_KKDF_DOVIZ_ID = 1;
                ff.HESAPLANMIS_BSMV = 0;
                ff.HESAPLANMIS_BSMV_DOVIZ_ID = 1;
                ff.HESAPLANMIS_KDV = 0;
                ff.HESAPLANMIS_KDV_DOVIZ_ID = 1;
                ff.HESAPLANMIS_OIV = 0;
                ff.HESAPLANMIS_OIV_DOVIZ_ID = 1;

                Thread.Sleep(100);
                ff.OZEL_TAZMINAT_FAIZ_ISLESINMI = false;
                ff.OZEL_TAZMINAT_DOVIZ_ID = 1;
                ff.OZEL_TAZMINAT_FAIZ_BASLANGIC_TARIHI = null;
                ff.OZEL_TAZMINAT_FAIZ_ORANI = 0;
                ff.OZEL_TAZMINAT = 0;
                ff.OZEL_TAZMINAT_FAIZ_TIP_ID = 9;

                Thread.Sleep(100);
                ff.OZEL_TUTAR1_FAIZ_ISLESINMI = false;
                ff.OZEL_TUTAR1_DOVIZ_ID = 1;
                ff.OZEL_TUTAR1_FAIZ_BASLANGIC_TARIHI = null;
                ff.OZEL_TUTAR1 = 0;
                ff.OZEL_TUTAR1_FAIZ_ORANI = 0;
                ff.OZEL_TUTAR1_KONU_ID = null;
                ff.OZEL_TUTAR1_FAIZ_TIP_ID = 9;

                Thread.Sleep(100);
                ff.OZEL_TUTAR2_FAIZ_ISLESINMI = false;
                ff.OZEL_TUTAR2_DOVIZ_ID = 1;
                ff.OZEL_TUTAR2_FAIZ_BASLANGIC_TARIHI = null;
                ff.OZEL_TUTAR2 = 0;
                ff.OZEL_TUTAR2_FAIZ_ORANI = 0;
                ff.OZEL_TUTAR2_KONU_ID = null;
                ff.OZEL_TUTAR2_FAIZ_TIP_ID = 9;

                Thread.Sleep(100);
                ff.OZEL_TUTAR3_FAIZ_ISLESINMI = false;
                ff.OZEL_TUTAR3_DOVIZ_ID = 1;
                ff.OZEL_TUTAR3_FAIZ_BASLANGIC_TARIHI = null;
                ff.OZEL_TUTAR3 = 0;
                ff.OZEL_TUTAR3_FAIZ_ORANI = 0;
                ff.OZEL_TUTAR3_KONU_ID = null;
                ff.OZEL_TUTAR3_FAIZ_TIP_ID = 9;

                ff.EXTRA_STR1 = "";

                DataRepository.AV001_TI_BIL_FOYProvider.Save(ff);
                DevExpress.XtraEditors.XtraMessageBox.Show("Silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Sil_Click += frmIcraHesaplanmisFaizGiris_Button_Sil_Click;
            this.Button_Kaydet_Click += frmIcraHesaplanmisFaizGiris_Button_Kaydet_Click;
        }
    }
}