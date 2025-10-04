using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Belge.UserControls;
using AdimAdimDavaKaydi.Editor;
using AdimAdimDavaKaydi.Editor.Degiskenler.Util;
using AdimAdimDavaKaydi.Editor.Forms;
using AdimAdimDavaKaydi.Is.Forms;
using AdimAdimDavaKaydi.Is.General.Gorev;
using AdimAdimDavaKaydi.UserControls;
using AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge;
using AdimAdimDavaKaydi.Util;
using AvukatProDegiskenler.Util;
using AvukatProEditorDegisken;
using AvukatProLib;
using AvukatProLib.Hesap;
using AvukatProLib.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using TableConverter;
using TXTextControl;

namespace AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge
{
    public partial class frmEditor : AdimAdimDavaKaydi.Util.BaseClasses.AvpRibbonForm
    {
        private string _BarkodTip = "";

        private AvukatProLib.Arama.AvpDataContext context =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        #region Bar Button Item Click

        //Þablon kaydýndan yeni sablonun ilgili yere gelmesini saðlamak için eklendi. MB
        public bool Refresh
        {
            set
            {
                if (value)
                {
                    BelgeUtil.Inits._SablonRaporGetir = null;
                    DokumanDoldur();
                }
            }
        }

        //Kaydet
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.Save();
        }

