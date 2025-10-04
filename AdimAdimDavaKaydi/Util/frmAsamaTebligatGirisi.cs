using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.Util
{
    public partial class frmAsamaTebligatGirisi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmAsamaTebligatGirisi()
        {
            InitializeComponent();
        }

        private void frmAsamaTebligatGirisi_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.TebligatKonuGetir(lkTebligatKonu);
            BelgeUtil.Inits.AsamaAltKodGetir(lkAltAsama);
            foreach (RadioGroupItem item in radioGroup1.Properties.Items)
            {
                defaultItems.Add(item);
            }
        }

        private RadioGroupItemCollection defaultItems = new RadioGroupItemCollection();

        private void lkTebligatKonu_EditValueChanged(object sender, EventArgs e)
        {
            if (lkTebligatKonu.EditValue is int)
            {
                TList<TDIE_KOD_ASAMA_ILISKI> iliskiler =
                    DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADITEBLIGAT_KONU_ID(
                        "AV001_TDI_BIL_TEBLIGAT_MUHATAP", (int)lkTebligatKonu.EditValue);
                radioGroup1.Properties.Items.Clear();
                foreach (RadioGroupItem itm in defaultItems)
                {
                    radioGroup1.Properties.Items.Add(itm);
                }
                foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskiler)
                {
                    RadioGroupItem itm =
                        radioGroup1.Properties.Items.GetItemByValue(iliski.SUTUN_ADI.Replace("~", "").Trim());
                    if (itm != null)
                    {
                        radioGroup1.Properties.Items.Remove(itm);
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lkTebligatKonu.EditValue == null || lkAltAsama.EditValue == null || radioGroup1.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen tebligat konusu, alt aþamasý ve üretilecek aþama tipini seçiniz!");
                return;
            }
            TDIE_KOD_ASAMA_ILISKI iliski = new TDIE_KOD_ASAMA_ILISKI();
            string radioSecim = String.Format("{0}", radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value);
            iliski.SUTUN_ADI = String.Format("{0}~", radioSecim);
            iliski.ALT_ASAMA_KOD_ID = (int)lkAltAsama.EditValue;
            iliski.TEBLIGAT_KONU_ID = (int)lkTebligatKonu.EditValue;
            iliski.ASAMA_URETSIN_MI = true;
            iliski.TEBLIGAT_URETSIN_MI = false;
            iliski.TABLO_ADI = "AV001_TDI_BIL_TEBLIGAT_MUHATAP";
            iliski.IS_URETSIN_MI = false;
            iliski.KONTROL_KIM = "AVUKATPRO";
            iliski.KONTROL_TARIHI = DateTime.Now;
            iliski.KAYIT_TARIHI = DateTime.Now;
            iliski.SADECE_GUNCELLEMEDE = false;
            iliski.SADECE_YENI_KAYITDA = true;

            if (iliski.SUTUN_ADI.Contains("POSTALANDI_MI"))
            {
                iliski.SUTUN_DEGERI = "True~";
                iliski.ASAMA_TARIH_SUTUNU = "EVRAK_TARIHI";
            }
            else
            {
                iliski.SUTUN_DEGERI = "<DOLU>~";
                iliski.ASAMA_TARIH_SUTUNU = radioSecim;
            }
            switch (radioSecim)
            {
                case "POSTALANDI_MI":
                    iliski.ACIKLAMA = "postalandý.";
                    break;
                case "TEBLIG_TARIH":
                    iliski.ACIKLAMA = "teblið edildi.";
                    break;
                case "BILA_TARIHI":
                    iliski.ACIKLAMA = "bila döndü.";
                    break;
                case "ZABITA_ARASTIRMA_TARIHI":
                    iliski.ACIKLAMA = "için zabýta araþtýrmasý istendi.";
                    break;
                case "OLUMSUZ_SONUC_TARIHI":
                    iliski.ACIKLAMA = "ile ilgili zabýta araþtýrmasý sonucu olumsuz.";
                    break;
                case "TEBLIGATA_ITIRAZ_TARIHI":
                    iliski.ACIKLAMA = "gönderilmiþ muhatap itiraz etmiþtir.";
                    break;
                default:
                    throw new Exception("radioSecim can not recognized");
            }

            try
            {
                DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.Save(iliski);
                lkAltAsama.EditValue = null;
                lkTebligatKonu.EditValue = null;
                radioGroup1.SelectedIndex = -1;
                lkTebligatKonu.EditValue = iliski.TEBLIGAT_KONU_ID.Value;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}