using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmMahsupBilgileri : Util.BaseClasses.AvpXtraForm
    {
        public frmMahsupBilgileri()
        {
            InitializeComponent();
            this.FormClosing += frmMahsupBilgileri_FormClosing;
            InitializeEvents();
        }

        private TList<AV001_TI_BIL_BORCLU_MAHSUP> addNewList;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_BORCLU_MAHSUP> AddNewList
        {
            get { return addNewList; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    addNewList = value;
                    dNEgrdMahsupBilgileri.DataSource = value;
                    vgMahsupBilgileri.DataSource = dNEgrdMahsupBilgileri.DataSource;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !DesignMode)
                {
                    myFoy = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_BORCLU_MAHSUP>();
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;

            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_BORCLU_MAHSUP m in AddNewList)
            {
                if (m.IsNew || m.IsDirty)
                {
                    return false;
                }
            }

            return true;
        }

        private void frmMahsupBilgileri_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;

            //validate
            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;
                    XtraMessageBox.Show("Deðiþiklikler Kaydedildi.", "Kaydet ve Çýk",
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

        private void frmMahsupBilgileri_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmMahsupBilgileri_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmMahsupBilgileri_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.ParaBicimiAyarla(rSpeMahsupMiktari);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmMahsupBilgileri_Button_Kaydet_Click;
        }

        private bool Save()
        {
            bool sonuc = false;
            if (MyFoy != null)
            {
                addNewList.ForEach(delegate(AV001_TI_BIL_BORCLU_MAHSUP b) { b.ICRA_FOY_ID = MyFoy.ID; });

                if (MyFoy.ID > 0)
                {
                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                    try
                    {
                        foreach (var mahsup in addNewList)
                        {
                            if (
                                MyFoy.AV001_TI_BIL_BORCLU_MAHSUPCollection.Exists(
                                    delegate(AV001_TI_BIL_BORCLU_MAHSUP pol) { return pol.ID == mahsup.ID; })) continue;
                            MyFoy.AV001_TI_BIL_BORCLU_MAHSUPCollection.AddRange(AddNewList);
                        }

                        tran.BeginTransaction();
                        DataRepository.AV001_TI_BIL_FOYProvider.Save(tran, MyFoy); // Okan 18.08.2010

                        DataRepository.AV001_TI_BIL_BORCLU_MAHSUPProvider.DeepSave(tran,
                                                                                   MyFoy.
                                                                                       AV001_TI_BIL_BORCLU_MAHSUPCollection);
                        tran.Commit();

                        sonuc = true;
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                        for (int i = 0; i < AddNewList.Count; i++)
                        {
                            MyFoy.AV001_TI_BIL_BORCLU_MAHSUPCollection.Remove(AddNewList[i]);
                        }
                    }
                    finally
                    {
                        tran.Dispose();
                    }
                }
                else
                {
                    sonuc = true;
                }
            }
            else
            {
                sonuc = true;
            }
            return sonuc;
        }
    }
}