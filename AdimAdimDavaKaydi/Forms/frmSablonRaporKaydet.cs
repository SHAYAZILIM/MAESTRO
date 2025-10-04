using AvukatProLib2.Entities;
using DevExpress.XtraVerticalGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmSablonRaporKaydet : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmSablonRaporKaydet()
        {
            InitializeComponent();
            repositoryItemComboBox1.Validating += repositoryItemComboBox1_Validating;
            repositoryItemComboBox1.AutoComplete = true;

            if (BelgeUtil.Inits._SablonRaporGetir == null)
                BelgeUtil.Inits._SablonRaporGetir = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.ToList();
            List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> lstRapors = BelgeUtil.Inits._SablonRaporGetir;
            List<string> lstads = new List<string>();
            for (int i = 0; i < lstRapors.Count; i++)
            {
                lstads.Add(lstRapors[i].AD);
            }
            repositoryItemComboBox1.Items.AddRange(lstads);
        }

        private TextControl document;

        private string filename = "";
        
        public void ShowMe(TXTextControl.TextControl _document)
        {
            document = _document;

            //.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        private void frmSablonRaporKaydet_Load(object sender, EventArgs e)
        {
            #region TAHSIN ...  LOOKUPLAR

            BelgeUtil.Inits.DavaAdi(rLueDavaNeden);
            BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdlibirimBolum);
            BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTip);
            BelgeUtil.Inits.DavaTalepGetir(rLueDavaTalep);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.SektorKodGetir(rLueSektor);
            BelgeUtil.Inits.DilKodGetir(rLueDil);
            BelgeUtil.Inits.TakipKonusuGetir(rLueTakipTalepKonu);

            BelgeUtil.Inits.ModulKodGetir(rLueModul);
            BelgeUtil.Inits.SablonRaporTipGetir(rLueRaporTip);
            BelgeUtil.Inits.FormTipiGetir(rLueFormOrnekNo);
            BelgeUtil.Inits.SablonAltKategoriGetir(rLueKategori);

            #endregion TAHSIN ...  LOOKUPLAR

            TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> lstRapor =
                new TList<AV001_TDIE_BIL_SABLON_RAPOR>();
            lstRapor.AllowNew = true;
            lstRapor.Add(new AV001_TDIE_BIL_SABLON_RAPOR());
            this.vGridControl1.DataSource = lstRapor;
            this.vGridControl1.Rows["rowDOSYA_ADRES"].Properties.Value = filename;
        }

        private void repositoryItemComboBox1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Count() > 0;
        }

        //Ýptal
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] veri = new byte[100000];
                document.Save(out veri, TXTextControl.BinaryStreamType.MSWord, new TXTextControl.SaveSettings());
                TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> lstRapors =
                    ((TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>)this.vGridControl1.DataSource);
                for (int i = 0; i < lstRapors.Count; i++)
                {
                    lstRapors[i].DOSYA = veri;
                    lstRapors[i].RAPOR_TIP_ID = 2;
                }
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.Save(lstRapors);

                this.Close();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void vGridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VGridHitInfo hitinf = vGridControl1.CalcHitInfo(e.Location);
        }
    }
}