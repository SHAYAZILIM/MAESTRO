using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Editor.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Generalclass.Forms;
using AvukatProLib2.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.UserControls
{
    public partial class ucSablonEditoreGonder : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSablonEditoreGonder()
        {
            InitializeComponent();
        }


        [Browsable(false)]
        public IList Foys { get; set; }

        [Browsable(false)]
        public List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> MyDataSource
        {
            get
            {
                if (!DesignMode && (this.gridControl1.DataSource is List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>) &&
                    (this.gridControl1.DataSource != null))
                {
                    return (List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)this.gridControl1.DataSource;
                }
                return null;
            }
            set
            {
                if (!DesignMode && value != null)
                {
                    this.gridControl1.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        public List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> SecilenRaporlar
        {
            get
            {
                if (MyDataSource != null && MyDataSource.Count > 0)
                {
                    return MyDataSource.FindAll(vi => vi.IsSelected);
                }
                return new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
            }
        }

        public frmEditor SelectedEditor { get; set; }

        public void ModuleGoreDoldur(int ModulId)
        {
            popupContainerEdit1.Enter += delegate { this.MyDataSource = BelgeUtil.Inits.SablonRaporGetir(ModulId); };
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            try
            {
                frmIstek istek = new frmIstek();
                List<object> liste = new List<object>();

                for (int i = 0; i < Foys.Count; i++)
                {
                    if (Foys[i] is AV001_TI_BIL_FOY)
                    {
                        istek.Foyler.Add((AV001_TI_BIL_FOY)Foys[i]);
                        liste.Add((AV001_TI_BIL_FOY)Foys[i]);
                    }
                }

                List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> lstRapor = ((List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)gridControl1.DataSource);
                List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> lstRapors = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
                string resultstring = istek.LoadFromList(SecilenRaporlar);
                string BarkodTip = resultstring.Split('-')[0].ToString();// barkod tipini kullanýcaz
                DialogResult dialogResult = resultstring.Split('-')[1].ToString() == "OK" ? DialogResult.OK : DialogResult.Cancel;
                if (dialogResult == DialogResult.Cancel)
                    return;

                if (istek.PostaListesiVarmi)
                {
                    frmPostaListesiYazdir frm = new frmPostaListesiYazdir(liste);
                    frm.Show();
                }

                if (istek.list is List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)
                {
                    List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> dlstRaporlar = ((List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)istek.list);

                    if (SelectedEditor == null || SelectedEditor.IsDisposed)
                    {
                        SelectedEditor = new frmEditor();
                        SelectedEditor.MdiParent = mdiAvukatPro.MainForm;
                    }

                    SelectedEditor.OpenAllSablonForThread(dlstRaporlar, Foys, BarkodTip);
                }

                (gridControl1.DataSource as List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>).FindAll(vi => vi.IsSelected == true).ForEach(item => item.IsSelected = false);
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (gridView1.IsEditing)
            {
                gridView1.CloseEditor();
            }
        }

        private void linkTakipSetiSec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AvukatProLib.Arama.AvpDataContext db = BelgeUtil.Inits.context;

            foreach (var item in Foys)
            {
                if (item is AV001_TI_BIL_FOY)
                {
                    var foy = item as AV001_TI_BIL_FOY;
                    var ayarlar =
                        db.AV001_TI_BIL_YAZDIRMA_AYARLARIs.Where(
                            vi => vi.KULLANICI_ID == AvukatProLib.Kimlik.Bilgi.ID && vi.FORM_ID == foy.FORM_TIP_ID);
                    if (ayarlar.Count() > 0)
                    {
                        var ayar = ayarlar.First();

                        foreach (var aDetay in ayar.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAYs)
                        {
                            bool alacakKosulu = !aDetay.ALACAK_NEDENI_ID.HasValue;
                            bool sozlesmeKosulu = !aDetay.SOZLESME_ALT_TIP_ID.HasValue;

                            if (aDetay.ALACAK_NEDENI_ID.HasValue)
                                alacakKosulu =
                                    foy.AV001_TI_BIL_ALACAK_NEDENCollection.Exists(
                                        vi => vi.ALACAK_NEDEN_KOD_ID == aDetay.ALACAK_NEDENI_ID.Value);

                            if (aDetay.SOZLESME_ALT_TIP_ID.HasValue)
                                sozlesmeKosulu =
                                    foy.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME.Exists(
                                        vi => vi.ALT_TIP_ID == aDetay.SOZLESME_ALT_TIP_ID);
                            if (sozlesmeKosulu && alacakKosulu)
                                MyDataSource.Where(vi => vi.ID == aDetay.SABLON_ID).First().IsSelected = true;
                        }
                    }
                }
            }
        }

        private void popupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (MyDataSource == null)
            {
                return;
            }
            if (MyDataSource != null && MyDataSource.Count > 0)
            {
                this.gridView1.FocusedRowHandle = 0;
            }

            string secim = "";

            for (int i = 0; i < SecilenRaporlar.Count; i++)
            {
                secim += SecilenRaporlar[i].AD + "," + Environment.NewLine;
            }

            this.popupContainerEdit1.Text = secim;
            this.popupContainerEdit1.ToolTip = secim;
        }
    }
}