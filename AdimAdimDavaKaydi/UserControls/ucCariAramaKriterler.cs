using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucCariAramaKriterler : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCariAramaKriterler()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> Temizle;
        public event EventHandler<EventArgs> Sorgula;

        //List<AvukatProLib.Arama.AV001_TDI_BIL_CARI> arananCariler = new List<AvukatProLib.Arama.AV001_TDI_BIL_CARI>();

        //aykut hýzlandýrma 01.02.2013
        //[Browsable(false)]
        //public List<AvukatProLib.Arama.AV001_TDI_BIL_CARI> ArananCarilerim { get; set; }
        [Browsable(false)]
        public DataTable ArananCarilerim { get; set; }

        public List<AV001_TDI_BIL_CARI_KIMLIK> cariKimlikLer;

        public void LookUpDoldur()
        {
            lkCariRefCARI.Properties.NullText = "Seç";
            lkCariRefCARI.Enter += delegate { BelgeUtil.Inits.perCariGetir(lkCariRefCARI.Properties); };            
            
            lkBagliOlduguGrupID.Properties.NullText = "Seç";
            lkBagliOlduguGrupID.Enter += delegate { BelgeUtil.Inits.perCariGetir(lkBagliOlduguGrupID.Properties); };
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
                        (con).ResetText();
                        ((DateEdit)con).EditValue = null;
                    }

                    else if (con is SpinEdit)
                    {
                        ((SpinEdit)con).EditValue = null;
                    }
                    else if (con is CheckEdit)
                    {
                        ((CheckEdit)con).EditValue = null;
                    }
                    else if (con is TextEdit)
                    {
                        //con.Text = string.Empty;
                        ((TextEdit)con).EditValue = null;
                    }
                }
            }
            catch 
            {
                XtraMessageBox.Show("Kriterleri Temizlerken Bir Hata Oluþtu...");
            }
        }

        public void cariAramaSonuc()
        {
            if (txtCariAD.EditValue == null &&
                txtCariUNVAN.EditValue == null &&
                lkCariRefCARI.EditValue == null &&
                txtCariKOD.EditValue == null &&
                txtCariMusteriNo.EditValue == null &&                
                lkBagliOlduguGrupID.EditValue == null &&
                chkMuvekkilmi.EditValue == (object)false &&
                chkKarsiTarafmi.EditValue == (object)false &&
                chkFirmami.EditValue == (object)false &&
                chkPersonelmi.EditValue == (object)false &&
                chkAvukatmi.EditValue == (object)false &&
                chkBilirkisimi.EditValue == (object)false &&
                chkAvukatOrtakligimi.EditValue == (object)false &&
                chkAdliBirimmi.EditValue == (object)false &&
                chkAdliPersonelmi.EditValue == (object)false &&
                chkKamuCarimi.EditValue == (object)false &&
                chkHasimsizmi.EditValue == (object)false &&
                chkHarctanMuafmi.EditValue == (object)false &&
                chkKaraListedemi.EditValue == (object)false &&
                chkAkListedemi.EditValue == (object)false)
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        "Hiç Bir Tercihde Bulunmadýnýz , Bütün Þahýslarý getirmek istermisiniz ? " + Environment.NewLine +
                        "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    XtraMessageBox.Show("Lütfen En Az Bir Seçim Yapýnýz...");
                    ArananCarilerim = null;
                }
            }
            else
            {
                #region <CC-20090721>

                // ararken hata alýnýyordu null için newlendi
                ArananCarilerim = new DataTable();

                #endregion<CC-20090721>

                //CARI SP DEN ARAMA
                ArananCarilerim = AvukatProLib.Arama.R_CARI_ARAMASorgu.GetByFiltre(
                    txtCariKOD.EditValue != null ? txtCariKOD.EditValue.ToString() : null,
                    txtCariAD.EditValue != null ? txtCariAD.EditValue.ToString() : null,
                    txtCariUNVAN.EditValue != null ? txtCariUNVAN.EditValue.ToString() : null,
                    (int?)lkCariRefCARI.EditValue,
                    GetCheckState(chkMuvekkilmi),
                    GetCheckState(chkKarsiTarafmi),
                    GetCheckState(chkFirmami),
                    GetCheckState(chkPersonelmi),
                    GetCheckState(chkAvukatmi),
                    GetCheckState(chkKurumAvukatiMi),
                    GetCheckState(chkBilirkisimi),
                    GetCheckState(chkAvukatOrtakligimi),
                    GetCheckState(chkAdliBirimmi),
                    GetCheckState(chkAdliPersonelmi),
                    GetCheckState(chkHarctanMuafmi),
                    GetCheckState(chkKamuCarimi),
                    GetCheckState(chkHasimsizmi),
                    GetCheckState(chkKaraListedemi),
                    GetCheckState(chkAkListedemi),
                    txtCariMusteriNo.EditValue != null ? txtCariMusteriNo.EditValue.ToString() : null,
                    (int?)lkBagliOlduguGrupID.EditValue, AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                // }
            }
        }

        private bool? GetCheckState(CheckEdit ce)
        {
            switch (ce.CheckState)
            {
                case CheckState.Checked:
                    return true;
                case CheckState.Indeterminate:
                    return null;
                case CheckState.Unchecked:
                    return null;
                default:
                    return null;
            }
        }

        private void ucCariAramaKriterler_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            LookUpDoldur();
        }

        private void sBtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(pnlSahisBilgiler.Controls);
            FormlariTemizle(groupControl2.Controls);
            ArananCarilerim = null;
            if (Temizle != null)
                Temizle(this, new EventArgs());
        }

        public bool kimlikmi;

        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            //TAB DEÐÝÞME OLAYI
            if (e != null)
            {
                if (e.ToString() == "xTabCariKimlikBilgiler")
                {
                    kimlikmi = true;
                }
                else
                {
                    kimlikmi = false;
                }
            }
        }

        private void sBtnSorgula_Click(object sender, EventArgs e)
        {
            //SORGULA
            if (Sorgula != null)
                Sorgula(this, new EventArgs());
        }
    }
}