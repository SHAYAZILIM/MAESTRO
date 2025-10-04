using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucFormOdemeBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucFormOdemeBilgileri()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_BORCLU_ODEME> MyDataSource
        {
            get
            {
                if (gcOdemeListesi.DataSource is TList<AV001_TI_BIL_BORCLU_ODEME>)
                    return (TList<AV001_TI_BIL_BORCLU_ODEME>)gcOdemeListesi.DataSource;
                else
                    return null;
            }
            set { gcOdemeListesi.DataSource = value; }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY Foy { get; set; }

        [Browsable(false)]
        public TList<AV001_TI_BIL_BORCLU_ODEME> Odemeler
        {
            get { return odemeler; }
            set { odemeler = value; }
        }

        private TList<AV001_TI_BIL_BORCLU_ODEME> odemeler = new TList<AV001_TI_BIL_BORCLU_ODEME>();
        private TList<AV001_TI_BIL_FOY_TARAF> listAlacakli;
        private TList<AV001_TI_BIL_FOY_TARAF> listBorclu;

        [Browsable(false)]
        public TList<AV001_TI_BIL_FOY_TARAF> ListAlacakli
        {
            get { return listAlacakli; }
            set
            {
                listAlacakli = value;

                if (ListAlacakli != null && !this.DesignMode)
                    OdenenGetir();
            }
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_FOY_TARAF> ListBorclu
        {
            get { return listBorclu; }
            set
            {
                listBorclu = value;
                if (ListAlacakli != null && !this.DesignMode)
                    OdeyenGetir();
            }
        }

        private void Ekle()
        {
            AV001_TI_BIL_BORCLU_ODEME odeme = new AV001_TI_BIL_BORCLU_ODEME();

            if (lueOdeyen.EditValue != null)
                odeme.ODEYEN_CARI_ID = (int)lueOdeyen.EditValue;

            if (lueOdenen.EditValue != null)
            {
                odeme.ODENEN_CARI_ID = (int)lueOdenen.EditValue;
                odeme.BORCLU_ADINA_ODENEN_CARI_ID = (int)lueOdenen.EditValue;
                odeme.BORCLU_ADINA_ODEYEN_CARI_ID = (int)lueOdenen.EditValue;
            }

            if (dtOdemeT.EditValue != null)
            {
                odeme.ODEME_TARIHI = (DateTime)dtOdemeT.EditValue;
            }
            if (Miktar.EditValue != null)
                odeme.ODEME_MIKTAR = (decimal)Miktar.EditValue;
            if (lueDoviz.EditValue != null)
                odeme.ODEME_MIKTAR_DOVIZ_ID = (int)lueDoviz.EditValue;
            if (lueOdemeSekli.EditValue != null)
                odeme.ODEME_TIP_ID = (int)lueOdemeSekli.EditValue;
            if (lueOdemeYeri != null)
            {
                odeme.ODEME_YER_ID = (int)lueOdemeYeri.EditValue;
            }
            odeme.IHTIYATI_HACIZDE_MI = checkEdit2.Checked;

            Foy.AV001_TI_BIL_BORCLU_ODEMECollection.Add(odeme);
            odemeler.Add(odeme);
        }

        private void OdenenGetir()
        {
            try
            {
                TList<AV001_TDI_BIL_CARI> odenen = new TList<AV001_TDI_BIL_CARI>();
                foreach (AV001_TI_BIL_FOY_TARAF var in ListAlacakli)
                {
                    if (var.CARI_ID.HasValue)
                    {
                        odenen.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(var.CARI_ID.Value));
                    }
                }

                lueOdenen.Properties.DisplayMember = "AD";
                lueOdenen.Properties.ValueMember = "ID";

                lueOdenen.Properties.DataSource = odenen;
                lueOdenen.Properties.Columns.Clear();
                lueOdenen.Properties.Columns.AddRange(new[]
                                                          {
                                                              new LookUpColumnInfo("KOD", 10, "Kod"),
                                                              new LookUpColumnInfo("AD", 10, "Ad")
                                                          }
                    );

                lueOdenen.Properties.NullText = "Ödenen";

                if (odenen.Count == 1)
                    lueOdenen.EditValue = odenen[0].ID;

                rLueOdenen.DataSource = odenen;
                rLueOdenen.ValueMember = "ID";
                rLueOdenen.DisplayMember = "AD";

                rLueOdenen.Columns.Clear();
                rLueOdenen.Columns.AddRange(new[]
                                                {
                                                    new LookUpColumnInfo("KOD", 10, "Kod"),
                                                    new LookUpColumnInfo("AD", 10, "Ad")
                                                }
                    );

                rLueOdenen.NullText = "Ödenen";
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void OdeyenGetir()
        {
            try
            {
                TList<AV001_TDI_BIL_CARI> odeyen = new TList<AV001_TDI_BIL_CARI>();

                foreach (AV001_TI_BIL_FOY_TARAF var in ListBorclu)
                {
                    if (var.CARI_ID.HasValue)
                    {
                        odeyen.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(var.CARI_ID.Value));
                    }
                }
                lueOdeyen.Properties.DisplayMember = "AD";
                lueOdeyen.Properties.ValueMember = "ID";

                lueOdeyen.Properties.DataSource = odeyen;
                lueOdeyen.Properties.Columns.Clear();
                lueOdeyen.Properties.Columns.AddRange(new[]
                                                          {
                                                              new LookUpColumnInfo("KOD", 10, "Kod"),
                                                              new LookUpColumnInfo("AD", 10, "Ad")
                                                          });
                lueOdeyen.Properties.NullText = "Ödeyen";

                if (odeyen.Count == 1)
                    lueOdeyen.EditValue = odeyen[0].ID;

                rLueOdeyen.DataSource = odeyen;
                rLueOdeyen.ValueMember = "ID";
                rLueOdeyen.DisplayMember = "AD";

                rLueOdeyen.Columns.Clear();
                rLueOdeyen.Columns.AddRange(new[]
                                                {
                                                    new LookUpColumnInfo("KOD", 10, "Kod"),
                                                    new LookUpColumnInfo("AD", 10, "Ad")
                                                });
                rLueOdeyen.NullText = "Ödeyen";
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private bool Kontrol(int odenenId, int odeyenId)
        {
            if (MyDataSource.Count == 0)
                return true;

            foreach (AV001_TI_BIL_BORCLU_ODEME var in MyDataSource)
            {
                if (var.ODENEN_CARI_ID != odenenId || var.ODEYEN_CARI_ID != odeyenId)
                    continue;
                else
                    return false;
            }
            return true;
        }

        public void DataGetir()
        {
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueDoviz);
            BelgeUtil.Inits.OdemeTipiGetir(lueOdemeSekli.Properties);
            BelgeUtil.Inits.OdemeTipiGetir(rLueOdemeTip);
            BelgeUtil.Inits.OdemeYeriGetir(lueOdemeYeri.Properties);
            BelgeUtil.Inits.OdemeYeriGetir(rLueOdemeYeri);
            BelgeUtil.Inits.ParaBicimiAyarla(Miktar.Properties);
        }

        private void ucFormOdemeBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            DataGetir();

            //--Set Values--//
            lueDoviz.EditValue = 1;
            lueOdemeYeri.EditValue = 1;
            lueOdemeSekli.EditValue = 1;
            dtOdemeT.EditValue = DateTime.Now;
            //--Set Values--//
        }

        private void Temizle()
        {
            lueOdeyen.EditValue = null;
            lueOdenen.EditValue = null;
            Miktar.Value = 0;
            lueOdemeSekli.EditValue = 1;
            lueOdemeYeri.EditValue = null;
            checkEdit2.Checked = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (validator.Validate())
            {
                if ((decimal)Miktar.EditValue <= 0)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ödeme Miktarý '0' dan büyük olmalýdýr.", "Uyarý",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (Kontrol((int)lueOdenen.EditValue, (int)lueOdeyen.EditValue))
                    {
                        Ekle();

                        Temizle();

                        gcOdemeListesi.DataSource = Foy.AV001_TI_BIL_BORCLU_ODEMECollection;
                    }
                    else
                        DevExpress.XtraEditors.XtraMessageBox.Show("Ödenen/Ödeyen daha önce eklenmiþ.", "Uyarý",
                                                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnOdemeSil_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_BORCLU_ODEME> secilenler = new TList<AV001_TI_BIL_BORCLU_ODEME>();

            for (int j = 0; j < Odemeler.Count; j++)
            {
                if (Odemeler[j].IsSelected && !secilenler.Contains(Odemeler[j]))
                    secilenler.Add(Odemeler[j]);
            }

            if (gwOdemeListesi.SelectedRowsCount <= 0) return;

            else
            {
                DialogResult ds = XtraMessageBox.Show("Seçili kayýtlarý silmek istediðinizden emin misiniz ?",
                                                      "Silme Ýþlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ds == DialogResult.Yes)
                {
                    for (int i = 0; i < secilenler.Count; i++)
                    {
                        Foy.AV001_TI_BIL_BORCLU_ODEMECollection.Remove(secilenler[i]);
                    }
                }
            }
            gcOdemeListesi.DataSource = Foy.AV001_TI_BIL_BORCLU_ODEMECollection;
        }
    }
}