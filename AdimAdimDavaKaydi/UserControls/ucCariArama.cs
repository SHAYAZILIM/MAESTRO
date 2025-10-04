using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using AdimAdimDavaKaydi.Forms;
using System.Drawing;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucCariArama : DevExpress.XtraEditors.XtraUserControl
    {

        public ucCariArama()
        {
            InitializeComponent();
            exGridCariArama.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            exGridCariArama.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }


        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;
                AdimAdimDavaKaydi.frmCariGenelGiris cariForms;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>), typeof(TList<AV001_TDI_BIL_CARI_BANKA>));
                cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCari = cari;
                //.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        private void barSecilenkeriKayitEkranindaAc_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCariGenelGiris cariGenel = new frmCariGenelGiris();
            TList<AV001_TDI_BIL_CARI> secilenCariler = GetSelectedPerson(MyDataSource);
            if (secilenCariler.Count > 0)
            {
                if (cariGenel == null || cariGenel.IsDisposed)
                {
                    cariGenel = new frmCariGenelGiris();
                }
                cariGenel.YeniKayitMi = false;
                cariGenel.Show(secilenCariler);
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        "Seçilen kayýt yok. Buna raðmen Cari Kayýt formunu açmak istediðinizden emin misiniz?",
                        "Foy Arama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    frmCariGenelGiris frm = new frmCariGenelGiris();
                    frm.Show();
                }
            }
        }

        private void barSecilenIliskiliKayitlarAc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var secilenCarilerim = GetSelectedPerson(MyDataSource);

            if (secilenCarilerim.Count >= 1)
            {
                if (secilenCarilerim.Count > 1)
                    XtraMessageBox.Show(
                        "Ýlk Seçilen Þahýs için Rapor Ekraný açýlacaktýr.\nLütfen çoklu seçim yapmayýnýz...");
            }
            else if (secilenCarilerim.Count == 0)
            {
                XtraMessageBox.Show("Lütfen Bir adet Þahýs Seçiniz...");
            }

            if (secilenCarilerim.Count == 1)
            {
                CariTakipForms.Forms.frmCariTakipForm cariTakip =
                    new AdimAdimDavaKaydi.CariTakipForms.Forms.frmCariTakipForm();
                cariTakip.Show(secilenCarilerim[0]);
            }
            else
            {
                XtraMessageBox.Show("Lütfen bir Þahýs seçiniz...");
            }
        }

        public void SagTusaEkle()
        {
            exGridCariArama.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                exGridCariArama.RightClickPopup.LinkPersist.Add(var);
            }
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            //sað click eklenecek itemlar
            //if (e.Column != null && e.Column.FieldName == "REFERANS_CARI_ID")
            //{
            //    //BarSubItem bus = new BarSubItem(e.Manager, "Düzenle");

            //    BarButtonItem bus = new BarButtonItem(e.Manager, "Düzenle");
            //    //bus.ItemLinks.Add(barBtnSecimiKaldir);

            //    AvukatProLib.Arama.AV001_TDI_BIL_CARI secim = e.Rows as AvukatProLib.Arama.AV001_TDI_BIL_CARI;

            //    int? id = secim.REFERANS_CARI_ID;
            //    if (id.HasValue)
            //    {
            //        bus.Tag = id.Value;
            //    }
            //    bus.ItemClick += barBtnSecimiKaldir_ItemClick;
            //    e.MyPopupMenu.ItemLinks.Insert(0, bus);

            //}
            //else 
            if (e.Column != null)
            {
                BarButtonItem bus = new BarButtonItem(e.Manager, "Düzenle");
                int? id = Convert.ToInt32(((System.Data.DataRowView)(e.Rows)).Row["ID"]);
                if (id.HasValue)
                {
                    bus.Tag = id.Value;
                }
                bus.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);


                BarButtonItem bus2 = new BarButtonItem(e.Manager, "Seçilen Þahýslarý Kayýt Ekranýnda Aç");
                int? id2 = Convert.ToInt32(((System.Data.DataRowView)(e.Rows)).Row["ID"]);
                if (id2.HasValue)
                {
                    bus2.Tag = id2.Value;
                }
                bus2.ItemClick += barSecilenkeriKayitEkranindaAc_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus2);

                BarButtonItem bus3 = new BarButtonItem(e.Manager, "Seçilen Þahýsýn Ýliþkili Kayýtlarýný Aç");
                int? id3 = Convert.ToInt32(((System.Data.DataRowView)(e.Rows)).Row["ID"]);
                if (id3.HasValue)
                {
                    bus3.Tag = id3.Value;
                }
                bus3.ItemClick += barSecilenIliskiliKayitlarAc_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus3);
            }
            //else if (e.Column != null && e.Column.FieldName == "YETKILI_CARI_2_ID")
            //{
            //    BarSubItem bus = new BarSubItem(e.Manager, "Düzenle");

            //    BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");

            //    bus.ItemLinks.Add(barBtnSecimiKaldir);

            //    AvukatProLib.Arama.AV001_TDI_BIL_CARI secim = e.Rows as AvukatProLib.Arama.AV001_TDI_BIL_CARI;

            //    int? id = secim.YETKILI_CARI_2_ID;
            //    if (id.HasValue)
            //    {
            //        barBtnSecimiKaldir.Tag = id.Value;
            //    }
            //    barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
            //    e.MyPopupMenu.ItemLinks.Insert(0, bus);
            //}
            //else if (e.Column != null && e.Column.FieldName == "YETKILI_CARI_1_ID")
            //{
            //    BarSubItem bus = new BarSubItem(e.Manager, "Düzenle");

            //    BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");

            //    bus.ItemLinks.Add(barBtnSecimiKaldir);

            //    AvukatProLib.Arama.AV001_TDI_BIL_CARI secim = e.Rows as AvukatProLib.Arama.AV001_TDI_BIL_CARI;

            //    int? id = secim.YETKILI_CARI_1_ID;
            //    if (id.HasValue)
            //    {
            //        barBtnSecimiKaldir.Tag = id.Value;
            //    }
            //    barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
            //    e.MyPopupMenu.ItemLinks.Insert(0, bus);
            //}

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

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (e.Item.Name == brbtnMerge.Name)
            //{
            //    if (gvSahis.FocusedRowHandle >= 0)
            //    {
            //        var kisi = MyDataSource[gvSahis.FocusedRowHandle];
            //        int cariId = kisi.ID;
            //        frmCariMerge carimerge = new frmCariMerge();
            //        carimerge.Show();
            //    }
            //}
            if (e.Item.Tag != null)
            {
                //if (e.Item.Name == brMerge.Name)
                //{
                //    AdimAdimDavaKaydi.Forms.frmCariMerge frmCariMerge =
                //        new AdimAdimDavaKaydi.Forms.frmCariMerge(e.Item.Tag as AvukatProLib.Arama.AV001_TDI_BIL_CARI);

                //    frmCariMerge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                //    frmCariMerge.ShowDialog();
                //}
                //else 
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
                    //frmicraDosyaKayit.MdiParent = null;
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
                    AdimAdimDavaKaydi.frmCariGenelGiris cariForms;
                    cariForms = new frmCariGenelGiris();
                    cariForms.YeniKayitMi = true;
                    //cariForms.MdiParent = null;
                    cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cariForms.Show();
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
                    // frmdavaDosyaKayit.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }

                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is AvukatProLib.Arama.AV001_TDI_BIL_CARI)
                    {
                        AvukatProLib.Arama.AV001_TDI_BIL_CARI cari = e.Item.Tag as AvukatProLib.Arama.AV001_TDI_BIL_CARI;

                        string tablob = "AvukatProLib.Arama.AV001_TDI_BIL_CARI";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (cari.ID != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.SetByTableNameAndId(tablob, cari.ID);
                                // belgeKayit.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }

                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    if (e.Item.Tag is AvukatProLib.Arama.AV001_TDI_BIL_CARI)
                    {
                        AvukatProLib.Arama.AV001_TDI_BIL_CARI takip =
                            e.Item.Tag as AvukatProLib.Arama.AV001_TDI_BIL_CARI;
                        string tabloI = "AvukatProLib.Arama.AV001_TDI_BIL_CARI";
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
                    //if (e.Item.Tag is AvukatProLib.Arama.AV001_TDI_BIL_CARI)
                    //{
                    //    AvukatProLib.Arama.AV001_TDI_BIL_CARI takip = e.Item.Tag as AvukatProLib.Arama.AV001_TDI_BIL_CARI;
                    //    bool islemYap = true;
                    //    if (takip.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AvukatProLib.Arama.AV001_TDI_BIL_CARI";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        d.ShowDialog(tabloB, takip.ID);

                    //    }
                    //}
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    if (e.Item.Tag is AvukatProLib.Arama.AV001_TDI_BIL_CARI)
                    {
                        AvukatProLib.Arama.AV001_TDI_BIL_CARI takip =
                            e.Item.Tag as AvukatProLib.Arama.AV001_TDI_BIL_CARI;
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.CariArama, takip.ID);
                    }
                }
                else if (e.Item.Tag == "SendSms")
                {
                    string _cariId;
                    string _ad;
                    string _cepTel1;
                    string _cepTel2;
                    string _mail1;
                    string _mail2;
                    string _fax1;
                    string _fax2;
                    DataTable dt = new DataTable();
                    DataColumn dcId = new DataColumn("Id");
                    DataColumn dcAd = new DataColumn("Ad");
                    DataColumn dcEmail1 = new DataColumn("Email1");
                    DataColumn dcEmail2 = new DataColumn("Email2");
                    DataColumn dcCepTel = new DataColumn("CepTel");
                    DataColumn dcCepTel2 = new DataColumn("CepTel2");
                    DataColumn dcFax = new DataColumn("Fax");
                    DataColumn dcEvFax = new DataColumn("EvFax");
                    dt.Columns.Add(dcId);
                    dt.Columns.Add(dcAd);
                    dt.Columns.Add(dcEmail1);
                    dt.Columns.Add(dcEmail2);
                    dt.Columns.Add(dcCepTel);
                    dt.Columns.Add(dcCepTel2);
                    dt.Columns.Add(dcFax);
                    dt.Columns.Add(dcEvFax);
                    for (int rowHandle = 0; rowHandle < gvSahis.RowCount; rowHandle++)
                    {
                        if ((bool)gvSahis.GetRowCellValue(rowHandle, "IsSelected"))
                        {
                            _cariId = gvSahis.GetRowCellValue(rowHandle, "ID").ToString();
                            if (gvSahis.GetRowCellValue(rowHandle, "AD") == null)
                            {
                                _ad = "";
                            }
                            else
                            {
                                _ad = gvSahis.GetRowCellValue(rowHandle, "AD").ToString();
                            }
                            if (gvSahis.GetRowCellValue(rowHandle, "CEP_TEL") == null)
                            {
                                _cepTel1 = "";
                            }
                            else
                            {
                                _cepTel1 = gvSahis.GetRowCellValue(rowHandle, "CEP_TEL").ToString();
                            }
                            if (gvSahis.GetRowCellValue(rowHandle, "CEP_TEL2") == null)
                            {
                                _cepTel2 = "";
                            }
                            else
                            {
                                _cepTel2 = gvSahis.GetRowCellValue(rowHandle, "CEP_TEL2").ToString();
                            }
                            if (gvSahis.GetRowCellValue(rowHandle, "EMAIL_1") == null)
                            {
                                _mail1 = "";
                            }
                            else
                            {
                                _mail1 = gvSahis.GetRowCellValue(rowHandle, "EMAIL_1").ToString();
                            }
                            if (gvSahis.GetRowCellValue(rowHandle, "EMAIL_2") == null)
                            {
                                _mail2 = "";
                            }
                            else
                            {
                                _mail2 = gvSahis.GetRowCellValue(rowHandle, "EMAIL_2").ToString();
                            }
                            if (gvSahis.GetRowCellValue(rowHandle, "FAX") == null)
                            {
                                _fax1 = "";
                            }
                            else
                            {
                                _fax1 = gvSahis.GetRowCellValue(rowHandle, "FAX").ToString();
                            }
                            if (gvSahis.GetRowCellValue(rowHandle, "EV_FAX") == null)
                            {
                                _fax2 = "";
                            }
                            else
                            {
                                _fax2 = gvSahis.GetRowCellValue(rowHandle, "EV_FAX").ToString();
                            }

                           
                           
                            dt.Rows.Add(_cariId, _ad, _mail1, _mail2, _cepTel1, _cepTel2, _fax1, _fax2);
                        }
                    }
                    if (dt.Rows.Count>0)
                    {
                        AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms smail = new AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms();
                        smail.Show(dt, e.Item.Tag.ToString());
                    }
                    else
                    {
                        XtraMessageBox.Show("Editöre göndermek için geliþme seçiniz!");
                    }
                }
                else if (e.Item.Tag == "SendMail")
                {
                    string _cariId;
                    string _ad;
                    string _cepTel1;
                    string _cepTel2;
                    string _mail1;
                    string _mail2;
                    string _fax1;
                    string _fax2;
                    DataTable dt = new DataTable();
                    DataColumn dcId = new DataColumn("Id");
                    DataColumn dcAd = new DataColumn("Ad");
                    DataColumn dcEmail1 = new DataColumn("Email1");
                    DataColumn dcEmail2 = new DataColumn("Email2");
                    DataColumn dcCepTel = new DataColumn("CepTel");
                    DataColumn dcCepTel2 = new DataColumn("CepTel2");
                    DataColumn dcFax = new DataColumn("Fax");
                    DataColumn dcEvFax = new DataColumn("EvFax");
                    dt.Columns.Add(dcId);
                    dt.Columns.Add(dcAd);
                    dt.Columns.Add(dcEmail1);
                    dt.Columns.Add(dcEmail2);
                    dt.Columns.Add(dcCepTel);
                    dt.Columns.Add(dcCepTel2);
                    dt.Columns.Add(dcFax);
                    dt.Columns.Add(dcEvFax);
                    for (int rowHandle = 0; rowHandle < gvSahis.RowCount; rowHandle++)
                    {
                        if ((bool)gvSahis.GetRowCellValue(rowHandle, "IsSelected"))
                        {
                            _cariId = gvSahis.GetRowCellValue(rowHandle, "ID").ToString();
                            _ad = gvSahis.GetRowCellValue(rowHandle, "AD").ToString();
                            _cepTel1 = gvSahis.GetRowCellValue(rowHandle, "CEP_TEL").ToString();
                            _cepTel2 = gvSahis.GetRowCellValue(rowHandle, "CEP_TEL2").ToString();
                            _mail1 = gvSahis.GetRowCellValue(rowHandle, "EMAIL_1").ToString();
                            _mail2 = gvSahis.GetRowCellValue(rowHandle, "EMAIL_2").ToString();
                            _fax1 = gvSahis.GetRowCellValue(rowHandle, "FAX").ToString();
                            _fax2 = gvSahis.GetRowCellValue(rowHandle, "EV_FAX").ToString();
                            dt.Rows.Add(_cariId, _ad, _mail1, _mail2, _cepTel1, _cepTel2, _fax1, _fax2);
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms smail = new AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms();
                        smail.Show(dt, e.Item.Tag.ToString());
                    }
                    else
                    {
                        XtraMessageBox.Show("Editöre göndermek için geliþme seçiniz!");
                    }
                }
                else if (e.Item.Tag == "SendFax")
                {
                    string _cariId;
                    string _ad;
                    string _cepTel1;
                    string _cepTel2;
                    string _mail1;
                    string _mail2;
                    string _fax1;
                    string _fax2;
                    DataTable dt = new DataTable();
                    DataColumn dcId = new DataColumn("Id");
                    DataColumn dcAd = new DataColumn("Ad");
                    DataColumn dcEmail1 = new DataColumn("Email1");
                    DataColumn dcEmail2 = new DataColumn("Email2");
                    DataColumn dcCepTel = new DataColumn("CepTel");
                    DataColumn dcCepTel2 = new DataColumn("CepTel2");
                    DataColumn dcFax = new DataColumn("Fax");
                    DataColumn dcEvFax = new DataColumn("EvFax");
                    dt.Columns.Add(dcId);
                    dt.Columns.Add(dcAd);
                    dt.Columns.Add(dcEmail1);
                    dt.Columns.Add(dcEmail2);
                    dt.Columns.Add(dcCepTel);
                    dt.Columns.Add(dcCepTel2);
                    dt.Columns.Add(dcFax);
                    dt.Columns.Add(dcEvFax);
                    for (int rowHandle = 0; rowHandle < gvSahis.RowCount; rowHandle++)
                    {
                        if ((bool)gvSahis.GetRowCellValue(rowHandle, "IsSelected"))
                        {
                            _cariId = gvSahis.GetRowCellValue(rowHandle, "ID").ToString();
                            _ad = gvSahis.GetRowCellValue(rowHandle, "AD").ToString();
                            _cepTel1 = gvSahis.GetRowCellValue(rowHandle, "CEP_TEL").ToString();
                            _cepTel2 = gvSahis.GetRowCellValue(rowHandle, "CEP_TEL2").ToString();
                            _mail1 = gvSahis.GetRowCellValue(rowHandle, "EMAIL_1").ToString();
                            _mail2 = gvSahis.GetRowCellValue(rowHandle, "EMAIL_2").ToString();
                            _fax1 = gvSahis.GetRowCellValue(rowHandle, "FAX").ToString();
                            _fax2 = gvSahis.GetRowCellValue(rowHandle, "EV_FAX").ToString();
                            dt.Rows.Add(_cariId, _ad, _mail1, _mail2, _cepTel1, _cepTel2, _fax1, _fax2);
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms smail = new AdimAdimDavaKaydi.Mail.frmSpecialBulkMailAndSms();
                        smail.Show(dt, e.Item.Tag.ToString());
                    }
                    else
                    {
                        XtraMessageBox.Show("Editöre göndermek için geliþme seçiniz!");
                    }
                }
            }
        }
        
        public DataTable MyDataSource
        {
            get
            {
                return exGridCariArama.DataSource as DataTable;
            }
            set
            {
                exGridCariArama.DataSource = value;
                //extendedGridControl1.DataSource = exGridCariArama.DataSource;
            }
        }

       
        private TList<AV001_TDI_BIL_CARI> seciliCariKayitlari;
        public TList<AV001_TDI_BIL_CARI> GetSelectedPerson(DataTable cari)
        {
            //secilenCarilerim.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)item["ID"]));
            seciliCariKayitlari = new TList<AV001_TDI_BIL_CARI>();
            foreach (DataRow f in cari.Rows)
            {
                if (Convert.ToBoolean(f["IsSelected"]))
                    seciliCariKayitlari.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)f["ID"]));
            }
            return seciliCariKayitlari;
        }

        private AvukatProLib.Arama.AV001_TDI_BIL_CARI secilenCari;

        public AvukatProLib.Arama.AV001_TDI_BIL_CARI GetSelectedCari(List<AvukatProLib.Arama.AV001_TDI_BIL_CARI> cari)
        {
            secilenCari = new AvukatProLib.Arama.AV001_TDI_BIL_CARI();
            foreach (var secilenim in cari)
            {
                if (secilenim.IsSelected)
                {
                    secilenCari = secilenim;
                    //return secilenCari;
                }
                else
                    secilenCari = null;
            }

            return secilenCari;
        }

        public DataTable SeciliCariler
        {
            get
            {
                if (!DesignMode)
                {
                    DataTable seciliCariler = new DataTable();
                    for (int i = 0; i < this.MyDataSource.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(this.MyDataSource.Rows[i]["IsSelected"]))
                        {
                            seciliCariler.Rows.Add(this.MyDataSource.Rows[i]);
                        }
                    }
                    if (seciliCariler.Rows.Count > 0)
                    {
                        return seciliCariler;
                    }
                }

                return null;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    for (int i = 0; i < this.MyDataSource.Rows.Count; i++)
                    {
                        for (int y = 0; y < value.Rows.Count; y++)
                        {
                            if (this.MyDataSource.Rows[i]["ID"].ToString() == value.Rows[y]["ID"].ToString())
                            {
                                this.MyDataSource.Rows[i]["IsSelected"] = true;
                            }
                        }
                    }
                }
            }
        }

        private void ucCariArama_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.KimlikTurGetir(rLueKimlik);
            BelgeUtil.Inits.UyrukGetir(rLueUyruk);
            BelgeUtil.Inits.CinsiyetGetir(rLueCinsiyet);
            BelgeUtil.Inits.MedeniHalGetir(rLueMedeniHal);
            BelgeUtil.Inits.KanGrupGetir(rLueKanGrup);
            BelgeUtil.Inits.KimlikVerilisNedenGetir(rLueCuzdanVerilmeNeden);

            SagTusaEkle();

            exGridCariArama.ButtonCevirClick += exGridCariArama_ButtonCevirClick;
            //extendedGridControl1.ButtonCevirClick += exGridCariArama_ButtonCevirClick;
        }

        private void exGridCariArama_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //if (exGridCariArama.Visible)
            //{
            //    exGridCariArama.Visible = false;
                //extendedGridControl1.Visible = true;
            //}
            //else
            //{
                //extendedGridControl1.Visible = false;
            //    exGridCariArama.Visible = true;
            //}
        }

        public event EventHandler<EventArgs> KayitSilindi;

        private void exGridCariArama_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "KayitSil")
            {
                //AvukatProLib.Arama.AV001_TDI_BIL_CARI cari =
                //    bandedGridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TDI_BIL_CARI;
                //string Foy_no = cari.AD;
                string ad = gvSahis.GetFocusedRowCellValue("AD").ToString();
                int cariId = (int)gvSahis.GetFocusedRowCellValue("ID");
                frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_CARI", "ID = " + cariId);
                if (kayitSil.ShowDialog() == DialogResult.OK)
                {
                    if (KayitSilindi != null)
                        KayitSilindi(this, new EventArgs());

                    XtraMessageBox.Show(ad + " 'Ýsimli Cari Silinmiþtir");
                }
            }
            else if (e.Button.Tag.ToString() == "Ekle")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris ();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Yeni kayýtlarý görmek için tekrar sorgulama yapmanýz gerekmektedir...");
        }

        private void exGridCariArama_DoubleClick(object sender, EventArgs e)
        {
            //if (bandedGridView1.FocusedRowHandle >= 0)
            if (gvSahis.FocusedRowHandle >= 0)
            {
                //int cariId = (int)MyDataSource.Rows[gvSahis.FocusedRowHandle]["ID"];
                int cariId = (int)gvSahis.GetFocusedRowCellValue("ID");
                AdimAdimDavaKaydi.frmCariGenelGiris cariForms;
                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                    cariForms = new frmCariGenelGiris();
                DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>), typeof(TList<AV001_TDI_BIL_CARI_BANKA>));
                cariForms.YeniKayitMi = false;
                cariForms.MyCari = cari;
                //cariForms.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        private void bBtnMerge_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}