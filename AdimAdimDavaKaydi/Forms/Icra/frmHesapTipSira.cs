using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmHesapTipSira : DevExpress.XtraEditors.XtraForm
    {
        public frmHesapTipSira(int? hesapTipId)
        {
            this.HesapTipi = hesapTipId;
            InitializeComponent();
        }

        public frmHesapTipSira(int hesapTipId, bool editMode, System.Collections.Generic.List<AV001_TI_KOD_HESAP_TIP_SIRA> HesapSiraListesi)
        {
            this.HesapTipi = hesapTipId;
            InitializeComponent();
            EditMode = editMode;
            this.HesapSiraListesi = HesapSiraListesi;
        }

        public DialogResult KayitBasarili = DialogResult.No;

        private bool editMode;

        public bool EditMode
        {
            get { return editMode; }
            set
            {
                editMode = value;
                if (editMode)
                {
                    simpleButton3.Text = "Tamam";
                    simpleButton4.Text = "İptal";
                }
            }
        }

        public System.Collections.Generic.List<AV001_TI_KOD_HESAP_TIP_SIRA> HesapSiraListesi { get; set; }

        public int? HesapTipi { get; set; }

        private void frmHesapTipSira_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.HesapTipiGetir(lookUpEdit1);
            BelgeUtil.Inits.MahsupKategoriGetir(repositoryItemLookUpEdit1);
            if (HesapTipi != null)
            {
                lookUpEdit1.EditValue = HesapTipi;
            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (HesapSiraListesi == null || HesapSiraListesi.Count == 0)
                HesapSiraListesi = DataRepository.AV001_TI_KOD_HESAP_TIP_SIRAProvider.GetAll().ToList();

            var hesapTipleri = HesapSiraListesi.FindAll(vi => vi.HESAP_TIP_ID == (int)lookUpEdit1.EditValue).OrderBy(vi => vi.SIRA_NO).ToList();

            bindingSource1.DataSource = hesapTipleri;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var item = bindingSource1.Current;
            var eskiSira = bindingSource1.IndexOf(item);

            if (eskiSira > 0)
            {
                bindingSource1.Remove(item);
                bindingSource1.Insert(eskiSira - 1, item);
                gridView1.FocusedRowHandle = eskiSira - 1;
            }

            bindingSource1.CurrencyManager.Refresh();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //asagi
            var item = bindingSource1.Current;
            var eskiSira = bindingSource1.IndexOf(item);

            if (eskiSira < bindingSource1.Count - 1)
            {
                bindingSource1.Remove(item);
                bindingSource1.Insert(eskiSira + 1, item);
                gridView1.FocusedRowHandle = eskiSira + 1;
            }

            bindingSource1.CurrencyManager.Refresh();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (EditMode) // EditMode'da kayıt yapılmayacak
            {
                for (int i = 0; i < bindingSource1.List.Count; i++)
                {
                    var item = bindingSource1.List[i] as AV001_TI_KOD_HESAP_TIP_SIRA;
                    item.SIRA_NO = i + 1;
                }
                KayitBasarili = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (bindingSource1.Count > 0)
                {
                    TransactionManager tm = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                    try
                    {
                        tm.BeginTransaction();
                        for (int i = 0; i < bindingSource1.List.Count; i++)
                        {
                            var item = bindingSource1.List[i] as AV001_TI_KOD_HESAP_TIP_SIRA;
                            item.SIRA_NO = i + 1;
                            DataRepository.AV001_TI_KOD_HESAP_TIP_SIRAProvider.Save(tm, item);
                        }
                        tm.Commit();
                        DialogResult = KayitBasarili = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        if (tm.IsOpen)
                            tm.Rollback();

                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}