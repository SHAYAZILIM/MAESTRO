using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.GirisEkran;
using AdimAdimDavaKaydi.PaketKontrol;
using AdimAdimDavaKaydi.Raporlama;
using AdimAdimDavaKaydi.UserControls;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AdimAdimDavaKaydi.Util;
using AVPSetLicence;
using AvukatProLib;
using AvukatProLib.Hesap.Views;
using AvukatProLib.PaketYonetimi;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace AdimAdimDavaKaydi.AnaForm
{
    public partial class mdiAvukatPro : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public static mdiAvukatPro MainForm;
        private BackgroundWorker conferenceCallWorker = new BackgroundWorker();
        private BackgroundWorker directCallWorker = new BackgroundWorker();
        private bool hat1Dolumu = false;
        private bool hat2Dolumu = false;
        private int Id;
        private int IsId;
        private bool konferansaEkleHat1i = false;
        private bool konferansaEkleHat2i = false;
        private ServiceController sc;
        private BackgroundWorker startCallWorker = new BackgroundWorker();
        private BackgroundWorker stopCallWorker = new BackgroundWorker();
        private string strId;
        private BackgroundWorker waitCallWorker = new BackgroundWorker();
        private string yapilacakIsler = string.Empty;
        private bool yonlendirHat1i = false;
        private bool yonlendirHat2i = false;

        #endregion Fields

        #region Constructors

        public mdiAvukatPro()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            if (BelgeUtil.Inits.PaketAdi != 1)
            {
            }
            else
                txtYapilacakIsler.Visible = false;

            this.FormClosing += mdiAvukatPro_FormClosing;
        }

        #endregion Constructors

        #region Events

        public event EventHandler OnLoadPacket;

        #endregion Events

        #region Properties

        public string AcilacakDosyaYolu
        {
            get;
            set;
        }

        static bool _IsAcilisSekli = false;
        static Kisayol.AcilisSekli _AcilisSekli;
        public static Kisayol.AcilisSekli AcilisSekli
        {
            get
            {
                if (!_IsAcilisSekli)
                {
                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    string sonuc = "";

                    try
                    {
                        cn.AddParams("@KULLANICI_ID", Kimlikci.Kimlik.Bilgi.ID);
                        sonuc = cn.ExecuteScalar("select isnull(PROGRAM_ACILIS_EKRAN,'') as PROGRAM_ACILIS_EKRAN from dbo.TDIE_BIL_KULLANICI_GENEL_AYAR where KULLANICI_ID=@KULLANICI_ID").ToString();
                    }
                    catch { ;}

                    if (string.IsNullOrEmpty(sonuc))
                        _AcilisSekli = Kisayol.AcilisSekli.Normal;
                    else if (sonuc == "17")
                        _AcilisSekli = Kisayol.AcilisSekli.DavaArama;
                    else if (sonuc == "19")
                        _AcilisSekli = Kisayol.AcilisSekli.DavaTakip;
                    else if (sonuc == "23")
                        _AcilisSekli = Kisayol.AcilisSekli.Editor;
                    else if (sonuc == "31")
                        _AcilisSekli = Kisayol.AcilisSekli.IcraArama;
                    else if (sonuc == "33")
                        _AcilisSekli = Kisayol.AcilisSekli.IcraTakip;
                    else if (sonuc == "78")
                        _AcilisSekli = Kisayol.AcilisSekli.Is;
                    else if (sonuc == "47")
                        _AcilisSekli = Kisayol.AcilisSekli.Klasor;
                    else if (sonuc == "64")
                        _AcilisSekli = Kisayol.AcilisSekli.SorusturmaArama;
                    else if (sonuc == "65")
                        _AcilisSekli = Kisayol.AcilisSekli.SorusturmaTakip;
                    else if (sonuc == "68")
                        _AcilisSekli = Kisayol.AcilisSekli.SozlesmeTakip;
                    else if (sonuc == "70")
                        _AcilisSekli = Kisayol.AcilisSekli.Tebligat;
                    else if (sonuc == "10")
                        _AcilisSekli = Kisayol.AcilisSekli.Belge;
                    else if (sonuc == "4")
                        _AcilisSekli = Kisayol.AcilisSekli.Ajanda;
                    else if (sonuc == "48")
                        _AcilisSekli = Kisayol.AcilisSekli.Kurumsal;
                    else if (sonuc == "76")
                        _AcilisSekli = Kisayol.AcilisSekli.Normal;
                    else if (sonuc == "52")
                        _AcilisSekli = Kisayol.AcilisSekli.Muhasebe;
                    else if (sonuc == "60")
                        _AcilisSekli = Kisayol.AcilisSekli.Proje;
                    else if (sonuc == "27")
                        _AcilisSekli = Kisayol.AcilisSekli.Görüþme;

                    else
                        _AcilisSekli = Kisayol.AcilisSekli.Normal;
                }
                return _AcilisSekli;
            }
            set
            {
                _IsAcilisSekli = true;
                _AcilisSekli = value;
            }
        }

        public Dictionary<AvukatProLib.Extras.FormType, object> Forms
        {
            get;
            set;
        }

        public AvukatProLib.Extras.FormType FormTipi
        {
            get;
            set;
        }

        [Category("Extended Properties")]
        public ToolStripItemCollection UstMenuler
        {
            get { return mdiAvukatPro.MainForm.c_mnUstMenu.Items; }
        }

        #endregion Properties

        #region Methods

        public bool aramaVarmiHat1 = false;
        private bool _IsShow = false;

        public bool IsShow
        {
            get { return _IsShow; }
            private set
            {
                _IsShow = value;
            }
        }

        /// <summary>
        /// Determines if there is an active connection on this computer
        /// </summary>
        /// <returns></returns>
        public static bool HasActiveConnection()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        public static void slue_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            DevExpress.XtraEditors.SearchLookUpEdit slue = (sender as DevExpress.XtraEditors.SearchLookUpEdit);
            for (int rowHandle = 0; rowHandle < slue.Properties.View.RowCount; rowHandle++)
            {
                if ((bool)slue.Properties.View.GetRowCellValue(rowHandle, "isSelected") == true)
                { slue.Properties.NullText = "Seçildi"; return; }
            }
        }

        public void btnAraGiden_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            System.Windows.Forms.ComboBox _cmbBoxTelNoGiden;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;
            RadioButton _rdButtonDahili;
            RadioButton _rdButtonHarici;
            SearchLookUpEdit _SlueArananGiden;
            Button _btnKapatGiden;
            Button _btnYonlendirGiden;
            Button _btnKonferansGiden;

            AVPCallCenter cc = new AVPCallCenter();

            switch (btn.Name)
            {
                case "btnAraGidenHat1":
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;
                    _SlueArananGiden = SlueArananGidenHat1;
                    _btnKapatGiden = btnKapatGidenHat1;
                    _btnKonferansGiden = btnKonferansGidenHat1;
                    _btnYonlendirGiden = btnYonlendirGidenHat1;

                    if (_cmbBoxTelNoGiden.Text != "")
                    {
                        aramaVarmiHat1 = true;
                        if (cc.online())
                        {
                            string aranan = _cmbBoxTelNoGiden.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string arayan = ipAddress.ToString();
                            //if (hat2Dolumu)
                            //{
                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string s = arayan;// cmbBoxTelNoGidenHat2.Text.Split('~')[0];// cc.forVoipXmlCreatorString(cmbBoxTelNoGidenHat2.Text.Split('~')[0], arayan, "", "14");
                                if (cc.sendIpSantralForwardServicetring(aranan, arayan, "12", s) == 1)
                                {
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                    _btnKapatGiden.Visible = true;
                                    hat1Dolumu = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat1Dolumu = false;
                                }
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string s = arayan;// string s = txtBoxTelNoGelenHat2.Text.Split('~')[0];// cc.forVoipXmlCreatorString(txtBoxTelNoGelenHat2.Text.Split('~')[0], arayan, "", "14");
                                if (cc.sendIpSantralForwardServicetring(aranan, arayan, "12", s) == 1)
                                {
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                    _btnKapatGiden.Visible = true;
                                    hat1Dolumu = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat1Dolumu = false;
                                }
                            }
                            else
                            {
                                if (cc.sendIpSantralForwardService(aranan, arayan, "12") == 1)
                                {
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                    _btnKapatGiden.Visible = true;
                                    hat1Dolumu = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat1Dolumu = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aramak için bir numara seçiniz!");
                        _rdButtonHarici.Enabled = true;
                        _rdButtonDahili.Enabled = true;
                    }

                    break;

                case "btnAraGidenHat2":

                    _txtBoxTcNo = txtBoxTcNoGidenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat2;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat2;
                    _rdButtonDahili = rdButtonDahiliHat2;
                    _rdButtonHarici = rdButtonHariciHat2;
                    _SlueArananGiden = SlueArananGidenHat2;
                    _btnKapatGiden = btnKapatGidenHat2;
                    _btnKonferansGiden = btnKonferansGidenHat2;
                    _btnYonlendirGiden = btnYonlendirGidenHat2;

                    if (_cmbBoxTelNoGiden.Text != "")
                    {
                        _rdButtonHarici.Enabled = false;
                        _rdButtonDahili.Enabled = false;
                        _cmbBoxTelNoGiden.Enabled = false;
                        _SlueArananGiden.Enabled = false;
                        if (cc.online())
                        {
                            string aranan = _cmbBoxTelNoGiden.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string arayan = ipAddress.ToString();

                            if (cmbBoxTelNoGidenHat1.Text != "")
                            {
                                string s = arayan;// string s = cmbBoxTelNoGidenHat1.Text.Split('~')[0];// cc.forVoipXmlCreatorString(cmbBoxTelNoGidenHat1.Text.Split('~')[0], arayan, "", "14");
                                if (cc.sendIpSantralForwardServicetring(aranan, arayan, "12", s) == 1)
                                {
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                    _btnKapatGiden.Visible = true;
                                    hat1Dolumu = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat1Dolumu = false;
                                }
                            }
                            else if (txtBoxTelNoGelenHat1.Text != "")
                            {
                                string s = arayan;// string s = txtBoxTelNoGelenHat1.Text.Split('~')[0];// cc.forVoipXmlCreatorString(txtBoxTelNoGelenHat1.Text.Split('~')[0], arayan, "", "14");
                                if (cc.sendIpSantralForwardServicetring(aranan, arayan, "12", s) == 1)
                                {
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                    _btnKapatGiden.Visible = true;
                                    hat1Dolumu = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat1Dolumu = false;
                                }
                            }
                            else
                            {
                                if (cc.sendIpSantralForwardService(aranan, arayan, "12") == 1)
                                {
                                    _btnKapatGiden.Visible = true;
                                    hat2Dolumu = true;
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat2Dolumu = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aramak için bir numara seçiniz!");
                        _rdButtonHarici.Enabled = true;
                        _rdButtonDahili.Enabled = true;
                    }

                    break;

                default:
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;
                    _SlueArananGiden = SlueArananGidenHat1;
                    _btnKapatGiden = btnKapatGidenHat1;
                    _btnKonferansGiden = btnKonferansGidenHat1;
                    _btnYonlendirGiden = btnYonlendirGidenHat1;

                    if (_cmbBoxTelNoGiden.Text != "")
                    {
                        aramaVarmiHat1 = true;
                        _rdButtonHarici.Enabled = false;
                        _rdButtonDahili.Enabled = false;
                        _cmbBoxTelNoGiden.Enabled = false;
                        _SlueArananGiden.Enabled = false;
                        if (cc.online())
                        {
                            string aranan = _cmbBoxTelNoGiden.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string arayan = ipAddress.ToString();

                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string s = arayan;// string s = cmbBoxTelNoGidenHat2.Text.Split('~')[0];// cc.forVoipXmlCreatorString(cmbBoxTelNoGidenHat2.Text.Split('~')[0], arayan, "", "14");
                                if (cc.sendIpSantralForwardServicetring(aranan, arayan, "12", s) == 1)
                                {
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                    _btnKapatGiden.Visible = true;
                                    hat1Dolumu = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat1Dolumu = false;
                                }
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string s = arayan;//  string s = txtBoxTelNoGelenHat2.Text.Split('~')[0];// cc.forVoipXmlCreatorString(txtBoxTelNoGelenHat2.Text.Split('~')[0], arayan, "", "14");
                                if (cc.sendIpSantralForwardServicetring(aranan, arayan, "12", s) == 1)
                                {
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                    _btnKapatGiden.Visible = true;
                                    hat1Dolumu = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat1Dolumu = false;
                                }
                            }
                            else
                            {
                                if (cc.sendIpSantralForwardService(aranan, arayan, "12") == 1)
                                {
                                    _btnKapatGiden.Visible = true;
                                    hat1Dolumu = true;
                                    _btnKonferansGiden.Visible = true;
                                    _btnYonlendirGiden.Visible = true;
                                }
                                else
                                {
                                    _btnKapatGiden.Visible = false;
                                    _btnKonferansGiden.Visible = false;
                                    _btnYonlendirGiden.Visible = false;
                                    hat1Dolumu = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aramak için bir numara seçiniz!");
                        _rdButtonHarici.Enabled = true;
                        _rdButtonDahili.Enabled = true;
                    }
                    break;
            }
        }

        public void btnEskiGorusmeGetir_Click(object sender, EventArgs e)
        {
            if (rdBtnDosyaEskiGorusmeHat1.Checked)
            {
                string foyId = ucGorusmelerHat1.Tag.ToString().Split('~')[0];
                AVPCallCenter cc = new AVPCallCenter();
                cc.EskiGorusmeDoldur(ucGorusmelerHat1, ucGorusmeKayitHat1.ModulTipi, foyId, "");
            }
            else if (rdBtnSahisEskiGorusmeHat1.Checked)
            {
                string cariId = ucGorusmelerHat1.Tag.ToString().Split('~')[1];
                AVPCallCenter cc = new AVPCallCenter();
                cc.EskiGorusmeDoldur(ucGorusmelerHat1, ucGorusmeKayitHat1.ModulTipi, "", cariId);
            }
        }

        public void btnGelenBul_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            DevExpress.XtraEditors.SearchLookUpEdit slue;
            DevExpress.XtraGrid.GridControl gridCntrl;

            switch (btn.Name)
            {
                case "btnGelenBulHat1":

                    slue = SlueArayanGelenHat1;
                    gridCntrl = gridControlGelenHat1;

                    break;

                case "btnGelenBulHat2":

                    slue = SlueArayanGelenHat2;
                    gridCntrl = gridControlGelenHat2;

                    break;

                default:

                    slue = SlueArayanGelenHat1;
                    gridCntrl = gridControlGelenHat1;
                    break;
            }

            int CariId = 0;
            for (int rowHandle = 0; rowHandle < slue.Properties.View.RowCount; rowHandle++)
            {
                if ((bool)slue.Properties.View.GetRowCellValue(rowHandle, "isSelected") == true)
                {
                    CariId = (int)slue.Properties.View.GetRowCellValue(rowHandle, "ID");
                    List<HizliArama> aramaSonuclari = new List<HizliArama>();
                    try
                    {
                        aramaSonuclari = AvukatProLib.Hesap.Views.HizliArama.GetByCariId(CariId, AvukatProLib.Kimlik.SubeKodu);
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                    AVPCallCenter cc = new AVPCallCenter();
                    cc.gridDoldur(gridCntrl, aramaSonuclari, CariId);
                    gridCntrl.Tag = CariId;
                }
            }
        }

        public void btnGidenBul_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            DevExpress.XtraEditors.SearchLookUpEdit slue;
            DevExpress.XtraGrid.GridControl gridCntrl;
            bool gridDoldursunmu = true;

            switch (btn.Name)
            {
                case "btnGidenBulHat1":
                    slue = SlueArananGidenHat1;
                    gridCntrl = gridControlGidenHat1;
                    if (rdButtonDahiliHat1.Checked)
                    {
                        gridDoldursunmu = false;
                    }

                    break;

                case "btnGidenBulHat2":
                    slue = SlueArananGidenHat2;
                    gridCntrl = gridControlGidenHat2;
                    if (rdButtonDahiliHat2.Checked)
                    {
                        gridDoldursunmu = false;
                    }

                    break;

                default:
                    slue = SlueArananGidenHat1;
                    gridCntrl = gridControlGidenHat1;
                    if (rdButtonDahiliHat1.Checked)
                    {
                        gridDoldursunmu = false;
                    }
                    break;
            }
            if (gridDoldursunmu)
            {
                if (slue.Properties.DisplayMember != "")
                {
                    int CariId = 0;
                    for (int rowHandle = 0; rowHandle < slue.Properties.View.RowCount; rowHandle++)
                    {
                        if ((bool)slue.Properties.View.GetRowCellValue(rowHandle, "isSelected") == true)
                        {
                            CariId = (int)slue.Properties.View.GetRowCellValue(rowHandle, "ID");
                            List<HizliArama> aramaSonuclari = new List<HizliArama>();
                            try
                            {
                                aramaSonuclari = AvukatProLib.Hesap.Views.HizliArama.GetByCariId(CariId,
                                                                                                 AvukatProLib.Kimlik.SubeKodu);
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Catch(this, ex);
                            }

                            AVPCallCenter cc = new AVPCallCenter();
                            cc.gridDoldur(gridCntrl, aramaSonuclari, CariId);
                            gridCntrl.Tag = CariId;
                        }
                    }
                }
            }
        }

        public void btnGorusmeKaydet_Click(object sender, EventArgs e)
        {
            AVPCallCenter cc = new AVPCallCenter();
            cc.GorusmeKaydet(ucGorusmeKayitHat1);
            MessageBox.Show("Görüþme Kaydý Baþarýyla Tamamlandý");
            ucGorusmeKayitHat1.MyDataSource = new TList<AV001_TDI_BIL_GORUSME>();
        }

        public void btnKapatGiden_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            System.Windows.Forms.ComboBox _cmbBoxTelNoGiden;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;
            RadioButton _rdButtonDahili;
            RadioButton _rdButtonHarici;
            Button _btnKapatGiden;
            Button _btnYonlendirGiden;
            Button _btnKonferansGiden;
            SearchLookUpEdit _SlueArananGiden;
            string tabPageName;

            switch (btn.Name)
            {
                case "btnKapatGidenHat1":
                    tabPageName = "Hat1";
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;
                    _btnKapatGiden = btnKapatGidenHat1;
                    _btnYonlendirGiden = btnYonlendirGidenHat1;
                    _btnKonferansGiden = btnKonferansGidenHat1;
                    _SlueArananGiden = SlueArananGidenHat1;

                    break;

                case "btnKapatGidenHat2":
                    tabPageName = "Hat2";
                    _txtBoxTcNo = txtBoxTcNoGidenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat2;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat2;
                    _rdButtonDahili = rdButtonDahiliHat2;
                    _rdButtonHarici = rdButtonHariciHat2;
                    _btnKapatGiden = btnKapatGidenHat2;
                    _btnYonlendirGiden = btnYonlendirGidenHat2;
                    _btnKonferansGiden = btnKonferansGidenHat2;
                    _SlueArananGiden = SlueArananGidenHat2;

                    break;

                default:
                    tabPageName = "Hat1";
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;
                    _btnKapatGiden = btnKapatGidenHat1;
                    _btnYonlendirGiden = btnYonlendirGidenHat1;
                    _btnKonferansGiden = btnKonferansGidenHat1;
                    _SlueArananGiden = SlueArananGidenHat1;

                    break;
            }

            AVPCallCenter cc = new AVPCallCenter();

            if (_cmbBoxTelNoGiden.Text != "")
            {
                if (tabPageName == "Hat1")
                {
                    if (hat1Dolumu)
                    {
                        aramaVarmiHat1 = false;
                        _rdButtonHarici.Enabled = true;
                        _rdButtonDahili.Enabled = true;
                        _cmbBoxTelNoGiden.Enabled = true;
                        _SlueArananGiden.Enabled = true;
                        if (cc.online())
                        {
                            string aranan = _cmbBoxTelNoGiden.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string arayan = ipAddress.ToString();
                            cc.sendIpSantralForwardService(aranan, arayan, "10");
                            hat1Dolumu = false;
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }
                }
                else if (tabPageName == "Hat2")
                {
                    if (hat2Dolumu)
                    {
                        aramaVarmiHat1 = false;
                        _rdButtonHarici.Enabled = true;
                        _rdButtonDahili.Enabled = true;
                        _cmbBoxTelNoGiden.Enabled = true;
                        _SlueArananGiden.Enabled = true;
                        if (cc.online())
                        {
                            string aranan = _cmbBoxTelNoGiden.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string arayan = ipAddress.ToString();
                            cc.sendIpSantralForwardService(aranan, arayan, "10");
                            hat2Dolumu = false;
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }
                    else
                    {
                    }
                }
            }
            else
            {
            }
        }

        public void btnKonferansGiden_Click(object sender, EventArgs e)
        {
            if (konferansaEkleHat1i)
            {
                konferansaEkleHat1i = false;
            }
            if (konferansaEkleHat2i)
            {
                konferansaEkleHat2i = false;
            }
            if (yonlendirHat1i)
            {
                yonlendirHat1i = false;
            }
            if (yonlendirHat2i)
            {
                yonlendirHat2i = false;
            }

            Button btn = (sender as Button);
            switch (btn.Name)
            {
                case "btnKonferansGidenHat1":

                    konferansaEkleHat1i = true;
                    MessageBox.Show("Konferansa eklemek istediðiniz hattýn resmine týklayýn");

                    break;

                case "btnKonferansGidenHat2":

                    konferansaEkleHat2i = true;
                    MessageBox.Show("Konferansa eklemek istediðiniz hattýn resmine týklayýn");

                    break;

                default:

                    konferansaEkleHat1i = true;
                    MessageBox.Show("Konferansa eklemek istediðiniz hattýn resmine týklayýn");

                    break;
            }
        }

        public void btnYonlendirGiden_Click(object sender, EventArgs e)
        {
            if (konferansaEkleHat1i)
            {
                konferansaEkleHat1i = false;
            }
            if (konferansaEkleHat2i)
            {
                konferansaEkleHat2i = false;
            }
            if (yonlendirHat1i)
            {
                yonlendirHat1i = false;
            }
            if (yonlendirHat2i)
            {
                yonlendirHat2i = false;
            }

            Button btn = (sender as Button);
            switch (btn.Name)
            {
                case "btnYonlendirGidenHat1":

                    if (hat2Dolumu)
                    {
                        yonlendirHat1i = true;
                        MessageBox.Show("Yonlendirmeyi baðlamak istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Yönlendirmek için açýlacak yeni hattan yönlendirmek istediðiniz numarayý arayýn");
                    }

                    break;

                case "btnYonlendirGidenHat2":

                    if (hat1Dolumu)
                    {
                        yonlendirHat2i = true;
                        MessageBox.Show("Yonlendirmeyi baðlamak istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Yönlendirmek için açýlacak yeni hattan yönlendirmek istediðiniz numarayý arayýn");
                    }

                    break;

                default:

                    if (hat2Dolumu)
                    {
                        yonlendirHat1i = true;
                        MessageBox.Show("Yonlendirmeyi baðlamak istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Yönlendirmek için açýlacak yeni hattan yönlendirmek istediðiniz numarayý arayýn");
                    }

                    break;
            }
        }

        public List<object> GetControlsList(object c, List<object> list)
        {
            if (c is MenuStrip)
            {
                foreach (var cnt in (c as MenuStrip).Items)
                {
                    list.Add(cnt);
                    GetControlsList(cnt, list);
                }
            }
            else if (c is ToolStripMenuItem)
            {
                foreach (var cnt in (c as ToolStripMenuItem).DropDownItems)
                {
                    list.Add(cnt);
                    GetControlsList(cnt, list);
                }
            }
            else if (c is Control)
            {
                foreach (Control cnt in (c as Control).Controls)
                {
                    list.Add(cnt);
                    GetControlsList(cnt, list);
                }
            }
            return list;
        }

        public Form GetForm(AvukatProLib.Extras.FormType frmType)
        {
            if (Forms.ContainsKey(frmType))
            {
                Form form = (Forms[frmType] as Form);

                if (form.IsDisposed)
                {
                    Forms.Remove(frmType);
                }
            }

            #region Form Tipleri

            switch (frmType)
            {
                case AvukatProLib.Extras.FormType.AjandaGirisEkran:
                    break;

                case AvukatProLib.Extras.FormType.BelgeGirisEkran:
                    break;

                case AvukatProLib.Extras.FormType.TumDosyalar:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TumDosyalar))
                        Forms.Add(AvukatProLib.Extras.FormType.TumDosyalar, new rFrmTumDosyalar());
                    break;

                case AvukatProLib.Extras.FormType.ProjeGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.ProjeGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.ProjeGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmProjeGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.YapilcakIslerGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.YapilcakIslerGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.YapilcakIslerGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIslerGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.OdemePlani:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.OdemePlani))
                        Forms.Add(AvukatProLib.Extras.FormType.OdemePlani, new AdimAdimDavaKaydi.UserControls.frmOdemePlani());
                    break;

                case AvukatProLib.Extras.FormType.FaizTipiKT:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.FaizTipiKT))
                        Forms.Add(AvukatProLib.Extras.FormType.FaizTipiKT, new AdimAdimDavaKaydi.Forms.Icra.frmFaizTipiKT());
                    break;

                case AvukatProLib.Extras.FormType.KayitIliski:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.KayitIliski))
                        Forms.Add(AvukatProLib.Extras.FormType.KayitIliski, new rFrmKayitIliski());
                    break;

                case AvukatProLib.Extras.FormType.Muhasebelestirme:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.Muhasebelestirme))
                        Forms.Add(AvukatProLib.Extras.FormType.Muhasebelestirme, new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebelestirme());
                    break;

                case AvukatProLib.Extras.FormType.MuhasebeGiris:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.MuhasebeGiris))
                        Forms.Add(AvukatProLib.Extras.FormType.MuhasebeGiris, new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris());
                    break;

                case AvukatProLib.Extras.FormType.BaglantiAyar:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.BaglantiAyar))
                        Forms.Add(AvukatProLib.Extras.FormType.BaglantiAyar, new AdimAdimDavaKaydi.Util.KullaniciAyar.frmBaglantiAyar());
                    break;

                case AvukatProLib.Extras.FormType.KasaGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.KasaGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.KasaGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmKasaGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.ProjeGenel:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.ProjeGenel))
                        Forms.Add(AvukatProLib.Extras.FormType.ProjeGenel, new frmKlasorYeni());
                    break;

                case AvukatProLib.Extras.FormType.KisayolOlustur:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.KisayolOlustur))
                        Forms.Add(AvukatProLib.Extras.FormType.KisayolOlustur, new frmKisayolOlustur());
                    break;

                case AvukatProLib.Extras.FormType.PoliceHasarGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.PoliceHasarGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.PoliceHasarGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmPoliceHasarGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.LisansAktiveEtme:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.LisansAktiveEtme))
                        Forms.Add(AvukatProLib.Extras.FormType.LisansAktiveEtme, new AvukatProLib.Lisans.frmLisansAktiveEtme());
                    break;

                case AvukatProLib.Extras.FormType.AsamaTebligatGirisi:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.AsamaTebligatGirisi))
                        Forms.Add(AvukatProLib.Extras.FormType.AsamaTebligatGirisi, new frmAsamaTebligatGirisi());
                    break;

                case AvukatProLib.Extras.FormType.SozlesmeTakip:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.SozlesmeTakip))
                        Forms.Add(AvukatProLib.Extras.FormType.SozlesmeTakip, new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip());
                    break;

                case AvukatProLib.Extras.FormType.SorusturmaTakip:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.SorusturmaTakip))
                        Forms.Add(AvukatProLib.Extras.FormType.SorusturmaTakip, new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip());
                    break;

                case AvukatProLib.Extras.FormType.IcraGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IcraGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.IcraGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.IcraTakip:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IcraTakip))
                        Forms.Add(AvukatProLib.Extras.FormType.IcraTakip, new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip());
                    break;

                case AvukatProLib.Extras.FormType.DavaTakip:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.DavaTakip))
                        Forms.Add(AvukatProLib.Extras.FormType.DavaTakip, new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip());
                    break;

                case AvukatProLib.Extras.FormType.DavaGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.DavaGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.DavaGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmDavaGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.DavaGirisHizliEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.DavaGirisHizliEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.DavaGirisHizliEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmDavaGirisHizliEkran());
                    break;

                case AvukatProLib.Extras.FormType.SozlesmeGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.SozlesmeGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.SozlesmeGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmSozlesmeGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.SorusturmaGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.SorusturmaGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.SorusturmaGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmSorusturmaGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.BelgeAramaEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.BelgeAramaEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.BelgeAramaEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmBelgeAramaEkran());
                    break;

                case AvukatProLib.Extras.FormType.TebligatGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TebligatGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.TebligatGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmTebligatGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.MuhasebeGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.MuhasebeGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.MuhasebeGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmMuhasebeGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.KlasorGenel:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.KlasorGenel))
                        Forms.Add(AvukatProLib.Extras.FormType.KlasorGenel, new frmKlasorYeni());
                    break;

                case AvukatProLib.Extras.FormType.KurumsalGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.KurumsalGirisEkran))
                    {
                        Forms.Add(AvukatProLib.Extras.FormType.KurumsalGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran());
                    }
                    break;

                case AvukatProLib.Extras.FormType.YapilcakIsAramaEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.YapilcakIsAramaEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.YapilcakIsAramaEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran());
                    break;

                case AvukatProLib.Extras.FormType.TemsilBilgileriGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TemsilBilgileriGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.TemsilBilgileriGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmTemsilBilgileriGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.CariAramaForm:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.CariAramaForm))
                        Forms.Add(AvukatProLib.Extras.FormType.CariAramaForm, new rFrmCariAramaForm());
                    break;

                case AvukatProLib.Extras.FormType.ProjeAramaForm:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.ProjeAramaForm))
                        Forms.Add(AvukatProLib.Extras.FormType.ProjeAramaForm, new frmKlasorYeni());
                    break;

                case AvukatProLib.Extras.FormType.GorusmeGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.GorusmeGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.GorusmeGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmGorusmeGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.GayrimenkulGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.GayrimenkulGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.GayrimenkulGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmGayrimenkulGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.SatisGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.SatisGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.SatisGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmSatisGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.KiymetliEvrakGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.KiymetliEvrakGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.KiymetliEvrakGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmKiymetliEvrakGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.IhtiyatiTedbirBilgileriGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IhtiyatiTedbirBilgileriGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.IhtiyatiTedbirBilgileriGirisEkran,
                                  new AdimAdimDavaKaydi.GirisEkran.rFrmIhtiyatiTedbirBilgileriGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.TeminatMektupGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TeminatMektupGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.TeminatMektupGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmTeminatMektupGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.ParolaDegistirme:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.ParolaDegistirme))
                        Forms.Add(AvukatProLib.Extras.FormType.ParolaDegistirme, new frmParolaDegistirme());
                    (Forms[frmType] as Form).Show();
                    break;

                case AvukatProLib.Extras.FormType.GenelAyar:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.GenelAyar))
                        Forms.Add(AvukatProLib.Extras.FormType.GenelAyar, new AdimAdimDavaKaydi.Util.KullaniciAyar.frmGenelAyar());
                    break;

                case AvukatProLib.Extras.FormType.DurusmaCelseGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.DurusmaCelseGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.DurusmaCelseGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmDurusmaCelseGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.DurusmaAraKararGirisEkran:

                    //if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.DurusmaAraKararGirisEkran))
                    //    Forms.Add(AvukatProLib.Extras.FormType.DurusmaAraKararGirisEkran, new rFrmDurusmaAraKararGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.TumMallarGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TumMallarGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.TumMallarGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmTumMallarGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.OdemeBilgileriGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.OdemeBilgileriGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.OdemeBilgileriGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmOdemeBilgileriGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.IlamBilgileriGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IlamBilgileriGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.IlamBilgileriGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmIlamBilgileriGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.TaahhutBilgileriGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TaahhutBilgileriGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.TaahhutBilgileriGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmTaahhutBilgileriGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.IhtiyatiHacizGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IhtiyatiHacizGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.IhtiyatiHacizGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmIhtiyatiHacizGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.ItirazBilgileriGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.ItirazBilgileriGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.ItirazBilgileriGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmItirazBilgileriGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.HacizGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.HacizGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.HacizGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmHacizGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.Cetvel:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.Cetvel))
                        Forms.Add(AvukatProLib.Extras.FormType.Cetvel, new AdimAdimDavaKaydi.KodCetvel.Forms.Kod.frmCetvel());
                    break;

                case AvukatProLib.Extras.FormType.IsParamEkle:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IsParamEkle))
                        Forms.Add(AvukatProLib.Extras.FormType.IsParamEkle, new AdimAdimDavaKaydi.Is.Forms.frmIsParamEkle());
                    break;

                case AvukatProLib.Extras.FormType.DegiskenAyar:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.DegiskenAyar))
                        Forms.Add(AvukatProLib.Extras.FormType.DegiskenAyar, new AdimAdimDavaKaydi.Editor.Forms.frmDegiskenAyar());
                    break;

                case AvukatProLib.Extras.FormType.CariTakipForm:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.CariTakipForm))
                        Forms.Add(AvukatProLib.Extras.FormType.CariTakipForm, new AdimAdimDavaKaydi.CariTakipForms.Forms.frmCariTakipForm());
                    break;

                case AvukatProLib.Extras.FormType.SikKullanilanEkle:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.SikKullanilanEkle))
                        Forms.Add(AvukatProLib.Extras.FormType.SikKullanilanEkle, new rfrmSikKullanilanEkle());
                    break;

                case AvukatProLib.Extras.FormType.IsKayitUfak:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IsKayitUfak))
                        Forms.Add(AvukatProLib.Extras.FormType.IsKayitUfak, new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak());
                    break;

                case AvukatProLib.Extras.FormType.Main:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.Main))
                        Forms.Add(AvukatProLib.Extras.FormType.Main, new AVPTransfer.frmMain());
                    break;

                case AvukatProLib.Extras.FormType.Ajanda:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.Ajanda))
                        Forms.Add(AvukatProLib.Extras.FormType.Ajanda, new global::AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda());
                    break;

                case AvukatProLib.Extras.FormType.AboutAvukatpro:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.AboutAvukatpro))
                        Forms.Add(AvukatProLib.Extras.FormType.AboutAvukatpro, new AboutAvukatpro());
                    break;

                case AvukatProLib.Extras.FormType.DavaDosyaKayitForm:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.DavaDosyaKayitForm))
                        Forms.Add(AvukatProLib.Extras.FormType.DavaDosyaKayitForm, new frmDavaDosyaKayitForm());
                    break;

                case AvukatProLib.Extras.FormType.IcraDosyaKayit:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IcraDosyaKayit))
                        Forms.Add(AvukatProLib.Extras.FormType.IcraDosyaKayit, new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit());
                    break;

                case AvukatProLib.Extras.FormType.AdimAdimIcraKaydi:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.AdimAdimIcraKaydi))
                        Forms.Add(AvukatProLib.Extras.FormType.AdimAdimIcraKaydi, new AdimAdimDavaKaydi.Forms.Dava.frmAdimAdimIcraKaydi());
                    break;

                case AvukatProLib.Extras.FormType.SorusturmaGiris:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.SorusturmaGiris))
                        Forms.Add(AvukatProLib.Extras.FormType.SorusturmaGiris, new AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris());
                    break;

                case AvukatProLib.Extras.FormType.BelgeKayitUfak:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.BelgeKayitUfak))
                        Forms.Add(AvukatProLib.Extras.FormType.BelgeKayitUfak, new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak());
                    break;

                case AvukatProLib.Extras.FormType.TebligatKayitEkrani:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TebligatKayitEkrani))
                        Forms.Add(AvukatProLib.Extras.FormType.TebligatKayitEkrani, new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit());
                    break;

                case AvukatProLib.Extras.FormType.SozlesmeKayit:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.SozlesmeKayit))
                        Forms.Add(AvukatProLib.Extras.FormType.SozlesmeKayit, new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit());
                    break;

                case AvukatProLib.Extras.FormType.TemsilKayit:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TemsilKayit))
                        Forms.Add(AvukatProLib.Extras.FormType.TemsilKayit, new frmTemsilKayit());
                    break;

                case AvukatProLib.Extras.FormType.CariGenelGiris:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.CariGenelGiris))
                        Forms.Add(AvukatProLib.Extras.FormType.CariGenelGiris, new frmCariGenelGiris());
                    break;

                case AvukatProLib.Extras.FormType.AracGemiUcakGirisEkran:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.AracGemiUcakGirisEkran))
                        Forms.Add(AvukatProLib.Extras.FormType.AracGemiUcakGirisEkran, new AdimAdimDavaKaydi.GirisEkran.rFrmAracGemiUcakGirisEkran());
                    break;

                case AvukatProLib.Extras.FormType.TespitKaydetForm:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.TespitKaydetForm))
                        Forms.Add(AvukatProLib.Extras.FormType.TespitKaydetForm, new frmTespitKaydetForm());
                    break;

                case AvukatProLib.Extras.FormType.GorusmeKayit:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.GorusmeKayit))
                        Forms.Add(AvukatProLib.Extras.FormType.GorusmeKayit, new rFrmGorusmeKayit());
                    break;

                case AvukatProLib.Extras.FormType.Editor:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.Editor))
                        Forms.Add(AvukatProLib.Extras.FormType.Editor, new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor());
                    break;

                case AvukatProLib.Extras.FormType.AdimAdimEditoreGonder:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.AdimAdimEditoreGonder))
                        Forms.Add(AvukatProLib.Extras.FormType.AdimAdimEditoreGonder, new AdimAdimDavaKaydi.Editor.Forms.frmAdimAdimEditoreGonder());
                    break;

                case AvukatProLib.Extras.FormType.KiymetliEvrakKayitLayout:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.KiymetliEvrakKayitLayout))
                        Forms.Add(AvukatProLib.Extras.FormType.KiymetliEvrakKayitLayout, new AdimAdimDavaKaydi.Forms.LayForm.frmKiymetliEvrakKayitLayout()); break;
                case AvukatProLib.Extras.FormType.KiymetliEvrakKayit:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.KiymetliEvrakKayit))
                        Forms.Add(AvukatProLib.Extras.FormType.KiymetliEvrakKayit, new frmKiymetliEvrakKayit()); break;
                case AvukatProLib.Extras.FormType.AlacakNedenEkle:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.AlacakNedenEkle))
                        Forms.Add(AvukatProLib.Extras.FormType.AlacakNedenEkle, new AdimAdimDavaKaydi.IcraTakipForms.frmAlacakNedenEkle()); break;
                case AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris:
                    if (!Forms.ContainsKey(AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris))
                        Forms.Add(AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris, new frmIcraIlamMahkemesiGiris()); break;

                default:
                    break;
            }

            #endregion Form Tipleri

            return (Forms[frmType] as Form);
        }

        public void Kisayollar(KeyEventArgs keyEvent)
        {
            #region Alt

            if (keyEvent.Alt)
            {
                switch (keyEvent.KeyCode)
                {
                    case Keys.A:
                        AdimAdimDavaKaydi.Forms.Dava.rfrmAraKararKayit araKarar = new AdimAdimDavaKaydi.Forms.Dava.rfrmAraKararKayit();

                        //araKarar.MdiParent = null;
                        araKarar.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        araKarar.IsModul = true;
                        araKarar.Show();
                        break;

                    case Keys.K:
                        AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit kesifInceleme = new AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit();

                        //kesifInceleme.MdiParent = null;
                        kesifInceleme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        kesifInceleme.IsModul = true;
                        kesifInceleme.Show();
                        break;

                    case Keys.J:
                        AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit durusma = new AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit();

                        //durusma.MdiParent = null;
                        durusma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        durusma.IsModul = true;
                        durusma.Show();
                        break;

                    case Keys.I:
                        Is.Forms.frmIsKayitUfak isKayýt = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                        //.MdiParent = null;
                        isKayýt.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        isKayýt.Show();
                        break;

                    case Keys.M:

                        //                        Forms.frmMasrafAvansMini masraf = new AdimAdimDavaKaydi.Forms.frmMasrafAvansMini();
                        IcraTakipForms.frmMasrafAvansKayitHizli masraf = new IcraTakipForms.frmMasrafAvansKayitHizli();

                        //masraf.MdiParent = null;
                        masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkraniDisinda;
                        masraf.Show();
                        break;

                    case Keys.Z:
                        AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit evrakKaydi = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();

                        //evrakKaydi.MdiParent = null;
                        evrakKaydi.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        evrakKaydi.Show();
                        break;

                    case Keys.S:
                        Forms.Icra.frmSatisGirisi satisEkle = new AdimAdimDavaKaydi.Forms.Icra.frmSatisGirisi();

                        //satisEkle.MdiParent = null;
                        satisEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        satisEkle.IsModul = true;
                        satisEkle.Show();
                        break;

                    case Keys.H:
                        Forms.Icra.frmHacizGirisi hacizEkle = new AdimAdimDavaKaydi.Forms.Icra.frmHacizGirisi();

                        //hacizEkle.MdiParent = null;
                        hacizEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        hacizEkle.IsModul = true;
                        hacizEkle.Show();
                        break;

                    case Keys.V:
                        mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.TemsilKayit);
                        break;

                    case Keys.B:

                        //mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.BelgeKayitUfak);
                        AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belgeKayit = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();

                        //belgeKayit.MdiParent = null;
                        belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        belgeKayit.Show();
                        break;

                    case Keys.L:
                        AdimAdimDavaKaydi.Forms.frmYeniKlasor frm = new AdimAdimDavaKaydi.Forms.frmYeniKlasor();
                        AV001_TDIE_BIL_PROJE prj = frm.YeniKlasorGetir();
                        if (prj != null)
                        {
                            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(prj);
                        }
                        break;

                    //case Keys.G:
                    //    rFrmGorusmelerKaydet gorusmeDava = new rFrmGorusmelerKaydet();
                    //    gorusmeDava.IsModul = true;
                    //    gorusmeDava.Show();
                    //    break;

                    case Keys.F:
                        rFrmGorusmeKayit gorusmeIcra = new rFrmGorusmeKayit();
                        //gorusmeIcra.MdiParent = null;
                        gorusmeIcra.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        gorusmeIcra.IsModul = true;
                        gorusmeIcra.Show();
                        break;

                    case Keys.O:
                        IcraTakipForms.rFrmTarafOdeme odeme = new AdimAdimDavaKaydi.IcraTakipForms.rFrmTarafOdeme();

                        //odeme.MdiParent = null;
                        odeme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        odeme.IsModul = true;
                        odeme.Show();
                        break;

                    case Keys.C:
                        mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.CariGenelGiris);
                        break;

                    case Keys.N:
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak not = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                        //not.MdiParent = null;
                        not.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        not.Show();
                        break;

                    case Keys.T:
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak toplanti = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                        //toplanti.MdiParent = null;
                        toplanti.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        toplanti.Show();
                        break;

                    case Keys.W:
                        System.Diagnostics.Process word = new System.Diagnostics.Process();
                        word.StartInfo.FileName = "WINWORD.exe";
                        word.Start();
                        break;

                    case Keys.X:
                        System.Diagnostics.Process excel = new System.Diagnostics.Process();
                        excel.StartInfo.FileName = "EXCEL.exe";
                        excel.Start();
                        break;

                    case Keys.U:
                        System.Diagnostics.Process pro = new System.Diagnostics.Process();
                        pro.StartInfo.FileName = "OUTLOOK.exe";
                        pro.Start();
                        break;

                    case Keys.D:
                        IcraTakipForms.frmMuvekkilOdemeleriLayout muvekkilOdeme =
                            new AdimAdimDavaKaydi.IcraTakipForms.frmMuvekkilOdemeleriLayout();

                        muvekkilOdeme.TakipEkraniDisinda = true;

                        //muvekkilOdeme.MdiParent = null;
                        muvekkilOdeme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        muvekkilOdeme.Show();
                        break;

                    default:
                        break;
                }
            }

            #endregion Alt

            #region Ctrl

            //Ctrl tuþu
            if (keyEvent.Control)
            {
                switch (keyEvent.KeyCode)
                {
                    case Keys.F:
                        Forms.Genel.frmTumDosyalardaArama tumDosyalar =
                            new AdimAdimDavaKaydi.Forms.Genel.frmTumDosyalardaArama();
                        tumDosyalar.Show();
                        break;

                    case Keys.S:
                        AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout loyut = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();

                        loyut.Show();
                        break;

                    case Keys.I:
                        mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.IcraDosyaKayit);
                        break;

                    case Keys.D:
                        mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.DavaDosyaKayitForm);
                        break;

                    case Keys.H:
                        mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.SorusturmaGiris);
                        break;

                    case Keys.J:
                        Ajanda.Forms.MainForms.frmAjanda ajanda =
                            new AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda();

                        //ajanda.MdiParent = null;
                        ajanda.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        ajanda.Show();
                        break;

                    case Keys.R:
                        rfrmSikKullanilanlar sikKullanilanlar = new rfrmSikKullanilanlar();
                        //sikKullanilanlar.MdiParent = null;
                        sikKullanilanlar.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        sikKullanilanlar.Show();
                        break;

                    case Keys.K:
                        rfrmSikKullanilanEkle sikKullanilanEkle = new rfrmSikKullanilanEkle();
                        // sikKullanilanEkle.MdiParent = null;
                        sikKullanilanEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        sikKullanilanEkle.Show();
                        break;

                    case Keys.G:
                        rfrmGunlukIslerim gunlukIslerim = new rfrmGunlukIslerim();
                        gunlukIslerim.StartPosition = FormStartPosition.WindowsDefaultLocation;

                        // gunlukIslerim.MdiParent = null;
                        gunlukIslerim.Show();
                        break;

                    case Keys.E:
                        AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
                        editor.TakipEkranidan = false;
                        editor.MdiParent = this;
                        editor.Show();
                        editor.beklemePaneli.Visible = false;

                        //OpenForm(AvukatProLib.Extras.FormType.Editor);
                        break;

                    case Keys.N:
                        ekranÖzelleþtirmeToolStripMenuItem_Click(null, null);

                        //OpenForm(AvukatProLib.Extras.FormType.Editor);
                        break;

                    default:
                        break;
                }
            }

            #endregion Ctrl

            #region Ctrl+Shift

            //Ctrl+Shift
            if (keyEvent.Control && keyEvent.Shift)
            {
                switch (keyEvent.KeyCode)
                {
                    case Keys.K:
                        GirisEkran.rFrmYapilcakIsAramaEkran durusma =
                            new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();

                        //durusma.MdiParent = null;
                        durusma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        durusma.HizliErisimdenMi = true;
                        durusma.DurusmaMi = true;
                        durusma.Show();
                        break;

                    case Keys.A:
                        GirisEkran.rFrmYapilcakIsAramaEkran araKarar =
                            new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();

                        //araKarar.MdiParent = null;
                        araKarar.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        araKarar.HizliErisimdenMi = true;
                        araKarar.AraKararMi = true;
                        araKarar.Show();
                        break;

                    case Keys.T:
                        GirisEkran.rFrmYapilcakIsAramaEkran toplanti =
                            new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();

                        //toplanti.MdiParent = null;
                        toplanti.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        toplanti.HizliErisimdenMi = true;
                        toplanti.ToplantiMi = true;
                        toplanti.Show();
                        break;

                    case Keys.N:
                        GirisEkran.rFrmYapilcakIsAramaEkran notlar =
                            new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();

                        //notlar.MdiParent = null;
                        notlar.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        notlar.HizliErisimdenMi = true;
                        notlar.NotMu = true;
                        notlar.Show();
                        break;

                    case Keys.G:
                        GirisEkran.rFrmYapilcakIsAramaEkran gunlukIs =
                            new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();

                        //gunlukIs.MdiParent = null;
                        gunlukIs.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        gunlukIs.HizliErisimdenMi = true;
                        gunlukIs.GunlukIsMi = true;
                        gunlukIs.Show();
                        break;

                    default:
                        break;
                }
            }

            #endregion Ctrl+Shift
        }

        public void LoadComplete()
        {
            switch (AcilisSekli)
            {
                case Kisayol.AcilisSekli.IcraTakip:
                    AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frm = (AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip)GetForm(AvukatProLib.Extras.FormType.IcraTakip);
                    TList<AV001_TI_BIL_FOY> Ifoy = new TList<AV001_TI_BIL_FOY>();
                    Ifoy.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(Id));
                    frm.Show(Ifoy);
                    frm.FormClosing += frm_FormClosing;
                    break;

                case Kisayol.AcilisSekli.DavaTakip:
                    AdimAdimDavaKaydi.DavaTakip.frmDavaTakip dfrm = (AdimAdimDavaKaydi.DavaTakip.frmDavaTakip)GetForm(AvukatProLib.Extras.FormType.DavaTakip);
                    TList<AV001_TD_BIL_FOY> dfoy = new TList<AV001_TD_BIL_FOY>();
                    dfoy.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(Id));
                    dfrm.Show(dfoy);
                    dfrm.FormClosing += frm_FormClosing;
                    break;

                case Kisayol.AcilisSekli.SorusturmaTakip:
                    AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip sfrm = (AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip)GetForm(AvukatProLib.Extras.FormType.SorusturmaTakip);
                    TList<AV001_TD_BIL_HAZIRLIK> Hfoy = new TList<AV001_TD_BIL_HAZIRLIK>();
                    Hfoy.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(Id));
                    sfrm.Show(Hfoy);
                    sfrm.FormClosing += frm_FormClosing;
                    break;

                //case Kisayol.AcilisSekli.Normal:
                //    AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran frmKurum = new AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran(){ WindowState = FormWindowState.Maximized };
                //    frmKurum.StartPosition = FormStartPosition.CenterScreen;
                //    frmKurum.Show();

                //GetForm(FormTipi).Show();
                //break;

                case Kisayol.AcilisSekli.Klasor:
                    frmKlasorYeni frmKlasor = (frmKlasorYeni)GetForm(AvukatProLib.Extras.FormType.KlasorGenel);
                    frmKlasor.WindowState = FormWindowState.Maximized;
                    frmKlasor.Show();
                    break;

                case Kisayol.AcilisSekli.IcraArama:
                    AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran frmIcraGiris = (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran)GetForm(AvukatProLib.Extras.FormType.IcraGirisEkran);
                    frmIcraGiris.WindowState = FormWindowState.Maximized;
                    frmIcraGiris.Show();
                    break;

                case Kisayol.AcilisSekli.DavaArama:
                    AdimAdimDavaKaydi.GirisEkran.rFrmDavaGirisEkran frmDavaGiris = (AdimAdimDavaKaydi.GirisEkran.rFrmDavaGirisEkran)GetForm(AvukatProLib.Extras.FormType.DavaGirisEkran);
                    frmDavaGiris.WindowState = FormWindowState.Maximized;
                    frmDavaGiris.Show();
                    break;

                case Kisayol.AcilisSekli.SorusturmaArama:
                    AdimAdimDavaKaydi.GirisEkran.rFrmSorusturmaGirisEkran frmSorusturmaGiris =
                        (AdimAdimDavaKaydi.GirisEkran.rFrmSorusturmaGirisEkran)GetForm(AvukatProLib.Extras.FormType.SorusturmaGirisEkran);
                    frmSorusturmaGiris.WindowState = FormWindowState.Maximized;
                    frmSorusturmaGiris.Show();
                    break;

                case Kisayol.AcilisSekli.Tebligat:
                    AdimAdimDavaKaydi.GirisEkran.rFrmTebligatGirisEkran rFrmTebligatGirisEkran =
                        (AdimAdimDavaKaydi.GirisEkran.rFrmTebligatGirisEkran)GetForm(AvukatProLib.Extras.FormType.TebligatGirisEkran);
                    rFrmTebligatGirisEkran.WindowState = FormWindowState.Maximized;
                    rFrmTebligatGirisEkran.Show();
                    break;

                case Kisayol.AcilisSekli.SozlesmeTakip:
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip sofrm = (AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip)GetForm(AvukatProLib.Extras.FormType.SozlesmeTakip);
                    sofrm.Show(Id);
                    sofrm.FormClosing += frm_FormClosing;
                    break;

                case Kisayol.AcilisSekli.Is:
                    //rFrmYapilcakIsAramaEkran frmyapis = new rFrmYapilcakIsAramaEkran() { WindowState = FormWindowState.Maximized };
                    //frmyapis.Show();

                    AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                        new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak() { WindowState = FormWindowState.Maximized };

                    AV001_TDI_BIL_IS acilacakis = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(int.Parse((AcilacakDosyaYolu)));
                    frmisKayit.Record = acilacakis;

                    //frmisKayit.MdiParent = null;
                    frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmisKayit.Show();

                    break;

                case Kisayol.AcilisSekli.Ajanda:
                    AdimAdimDavaKaydi.Ajanda.Forms.MainForms.frmAjanda frmaj = new Ajanda.Forms.MainForms.frmAjanda() { WindowState = FormWindowState.Maximized };
                    frmaj.Show();
                    break;

                case Kisayol.AcilisSekli.Muhasebe:
                    AdimAdimDavaKaydi.GirisEkran.rFrmMuhasebeGirisEkran frmuh = new AdimAdimDavaKaydi.GirisEkran.rFrmMuhasebeGirisEkran() { WindowState = FormWindowState.Maximized };
                    frmuh.Show();
                    break;

                case Kisayol.AcilisSekli.Editor:
                    AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor frmed = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor() { WindowState = FormWindowState.Maximized };
                    frmed.Show();
                    frmed.beklemePaneli.Visible = false;
                    break;

                case Kisayol.AcilisSekli.Belge:
                    AdimAdimDavaKaydi.GirisEkran.rFrmBelgeAramaEkran frmbe = new AdimAdimDavaKaydi.GirisEkran.rFrmBelgeAramaEkran() { WindowState = FormWindowState.Maximized };
                    frmbe.Show();
                    break;

                case Kisayol.AcilisSekli.Proje:
                    AdimAdimDavaKaydi.GirisEkran.rFrmKlasorAramaEkran frmpr = new GirisEkran.rFrmKlasorAramaEkran() { WindowState = FormWindowState.Maximized };
                    frmpr.Show();
                    break;

                case Kisayol.AcilisSekli.Görüþme:
                    AdimAdimDavaKaydi.GirisEkran.rFrmGorusmeGirisEkran frmgr = new GirisEkran.rFrmGorusmeGirisEkran() { WindowState = FormWindowState.Maximized };
                    frmgr.Show();
                    break;

                default:
                    AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran frmKurumd = new AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran() { StartPosition = FormStartPosition.CenterScreen };
                    frmKurumd.Show();
                    break;
            }
        }

        public void OpenForm(AvukatProLib.Extras.FormType frmType)
        {
            try
            {
                Form frm = GetForm(frmType);
                if (!frm.IsDisposed)
                    frm.Show();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
            }
        }

        public void SlueArayanGelen_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SearchLookUpEdit slue = (sender as DevExpress.XtraEditors.SearchLookUpEdit);
            TextBox _txtTelNoGelen;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;

            switch (slue.Name)
            {
                case "SlueArayanGelenHat1":
                    _txtBoxTcNo = txtBoxTcNoGelenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat1;
                    _txtTelNoGelen = txtBoxTelNoGelenHat1;
                    break;

                case "SlueArayanGelenHat2":
                    _txtBoxTcNo = txtBoxTcNoGelenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat2;
                    _txtTelNoGelen = txtBoxTelNoGelenHat2;
                    break;

                default:
                    _txtBoxTcNo = txtBoxTcNoGelenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat1;
                    _txtTelNoGelen = txtBoxTelNoGelenHat1;
                    break;
            }
            _txtBoxTcNo.Text = "";
            _txtMusteriNo.Text = "";

            for (int rowHandle = 0; rowHandle < slue.Properties.View.RowCount; rowHandle++)
            {
                if ((bool)slue.Properties.View.GetRowCellValue(rowHandle, "isSelected") == true)
                {
                    _txtBoxTcNo.Text = slue.Properties.View.GetRowCellValue(rowHandle, "TC KÝMLÝK NO").ToString();
                    _txtMusteriNo.Text = slue.Properties.View.GetRowCellValue(rowHandle, "MÜÞTERÝ NO").ToString();
                    slue.Tag = Convert.ToInt32(slue.Properties.View.GetRowCellValue(rowHandle, "ID").ToString());
                }
            }
        }

        public void SlueArayanGelen_Enter(object sender, EventArgs e)
        {
            if (((SearchLookUpEdit)sender).Name == "SlueArayanGelenHat1")
            {
                if (txtBoxTelNoGelenHat1.Text != "")
                {
                    SlueArayanGelen_Enter_gon(SlueArayanGelenHat1, txtBoxTelNoGelenHat1.Text, e);
                }
            }
            else if (((SearchLookUpEdit)sender).Name == "SlueArayanGelenHat2")
            {
                if (txtBoxTelNoGelenHat2.Text != "")
                {
                    SlueArayanGelen_Enter_gon(SlueArayanGelenHat2, txtBoxTelNoGelenHat2.Text, e);
                }
            }
        }

        public void view1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView grdView = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            if ((bool)grdView.GetRowCellValue(e.RowHandle, "isSelected") == false)
            {
                grdView.SetRowCellValue(e.RowHandle, "isSelected", true);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (AcilisSekli == Kisayol.AcilisSekli.DavaTakip || AcilisSekli == Kisayol.AcilisSekli.IcraTakip || AcilisSekli == Kisayol.AcilisSekli.SozlesmeTakip || AcilisSekli == Kisayol.AcilisSekli.SorusturmaTakip)
            {
                try
                {
                    StreamReader streader = File.OpenText(AcilacakDosyaYolu);
                    if (!streader.EndOfStream)
                    {
                        strId = streader.ReadLine();
                        Id = Convert.ToInt32(Kisayol.Decrypt(strId));
                    }
                    if (!streader.EndOfStream)
                        IsId = Convert.ToInt32(Kisayol.Decrypt(streader.ReadLine()));
                }
                catch { }
            }

            //if (AcilisSekli != Kisayol.AcilisSekli.Normal && AcilisSekli != Kisayol.AcilisSekli.GenelGiriþ)
            //{
            //    AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran frmKurumd2 = new AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran() { WindowState = FormWindowState.Maximized };
            //    frmKurumd2.Show();
            //}
            Thread th = new Thread(new ThreadStart(delegate
            {
                this.GetPaketForm();

                if (!DesignMode)
                {
                    this.IsShow = true;
                    if (this.OnLoadPacket != null)
                        this.OnLoadPacket(this, null);
                }
            }));
            th.Start();
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool
            InternetGetConnectedState(out int Description, int ReservedValue);

        private static string SetNullText(object sender)
        {
            if (sender is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
                return "BOÞ";
            else
                return "Seçiniz";
        }

        private void adEsasNoDosyaNoyaGoreBulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Genel.frmTumDosyalardaArama tumDosyalar = new AdimAdimDavaKaydi.Forms.Genel.frmTumDosyalardaArama();
            tumDosyalar.Show();
        }

        private void aktarýlanMasraflarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmAktarilanMasraflar frm = new AdimAdimDavaKaydi.Entegrasyon.frmAktarilanMasraflar();
            frm.Show();
        }

        private void aktarýlanTahsilatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmAktarilanTahsilatlar frm = new AdimAdimDavaKaydi.Entegrasyon.frmAktarilanTahsilatlar();
            frm.Show();
        }

        private void anaEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool AcikMi = false;
            foreach (string item in this.GetChildNames())
            {
                if (item == "rFrmKurumsalGirisEkran")
                    AcikMi = true;
            }

            if (!AcikMi)
            {
                AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran frmKurumd = new AdimAdimDavaKaydi.GirisEkran.rFrmKurumsalGirisEkran() { StartPosition = FormStartPosition.CenterScreen };
                frmKurumd.Show();
            }
        }

        private void aracBilgisindenBulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.AracGemiUcakGirisEkran);
        }

        private void araKararlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmYapilcakIsAramaEkran isArama = new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();
            isArama.HizliErisimdenMi = true;
            isArama.AraKararMi = true;
            isArama.Show();
        }

        private void araKararToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rfrmAraKararKayit araKarar = new AdimAdimDavaKaydi.Forms.Dava.rfrmAraKararKayit();
            araKarar.StartPosition = FormStartPosition.WindowsDefaultLocation;
            araKarar.IsModul = true;
            araKarar.Show();
        }

        private void araKararToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //AYKUT
            frmAraKararExpres AraKararEkspres = new frmAraKararExpres();
            AraKararEkspres.Show();
        }

        private void asistanýÇalýþtýrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string raporEXE = Application.StartupPath + "\\Asistan.exe";
                if (File.Exists(raporEXE))
                {
                    System.Diagnostics.Process.Start(raporEXE, AvukatProLib.Kimlikci.Kimlik.KullaniciAdi);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Asistan Modülüne Eriþim Hakkýnýz Bulunmamaktadýr...");
                }
            }
            catch
            {
            }
        }

        private void bakýmAyarlarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string bakimEXE = Application.StartupPath + "\\AvukatProLib.Bakim.exe";
                if (File.Exists(bakimEXE))
                {
                    System.Diagnostics.Process.Start(bakimEXE);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bakým Ayarlarýna Eriþim Hakkýnýz Bulunmamaktadýr...");
                }
            }
            catch
            {
            }
        }

        private void basamaklaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void belgeEvrakSözleþmeÝcraDavaSoruþturmaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.rFrmTumDosyalar tumDosyalar = new AdimAdimDavaKaydi.Forms.rFrmTumDosyalar();
            tumDosyalar.Show();
        }

        private void belgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.BelgeKayitUfak);
        }

        private void bireyselKredilerTakipliAlacaklarÝçinRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvukatProRaporlar.Forms.frmDonemselRaporSihirbaz.ShowWizard(3);
        }

        private void boçlununTümMallarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.TumMallarGirisEkran);
        }

        private void borcluOdemesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.IcraTakipForms.rFrmTarafOdeme frm = new AdimAdimDavaKaydi.IcraTakipForms.rFrmTarafOdeme();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.IsModul = true;
            frm.Show();
        }

        private void borçluÖdemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.OdemeBilgileriGirisEkran);
        }

        private void btnCevaplaGelen_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            TextBox _txtTelNoGelen;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;
            SearchLookUpEdit _SlueArayanGelen;
            Button _btnKapatGelen;
            Button _btnYonlendirGelen;
            Button _btnKonferansGelen;
            Button _btnGeriCevirGelen;

            AVPCallCenter cc = new AVPCallCenter();

            switch (btn.Name)
            {
                case "btnCevaplaGelenHat1":
                    _btnGeriCevirGelen = btnGeriCevirGelenHat1;
                    _txtBoxTcNo = txtBoxTcNoGelenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat1;
                    _txtTelNoGelen = txtBoxTelNoGelenHat1;
                    _SlueArayanGelen = SlueArayanGelenHat1;
                    _btnKapatGelen = btnKapatGelenHat1;
                    _btnKonferansGelen = btnKonferansGelenHat1;
                    _btnYonlendirGelen = btnYonlendirGelenHat1;

                    if (_txtTelNoGelen.Text != "")
                    {
                        aramaVarmiHat1 = true;
                        _txtTelNoGelen.Enabled = false;
                        _SlueArayanGelen.Enabled = false;
                        if (cc.online())
                        {
                            string aranan = _txtTelNoGelen.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string arayan = ipAddress.ToString();
                            if (hat2Dolumu)
                            {
                                if (cmbBoxTelNoGidenHat2.Text != "")
                                {
                                    if (cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat2.Text.Split('~')[0], arayan, "14") == 1)
                                    {
                                    }
                                    else
                                    {
                                    }
                                }
                                else if (txtBoxTelNoGelenHat2.Text != "")
                                {
                                    if (cc.sendIpSantralForwardService(txtBoxTelNoGelenHat2.Text.Split('~')[0], arayan, "14") == 1)
                                    {
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                            if (cc.sendIpSantralForwardService(aranan, arayan, "12") == 1)
                            {
                                _btnKapatGelen.Visible = true;
                                hat1Dolumu = true;
                                _btnGeriCevirGelen.Visible = false;
                                _btnKonferansGelen.Visible = true;
                                _btnYonlendirGelen.Visible = true;
                            }
                            else
                            {
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat1Dolumu = false;
                                _btnGeriCevirGelen.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aramak için bir numara seçiniz!");
                    }

                    break;

                case "btnCevaplaGelenHat2":

                    _btnGeriCevirGelen = btnGeriCevirGelenHat2;
                    _txtBoxTcNo = txtBoxTcNoGidenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat2;
                    _txtTelNoGelen = txtBoxTelNoGelenHat2;
                    _SlueArayanGelen = SlueArananGidenHat2;
                    _btnKapatGelen = btnKapatGidenHat2;
                    _btnKonferansGelen = btnKonferansGidenHat2;
                    _btnYonlendirGelen = btnYonlendirGidenHat2;

                    if (_txtTelNoGelen.Text != "")
                    {
                        _txtTelNoGelen.Enabled = false;
                        _SlueArayanGelen.Enabled = false;
                        if (cc.online())
                        {
                            string aranan = _txtTelNoGelen.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string arayan = ipAddress.ToString();
                            if (hat1Dolumu)
                            {
                                if (cmbBoxTelNoGidenHat1.Text != "")
                                {
                                    if (cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat1.Text.Split('~')[0], arayan, "14") == 1)
                                    {
                                    }
                                    else
                                    {
                                    }
                                }
                                else if (txtBoxTelNoGelenHat1.Text != "")
                                {
                                    if (cc.sendIpSantralForwardService(txtBoxTelNoGelenHat1.Text.Split('~')[0], arayan, "14") == 1)
                                    {
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                            if (cc.sendIpSantralForwardService(aranan, arayan, "12") == 1)
                            {
                                _btnKapatGelen.Visible = true;
                                hat2Dolumu = true;
                                _btnGeriCevirGelen.Visible = false;
                                _btnKonferansGelen.Visible = true;
                                _btnYonlendirGelen.Visible = true;
                            }
                            else
                            {
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat2Dolumu = false;
                                _btnGeriCevirGelen.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aramak için bir numara seçiniz!");
                    }
                    break;

                default:
                    _btnGeriCevirGelen = btnGeriCevirGelenHat1;
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _txtTelNoGelen = txtBoxTelNoGelenHat1;
                    _SlueArayanGelen = SlueArananGidenHat1;
                    _btnKapatGelen = btnKapatGidenHat1;
                    _btnKonferansGelen = btnKonferansGidenHat1;
                    _btnYonlendirGelen = btnYonlendirGidenHat1;
                    if (_txtTelNoGelen.Text != "")
                    {
                        aramaVarmiHat1 = true;
                        _txtTelNoGelen.Enabled = false;
                        _SlueArayanGelen.Enabled = false;
                        if (cc.online())
                        {
                            string aranan = _txtTelNoGelen.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string arayan = ipAddress.ToString();
                            if (hat2Dolumu)
                            {
                                if (cmbBoxTelNoGidenHat2.Text != "")
                                {
                                    if (cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat2.Text.Split('~')[0], arayan, "14") == 1)
                                    {
                                    }
                                    else
                                    {
                                    }
                                }
                                else if (txtBoxTelNoGelenHat2.Text != "")
                                {
                                    if (cc.sendIpSantralForwardService(txtBoxTelNoGelenHat2.Text.Split('~')[0], arayan, "14") == 1)
                                    {
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                            if (cc.sendIpSantralForwardService(aranan, arayan, "12") == 1)
                            {
                                _btnKapatGelen.Visible = true;
                                hat1Dolumu = true;
                                _btnGeriCevirGelen.Visible = false;
                                _btnKonferansGelen.Visible = true;
                                _btnYonlendirGelen.Visible = true;
                            }
                            else
                            {
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat1Dolumu = false;
                                _btnGeriCevirGelen.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aramak için bir numara seçiniz!");
                    }
                    break;
            }
        }

        private void btnGeriCevirGelen_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            TextBox _txtTelNoGelen;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;
            SearchLookUpEdit _SlueArayanGelen;
            Button _btnKapatGelen;
            Button _btnYonlendirGelen;
            Button _btnKonferansGelen;

            AVPCallCenter cc = new AVPCallCenter();

            switch (btn.Name)
            {
                case "btnGeriCevirGelenHat1":
                    _txtBoxTcNo = txtBoxTcNoGelenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat1;
                    _txtTelNoGelen = txtBoxTelNoGelenHat1;
                    _SlueArayanGelen = SlueArayanGelenHat1;
                    _btnKapatGelen = btnKapatGelenHat1;
                    _btnKonferansGelen = btnKonferansGelenHat1;
                    _btnYonlendirGelen = btnYonlendirGelenHat1;

                    if (_txtTelNoGelen.Text != "")
                    {
                        aramaVarmiHat1 = true;
                        _txtTelNoGelen.Enabled = false;
                        _SlueArayanGelen.Enabled = false;
                        if (cc.online())
                        {
                            string arayan = _txtTelNoGelen.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string aranan = ipAddress.ToString();

                            if (cc.sendIpSantralForwardService(aranan, arayan, "101") == 1)
                            {
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat1Dolumu = false;
                            }
                            else
                            {
                                MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat1Dolumu = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }

                    break;

                case "btnGeriCevirGelenHat2":

                    _txtBoxTcNo = txtBoxTcNoGelenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat2;
                    _txtTelNoGelen = txtBoxTelNoGelenHat2;
                    _SlueArayanGelen = SlueArayanGelenHat2;
                    _btnKapatGelen = btnKapatGelenHat2;
                    _btnKonferansGelen = btnKonferansGelenHat2;
                    _btnYonlendirGelen = btnYonlendirGelenHat2;

                    if (_txtTelNoGelen.Text != "")
                    {
                        _txtTelNoGelen.Enabled = false;
                        _SlueArayanGelen.Enabled = false;
                        if (cc.online())
                        {
                            string arayan = _txtTelNoGelen.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string aranan = ipAddress.ToString();

                            if (cc.sendIpSantralForwardService(aranan, arayan, "101") == 1)
                            {
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat2Dolumu = false;
                            }
                            else
                            {
                                MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat2Dolumu = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }

                    break;

                default:
                    _txtBoxTcNo = txtBoxTcNoGelenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat1;
                    _txtTelNoGelen = txtBoxTelNoGelenHat1;
                    _SlueArayanGelen = SlueArayanGelenHat1;
                    _btnKapatGelen = btnKapatGelenHat1;
                    _btnKonferansGelen = btnKonferansGelenHat1;
                    _btnYonlendirGelen = btnYonlendirGelenHat1;

                    if (_txtTelNoGelen.Text != "")
                    {
                        aramaVarmiHat1 = true;
                        _txtTelNoGelen.Enabled = false;
                        _SlueArayanGelen.Enabled = false;
                        if (cc.online())
                        {
                            string arayan = _txtTelNoGelen.Text.Split('~')[0];
                            string strHostName = System.Net.Dns.GetHostName();
                            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            string aranan = ipAddress.ToString();

                            if (cc.sendIpSantralForwardService(aranan, arayan, "101") == 1)
                            {
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat1Dolumu = false;
                            }
                            else
                            {
                                MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                                _btnKapatGelen.Visible = false;
                                _btnKonferansGelen.Visible = false;
                                _btnYonlendirGelen.Visible = false;
                                hat1Dolumu = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                        }
                    }

                    break;
            }
        }

        private void btnKapatGelen_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            TextBox _txtTelNoGelen;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;
            Button _btnKapatGelen;
            Button _btnYonlendirGelen;
            Button _btnKonferansGelen;
            SearchLookUpEdit _SlueArananGelen;
            string tabPage;

            switch (btn.Name)
            {
                case "btnKapatGelenHat1":
                    tabPage = "Hat1";
                    _txtBoxTcNo = txtBoxTcNoGelenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat1;
                    _txtTelNoGelen = txtBoxTelNoGelenHat1;
                    _btnKapatGelen = btnKapatGelenHat1;
                    _btnYonlendirGelen = btnYonlendirGelenHat1;
                    _btnKonferansGelen = btnKonferansGelenHat1;
                    _SlueArananGelen = SlueArayanGelenHat1;
                    hat1Dolumu = false;

                    break;

                case "btnKapatGelenHat2":
                    tabPage = "Hat2";
                    _txtBoxTcNo = txtBoxTcNoGelenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat2;
                    _txtTelNoGelen = txtBoxTelNoGelenHat2;
                    _btnKapatGelen = btnKapatGelenHat2;
                    _btnYonlendirGelen = btnYonlendirGelenHat2;
                    _btnKonferansGelen = btnKonferansGelenHat2;
                    _SlueArananGelen = SlueArayanGelenHat2;
                    hat2Dolumu = false;
                    break;

                default:
                    tabPage = "Hat1";
                    _txtBoxTcNo = txtBoxTcNoGelenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGelenHat1;
                    _txtTelNoGelen = txtBoxTelNoGelenHat1;
                    _btnKapatGelen = btnKapatGelenHat1;
                    _btnYonlendirGelen = btnYonlendirGelenHat1;
                    _btnKonferansGelen = btnKonferansGelenHat1;
                    _SlueArananGelen = SlueArayanGelenHat1;
                    hat1Dolumu = false;
                    break;
            }
            AVPCallCenter cc = new AVPCallCenter();

            if (tabPage == "Hat1")
            {
                if (hat1Dolumu)
                {
                    aramaVarmiHat1 = false;
                    _txtTelNoGelen.Enabled = true;
                    _SlueArananGelen.Enabled = true;
                    if (cc.online())
                    {
                        string aranan = _txtTelNoGelen.Text;
                        string strHostName = System.Net.Dns.GetHostName();
                        IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                        IPAddress ipAddress = ipHostInfo.AddressList[0];
                        string arayan = ipAddress.ToString();
                        cc.sendIpSantralForwardService(aranan, arayan, "10");
                        hat1Dolumu = false;
                        _btnKapatGelen.Visible = false;
                        _btnYonlendirGelen.Visible = false;
                        _btnKonferansGelen.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                    }
                }
            }
            else if (tabPage == "Hat2")
            {
                if (hat2Dolumu)
                {
                    _txtTelNoGelen.Enabled = true;
                    _SlueArananGelen.Enabled = true;
                    if (cc.online())
                    {
                        string aranan = _txtTelNoGelen.Text;
                        string strHostName = System.Net.Dns.GetHostName();
                        IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                        IPAddress ipAddress = ipHostInfo.AddressList[0];
                        string arayan = ipAddress.ToString();
                        cc.sendIpSantralForwardService(aranan, arayan, "10");
                        hat2Dolumu = false;
                        _btnKapatGelen.Visible = false;
                        _btnYonlendirGelen.Visible = false;
                        _btnKonferansGelen.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("IpSantral servisi ile baðlantý kurulamadý");
                    }
                }
                else
                {
                }
            }
        }

        private void btnKonferansGelen_Click(object sender, EventArgs e)
        {
            if (konferansaEkleHat1i)
            {
                konferansaEkleHat1i = false;
            }
            if (konferansaEkleHat2i)
            {
                konferansaEkleHat2i = false;
            }
            if (yonlendirHat1i)
            {
                yonlendirHat1i = false;
            }
            if (yonlendirHat2i)
            {
                yonlendirHat2i = false;
            }

            Button btn = (sender as Button);
            switch (btn.Name)
            {
                case "btnKonferansGelenHat1":

                    if (hat2Dolumu)
                    {
                        konferansaEkleHat1i = true;
                        MessageBox.Show("Konferansa eklemek istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Konferansa eklemek için açýlacak yeni hattan Konferansa eklemek istediðiniz numarayý arayýn");
                    }

                    break;

                case "btnKonferansGelenHat2":

                    if (hat1Dolumu)
                    {
                        konferansaEkleHat2i = true;
                        MessageBox.Show("Konferansa eklemek istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Konferansa eklemek için açýlacak yeni hattan Konferansa eklemek istediðiniz numarayý arayýn");
                    }

                    break;

                default:

                    if (hat2Dolumu)
                    {
                        konferansaEkleHat1i = true;
                        MessageBox.Show("Konferansa eklemek istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Konferansa eklemek için açýlacak yeni hattan Konferansa eklemek istediðiniz numarayý arayýn");
                    }

                    break;
            }
        }

        private void btnYeniAramaGelen_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            AVPCallCenter cc = new AVPCallCenter();

            switch (btn.Name)
            {
                case "btnYeniAramaGelenHat1":

                    if (cmbBoxTelNoGidenHat2.Text == "" && txtBoxTelNoGelenHat2.Text == "")
                    {
                        cc.ShowTabPage(xtraTabHatlar, xtraTabHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageEskiGorusmelerHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGelenHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGorusmeTutanagiHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageIcraHesapHat2);
                        xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                        cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGidenHat2);
                        btnKapatGidenHat2.Visible = false;
                        btnYonlendirGidenHat2.Visible = false;
                        btnKonferansGidenHat2.Visible = false;
                    }

                    break;

                case "btnYeniAramaGelenHat2":
                    if (cmbBoxTelNoGidenHat1.Text == "" && txtBoxTelNoGelenHat1.Text == "")
                    {
                        //cc.ShowTabPage(xtraTabHatlar, xtraTabHat1);
                        cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageEski);
                        cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGorusmeTutanagi);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageIcraHesapHat1);
                        xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                        cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGiden);
                        btnKapatGidenHat1.Visible = false;
                        btnYonlendirGidenHat1.Visible = false;
                        btnKonferansGidenHat1.Visible = false;
                    }

                    break;

                default:

                    if (cmbBoxTelNoGidenHat2.Text == "" && txtBoxTelNoGelenHat2.Text == "")
                    {
                        cc.ShowTabPage(xtraTabHatlar, xtraTabHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageEskiGorusmelerHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGelenHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGorusmeTutanagiHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageIcraHesapHat2);
                        xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                        cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGidenHat2);
                        btnKapatGidenHat2.Visible = false;
                        btnYonlendirGidenHat2.Visible = false;
                        btnKonferansGidenHat2.Visible = false;
                    }
                    break;
            }
        }

        private void btnYeniAramaGiden_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            AVPCallCenter cc = new AVPCallCenter();
            switch (btn.Name)
            {
                case "btnYeniAramaGidenHat1":

                    if (cmbBoxTelNoGidenHat2.Text == "" && txtBoxTelNoGelenHat2.Text == "")
                    {
                        cc.ShowTabPage(xtraTabHatlar, xtraTabHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageEskiGorusmelerHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGelenHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGorusmeTutanagiHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageIcraHesapHat2);
                        xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                        cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGidenHat2);
                        btnKapatGidenHat2.Visible = false;
                        btnYonlendirGidenHat2.Visible = false;
                        btnKonferansGidenHat2.Visible = false;
                    }

                    break;

                case "btnYeniAramaGidenHat2":
                    if (cmbBoxTelNoGidenHat1.Text == "" && txtBoxTelNoGelenHat1.Text == "")
                    {
                        //cc.ShowTabPage(xtraTabHatlar, xtraTabHat1);
                        cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageEski);
                        cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGorusmeTutanagi);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageIcraHesapHat1);
                        xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                        cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGiden);
                        btnKapatGidenHat1.Visible = false;
                        btnYonlendirGidenHat1.Visible = false;
                        btnKonferansGidenHat1.Visible = false;
                    }

                    break;

                default:

                    if (cmbBoxTelNoGidenHat2.Text == "" && txtBoxTelNoGelenHat2.Text == "")
                    {
                        cc.ShowTabPage(xtraTabHatlar, xtraTabHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageEskiGorusmelerHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGelenHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGorusmeTutanagiHat2);
                        cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageIcraHesapHat2);
                        xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                        cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGidenHat2);
                        btnKapatGidenHat2.Visible = false;
                        btnYonlendirGidenHat2.Visible = false;
                        btnKonferansGidenHat2.Visible = false;
                    }
                    break;
            }
        }

        private void btnYonlendirGelen_Click(object sender, EventArgs e)
        {
            if (konferansaEkleHat1i)
            {
                konferansaEkleHat1i = false;
            }
            if (konferansaEkleHat2i)
            {
                konferansaEkleHat2i = false;
            }
            if (yonlendirHat1i)
            {
                yonlendirHat1i = false;
            }
            if (yonlendirHat2i)
            {
                yonlendirHat2i = false;
            }

            Button btn = (sender as Button);
            switch (btn.Name)
            {
                case "btnYonlendirGelenHat1":

                    if (hat2Dolumu)
                    {
                        yonlendirHat1i = true;
                        MessageBox.Show("Yonlendirmeyi baðlamak istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Yönlendirmek için açýlacak yeni hattan yönlendirmek istediðiniz numarayý arayýn");
                    }

                    break;

                case "btnYonlendirGelenHat2":

                    if (hat1Dolumu)
                    {
                        yonlendirHat2i = true;
                        MessageBox.Show("Yonlendirmeyi baðlamak istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Yönlendirmek için açýlacak yeni hattan yönlendirmek istediðiniz numarayý arayýn");
                    }

                    break;

                default:

                    if (hat2Dolumu)
                    {
                        yonlendirHat1i = true;
                        MessageBox.Show("Yonlendirmeyi baðlamak istediðiniz hattýn resmine týklayýn");
                    }
                    else
                    {
                        MessageBox.Show("Yönlendirmek için açýlacak yeni hattan yönlendirmek istediðiniz numarayý arayýn");
                    }

                    break;
            }
        }

        private void c_titemArkaPlanResim_Click(object sender, EventArgs e)
        {
            if (this.c_opfArkaPlan.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage = System.Drawing.Image.FromFile(c_opfArkaPlan.FileName);
            }
        }

        private void c_titemBenimAjandam_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.Ajanda);
        }

        private void c_titemDetayliAjanda_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.Ajanda);
        }

        private void c_titemDosyaBelgeBelgeBul_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.BelgeAramaEkran);
        }

        private void c_titemDosyaBelgeYeniBelge_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belgeKayit = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
            belgeKayit.MdiParent = this;
            belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            belgeKayit.Show();
        }

        private void c_titemDosyaCikis_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Programdan çýkmak istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            //    return;
            Application.Exit();
        }

        private void c_titemDosyaDavaDosyaBul_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.DavaGirisHizliEkran);
        }

        private void c_titemDosyaDavaDosyaGelismisBul_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.DavaGirisEkran);
        }

        private void c_titemDosyaDavaEkleStandartFormIle_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.DavaDosyaKayitForm);
        }

        private void c_titemDosyaDavaSorusturmaBul_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.SorusturmaGirisEkran);
        }

        private void c_titemDosyaDegisikIslerIhtiyatiHaciz_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IhtiyatiHacizGirisEkran);
        }

        private void c_titemDosyaDegisikIslerIhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IhtiyatiTedbirBilgileriGirisEkran);
        }

        private void c_titemDosyaDegisikIslerTespitKaydet_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.TespitKaydetForm);
        }

        private void c_titemDosyaEvrakBul_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.TebligatGirisEkran);
        }

        private void c_titemDosyaEvrakYeniEkle_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.TebligatKayitEkrani);
        }

        private void c_titemDosyaGorusmeKayitBul_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.GorusmeGirisEkran);
        }

        private void c_titemDosyaGorusmeYeniGorusme_Click(object sender, EventArgs e)
        {
            Forms.rFrmGorusmeKayit gorusme = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
            gorusme.IsModul = true;
            gorusme.Show();
        }

        private void c_titemDosyaHukukMuhasebesi_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.MuhasebeGirisEkran);
        }

        private void c_titemDosyaIcraDosyaBul_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IcraGirisEkran);
        }

        private void c_titemDosyaIcraYeniSihirbazIle_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.AdimAdimIcraKaydi);
        }

        private void c_titemDosyaIcraYeniStandartFormIle_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IcraDosyaKayit);
        }

        private void c_titemDosyaKisiBulKisi_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.CariAramaForm);
        }

        private void c_titemDosyaKisiYeniKisi_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.CariGenelGiris);
        }

        private void c_titemDosyaProjeDosyaBulProje_Click(object sender, EventArgs e)
        {
            frmKlasorYeni klasor = new frmKlasorYeni();
            klasor.Show();
        }

        private void c_titemDosyaProjeDosyaKlasorAra_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmKlasorAramaEkran frmklasorAra = new AdimAdimDavaKaydi.GirisEkran.rFrmKlasorAramaEkran();
            frmklasorAra.Show();
        }

        private void c_titemDosyaProjeDosyaYeniProje_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmYeniKlasor frm = new AdimAdimDavaKaydi.Forms.frmYeniKlasor();
            AV001_TDIE_BIL_PROJE prj = frm.YeniKlasorGetir();
            if (prj != null)
            {
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(prj);
            }
        }

        private void c_titemDosyaSorusturmaYeniStandartFormIle_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.SorusturmaGiris);
        }

        private void c_titemDosyaSozlesmeBul_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.SozlesmeGirisEkran);
        }

        private void c_titemDosyaSozlesmeYeniStandartFormIleEkle_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout loyut = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();
            loyut.Show(1);
        }

        private void c_titemDosyaVekaletBulVekalet_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.TemsilBilgileriGirisEkran);
        }

        private void c_titemDosyaVekaletYeniVekalet_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.TemsilKayit);
        }

        private void c_titemDosyaYapilcakIsAra_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.YapilcakIsAramaEkran);
        }

        private void c_titemDosyaYapilcakIsEkle_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IsKayitUfak);
        }

        private void c_titemEditorDegiskenTanim_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.DegiskenAyar);
        }

        private void c_titemFormHerZamanUstte_Click(object sender, EventArgs e)
        {
            //this.TopMost = c_titemFormHerZamanUstte.Checked;
        }

        private void c_titemSaydamlikYuzde10_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem titem = (ToolStripMenuItem)sender;
                if (titem.Tag is int)
                {
                    this.Opacity = Convert.ToDouble(titem.Tag);
                }
            }
        }

        private void c_titemSistemIslemleriKullaniciSecenekleri_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.GenelAyar);
        }

        private void c_titemSistemIslemleriParolaDegistirme_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.ParolaDegistirme);
        }

        private void c_titemSistemIslemleriYedekAl_Click(object sender, EventArgs e)
        {
            frmYedek frm = new frmYedek();
            frm.Show();
        }

        private void c_titemStandartRaporlar_Click(object sender, EventArgs e)
        {
            //string raporEXE = Application.StartupPath + "\\AvukatProRaporlar.exe";
            //if (File.Exists(raporEXE))
            //{
            //    System.Diagnostics.Process.Start(raporEXE, AvukatProLib.Kimlikci.Kimlik.Cari_ID.ToString());
            //}
            //else
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("Raporlar Modülüne Eriþim Hakkýnýz Bulunmamaktadýr...");
            //}
        }

        private void c_titemSubemdekiAvukatlarinAjandasi_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.Ajanda);
        }

        private void c_titemTanimlarAntetTanimlarAlt_Click(object sender, EventArgs e)
        {
            Editor.Forms.frmAntetKaydet frmAntetKaydet = new AdimAdimDavaKaydi.Editor.Forms.frmAntetKaydet();
            frmAntetKaydet.Show();
        }

        private void c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.Main);
        }

        private void c_titemTanimlarKodVeCetvelAnaKodFormlar_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.Cetvel);
        }

        private void c_titemTebligatBarkodAraligiTanimlama_Click(object sender, EventArgs e)
        {
            frmPttBarkodAraligiKayit frmBarkodAraligiKayit = new frmPttBarkodAraligiKayit();
            frmBarkodAraligiKayit.MdiParent = this;
            frmBarkodAraligiKayit.Show();
        }

        private void c_titemYardimAvukatproYardim_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.AboutAvukatpro);
        }

        private void cekSenetBilgisindenBulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.KiymetliEvrakGirisEkran);
        }

        private void çaðrýMerkeziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)AdimAdimDavaKaydi.Properties.Resources.adliyede_gorusme;
            pictureBox2.Image = (Image)AdimAdimDavaKaydi.Properties.Resources.adliyede_gorusme;
            pictureBox3.Image = (Image)AdimAdimDavaKaydi.Properties.Resources.adliyede_gorusme;
            pictureBox4.Image = (Image)AdimAdimDavaKaydi.Properties.Resources.adliyede_gorusme;

            AVPCallCenter cc = new AVPCallCenter();
            if (!cc.online())
            {
                MessageBox.Show("!!! Ip Santrale Baðlanýlamadý");
            }
            cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
            cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageGorusmeTutanagi);
            cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageEski);
            cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageIcraHesapHat1);
            cc.HideTabPage(xtraTabHatlar, xtraTabHat2);
            cc.HideTabPage(xtraTabHatlar, xtraTabHat3);
            cc.HideTabPage(xtraTabHatlar, xtraTabHat4);

            tbPageGiden_Click(new object(), new EventArgs());
            btnKapatGidenHat1.Visible = false;
            btnYonlendirGidenHat1.Visible = false;
            btnKonferansGidenHat1.Visible = false;
            Thread ThreadServerStart = new Thread(doServerStart);
            ThreadServerStart.Start();

            dckPanelCagriMerkezi.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
        }

        private void daðýtýlmamýþMasraflarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmDagitilmamisMasraflar frm = new AdimAdimDavaKaydi.Entegrasyon.frmDagitilmamisMasraflar();
            frm.Show();
        }

        private void daðýtýlmamýþTahsilatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmDagitilmamisTahsilatlar frm = new AdimAdimDavaKaydi.Entegrasyon.frmDagitilmamisTahsilatlar();
            frm.Show();
        }

        private void dataAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AVPTransfer.frmAutoExport formExp = new AVPTransfer.frmAutoExport(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            formExp.Show();
        }

        private void davaliOdemesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rFrmDavaliOdemeleri frm = new AdimAdimDavaKaydi.Forms.Dava.rFrmDavaliOdemeleri();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void dikeyYerlestirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void doServerStart()
        {
            TcpListener serverSocket = new TcpListener(5092);
            TcpClient clientSocket;
            serverSocket.Start();
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            string[] _Gorusme = new string[50];

            while (true)
            {
                clientSocket = new TcpClient();
                clientSocket = serverSocket.AcceptTcpClient();
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                //dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                if (dataFromClient.ToString().Contains("PBX"))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(dataFromClient);
                    string _Id = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[0].InnerText;  //<Id>Id bilgisi </Id>
                    /*xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[1].InnerText*/
                    string _cagriTip = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[4].InnerText; //<CagriTipi>Cagrinin tipini verir telefon=1,fax=2,sms=3,sesliMesaj=4,mail=5,goruntuluTelefon=6</CagriTipi>
                    string _kaynakTel = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[1].InnerText;
                    string _hedefTel = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[2].InnerText;
                    //int _IS_KATEGORI_ID = 0;
                    //int _GORUSME_YONU = 0;
                    //string _GORUSULEN_TEL = "";
                    //string _GORUSEN_TEL = "";

                    //int _GORUSEN_CARI_ID = 0;

                    //int _GORUSULEN_CARI_ID = 0;
                    //if (_cagriTip[1].ToString() == "1")
                    //{
                    //    if (_hedefTel == "")
                    //    {
                    //        _TelNo = _kaynakTel;
                    //    }

                    //}
                    //else if (_cagriTip[1].ToString() == "2")
                    //{
                    //    if (_kaynakTel == "")
                    //    {
                    //        _TelNo = _hedefTel;
                    //    }

                    //}
                    //if (_TelNo != "")
                    //{
                    //AvukatProLib.CompInfo smtpInfo = (CompInfo.CompInfoListGetir(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName))[0];

                    //SqlConnection cnn = new SqlConnection(smtpInfo.ConStr);
                    //  cnn.Open();
                    //  SqlCommand cmd = new SqlCommand("SELECT s.DAHILI_1,s.DAHILI_2,s.DAHILI_3,s.ID,t.ID FROM dbo.AV001_TDI_BIL_CARI  s inner join dbo.AV001_TDI_BIL_CARI t on s.ID=t.BAGLI_OLDUGU_YETKILI_CARI_ID WHERE  t.TEL_1='" + _TelNo + "'OR t.TEL_2='" + _TelNo + "'OR t.FAX='" + _TelNo + "'OR t.CEP_TEL='" + _TelNo + "'OR t.CEP_TEL2='" + _TelNo + "'OR t.EV_TEL='" + _TelNo + "' OR t.EV_FAX='" + _TelNo + "'  ", cnn);
                    //  SqlDataReader dr;
                    //  dr = cmd.ExecuteReader();
                    //  int i = 0;

                    //if (SlueArayanGelenHat1.Properties.View.RowCount > 0)
                    //{
                    //}
                    //else
                    //{
                    if (dckPanelCagriMerkezi.InvokeRequired)
                    {
                        dckPanelCagriMerkezi.Invoke((MethodInvoker)delegate { dckPanelCagriMerkezi.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible; });
                    }

                    else
                    {
                        dckPanelCagriMerkezi.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                    }
                    //if (cmbBoxTelNoGidenHat1.Text!="")
                    //  {
                    AVPCallCenter cc = new AVPCallCenter();

                    if (!hat1Dolumu)
                    {
                        hat1Dolumu = true;
                        tbControlCagriBilgileriHat1.Invoke((MethodInvoker)delegate
                        {
                            cc.ShowTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                            cc.HideTabPage(tbControlCagriBilgileriHat1, tbPageGiden);
                        });
                        btnKapatGelenHat1.Invoke((MethodInvoker)delegate
                        {
                            btnKapatGelenHat1.Visible = false;
                        });
                        btnYeniAramaGelenHat1.Invoke((MethodInvoker)delegate
                        {
                            btnYeniAramaGelenHat1.Visible = false;
                        });
                        if (txtBoxTelNoGelenHat1.InvokeRequired)
                        {
                            txtBoxTelNoGelenHat1.Invoke((MethodInvoker)delegate { txtBoxTelNoGelenHat1.Text = _kaynakTel; });
                        }
                        else
                        {
                            txtBoxTelNoGelenHat1.Text = _kaynakTel;
                        }

                        //SlueArayanGelenHat1.Invoke((MethodInvoker)delegate { SlueArayanGelen_Enter(SlueArayanGelenHat1, new EventArgs()); });
                    }
                    else if (!hat2Dolumu)
                    {
                        hat2Dolumu = true;

                        if (txtBoxTelNoGelenHat2.InvokeRequired)
                        {
                            txtBoxTelNoGelenHat2.Invoke((MethodInvoker)delegate { txtBoxTelNoGelenHat2.Text = _kaynakTel; });
                        }
                        else
                        {
                            txtBoxTelNoGelenHat2.Text = _kaynakTel;
                        }

                        xtraTabHatlar.Invoke((MethodInvoker)delegate
                        {
                            cc.ShowTabPage(xtraTabHatlar, xtraTabHat2);
                        });
                        tbControlCagriBilgileriHat2.Invoke((MethodInvoker)delegate
                        {
                            cc.ShowTabPage(tbControlCagriBilgileriHat2, tbPageGelenHat2);
                            cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGidenHat2);
                            cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageEskiGorusmelerHat2);
                            cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageGorusmeTutanagiHat2);
                            cc.HideTabPage(tbControlCagriBilgileriHat2, tbPageIcraHesapHat2);
                        });
                        btnKapatGelenHat2.Invoke((MethodInvoker)delegate
                        {
                            btnKapatGelenHat2.Visible = false;
                        });
                        btnYeniAramaGelenHat2.Invoke((MethodInvoker)delegate
                        {
                            btnYeniAramaGelenHat2.Visible = false;
                        });
                    }

                    //}

                    //SlookUpEditGelenHat1_Enter(SlookUpEditGelenHat1, _TelNo, EventArgs.Empty);
                    //SlookUpEditGelenHat1.Properties.View.row
                    //}
                    //while (dr.Read())
                    //{
                    //    _Gorusme[i] = dr[0].ToString() + "~" + Convert.ToInt32(dr[3].ToString()) + "~" + Convert.ToInt32(dr[4].ToString());
                    //    i++;
                    //}
                    //cmd.Dispose();
                    //cnn.Close();
                    //cnn.Dispose();

                    //if (_cagriTip[1].ToString() == "1")
                    //{
                    //    _GORUSME_YONU = 0;
                    //    _GORUSULEN_TEL = _kaynakTel;
                    //    _GORUSEN_TEL = _GorusenTelSql;
                    //}
                    //else if (_cagriTip[1].ToString() == "2")
                    //{
                    //    _GORUSME_YONU = 1;
                    //    _GORUSULEN_TEL = _hedefTel;
                    //    _GORUSEN_TEL = _GorusenTelSql;
                    //}

                    //}
                    //else
                    //{
                    //if (_cagriTip[1].ToString() == "1")
                    //{
                    //    _GORUSME_YONU = 0;
                    //    _GORUSULEN_TEL = _kaynakTel;
                    //    _GORUSEN_TEL = _hedefTel;
                    //}
                    //else if (_cagriTip[1].ToString() == "2")
                    //{
                    //    _GORUSME_YONU = 1;
                    //    _GORUSULEN_TEL = _hedefTel;
                    //    _GORUSEN_TEL = _kaynakTel;
                    //}
                    //}

                    //switch (_cagriTip[0].ToString())
                    //{
                    //    case "1":
                    //        _IS_KATEGORI_ID = 493;

                    //        break;

                    //    case "2":
                    //        _IS_KATEGORI_ID = 487;
                    //        break;

                    //    case "3":
                    //        break;

                    //    case "4":
                    //        _IS_KATEGORI_ID = 886;
                    //        break;

                    //    case "5":
                    //        break;

                    //    case "6":
                    //        _IS_KATEGORI_ID = 882;
                    //        break;

                    //    default:
                    //        break;
                    //}
                    string _kanalAdi = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[3].InnerText;
                    string _baslangicTarih = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[5].InnerText;
                    string _baslangicSaat = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[6].InnerText;
                    string _kayitUrl = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[7].InnerText;
                    string _bitisTarih = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[8].InnerText;
                    string _bitisSaat = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[9].InnerText;
                    string _kabulBilgisi = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[10].InnerText;

                    string _kanalAdi2 = xmlDoc.DocumentElement.ChildNodes[1].ChildNodes[0].InnerText;
                    string _yonlendiren = xmlDoc.DocumentElement.ChildNodes[1].ChildNodes[1].InnerText;
                    string _yonlendirilen = xmlDoc.DocumentElement.ChildNodes[1].ChildNodes[2].InnerText;

                    string _kanalAdi3 = xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].InnerText;
                    string _davetEden = xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[1].InnerText;
                    string _davetEdilen = xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[2].InnerText;

                    //SqlConnection cnn2 = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Password=PASSWRD1;Initial Catalog=BARKOD;Data Source=DEVELOPER-PC");
                    //cnn2.Open();
                    //SqlCommand cmd2 = new SqlCommand("SELECT Dosya_No, Adliye, Gorev, No, Esas_No, Takip_T, Referans1, Referans2, Referans3, Ozel_Kod1, Ozel_Kod2, Ozel_Kod3, Ozel_Kod4, Takip_Konusu, Durum, K, Taraf_Adi, Sifat, Sorumlu_Adi, Tipi, ID, BANKA_ID, SUBE_ID, FOY_BIRIM_ID, FOY_YERI_ID, FOY_OZEL_DURUM_ID, TAHSILAT_DURUM_ID, KREDI_GRUP_ID, KREDI_TIP_ID, KLASOR_1, KLASOR_2, SUBE_KODU, KAYIT_TARIHI, SUBE_KOD_ID, KONTROL_KIM_ID, MODUL, PROJE_ID, PROJE_ADI, PROJE_KOD, SEGMENT, ACIKLAMA FROM dbo.R_BIRLESIK_TAKIPLER_TUMU_TEXT WHERE Taraf_Adi=" + _GORUSULEN_CARI_ID + " ", cnn2);
                    //SqlDataReader dr2;
                    //dr2 = cmd2.ExecuteReader();
                    //bool b = false;
                    //while (dr2.Read())
                    //{
                    //    b = true;
                    //}
                    //if (b)
                    //{
                    //    Form2 frm2 = new Form2();
                    //    frm2.Show();
                    //    Application.Run(new Form2());
                    //}
                    //for (int i = 0; i < _Gorusme.Count(); i++)
                    //{
                    //    _Gorusme[i].ToString();
                    //}

                    //_GORUSULEN_CARI_ID
                }

                clientSocket.Close();
            }

        }

        private void dönemselRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvukatProRaporlar.Forms.frmDonemselRaporSihirbaz.ShowWizard(1);
        }

        private void dövizKurlarýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmShowGunlukKur frm = new AdimAdimDavaKaydi.Entegrasyon.frmShowGunlukKur();
            frm.Show();
        }

        private void durusmaKesifAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.DurusmaCelseGirisEkran);
        }

        private void durusmaSatisKesifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmYapilcakIsAramaEkran isArama = new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();
            isArama.HizliErisimdenMi = true;
            isArama.DurusmaMi = true;
            isArama.Show();
        }

        private void durusmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit durusma = new AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit();
            durusma.StartPosition = FormStartPosition.WindowsDefaultLocation;
            durusma.IsModul = true;
            durusma.Show();
        }

        private void duruþmaKeþifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.DurusmaCelseGirisEkran);
        }

        private void duruþmaSatýþKeþifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmYapilcakIsAramaEkran isArama = new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();
            isArama.HizliErisimdenMi = true;
            isArama.DurusmaMi = true;
            isArama.Show();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.SikKullanilanEkle);
        }

        private void ekranÖzelleþtirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //string conStr = "";
                //if (frmPack != null && !String.IsNullOrEmpty(frmPack.ConStr)) conStr = frmPack.ConStr;
                //frmPack = new frmPackManager(this.ActiveMdiChild, conStr);
                //frmPack.ConStr = conStr;
                //frmPack.Show();
                List<Form> forms = new List<Form>();
                forms.Add(this);
                forms.AddRange(this.MdiChildren);
                frmPaket frmPaket = new frmPaket(forms);
                frmPaket.Show();
            }
        }

        private void envanterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.rFrmTumDosyalar tumDosyalar = new AdimAdimDavaKaydi.Forms.rFrmTumDosyalar();
            tumDosyalar.AcilisModu = AdimAdimDavaKaydi.UserControls.ucKurumsalGiris.AcilisModu.Envanter;
            tumDosyalar.Show();
        }

        private void evrakTebligatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit evrakKaydi = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
            evrakKaydi.Show();
        }

        private void FormInit()
        {
            MainForm = this;

            Forms = new Dictionary<AvukatProLib.Extras.FormType, object>();
        }

        private void formlarEditörToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            editor.TakipEkranidan = false;
            editor.MdiParent = this;
            editor.Show();
            editor.beklemePaneli.Visible = false;
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsId != 0)
            {
                if (MessageBox.Show("Bu hatýrlatmaya konu olan Ýþ tamamlandý olarak iþaretlensin mi?"
                                    , "AvukatPro", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    AV001_TDI_BIL_IS AcilanIs = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(IsId);
                    AcilanIs.DURUM = true;
                    AcilanIs.BITIS_TARIHI = DateTime.Now;
                    AcilanIs.STAMP = 1;
                    DataRepository.AV001_TDI_BIL_ISProvider.Save(AcilanIs);
                }
            }
        }

        private void gayrimenkulÝpoteðiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout loyut = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();
            loyut.Show(3, Convert.ToInt32(item.Tag));
        }

        private void gelismisRaporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string raporEXE = Application.StartupPath + "\\AvukatProRaporlar.exe";
                if (File.Exists(raporEXE))
                {
                    System.Diagnostics.Process.Start(raporEXE, AvukatProLib.Kimlikci.Kimlik.Cari_ID.ToString());
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Raporlar Modülüne Eriþim Hakkýnýz Bulunmamaktadýr...");
                }
            }
            catch
            {
            }
        }

        private void genelBilgilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmShowXML frm = new AdimAdimDavaKaydi.Entegrasyon.frmShowXML();
            frm.Show();
        }

        private void genelSözleþmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout loyut = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();
            loyut.Show();
        }

        private void gorusmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.rFrmGorusmeKayit gorusme = new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

            // gorusme.MdiParent = null;
            gorusme.StartPosition = FormStartPosition.WindowsDefaultLocation;
            gorusme.IsModul = true;
            gorusme.Show();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rfrmSikKullanilanlar kullanianlar = new rfrmSikKullanilanlar();
            kullanianlar.Show();
        }

        private void gridViewGelenHat1_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = (sender as DevExpress.XtraGrid.Views.Grid.GridView);

            string foyId = gv.GetRowCellValue(e.RowHandle, "Foy Ýd").ToString();
            string tipi = gv.GetRowCellValue(e.RowHandle, "Tipi").ToString();

            if (gv.Name == "gridViewGelenHat1")
            {
                ucGorusmelerHat1.MyDataSource = new TList<AV001_TDI_BIL_GORUSME>();
                if (e.RowHandle < -1)
                    return;

                AVPCallCenter cc = new AVPCallCenter();
                cc.gorusmeKayitDoldur(ucGorusmeKayitHat1, foyId, tipi, txtBoxTelNoGelenHat1.Text, SlueArayanGelenHat1.Tag.ToString(), 0, ucIcraHesapCetveliHat1);
                ucGorusmelerHat1.Tag = foyId + "~" + gridControlGelenHat1.Tag.ToString();
            }
            else if (gv.Name == "gridViewGelenHat2")
            {
                ucGorusmelerHat2.MyDataSource = new TList<AV001_TDI_BIL_GORUSME>();
                if (e.RowHandle < -1)
                    return;

                AVPCallCenter cc = new AVPCallCenter();
                cc.gorusmeKayitDoldur(ucGorusmeKayitHat2, foyId, tipi, txtBoxTelNoGelenHat2.Text, SlueArayanGelenHat2.Tag.ToString(), 0, ucIcraHesapCetveliHat2);
                ucGorusmelerHat2.Tag = foyId + "~" + gridControlGelenHat2.Tag.ToString();
            }
        }

        private void gridViewGiden_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            TabControl _tbcontrolCagriBilgileri;
            TabPage _tbPageIcraHesap;
            TabPage _tbPageEskiGorusmeler;
            TabPage _tbPageGorusmeTutatnagi;
            ucGorusmeKayit _myucGorusmeKayit;
            System.Windows.Forms.ComboBox _cmbBoxTelNoGiden;
            SearchLookUpEdit _sleu;
            ucGorusmeler _myucGorusmeler;
            DevExpress.XtraGrid.GridControl _mygridControl;

            switch (gv.Name)
            {
                case "gridViewGidenHat1":
                    _myucGorusmeler = ucGorusmelerHat1;
                    _sleu = SlueArananGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _myucGorusmeKayit = ucGorusmeKayitHat1;
                    _tbPageGorusmeTutatnagi = tbPageGorusmeTutanagi;
                    _tbPageEskiGorusmeler = tbPageEski;
                    _tbPageIcraHesap = tbPageIcraHesapHat1;
                    _tbcontrolCagriBilgileri = tbControlCagriBilgileriHat1;
                    _mygridControl = gridControlGidenHat1;

                    break;

                case "gridViewGidenHat2":
                    _myucGorusmeler = ucGorusmelerHat2;
                    _sleu = SlueArananGidenHat2;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat2;
                    _myucGorusmeKayit = ucGorusmeKayitHat2;
                    _tbPageGorusmeTutatnagi = tbPageGorusmeTutanagiHat2;
                    _tbPageEskiGorusmeler = tbPageEskiGorusmelerHat2;
                    _tbPageIcraHesap = tbPageIcraHesapHat2;
                    _tbcontrolCagriBilgileri = tbControlCagriBilgileriHat2;
                    _mygridControl = gridControlGidenHat2;

                    break;

                default:
                    _myucGorusmeler = ucGorusmelerHat1;
                    _sleu = SlueArananGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _myucGorusmeKayit = ucGorusmeKayitHat1;
                    _tbPageGorusmeTutatnagi = tbPageGorusmeTutanagi;
                    _tbPageEskiGorusmeler = tbPageEski;
                    _tbPageIcraHesap = tbPageIcraHesapHat1;
                    _tbcontrolCagriBilgileri = tbControlCagriBilgileriHat1;
                    _mygridControl = gridControlGidenHat1;

                    break;
            }
            _myucGorusmeler.MyDataSource = new TList<AV001_TDI_BIL_GORUSME>();
            if (e.RowHandle < -1)
                return;

            string foyId = gv.GetRowCellValue(e.RowHandle, "Foy Ýd").ToString();
            string tipi = gv.GetRowCellValue(e.RowHandle, "Tipi").ToString();
            AVPCallCenter cc = new AVPCallCenter();
            if (tipi == "ÝCRA")
            {
                cc.ShowTabPage(_tbcontrolCagriBilgileri, _tbPageIcraHesap);
            }

            cc.ShowTabPage(_tbcontrolCagriBilgileri, _tbPageEskiGorusmeler);
            cc.ShowTabPage(_tbcontrolCagriBilgileri, _tbPageGorusmeTutatnagi);
            cc.selectTabPage(_tbcontrolCagriBilgileri, _tbPageGorusmeTutatnagi);

            cc.gorusmeKayitDoldur(_myucGorusmeKayit, foyId, tipi, _cmbBoxTelNoGiden.Text.Split('~')[0].ToString(), _sleu.Tag.ToString(), 1, ucIcraHesapCetveliHat1);
            _myucGorusmeler.Tag = foyId + "~" + _mygridControl.Tag.ToString();
        }

        private void guncellemeAyarlariToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            AvukatproUpdater.Common.Parameters.Param prm = new AvukatproUpdater.Common.Parameters.Param();
            if (AvukatproUpdater.Common.Parameters.frmParam.LoadParam(ref prm, Path.Combine(Application.ExecutablePath, "Updater\\UpdaterParam.xml"), true))
            {
                if (prm.IsBothClientAndServer)
                {
                    try
                    {
                        sc = new System.ServiceProcess.ServiceController("AvukatproUpdaterService");
                        if (sc.Status == ServiceControllerStatus.Running)
                        {
                            guncellemeServisiniBaslatToolStripMenuItem.Text = "Uygulama güncelleme servisini durdur.";
                        }
                        else if (sc.Status == ServiceControllerStatus.Stopped)
                        {
                            guncellemeServisiniBaslatToolStripMenuItem.Text = "Uygulama güncelleme servisini baþlat.";
                        }
                        guncellemeServisiniBaslatToolStripMenuItem.Visible = true;
                    }
                    catch (Exception)
                    {
                        sc = null;
                        guncellemeServisiniBaslatToolStripMenuItem.Visible = false;
                    }
                }
            }
            else guncellemeServisiniBaslatToolStripMenuItem.Visible = false;
        }

        private void guncellemeServisiniBaslatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Stop();
            }
            else if (sc.Status == ServiceControllerStatus.Stopped)
            {
                sc.Start();
            }
        }

        private void gunlukIslerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmYapilcakIsAramaEkran isArama = new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();
            isArama.HizliErisimdenMi = true;
            isArama.GunlukIsMi = true;
            isArama.Show();
        }

        private void hacizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Icra.frmHacizGirisi frm = new AdimAdimDavaKaydi.Forms.Icra.frmHacizGirisi();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.HacizEdilecekMalVar = true;
            frm.IsModul = true;
            frm.Show();
        }

        private void hacizToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.HacizGirisEkran);
        }

        private void hakemSözleþmesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout loyut = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();
            loyut.Show(5);
        }

        private void hariciSimulasyonHesabiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.UserControls.frmOdemePlani frmTaahhut = new AdimAdimDavaKaydi.UserControls.frmOdemePlani(true);
            frmTaahhut.Show();
        }

        private void hasarBilgileriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rfrmHasarGirisEkrani policeHasar = new rfrmHasarGirisEkrani();
            policeHasar.Show();
        }

        private void IcraSozlesmeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.GirisEkran.frmIcraVekaletSozlesmesi frm = new AdimAdimDavaKaydi.GirisEkran.frmIcraVekaletSozlesmesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void IsUcretlendirmeSozlesmeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Is.frmIsSozlesmeKayit isSozlesme = new AdimAdimDavaKaydi.Is.frmIsSozlesmeKayit();
            isSozlesme.MyDataSource = new AV001_TDI_BIL_IS_SOZLESME();
            isSozlesme.MdiParent = this;
            isSozlesme.Show();
        }

        private void icraHýzlýAramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.GirisEkran.frmIcraGirisHizliEkran frm = new AdimAdimDavaKaydi.GirisEkran.frmIcraGirisHizliEkran();
            frm.Show();
            frm.Activate();
        }

        private void ihtiyatiHacizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IhtiyatiHacizGirisEkran);
        }

        private void ihtiyatiHacizToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IhtiyatiHacizGirisEkran);
        }

        private void ihtiyatiTedbirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IhtiyatiTedbirBilgileriGirisEkran);
        }

        private void ihtiyatiTedbirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IhtiyatiTedbirBilgileriGirisEkran);
        }

        private void ilamBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IlamBilgileriGirisEkran);
        }

        private void isToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Is.Forms.frmIsKayitUfak isKayýt = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            isKayýt.StartPosition = FormStartPosition.WindowsDefaultLocation;
            isKayýt.Show();
        }

        private void itirazBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.ItirazBilgileriGirisEkran);
        }

        private void kararaÇýkanDosyalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKararaCikanDosyalar frmkr = new frmKararaCikanDosyalar() { StartPosition = FormStartPosition.CenterScreen, WindowState = FormWindowState.Maximized, MdiParent = this };
            frmkr.Show();
        }

        private void kesifIncelemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit kesifInceleme = new AdimAdimDavaKaydi.Forms.Dava.rFrmCelseKayit();
            kesifInceleme.StartPosition = FormStartPosition.WindowsDefaultLocation;
            kesifInceleme.IsModul = true;
            kesifInceleme.Show();
        }

        private void kimNeredeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKimNeredeBilgileri frmKimNerede = new frmKimNeredeBilgileri();
            frmKimNerede.Show();
        }

        private void klasorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYeniKlasor frm = new frmYeniKlasor();
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
            frm.FormClosed += delegate
            {
                AV001_TDIE_BIL_PROJE prj = frm.YeniKlasorGetir();
                if (prj != null)
                {
                    prj.SUBE_KOD_ID = AdimAdimDavaKaydi.Forms.frmKlasorYeni.KullaniciSubeIDGetir(prj.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Find(vi => !vi.YETKILI_MI.Value).CARI_ID);
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(prj);
                }
            };
        }

        private void krediKartýSözleþmesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout loyut = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();
            loyut.Show(2, Convert.ToInt32(item.Tag));
        }

        private void krediSözleþmesiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout loyut = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();
            loyut.Show(2);
        }

        private void kullanýcýDeðiþtirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKullaniciDegistir frmkulld = new frmKullaniciDegistir();
            frmkulld.ShowDialog();
        }

        private void kurGiriþiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmGunlukDovizKurGirisi frm = new frmGunlukDovizKurGirisi();
            frm.Show();
        }

        private void markaPatentSözleþmesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout loyut = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout();
            loyut.Show(6);
        }

        private void masrafAvansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli masraf =
                new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
            masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkraniDisinda;
            masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
            masraf.Show();
        }

        private void masraflarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmShowMasrafXML frm = new AdimAdimDavaKaydi.Entegrasyon.frmShowMasrafXML();
            frm.Show();
        }

        private void mdiAvukatPro_FormClosing(object sender, FormClosingEventArgs e)
        {
            AVPLicenceControl.LisansKontrolu(Application.StartupPath);

            AVPCallCenter cc = new AVPCallCenter();
            cc.offline();
            DialogResult dg = DevExpress.XtraEditors.XtraMessageBox.Show("Programdan çýkmak istediðinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dg == DialogResult.No)
                e.Cancel = true;
            else
            {
                Environment.Exit(1);
                this.Dispose();
            }
        }

        private void mdiAvukatPro_KeyDown(object sender, KeyEventArgs e)
        {
            Kisayollar(e);
        }

        private void mdiAvukatPro_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = Application.StartupPath;

            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];
            FormInit();

            //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this); // 21.01.2010 Paket Kontrolü için eklendi. Okan ARDIÇ
            //ekranÖzelleþtirmeToolStripMenuItem.Visible = true; //Müþteri exelerinde kapalý olmalý. MB
            c_titemYardimLisanslama.Visible = false;

            SetStyles();

            //<TIO - 20092108 - TOTAL için özel  Þube Merkez deðil ise Raporlara ulaþamayacak >
