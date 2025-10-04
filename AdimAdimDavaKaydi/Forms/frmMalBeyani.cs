using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmMalBeyani : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmMalBeyani()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += frmMalBeyani_FormClosing;
        }

        private int cariId;

        private int foyId;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        private AV001_TI_BIL_FOY_TARAF_GELISME myGelisme;

        public delegate void OnCommandCompleted(object sender);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myFoy = value;
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                    result = myFoy.AV001_TI_BIL_MAL_BEYANICollection;
                    ucMalBeyani1.MyFoy = this.myFoy;
                    ucMalBeyani1.MyDataSource = result;

                    result.AddingNew += result_AddingNew;
                    TList<AV001_TI_BIL_FOY_TARAF> t =
                        AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy);
                    cariId = Convert.ToInt32(t[0].CARI_ID);
                    foyId = myFoy.ID;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme
        {
            get { return myGelisme; }
            set { myGelisme = value; }
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            this.MyFoy = foyEntity;
            this.Show();
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            //this.Kaydet();
            bool rest = true;

            //foreach (AV001_TI_BIL_MAL_BEYANI n in result)
            //{
            //    string sStr = ucKanit.Validate(n);

            //    if (sStr != string.Empty)
            //    {
            //        XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
            //            + System.Environment.NewLine + sStr, "Uyarý");

            //        rest = false;
            //        break;
            //    }
            //}

            if (rest)
            {
                if (Kaydet())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_MAL_BEYANI n in result)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmMalBeyani_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    btnKaydet_ItemClick(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }

            if (MyGelisme != null)
                UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.MalBeyaniTarihiHesapla(myGelisme, MyFoy);
        }

        private void frmMalBeyani_Load(object sender, EventArgs e)
        {
            //result = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_MAL_BEYANIProvider.Find(string.Format("ICRA_FOY_ID = '{0}' AND ICRA_TARAF_ID='{1}' AND ICRA_TARAF='{2}'", foyId, cariId, 2));
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        #region <AC - 20090613>

        // "result" deðiþkeninin access modifierý "ucMalBeyaný" ndan eriþebilmek için public tanýmlandý.
        public TList<AV001_TI_BIL_MAL_BEYANI> result;

        #endregion <AC - 20090613>

        private bool Kaydet()
        {
            // DialogResult res = MessageBox.Show("Deðiþiklikler kaydedilsin mi?", "Kaydet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (res == DialogResult.Yes)
            //{
            //    try
            //    {
            //        DataRepository.AV001_TI_BIL_MAL_BEYANIProvider.Save(result);
            //        this.CommandCompleted(this);
            //    }
            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            //}

            bool sonuc = false;

            MyFoy.AV001_TI_BIL_MAL_BEYANICollection.ForEach(
                delegate(AV001_TI_BIL_MAL_BEYANI m) { m.ICRA_FOY_ID = MyFoy.ID; });

            //MyFoy.AV001_TI_BIL_MAL_BEYANICollection.AddRange(result);

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_MAL_BEYANIProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_MAL_BEYANICollection);

                tran.Commit();

                sonuc = true;

                UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
                for (int i = 0; i < result.Count; i++)
                {
                    MyFoy.AV001_TI_BIL_MAL_BEYANICollection.Remove(result[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        private void result_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_MAL_BEYANI addNew = new AV001_TI_BIL_MAL_BEYANI();

            addNew.ICRA_FOY_ID = foyId;
            addNew.ICRA_TARAF_ID = cariId;
            addNew.ICRA_TARAF = "2";
            addNew.SUBE_KODU = 1;
            addNew.STAMP = 1;
            addNew.KONTROL_VERSIYON = 1;
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KLASOR_KODU = "GENEL";
            addNew.KAYIT_TARIHI = DateTime.Now;
            e.NewObject = addNew;
        }
    }
}