using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmDosyaKimlikBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmDosyaKimlikBilgileri()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += new EventHandler(frmDosyaKimlikBilgileri_Load);
        }

        private AV001_TD_BIL_FOY _MyDavaFoy;

        private AV001_TI_BIL_FOY _MyIcraFoy;

        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return _MyDavaFoy; }
            set
            {
                _MyDavaFoy = value;
                if (value != null)
                {
                    if (value != null)
                    {
                        colADLI_BIRIM_NO_ID.Caption = "Mahkeme Şubesi";
                        colADLI_BIRIM_GOREV_ID.Caption = "Mahkeme Adı";
                        colESAS_NO.FieldName = "ESKI_DAVA_DOSYA_NO";

                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DUSME_YENILEME>));
                        bndEskiBilgiler.DataSource = value.AV001_TD_BIL_DUSME_YENILEMECollection;
                    }
                }
            }
        }

        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return _MyIcraFoy; }
            set
            {
                _MyIcraFoy = value;
                if (value != null)
                {
                    colADLI_BIRIM_NO_ID.Caption = "İcra Şubesi";
                    colADLI_BIRIM_GOREV_ID.Caption = "İcra Dairesi Adı";
                    colESAS_NO.FieldName = "ESKI_ICRA_DOSYA_NO";

                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_DUSME_YENILEME>));
                    bndEskiBilgiler.DataSource = value.AV001_TI_BIL_DUSME_YENILEMECollection;
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foy)
        {
            this.MyIcraFoy = foy;
            this.Show();
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            this.MyDavaFoy = foy;
            this.Show();
        }

        private void BindLookUps()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(lueNo);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(lueGorev);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            BelgeUtil.Inits.DusmeYenilemeNedeniGetir(lueDegisimNedeni);
            BelgeUtil.Inits.DusmeYenilemeNedeniGetir(rlueDegisimNedeni);
        }

        private void frmDosyaKimlikBilgileri_Button_Kaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        private void frmDosyaKimlikBilgileri_Load(object sender, EventArgs e)
        {
            BindLookUps();
        }

        private void InitializeEvents()
        {
            this.Button_Kaydet_Click += new EventHandler<EventArgs>(frmDosyaKimlikBilgileri_Button_Kaydet_Click);
        }

        private void Kaydet()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            #region İcra

            if (MyIcraFoy != null)
            {
                //Eski Bilgiler
                AV001_TI_BIL_DUSME_YENILEME eskiBilgileriIcra = MyIcraFoy.AV001_TI_BIL_DUSME_YENILEMECollection.AddNew();
                eskiBilgileriIcra.ICRA_FOY_ID = MyIcraFoy.ID;
                eskiBilgileriIcra.ADLI_BIRIM_ADLIYE_ID = MyIcraFoy.ADLI_BIRIM_ADLIYE_ID;
                eskiBilgileriIcra.ADLI_BIRIM_NO_ID = MyIcraFoy.ADLI_BIRIM_NO_ID;
                eskiBilgileriIcra.ADLI_BIRIM_GOREV_ID = MyIcraFoy.ADLI_BIRIM_GOREV_ID;
                eskiBilgileriIcra.ESKI_ICRA_DOSYA_NO = MyIcraFoy.ESAS_NO;
                if (lueDegisimNedeni.EditValue != null)
                    eskiBilgileriIcra.DUSME_DEGISME_KODU_ID = (int?)lueDegisimNedeni.EditValue;

                //Yeni Bilgiler
                if (lueAdliye.EditValue != null)
                    MyIcraFoy.ADLI_BIRIM_ADLIYE_ID = (int)lueAdliye.EditValue;
                if (lueNo.EditValue != null)
                    MyIcraFoy.ADLI_BIRIM_NO_ID = (int)lueNo.EditValue;
                if (lueGorev.EditValue != null)
                    MyIcraFoy.ADLI_BIRIM_GOREV_ID = (int)lueGorev.EditValue;
                if (!string.IsNullOrEmpty(txtEsasNo.Text))
                    MyIcraFoy.ESAS_NO = txtEsasNo.Text;

                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(tran, MyIcraFoy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_DUSME_YENILEME>));
                    tran.Commit();
                    MessageBox.Show("Kayıt Tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bndEskiBilgiler.DataSource = MyIcraFoy.AV001_TI_BIL_DUSME_YENILEMECollection;
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();

                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }

            #endregion İcra

            #region Dava

            else if (MyDavaFoy != null)
            {
                //Eski Bilgiler
                AV001_TD_BIL_DUSME_YENILEME eskiBilgilerDava = MyDavaFoy.AV001_TD_BIL_DUSME_YENILEMECollection.AddNew();
                eskiBilgilerDava.DAVA_FOY_ID = MyDavaFoy.ID;
                eskiBilgilerDava.ADLI_BIRIM_ADLIYE_ID = MyDavaFoy.ADLI_BIRIM_ADLIYE_ID;
                eskiBilgilerDava.ADLI_BIRIM_NO_ID = MyDavaFoy.ADLI_BIRIM_NO_ID;
                eskiBilgilerDava.ADLI_BIRIM_GOREV_ID = MyDavaFoy.ADLI_BIRIM_GOREV_ID;
                eskiBilgilerDava.ESKI_DAVA_DOSYA_NO = MyDavaFoy.ESAS_NO;
                if (lueDegisimNedeni.EditValue != null)
                    eskiBilgilerDava.DUSME_DEGISME_KODU_ID = (int?)lueDegisimNedeni.EditValue;

                //Yeni Bilgiler
                if (lueAdliye.EditValue != null)
                    MyDavaFoy.ADLI_BIRIM_ADLIYE_ID = (int)lueAdliye.EditValue;
                if (lueNo.EditValue != null)
                    MyDavaFoy.ADLI_BIRIM_NO_ID = (int)lueNo.EditValue;
                if (lueGorev.EditValue != null)
                    MyDavaFoy.ADLI_BIRIM_GOREV_ID = (int)lueGorev.EditValue;
                if (!string.IsNullOrEmpty(txtEsasNo.Text))
                    MyDavaFoy.ESAS_NO = txtEsasNo.Text;

                try
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepSave(tran, MyDavaFoy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_DUSME_YENILEME>));
                    tran.Commit();
                    MessageBox.Show("Kayıt Tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bndEskiBilgiler.DataSource = MyDavaFoy.AV001_TD_BIL_DUSME_YENILEMECollection;
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();

                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }

            #endregion Dava
        }
    }
}