        //Bull
        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmEditorFind find = new frmEditorFind();
                find.ShowFindDialog(this.CurrentEditor);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            //this.CurrentEditor.Find("");
        }

        //Set Margins
        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.textControl1.FormattingStylesDialog();
        }

        private void barButtonItem116_ItemClick(object sender, ItemClickEventArgs e)
        {
            TList<AV001_TDIE_BIL_BELGE> lstBelge = new TList<AV001_TDIE_BIL_BELGE>();
            for (int i = 0; i < this.editors.Count; i++)
            {
                lstBelge.Add(this.editors[i].GetBelge());
            }

            frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
            belgeKayit.Child.MyDataSource = lstBelge;

            //belgeKayit.MdiParent = null;
            belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            belgeKayit.Show();

            for (int i = 0; i < this.editors.Count; i++)
            {
                this.editors[i].Print();
            }
        }

        private void barButtonItem117_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < this.editors.Count; i++)
            {
                this.editors[i].Preview();
            }
        }

        //Yeni Sekme
        private void barButtonItem118_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.NewTab();
        }

        //Yeni Dosya
        private void barButtonItem119_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEditor editor = new frmEditor();
            editor.MdiParent = mdiAvukatPro.MainForm;
            editor.Show();
        }

        //Dikeuy Sayfa
        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.textControl1.Landscape = !CurrentEditor.textControl1.Landscape;
        }

        private void barButtonItem120_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDegiskenler degiskenler = new frmDegiskenler();
            degiskenler.ShowDialog();

            //GrupAciklama.frmMain mainAciklama = new GrupAciklama.frmMain();
            //if (selectedFoy != null)
            //{
            //    if (this.SelectedFoys.Count > 0)
            //    {
            //        AvukatProLib2.Entities.AV001_TI_BIL_FOY myRecord = (AvukatProLib2.Entities.AV001_TI_BIL_FOY)this.SelectedFoys[0];
            //        mainAciklama.Show();
            //    }
            //    else
            //    {
            //        mainAciklama.Show();

            //    }
            //}
            //else
            //{
            //    mainAciklama.Show();
            //}
        }

        private void barButtonItem121_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowDialog();
            this.SelectedFoys = Tools.DeSerializeClass<TList<AV001_TI_BIL_FOY>>(opf.FileName);
            if (SelectedFoys is TList<AV001_TI_BIL_FOY>)
            {
                if (((TList<AV001_TI_BIL_FOY>)SelectedFoys).Count >= 1)
                {
                    this.uctxEditor1.Icra = (AV001_TI_BIL_FOY)SelectedFoys[0];
                }
            }
        }

        private void barButtonItem122_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCokluSecim cokluyaz = new frmCokluSecim();
            cokluyaz.Editor = this;

            //cokluyaz.MdiParent = null;
            cokluyaz.StartPosition = FormStartPosition.WindowsDefaultLocation;
            cokluyaz.Show();
        }

        private void barButtonItem123_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmYazdirmaAyarlari yazdirmaAyarlari = new frmYazdirmaAyarlari();

            //yazdirmaAyarlari.MdiParent = null;
            yazdirmaAyarlari.StartPosition = FormStartPosition.WindowsDefaultLocation;
            yazdirmaAyarlari.Show();
        }

        private void barButtonItem124_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem125_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem127_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        //Yatay Sayfa
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            //CurrentEditor.textControl1.PageSize.Height = Tools.CmToPixcel(Tools.PixcelToCm(CurrentEditor.textControl1.PageSize.Width, true), false);
            //CurrentEditor.textControl1.PageSize.Width =Tools.CmToPixcel( Tools.PixcelToCm(CurrentEditor.textControl1.PageSize.Height, false),true);
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(frmEditor));
            CurrentEditor.textControl1.Landscape = !CurrentEditor.textControl1.Landscape;
            if (CurrentEditor.textControl1.Landscape)
            {
                barButtonItem13.LargeGlyph =
                    ((System.Drawing.Image)(resources.GetObject("barButtonItem12.LargeGlyph")));
            }
            else
            {
                barButtonItem13.LargeGlyph =
                    ((System.Drawing.Image)(resources.GetObject("barButtonItem13.LargeGlyph")));
            }
        }

        private void barButtonItem139_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        //Tümünü Otomatik doldur...
        private void barButtonItem14_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < editors.Count; i++)
            {
                this.CurrentEditor = editors[i];
                this.c_tcEditors.SelectedTabPage = editors[i].Page;
                CurrentEditor.SetFieldsValues(false);
            }
        }

        private void barButtonItem147_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (BelgeUtil.Inits._SablonRaporGetir == null)
                BelgeUtil.Inits._SablonRaporGetir =
                    BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.ToList(); // Okan
            frmTumsablonlar tumSablonlar = new frmTumsablonlar();
            tumSablonlar.ucSablonRapor1.MyDataSource = BelgeUtil.Inits._SablonRaporGetir;

            //tumSablonlar.MdiParent = null;
            tumSablonlar.StartPosition = FormStartPosition.WindowsDefaultLocation;
            tumSablonlar.Show();
        }

        private void barButtonItem148_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem149_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cnt == 0)
            {
                cnt = Convert.ToInt32(Encoding.UTF8.GetString(Tools.GetBytesFromFile("e:\\Sablon\\deneme.txt")));
            }
            else
            {
                Tools.SaveTofile("e:\\Sablon\\deneme.txt", cnt.ToString());
            }
            OpenRecord(raporlar[cnt], this.uctxEditor1.textControl1);
            if (Degiskenler == null || Degiskenler.Count == 0) // Okan
                Degiskenler = context.VDIE_BIL_SABLON_DEGISKENLERs.ToList();
            TXTextControl.TextFieldCollectionBase.TextFieldEnumerator enms =
                this.uctxEditor1.textControl1.TextFields.GetEnumerator();
            while (enms.MoveNext())
            {
                TextField tf = (TextField)enms.Current;
                AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER d =
                    GetVar(tf.Name.Split(new[] { "__" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                if (d != null)
                {
                    tf.Text = d.GORUNEN_AD;
                }
            }
            cnt++;
        }

        private void barButtonItem150_ItemClick(object sender, ItemClickEventArgs e)
        {
            byte[] veri = new byte[this.acilanRapor.DOSYA.Length];
            this.uctxEditor1.textControl1.Save(out veri, acilanTipi);
            this.acilanRapor.DOSYA = veri;
            AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.Save(acilanRapor);
            MessageBox.Show("kaydedildi!!!");
        }

        private void barButtonItem151_ItemClick(object sender, ItemClickEventArgs e)
        {
            AV001_TI_BIL_FOY foy = DegiskenHelper.GetSelectedKayitByModul(2).Kayit as AV001_TI_BIL_FOY;
            AvukatProUyap.Helper.GetUyap(BelgeUtil.Inits.context.per_AV001_TI_BIL_ICRA_Aramas.Single(item => item.ID == foy.ID));
        }

        //Tablo Ekle
        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                CurrentEditor.AddTable();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        //TextFrame Ekle
        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAlanEkle alanekle = new frmAlanEkle();
            alanekle.ShowMe(this.CurrentEditor.textControl1);
        }

        private void barButtonItem17_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                CurrentEditor.AddFrame();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        //Resim Ekle
        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.textControl1.Images.Add();
        }

        //Sil
        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.textControl1.Clear();
        }

        //Aç
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.Open();
        }

        //Tümünü Seç
        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.textControl1.SelectAll();
        }

        //Ýmza Ekle
        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            AvukatProImageEditor.AvproImageEditor ieditor = new AvukatProImageEditor.AvproImageEditor();
            ieditor.ShowDialog();
            this.uctxEditor1.AddImageFromMemory(ieditor.OpenedImage, true);
        }

        //üst Bilgi //Alt Bilgi
        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                CurrentEditor.textControl1.HeaderFooterActivationStyle = HeaderFooterActivationStyle.ActivateDoubleClick;
                CurrentEditor.textControl1.HeaderFooterFrameStyle = HeaderFooterFrameStyle.DottedFrame;
                CurrentEditor.textControl1.HeadersAndFooters.Add(HeaderFooterType.Footer);
                CurrentEditor.textControl1.HeadersAndFooters.Add(HeaderFooterType.Header);

                HeaderFooter AltBilgi = CurrentEditor.textControl1.HeadersAndFooters.GetItem(HeaderFooterType.Footer);
                HeaderFooter UstBilgi = CurrentEditor.textControl1.HeadersAndFooters.GetItem(HeaderFooterType.Header);
                AltBilgi.Activate();
                UstBilgi.Activate();

                AltBilgi.Selection.Text = " alt Bilgi";
                UstBilgi.Selection.Text = " ust Bilgi";

                AltBilgi.PageNumberFields.Add(new PageNumberField(1, NumberFormat.ArabicNumbers));

                //AltBilgi.TextFields.Add(new TextField("4123423"));
                //UstBilgi.TextFields.Add(new TextField("eadasdsa"));
                CurrentEditor.textControl1.HeaderFooterActivationStyle = HeaderFooterActivationStyle.ActivateClick;
                CurrentEditor.textControl1.HeaderFooterFrameStyle = HeaderFooterFrameStyle.DottedFrame;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        /// <summary>
        /// Tablo Düzenle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.textControl1.TableFormatDialog();
        }

        //Antet
        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            AvukatProImageEditor.AvproImageEditor ieditor = new AvukatProImageEditor.AvproImageEditor();
            ieditor.ShowDialog();
            this.uctxEditor1.AddImageFromMemory(ieditor.OpenedImage, true);
        }

        //Filigran Ekle
        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.uctxEditor1.WaterMark != string.Empty)
            {
                t.Text = this.uctxEditor1.WaterMark;
            }
            AvukatProImageEditor.AvproImageEditor ieditor = new AvukatProImageEditor.AvproImageEditor();
            ieditor.ShowDialog();
            this.uctxEditor1.WaterMarkImage = ieditor.OpenedImage;
            this.uctxEditor1.WaterMarkLocation = new Point(ieditor.Position.X * 8, ieditor.Position.Y * 8);
            this.uctxEditor1.YaziTipi = ieditor.YaziTipi;
            this.uctxEditor1.WaterMark = ieditor.Text;
            this.uctxEditor1.DrawWaterMark(ieditor.OpenedImage, new Point(1, 1));
        }

        //Tarih Saat
        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.textControl1.Selection.Text = DateTime.Now.ToString();
        }

        //Elektronik imza
        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        //Þifre Tanýmý
        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        //Dokuman Þifrele
        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            string pwd = string.Empty;
            ;
            Form frm = new Form();
            frm.Size = new Size(300, 100);
            TextEdit te = new TextEdit();
            te.Location = new Point(0, 0);
            frm.Text = "Þifre Belirleyiniz";
            te.Properties.PasswordChar = '*';
            SimpleButton btn = new SimpleButton();
            btn.Text = "Kapat";
            btn.Location = new Point(te.Location.X, 40);
            frm.Controls.Add(btn);
            frm.Controls.Add(te);
            frm.Show();
            btn.Click += delegate { frm.Close(); };
            frm.FormClosed += delegate
                                  {
                                      pwd = te.Text;

                                      byte[] veri; //= new byte[1000000];
                                      CurrentEditor.textControl1.Save(out veri,
                                                                      TXTextControl.BinaryStreamType.InternalFormat);
                                      byte[] sifreli = Tools.Sifrele(veri);

                                      anahtar = Tools.anahtar;
                                      vektor = Tools.Vektor;

                                      PaswordedFile pf = new PaswordedFile();
                                      pf.Datas = sifreli;
                                      pf.Key = anahtar;
                                      pf.Vektor = vektor;
                                      pf.Pwd = pwd;
                                      pf.Name = this.CurrentEditor.Name;
                                      SaveFileDialog sfd = new SaveFileDialog();
                                      sfd.Filter = "*.txp|þifreli Editör Dosyasý";
                                      sfd.DefaultExt = "txp";
                                      sfd.AddExtension = true;
                                      sfd.ShowDialog();

                                      string fileName = sfd.FileName;
                                      DialogResult dr =
                                          XtraMessageBox.Show(
                                              "Bu belgeyi " + fileName + " dosyasý olark kaydetmek üzeresiniz ! ",
                                              "Kayýt iþlemi yapýlýyor ! ", MessageBoxButtons.OKCancel);
                                      if (dr == DialogResult.OK)
                                      {
                                          Tools.SerializeClass(pf, fileName);
                                      }
                                  };
        }

        //Dokuman Þifre Çöz
        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "*.txp|þifreli Editör Dosyasý";
            opf.DefaultExt = "txp";

            DialogResult dro = opf.ShowDialog();
            if (dro == DialogResult.Cancel)
            {
                return;
            }
            PaswordedFile pf = Tools.DeSerializeClass<PaswordedFile>(opf.FileName);
            string pwd = string.Empty;
            Form frm = new Form();
            frm.Size = new Size(300, 100);
            TextEdit te = new TextEdit();
            te.Location = new Point(0, 0);
            frm.Text = "Þifre Giriniz";
            te.Properties.PasswordChar = '*';
            SimpleButton btn = new SimpleButton();
            btn.Text = "Kapat";
            btn.Location = new Point(te.Location.X, 40);
            frm.Controls.Add(btn);
            frm.Controls.Add(te);
            frm.Show();
            btn.Click += delegate { frm.Close(); };
            frm.FormClosed += delegate
                                  {
                                      if (pf.Pwd == te.Text)
                                      {
                                          byte[] veri = new byte[0];

                                          //CurrentEditor.textControl1.Save(out veri, TXTextControl.BinaryStreamType.InternalFormat);
                                          byte[] sifresiz = Tools.SifreCoz(pf.Key, pf.Vektor, pf.Datas);
                                          DialogResult dr =
                                              XtraMessageBox.Show(
                                                  "Bu belgeyi kapatýp yerine þifreli içerikteki " + opf.FileName +
                                                  " dosyasýný açýyorsunuz ! ", "içerik silinecek ! ",
                                                  MessageBoxButtons.OKCancel);

                                          if (dr == DialogResult.OK)
                                          {
                                              this.CurrentEditor.textControl1.Load(sifresiz,
                                                                                   TXTextControl.BinaryStreamType.
                                                                                       InternalFormat);
                                          }
                                      }
                                      else
                                          XtraMessageBox.Show("Yanlýþ Þifre Girdiniz Dosyayý Açamýyoruz...");
                                  };
        }

        //Otomatik Doldur
        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.FieldFilled = false;
            CurrentEditor.SetFieldsValues(false);
        }

        //Yeni Kayýt Getir
        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.FieldFilled = false;
            CurrentEditor.SetFieldsValues(true);
        }

        //Geri
        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.textControl1.Undo();
        }

        //Ýleri
        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.textControl1.Redo();
        }

        //Sözcük denetimi
        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.SozcukDenetimi();
        }

        //Yazým Yardýmcýsý
        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.YazimYardimcisi();
        }

        //Hukuk Sözlüðü
        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.YazimYardimcisi();
        }

        //Yazdýr
        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Belge Kaydý Oluþturulsun mu?", "Belge Oluþtur...",
                                                  MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                TList<AV001_TDIE_BIL_BELGE> lstBelge = new TList<AV001_TDIE_BIL_BELGE>();
                lstBelge.Add(this.CurrentEditor.GetBelge());

                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                belgeKayit.Child.MyDataSource = lstBelge;

                //belgeKayit.MdiParent = null;
                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;

                belgeKayit.Show();
                belgeKayit.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
            }

            CurrentEditor.textControl1.Print(this.CurrentEditor.Name);
        }

        //Önizleme
        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.Preview();
        }

        /// <summary>
        /// Text Frame Düzenle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TextFrameSelected)
            {
                this.CurrentEditor.textControl1.TextFrameAttributesDialog();
            }
        }

        /// <summary>
        /// Resim düzenle ..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.textControl1.ImageAttributesDialog();
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = new Form();
            LookUpEdit le = new LookUpEdit();
            le.Properties.DataSource = Degerler.TabloAlani();
            le.Properties.DisplayMember = "Ad";
            le.Properties.ValueMember = "Degeri";
            le.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad"));
            le.Dock = DockStyle.Top;
            ChartControl ccont = new ChartControl();
            ccont.Dock = DockStyle.Fill;
            le.EditValueChanged +=
                delegate { ccont.DataSource = TableStringConverter.GetAllRecordByTableName(le.EditValue.ToString()); };
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            btn.Text = "tamam";
            btn.Dock = DockStyle.Bottom;
            btn.Click += delegate
                             {
                                 string yol = Tools.TempFilesPath + DateTime.Now.Ticks + ".html";
                                 ccont.ExportToHtml(yol);
                                 frm.Close();
                                 this.uctxEditor1.textControl1.Selection.Load(yol, TXTextControl.StreamType.HTMLFormat);
                             };
            frm.Controls.Add(btn);
            frm.Controls.Add(le);
            frm.Controls.Add(ccont);
            frm.Show();
        }

        //Yazdýr
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.Print();
        }

        private void barButtonItem51_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// <summary>
        /// Excele Gönder ...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.uctxEditor1.SendToExcel();
        }

        private void barButtonItem54_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.CurrentEditor.selBel != null)
                this.Belge = this.CurrentEditor.selBel;

            if (this.Belge == null)
                XtraMessageBox.Show("Hatýrlatma Kayýdý Yapabilmeniz Ýçin Ýlk Önce Belge Kayýdý Yapmalýsýnýz");
            else
            {
                frmIsKayitUfak frmIsKayit = new frmIsKayitUfak();
                if (this.IS == null)
                {
                    TList<NN_IS_BELGE> ib = DataRepository.NN_IS_BELGEProvider.GetByBELGE_ID(this.Belge.ID);
                    if (ib.Count < 0)
                        this.IS = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(ib[0].IS_ID);
                }

                if (this.IS != null)
                {
                    if (this.Belge != null)
                    {
                        frmIsKayit.ucIsKayitUfak1.OpenedRecord = this.Belge;
                    }
                    frmIsKayit.ucIsKayitUfak1.Record = this.IS;

                    // frmIsKayit.ucIsKayitUfak1.NewRecord();
                    frmIsKayit.Show();
                }
                else
                    XtraMessageBox.Show("Hatýrlatma Kayýdý Yapabilmeniz Ýçin Ýlk Önce Ýþ Kayýdý Yapmalýsýnýz");
            }
        }

        private void barButtonItem55_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.CurrentEditor.selBel != null)
                this.Belge = this.CurrentEditor.selBel;
            if (this.Belge == null)
                XtraMessageBox.Show("Ýþ Kayýdý Yapabilmeniz Ýçin Ýlk Önce Belge Kayýdý Yapmalýsýnýz");
            else
            {
                frmIsKayitUfak frmIsKayit = new frmIsKayitUfak();
                frmIsKayit.ucIsKayitUfak1.ModulID = 8;
                if (this.Belge != null)
                {
                    frmIsKayit.ucIsKayitUfak1.OpenedRecord = this.Belge;
                }
                frmIsKayit.ucIsKayitUfak1.Saved += ucIsKayitUfak1_Saved;

                //frmIsKayit.ucIsKayitUfak1.NewRecord();
                frmIsKayit.Show();
            }
        }

        /// <summary>
        /// Word e Gönder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {
            string dosyaAdi = Tools.TempFilesPath + Guid.NewGuid() + ".docx";
            this.CurrentEditor.textControl1.Save(dosyaAdi, TXTextControl.StreamType.WordprocessingML);
            Tools.OpenProgram(dosyaAdi);
        }

        /// <summary>
        /// Pdf e Gönder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {
            string dosyaAdi = Tools.TempFilesPath + Guid.NewGuid() + ".pdf";
            this.CurrentEditor.textControl1.Save(dosyaAdi, TXTextControl.StreamType.AdobePDF);
            Tools.OpenProgram(dosyaAdi);
        }

        //Önizleme
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.Preview();
        }

        /// <summary>
        /// NotePAde Gönder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem60_ItemClick(object sender, ItemClickEventArgs e)
        {
            string dosyaAdi = Tools.TempFilesPath + Guid.NewGuid() + ".txt";
            this.CurrentEditor.textControl1.Save(dosyaAdi, TXTextControl.StreamType.PlainAnsiText);
            Tools.OpenProgram(dosyaAdi);
        }

        /// <summary>
        /// Painte Gönder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem61_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        /// <summary>
        /// ExplorerDa Aç
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem62_ItemClick(object sender, ItemClickEventArgs e)
        {
            string dosyaAdi = Tools.TempFilesPath + Guid.NewGuid() + ".html";
            this.CurrentEditor.textControl1.Save(dosyaAdi, TXTextControl.StreamType.HTMLFormat);
            Tools.OpenProgram(dosyaAdi);
        }

        //Veri tabanýna Kaydet
        private void barButtonItem63_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.SaveToDb();
        }

        //Sektor
        private void barButtonItem64_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ucSektor sektor = new ucSektor();
            Form frm = new Form();
            frm.Controls.Add(sektor);
            sektor.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = "Sektor";
            frm.Show();
        }

        //Dil
        private void barButtonItem66_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            try
            {
                ucDil sektor = new ucDil();
                Form frm = new Form();
                frm.Controls.Add(sektor);
                sektor.Dock = DockStyle.Fill;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = "Dil";
                frm.Show();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        //sablon Alt kategori
        private void barButtonItem67_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            try
            {
                ucKategori kat = new ucKategori();
                Form frm = new Form();
                frm.Controls.Add(kat);
                kat.Dock = DockStyle.Fill;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = "Kategori";
                frm.Show();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        /// <summary>
        /// Kayýtlý Sablonlar
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem68_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            try
            {
                ucSablonRapor srpr = new ucSablonRapor();
                Form frm = new Form();
                frm.WindowState = FormWindowState.Maximized;
                frm.Controls.Add(srpr);
                srpr.Dock = DockStyle.Fill;
                frm.Show();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        /// <summary>
        /// Word Pad e Gönder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem69_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            string dosyaAdi = Tools.TempFilesPath + Guid.NewGuid() + ".rtf";
            this.CurrentEditor.textControl1.Save(dosyaAdi, TXTextControl.StreamType.RichTextFormat);
            Tools.OpenProgram(dosyaAdi);
        }

        //Yapýþtýr
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.CurrentEditor.Paste();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        /// <summary>
        /// Özel Sayfa Boyutlarý
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem71_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentEditor.textControl1.FormattingStylesDialog();
        }

        /// <summary>
        ///
        /// dava Talep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem72_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ucDavaTalep kat = new ucDavaTalep();
                Form frm = new Form();
                frm.Controls.Add(kat);
                kat.Dock = DockStyle.Fill;
                frm.Text = "dava Konusu ";
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void barButtonItem73_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.textControl1.ParagraphFormatDialog();
        }

        /// <summary>
        /// Sözleþme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem74_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //ucDavaTalep kat = new ucDavaTalep();
                //Form frm = new Form();
                //frm.Controls.Add(kat);
                //kat.Dock = DockStyle.Fill;
                //frm.WindowState = FormWindowState.Maximized;
                //frm.Text = "Sozleþme";
                //frm.Show();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void barButtonItem75_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucBelgeKayitUfak belgeKayit = new ucBelgeKayitUfak();
            Form rfrmBelgeKaydi = new Form();

            rfrmBelgeKaydi.Width = belgeKayit.Width;
            rfrmBelgeKaydi.Height = belgeKayit.Height + 25;
            rfrmBelgeKaydi.Controls.Add(belgeKayit);
            belgeKayit.OpenedRecord = Rapor;
            if (this.Belge == null)
            {
                belgeKayit.NewRecord();
            }
            else
            {
                TList<AV001_TDIE_BIL_BELGE> lstbelge = new TList<AV001_TDIE_BIL_BELGE>();
                lstbelge.Add(this.Belge);
                belgeKayit.MyDataSource = lstbelge;
            }

            string yol = Tools.TempFilesPath + DateTime.Now.Ticks + ".tx";
            this.uctxEditor1.Save(yol);
            belgeKayit.Current.DOSYA_ADI = yol;
            rfrmBelgeKaydi.Show();
            rfrmBelgeKaydi.Text = "Yeni Bir Belge Ekle";
            belgeKayit.Saved += ucBelgeKayitUfak1_Saved;
            Belge = belgeKayit.Current;
        }

        private void barButtonItem76_ItemClick(object sender, ItemClickEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT foyt = null;
            if (this.CurrentEditor.selBel != null)
                this.Belge = this.CurrentEditor.selBel;
            if (this.Belge == null)
                XtraMessageBox.Show("Tebligat Kayýdý Yapabilmeniz Ýçin Ýlk Önce Belge Kayýdý Yapmalýsýnýz");
            else
            {
                TList<NN_BELGE_TEBLIGAT> nbt = DataRepository.NN_BELGE_TEBLIGATProvider.GetByBELGE_ID(this.Belge.ID);
                if (nbt.Count > 0)
                {
                    foyt = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID(nbt[0].TEBLIGAT_ID);
                    AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit frmTebligatKayit =
                        new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(foyt, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDIE_BIL_BELGE>),
                                                                           typeof(TList<NN_BELGE_TEBLIGAT>),
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>),
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>
                                                                               ));
                    frmTebligatKayit.bndTebligat.DataSource = foyt;
                    frmTebligatKayit.Show();
                }
                else
                {
                    AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit frmTebligatKayit =
                        new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
                    frmTebligatKayit.YenileKayit += frmTebligatKayit_YenileKayit;
                    frmTebligatKayit.bndTebligat.AddNew();
                    frmTebligatKayit.Show();
                }
            }

            #region Eski

            //Form rfrmBelgeKaydi = new Form();
            ////  GetBelge();
            //ucTebligat tebligat = new ucTebligat();
            //AV001_TDI_BIL_TEBLIGAT teblig = RecordGenerator.Generate.GenerateAV001_TDI_BIL_TEBLIGATByRecord(Rapor);
            //TList<AV001_TDI_BIL_TEBLIGAT> lstTeblig = new TList<AV001_TDI_BIL_TEBLIGAT>();
            //teblig.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT.Add(this.Belge);
            //lstTeblig.Add(teblig);
            //tebligat.MyDataSource = lstTeblig;
            //rfrmBelgeKaydi.Controls.Add(tebligat);
            //tebligat.Dock = DockStyle.Fill;
            //rfrmBelgeKaydi.Show();
            //rfrmBelgeKaydi.Text = "Yeni Bir Tebligat Ekle";

            #endregion Eski
        }

        private void barButtonItemTopluMail_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MailListesi != null && MailListesi.Count > 0)
            {
                if (MessageBox.Show("Dosyalara ait bütün sorumlu avukatlara oluþturulan dökümanlar mail olarak gönderilecektir.", "Uyarý", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                List<string> FilePaths = new List<string>();
                int i = 1;
                SaveSettings settings = new SaveSettings();
                settings.CssSaveMode = CssSaveMode.OverwriteFile;
                settings.DocumentAccessPermissions = DocumentAccessPermissions.AllowAll;
                CompInfo MailCompInfo = Kimlikci.Kimlik.SirketBilgisi;
                if (String.IsNullOrEmpty(MailCompInfo.SMTPSunucuAdresi) || String.IsNullOrEmpty(MailCompInfo.SMTPKullaniciAdi)
                || String.IsNullOrEmpty(MailCompInfo.SMTPPort) || String.IsNullOrEmpty(MailCompInfo.SMTPSifre))
                {
                    MessageBox.Show("Lütfen mail ayarlarýnýzý yapýlandýrýnýz.");
                    return;
                }
                var eklentiler = new List<Attachment>();
                
                SmtpClient client;
                AV001_TDI_BIL_CARI cari = null;
                if (Kimlikci.Kimlik != null)
                {
                    cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Kimlikci.Kimlik.Cari_ID);
                }
                if (cari == null)
                    return;
                beklemePaneli.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (beklemePaneli.Width * 2) + (beklemePaneli.Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (beklemePaneli.Height * 2) + (beklemePaneli.Height / 2));
                beklemePaneli.Visible = true;
                
                BackgroundWorker bg = new BackgroundWorker();
                bg.DoWork += delegate
                {
                    foreach (KeyValuePair<EditorDokuman, List<string>> item in MailListesi)
                    {
                        this.CurrentEditor.textControl1.Load(item.Key.Dokuman, BinaryStreamType.InternalFormat);
                        string fileName = i.ToString() + " " + item.Key.FoyNo + " " + item.Key.Ad;
                        if (fileName.Length > 150)
                            fileName = fileName.Substring(0, 150);

                        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fileName + ".doc";
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                        try
                        {
                            this.CurrentEditor.textControl1.Save(filePath, StreamType.MSWord, settings);

                            eklentiler = new List<Attachment>();
                            eklentiler.Add(new Attachment(filePath));

                            client = new SmtpClient(MailCompInfo.SMTPSunucuAdresi, Convert.ToInt32(MailCompInfo.SMTPPort));
                            client.UseDefaultCredentials = false;
                            client.EnableSsl = MailCompInfo.SMTPSSL;
                            NetworkCredential user = new NetworkCredential(MailCompInfo.SMTPKullaniciAdi, MailCompInfo.SMTPSifre);
                            client.Credentials = user;

                            var msg = new MailMessage(user.UserName, item.Value.First());
                            foreach (var mailadre in item.Value.Skip(1))
                            {
                                msg.To.Add(mailadre);
                            }
                            foreach (Attachment atc in eklentiler)
                                msg.Attachments.Add(atc);
                            try
                            {
                                client.Send(msg);
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Logger.ErrorException("Toplu mail hata", ex);
                            }
                            try
                            {
                                if (File.Exists(filePath))
                                    File.Delete(filePath);
                            }
                            catch
                            {
                            }
                        }
                        catch (Exception ex)
                        {
                            BelgeUtil.ErrorHandler.Logger.ErrorException("Toplu mail hata", ex);
                        }

                    }
                };
                bg.RunWorkerCompleted += delegate
                {
                    beklemePaneli.Visible = false;
                    MessageBox.Show("Toplu mail gönderim iþlemi bitmiþtir.");
                };
                bg.RunWorkerAsync();
            }
        }

        private void barButtonItem77_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvSayfalar.DataSource != null)
            {
                var dokumanListesi = gcSayfalar.DataSource as List<EditorDokuman>;
                List<string> FilePaths = new List<string>();
                int i = 1;
                SaveSettings settings = new SaveSettings();
                settings.CssSaveMode = CssSaveMode.OverwriteFile;
                settings.DocumentAccessPermissions = DocumentAccessPermissions.AllowAll;

                foreach (EditorDokuman item in dokumanListesi)
                {
                    this.CurrentEditor.textControl1.Load(item.Dokuman, BinaryStreamType.InternalFormat);
                    string fileName = i.ToString() + " " + item.FoyNo + " " + item.Ad;
                    if (fileName.Length > 150)
                        fileName = fileName.Substring(0, 150);

                    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fileName + ".doc";
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                    try
                    {
                        this.CurrentEditor.textControl1.Save(filePath, StreamType.MSWord, settings);
                    }
                    catch
                    {
                        MessageBox.Show("Dosyalar kaydedilirken hata oluþtu", "Dosya kayýt hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FilePaths.Add(filePath);
                    i++;
                }
                AV001_TDI_BIL_CARI cari = null;
                if (Kimlikci.Kimlik != null)
                {
                    cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Kimlikci.Kimlik.Cari_ID);
                }
                AvukatProLib.Mail.frmMailSender mailSender;
                if (cari != null)
                {
                    if (!String.IsNullOrEmpty(cari.EMAIL_1))
                    {
                        mailSender = new AvukatProLib.Mail.frmMailSender(cari.EMAIL_1, FilePaths);
                        mailSender.ShowDialog();
                    }
                    else
                    {
                        mailSender = new AvukatProLib.Mail.frmMailSender(FilePaths);
                        mailSender.ShowDialog();
                    }
                }
                else
                {
                    mailSender = new AvukatProLib.Mail.frmMailSender(FilePaths);
                    mailSender.ShowDialog();
                }
                foreach (string file in FilePaths)
                {
                    try
                    {
                        if (File.Exists(file))
                            File.Delete(file);
                    }
                    catch
                    {
                    }
                }
            }
        }

        //Kes
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.CurrentEditor.Cut();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        //Kopyala
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.CurrentEditor.Copy();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        //Dokuman Sýkýþtýr
        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            byte[] veri = new byte[0];
            CurrentEditor.textControl1.Save(out veri, TXTextControl.BinaryStreamType.InternalFormat);
            FileStream FS = new FileStream(Tools.TempFilesPath + "veri.txt", FileMode.OpenOrCreate);
            FS.Write(veri, 0, veri.Length);
            FS.Close();

            SaveFileDialog saveZipped = new SaveFileDialog();
            saveZipped.Filter = "*.zip|Sýkýþtýrýlmýþ dosya";
            saveZipped.DefaultExt = "zip";
            saveZipped.AddExtension = true;
            saveZipped.ShowDialog();
            RarHelper.DosyayiRarla(Application.StartupPath, Tools.TempFilesPath + "veri.txt", saveZipped.FileName,
                                   "1q2w3e4r");

            //Tools.SerializeClass(Tools.GZipCompress(veri), saveZipped.FileName);
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            string str = barEditItem1.EditValue.ToString();
        }

        private void bbtnBelgeKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            TList<AV001_TDIE_BIL_BELGE> belgeListesi = new TList<AV001_TDIE_BIL_BELGE>();
            EditorDokuman dok = new EditorDokuman(null);
            dok.Ad = "yeni";

            //   dok.Sablon = new AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR();
            byte[] dizi;
            this.CurrentEditor.textControl1.Save(out dizi, BinaryStreamType.InternalFormat);
            dok.Dokuman = dizi;
            AV001_TDIE_BIL_BELGE belgem = dok.GetBelge(this.CurrentEditor.textControl1);
            belgem.ICERIK = dizi;
            if (belgem != null)
                belgeListesi.Add(belgem);

            frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
            belgeKayit.ucBelgeKayitUfak1.OpenedRecord = null;
            belgeKayit.MyDataSource = belgeListesi;
            belgeKayit.ucBelgeKayitUfak1.Duzenle = true;
            belgeKayit.ucBelgeKayitUfak1.Record = belgem;
            belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            belgeKayit.Show();
            belgeKayit.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
        }

        private void bbtnDosyadanAc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.OpenFile();
        }

        private void bbtnEditorDosyasiOlarakKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "tx";
            sfd.Title = "Editor Belgesi Olarak Kaydet";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                this.CurrentEditor.textControl1.Save(sfd.FileName, StreamType.InternalFormat);
            }
            catch
            {
                MesajCi.Goster("Dosya kaydetme Hatasi", "Dosya kaydedilirken bir hata ile karþýldý",
                               "Dosya kaydedilmeye çalýþýrken {0} hatasý oluþtu", MessageBoxButtons.OK,
                               "www.avukatpro.com", MessageBoxIcon.Error);
                return;
            }
            MesajCi.Goster("Ýþlem Baþarýlý", "Dosya baþarýlý bir þekilde kaydedildi",
                           "Dosya {0} adresine baþarýlý bir sekilde kaydedildi", MessageBoxButtons.OK,
                           "www.avukatpro.com", MessageBoxIcon.Information);
        }

        private void bbtnKayitlardanAc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.Open();
        }

        private void bbtnRaporOlarakSakla_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.Save();
        }

        private void bbtnTumunuBelgeye_ItemClick(object sender, ItemClickEventArgs e)
        {
            TList<AV001_TDIE_BIL_BELGE> lstBelge = new TList<AV001_TDIE_BIL_BELGE>();
            for (int i = 0; i < this.editors.Count; i++)
            {
                lstBelge.Add(this.editors[i].GetBelge());
            }

            frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
            belgeKayit.Child.MyDataSource = lstBelge;

            //belgeKayit.MdiParent = null;
            belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            belgeKayit.Show();
            belgeKayit.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
        }

        private void bbtnTumunuKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < this.editors.Count; i++)
            {
                this.editors[i].Save();
            }
        }

        private void bbtnWordBelgesiOlarakKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "doc";
            sfd.Title = "Word Belgesi Olarak Kaydet";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                this.CurrentEditor.textControl1.Save(sfd.FileName, StreamType.MSWord);
            }
            catch
            {
                MesajCi.Goster("Dosya kaydetme Hatasi", "Dosya kaydedilirken bir hata ile karþýldý",
                               string.Format("Dosya kaydedilmeye çalýþýrken {0} hatasý oluþtu", sfd.FileName),
                               MessageBoxButtons.OK, "www.avukatpro.com", MessageBoxIcon.Error);
                return;
            }
            MesajCi.Goster("Ýþlem Baþarýlý", "Dosya baþarýlý bir þekilde kaydedildi",
                           string.Format("Dosya {0} adresine baþarýlý bir sekilde kaydedildi", sfd.FileName),
                           MessageBoxButtons.OK, "www.avukatpro.com", MessageBoxIcon.Information);
        }

        private void bbtnXmlEGonder_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sdialog = new SaveFileDialog();
            sdialog.ShowDialog();
            Tools.SerializeXml(this.SelectedFoys, sdialog.FileName + ".xmk");
            XtraMessageBox.Show(sdialog.FileName + " Yoluna Dosya kaydý Yapýldý ");
        }

        private void bbtnYeniNot_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmYeniNot yeniNot = new frmYeniNot();
            //yeniNot.ShowDialog("AV001_TI_BIL_FOY", 27);
        }

        private void btnSecilenleriYazdir_Click(object sender, EventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();
            PrintDocument pDocument = new PrintDocument();
            pDialog.Document = pDocument;

            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                pDocument.PrinterSettings = pDialog.PrinterSettings;
                if (gcSayfalar.DataSource != null)
                {
                    var dokumanListesi = (gcSayfalar.DataSource as List<EditorDokuman>).GroupBy(vi => vi.FoyNo);
                    foreach (var dokuman in dokumanListesi)
                    {
                        foreach (var item in dokuman)
                        {
                            if (item.Secildi)
                            {
                                OpenEditorDokumanCurrentEditor(item);
                                pDialog.PrinterSettings.Copies = (short)item.CiktiSayisi;
                                pDialog.Document = pDocument;
                                pDocument.DocumentName = item.Ad;
                                this.CurrentEditor.textControl1.Print(pDocument);
                            }
                        }
                    }

                    #region <GKN-20090716>

                    //Kayýtlar Arasýnda gezerken kayýt ettiðimizden dolayý gridin üstündeki focuslanmýþ kayýta geri dönüyoruz
                    object secilenRow = gvSayfalar.GetFocusedRow();

                    if (secilenRow != null && secilenRow is EditorDokuman)
                    {
                        this.CurrentEditor.textControl1.Load(((EditorDokuman)secilenRow).Dokuman,
                                                             BinaryStreamType.InternalFormat);
                    }

                    #endregion <GKN-20090716>
                }
            }
        }

        private void frmTebligatKayit_YenileKayit(object sender, AdimAdimDavaKaydi.Forms.LayForm.EvrakKayitEventArgs e)
        {
            if (e.MyEvrak != null && this.Belge != null)
            {
                var obj = DataRepository.NN_BELGE_TEBLIGATProvider.GetByBELGE_ID(this.Belge.ID);
                if (obj.Count <= 0)
                {
                    NN_BELGE_TEBLIGAT teb = new NN_BELGE_TEBLIGAT();
                    teb.BELGE_ID = this.Belge.ID;
                    teb.TEBLIGAT_ID = e.MyEvrak.ID;
                    DataRepository.NN_BELGE_TEBLIGATProvider.Save(teb);
                }
            }
        }

        private void ucBelgeKayitUfak1_Saved(IList Records, IEntity Record)
        {
            this.Belge = (AV001_TDIE_BIL_BELGE)Record;
        }

        private void ucIsKayitUfak1_Saved(IList Records, IEntity Record)
        {
            this.IS = (AV001_TDI_BIL_IS)Records[0];
        }

        #endregion Bar Button Item Click

        #region Events

        public bool TakipEkranidan = true;

        private void c_tcEditors_CloseButtonClick(object sender, EventArgs e)
        {
            if (this.editors.Count == 1)
            {
                return;
            }
            this.c_tcEditors.TabPages.Remove(this.c_tcEditors.SelectedTabPage);
        }

        private void c_tcEditors_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page != null)
            {
                CurrentEditor = (uctxEditor)e.Page.Tag;
            }
        }

        private void Degiskenler_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                downHitInfo = hitInfo;
        }

        private void Degiskenler_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                                                             downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    AV001_TDIE_BIL_SABLON_DEGISKENLER deger = new AV001_TDIE_BIL_SABLON_DEGISKENLER();
                    deger = DataRepository.AV001_TDIE_BIL_SABLON_DEGISKENLERProvider.GetByID(((AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER)((GridView)gridControl1.MainView).GetFocusedRow()).ID);

                    view.GridControl.DoDragDrop(deger, DragDropEffects.All);
                    downHitInfo = null;
                }
            }
        }

        private void DokumanDoldur()
        {
            if (BelgeUtil.Inits._SablonRaporGetir == null)
            {
                if (BelgeUtil.CodeInfo<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>.ListeVarmi(typeof(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)))
                    BelgeUtil.Inits._SablonRaporGetir = BelgeUtil.CodeInfo<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>.ListeGetir(typeof(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)) as List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>;
                else
                {
                    BelgeUtil.Inits._SablonRaporGetir = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.ToList();
                    BelgeUtil.CodeInfo<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>.ListeKaydet(BelgeUtil.Inits._SablonRaporGetir, typeof(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR));
                }
            }
            //grdDokumanBelge.DataSource = BelgeUtil.Inits._SablonRaporGetir;

            grdDokumanBelge.DataSource = SablonDoldur();
        }

        private void Edit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            switch ((int)e.Value)
            {
                case 0:

                    c_tcEditors.HeaderLocation = TabHeaderLocation.Bottom;
                    break;

                case 1:

                    c_tcEditors.HeaderLocation = TabHeaderLocation.Left;
                    break;

                case 2:
                    c_tcEditors.HeaderLocation = TabHeaderLocation.Right;
                    break;

                case 3:
                    c_tcEditors.HeaderLocation = TabHeaderLocation.Top;
                    break;

                default:

                    c_tcEditors.HeaderLocation = TabHeaderLocation.Bottom;
                    break;
            }
        }

        private void Edit_ParseEditValue2(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            switch ((int)e.Value)
            {
                case 0:
                    c_tcEditors.HeaderOrientation = TabOrientation.Horizontal;
                    break;

                case 1:
                    c_tcEditors.HeaderOrientation = TabOrientation.Vertical;
                    break;

                default:
                    c_tcEditors.HeaderOrientation = TabOrientation.Default;
                    break;
            }
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            beklemePaneli.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (beklemePaneli.Width * 2) + (beklemePaneli.Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (beklemePaneli.Height * 2) + (beklemePaneli.Height / 2));
            beklemePaneli.Visible = true;

            AVPLicenceControl.LisansKontrolu(Application.StartupPath);
            if (DesignMode)
            {
                return;
            }
            DokumanDoldur();
            (gridControl1.MainView).MouseDown += Degiskenler_MouseDown;
            (gridControl1.MainView).MouseMove += Degiskenler_MouseMove;

            ((GridView)gridControl1.MainView).OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            if (BelgeUtil.Inits._SablonRaporGetirOtomatik == null)
            {
                if (BelgeUtil.Inits._SablonRaporGetir != null)
                {
                    BelgeUtil.Inits._SablonRaporGetirOtomatik =
                        BelgeUtil.Inits._SablonRaporGetir.FindAll(item => item.DEGISKENI_VARMI == true);
                }
                else
                    BelgeUtil.Inits._SablonRaporGetirOtomatik =
                        BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Where(item => item.DEGISKENI_VARMI == true).ToList();
            }
            raporlar = BelgeUtil.Inits._SablonRaporGetirOtomatik;

            //TODO: [PAKET] Editor menu
            //CS_KOD_FORM_LISTESI csKodFormListesi = AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor", ribbon.Name, 0,"Editor Menu");

            //AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor", dockPanel1.Name, csKodFormListesi.ID, "Otomatik Þablon Degiþkenleri");

            if (AuthHelperBase.PaketKontrol("AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor", dockPanel1.Name) ==
                0)
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            //foreach (RibbonPage ribbonPage in ribbon.Pages)
            //{
            //    //AuthHelper.ApplyAuthorization("AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor", ribbonPage.Name, csKodFormListesi.ID, ribbonPage.Text);
            //}

            #region <MB-20100629>

            //Yazýþma Örnekleri Dock Panelinin,editör ekraný takip ekranlarý dýþýnda açýldýðýnda visible gelmesini saðlamak için eklendi.

            if (!TakipEkranidan)
            {
                dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                dockPanel3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                dockPanel3.Width = 350; //Gridin bari görünmediði için width deðeri büyütüldü.
            }
            else
                dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;

            #endregion <MB-20100629>

            if (BelgeUtil.Inits.PaketAdi == 1)
                ribbonPage10.Visible = false;
            else
                ribbonPage10.Visible = true;
        }

        private void gvSayfalar_FocusedRowChanged(object sender,
                                                  DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            object secilen = gvSayfalar.GetFocusedRow();

            if (secilen != null)
            {
                object eskiSecim = gvSayfalar.GetRow(e.PrevFocusedRowHandle);
                if (eskiSecim != null)
                {
                    var eskiDokuman = eskiSecim as EditorDokuman;
                    byte[] dizi;

                    this.CurrentEditor.textControl1.Save(out dizi, BinaryStreamType.InternalFormat);

                    eskiDokuman.Dokuman = dizi;
                }
                EditorDokuman dokuman = secilen as EditorDokuman;
                OpenEditorDokumanCurrentEditor(dokuman);
            }
        }

        private DataTable SablonDoldur()
        {
            DataTable sonuc = new DataTable();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            sonuc = cn.GetDataTable("select * FROM VDIE_BIL_SABLON_RAPOR(nolock)");

            return sonuc;
        }

        private void textControl1_TextFrameActivated(object sender, TXTextControl.TextFrameEventArgs e)
        {
            TextFrameSelected = true;
        }

        private void textControl1_TextFrameDeactivated(object sender, TXTextControl.TextFrameEventArgs e)
        {
            TextFrameSelected = false;
        }

        private void uctxEditor1_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolum);
            BelgeUtil.Inits.SablonAltKategoriGetir(rLueKategori);
            BelgeUtil.Inits.ModulGetir(repositoryItemLookUpEdit1);
            BelgeUtil.Inits.ModulGetir(rlueModul);
            BelgeUtil.Inits.TakipKonusuGetir(rLueTakipTalepKonu);
            BelgeUtil.Inits.DavaTalepGetir(rLueDavaTalep);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTip);
            BelgeUtil.Inits.DavaNedenGetir(rLueDavaNeden);
            BelgeUtil.Inits.DilKodGetir(rLuedilGetir);
            BelgeUtil.Inits.SektorKodGetir(rLueSektorId);
            BelgeUtil.Inits.FormTipiGetir(rLueFormOrnekNo);

            CurrentEditor = this.uctxEditor1;
            this.uctxEditor1.Parentform = this;
            this.barEditItem1.Edit.ParseEditValue += Edit_ParseEditValue;
            barEditItem2.Edit.ParseEditValue += Edit_ParseEditValue2;
            this.c_tcEditors.SelectedTabPage.Tag = this.uctxEditor1;
            CurrentEditor.textControl1.TextFrameActivated += textControl1_TextFrameActivated;
            CurrentEditor.textControl1.TextFrameDeactivated += textControl1_TextFrameDeactivated;
        }

        #endregion Events

        #region Methots

        public uctxEditor DublicateCurrentEditor()
        {
            uctxEditor edtr = openInaNewTab(this.CurrentEditor.OpenedRapor);
            this.CurrentEditor.RelationalEditors.Add(edtr);
            if (!IsInRelation(this.CurrentEditor))
            {
                this.CurrentEditor.RelationalEditors.Add(this.CurrentEditor);
            }
            for (int i = 0; i < this.CurrentEditor.RelationalEditors.Count; i++)
            {
                if (!IsInRelation(this.CurrentEditor.RelationalEditors[i]))
                {
                    edtr.RelationalEditors.Add(this.CurrentEditor.RelationalEditors[i]);
                }
            }
            return edtr;
        }

        public AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER GetVar(string ad) // Okan
        {
            return Degiskenler.SingleOrDefault(item => item.AD == ad);
        }


        public void OpenFile(string file)
        {
            this.Show();
            this.CurrentEditor.OpenFile(file);
        }

        public bool OpenRecord(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rap, TextControl tcnt)
        {
            AV001_TDIE_BIL_SABLON_RAPOR rapor = DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(rap.ID);
            return OpenRecord(rapor, tcnt);
        }

        public bool OpenRecord(AV001_TDIE_BIL_SABLON_RAPOR rap, TextControl tcnt)
        {
            acilanRapor = rap;
            try
            {
                byte[] datas = acilanRapor.DOSYA;
                string adres = acilanRapor.DOSYA_ADRES;
                if (adres == null)
                {
                    try
                    {
                        tcnt.Load(datas, BinaryStreamType.InternalFormat);
                        acilanTipi = BinaryStreamType.InternalFormat;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            tcnt.Load(datas, BinaryStreamType.MSWord);
                            acilanTipi = BinaryStreamType.MSWord;
                        }
                        catch (Exception)
                        {
                            try
                            {
                                tcnt.Load(datas, BinaryStreamType.WordprocessingML);
                                acilanTipi = BinaryStreamType.WordprocessingML;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Bu Dosyayý Açamýyoruz!... Dosya Bozulmuþ olabilir...");
                            }
                        }
                    }
                }
                else
                {
                    tcnt.Load(datas, GetByfilename(adres));
                    acilanTipi = GetByfilename(adres);
                }

                return true;
            }
            catch
            {
            }
            return false;
        }

        private BinaryStreamType GetByfilename(string filename)
        {
            string ext = "";
            if (string.IsNullOrEmpty(filename))
            {
                ext = "doc";
            }
            else
            {
                string[] strl = filename.Split('.');
                ext = strl[strl.Length - 1];
            }
            switch (ext)
            {
                case "doc":
                    return BinaryStreamType.MSWord;

                case "tx":
                    return BinaryStreamType.InternalFormat;

                case "docx":
                    return BinaryStreamType.MSWord;

                case "pdf":
                    return BinaryStreamType.AdobePDF;

                default:
                    break;
            }
            return BinaryStreamType.InternalFormat;
        }

        private bool IsInRelation(uctxEditor edtr)
        {
            for (int i = 0; i < this.CurrentEditor.RelationalEditors.Count; i++)
            {
                if (this.CurrentEditor.RelationalEditors[i] == edtr)
                {
                    return true;
                }
            }
            return false;
        }

        private void OpenEditorDokumanCurrentEditor(EditorDokuman dokuman)
        {
            CompInfo smtpInfo = CompInfo.CmpNfoList[0];
            EditorDokuman.EditorDokumanTebligatBarkodCollection barCodeCollection = new EditorDokuman.EditorDokumanTebligatBarkodCollection();

            if (System.IO.File.Exists("C:\\AvukatProBarkodImage") == false)
            {
                // Directory.Delete("C:\\AvukatProBarkodImage");
                Directory.CreateDirectory("C:\\AvukatProBarkodImage");
            }

            foreach (var item in dokuman.Taraflar.ToList())
            {
                TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> myAV001_TDI_BIL_TEBLIGAT_MUHATAPs = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
                myAV001_TDI_BIL_TEBLIGAT_MUHATAPs = DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetByICRA_FOY_ID(((AV001_TI_BIL_FOY)dokuman.GecerliFoy).ID);
                foreach (AV001_TDI_BIL_TEBLIGAT_MUHATAP item2 in myAV001_TDI_BIL_TEBLIGAT_MUHATAPs.Where(q => q.MUHATAP_CARI_ID == item.CariId))
                {
                    if (string.IsNullOrEmpty(item2.PTT_BARKOD_NO))
                    {
                    }
                    else
                    {
                        if (item2.POSTALANDI_MI == false)
                        {
                            SqlConnection con2 = new SqlConnection(smtpInfo.ConStr);
                            con2.Open();
                            SqlCommand cmd1 = new SqlCommand("UPDATE [dbo].[AV001_TDI_BIL_TEBLIGAT_MUHATAP] SET [POSTALANDI_MI] =1  WHERE ID=" + item2.ID + " ", con2);//++
                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();
                            con2.Close();
                            con2.Dispose();
                            barCodeCollection.Add(item2.PTT_BARKOD_NO);
                        }
                    }
                }
            }
            dokuman.Barkodlar = barCodeCollection;
            byte[] dBytes = dokuman.Dokuman;

            string str2 = Encoding.GetEncoding("windows-1254").GetString(dBytes);

            this.CurrentEditor.textControl1.Load(dokuman.Dokuman, BinaryStreamType.InternalFormat);

            BarCodeCODE39Generator b = new BarCodeCODE39Generator();
            //   BarCodeEAN13Generator c = new BarCodeEAN13Generator();

            foreach (var item in dokuman.Barkodlar)
            {
                b.BarCode = item.TebligatBarkod;
                b.SaveImage("C:\\AvukatProBarkodImage\\" + item.TebligatBarkod.ToString() + ".jpg", dokuman.barkodTurID);
                //System.Drawing.Image myImage = c.Generate(item.TebligatBarkod,dokuman.barkodTurID);
                //myImage.Save("C:\\AvukatProBarkodImage\\" + item.TebligatBarkod.ToString() + ".jpg");
            }
            string[] dizindekiDosyalar = Directory.GetFiles("C:\\AvukatProBarkodImage");
            foreach (string dosya in dizindekiDosyalar)
            {
                FileInfo fileInfo = new FileInfo(dosya);
                if (fileInfo.Extension == ".jpg")
                {
                    if (str2.Contains(fileInfo.Name.ToString().Replace(".jpg", "")))
                    {
                        if (this.CurrentEditor.textControl1.Images.Count > 2)
                        {
                        }
                        else
                        {
                            TXTextControl.Image image1 = new TXTextControl.Image();
                            System.Drawing.Point location;
                            location = this.CurrentEditor.textControl1.InputPosition.Location;
                            image1.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();

                            //image.FileName = "C:\\kenan6.bmp";
                            image1.Sizeable = true;
                            image1.Moveable = true;
                            image1.HorizontalScaling = 100;
                            image1.VerticalScaling = 100;
                            image1.SaveMode = TXTextControl.ImageSaveMode.SaveAsData;
                            TXTextControl.Image image2 = new TXTextControl.Image();
                            System.Drawing.Point location1 = new Point();
                            System.Drawing.Point location2 = new Point();
                            switch (dokuman.TurID)
                            {
                                case 333:
                                    location1.X = location.X + 6700;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 6700;
                                    location2.Y = location.Y + 7500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    if (dokuman.barkodTurID == 1)
                                    {
                                    }
                                    else if (dokuman.barkodTurID == 4)
                                    {
                                    }
                                    else if (dokuman.barkodTurID == 0)
                                    {
                                    }
                                    break;
                                //case 343:

                                //    break;
                                case 439:

                                    break;
                                //case 334:

                                //    break;
                                case 504:
                                case 3213:
                                case 3214:
                                    location1.X = location.X + 6500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 6500;
                                    location2.Y = location.Y + 9500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();

                                    break;

                                case 505:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;

                                case 507:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;

                                case 509:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;

                                case 510:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;

                                case 520:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;
                                //case 1204:
                                //    break;
                                case 1219:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;
                                //case 1256:
                                //case 1257:
                                //    break;
                                case 3211:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8000;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;

                                case 3212:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;

                                case 3215:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;

                                case 3216:
                                    location1.X = location.X + 7500;
                                    location1.Y = location.Y + 3500;
                                    location2.X = location.X + 7500;
                                    location2.Y = location.Y + 8500;
                                    image2.FileName = "C:\\AvukatProBarkodImage\\" + fileInfo.Name.ToString();
                                    break;

                                default:

                                    location1.X = 0;
                                    location1.Y = 0;
                                    location2.X = 0;
                                    location2.Y = 0;
                                    break;
                            }
                            image2.Sizeable = true;
                            image2.Moveable = true;
                            image2.HorizontalScaling = 100;
                            image2.VerticalScaling = 100;
                            image2.SaveMode = TXTextControl.ImageSaveMode.SaveAsData;

                            this.CurrentEditor.textControl1.Images.Add(image1, location1, TXTextControl.ImageInsertionMode.DisplaceText);
                            this.CurrentEditor.textControl1.Images.Add(image2, location2, TXTextControl.ImageInsertionMode.DisplaceText);
                        }
                    }
                }
            }
        }

        #endregion Methots

        #region OpenAllSablon

        private string BarkodTip2;
        private object foys2;
        private List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar2 = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
        private List<object> SelectedList = new List<object>();
        private bool TakipSetiYazdirilsinMi = false;
        private Dictionary<EditorDokuman, List<string>> MailListesi;
        public void OpenAllSablon(List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar, object foys, string BarkodTip, int tip = 0)
        {
            if (MailListesi == null)
                MailListesi = new Dictionary<EditorDokuman, List<string>>();
            _BarkodTip = BarkodTip;
            if (this.CurrentEditor == null)
                this.CurrentEditor = new uctxEditor();

            if (foys is AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama)
            {
                //TList<AV001_TI_BIL_FOY> foyler = AvukatProLib.Arama.ViewTableConverter.per_AV001_TI_BIL_ICRA_Arama_TO_AV001_TI_BIL_FOY_List(((List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>)foys);

                TList<AV001_TI_BIL_FOY> foyler = new TList<AV001_TI_BIL_FOY>();
                for (int i = 0; i < (foys as List<DataRow>).Count; i++)
                {
                    foyler.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)(foys as List<DataRow>)[i]["ID"]));
                }

                OpenAllSablon(raporlar, foyler, BarkodTip);
            }
            else if (foys is DataRow && tip == 0)
            {
                //AV001_TI_BIL_FOY foy = AvukatProLib.Arama.ViewTableConverter.per_AV001_TI_BIL_ICRA_Arama_TO_AV001_TI_BIL_FOY((AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama)foys);
                AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)(foys as DataRow)["ID"]);
                OpenAllSablon(raporlar, foy, BarkodTip);
            }
            else if (foys is DataRow && tip == 1)
            {
                //AV001_TI_BIL_FOY foy = AvukatProLib.Arama.ViewTableConverter.per_AV001_TI_BIL_ICRA_Arama_TO_AV001_TI_BIL_FOY((AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama)foys);
                AV001_TD_BIL_FOY foy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)(foys as DataRow)["ID"]);
                OpenAllSablon(raporlar, foy, BarkodTip);
            }
            else
            {
                List<EditorDokuman> dokumanListesi = new List<EditorDokuman>();
                //this.Show();
                EditorAraclari arac = new EditorAraclari();

                foreach (var rapor in raporlar)
                {
                    if (foys is TList<AV001_TI_BIL_FOY>)
                    {
                        var foyListesi = foys as TList<AV001_TI_BIL_FOY>;
                        foreach (var tekFoy in foyListesi)
                        {
                            //Takip setinde doðru masraf makbuzunun gelmesini saðlamak için yapýldý. Masraf makbuzu ayrý bir cs içerisinde hazýrlandýðýndan bu þekilde yapýlabildi. MB
                            if (rapor.ID == 1232)
                            {
                                var list = Editor.Degiskenler.Util.MasrafMakbuzu.MasrafMakbuzuGetirForTakitSeti(tekFoy, this.CurrentEditor.textControl1);
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(tekFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                                DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(tekFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                                foreach (var item in list)
                                {
                                    var mails = tekFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection
                                        .Where(q => q.SORUMLU_AVUKAT_CARI_IDSource != null && !string.IsNullOrEmpty(q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1))
                                        .Select(q => q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1).ToList();
                                    MailListesi.Add(item, mails);
                                }
                                dokumanListesi.AddRange(list);
                            }
                            else
                            {
                                var list = arac.GetEditorDokumansBySablonAndIcraFoy(rapor, tekFoy, this.CurrentEditor.textControl1, BarkodTip);
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(tekFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                                DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(tekFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                                foreach (var item in list)
                                {
                                    var mails = tekFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection
                                        .Where(q => q.SORUMLU_AVUKAT_CARI_IDSource != null && !string.IsNullOrEmpty(q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1))
                                        .Select(q => q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1).ToList();
                                    MailListesi.Add(item, mails);
                                }
                                dokumanListesi.AddRange(list);
                            }
                        }
                    }
                    else if (foys is AV001_TI_BIL_FOY)
                    {
                        //Takip setinde doðru amsraf makbuzunun gelmesini saðlamak için yapýldý. Masraf makbuzu ayrý bir cs içerisinde hazýrlandýðýndan bu þekilde yapýlabildi. MB
                        if (rapor.ID == 1232)
                        {
                            var list = Editor.Degiskenler.Util.MasrafMakbuzu.MasrafMakbuzuGetirForTakitSeti(foys as AV001_TI_BIL_FOY, this.CurrentEditor.textControl1);
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad((AV001_TI_BIL_FOY)foys, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                            DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(((AV001_TI_BIL_FOY)foys).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                            foreach (var item in list)
                            {
                                var mails = ((AV001_TI_BIL_FOY)foys).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection
                                    .Where(q => q.SORUMLU_AVUKAT_CARI_IDSource != null && !string.IsNullOrEmpty(q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1))
                                    .Select(q => q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1).ToList();
                                MailListesi.Add(item, mails);
                            }
                            dokumanListesi.AddRange(list);
                        }
                        else
                        {
                            var list = arac.GetEditorDokumansBySablonAndIcraFoy(rapor, foys as AV001_TI_BIL_FOY, this.CurrentEditor.textControl1, BarkodTip);
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad((AV001_TI_BIL_FOY)foys, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                            DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(((AV001_TI_BIL_FOY)foys).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                            foreach (var item in list)
                            {
                                var mails = ((AV001_TI_BIL_FOY)foys).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection
                                    .Where(q => q.SORUMLU_AVUKAT_CARI_IDSource != null && !string.IsNullOrEmpty(q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1))
                                    .Select(q => q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1).ToList();
                                MailListesi.Add(item, mails);
                            }
                            dokumanListesi.AddRange(list);
                        }
                    }
                    else if (foys is TList<AV001_TD_BIL_FOY>)
                    {
                        var foyListesi = foys as TList<AV001_TD_BIL_FOY>;
                        foreach (var tekFoy in foyListesi)
                        {
                            var list = arac.GetEditorDokumansBySablonAndDavaFoy(rapor, tekFoy, this.CurrentEditor.textControl1);
                            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(tekFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                            DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(tekFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                            foreach (var item in list)
                            {
                                var mails = tekFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection
                                    .Where(q => q.SORUMLU_AVUKAT_CARI_IDSource != null && !string.IsNullOrEmpty(q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1))
                                    .Select(q => q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1).ToList();
                                MailListesi.Add(item, mails);
                            }
                            dokumanListesi.AddRange(list);
                        }
                    }
                    else if (foys is AV001_TD_BIL_FOY)
                    {
                        var list = arac.GetEditorDokumansBySablonAndDavaFoy(rapor, foys as AV001_TD_BIL_FOY, this.CurrentEditor.textControl1);
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad((AV001_TD_BIL_FOY)foys, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                        DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(((AV001_TD_BIL_FOY)foys).AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                        foreach (var item in list)
                        {
                            var mails = ((AV001_TD_BIL_FOY)foys).AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection
                                .Where(q => q.SORUMLU_AVUKAT_CARI_IDSource != null && !string.IsNullOrEmpty(q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1))
                                .Select(q => q.SORUMLU_AVUKAT_CARI_IDSource.EMAIL_1).ToList();
                            MailListesi.Add(item, mails);
                        }
                        dokumanListesi.AddRange(list);
                    }
                }

                if (gcSayfalar.DataSource == null)
                    gcSayfalar.DataSource = new List<EditorDokuman>();
                if (gcSayfalar.DataSource is List<EditorDokuman>)
                {
                    (gcSayfalar.DataSource as List<EditorDokuman>).AddRange(dokumanListesi);
                    gcSayfalar.Refresh();
                    gcSayfalar.RefreshDataSource();
                }
                else
                {
                    gcSayfalar.DataSource = dokumanListesi;
                }

                if (gcSayfalar.DataSource != null)
                {
                    var data = (gcSayfalar.DataSource as List<EditorDokuman>);
                    if (data.Count > 0)
                    {
                        var dok = gvSayfalar.GetRow(0) as EditorDokuman;
                        OpenEditorDokumanCurrentEditor(dok);
                    }
                }
            }

            if (BelgeUtil.Inits.PaketAdi != 1)
                return;

            if (gcSayfalar.DataSource != null)
            {
                var dokumanListesi = gcSayfalar.DataSource as List<EditorDokuman>;
                List<string> FilePaths = new List<string>();
                int i = 1;
                SaveSettings settings = new SaveSettings();
                settings.CssSaveMode = CssSaveMode.OverwriteFile;
                settings.DocumentAccessPermissions = DocumentAccessPermissions.AllowAll;

                ////Belge Oluþturma
                //TList<AV001_TDIE_BIL_BELGE> belgeList = new TList<AV001_TDIE_BIL_BELGE>();

                foreach (EditorDokuman item in dokumanListesi)
                {
                    this.CurrentEditor.textControl1.Load(item.Dokuman, BinaryStreamType.InternalFormat);
                    string fileName = i.ToString() + " " + item.FoyNo + " " + item.Ad;
                    if (fileName.Length > 150)
                        fileName = fileName.Substring(0, 150);

                    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fileName + ".doc";
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                    try
                    {
                        this.CurrentEditor.textControl1.Save(filePath, StreamType.MSWord, settings);
                    }
                    catch
                    {
                        MessageBox.Show("Dosyalar kaydedilirken hata oluþtu", "Dosya kayýt hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    FilePaths.Add(filePath);
                    i++;

                    //AV001_TDIE_BIL_BELGE belge = item.GetBelge(this.CurrentEditor.textControl1);
                    //BelgeList.Add(belge);
                }

                //DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepSave(BelgeList, DeepSaveType.IncludeChildren, typeof(TList<NN_BELGE_ICRA>));

                AV001_TDI_BIL_CARI cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Kimlikci.Kimlik.Cari_ID);

                AvukatProLib.Mail.frmMailSender mailSender;
                if (cari != null)
                {
                    if (!String.IsNullOrEmpty(cari.EMAIL_1))
                    {
                        mailSender = new AvukatProLib.Mail.frmMailSender(cari.EMAIL_1, FilePaths);
                        mailSender.ShowDialog();
                    }
                    else
                    {
                        mailSender = new AvukatProLib.Mail.frmMailSender(FilePaths);
                        mailSender.ShowDialog();
                    }
                }
                else
                {
                    mailSender = new AvukatProLib.Mail.frmMailSender(FilePaths);
                    mailSender.ShowDialog();
                }
                var data = (gcSayfalar.DataSource as List<EditorDokuman>);
                if (data.Count > 0)
                {
                    var dok = gvSayfalar.GetRow(0) as EditorDokuman;
                    OpenEditorDokumanCurrentEditor(dok);
                }
            }
        }

        public void OpenAllSablon(List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar, object foys, bool fillValues, bool print)
        {
            if (foys is IList)
            {
                IList liste = ((IList)foys);
                for (int i = 0; i < liste.Count; i++)
                {
                    if (liste[i] is IEntity)
                    {
                        DegiskenHelper.AddToSeciliKayitlar((IEntity)liste[i]);
                    }
                }
            }

            if (foys is IEntity)
            {
                DegiskenHelper.AddToSeciliKayitlar((IEntity)foys);
            }

            for (int i = 0; i < raporlar.Count; i++)
            {
                AV001_TDIE_BIL_SABLON_RAPOR rapor =
                    DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(raporlar[i].ID);
                uctxEditor edt = openInaNewTab(rapor, fillValues);
                this.CurrentEditor = edt;
                if (print)
                {
                    edt.Preview();
                }
            }
        }

        public void OpenAllSablonForThread(List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar, object foys, string BarkodTip)
        {
            this.Show();
            raporlar2 = raporlar;
            foys2 = foys;
            BarkodTip2 = BarkodTip;
            backgroundWorker1.RunWorkerAsync();
        }

        public void OpenAllSablonForThreadMulti(List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar, object foys, string BarkodTip, List<object> _SelectedList, bool TakipSetiYazdirilsinMi)
        {
            this.Show();
            this.TakipSetiYazdirilsinMi = TakipSetiYazdirilsinMi;
            raporlar2 = raporlar;
            foys2 = foys;
            BarkodTip2 = BarkodTip;
            SelectedList = _SelectedList;
            backgroundWorker2.RunWorkerAsync();

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            OpenAllSablon(raporlar2, foys2, BarkodTip2);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            beklemePaneli.Visible = false;
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < SelectedList.Count; i++)
            {
                List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> rap = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                DataTable dt = null;
                int tip = 0;
                try
                {
                    cn.AddParams("@FORM_ID", ((System.Data.DataRow)(SelectedList[i]))["FORM_TIP_ID"]);
                    dt = cn.GetDataTable("SELECT SABLON_ID FROM dbo.AV001_TI_BIL_YAZDIRMA_AYARLARI_DETAY(nolock) WHERE YAZDIRMA_AYAR_ID in (SELECT ID FROM dbo.AV001_TI_BIL_YAZDIRMA_AYARLARI(nolock) WHERE FORM_ID=@FORM_ID)");
                }
                catch
                {
                    tip = 1;
                }
                if (dt != null && !TakipSetiYazdirilsinMi)
                    OpenAllSablon(raporlar2, SelectedList[i], "", tip);
                else if (dt == null || dt.Rows.Count == 0)
                    OpenAllSablon(raporlar2, SelectedList[i], "", tip);
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        AvukatProLib.Arama.AvpDataContext xx = new AvukatProLib.Arama.AvpDataContext(Kimlikci.Kimlik.SirketBilgisi.ConStr);
                        AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR aa = xx.VDIE_BIL_SABLON_RAPORs.Where(vi => vi.ID == (int)row["SABLON_ID"]).ToList()[0];
                        rap.Add(aa);
                    }

                    OpenAllSablon(rap, SelectedList[i], "", tip);
                }
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            backgroundWorker2.CancelAsync();
            beklemePaneli.Visible = false;
        }

        #endregion OpenAllSablon

        #region OpenSablon

        public uctxEditor OpenSablonInNewTab(AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR rapor)
        {
            this.Show();
            return openInaNewTab(rapor, false);
        }

        #endregion OpenSablon

        #region openInaNewTab

        private uctxEditor NewTab()
        {
            uctxEditor editor = new uctxEditor();
            editor.Dock = DockStyle.Fill;
            XtraTabPage tp = new XtraTabPage();
            tp.Tag = editor;
            tp.Text = "New Tab";
            tp.Text = "New Tab";
            tp.Controls.Add(editor);
            this.c_tcEditors.TabPages.Add(tp);
            editor.Page = tp;
            editor.SelectedStreamType = TXTextControl.StreamType.InternalFormat;

            editor.Parentform = this;
            editors.Add(editor);
            XtraTabPage tpex = this.c_tcEditors.SelectedTabPage;
            uctxEditor exedt = this.CurrentEditor;
            this.c_tcEditors.SelectedTabPage = editor.Page;
            this.Show();

            //this.CurrentEditor = exedt;
            return editor;
        }

        private uctxEditor openInaNewTab(AV001_TDIE_BIL_SABLON_RAPOR rapor, bool fillValues)
        {

            RecordInfos ri = new RecordInfos();
            ri.Data = rapor;
            ri.SelectedFrom = LoadFromType.FromTable;
            uctxEditor editor = new uctxEditor();
            editor.Dock = DockStyle.Fill;
            XtraTabPage tp = new XtraTabPage();
            tp.Tag = editor;

            if (rapor.AD.Length > 22)
            {
                tp.Text = rapor.AD.Substring(0, 22) + "...";
            }
            else
            {
                tp.Text = rapor.AD;
            }

            tp.Controls.Add(editor);
            this.c_tcEditors.TabPages.Add(tp);
            editor.Page = tp;
            editor.SelectedStreamType = TXTextControl.StreamType.InternalFormat;
            editor.Record = ri;
            if (rapor.AD.Length > 22)
            {
                ri.Name = rapor.AD.Substring(0, 22) + "...";
            }
            else
            {
                ri.Name = rapor.AD;
            }

            editor.Parentform = this;
            editors.Add(editor);
            XtraTabPage tpex = this.c_tcEditors.SelectedTabPage;
            uctxEditor exedt = this.CurrentEditor;
            this.c_tcEditors.SelectedTabPage = editor.Page;
            this.Show();
            bool opened = editor.OpenRecord(editor.Record);
            if (!opened)
            {
                MessageBox.Show("Baþarýsýz iþlem Dosya Düzgün olarak Açýlamadý ... ");
            }
            if (fillValues)
            {
                for (int i = 0; i < editors.Count; i++)
                {
                    if (!editors[i].AlanlarDolduruldumu)
                    {
                        editors[i].SetFieldsValues(false);
                    }
                }
            }

            //this.CurrentEditor = exedt;
            return editor;
        }

        private uctxEditor openInaNewTab(AV001_TDIE_BIL_SABLON_RAPOR rapor)
        {
            if (rapor == null)
            {
                rapor = new AV001_TDIE_BIL_SABLON_RAPOR();
                rapor.AD = "deneme";
                String file = Tools.TempFilesPath + DateTime.Now.Ticks + ".TX";
                rapor.DOSYA_ADRES = file;
                this.CurrentEditor.SaveToPath(file);
                rapor.DOSYA = Tools.GetBytesFromFile(file);
            }
            return openInaNewTab(rapor, false);
        }

        #endregion openInaNewTab

        #region Gruplama Çalýþmalarý

        public List<EditorDokuman> DokumanListesi
        {
            get { return gcSayfalar.DataSource as List<EditorDokuman>; }
            set { gcSayfalar.DataSource = value; }
        }

        #endregion Gruplama Çalýþmalarý

        #region Fields

        public frmEditor()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private AV001_TDIE_BIL_SABLON_RAPOR acilanRapor = new AV001_TDIE_BIL_SABLON_RAPOR();
        private BinaryStreamType acilanTipi = BinaryStreamType.InternalFormat;
        private byte[] anahtar = new byte[0];
        private int cnt = 1;

        private List<AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER> Degiskenler =
            new List<AvukatProLib.Arama.VDIE_BIL_SABLON_DEGISKENLER>();

        private GridHitInfo downHitInfo;
        private List<uctxEditor> editors = new List<uctxEditor>();
        private Form frm = new Form();
        private List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
        private TextBox t = new TextBox();
        private bool TextFrameSelected;

        private byte[] vektor = new byte[0];

        #endregion Fields

        #region Properties

        /// <summary>
        /// Seçili  Foy kaydý
        /// </summary>
        private IList selectedFoy;

        public AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE Belge { get; set; }

        public uctxEditor CurrentEditor { get; set; }

        public AvukatProLib2.Entities.AV001_TDI_BIL_IS IS { get; set; }

        public AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR Rapor { get; set; }

        public IList SelectedFoys
        {
            get { return selectedFoy; }
            set
            {
                selectedFoy = value;
                if (value != null)
                {
                    if (this.CurrentEditor == null)
                    {
                        this.CurrentEditor = this.uctxEditor1;
                    }
                    CurrentEditor.SelectedFoys = value;
                }
            }
        }

        public List<AvukatProDegiskenler.Icra.CariGrup> TebligatIcinUcuncuSahisBilgileri { get; set; }

        #endregion Properties

        #region Belge Kayýt, Popup

        private void btnPopupBelgeleriKaydet_Click(object sender, EventArgs e)
        {
            popupControlContainer1.Enabled = false;

            var belgeler = ucKaydedilecekBelgeler1.MyDataSource;

            TransactionManager tm = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tm.BeginTransaction();
                foreach (var belge in belgeler)
                {
                    if (belge.IsSelected)
                    {
                        var kalkacakSorumlular = new TList<AV001_TDIE_BIL_BELGE_SORUMLU>();
                        foreach (var sorumlu in belge.AV001_TDIE_BIL_BELGE_SORUMLUCollection)
                        {
                            if (!sorumlu.IsSelected)
                                kalkacakSorumlular.Add(sorumlu);
                        }

                        foreach (var item in kalkacakSorumlular)
                        {
                            belge.AV001_TDIE_BIL_BELGE_SORUMLUCollection.Remove(item);
                        }

                        var kalkacakTaraflar = new TList<AV001_TDIE_BIL_BELGE_TARAF>();
                        foreach (var taraf in belge.AV001_TDIE_BIL_BELGE_TARAFCollection)
                        {
                            if (!taraf.IsSelected)
                                kalkacakTaraflar.Add(taraf);
                        }
                        foreach (var item in kalkacakTaraflar)
                        {
                            belge.AV001_TDIE_BIL_BELGE_TARAFCollection.Remove(item);
                        }

                        DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepSave(tm, belge, DeepSaveType.IncludeChildren
                                                                             , typeof(TList<NN_BELGE_ICRA>)
                                                                             ,
                                                                             typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>)
                                                                             ,
                                                                             typeof(TList<AV001_TDIE_BIL_BELGE_SORUMLU>
                                                                                 ));
                    }
                }

                tm.Commit();

                MessageBox.Show("Kayýt Tamamlandý", "Ýþlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                popupControlContainer1.Hide();
            }
            catch (Exception ex)
            {
                if (tm.IsOpen)
                    tm.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                popupControlContainer1.Enabled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TList<AV001_TDIE_BIL_BELGE> belgeListesi = new TList<AV001_TDIE_BIL_BELGE>();
            if (gvSayfalar.DataSource != null)
            {
                object secilen = gvSayfalar.GetFocusedRow();

                if (secilen != null)
                {
                    var eskiDokuman = secilen as EditorDokuman;

                    byte[] dizi;

                    this.CurrentEditor.textControl1.Save(out dizi, BinaryStreamType.InternalFormat);

                    eskiDokuman.Dokuman = dizi;
                }

                var dokumanListesi = gcSayfalar.DataSource as List<EditorDokuman>;

                foreach (var item in dokumanListesi)
                {
                    belgeListesi.Add(item.GetBelge(this.CurrentEditor.textControl1));
                }

                ucKaydedilecekBelgeler1.MyDataSource = belgeListesi;

                popupControlContainer1.Show();
                if (!popupControlContainer1.Enabled) popupControlContainer1.Enabled = true;
            }
            else
            {
                EditorDokuman dok = new EditorDokuman(null);
                dok.Ad = sablonadi;

                //        dok.Sablon = gridView2.GetFocusedRow() as AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR;
                byte[] dizi;
                this.CurrentEditor.textControl1.Save(out dizi, BinaryStreamType.InternalFormat);
                dok.Dokuman = dizi;
                frmDosyaModulSec dms = new frmDosyaModulSec();
                dms.Show();
                dms.FormClosed += delegate
                                      {
                                          dok.GecerliFoy = dms.Record;
                                          AV001_TDIE_BIL_BELGE belgem = dok.GetBelge(this.CurrentEditor.textControl1);
                                          belgem.ICERIK = dizi;
                                          if (belgem != null)
                                              belgeListesi.Add(belgem);

                                          frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                          belgeKayit.ucBelgeKayitUfak1.OpenedRecord = dms.Record;
                                          belgeKayit.MyDataSource = belgeListesi;
                                          belgeKayit.ucBelgeKayitUfak1.Duzenle = true;
                                          belgeKayit.ucBelgeKayitUfak1.Record = belgem;
                                          belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                          belgeKayit.Show();
                                          belgeKayit.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                                      };
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            popupControlContainer1.Hide();
        }

        #endregion Belge Kayýt, Popup

        #region Klasör Raporu Ýçin çalýþmalar

        public void Show(AV001_TDIE_BIL_SABLON_RAPOR rapor, AV001_TDIE_BIL_PROJE proje)
        {
            if (rapor == null)
            {
                MessageBox.Show("Ýstenilen rapora ait þablon bulunamadý.");
                return;
            }
            this.Show();

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.KlasorRapor(rapor, proje, CurrentEditor.textControl1);
            beklemePaneli.Visible = false;
        }

        public void Show(AV001_TDIE_BIL_SABLON_RAPOR rapor, AV001_TDIE_BIL_PROJE proje,
                         AV001_TI_BIL_IHTIYATI_HACIZ iHaciz)
        {
            if (rapor == null)
            {
                MessageBox.Show("Ýstenilen rapora ait þablon bulunamadý.");
                return;
            }
            if (proje == null || iHaciz == null || rapor == null) return;
            this.Show();

            AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Tool.IhtiyatiHacizDilekcesi(iHaciz, rapor, proje,
                                                                                    CurrentEditor.textControl1);
            beklemePaneli.Visible = false;
        }

        #endregion Klasör Raporu Ýçin çalýþmalar

        private TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> lstRapors =
            new TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>();

        private string sablonadi;

        private void barButtonItem152_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CurrentEditor.OpenBelge();
        }

        private void bbtnPdfBelgesiOlarakKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "pdf";
            sfd.Title = "PDF Olarak Kaydet";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                this.CurrentEditor.textControl1.Save(sfd.FileName, StreamType.AdobePDF);
            }
            catch
            {
                MesajCi.Goster("Dosya kaydetme Hatasi", "Dosya kaydedilirken bir hata ile karþýldý",
                               string.Format("Dosya kaydedilmeye çalýþýrken {0} hatasý oluþtu", sfd.FileName),
                               MessageBoxButtons.OK, "www.avukatpro.com", MessageBoxIcon.Error);
                return;
            }
            try
            {
                MesajCi.Goster("Ýþlem Baþarýlý", "Dosya baþarýlý bir þekilde kaydedildi",
               string.Format(
                   string.Format("Dosya {0} adresine baþarýlý bir sekilde kaydedildi", sfd.FileName),
                   sfd.FileName), MessageBoxButtons.OK, "www.avukatpro.com", MessageBoxIcon.Information);
            }
            catch (Exception)
            {
            }
        }

        private void bbtnRtfBelgesiOlarakKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "rtf";
            sfd.Title = "RTF Olarak Kaydet";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                this.CurrentEditor.textControl1.Save(sfd.FileName, StreamType.RichTextFormat);
            }
            catch
            {
                MesajCi.Goster("Dosya kaydetme Hatasi", "Dosya kaydedilirken bir hata ile karþýldý",
                               string.Format("Dosya kaydedilmeye çalýþýrken {0} hatasý oluþtu", sfd.FileName),
                               MessageBoxButtons.OK, "www.avukatpro.com", MessageBoxIcon.Error);
                return;
            }
            MesajCi.Goster("Ýþlem Baþarýlý", "Dosya baþarýlý bir þekilde kaydedildi",
                           string.Format(
                               string.Format("Dosya {0} adresine baþarýlý bir sekilde kaydedildi", sfd.FileName),
                               sfd.FileName), MessageBoxButtons.OK, "www.avukatpro.com", MessageBoxIcon.Information);
        }

        private void grdDokumanBelge_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "mEkle")
            {
                uctxEditor1.OpenedRapor = null;
                this.CurrentEditor.Save();
                if (this.CurrentEditor.kaydet != null)
                    this.CurrentEditor.kaydet.FormClosed += kaydet_FormClosed;
            }
            else if (e.Button.Tag.ToString() == "mDuzenle")
            {
                if (gridView2.GetFocusedRow() == null || gridView2.GetFocusedRow() as AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR == null)
                    return;

                AV001_TDIE_BIL_SABLON_RAPOR rapor =
                    DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(
                        (gridView2.GetFocusedRow() as AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR).ID);
                uctxEditor1.OpenedRapor = rapor;
                this.CurrentEditor.Save();
                if (this.CurrentEditor.kaydet != null)
                    this.CurrentEditor.kaydet.FormClosed += kaydet_FormClosed;
            }

            #region <MB-20100701>

            //Seçili dilekçenin silinebilmesi için eklendi.

            else if (e.Button.Tag.ToString() == "Sil")
            {
                if (gridView2.GetFocusedRow() == null || gridView2.GetFocusedRow() as AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR == null)
                    return;

                AV001_TDIE_BIL_SABLON_RAPOR rapor =
                    DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(
                        (gridView2.GetFocusedRow() as AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR).ID);
                frmKayitSil sil = new frmKayitSil("AV001_TDIE_BIL_SABLON_RAPOR", String.Format("ID = {0}", rapor.ID));
                sil.Show();
                sil.FormClosed += kaydet_FormClosed;
            }

            #endregion <MB-20100701>

            //#region <MB-20100701>
            ////Grid üzerinden düzenleme yapýlabilmesi için eklendi.

            //else if (e.Button.Tag.ToString() == "Kaydet")
            //{
            //    TList<AV001_TDIE_BIL_SABLON_RAPOR> raporlarList = new TList<AV001_TDIE_BIL_SABLON_RAPOR>();
            //    List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> raporlar = grdDokumanBelge.DataSource as List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>;

            //    if (raporlar == null) return;
            //    raporlar.ForEach(item =>
            //        {
            //            AV001_TDIE_BIL_SABLON_RAPOR rapor = DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(item.ID);

            //            if (rapor != null)
            //            {
            //                rapor.ADLI_BIRIM_BOLUM_ID = item.ADLI_BIRIM_BOLUM_ID;
            //                rapor.KATEGORI_ID = item.KATEGORI_ID;
            //                rapor.ADLI_BIRIM_GOREV_ID = item.ADLI_BIRIM_GOREV_ID;
            //                rapor.SEKTOR_ID = item.SEKTOR_ID;
            //                rapor.DAVA_TALEP_ID = item.DAVA_TALEP_ID;
            //                raporlarList.Add(rapor);
            //            }
            //        });

            //    TransactionManager tran = new TransactionManager(Kimlik.SirketBilgisi.ConStr);

            //    try
            //    {
            //        tran.BeginTransaction();
            //        DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.Save(tran, raporlarList);
            //        tran.Commit();
            //        XtraMessageBox.Show("Kayýt iþlemi baþarý ile gerçekleþtirildi.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        if (tran.IsOpen)
            //            tran.Rollback();
            //        ErrorHandler.Catch(this, ex);
            //    }
            //}

            //#endregion
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            object value = gridView2.GetRow(gridView2.FocusedRowHandle);

            AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR tmpRapor =
                DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID((int)gridView2.GetFocusedRowCellValue("ID"));

            //if (value is AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR)
            //{
            if (tmpRapor != null)

                //    lstRapors.Add(tmpRapor);
                ////}
                //if (lstRapors.Count > 0)
                OpenSablonInNewTab(tmpRapor);

            //       OpenRecord(tmpRapor, uctxEditor1.textControl1);
        }

        private void hideContainerLeft_MouseHover(object sender, EventArgs e)
        {
            if (gridControl1.DataSource == null)
            {
                if (Degiskenler == null || Degiskenler.Count == 0) // Okan
                    Degiskenler = context.VDIE_BIL_SABLON_DEGISKENLERs.ToList();
                this.gridControl1.DataSource = Degiskenler;
            }
        }

        private void kaydet_FormClosed(object sender, FormClosedEventArgs e)
        {
            DokumanDoldur();
            uctxEditor1.ClearEditor();
        }

        #region <MB-20100629>

        //Yazýþma örneklerinin belirlenen kritere göre gruplanmasýný saðlamak için eklendi.

        private void gcGruplamaSecenekleri_EditValueChanging(object sender,
                                                             DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue == null) return;

            gridView2.SortInfo.Clear();
            colKATEGORI_ID.Visible = false;

            if ((int)e.NewValue == 0)
                gridView2.SortInfo.Add(colADLI_BIRIM_BOLUM_ID, DevExpress.Data.ColumnSortOrder.Ascending);
            else if ((int)e.NewValue == 1)
                gridView2.SortInfo.Add(colKATEGORI_ID, DevExpress.Data.ColumnSortOrder.Ascending);
            else if ((int)e.NewValue == 2)
                gridView2.SortInfo.Add(colADLI_BIRIM_GOREV_ID, DevExpress.Data.ColumnSortOrder.Ascending);
            else if ((int)e.NewValue == 3)
                gridView2.SortInfo.Add(colSEKTOR_ID, DevExpress.Data.ColumnSortOrder.Ascending);
            else if ((int)e.NewValue == 4)
                gridView2.SortInfo.Add(colDAVA_TALEP_ID, DevExpress.Data.ColumnSortOrder.Ascending);
            else if ((int)e.NewValue == 5)
                gridView2.SortInfo.Clear();
        }

        #endregion <MB-20100629>
    }
}