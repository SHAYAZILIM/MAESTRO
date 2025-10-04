using AdimAdimDavaKaydi.Editor.Degiskenler.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmIcraOdemeBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIcraOdemeBilgileri()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private AV001_TI_BIL_FOY _myFoy;
        private AV001_TDIE_BIL_PROJE _MyProje;

        private TList<AV001_TI_BIL_BORCLU_ODEME> myDataSource;

        private TList<AV001_TDI_BIL_CARI> myTaraf;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_BORCLU_ODEME> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    myDataSource = value;

                    ucOdemeBilgileri2.MyDataSource = value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY myFoy
        {
            get { return _myFoy; }
            set
            {
                if (value != null)
                    BelgeUtil.Inits.AlacakNedenByFoy(value, ucOdemeBilgileri2.glueAlacakNeden);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return _MyProje; }
            set
            {
                if (value != null)
                    BelgeUtil.Inits.AlacakNedenByFoy(value, ucOdemeBilgileri2.glueAlacakNeden);

                _MyProje = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_CARI> MyTaraf
        {
            get { return myTaraf; }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    myTaraf = value;
                    ucOdemeBilgileri2.MyTarafList = value;
                }
            }
        }

        public void Show(TList<AV001_TI_BIL_BORCLU_ODEME> borcluOdemeCollection)
        {
            MyDataSource = borcluOdemeCollection;
            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY foy, TList<AV001_TDI_BIL_CARI> tumTaraflar)
        {
            MyDataSource = foy.AV001_TI_BIL_BORCLU_ODEMECollection;
            myFoy = foy;
            MyTaraf = tumTaraflar;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void Show(TList<AV001_TI_BIL_BORCLU_ODEME> borcluOdemeCollection, TList<AV001_TDI_BIL_CARI> tumTaraflar)
        {
            this.MyDataSource = borcluOdemeCollection;
            MyTaraf = tumTaraflar;
            this.Show();
        }

        public void ShowDialog(TList<AV001_TI_BIL_BORCLU_ODEME> borcluOdemeCollection)
        {
            MyDataSource = borcluOdemeCollection;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        public void ShowDialog(TList<AV001_TI_BIL_BORCLU_ODEME> borcluOdemeCollection,
                               TList<AV001_TDI_BIL_CARI> tumTaraflar, AV001_TI_BIL_FOY MyFoy)
        {
            myFoy = MyFoy;
            MyDataSource = borcluOdemeCollection;
            MyTaraf = tumTaraflar;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        public void ShowDialog(AV001_TI_BIL_FOY foy, TList<AV001_TDI_BIL_CARI> tumTaraflar)
        {
            MyDataSource = foy.AV001_TI_BIL_BORCLU_ODEMECollection;
            myFoy = foy;
            MyTaraf = tumTaraflar;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        private void frmIcraOdemeBilgileri_Button_Tamam_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Yap�lan De�i�iklikler kaydedildi...", "Bilgi", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);                
            }
            else
            {
                DialogResult dr = XtraMessageBox.Show("Bir hatayla kar��la��ld� ��kmak istiyormusunuz...", "Bilgi",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIcraOdemeBilgileri_Button_Tamam_Click;
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                #region <YY-20090615>

                //Projeyi kaydemesi i�in parametre eklendi.

                #endregion <YY-20090615>

                foreach (var item in myDataSource)
                {
                    //if (item.ALACAK_NEDEN_ID == 0)
                    //{
                    //    DialogResult dr =
                    //        XtraMessageBox.Show(
                    //            "Alacak Nedeni Se�erek �deme Kayd� Yapmak �stiyorsan�z �nce Dosyay� Kaydetmelisiniz." +
                    //            Environment.NewLine + "�deme Kayd�na Devam Etmek �stiyor musunuz?", "UYARI",
                    //            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    //    if (dr == DialogResult.Yes)
                    //    {
                    item.ALACAK_NEDEN_ID = null; //Kay�tta alacak nedeni se�tirilecek ama kayd� yapt�r�lmayacak. MB

                    trans.BeginTransaction();

                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(trans, item,
                                                                              DeepSaveType.IncludeChildren,
                                                                              typeof(
                                                                                  TList
                                                                                  <AV001_TI_BIL_BORCLU_ODEME>),
                                                                              typeof(
                                                                                  TList
                                                                                  <
                                                                                  AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME
                                                                                  >));

                    trans.Commit();

                    AvukatProLib.Hesap.MuhasebeAraclari.SetCariHesapByBorcluOdeme(item.ID);
                    Forms.frmKlasorYeni.OdemelerYuklendi = false;//�deme kayd�ndan sonra klas�rde t�m �demelerin refresh olmas� i�in eklendi. MB

                    //    }
                    //    else
                    //        return false;
                    //}
                    //else
                    //{
                    //    trans.BeginTransaction();

                    //    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(trans, item,
                    //                                                              DeepSaveType.IncludeChildren,
                    //                                                              typeof (
                    //                                                                  TList<AV001_TI_BIL_BORCLU_ODEME>),
                    //                                                              typeof (
                    //                                                                  TList
                    //                                                                  <
                    //                                                                  AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME
                    //                                                                  >));

                    //    trans.Commit();

                    //    AvukatProLib.Hesap.MuhasebeAraclari.SetCariHesapByBorcluOdeme(item.ID);
                    //}
                }
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }

            return true;
        }
    }
}