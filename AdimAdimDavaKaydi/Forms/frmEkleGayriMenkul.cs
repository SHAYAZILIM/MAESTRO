using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmEkleGayriMenkul : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmEkleGayriMenkul()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(frmEkleGayriMenkul_FormClosed);
        }

        public TList<AV001_TI_BIL_GAYRIMENKUL> alreadyaddedList;

        public TList<AV001_TI_BIL_GAYRIMENKUL> selectedList;

        public AV001_TD_BIL_FOY MyDavaFoy { get; set; }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.c_btnTamam.Text = "Gönder";
        }

        private void frmEkleGayriMenkul_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (gridControl1.DataSource != null && gridControl1.DataSource is TList<AV001_TI_BIL_GAYRIMENKUL>)
                ((TList<AV001_TI_BIL_GAYRIMENKUL>)gridControl1.DataSource).FindAll(vi => vi.IsSelected).ForEach(item => item.IsSelected = false);
        }

        private void frmEkleGayriMenkul_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                int ulkeId = 2;
                try
                {
                    ulkeId = AvukatProLib2.Data.DataRepository.TDI_KOD_ULKEProvider.GetByULKE("TÜRKÝYE").ID;
                }
                catch (Exception)
                {
                }
                BelgeUtil.Inits.IlGetirUlkeyeGore(rlkIL_ID, ulkeId);
                BelgeUtil.Inits.IlceGetirTumu(rlkILCE_ID);
                this.gridControl1.DataSource = BelgeUtil.Inits.GayrimenkulGetir();
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                TList<AV001_TI_BIL_GAYRIMENKUL> result = ((TList<AV001_TI_BIL_GAYRIMENKUL>)gridControl1.DataSource).FindAll(item => item.IsSelected);

                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(result, true, DeepLoadType.IncludeChildren, typeof(TList<NN_DAVA_GAYRIMENKUL>), typeof(TList<NN_ICRA_GAYRIMENKUL>));

                TList<AV001_TI_BIL_GAYRIMENKUL> sonhal = new TList<AV001_TI_BIL_GAYRIMENKUL>();

                foreach (AV001_TI_BIL_GAYRIMENKUL gm in result)
                {
                    string mesaj = "";
                    if (gm.NN_DAVA_GAYRIMENKULCollection.Count > 0)

                    ///TODO: Ýkinci kontrol kaldýrýlacak yeni yapý kullanýlacak
                    {
                        string msg = "";
                        foreach (NN_DAVA_GAYRIMENKUL d in gm.NN_DAVA_GAYRIMENKULCollection)
                        {
                            var davaFoy = BelgeUtil.Inits.context.per_AV001_TD_BIL_FOY_DosyaBilgileris.Single(vi => vi.ID == d.DAVA_FOY_ID);
                            msg += String.Format("Dosya No: {1} , Adliye : {0} {4} {5} , Esas No: {2} {3}", davaFoy.ADLIYE, davaFoy.FOY_NO, davaFoy.ESAS_NO, Environment.NewLine, davaFoy.NO, davaFoy.GOREV);
                        }
                        mesaj += gm.ID + " Sistem numaralý gayrimenkul daha önce aþaðýda bulunan dava dosya(sýn/larýn) da kullanýlmýþtýr." + Environment.NewLine + msg;
                    }
                    if (gm.NN_ICRA_GAYRIMENKULCollection.Count > 0)
                    {
                        string msg = "";
                        foreach (NN_ICRA_GAYRIMENKUL d in gm.NN_ICRA_GAYRIMENKULCollection)
                        {
                            var icraFoy = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_DosyaBilgileris.Single(vi => vi.ID == d.ICRA_FOY_ID);
                            msg += String.Format("Dosya No: {1} , Müdürlük : {0} {4} {5} , Esas No: {2} {3}", icraFoy.ADLIYE, icraFoy.FOY_NO, icraFoy.ESAS_NO, Environment.NewLine, icraFoy.NO, icraFoy.GOREV);
                        }
                        mesaj += (gm.ID + " Sistem numaralý gayrimenkul daha önce aþaðýda bulunan icra dosya(sýn/larýn) da kullanýlmýþtýr." + Environment.NewLine + msg);
                    }
                    if (gm.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.Count > 0)
                    {
                        mesaj += (gm.ID + " Sistem numaralý evrak daha önceden bir soruþturma dosyasýnda kullanýlmýþtýr.");
                    }
                    if (string.IsNullOrEmpty(mesaj))
                        sonhal.Add(gm);
                    else
                    {
                        System.Windows.Forms.DialogResult dr = MessageBox.Show(mesaj + Environment.NewLine + "Eklemek istediðinize eminmisiniz ?", "Dikkat", MessageBoxButtons.YesNo);
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            sonhal.Add(gm);
                        }
                    }
                }

                selectedList = sonhal;

                foreach (var item in selectedList)
                {
                    if (MyDavaFoy != null)
                    {
                        NN_DAVA_GAYRIMENKUL davaGayrimenkul = new NN_DAVA_GAYRIMENKUL();
                        davaGayrimenkul.DAVA_FOY_ID = MyDavaFoy.ID;
                        davaGayrimenkul.GAYRIMENKUL_ID = item.ID;
                        if (DataRepository.NN_DAVA_GAYRIMENKULProvider.GetByDAVA_FOY_IDGAYRIMENKUL_ID(davaGayrimenkul.DAVA_FOY_ID, davaGayrimenkul.GAYRIMENKUL_ID) == null)
                        {
                            DataRepository.NN_DAVA_GAYRIMENKULProvider.Save(davaGayrimenkul);
                        }
                    }
                }
                MessageBox.Show("Gayrimenkul dosyaya eklendi.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}