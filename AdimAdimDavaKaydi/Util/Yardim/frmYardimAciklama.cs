using System;
using System.Collections.Generic;
using System.Drawing;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class frmYardimAciklama : DevExpress.XtraEditors.XtraForm
    {
        public frmYardimAciklama()
        {
            InitializeComponent();
        }

        private bool OldRecordOpened;
        private TDIE_KOD_PRATIK_YARDIM yardim;

        public void Show(ControlField field, List<ControlField> fieldList)
        {
            if (field == null)
            {
                return;
            }

            cf = field;
            if (field.Id == 0)
            {
                yardim = GetControlFieldAsPratikYardim(cf);
                yardim.UYARI_TIP_ID = 1;
                this.bindingSource1.DataSource = yardim;
                OldRecordOpened = false;
            }
            else
            {
                yardim = AvukatProLib2.Data.DataRepository.TDIE_KOD_PRATIK_YARDIMProvider.GetByID(field.Id);
                this.bindingSource1.DataSource = yardim;
                OldRecordOpened = true;
            }
            if (this.bindingSource1.DataSource == null)
            {
                yardim = GetControlFieldAsPratikYardim(cf);
                this.bindingSource1.DataSource = yardim;
                OldRecordOpened = true;
            }
            this.Show();
        }

        private TDIE_KOD_PRATIK_YARDIM GetControlFieldAsPratikYardim(ControlField cf)
        {
            TDIE_KOD_PRATIK_YARDIM yardim = new TDIE_KOD_PRATIK_YARDIM();
            yardim.ACIKLAMA = cf.Aciklama;
            yardim.ALAN_ADI = cf.ControlId;
            yardim.GORUNEN_AD = cf.Adi;
            yardim.BASLIK = cf.Baslik;
            yardim.FORM_ADI = cf.FormId;
            yardim.KONTROL_ADI = cf.ParentId;
            yardim.MODUL_ID = cf.ModulId;
            yardim.ID = cf.Id;

            yardim.UYARI_TIP_ID = cf.UyariID;
            return yardim;
        }

        private ControlField cf = new ControlField();

        public delegate void OnKaydet(object sender, TDIE_KOD_PRATIK_YARDIM newRecord, ControlField control);

        public event OnKaydet Kaydet;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.DataSource is TDIE_KOD_PRATIK_YARDIM)
            {
                TDIE_KOD_PRATIK_YARDIM yardimi = (TDIE_KOD_PRATIK_YARDIM)this.bindingSource1.DataSource;
                TList<TDIE_KOD_PRATIK_YARDIM> seciliYardimlar = new TList<TDIE_KOD_PRATIK_YARDIM>();
                //yardim.TDIE_KOD_PRATIK_YARDIMCollection
                //ucPratikYardim2.GetSeciliYardimlar();
                AvukatProLib2.Data.DataRepository.TDIE_KOD_PRATIK_YARDIMProvider.Save(yardimi);
                // Tools.SerializeXml((TDIE_KOD_PRATIK_YARDIM)this.bindingSource1.DataSource, Tools.TempFilesPath + "Yardim.xml");
                cf.Adi = yardimi.GORUNEN_AD;
                cf.Aciklama = yardimi.ACIKLAMA;
                cf.Baslik = yardimi.BASLIK;
                cf.ControlId = yardimi.ALAN_ADI;
                cf.FormId = yardimi.FORM_ADI;
                cf.ModulId = yardimi.MODUL_ID;
                cf.ParentId = yardimi.KONTROL_ADI;
                cf.UyariID = yardimi.UYARI_TIP_ID;
                cf.Id = yardimi.ID;
                if (Kaydet != null)
                {
                    Kaydet(this, (TDIE_KOD_PRATIK_YARDIM)this.bindingSource1.DataSource, cf);
                }
            }

            if (this.bindingSource1.DataSource is TList<TDIE_KOD_PRATIK_YARDIM>)
            {
                AvukatProLib2.Data.DataRepository.TDIE_KOD_PRATIK_YARDIMProvider.Save(
                    (TList<TDIE_KOD_PRATIK_YARDIM>)this.bindingSource1.DataSource);
            }

            if (!OldRecordOpened)
            {
                AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil.HelpStatus.Fields.Add(cf);
            }

            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static TList<TDIE_KOD_PRATIK_YARDIM> Yardimlar;

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (Yardimlar == null)
            {
                Yardimlar = new TList<TDIE_KOD_PRATIK_YARDIM>();
            }

            if (this.bindingSource1.DataSource is TDIE_KOD_PRATIK_YARDIM)
            {
                Yardimlar.Add(((TDIE_KOD_PRATIK_YARDIM)this.bindingSource1.DataSource));
                if (Kaydet != null)
                {
                    Kaydet(this, (TDIE_KOD_PRATIK_YARDIM)this.bindingSource1.DataSource, cf);
                }
            }

            Tools.SerializeXml(Yardimlar, Tools.TempFilesPath + "Yardim.xml");

            // AvukatProLib2.Data.DataRepository.TDIE_KOD_PRATIK_YARDIMProvider.Save((TDIE_KOD_PRATIK_YARDIM)this.bindingSource1.DataSource);
        }

        private void frmYardimAciklama_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.UyariTipDoldur(this.lookUpEdit1);
            BelgeUtil.Inits.ModulGetir(this.lookUpEdit2.Properties);
            if (string.IsNullOrEmpty(memoEdit1.Text))
            {
                this.memoEdit1.Text = "Yardým Metni";
            }
            if (string.IsNullOrEmpty(this.textEdit6.Text))
            {
                this.textEdit6.Text = "Yardým için bir baþlýk";
            }
            if (this.lookUpEdit1.EditValue == null)
            {
                this.lookUpEdit1.EditValue = 1;
            }

            TList<TDIE_KOD_PRATIK_YARDIM> yardimlar = new TList<TDIE_KOD_PRATIK_YARDIM>();
            AvukatProLib2.Data.DataRepository.TDIE_KOD_PRATIK_YARDIMProvider.DeepLoad(yardim, false,
                                                                                      AvukatProLib2.Data.DeepLoadType.
                                                                                          IncludeChildren,
                                                                                      typeof(
                                                                                          TList
                                                                                          <TDIE_KOD_PRATIK_YARDIM_ILISKI
                                                                                          >),
                                                                                      typeof(
                                                                                          TList<TDIE_KOD_PRATIK_YARDIM>));
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                colorEdit1.Color =
                    Color.FromName(
                        AvukatProLib2.Data.DataRepository.TDIE_KOD_UYARI_TIPProvider.GetByID(
                            Convert.ToInt32(lookUpEdit1.EditValue)).RENK);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            /// TODO : Yardým dosyasýný aç ve oradan seç ...
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmBrowser browser = new frmBrowser();
            browser.navigate("http://www.avukatpro.com/");
            browser.Show();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.lookUpEdit1.EditValue = 1;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            TDIE_KOD_PRATIK_YARDIM yardim = ucPratikYardim1.AlSeciliYardim();
            if (yardim != null)
            {
                this.memoEdit1.Text = yardim.ACIKLAMA;
                this.textEdit6.Text = yardim.ACIKLAMA;
                this.checkEdit1.EditValue = yardim.IPUCU_MU;
                this.checkEdit2.EditValue = yardim.UYAP_ICIN_GEREKLI_MI;
                this.textEdit5.EditValue = yardim.CEVRIMICI_VIDEO_ADRESI;
                this.textEdit9.EditValue = yardim.CEVRIMDISI_VIDEO_ADRESI;
                this.textEdit7.EditValue = yardim.CEVRIMICI_YARDIM_ADRESI;
                this.textEdit8.EditValue = yardim.CEVRIMDISI_YARDIM_ADRESI;
                this.pictureEdit1.EditValue = yardim.RESIM;
            }
        }
    }

    public class ControlField
    {
        public int Id { get; set; }

        public string ControlId { get; set; }

        public string FormId { get; set; }

        public string ParentId { get; set; }

        public string Adi { get; set; }

        public string Aciklama { get; set; }

        public string Baslik { get; set; }

        public int ModulId { get; set; }

        public int UyariID { get; set; }

        public ControlField()
        {
        }

        public ControlField(int id, string controlId, string formId, string parentId, int modul, string adi,
                            string baslik, string aciklama, int uyari)
        {
            this.Id = id;
            this.ControlId = controlId;
            this.Adi = adi;
            this.FormId = formId;
            this.ParentId = parentId;
            this.Aciklama = aciklama;
            this.ModulId = modul;
            this.Baslik = baslik;
            this.UyariID = uyari;
        }

        //public ControlField(int id, string controlId, string formId, string parentId,int modul, string adi, string aciklama):this(id,controlId,formId,parentId,1,adi, aciklama,
        //{
        //    this._id = id;
        //    this._controlId = controlId;
        //    this._adi = adi;
        //    this._FormId = formId;
        //    this._parentId = parentId;
        //    this._aciklama = aciklama;
        //    this._modul_Id = modul;

        //}

        public ControlField(int id, string controlId, string formId, string adi, string aciklama)
            : this(id, controlId, formId, string.Empty, 1, adi, string.Empty, aciklama, 0)
        {
        }

        public static ControlField FindInControlFields(string caption, string name, string parent, string form,
                                                       int modul, List<ControlField> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].FormId == form && fields[i].ControlId == name && fields[i].ParentId == parent &&
                    fields[i].ModulId == modul)
                {
                    return fields[i];
                }
            }

            return new ControlField(0, name, form, parent, modul, caption, string.Empty, string.Empty, 0);
        }
    }
}