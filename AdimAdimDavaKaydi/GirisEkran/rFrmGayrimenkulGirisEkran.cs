using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmGayrimenkulGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private string Ada;

        private string Adres;

        private int? BelediyeID;

        private string Bucak;

        private int? IlceID;

        private int? IlID;

        private string Koy;

        private string Mahalle;

        private TList<AV001_TI_BIL_GAYRIMENKUL> MyDataSource = new TList<AV001_TI_BIL_GAYRIMENKUL>();

        private string Niteligi;

        private string Pafta;

        private string Parsel;

        private int? TapuID;

        private DateTime? Tarih;

        public rFrmGayrimenkulGirisEkran()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public void GayrimenkulDoldur()
        {
            MyDataSource = new TList<AV001_TI_BIL_GAYRIMENKUL>();
            DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(MyDataSource, true, DeepLoadType.IncludeChildren,
                                                                     typeof(AV001_TI_BIL_FOY));
            ucGayrimenkulGiris1.MyDataSource = MyDataSource;
        }

        public void GemiUcakAracKaydet()
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
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepSave(tran, MyDataSource);
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

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Editor_Click += barButtonItem18_ItemClick;
            this.Button_Excel_Click += barButtonItem21_ItemClick;
            this.Button_Word_Click += barButtonItem19_ItemClick;
            this.Button_Outlook_Click += barButtonItem20_ItemClick;
            this.Button_PDF_Click += barButtonItem22_ItemClick;
            this.Button_Kaydet_Click += barButtonItem3_ItemClick;
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
            //KAYDET
            GemiUcakAracKaydet();
        }

        private void dtTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih.EditValue != null)
                Tarih = (DateTime?)dtTarih.EditValue;
            else
                Tarih = null;
        }

        private void gLueIcraFoy_EditValueChanged(object sender, EventArgs e)
        {
            //EDITVALUECHANGED
            AV001_TI_BIL_FOY foy =
                DataRepository.AV001_TI_BIL_FOYProvider.GetByID(
                    (gLueIcraFoy.Properties.View.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama).ID);
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                                typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));

            //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(foy.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_ICRA_GAYRIMENKUL, false, DeepLoadType.IncludeChildre);
            ucGayrimenkulGiris1.MyDataSource = foy.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_ICRA_GAYRIMENKUL;
        }

        private void lueBelediyeID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBelediyeID.EditValue != null)
                BelediyeID = (int)lueBelediyeID.EditValue;
            else
                BelediyeID = null;
        }

        private void lueIlce_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIlce.EditValue != null)
                IlceID = (int)lueIlce.EditValue;
            else
                IlceID = null;
        }

        private void lueIlID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIlID.EditValue != null)
            {
                IlID = (int)lueIlID.EditValue;
                BelgeUtil.Inits.IlceGetirIleGore(lueIlce.Properties, IlID.Value);
            }
            else
                IlID = null;
        }

        private void lueTapuID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTapuID.EditValue != null)
                TapuID = (int)lueTapuID.EditValue;
            else
                TapuID = null;
        }

        private void rFrmGayrimenkulGirisEkran_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            GayrimenkulDoldur();

            //Lookup'larýn týklandýðýnda doldurulmasý.

            lueIlID.Properties.NullText = "Seç";
            lueIlID.Enter += delegate { BelgeUtil.Inits.IlGetir(lueIlID); };

            lueIlce.Properties.NullText = "Seç";
            lueIlce.Enter += delegate { BelgeUtil.Inits.IlceGetirTumu(lueIlce); };

            lueTapuID.Properties.NullText = "Seç";
            lueTapuID.Enter += delegate { BelgeUtil.Inits.TapuMudurlukGetir(lueTapuID.Properties); };

            lueBelediyeID.Properties.NullText = "Seç";
            lueBelediyeID.Enter += delegate { BelgeUtil.Inits.BelediyeGetirTumu(lueBelediyeID.Properties); };

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);

            gLueIcraFoy.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            gLueIcraFoy.Properties.DisplayMember = "FOY_NO";
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            sbtnSorgula.Enabled = false;
            TList<AV001_TI_BIL_GAYRIMENKUL> GayrimenkulList = new TList<AV001_TI_BIL_GAYRIMENKUL>();

            GayrimenkulList = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetByFiltre(Tarih, IlID, IlceID, Bucak,
                                                                                          Mahalle, Koy, null, null,
                                                                                          Pafta, Ada, Parsel, null, null,
                                                                                          null, null, null, null, null,
                                                                                          Niteligi, null, null, null,
                                                                                          null, Adres, TapuID,
                                                                                          BelediyeID);


            //GayrimenkulList = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetByFiltre(Tarih, IlID, IlceID, (Bucak == null ? "" : Bucak),
            //                                                                              (Mahalle == null ? "" : Mahalle), (Koy == null ? "" : Koy), "", "",
            //                                                                              (Pafta == null ? "" : Pafta), (Ada == null ? "" : Ada), (Parsel == null ? "" : Parsel), "", "",
            //                                                                              "", "", "", "", "",
            //                                                                              (Niteligi == null ? "" : Niteligi), "", "", "",
            //                                                                              "", (Adres == null ? "" : Adres), TapuID,
            //                                                                              BelediyeID);
            

            ucGayrimenkulGiris1.MyDataSource = GayrimenkulList;
            sbtnSorgula.Enabled = true;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(lCntrlGayrimenkul.Controls);
            ucGayrimenkulGiris1.MyDataSource = null;
        }

        private void txtAda_EditValueChanged(object sender, EventArgs e)
        {
            Ada = "%" + txtAda.Text + "%";
            if (txtAda.Text == string.Empty)
                Ada = null;
        }

        private void txtAdres_EditValueChanged(object sender, EventArgs e)
        {
            Adres = "%" + txtAdres.Text + "%";
            if (txtAdres.Text == string.Empty)
                Adres = null;
        }

        private void txtBucak_EditValueChanged(object sender, EventArgs e)
        {
            Bucak = "%" + txtBucak.Text + "%";
            if (txtBucak.Text == string.Empty)
                Bucak = null;
        }

        private void txtKoy_EditValueChanged(object sender, EventArgs e)
        {
            Koy = "%" + txtKoy.Text + "%";
            if (txtKoy.Text == string.Empty)
                Koy = null;
        }

        private void txtMahalle_EditValueChanged(object sender, EventArgs e)
        {
            Mahalle = "%" + txtMahalle.Text + "%";
            if (txtMahalle.Text == string.Empty)
                Mahalle = null;
        }

        private void txtNiteligi_EditValueChanged(object sender, EventArgs e)
        {
            Niteligi = "%" + txtNiteligi.Text + "%";
            if (txtNiteligi.Text == string.Empty)
                Niteligi = null;
        }

        private void txtPafta_EditValueChanged(object sender, EventArgs e)
        {
            Pafta = "%" + txtPafta.Text + "%";
            if (txtPafta.Text == string.Empty)
                Pafta = null;
        }

        private void txtParsel_EditValueChanged(object sender, EventArgs e)
        {
            Parsel = "%" + txtParsel.Text + "%";
            if (txtParsel.Text == string.Empty)
                Parsel = null;
        }
    }
}