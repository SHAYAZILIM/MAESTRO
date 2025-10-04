using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.StyleFormatConditions;
using System.Drawing;
using AdimAdimDavaKaydi.Properties;


namespace AdimAdimDavaKaydi.UserControls
{


    public partial class ucIcraTarafGelismeBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {


        public ucIcraTarafGelismeBilgileri()
        {
            InitializeComponent();
            exGridIcraTarafGelismeleri.RightClickPopup.PopupOpening += new EventHandler<PopupOpeningEventArgs>(RightClickPopup_PopupOpening);
            exGridIcraTarafGelismeleri.RightClickPopup.PopupButtonClick += new EventHandler<DevExpress.XtraBars.ItemClickEventArgs>(RightClickPopup_PopupButtonClick);
        }

        void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag == "Yazdir")
            {
                List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foys = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
                for (int rowHandle = 0; rowHandle < gvIcraTarafGelismeleri.RowCount; rowHandle++)
                {
                    if ((bool)gvIcraTarafGelismeleri.GetRowCellValue(rowHandle, "IsSelected"))
                    {
                        foys.Add(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByID((int)gvIcraTarafGelismeleri.GetRowCellValue(rowHandle, "IcraFoyId")));
                    }
                }

                if (foys.Count > 0)
                {
                    AdimAdimDavaKaydi.Editor.Forms.frmAdimAdimEditoreGonder editor = new Editor.Forms.frmAdimAdimEditoreGonder();
                    editor.Show(foys);
                }
                else
                {
                    XtraMessageBox.Show("Editöre göndermek için geliþme seçiniz!");
                }
            }
            else if (e.Item.Tag == "SendSms")
            {
                List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foys = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
                for (int rowHandle = 0; rowHandle < gvIcraTarafGelismeleri.RowCount; rowHandle++)
                {
                    if ((bool)gvIcraTarafGelismeleri.GetRowCellValue(rowHandle, "IsSelected"))
                    {
                        foys.Add(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByID((int)gvIcraTarafGelismeleri.GetRowCellValue(rowHandle, "IcraFoyId")));
                    }
                }
                if (foys.Count > 0)
                {
                    AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms smail = new AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms();
                    smail.Show(foys,e.Item.Tag.ToString());
                }
                else
                {
                    XtraMessageBox.Show("Editöre göndermek için geliþme seçiniz!");
                }
            }
            else if (e.Item.Tag == "SendMail")
            {
                List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foys = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
                for (int rowHandle = 0; rowHandle < gvIcraTarafGelismeleri.RowCount; rowHandle++)
                {
                    if ((bool)gvIcraTarafGelismeleri.GetRowCellValue(rowHandle, "IsSelected"))
                    {
                        foys.Add(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByID((int)gvIcraTarafGelismeleri.GetRowCellValue(rowHandle, "IcraFoyId")));
                    }
                }

                if (foys.Count > 0)
                {
                    AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms smail = new AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms();
                    smail.Show(foys, e.Item.Tag.ToString());
                }
                else
                {
                    XtraMessageBox.Show("Editöre göndermek için geliþme seçiniz!");
                }
            }
            else if (e.Item.Tag == "SendFax")
            {
                List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foys = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
                for (int rowHandle = 0; rowHandle < gvIcraTarafGelismeleri.RowCount; rowHandle++)
                {
                    if ((bool)gvIcraTarafGelismeleri.GetRowCellValue(rowHandle, "IsSelected"))
                    {
                        foys.Add(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByID((int)gvIcraTarafGelismeleri.GetRowCellValue(rowHandle, "IcraFoyId")));
                    }
                }
                if (foys.Count > 0)
                {
                    AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms smail = new AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms();
                    smail.Show(foys, e.Item.Tag.ToString());
                }
                else
                {
                    XtraMessageBox.Show("Editöre göndermek için geliþme seçiniz!");
                }
            }
        }
        void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null)
            {
                DevExpress.XtraBars.BarButtonItem yazdir = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Seçilenlere yazýþma gönder");
                Bitmap imageYazdir = (Bitmap)AdimAdimDavaKaydi.Properties.Resources.yazdir;
                imageYazdir.MakeTransparent(Color.Fuchsia);
                yazdir.Glyph = imageYazdir;
                yazdir.Tag = "Yazdir";
                e.MyPopupMenu.AddItem(yazdir);

                DevExpress.XtraBars.BarButtonItem SendSms = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Seçilenlere Sms gönder");
                Bitmap imageSMS = (Bitmap)AdimAdimDavaKaydi.Properties.Resources.SmsImage;
                imageSMS.MakeTransparent(Color.Fuchsia);
                SendSms.Glyph = imageSMS;
                SendSms.Tag = "SendSms";  
                e.MyPopupMenu.AddItem(SendSms);
                DevExpress.XtraBars.BarButtonItem SendMail = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Seçilenlere Mail gönder");
                Bitmap imageMail = (Bitmap)AdimAdimDavaKaydi.Properties.Resources.Mail_16x16;
                imageMail.MakeTransparent(Color.Fuchsia);
                SendMail.Glyph = imageMail;
                SendMail.Tag = "SendMail";
                e.MyPopupMenu.AddItem(SendMail);
                DevExpress.XtraBars.BarButtonItem SendFax = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Seçilenlere Fax gönder");
                Bitmap imageFax = (Bitmap)AdimAdimDavaKaydi.Properties.Resources.fax_cekilecek1;
                imageFax.MakeTransparent(Color.Fuchsia);
                SendFax.Glyph = imageFax;
                SendFax.Tag = "SendFax";
                e.MyPopupMenu.AddItem(SendFax);

            }
        }

        //VI_BIL_ICRA_TARAF_GELISMELERI

        [Browsable(false)]
        public List<ViBilIcraTarafGelismeleriEntity> MyDataSource
        {
            get
            {
                if (exGridIcraTarafGelismeleri.DataSource is List<ViBilIcraTarafGelismeleriEntity>)
                    return (List<ViBilIcraTarafGelismeleriEntity>)exGridIcraTarafGelismeleri.DataSource;
                return null;
            }
            set { exGridIcraTarafGelismeleri.DataSource = value; }
        }

        public void LookUpDoldur()
        {
            lkAdliye.Properties.NullText = "Seç";
            lkAdliyeBirimNO.Properties.NullText = "Seç";
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTakipEdilen, null);
            BelgeUtil.Inits.DosyaDurumGetir(lueDosyaDurum);
            lkAdliye.Enter += BelgeUtil.Inits.AdliBirimAdliyeGetir_Enter;
            lkAdliyeBirimNO.Enter += BelgeUtil.Inits.AdliBirimNoGetir_Enter;
            AvukatPro.Services.Implementations.DevExpressService.FormTipiDoldur(rlueFormTip);
            lueDosyaDurum.EditValue = (int)AvukatProLib.Extras.FoyDurum.FAAL;
        }
        private void ucIcraTarafGelismeBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            LookUpDoldur();
        }
        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        (con).ResetText();
                        ((DateEdit)con).EditValue = null;
                    }
                    else if (con is TextEdit)
                    {
                        ((TextEdit)con).EditValue = null;
                    }
                }
            }
            catch 
            {
                XtraMessageBox.Show(
                    "Arama Kriterleri Temizlenirken (Silinirken) Bir Hata Oluþtu..\nLütfen Yeniden Deneyiniz...");
            }
        }

        private void sBtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(xTabFoyBilgileri.Controls);
            //FormlariTemizle(xTabTarihBilgileri.Controls);
        }

        private void GelistirmeleriGuncelle(List<ViBilIcraTarafGelismeleriEntity> datas)
        {
            TList<AV001_TI_BIL_FOY> foyler = new TList<AV001_TI_BIL_FOY>();
            foreach (var data in datas)
            {
                if (data.IcraFoyId.HasValue && !foyler.Contains(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)data.IcraFoyId)))
                    foyler.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)data.IcraFoyId));
            }

            foyler.Distinct();

            //foreach (var foy in DataRepository.AV001_TI_BIL_FOYProvider.GetAll())
            //{
            //    if (DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.GetByICRA_FOY_ID(foy.ID).Count < 1)
            //        foyler.Add(foy);
            //}

            if (foyler.Count > 0)
            {
                foreach (var foy in foyler)
                {
                    if (foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

                    TList<AV001_TI_BIL_FOY_TARAF> taraflar = foy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(t => !t.TAKIP_EDEN_MI && t.CARI_ID.HasValue);
                    if (taraflar.Count > 0)
                    {
                        foreach (var taraf in taraflar)
                        {
                            int borcluID = (int)taraf.CARI_ID;

                            AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.CurrBorcluId = borcluID;
                            AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.BorcluCariID = borcluID;
                            AV001_TI_BIL_FOY_TARAF_GELISME guncellenecekGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeleriGuncelle(foy, null)[0];

                            if (!guncellenecekGelisme.ICRA_FOY_ID.HasValue)
                                guncellenecekGelisme.ICRA_FOY_ID = foy.ID;
                            if (!guncellenecekGelisme.ICRA_FOY_TARAF_ID.HasValue)
                                guncellenecekGelisme.ICRA_FOY_TARAF_ID = taraf.ID;

                            DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.Save(guncellenecekGelisme);

                        }
                    }
                }
            }
        }

        private void sBtnSorgula_Click(object sender, EventArgs e)
        {
            //Sorgula
            Sorgula();

            //Gelistirmeleri Güncelle
            if (chkGuncelle.Checked)
            {
                DialogResult dr = XtraMessageBox.Show("Güncelleme iþlemi kayýtlarla orantýlý olarak fazla zaman alan bir iþlemdir. Devam etmek istediðinize emin misiniz ?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr.Equals(DialogResult.Yes))
                {
                    GelistirmeleriGuncelle(MyDataSource);
                    Sorgula();
                }
            }
        }

        private void Sorgula()
        {
            AvukatPro.Services.Messaging.GetTarafGelismeleriByFiltreRequest request = new AvukatPro.Services.Messaging.GetTarafGelismeleriByFiltreRequest();
            request.AdliyeId = (int?)lkAdliye.EditValue;
            request.DosyaDurum = (int?)lueDosyaDurum.EditValue;
            if (txteDosyaNo.EditValue != null)
                request.DosyaNo = txteDosyaNo.EditValue.ToString();
            if (txteEsasNo.EditValue != null)
                request.EsasNo = txteEsasNo.EditValue.ToString();
            request.FormTipID = (int?)lueFormTipi.EditValue;
            request.NoId = (int?)lkAdliyeBirimNO.EditValue;
            request.TakipEdilen = lueTakipEdilen.EditValue == null ? "" : lueTakipEdilen.Text;
            request.TakipTarihi = (DateTime?)deTakipTarihi.EditValue;
            if (!(bool)rgDosyaGrubu.EditValue)
                request.KontrolKimID = AvukatProLib.Kimlik.CurrentCariId;

            MyDataSource = AvukatPro.Services.Implementations.CariService.GetTarafGelismeleriByFiltre(request);
        }

        private void gvIcraTarafGelismeleri_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;

            int? gelismeId = (int?)gvIcraTarafGelismeleri.GetRowCellValue(e.FocusedRowHandle, "Id");
            if (gelismeId != null)
            {
                AV001_TI_BIL_FOY_TARAF_GELISME gelisme = DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.GetByID((int)gelismeId);
                AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)gelisme.ICRA_FOY_ID);
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                ucIcraTarafGelismeleri1.CurrBorcluId = (int)foy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.ID == gelisme.ICRA_FOY_TARAF_ID).CARI_ID;

                ucIcraHesapCetveli1.IcraDosyaKayitEkrani = true;
                ucIcraHesapCetveli1.MyFoyDataSource = foy;
                ucIcraHesapCetveli1.MyTarafSource = foy.AV001_TI_BIL_FOY_TARAFCollection;
                ucIcraTarafGelismeleri1.MyFoy = foy;
                UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeleriGuncelle(foy, null);
            }
        }

        private void exGridIcraTarafGelismeleri_DoubleClick(object sender, EventArgs e)
        {
            if (gvIcraTarafGelismeleri.GetFocusedRow() != null)
            {
                ViBilIcraTarafGelismeleriEntity takip = gvIcraTarafGelismeleri.GetFocusedRow() as ViBilIcraTarafGelismeleriEntity;
                if (takip.IcraFoyId.HasValue)
                {
                    AV001_TI_BIL_FOY icra = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)takip.IcraFoyId);
                    TList<AV001_TI_BIL_FOY> seciliKayitler = new TList<AV001_TI_BIL_FOY>();
                    seciliKayitler.Add(icra);
                    AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frmicraTakip = new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                    frmicraTakip.Show(seciliKayitler);
                }
            }
        }

        private void gvIcraTarafGelismeleri_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                ViBilIcraTarafGelismeleriEntity gelisme = null;

                gelisme = (ViBilIcraTarafGelismeleriEntity)gvIcraTarafGelismeleri.GetRow(e.RowHandle);

                if ((gelisme.BilaTarihi.HasValue || gelisme.ZabitaArastirmaOlumsuzTarihi.HasValue || gelisme.ZabitacaYeniAdresBulunduguTarihi.HasValue) && !gelisme.IlkTebligatTarihi.HasValue)
                {
                    e.Appearance.BackColor = System.Drawing.Color.Purple;
                    e.Appearance.BackColor2 = System.Drawing.Color.Purple;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (gelisme.IlkTebligatTarihiDurumu == "Bekleniyor.")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Gold;
                    e.Appearance.BackColor2 = System.Drawing.Color.Gold;
                    e.Appearance.ForeColor = System.Drawing.Color.Black;
                }
                else if (gelisme.KesinlesmeTarihiDurumu == "Kesinleþti")
                {
                    e.Appearance.BackColor = System.Drawing.Color.DarkGreen;
                    e.Appearance.BackColor2 = System.Drawing.Color.DarkGreen;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (gelisme.ItirazTarihiDurumu == "Tümüne Ýtiraz" || gelisme.ItirazTarihiDurumu == "Kabul Edildi")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Red;
                    e.Appearance.BackColor2 = System.Drawing.Color.Red;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (gelisme.ItirazTarihiDurumu == "Kýsmi Ýtiraz")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Red;
                    e.Appearance.BackColor2 = System.Drawing.Color.Green;
                    e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (gelisme.IlkTebligatTarihi.HasValue && !gelisme.KesinlesmeTarihi.HasValue && !gelisme.ItirazTarihi.HasValue)
                {
                    e.Appearance.BackColor = System.Drawing.Color.Orange;
                    e.Appearance.BackColor2 = System.Drawing.Color.Orange;
                    e.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
                }
                if (gelisme.KesinlesmeTarihiDurumu == "Mehil Öncesi")
                {
                    e.Appearance.BackColor = System.Drawing.Color.DarkBlue;
                    e.Appearance.BackColor2 = System.Drawing.Color.DarkBlue;
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void gvIcraTarafGelismeleri_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gv = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            gv.SetRowCellValue(e.RowHandle, gv.Columns["IsSelected"], !((bool)gv.GetRowCellValue(e.RowHandle, "IsSelected")));
        }
    }
}