#if tmpTOTALOZEL
            if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
            {
                //c_titemStandartRaporlar
                c_titemStandartRaporlar.Visible = false;
            }
#endif
            foreach (var item in PaketHelper.Paketler)
            {
                var toolitem = (ToolStripMenuItem)ekranGorunumleriToolStripMenuItem.DropDownItems.Add(item.PaketAdi, null);
                if (PaketHelper.AktifPaket == item)
                    toolitem.Checked = true;
                toolitem.Click += paketDegistir2_Click;
            }

            ///Önemli :   Döviz çekme kýsmý serversideservice içine aktarýlacak////
            TList<TDI_CET_GUNLUK_DOVIZ_KUR> dvx = DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.GetBy_DovizID_TarihtenBuyuk(2, DateTime.Today.AddDays(-1));

            if (dvx.Count == 0)
            {
                if (cmpNfo.BitisTarihi >= DateTime.Today)
                {
                    if (HasActiveConnection())
                    {
                        try
                        {
                            DataSet dsDoviz = new DataSet();
                            dsDoviz.ReadXml("http://www.tcmb.gov.tr/kurlar/today.xml");
                            foreach (DataRow row in dsDoviz.Tables[1].Rows)
                            {
                                TDI_KOD_DOVIZ_TIP dov = //DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByDOVIZ_KODUAD(row["Kod"].ToString(), row["Isim"].ToString());
                                BelgeUtil.Inits.DovizSource.Where(q => q.DOVIZ_KODU.Trim() == row["Kod"].ToString().Trim()).FirstOrDefault();
                                if (dov != null)
                                {
                                    TList<TDI_CET_GUNLUK_DOVIZ_KUR> dv = DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.GetBy_DovizID_TarihtenBuyuk(dov.ID, DateTime.Today.AddDays(-1));
                                    if (dv.Count == 0)
                                    {
                                        try
                                        {
                                            TDI_CET_GUNLUK_DOVIZ_KUR dd = new TDI_CET_GUNLUK_DOVIZ_KUR();
                                            dd.DOVIZ_ID = dov.ID;
                                            dd.TARIH = DateTime.Today;
                                            dd.TL_DEGERI = Convert.ToDecimal(row["ForexBuying"].ToString().Replace(".", ","));
                                            dd.SUBE_KODU = dov.SUBE_KODU;
                                            dd.KONTROL_NE_ZAMAN = DateTime.Today;
                                            dd.KONTROL_KIM = "AVUKATPRO";
                                            dd.KONTROL_VERSIYON = dov.KONTROL_VERSIYON;
                                            dd.STAMP = dov.STAMP;
                                            dd.KONTROL_KIM_ID = dov.KONTROL_KIM_ID;
                                            dd.SUBE_KOD_ID = dov.SUBE_KOD_ID;
                                            dd.TCMB_KAYDI_MI = true;
                                            dd.DOVIZ_SATIS = null;
                                            dd.EFEKTIF_ALIS = null;
                                            dd.EFEKTIF_SATIS = null;
                                            dd.DOVIZ_ORTALAMA = null;
                                            dd.EFEKTIF_ORTALAMA = null;
                                            DataRepository.TDI_CET_GUNLUK_DOVIZ_KURProvider.DeepSave(dd);
                                        }
                                        catch { ;}
                                    }
                                }
                            }
                        }
                        catch { ;}
                    }
                }
            }

            ABDegiskenler.DegiskenleriDoldur();

            foreach (ToolStripMenuItem item in ekranGorunumleriToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            //(sender as ToolStripMenuItem).Checked = true;
            envanterToolStripMenuItem1.Visible = true;
            if (File.Exists(Path.Combine(Application.StartupPath, "belgekayit.avpis")))
            {
                System.Threading.Thread.Sleep(1000);
                var file = File.ReadAllLines(Path.Combine(Application.StartupPath, "belgekayit.avpis"));
                try
                {
                    File.Delete(Path.Combine(Application.StartupPath, "belgekayit.avpis"));
                }
                catch { }
                AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak frmBelgeKayitUfakf =
                        new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                frmBelgeKayitUfakf.FileName = file.ToList();
                frmBelgeKayitUfakf.MdiParent = this;
                //frmisKayit.MdiParent = null;
                frmBelgeKayitUfakf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmBelgeKayitUfakf.Show();
            }
            if (File.Exists(Path.Combine(Application.StartupPath, "evrakkayit.avpis")))
            {
                System.Threading.Thread.Sleep(1000);
                var file = File.ReadAllLines(Path.Combine(Application.StartupPath, "evrakkayit.avpis"));
                try
                {
                    File.Delete(Path.Combine(Application.StartupPath, "evrakkayit.avpis"));
                }
                catch { }
                AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit_exp frmBelgeKayitUfakf =
                        new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit_exp();
                frmBelgeKayitUfakf.FileName = file.ToList();
                frmBelgeKayitUfakf.MdiParent = this;
                //frmisKayit.MdiParent = null;
                frmBelgeKayitUfakf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmBelgeKayitUfakf.Show();
            }
        }

        private void mdiAvukatPro_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.Text = this.ActiveMdiChild.Text;
            }
            else
                this.Text = "AvukatPro Maestro 2013";
        }

        private void muallakRaporToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmMuallakRaporu rapor = new frmMuallakRaporu();
            rapor.Show();
        }

        private void mükerrerÞahýslarýBirleþtirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCariMerge frmcarrr = new frmCariMerge();
            frmcarrr.ShowDialog();
        }

        private void müvekkileÖdemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IcraTakipForms.frmMuvekkilOdemeleriLayout muvekkilOdeme =
               new AdimAdimDavaKaydi.IcraTakipForms.frmMuvekkilOdemeleriLayout();

            muvekkilOdeme.TakipEkraniDisinda = true;
            muvekkilOdeme.StartPosition = FormStartPosition.WindowsDefaultLocation;
            muvekkilOdeme.Show();
        }

        private void müvekkilHesaplarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Raporlama.frmMuvekkilRapor frm = new AdimAdimDavaKaydi.Raporlama.frmMuvekkilRapor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void notlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmYapilcakIsAramaEkran isArama = new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();
            isArama.HizliErisimdenMi = true;
            isArama.NotMu = true;
            isArama.Show();
        }

        private void notToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Is.Forms.frmIsKayitUfak notlar = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            notlar.StartPosition = FormStartPosition.WindowsDefaultLocation;
            notlar.Show();
        }

        private void paketDegistir2_Click(object sender, EventArgs e)
        {
            Paket pk = PaketHelper.Paketler.Where(q => q.PaketAdi == (sender as ToolStripMenuItem).Text).FirstOrDefault();

            foreach (ToolStripMenuItem item in ekranGorunumleriToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            (sender as ToolStripMenuItem).Checked = true;
            if (pk != null)
            {
                PaketHelper.AktifPaket = pk;
                if (!DesignMode)
                    this.GetPaketForm();
                foreach (var child in this.MdiChildren)
                {
                    if (!DesignMode)
                        child.GetPaketForm();
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            AVPCallCenter cc = new AVPCallCenter();
            PictureBox pcBox = (sender as PictureBox);

            switch (pcBox.Name)
            {
                case "pictureBox1":

                    if (yonlendirHat2i)
                    {
                        if (cmbBoxTelNoGidenHat1.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGiden);

                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];

                                cc.sendIpSantralForwardService(ipAddress.ToString(), cmbBoxTelNoGidenHat2.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat2.Text.Split('~')[0], cmbBoxTelNoGidenHat1.Text.Split('~')[0], "16");
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), txtBoxTelNoGelenHat2.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat2.Text.Split('~')[0], cmbBoxTelNoGidenHat1.Text.Split('~')[0], "16");
                            }
                        }
                        else if (txtBoxTelNoGelenHat1.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), cmbBoxTelNoGidenHat2.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat2.Text.Split('~')[0], txtBoxTelNoGelenHat1.Text.Split('~')[0], "16");
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), txtBoxTelNoGelenHat2.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat2.Text.Split('~')[0], txtBoxTelNoGelenHat1.Text.Split('~')[0], "16");
                            }
                        }
                    }
                    else if (konferansaEkleHat2i)
                    {
                        if (cmbBoxTelNoGidenHat1.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGiden);

                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat1.Text.Split('~')[0], ipAddress.ToString(), cmbBoxTelNoGidenHat2.Text.Split('~')[0], "20");
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat1.Text.Split('~')[0], ipAddress.ToString(), txtBoxTelNoGelenHat2.Text.Split('~')[0], "20");
                            }
                        }
                        else if (txtBoxTelNoGelenHat1.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];

                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat1.Text.Split('~')[0], ipAddress.ToString(), cmbBoxTelNoGidenHat2.Text.Split('~')[0], "20");
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];

                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat1.Text.Split('~')[0], ipAddress.ToString(), txtBoxTelNoGelenHat2.Text.Split('~')[0], "20");
                            }
                        }
                    }
                    else
                    {
                        xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                        if (cmbBoxTelNoGidenHat1.Text != "")
                        {
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGiden);
                        }
                        else if (txtBoxTelNoGelenHat1.Text != "")
                        {
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                        }
                    }

                    break;

                case "pictureBox2":

                    if (yonlendirHat1i)
                    {
                        if (cmbBoxTelNoGidenHat2.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                            cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGidenHat2);

                            if (cmbBoxTelNoGidenHat1.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];

                                cc.sendIpSantralForwardService(ipAddress.ToString(), cmbBoxTelNoGidenHat1.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat1.Text.Split('~')[0], cmbBoxTelNoGidenHat2.Text.Split('~')[0], "16");
                            }
                            else if (txtBoxTelNoGelenHat1.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), txtBoxTelNoGelenHat1.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat1.Text.Split('~')[0], cmbBoxTelNoGidenHat2.Text.Split('~')[0], "16");
                            }
                        }
                        else if (txtBoxTelNoGelenHat2.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                            cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGelenHat2);

                            if (cmbBoxTelNoGidenHat1.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), cmbBoxTelNoGidenHat1.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat1.Text.Split('~')[0], txtBoxTelNoGelenHat2.Text.Split('~')[0], "16");
                            }
                            else if (txtBoxTelNoGelenHat1.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), txtBoxTelNoGelenHat1.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat1.Text.Split('~')[0], txtBoxTelNoGelenHat2.Text.Split('~')[0], "16");
                            }
                        }
                    }
                    else if (konferansaEkleHat1i)
                    {
                        if (cmbBoxTelNoGidenHat2.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                            cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGidenHat2);

                            if (cmbBoxTelNoGidenHat1.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat2.Text.Split('~')[0], ipAddress.ToString(), cmbBoxTelNoGidenHat1.Text.Split('~')[0], "20");
                            }
                            else if (txtBoxTelNoGelenHat1.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat2.Text.Split('~')[0], ipAddress.ToString(), txtBoxTelNoGelenHat1.Text.Split('~')[0], "20");
                            }
                        }
                        else if (txtBoxTelNoGelenHat2.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                            cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGelenHat2);

                            if (cmbBoxTelNoGidenHat1.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat2.Text.Split('~')[0], ipAddress.ToString(), cmbBoxTelNoGidenHat1.Text.Split('~')[0], "20");
                            }
                            else if (txtBoxTelNoGelenHat1.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat2.Text.Split('~')[0], ipAddress.ToString(), txtBoxTelNoGelenHat1.Text.Split('~')[0], "20");
                            }
                        }
                    }
                    else
                    {
                        xtraTabHatlar.SelectedTabPage = xtraTabHat2;
                        if (cmbBoxTelNoGidenHat2.Text != "")
                        {
                            cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGidenHat2);
                        }
                        else if (txtBoxTelNoGelenHat2.Text != "")
                        {
                            cc.selectTabPage(tbControlCagriBilgileriHat2, tbPageGelenHat2);
                        }
                    }

                    break;

                default:

                    if (yonlendirHat2i)
                    {
                        if (cmbBoxTelNoGidenHat1.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGiden);

                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), cmbBoxTelNoGidenHat2.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat2.Text.Split('~')[0], cmbBoxTelNoGidenHat1.Text.Split('~')[0], "16");
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), txtBoxTelNoGelenHat2.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat2.Text.Split('~')[0], cmbBoxTelNoGidenHat1.Text.Split('~')[0], "16");
                            }
                        }
                        else if (txtBoxTelNoGelenHat1.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];

                                cc.sendIpSantralForwardService(ipAddress.ToString(), cmbBoxTelNoGidenHat2.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat2.Text.Split('~')[0], txtBoxTelNoGelenHat1.Text.Split('~')[0], "16");
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(ipAddress.ToString(), txtBoxTelNoGelenHat2.Text.Split('~')[0], "10");
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat2.Text.Split('~')[0], txtBoxTelNoGelenHat1.Text.Split('~')[0], "16");
                            }
                        }
                    }
                    else if (konferansaEkleHat2i)
                    {
                        if (cmbBoxTelNoGidenHat1.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGiden);

                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat1.Text.Split('~')[0], ipAddress.ToString(), cmbBoxTelNoGidenHat2.Text.Split('~')[0], "20");
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(cmbBoxTelNoGidenHat1.Text.Split('~')[0], ipAddress.ToString(), txtBoxTelNoGelenHat2.Text.Split('~')[0], "20");
                            }
                        }
                        else if (txtBoxTelNoGelenHat1.Text != "")
                        {
                            xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                            if (cmbBoxTelNoGidenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat1.Text.Split('~')[0], ipAddress.ToString(), cmbBoxTelNoGidenHat2.Text.Split('~')[0], "20");
                            }
                            else if (txtBoxTelNoGelenHat2.Text != "")
                            {
                                string strHostName = System.Net.Dns.GetHostName();
                                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                                IPAddress ipAddress = ipHostInfo.AddressList[0];
                                cc.sendIpSantralForwardService(txtBoxTelNoGelenHat1.Text.Split('~')[0], ipAddress.ToString(), txtBoxTelNoGelenHat2.Text.Split('~')[0], "20");
                            }
                        }
                    }
                    else
                    {
                        xtraTabHatlar.SelectedTabPage = xtraTabHat1;
                        if (cmbBoxTelNoGidenHat1.Text != "")
                        {
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGiden);
                        }
                        else if (txtBoxTelNoGelenHat1.Text != "")
                        {
                            cc.selectTabPage(tbControlCagriBilgileriHat1, tbPageGelen);
                        }
                    }

                    break;
            }
        }

        private void poliçeBilgileriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmPoliceHasarGirisEkran policeHasar = new AdimAdimDavaKaydi.GirisEkran.rFrmPoliceHasarGirisEkran();
            policeHasar.Show();
        }

        private void rdButtonHarici_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdButton = (sender as RadioButton);
            System.Windows.Forms.ComboBox _cmbBoxTelNoGiden;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;
            RadioButton _rdButtonDahili;
            RadioButton _rdButtonHarici;
            SearchLookUpEdit _SlueArananGiden;
            Button _btnGidenBul;
            TabControl _tbcontrol;
            TabPage _tbpageGelen;
            TabPage _tbpageTutanak;
            TabPage _tbpageEski;
            TabPage _tbpageHesap;

            SlueArananGidenHat1.Properties.DataSource = new DataTable();
            SlueArananGidenHat2.Properties.DataSource = new DataTable();

            gridControlGelenHat1.DataSource = new DataTable();
            gridControlGidenHat1.DataSource = new DataTable();

            switch (rdButton.Name)
            {
                case "rdButtonHariciHat1":

                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;
                    _SlueArananGiden = SlueArananGidenHat1;
                    _btnGidenBul = btnGidenBulHat1;
                    _tbcontrol = tbControlCagriBilgileriHat1;
                    _tbpageGelen = tbPageGelen;
                    _tbpageTutanak = tbPageGorusmeTutanagi;
                    _tbpageEski = tbPageEski;
                    _tbpageHesap = tbPageIcraHesapHat1;

                    break;

                case "rdButtonHariciHat2":
                    _txtBoxTcNo = txtBoxTcNoGidenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat2;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat2;
                    _rdButtonDahili = rdButtonDahiliHat2;
                    _rdButtonHarici = rdButtonHariciHat2;
                    _SlueArananGiden = SlueArananGidenHat2;
                    _btnGidenBul = btnGidenBulHat2;
                    _tbcontrol = tbControlCagriBilgileriHat2;
                    _tbpageGelen = tbPageGelenHat2;
                    _tbpageTutanak = tbPageGorusmeTutanagiHat2;
                    _tbpageEski = tbPageEskiGorusmelerHat2;
                    _tbpageHesap = tbPageIcraHesapHat2;
                    break;

                default:
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;
                    _SlueArananGiden = SlueArananGidenHat1;
                    _btnGidenBul = btnGidenBulHat1;
                    _tbcontrol = tbControlCagriBilgileriHat1;
                    _tbpageGelen = tbPageGelen;
                    _tbpageTutanak = tbPageGorusmeTutanagi;
                    _tbpageEski = tbPageEski;
                    _tbpageHesap = tbPageIcraHesapHat1;
                    break;
            }

            AVPCallCenter cc = new AVPCallCenter();
            cc.HideTabPage(_tbcontrol, _tbpageGelen);
            cc.HideTabPage(_tbcontrol, _tbpageTutanak);
            cc.HideTabPage(_tbcontrol, _tbpageEski);
            cc.HideTabPage(_tbcontrol, _tbpageHesap);
            _txtBoxTcNo.Text = "";
            _txtMusteriNo.Text = "";
            _cmbBoxTelNoGiden.Items.Clear();
            foreach (var item in _cmbBoxTelNoGiden.Items)
            {
                _cmbBoxTelNoGiden.Items.Remove(item);
            }

            _cmbBoxTelNoGiden.Text = "";
            _cmbBoxTelNoGiden.SelectedText = "";
            _cmbBoxTelNoGiden.SelectedItem = null;
            _cmbBoxTelNoGiden.Refresh();
            _SlueArananGiden.Text = "";
            _SlueArananGiden.Refresh();
            if (!_rdButtonHarici.Checked)
            {
                _btnGidenBul.Visible = false;
            }
            else
            {
                _btnGidenBul.Visible = true;
            }
        }

        private void sahisEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.CariGenelGiris);
        }

        private void satýþToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.SatisGirisEkran);
        }

        private void satisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Icra.frmSatisGirisi satisEkle = new AdimAdimDavaKaydi.Forms.Icra.frmSatisGirisi();
            satisEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
            satisEkle.IsModul = true;
            satisEkle.Show();
        }

        private void SetStyles()
        {
            if (AvukatProLib.Kimlik.Bilgi != null && String.IsNullOrEmpty(AvukatProLib.Kimlik.Bilgi.STYLE))
                AvukatProLib.Kimlik.Bilgi.STYLE = "Caramel";

            if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.STYLE == "EBEGUMECI")
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetFlatStyle();
            }
            else if (AvukatProLib.Kimlik.Bilgi != null && !String.IsNullOrEmpty(AvukatProLib.Kimlik.Bilgi.STYLE))
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(AvukatProLib.Kimlik.Bilgi.STYLE);

                // SimpleButton imageButton = new SimpleButton();
                foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
                {
                    ToolStripMenuItem titemStyle = new ToolStripMenuItem();
                    titemStyle.CheckOnClick = true;
                    titemStyle.Text = cnt.SkinName;
                    titemStyle.Tag = cnt.SkinName;
                    titemStyle.Checked = cnt.Loaded;
                    titemStyle.Click += titemStyle_Click;
                    mdiAvukatPro.MainForm.c_titemStiller.DropDownItems.Add(titemStyle);
                }
            }
        }

        private void sikKullanýlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.rfrmSikKullanilanlar frm = new rfrmSikKullanilanlar();
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void SlueArananGiden_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SearchLookUpEdit slue = (sender as DevExpress.XtraEditors.SearchLookUpEdit);
            System.Windows.Forms.ComboBox _cmbBoxTelNoGiden;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;
            RadioButton _rdButtonDahili;
            RadioButton _rdButtonHarici;

            switch (slue.Name)
            {
                case "SlueArananGidenHat1":
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;

                    break;

                case "SlueArananGidenHat2":
                    _txtBoxTcNo = txtBoxTcNoGidenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat2;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat2;
                    _rdButtonDahili = rdButtonDahiliHat2;
                    _rdButtonHarici = rdButtonHariciHat2;
                    break;

                default:
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;
                    break;
            }

            int _ID = 0;
            _txtBoxTcNo.Text = "";
            _txtMusteriNo.Text = "";
            _cmbBoxTelNoGiden.Items.Clear();
            foreach (var item in _cmbBoxTelNoGiden.Items)
            {
                _cmbBoxTelNoGiden.Items.Remove(item);
            }
            _cmbBoxTelNoGiden.Text = "";
            _cmbBoxTelNoGiden.SelectedText = "";
            _cmbBoxTelNoGiden.SelectedItem = null;
            _cmbBoxTelNoGiden.Refresh();
            if (_rdButtonDahili.Checked)
            {
                for (int rowHandle = 0; rowHandle < slue.Properties.View.RowCount; rowHandle++)
                {
                    if ((bool)slue.Properties.View.GetRowCellValue(rowHandle, "isSelected") == true)
                    {
                        try
                        {
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ1").ToString()) || slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ1").ToString() == null || slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ1").ToString() == "") ? "" : slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ1").ToString() + "~ Dahili1");
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ1").ToString()) || slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ2").ToString() == null || slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ2").ToString() == "") ? "" : slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ2").ToString() + "~ Dahili2");
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ1").ToString()) || slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ3").ToString() == null || slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ3").ToString() == "") ? "" : slue.Properties.View.GetRowCellValue(rowHandle, "DAHÝLÝ3").ToString() + "~ Dahili3");
                            int count = _cmbBoxTelNoGiden.Items.Count;
                            for (int i = 0; i < count; i++)
                            {
                                if (_cmbBoxTelNoGiden.Items[i].ToString().TrimEnd().TrimStart() == "")
                                {
                                    _cmbBoxTelNoGiden.Items.RemoveAt(i);
                                    i--;
                                    count--;
                                }
                            }

                            slue.Tag = Convert.ToInt32(slue.Properties.View.GetRowCellValue(rowHandle, "ID").ToString());
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            else if (_rdButtonHarici.Checked)
            {
                for (int rowHandle = 0; rowHandle < slue.Properties.View.RowCount; rowHandle++)
                {
                    if ((bool)slue.Properties.View.GetRowCellValue(rowHandle, "isSelected") == true)
                    {
                        try
                        {
                            _txtBoxTcNo.Text = slue.Properties.View.GetRowCellValue(rowHandle, "TC KÝMLÝK NO").ToString();
                            _txtMusteriNo.Text = slue.Properties.View.GetRowCellValue(rowHandle, "MÜÞTERÝ NO").ToString();
                            _ID = Convert.ToInt32(slue.Properties.View.GetRowCellValue(rowHandle, "ID").ToString());
                            AV001_TDI_BIL_CARI mycari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(_ID);

                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(mycari.TEL_1) || mycari.TEL_1 == null || mycari.TEL_1 == "") ? "" : mycari.TEL_1 + "~ Tel1");
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(mycari.TEL_2) || mycari.TEL_2 == null || mycari.TEL_2 == "") ? "" : mycari.TEL_2 + "~ Tel2");
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(mycari.CEP_TEL) || mycari.CEP_TEL == null || mycari.CEP_TEL == "") ? "" : mycari.CEP_TEL + "~ Cep Tel");
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(mycari.CEP_TEL2) || mycari.CEP_TEL2 == null || mycari.CEP_TEL2 == "") ? "" : mycari.CEP_TEL2 + "~ Cep Tel2");
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(mycari.EV_TEL) || mycari.EV_TEL == null || mycari.EV_TEL == "") ? "" : mycari.EV_TEL + "~ Ev Tel");
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(mycari.FAX) || mycari.FAX == null || mycari.FAX == "") ? "" : mycari.FAX + "~ Fax");
                            _cmbBoxTelNoGiden.Items.Add((DBNull.Value.Equals(mycari.EV_FAX) || mycari.EV_FAX == null || mycari.EV_FAX == "") ? "" : mycari.EV_FAX + "~ Ev Fax");

                            int count = _cmbBoxTelNoGiden.Items.Count;
                            for (int i = 0; i < count; i++)
                            {
                                if (_cmbBoxTelNoGiden.Items[i].ToString().TrimEnd().TrimStart() == "")
                                {
                                    _cmbBoxTelNoGiden.Items.RemoveAt(i);
                                    i--;
                                    count--;
                                }
                            }

                            slue.Tag = Convert.ToInt32(slue.Properties.View.GetRowCellValue(rowHandle, "ID").ToString());
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        private void SlueArananGiden_Enter(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SearchLookUpEdit lue = (sender as DevExpress.XtraEditors.SearchLookUpEdit);

            System.Windows.Forms.ComboBox _cmbBoxTelNoGiden;
            TextBox _txtMusteriNo;
            TextBox _txtBoxTcNo;
            RadioButton _rdButtonDahili;
            RadioButton _rdButtonHarici;

            switch (lue.Name)
            {
                case "SlueArananGidenHat1":
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;

                    break;

                case "SlueArananGidenHat2":
                    _txtBoxTcNo = txtBoxTcNoGidenHat2;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat2;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat2;
                    _rdButtonDahili = rdButtonDahiliHat2;
                    _rdButtonHarici = rdButtonHariciHat2;
                    break;

                default:
                    _txtBoxTcNo = txtBoxTcNoGidenHat1;
                    _txtMusteriNo = txtBoxMusteriNoGidenHat1;
                    _cmbBoxTelNoGiden = cmbBoxTelNoGidenHat1;
                    _rdButtonDahili = rdButtonDahiliHat1;
                    _rdButtonHarici = rdButtonHariciHat1;
                    break;
            }
            _txtBoxTcNo.Text = "";
            _txtMusteriNo.Text = "";

            _cmbBoxTelNoGiden.Text = "";
            _cmbBoxTelNoGiden.SelectedText = "";
            _cmbBoxTelNoGiden.SelectedItem = null;
            _cmbBoxTelNoGiden.Refresh();

            DataTable table = new DataTable();

            if (_rdButtonHarici.Checked)
            {
                #region harici

                List<per_CariKimlikIletisimBilgileri> myiletisim = DataRepository.per_CariKimlikIletisimBilgileriProvider.GetAll().ToList();

                #region
                //TextBox txtBox1 = new TextBox();
                //TextBox txtBox2 = new TextBox();
                //System.Windows.Forms.ComboBox cmBox1 = new System.Windows.Forms.ComboBox();
                //if (lue.Name == "SlueArananGidenHat1")
                //{
                //txtBox1 = txtBoxTcNoGidenHat1;
                //txtBox1.Text = "";
                //txtBox2 = txtBoxMusteriNoGidenHat1;
                //txtBox2.Text = "";
                //cmBox1 = cmbBoxTelNoGidenHat1;
                //cmBox1.Items.Clear();

                //}
                //else if (lue.Name == "Hat2Giden-SlueArananGidenHat1")
                //{
                //    foreach (Control item in tbControlCagriBilgileriHat2.Controls)
                //    {
                //        if (item is Panel)
                //        {
                //            foreach (Control item2 in item.Controls)
                //            {
                //                if (item2.Name == "Hat2Giden-txtBoxTcNoGidenHat1")
                //                {
                //                    ((TextBox)item2).Text = "";

                //                    txtBox1 = (TextBox)item2;

                //                }
                //                else if (item2.Name == "Hat2Giden-txtBoxMusteriNoGidenHat1")
                //                {
                //                    ((TextBox)item2).Text = "";
                //                    txtBox2 = (TextBox)item2;
                //                }
                //                else if (item2.Name == "Hat2Giden-cmbBoxTelNoGidenHat1")
                //                {
                //                    ((System.Windows.Forms.ComboBox)item2).Items.Clear();
                //                    cmBox1 = (System.Windows.Forms.ComboBox)item2;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if (item.Name == "Hat2Giden-txtBoxTcNoGidenHat1")
                //            {
                //                ((TextBox)item).Text = "";
                //                txtBox1 = (TextBox)item;
                //            }
                //            else if (item.Name == "Hat2Giden-txtBoxMusteriNoGidenHat1")
                //            {
                //                ((TextBox)item).Text = "";
                //                txtBox2 = (TextBox)item;
                //            }
                //            else if (item.Name == "Hat2Giden-cmbBoxTelNoGidenHat1")
                //            {
                //                ((System.Windows.Forms.ComboBox)item).Items.Clear();
                //                cmBox1 = (System.Windows.Forms.ComboBox)item;
                //            }
                //        }
                //    }

                //}

                #endregion harici

                table.Columns.Add("AD", typeof(string));
                table.Columns.Add("TC KÝMLÝK NO", typeof(string));
                table.Columns.Add("BABA ADI", typeof(string));
                table.Columns.Add("DOÐUM TARÝHÝ", typeof(string));
                table.Columns.Add("KIZLIK SOYADI", typeof(string));
                table.Columns.Add("MÜÞTERÝ NO", typeof(string));
                table.Columns.Add("VERGÝ NO", typeof(string));
                table.Columns.Add("VERGÝ DAÝRESÝ", typeof(string));
                table.Columns.Add("ÜNVAN", typeof(string));
                table.Columns.Add("ESKÝ ÜNVAN", typeof(string));
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("isSelected", typeof(bool));
                foreach (var item in myiletisim)
                {
                    DataRow workRow = table.NewRow();

                    workRow[0] = (DBNull.Value.Equals(item.AD) || item.AD == null) ? "" : item.AD.ToString();
                    workRow[1] = (DBNull.Value.Equals(item.TC_KIMLIK_NO) || item.TC_KIMLIK_NO == null) ? "" : item.TC_KIMLIK_NO.ToString();
                    workRow[2] = (DBNull.Value.Equals(item.BABA_ADI) || item.BABA_ADI == null) ? "" : item.BABA_ADI.ToString();
                    workRow[3] = (DBNull.Value.Equals(item.DOGUM_TARIHI) || item.DOGUM_TARIHI == null) ? "" : item.DOGUM_TARIHI.ToString();
                    workRow[4] = (DBNull.Value.Equals(item.ANNE_KIZLIK_SOYADI) || item.ANNE_KIZLIK_SOYADI == null) ? "" : item.ANNE_KIZLIK_SOYADI.ToString();
                    workRow[5] = (DBNull.Value.Equals(item.MUSTERI_NO) || item.MUSTERI_NO == null) ? "" : item.MUSTERI_NO.ToString();
                    workRow[6] = (DBNull.Value.Equals(item.VERGI_NO) || item.VERGI_NO == null) ? "" : item.VERGI_NO.ToString();
                    workRow[7] = (DBNull.Value.Equals(item.VERGI_DAIRESI) || item.VERGI_DAIRESI == null) ? "" : item.VERGI_DAIRESI.ToString();
                    workRow[8] = (DBNull.Value.Equals(item.UNVAN) || item.UNVAN == null) ? "" : item.UNVAN.ToString();
                    workRow[9] = (DBNull.Value.Equals(item.ESKI_UNVAN) || item.ESKI_UNVAN == null) ? "" : item.ESKI_UNVAN.ToString();
                    workRow[10] = (DBNull.Value.Equals(item.ID)) ? 0 : Convert.ToInt32(item.ID.ToString());
                    workRow[11] = false;
                    table.Rows.Add(workRow);
                }

                if (table.Rows.Count > 0)
                {
                    lue.Properties.NullText = SetNullText(sender);
                    lue.Properties.View.Columns.Clear();
                    lue.Properties.DataSource = table;
                    lue.Properties.View.Name = lue.Name + "_myview";
                    lue.Properties.DisplayMember = "AD";
                    lue.Properties.ValueMember = "ID";
                    lue.Properties.View.OptionsSelection.EnableAppearanceFocusedCell = false;
                    lue.Properties.View.OptionsView.ShowGroupPanel = true;
                    lue.Properties.View.OptionsBehavior.Editable = true;
                    lue.Properties.View.OptionsSelection.MultiSelect = false;
                    lue.Properties.View.OptionsView.ShowAutoFilterRow = true;
                    lue.Properties.View.OptionsView.ShowGroupedColumns = true;
                    lue.Properties.View.OptionsView.ShowGroupPanel = true;
                    lue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
                    lue.Properties.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(view1_RowClick);
                }

                #endregion Methods
            }
            else if (_rdButtonDahili.Checked)
            {
                #region dahili

                List<AV001_TDI_BIL_CARI> myiletisim = DataRepository.AV001_TDI_BIL_CARIProvider.GetAll().ToList();

                table.Columns.Add("AD", typeof(string));
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("DAHÝLÝ1", typeof(string));
                table.Columns.Add("DAHÝLÝ2", typeof(string));
                table.Columns.Add("DAHÝLÝ3", typeof(string));
                table.Columns.Add("isSelected", typeof(bool));

                foreach (var item in myiletisim)
                {
                    if (item.PERSONEL_MI)
                    {
                        DataRow workRow = table.NewRow();

                        workRow[0] = (DBNull.Value.Equals(item.AD) || item.AD == null) ? "" : item.AD.ToString();
                        workRow[1] = (DBNull.Value.Equals(item.ID)) ? 0 : Convert.ToInt32(item.ID.ToString());
                        workRow[2] = (DBNull.Value.Equals(item.DAHILI_1) || item.DAHILI_1 == null) ? "" : item.DAHILI_1.ToString();
                        workRow[3] = (DBNull.Value.Equals(item.DAHILI_2) || item.DAHILI_2 == null) ? "" : item.DAHILI_2.ToString();
                        workRow[4] = (DBNull.Value.Equals(item.DAHILI_3) || item.DAHILI_3 == null) ? "" : item.DAHILI_3.ToString();
                        workRow[5] = false;
                        table.Rows.Add(workRow);
                    }
                }

                if (table.Rows.Count > 0)
                {
                    lue.Properties.NullText = SetNullText(sender);
                    lue.Properties.View.Columns.Clear();
                    lue.Properties.DataSource = table;
                    lue.Properties.View.Name = lue.Name + "_myview";
                    lue.Properties.DisplayMember = "AD";
                    lue.Properties.ValueMember = "ID";
                    lue.Properties.View.OptionsSelection.EnableAppearanceFocusedCell = false;
                    lue.Properties.View.OptionsView.ShowGroupPanel = true;
                    lue.Properties.View.OptionsBehavior.Editable = true;
                    lue.Properties.View.OptionsSelection.MultiSelect = false;
                    lue.Properties.View.OptionsView.ShowAutoFilterRow = true;
                    lue.Properties.View.OptionsView.ShowGroupedColumns = true;
                    lue.Properties.View.OptionsView.ShowGroupPanel = true;
                    lue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
                    lue.Properties.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(view1_RowClick);
                }

                #endregion dahili
            }
        }

        private void SlueArayanGelen_Enter_gon(object sender, string TelNo, EventArgs e)
        {
            DevExpress.XtraEditors.SearchLookUpEdit lue = (sender as DevExpress.XtraEditors.SearchLookUpEdit);

            DataTable table = new DataTable();

            table.Columns.Add("AD", typeof(string));
            table.Columns.Add("TC KÝMLÝK NO", typeof(string));
            table.Columns.Add("BABA ADI", typeof(string));
            table.Columns.Add("DOÐUM TARÝHÝ", typeof(string));
            table.Columns.Add("KIZLIK SOYADI", typeof(string));
            table.Columns.Add("MÜÞTERÝ NO", typeof(string));
            table.Columns.Add("VERGÝ NO", typeof(string));
            table.Columns.Add("VERGÝ DAÝRESÝ", typeof(string));
            table.Columns.Add("ÜNVAN", typeof(string));
            table.Columns.Add("ESKÝ ÜNVAN", typeof(string));
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("isSelected", typeof(bool));

            List<per_CariKimlikIletisimBilgileri> myiletisim = DataRepository.per_CariKimlikIletisimBilgileriProvider.GetAll().ToList();

            AvukatProLib.CompInfo smtpInfo = CompInfo.CmpNfoList[0];

            SqlConnection cnn = new SqlConnection(smtpInfo.ConStr);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID FROM dbo.AV001_TDI_BIL_CARI WHERE  TEL_1='" + TelNo + "'OR TEL_2='" + TelNo + "'OR FAX='" + TelNo + "'OR CEP_TEL='" + TelNo + "'OR CEP_TEL2='" + TelNo + "'OR EV_TEL='" + TelNo + "' OR EV_FAX='" + TelNo + "'  ", cnn);
            //SqlCommand cmd = new SqlCommand("SELECT s.DAHILI_1,s.DAHILI_2,s.DAHILI_3,s.ID,t.ID FROM dbo.AV001_TDI_BIL_CARI  s inner join dbo.AV001_TDI_BIL_CARI t on s.ID=t.BAGLI_OLDUGU_YETKILI_CARI_ID WHERE  t.TEL_1='" + TelNo + "'OR t.TEL_2='" + TelNo + "'OR t.FAX='" + TelNo + "'OR t.CEP_TEL='" + TelNo + "'OR t.CEP_TEL2='" + TelNo + "'OR t.EV_TEL='" + TelNo + "' OR t.EV_FAX='" + TelNo + "'  ", cnn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                foreach (var item in myiletisim)
                {
                    if (item.ID == Convert.ToInt32(dr[0].ToString()))
                    {
                        DataRow workRow = table.NewRow();

                        workRow[0] = (DBNull.Value.Equals(item.AD) || item.AD == null) ? "" : item.AD.ToString();
                        workRow[1] = (DBNull.Value.Equals(item.TC_KIMLIK_NO) || item.TC_KIMLIK_NO == null) ? "" : item.TC_KIMLIK_NO.ToString();
                        workRow[2] = (DBNull.Value.Equals(item.BABA_ADI) || item.BABA_ADI == null) ? "" : item.BABA_ADI.ToString();
                        workRow[3] = (DBNull.Value.Equals(item.DOGUM_TARIHI) || item.DOGUM_TARIHI == null) ? "" : item.DOGUM_TARIHI.ToString();
                        workRow[4] = (DBNull.Value.Equals(item.ANNE_KIZLIK_SOYADI) || item.ANNE_KIZLIK_SOYADI == null) ? "" : item.ANNE_KIZLIK_SOYADI.ToString();
                        workRow[5] = (DBNull.Value.Equals(item.MUSTERI_NO) || item.MUSTERI_NO == null) ? "" : item.MUSTERI_NO.ToString();
                        workRow[6] = (DBNull.Value.Equals(item.VERGI_NO) || item.VERGI_NO == null) ? "" : item.VERGI_NO.ToString();
                        workRow[7] = (DBNull.Value.Equals(item.VERGI_DAIRESI) || item.VERGI_DAIRESI == null) ? "" : item.VERGI_DAIRESI.ToString();
                        workRow[8] = (DBNull.Value.Equals(item.UNVAN) || item.UNVAN == null) ? "" : item.UNVAN.ToString();
                        workRow[9] = (DBNull.Value.Equals(item.ESKI_UNVAN) || item.ESKI_UNVAN == null) ? "" : item.ESKI_UNVAN.ToString();
                        workRow[10] = (DBNull.Value.Equals(item.ID)) ? 0 : Convert.ToInt32(item.ID.ToString());
                        workRow[11] = false;
                        table.Rows.Add(workRow);
                    }
                }
            }
            if (table.Rows.Count > 0)
            {
                lue.Properties.NullText = SetNullText(sender);
                lue.Properties.View.Columns.Clear();
                lue.Properties.DataSource = table;
                lue.Properties.View.Name = lue.Name + "_myview1";
                lue.Properties.DisplayMember = "AD";
                lue.Properties.ValueMember = "ID";
                lue.Properties.View.OptionsSelection.EnableAppearanceFocusedCell = false;
                lue.Properties.View.OptionsView.ShowGroupPanel = true;
                lue.Properties.View.OptionsBehavior.Editable = true;
                lue.Properties.View.OptionsSelection.MultiSelect = false;
                lue.Properties.View.OptionsView.ShowAutoFilterRow = true;
                lue.Properties.View.OptionsView.ShowGroupedColumns = true;
                lue.Properties.View.OptionsView.ShowGroupPanel = true;
                lue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
                lue.Properties.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(view1_RowClick);
            }
        }

        private void standartYazýþmalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.AdimAdimEditoreGonder);
        }

        private void þirketDeðiþtirToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void taahhütBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.TaahhutBilgileriGirisEkran);
        }

        private void tabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabWindowToolStripMenuItem.Checked)
            {
                xtraTabbedMdiManager1.MdiParent = this;
            }
            else
            {
                xtraTabbedMdiManager1.MdiParent = null;
            }
        }

        private void tahsilatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmShowTahsilatXML frm = new AdimAdimDavaKaydi.Entegrasyon.frmShowTahsilatXML();
            frm.Show();
        }

        private void tapuBilgisindenBulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.GayrimenkulGirisEkran);
        }

        private void tarafGeliþmeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmIcraTarafGelismeAramaEkran icraTarafGelismeAra = new AdimAdimDavaKaydi.GirisEkran.rFrmIcraTarafGelismeAramaEkran();
            icraTarafGelismeAra.Show();
        }

        private void tbControlCagriBilgileri_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tbPageGiden_Click(object sender, EventArgs e)
        {
        }

        private void teminatMektuplarýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTeminatMektupExpres teminatMektup = new frmTeminatMektupExpres();
            teminatMektup.Show();
        }

        private void temyizEdilenDosyalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTemyizEdilenDosyalar frmkr = new frmTemyizEdilenDosyalar() { StartPosition = FormStartPosition.CenterScreen, WindowState = FormWindowState.Maximized, MdiParent = this };
            frmkr.Show();
        }

        private void ticariKredilerTakipliAlacaklarÝçinRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvukatProRaporlar.Forms.frmDonemselRaporSihirbaz.ShowWizard(2);
        }

        private void ticariRiskRaporuDosyadanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTicariRiskRaporuDosya frmm = new frmTicariRiskRaporuDosya();
            frmm.MdiParent = this;
            frmm.Show();
        }

        private void ticariRiskRaporuEntegreliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTicariRiskRaporu frmm = new frmTicariRiskRaporu();
            frmm.MdiParent = this;
            frmm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void titemStyle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mdiAvukatPro.MainForm.c_titemStiller.DropDownItems.Count; i++)
            {
                ((ToolStripMenuItem)mdiAvukatPro.MainForm.c_titemStiller.DropDownItems[i]).Checked = false;
            }
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem titem = (ToolStripMenuItem)sender;
                titem.Checked = true;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(titem.Text);

                AvukatProLib.Kimlik.Bilgi.STYLE = titem.Text;
                AvukatProLib2.Data.DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(AvukatProLib.Kimlik.Bilgi);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmShowXMLKrediKartlari frm = new AdimAdimDavaKaydi.Entegrasyon.frmShowXMLKrediKartlari();
            frm.Show();
        }

        private void toplantilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GirisEkran.rFrmYapilcakIsAramaEkran isArama = new AdimAdimDavaKaydi.GirisEkran.rFrmYapilcakIsAramaEkran();
            isArama.HizliErisimdenMi = true;
            isArama.ToplantiMi = true;
            isArama.Show();
        }

        private void toplantiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Is.Forms.frmIsKayitUfak toplanti = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            toplanti.StartPosition = FormStartPosition.WindowsDefaultLocation;
            toplanti.Show();
        }

        private void topluYazýþmaVeUYAPEditörüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.AdimAdimEditoreGonder);
        }

        private void txtBoxTelNoGelenHat1_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxTelNoGelenHat1.Text.Length > 10)
            {
                SlueArayanGelen_Enter(SlueArayanGelenHat1, new EventArgs());
                hat1Dolumu = true;
            }
        }

        private void txtBoxTelNoGelenHat2_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxTelNoGelenHat2.Text.Length > 10)
            {
                SlueArayanGelen_Enter(SlueArayanGelenHat2, new EventArgs());
                hat2Dolumu = true;
            }
        }

        private void txtYapilacakIsler_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as DevExpress.XtraEditors.TextEdit).Tag != null)
            {
                AV001_TI_BIL_FOY_TARAF taraf = (AV001_TI_BIL_FOY_TARAF)(sender as DevExpress.XtraEditors.TextEdit).Tag;

                IcraTakipForms.frmIcraTarafGelismeler frm = new AdimAdimDavaKaydi.IcraTakipForms.frmIcraTarafGelismeler();
                var tarafIcra = (sender as DevExpress.XtraEditors.TextEdit).Tag as AV001_TI_BIL_FOY_TARAF;
                frm.CurrentCariID = tarafIcra.CARI_ID;
                if (tarafIcra.ICRA_FOY_ID.HasValue)
                    frm.MyFoy = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tarafIcra.ICRA_FOY_ID.Value);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        private void ucretlendirilmisIslerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.GirisEkran.frmIsSurecArama arama = new AdimAdimDavaKaydi.GirisEkran.frmIsSurecArama();
            arama.Show();
        }

        private void urunAktivasyonuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AvukatProLib.LisansYonetimi.frmLicenseActivation licenseActivation =
            //    new AvukatProLib.LisansYonetimi.frmLicenseActivation(AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi.ProductKey);
            //licenseActivation.ShowDialog();

            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];

            bool sonuc = false;
            frmSetLicence frmli = new frmSetLicence(cmpNfo, sonuc);
            frmli.ShowDialog();
        }

        private void vekaletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mdiAvukatPro.MainForm.OpenForm(AvukatProLib.Extras.FormType.TemsilKayit);
        }

        private void xtraTabHatlar_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
        }

        private void yatayYerlestirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void yedekDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYedek frm = new frmYedek();
            frm.Show();
        }

        private void yeniÝþTanýmlamaEkranýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(AvukatProLib.Extras.FormType.IsParamEkle);
        }

        #endregion Methods

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(Path.Combine(Application.StartupPath, "iskayit.avpis")))
            {
                System.Threading.Thread.Sleep(1000);
                var file = File.ReadAllText(Path.Combine(Application.StartupPath, "iskayit.avpis"));
                try
                {
                    File.Delete(Path.Combine(Application.StartupPath, "iskayit.avpis"));
                }
                catch { }
                AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                        new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak() { WindowState = FormWindowState.Maximized };

                AV001_TDI_BIL_IS acilacakis = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(int.Parse((file)));
                frmisKayit.Record = acilacakis;

                //frmisKayit.MdiParent = null;
                frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmisKayit.Show();
            }
            if (File.Exists(Path.Combine(Application.StartupPath, "belgekayit.avpis")))
            {
                System.Threading.Thread.Sleep(1000);
                var file = File.ReadAllLines(Path.Combine(Application.StartupPath, "belgekayit.avpis"));
                try
                {
                    File.Delete(Path.Combine(Application.StartupPath, "belgekayit.avpis"));
                }
                catch { }
                AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak frmBelgeKayitUfakf =
                        new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();
                frmBelgeKayitUfakf.FileName = file.ToList();
                frmBelgeKayitUfakf.MdiParent = this;
                //frmisKayit.MdiParent = null;
                frmBelgeKayitUfakf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmBelgeKayitUfakf.Show();
            }

            if (File.Exists(Path.Combine(Application.StartupPath, "evrakkayit.avpis")))
            {
                System.Threading.Thread.Sleep(1000);
                var file = File.ReadAllLines(Path.Combine(Application.StartupPath, "evrakkayit.avpis"));
                try
                {
                    File.Delete(Path.Combine(Application.StartupPath, "evrakkayit.avpis"));
                }
                catch { }
                AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit_exp frmBelgeKayitUfakf =
                        new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit_exp();
                frmBelgeKayitUfakf.FileName = file.ToList();
                frmBelgeKayitUfakf.MdiParent = this;
                //frmisKayit.MdiParent = null;
                frmBelgeKayitUfakf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmBelgeKayitUfakf.Show();
            }
        }

        #region Menu Item Click
        #endregion Menu Item Click
    }
}