using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmYeniKlasor : XtraForm
    {
        public frmYeniKlasor()
        {
            InitializeComponent();
        }

        public DialogResult KayitBasarili = DialogResult.No;

        public AV001_TDIE_BIL_PROJE YeniKlasorGetir()
        {
            //.MdiParent = null;
            //this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            //this.Show();
            AV001_TDIE_BIL_PROJE klasor = new AV001_TDIE_BIL_PROJE();
            DialogResult res = KayitBasarili;
            if (KayitBasarili == DialogResult.OK)
            {
                klasor.ADI = cmbKlasorAdi.Text;

                //klasor.ACIKLAMA = txtKlasorAciklamasi.Text;
                klasor.KOD = txtRafNo.Text.Replace(" ", "");
                klasor.OZEL_KOD1_ID = lkOzelKod1.EditValue as int?;
                klasor.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                klasor.PROJE_DURUM_ID = 1; // Aktif
                klasor.PROJE_TIP_ID = lkProjeTip.EditValue as int?;
                klasor.DURUM_ID = (int)FoyDurum.FAAL;
                klasor.BAGLI_PROJE_ID = null;
                AV001_TDIE_BIL_PROJE_SORUMLU sorumlu = new AV001_TDIE_BIL_PROJE_SORUMLU();
                sorumlu.CARI_ID = (int)lkSorumlu.EditValue;
                sorumlu.YETKILI_MI = false;

                if ((int)lkSorumlu.EditValue != (int)lkIzleyenCari.EditValue)
                {
                    AV001_TDIE_BIL_PROJE_SORUMLU izleyen = new AV001_TDIE_BIL_PROJE_SORUMLU();
                    izleyen.CARI_ID = (int)lkIzleyenCari.EditValue;
                    izleyen.YETKILI_MI = true;
                    klasor.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Add(izleyen);
                }
                klasor.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Add(sorumlu);

                // Okan Hesap Tipi eklendi 23.11.2010
                AV001_TDIE_BIL_PROJE_HESAP projeHesap = new AV001_TDIE_BIL_PROJE_HESAP();
                projeHesap.HESAPLAMA_TIPI = 1;//Klasör kaydýnda Azalan Otomatik getirildi. MB
                klasor.AV001_TDIE_BIL_PROJE_HESAPCollection.Add(projeHesap);
                return klasor;
            }
            else
            {
                return klasor = null;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            KayitBasarili = DialogResult.Cancel;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbKlasorAdi.Text))
            {
                XtraMessageBox.Show("Bir Klasör Adý girmelisiniz");
                return;
            }
            if (String.IsNullOrEmpty(txtRafNo.Text))
            {
                XtraMessageBox.Show("Bir Klasor No girmelisiniz");
                return;
            }
            if (lkOzelKod1.EditValue == null || !(lkOzelKod1.EditValue is int))
            {
                XtraMessageBox.Show("Bir Þube belirtmelisiniz");
                return;
            }
            if (lkSorumlu.EditValue == null || !(lkSorumlu.EditValue is int))
            {
                XtraMessageBox.Show("Bir Sorumlu belirtmelisiniz");
                return;
            }
            if (lkIzleyenCari.EditValue == null || !(lkIzleyenCari.EditValue is int))
            {
                XtraMessageBox.Show("Bir Ýzleyen belirtmelisiniz");
                return;
            }
            KayitBasarili = DialogResult.OK;
            this.Close();
        }

        private void bwCariDoldur_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BelgeUtil.Inits._per_CariGetir == null) BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariler = BelgeUtil.Inits._per_CariGetir;
            foreach (AvukatProLib.Arama.per_AV001_TDI_BIL_CARI cari in cariler)
            {
                if (cari.KARSI_TARAF_MI)
                {
                    bwCariDoldur.ReportProgress(0, cari.AD);
                }
            }
        }

        private void bwCariDoldur_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            cmbKlasorAdi.Properties.Items.Add(e.UserState.ToString());
        }

        private void cmbKlasorAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button != null && e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = cmbKlasorAdi.Text;
                frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          if (frm.KayitBasarili == DialogResult.OK)
                                          {
                                              cmbKlasorAdi.Properties.Items.Add(frm.MyCari.AD);
                                              cmbKlasorAdi.Text = frm.MyCari.AD;
                                          }
                                      };
            }
        }

        private void frmYeniKlasor_Load(object sender, EventArgs e)
        {
            lkSorumlu.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lkSorumlu); };
            lkIzleyenCari.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lkIzleyenCari); };
            lkOzelKod1.Properties.Enter += delegate { BelgeUtil.Inits.ProjeOzelKodGetir(lkOzelKod1.Properties); };
            lkProjeTip.Properties.Enter += delegate { BelgeUtil.Inits.ProjeTipGetir(lkProjeTip.Properties); };
            int? klasorNo =
                DataRepository.Provider.ExecuteScalar(CommandType.Text,
                                                      "Select TOP(1) CONVERT(int,SUBSTRING(REPLACE(KOD,' ',''),6,4))+1 from AV001_TDIE_BIL_PROJE WHERE KOD LIKE '" +
                                                      DateTime.Today.Year + "%' ORDER BY KOD DESC") as int?;
            if (!klasorNo.HasValue)
                klasorNo = 1;
            txtRafNo.Text = String.Format("{0}/{1:0000}", DateTime.Today.Year, klasorNo.Value);
            bwCariDoldur.RunWorkerAsync();
        }

        private void lkOzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
            {
                frmKlasorSubeOzelKod subeekle = new frmKlasorSubeOzelKod();
                subeekle.OzelKod = lkOzelKod1.Text;
                subeekle.FormClosed += subeekle_FormClosed;
                subeekle.Show();
            }
        }

        private void subeekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            BelgeUtil.Inits.ProjeOzelKodGetirRefresh(lkOzelKod1.Properties);
            BelgeUtil.Inits.ProjeOzelKodGetir(lkOzelKod1.Properties);
        }
    }
}