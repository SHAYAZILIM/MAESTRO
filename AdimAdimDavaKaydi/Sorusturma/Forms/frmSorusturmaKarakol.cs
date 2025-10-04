using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi.Sorusturma.Forms
{
    public partial class frmSorusturmaKarakol : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public int Tip;

        private bool kaydedildi;

        private TList<AV001_TD_BIL_HAZIRLIK_SUREC> myDatasource;

        private AV001_TD_BIL_HAZIRLIK mySorusturma;

        public frmSorusturmaKarakol()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += frmSorusturmaKarakol_FormClosing;
        }

        public event EventHandler<HazirlikSurecKaydedildiEventArgs> HazirlikSurecKaydedildi;

        public enum SurecTip
        {
            Karakol = 1,
            SorguMahkemesi = 3,
            Savcilik = 2
        }

        //void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        //{
        //}
        [Browsable(false)]
        public TList<AV001_TD_BIL_HAZIRLIK_SUREC> MyDataSource
        {
            get { return myDatasource; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myDatasource = value;

                    vgSorusturmaSurec.DataSource = value;
                    dataNavigatorExtended1.DataSource = value;
                    value.AddingNew += value_AddingNew;
                    FormBicilendir(Tip);

                    //DataRepository.AV001_TD_BIL_HAZIRLIK_SURECProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SUREC>));
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MySorusturma
        {
            get { return mySorusturma; }
            set
            {
                mySorusturma = value;

                if (value != null)
                {
                    if (MyDataSource == null)
                    {
                        MyDataSource = new TList<AV001_TD_BIL_HAZIRLIK_SUREC>();
                        MyDataSource.AddNew();
                    }

                    //MyDataSource.AddingNew += new AddingNewEventHandler(MyDataSource_AddingNew);
                    DataRepository.AV001_TD_BIL_HAZIRLIK_SURECProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SUREC>));
                }
            }
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmSorusturmaKarakol_Button_Kaydet_Click;
        }

        public bool Save()
        {
            bool sonuc = false;

            MyDataSource.ForEach(delegate(AV001_TD_BIL_HAZIRLIK_SUREC s) { s.HAZIRLIK_ID = MySorusturma.ID; });

            //MySorusturma.AV001_TD_BIL_HAZIRLIK_SURECCollection.AddRange(MyDataSource);

            foreach (var item in MyDataSource)
            {
                if (
                    MySorusturma.AV001_TD_BIL_HAZIRLIK_SURECCollection.Exists(
                        delegate(AV001_TD_BIL_HAZIRLIK_SUREC s) { return s.ID == item.ID; })) continue;
                MySorusturma.AV001_TD_BIL_HAZIRLIK_SURECCollection.Add(item);
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TD_BIL_HAZIRLIK_SURECProvider.DeepSave(trans, MySorusturma.AV001_TD_BIL_HAZIRLIK_SURECCollection, DeepSaveType.IncludeChildren);

                trans.Commit();

                foreach (var surc in MyDataSource)
                {
                    if (HazirlikSurecKaydedildi != null)
                        HazirlikSurecKaydedildi(this, new HazirlikSurecKaydedildiEventArgs(surc));
                }
                sonuc = true;
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < MyDataSource.Count; i++)
                {
                    MySorusturma.AV001_TD_BIL_HAZIRLIK_SURECCollection.Remove(MyDataSource[i]);
                }

                kaydedildi = false;

                return false;
            }

            finally
            {
                trans.Dispose();
            }

            return sonuc;
        }

        public void Show(TList<AV001_TD_BIL_HAZIRLIK_SUREC> list, int tip)
        {
            MyDataSource = list;
            Tip = tip;
            FormBicilendir(tip);
            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TD_BIL_HAZIRLIK_SUREC h in MyDataSource)
            {
                if (h.IsNew || h.IsDirty) return false;
            }

            return true;
        }

        private void FormBicilendir(int tip)
        {
            if (tip == (int)SurecTip.Karakol)
            {
                for (int i = 0; i <= vgSorusturmaSurec.Rows.Count; i++)
                {
                    if (vgSorusturmaSurec.Rows[i] is EditorRow)
                    {
                        if (vgSorusturmaSurec.Rows[i].Tag.ToString().Contains("K"))
                            vgSorusturmaSurec.Rows[i].Visible = true;
                        else
                            vgSorusturmaSurec.Rows[i].Visible = false;
                    }
                    else if (vgSorusturmaSurec.Rows[i] is MultiEditorRow)
                    {
                        if (vgSorusturmaSurec.Rows[i].Tag.ToString().Contains("K"))
                            vgSorusturmaSurec.Rows[i].Visible = true;
                        else
                            vgSorusturmaSurec.Rows[i].Visible = false;
                    }
                }
                return;
            }
            else if (tip == (int)SurecTip.Savcilik)
            {
                for (int i = 0; i <= vgSorusturmaSurec.Rows.Count; i++)
                {
                    if (vgSorusturmaSurec.Rows[i] is EditorRow)
                    {
                        if (vgSorusturmaSurec.Rows[i].Tag.ToString().Contains("S"))
                            vgSorusturmaSurec.Rows[i].Visible = true;
                        else
                            vgSorusturmaSurec.Rows[i].Visible = false;
                    }
                    else if (vgSorusturmaSurec.Rows[i] is MultiEditorRow)
                    {
                        if (vgSorusturmaSurec.Rows[i].Tag.ToString().Contains("S"))
                            vgSorusturmaSurec.Rows[i].Visible = true;
                        else
                            vgSorusturmaSurec.Rows[i].Visible = false;
                    }
                }
                return;
            }
            else if (tip == (int)SurecTip.SorguMahkemesi)
            {
                for (int i = 0; i <= vgSorusturmaSurec.Rows.Count; i++)
                {
                    if (vgSorusturmaSurec.Rows[i] is EditorRow)
                    {
                        if (vgSorusturmaSurec.Rows[i].Tag.ToString().Contains("M"))
                            vgSorusturmaSurec.Rows[i].Visible = true;
                        else
                            vgSorusturmaSurec.Rows[i].Visible = false;
                    }
                    else if (vgSorusturmaSurec.Rows[i] is MultiEditorRow)
                    {
                        if (vgSorusturmaSurec.Rows[i].Tag.ToString().Contains("M"))
                            vgSorusturmaSurec.Rows[i].Visible = true;
                        else
                            vgSorusturmaSurec.Rows[i].Visible = false;
                    }
                }
                return;
            }
        }

        private void frmSorusturmaKarakol_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                kaydedildi = true;

                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSorusturmaKarakol_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?", "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmSorusturmaKarakol_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmSorusturmaKarakol_Load(object sender, EventArgs e)
        {
            InitsData();
        }

        private void InitsData()
        {
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliye);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.perCariGetir(rLueIfadeVeren);
            BelgeUtil.Inits.ItirazSonucuGetir(rLueItirazSonuc);
            BelgeUtil.Inits.CariPersonelGetir(rLuePersonel);
            BelgeUtil.Inits.SavcilikHukumGetir(rLueSavcilikHüküm);
            BelgeUtil.Inits.HazirlikSikayetNedenGetir(rLueSikayetNeden);
            BelgeUtil.Inits.SorumluAvukatGetir(rLueSorumlu);
            BelgeUtil.Inits.HazirlikSurecSonucGetir(rLueSurecSonuc);
            BelgeUtil.Inits.HazirlikSurecGetir(rLueSurecTip);
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_HAZIRLIK_SUREC surec = new AV001_TD_BIL_HAZIRLIK_SUREC();
            surec.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            surec.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            surec.KONTROL_NE_ZAMAN = DateTime.Now;
            surec.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            surec.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            surec.KAYIT_TARIHI = DateTime.Now;
            surec.SUREC_TIP_ID = Tip;

            if (MySorusturma == null)
                return;
            if (MySorusturma.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Count > 0)
                surec.SIKAYET_NEDEN_ID = MySorusturma.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection[0].ID;
            e.NewObject = surec;
        }
    }
}