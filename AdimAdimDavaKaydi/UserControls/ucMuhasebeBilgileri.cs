using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucMuhasebeBilgileri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucMuhasebeBilgileri()
        {
            InitializeComponent();
            gcMuhasebe.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
        }

        public void SagTusaEkle()
        {
            gcMuhasebe.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gcMuhasebe.RightClickPopup.LinkPersist.Add(var);
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                if (e.Item.Name == bBtnSorusturmaEkle.Name)
                {
                    AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris frmSorusturma =
                        new AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris();
                    //frmSorusturma.MdiParent = null;
                    frmSorusturma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmSorusturma.Show();
                }
                else if (e.Item.Name == bBtnIcraEkle.Name)
                {
                    AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit frmicraDosyaKayit =
                        new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit();
                    // frmicraDosyaKayit.MdiParent = null;
                    frmicraDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmicraDosyaKayit.Show();
                }
                else if (e.Item.Name == bBtnSozlesmeEkle.Name)
                {
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmsozlesmeKayit =
                        new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
                    //frmsozlesmeKayit.MdiParent = null;
                    frmsozlesmeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmsozlesmeKayit.Show();
                }
                else if (e.Item.Name == bBSahis.Name)
                {
                    frmCariGenelGiris cGiris = new frmCariGenelGiris();
                    cGiris.YeniKayitMi = true;
                    //cGiris.MdiParent = null;
                    cGiris.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cGiris.Show();
                }
                else if (e.Item.Name == bBTemsilEkle.Name)
                {
                    frmTemsilKayit tKayit = new frmTemsilKayit();
                    //tKayit.MdiParent = null;
                    tKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    tKayit.Show();
                }
                else if (e.Item.Name == bBtnDavaEkle.Name)
                {
                    AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmdavaDosyaKayit = new frmDavaDosyaKayitForm();
                    //frmdavaDosyaKayit.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }

                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is AV001_TDI_BIL_FOY_MUHASEBE)
                    {
                        AV001_TDI_BIL_FOY_MUHASEBE takip = e.Item.Tag as AV001_TDI_BIL_FOY_MUHASEBE;

                        string tablob = "AV001_TDI_BIL_FOY_MUHASEBE";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (takip.ID != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.SetByTableNameAndId(tablob, takip.ID);
                                // belgeKayit.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }

                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    if (e.Item.Tag is AV001_TDI_BIL_FOY_MUHASEBE)
                    {
                        AV001_TDI_BIL_FOY_MUHASEBE takip = e.Item.Tag as AV001_TDI_BIL_FOY_MUHASEBE;
                        string tabloI = "AV001_TDI_BIL_FOY_MUHASEBE";
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                        frmisKayit.SetByTableNameAndId(tabloI, takip.ID);
                        //frmisKayit.MdiParent = null;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    }
                }

                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    //if (e.Item.Tag is AV001_TDI_BIL_FOY_MUHASEBE)
                    //{
                    //    AV001_TDI_BIL_FOY_MUHASEBE takip = e.Item.Tag as AV001_TDI_BIL_FOY_MUHASEBE;
                    //    bool islemYap = true;
                    //    if (takip.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AV001_TDI_BIL_FOY_MUHASEBE";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        d.ShowDialog(tabloB, takip.ID);

                    //    }
                    //}
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_FOY_MUHASEBE> MyDataSource
        {
            get
            {
                if (gcMuhasebe.DataSource is TList<AV001_TDI_BIL_FOY_MUHASEBE>)
                    return (TList<AV001_TDI_BIL_FOY_MUHASEBE>)gcMuhasebe.DataSource;

                return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    gcMuhasebe.DataSource = value;
                    extendedGridControl1.DataSource = gcMuhasebe.DataSource;
                }
            }
        }

        private bool viewHeader;

        public bool ViewHeader
        {
            get { return viewHeader; }
            set
            {
                viewHeader = value;
                if (value)
                {
                    groupControl1.Visible = true;
                    //gcMuhasebeTemp.Visible = true;
                    groupControl1.BringToFront();
                }
                else
                {
                    groupControl1.Visible = false;
                    //gcMuhasebeTemp.Visible = true;
                    //gcMuhasebeTemp.BringToFront();
                    //gcMuhasebeTemp.Dock = DockStyle.Fill;
                }
            }
        }

        private void ucMuhasebeBilgileri_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                try
                {
                    gcMuhasebe.ButtonCevirClick += gcMuhasebe_ButtonCevirClick;
                    extendedGridControl1.ButtonCevirClick += gcMuhasebe_ButtonCevirClick;
                    BelgeUtil.Inits.HareketAnaKategoriGetir(rLueMuhasebeAnaKategori);
                    BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueMuhasebeAltKategori);
                    BelgeUtil.Inits.perCariGetir(rLueDovizTip);
                    if (MySozlesme != null)
                        BelgeUtil.Inits.MasrafAvansGetirSozlesme(rLueMasrafAvans2, MySozlesme);
                    BelgeUtil.Inits.HareketAnaKategoriGetir(rLueMuhasebeAnaKategori2);
                    BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueMuhasebeAltKategori2);
                    BelgeUtil.Inits.perCariGetir(rLueDovizTip2);
                    BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
                    BelgeUtil.Inits.ParaBicimiAyarla(rudTutar2);
                    //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);
                    SagTusaEkle();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void gcMuhasebe_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gcMuhasebe.Visible)
            {
                extendedGridControl1.Visible = true;
                gcMuhasebe.Visible = false;
            }
            else
            {
                extendedGridControl1.Visible = false;
                gcMuhasebe.Visible = true;
            }
        }

        private void gcMuhasebe_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "KayitEkle")
                {
                    AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMuhasebeGir =
                        new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                    //frmMuhasebeGir.MdiParent = null;
                    frmMuhasebeGir.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmMuhasebeGir.FormClosed += frmMuhasebeGir_FormClosed;
                    frmMuhasebeGir.Show(MySozlesme);
                }
                else if (e.Button.Tag.ToString() == "KaydiDuzenle")
                {
                    AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli frmmini =
                        new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                    AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMuhasebeGir =
                        new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                    //frmmini.MdiParent = null;
                    frmmini.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmmini.MyDataSource =
                        DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID(
                            MyDataSource[gwMuhasebeBilgileri.FocusedRowHandle].MASRAF_AVANS_ID.Value);
                    // frmMuhasebeGir.FormClosed += new FormClosedEventHandler(frmMuhasebeGir_FormClosed);
                    frmmini.Show(MySozlesme);
                }
            }
        }

        private void frmMuhasebeGir_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
        }
    }
}