using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;
using DevExpress.XtraVerticalGrid.Rows;
using AdimAdimDavaKaydi.PaketKontrol;
namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaNedenleri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucDavaNedenleri()
        {
            InitializeComponent();
            this.Load += ucDavaNedenleri_Load;
        }

        public bool isFoyNew = false;

        public TList<AV001_TD_BIL_DAVA_NEDEN> MyDataSource
        {
            get
            {
                if (vgDavaNedeni.DataSource is TList<AV001_TD_BIL_DAVA_NEDEN>)
                {
                    vgDavaNedeni.CloseEditor();
                    return (TList<AV001_TD_BIL_DAVA_NEDEN>)vgDavaNedeni.DataSource;
                }
                else
                    return null;
            }
            set
            {
                vgDavaNedeni.DataSource = value;
                gridControl1.DataSource = value;
            }
        }

        private void ucDavaNedenleri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            compVGridRecordCopy1.MyVGridControl = vgDavaNedeni;

            InitsGetir();

            if (Kimlikci.Kimlik.SirketBilgisi.KurumsalMod == 1001)
            {
                mrowTutar.PropertiesCollection["TUTAR"].Caption = "Tutar";
                mrowDava.PropertiesCollection["DAVA_EDILEN_TUTAR"].Caption = "Dava Edilen Tutar";
            }

            #region Ozellestirme

            if (mrowReferans.PropertiesCollection["REFERANS_NO1"] != null)
                mrowReferans.PropertiesCollection["REFERANS_NO1"].Caption = Kimlikci.Kimlik.DavaDnReferans.Referans1;
            if (mrowReferans.PropertiesCollection["REFERANS_NO2"] != null)
                mrowReferans.PropertiesCollection["REFERANS_NO2"].Caption = Kimlikci.Kimlik.DavaDnReferans.Referans2;

            #endregion Ozellestirme

            mrowDavaS.Visible = false;
            mrowTazminats.Visible = false;
            mrowDovizIslemTipiFaizIslemTipi.Visible = false;
            mrowIhtarGideri.Visible = false;
            mrowDigerGider.Visible = false;
        }

        private void InitsGetir()
        {
            BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
            BelgeUtil.Inits.YuzdeBicimiAyarla(rudOran);
            BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
            BelgeUtil.Inits.FaizTipiGetir(rLueFaizTip);
            BelgeUtil.Inits.TazminatHesapTipiGetir(rlkTazminatTipi);

            if (isFoyNew)
            {
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.DovizIslemTipiGetir(rlkDovizIslemTipi);
            }
            else
            {
                AvukatPro.Services.Implementations.DevExpressService.DavaNedeniDoldur(rLueDavaNeden, null, false);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.DovizIslemTipiGetir(rlkDovizIslemTipi);
            }
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                vgDavaNedeni.Visible = true;
                vgDavaNedeni.BringToFront();
            }

            else if (vgDavaNedeni.Visible)
            {
                vgDavaNedeni.Visible = false;
                gridControl1.Visible = true;
                gridControl1.BringToFront();
            }
        }

        public void Yapilandir(string kd, bool nispiMi)
        {
            foreach (EditorRow c in this.vgDavaNedeni.Rows)
            {
                string davaNedeni = string.Empty;
                if (c.Name == "rowDavaNeden")
                    davaNedeni = c.Properties.ToString();
                string tag = c.Tag == null ? "" : c.Tag.ToString();
                if (tag.Contains("+") && tag.Length == 1)
                {
                    c.Visible = true;
                }
                else if (tag.Contains("+") && !tag.Contains(kd.ToLower()))
                {
                    c.Visible = true;
                }
                else if (tag.Contains(kd))
                {
                    if (!nispiMi && tag.Contains("[N]"))
                        c.Visible = false;
                    else
                        c.Visible = true;
                }
                
                else
                {
                    c.Visible = false;
                }

                foreach (EditorRow rw in c.ChildRows)
                {
                    string tg = rw.Tag == null ? "" : rw.Tag.ToString();
                    if (tg.Contains("+") && tg.Length == 1)
                    {
                        rw.Visible = true;
                    }
                    else if (tg.Contains("+") && !tg.Contains(kd.ToLower()))
                    {
                        rw.Visible = true;
                    }
                    else if (tg.Contains(kd))
                    {
                        if (!nispiMi && tag.Contains("[N]"))
                            c.Visible = false;
                        else
                            rw.Visible = true;
                    }
                    else if (tag.Contains("XX"))
                    {
                        if (davaNedeni == "")
                            c.Visible = true;
                    }
                    else
                    {
                        rw.Visible = false;
                    }
                }
            }
            this.GetPaketForm();

        }

        /// <summary>
        /// Aktif Neden deðiþtirildiðinde patlayan event.
        /// </summary>
        public event DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler DavaNedeniChanged;

        private void vgDavaNedeni_FocusedRecordChanged(object sender,
                                                       DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (DavaNedeniChanged != null)
                DavaNedeniChanged(sender, e);
        }

        /// <summary>
        /// Üzerinde bulunulan dava nedeni Validate olduðunda patlayan event.
        /// </summary>
        public event DevExpress.XtraVerticalGrid.Events.ValidateRecordEventHandler ValidateNeden;

        private void vgDavaNedeni_ValidateRecord(object sender, DevExpress.XtraVerticalGrid.Events.ValidateRecordEventArgs e)
        {
            if (ValidateNeden != null)
            {
                ValidateNeden(sender, e);
            }
        }

        public AV001_TD_BIL_DAVA_NEDEN CurrentNeden
        {
            get { return vgDavaNedeni.GetRecordObject(vgDavaNedeni.FocusedRecord) as AV001_TD_BIL_DAVA_NEDEN; }
        }

        public void TazminatYapilandir(DavaTazminatHesapTipi dt)
        {
            if (dt != null)
            {
                switch (dt)
                {
                    case DavaTazminatHesapTipi.Maktu:
                        rowTazminatOran.Visible = false;
                        mrowTazminatPara.Visible = true;
                        break;
                    case DavaTazminatHesapTipi.Nispi:
                        rowTazminatOran.Visible = true;
                        mrowTazminatPara.Visible = false;
                        break;
                }
                this.GetPaketForm();
            }
        }

        public static string Validate(AV001_TD_BIL_DAVA_NEDEN row)
        {
            StringBuilder sb = new StringBuilder();

            if (!row.DAVA_NEDEN_KOD_ID.HasValue)
                sb.AppendLine("* Dava nedeni boþ olamaz.");

            if (!row.OLAY_SUC_TARIHI.HasValue)
                sb.AppendLine("* Olay tarihi boþ olamaz.");

            return sb.ToString();
        }
    }
}