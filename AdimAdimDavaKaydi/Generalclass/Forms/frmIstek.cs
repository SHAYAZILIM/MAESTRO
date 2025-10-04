using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Generalclass.Forms
{
    public partial class frmIstek : XtraForm//: XtraMessageBoxForm
    {
        public frmIstek()
        {
            InitializeComponent();
        }

        public List<AV001_TI_BIL_FOY> Foyler = new List<AvukatProLib2.Entities.AV001_TI_BIL_FOY>();
        public IList list;
        public string resultString = "";

        public bool PostaListesiVarmi
        {
            get { return chkPostaListesi.Checked; }
            set { chkPostaListesi.Checked = value; }
        }

        public LookUpEdit GetYazdirmaSayisi(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rapor)
        {
            LookUpEdit ledit = new LookUpEdit();
            BelgeUtil.Inits.SetLookupByEnum(ledit.Properties, typeof(AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari));
            TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI> ayarlar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARIProvider.GetByYAZDIRILACAK_SABLON_ID(rapor.ID);
            if (ayarlar.FindAll(item => item.CARI_ID == AvukatProLib.Kimlik.CurrentCariId).Count == 0)
            {
                ayarlar = ayarlar.FindAll(item => item.CARI_ID == 1);
            }
            if (ayarlar.Count > 0)
            {
                ledit.Tag = ayarlar[0];
            }

            return ledit;
        }

        public string LoadFromList(IList lst)
        {
            bool resmiMi = false;
            bool muzekkereMi = false;
            bool adiMi = false;
            pictureBoxPTT.Image = (Image)AdimAdimDavaKaydi.Properties.Resources.PTTLargeImage;
            pictureBoxPTT.SizeMode = PictureBoxSizeMode.StretchImage;

            list = lst;
            for (int i = 0; i < lst.Count; i++)
            {
                CheckEdit btn = new CheckEdit();

                if (lst[i] is AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE)
                {
                    btn.Text = ((AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE)lst[i]).BELGE_ADI;
                    btn.Top = i * 30;
                    btn.Left = 10;
                    btn.Tag = lst[i];
                    btn.Checked = true;
                }

                if (lst[i] is AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)
                {
                    LookUpEdit ledit = GetYazdirmaSayisi(((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)lst[i]));

                    btn.Text = ((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)lst[i]).AD;
                    btn.Top = i * 30;
                    btn.Left = 10;
                    btn.Width = 300;

                    //Deðiþme anýnda tagindeki þablonun tagine seçimi yazacaðýz
                    ledit.Tag = lst[i];

                    btn.Tag = lst[i];
                    btn.Checked = true;

                    ledit.Top = i * 30;
                    ledit.Left = 350;
                    ledit.Width = 300;
                    ledit.Visible = false;
                    this.c_pnlButtons.Controls.Add(ledit);
                    ledit.EditValueChanged += ledit_EditValueChanged;
                    int _ID = ((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)lst[i]).ID;
                    if (_ID == 333 || _ID == 439 || _ID == 504 || _ID == 505 || _ID == 507 || _ID == 509 || _ID == 510 || _ID == 520 || _ID == 1204 || _ID == 1219 || _ID == 3213 || _ID == 3214 || _ID == 3215 || _ID == 3216)
                    {
                        resmiMi = true;
                    }
                    else if (_ID == 3211)
                    {
                        muzekkereMi = true;
                    }
                    else if (_ID == 3212)
                    {
                        adiMi = true;
                    }
                }

                btn.CheckedChanged += btn_CheckedChanged;
                this.c_pnlButtons.Controls.Add(btn);
            }
            if (resmiMi)
            {
                gBoxResmi.Visible = true;
            }
            if (muzekkereMi)
            {
                gBoxMuzekkere.Visible = true;
            }
            if (adiMi)
            {
                gBoxAdiPosta.Visible = true;
            }
            this.CancelButton = this.simpleButton1;

            //.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            DialogResult dresult = this.ShowDialog();

            resultString = resultString + "-" + dresult.ToString();

            return resultString;
        }

        private void btn_CheckedChanged(object sender, EventArgs e)
        {
            object o = ((CheckEdit)sender).Tag;
            if (o is AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE)
            {
                AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE belge = (AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE)o;
                list.Remove(belge);
            }

            if (o is AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR)
            {
                AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR rpr =
                    (AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR)o;
                list.Remove(rpr);
            }
            if (o is AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)
            {
                AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rpr =
                    (AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)o;
                list.Remove(rpr);
            }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            resultString = "";
            if (gBoxResmi.Visible == true)
            {
                if (rdButtonResmiTebligat.Checked == true)
                {
                    resultString = "1";
                }
                else if (rdButtonResmiAPS.Checked == true)
                {
                    resultString = "4";
                }
                else if (rdButtonResmiBarkodsuz.Checked == true)
                {
                    resultString = "0";
                }
            }
            if (gBoxMuzekkere.Visible == true)
            {
                if (rdButtonMuzekkereTaahhudlu.Checked == true)
                {
                    if (resultString != "")
                    {
                        resultString = resultString + "," + "2";
                    }
                    else
                    {
                        resultString = resultString + "2";
                    }
                }
                else if (rdButtonMuzekkereBarkodsuz.Checked == true)
                {
                    if (resultString != "")
                    {
                        resultString = resultString + "," + "0";
                    }
                    else
                    {
                        resultString = resultString + "0";
                    }
                }
            }
            if (gBoxAdiPosta.Visible == true)
            {
                if (rdButtonAdiPostaAPS.Checked == true)
                {
                    if (resultString != "")
                    {
                        resultString = resultString + "," + "5";
                    }
                    else
                    {
                        resultString = resultString + "5";
                    }
                }
                else if (rdButtonAdiPostaBarkodsuz.Checked == true)
                {
                    if (resultString != "")
                    {
                        resultString = resultString + "," + "0";
                    }
                    else
                    {
                        resultString = resultString + "0";
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnTarihDegistir_Click(object sender, EventArgs e)
        {
            if (Foyler.Count == 0)
                return;
            if (list[0] is AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)
            {
                if (MessageBox.Show("Dikkat !!!\n\nBu güncelleme uygulamasýný seçtiðiniz takdirde üzerinde bulunduðunuz yada toplu yazýþma editöründen seçtiðiniz tüm icra dosyalarýnýn Takip Tarihi seçtiðiniz tarih ile güncellenecek ve bu dosyalardaki hesaplar da bu tarihe göre deðiþecek ve güncellenecektir.\n\nBu iþleme devam etmek istediðinizden emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    return;

                foreach (AV001_TI_BIL_FOY foy in Foyler)
                {
                    foy.TAKIP_TARIHI = dateTakipTarihi.DateTime;
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(foy);
                    Hesap.Icra hesap = new Hesap.Icra(foy);
                }

                //for (int i = 0; i < list.Count; i++)
                //{
                //    if (list[i] is AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)
                //    {
                //        AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)list[i]).ID);
                //        foy.TAKIP_TARIHI = dateTakipTarihi.DateTime;
                //        DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(foy);
                //        Hesap.Icra hesap = new Hesap.Icra(foy);
                //    }
                //}

                MessageBox.Show("Ýþlem tamamlandý...");
            }
        }

        private void frmIstek_Load(object sender, EventArgs e)
        {
            dateTakipTarihi.DateTime = DateTime.Today;

            if (Foyler.Count == 0)
                groupControl1.Enabled = false;
        }

        private void ledit_EditValueChanged(object sender, EventArgs e)
        {
            var lookup = ((LookUpEdit)sender);
            if (lookup.Tag is AV001_TDIE_BIL_SABLON_RAPOR && lookup.EditValue != null)
            {
                var sablon = lookup.Tag as AV001_TDIE_BIL_SABLON_RAPOR;
                sablon.Tag = (AvpNg.Editor.UserControls.ucSablonYazdirmaSecim.YazdirmaSayilari)lookup.EditValue;
            }
        }

        private void rdButton_CheckedChanged(object sender, EventArgs e)
        {
            resultString = "";
            if (gBoxResmi.Visible == true)
            {
                if (rdButtonResmiTebligat.Checked == true)
                {
                    resultString = "1";
                }
                else if (rdButtonResmiAPS.Checked == true)
                {
                    resultString = "4";
                }
                else if (rdButtonResmiBarkodsuz.Checked == true)
                {
                    resultString = "0";
                }
            }
            if (gBoxMuzekkere.Visible == true)
            {
                if (rdButtonMuzekkereTaahhudlu.Checked == true)
                {
                    if (resultString != "")
                    {
                        resultString = resultString + "," + "2";
                    }
                    else
                    {
                        resultString = resultString + "2";
                    }
                }
                else if (rdButtonMuzekkereBarkodsuz.Checked == true)
                {
                    if (resultString != "")
                    {
                        resultString = resultString + "," + "0";
                    }
                    else
                    {
                        resultString = resultString + "0";
                    }
                }
            }
            if (gBoxAdiPosta.Visible == true)
            {
                if (rdButtonAdiPostaAPS.Checked == true)
                {
                    if (resultString != "")
                    {
                        resultString = resultString + "," + "5";
                    }
                    else
                    {
                        resultString = resultString + "5";
                    }
                }
                else if (rdButtonAdiPostaBarkodsuz.Checked == true)
                {
                    if (resultString != "")
                    {
                        resultString = resultString + "," + "0";
                    }
                    else
                    {
                        resultString = resultString + "0";
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}