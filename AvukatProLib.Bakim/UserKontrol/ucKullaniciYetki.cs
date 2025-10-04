using AvukatProLib.Bakim.Resources;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AvukatProLib.Bakim.UserKontrol
{
    public partial class ucKullaniciYetki : UserControl
    {
        public ucKullaniciYetki()
        {
            InitializeComponent();
        }

        private TList<CS_KOD_FORM_LISTESI> fList = new TList<CS_KOD_FORM_LISTESI>();

        private string FormAcýklama = string.Empty;

        private string fullad = string.Empty;

        private int i = 1;

        public CS_KOD_FORM_LISTESI MyProperty
        {
            get
            {
                if (lslForumListesi.SelectedItem is CS_KOD_FORM_LISTESI)
                    return (CS_KOD_FORM_LISTESI)lslForumListesi.SelectedItem;
                else
                    return null;
            }
        }

        private void lueUstGrup_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            TList<CS_KOD_FORM_GRUP> alttip = DataRepository.CS_KOD_FORM_GRUPProvider.GetByUST_GRUP_ID((int)e.NewValue);
            TList<CS_KOD_FORM_LISTESI> formLis = DataRepository.CS_KOD_FORM_LISTESIProvider.Find("FORM_GRUP_ID = " + (int)e.NewValue);

            if (e.NewValue != null)
            {
                foreach (Control var in grpYetki.Controls)
                {
                    if (var.Name.Contains("luealtgrup1") && !var.Name.Contains("lueUst"))
                    {
                        (var as LookUpEdit).Visible = false;
                        (var as LookUpEdit).EditValue = 0;
                    }
                }
                string str = string.Empty;
                fList = new TList<CS_KOD_FORM_LISTESI>();
                foreach (CS_KOD_FORM_LISTESI FormL in formLis)
                {
                    fList.Add(FormL);
                }
                str = "FULL_ADI";
                lslForumListesi.DataSource = fList;
                lslForumListesi.ValueMember = "ID";
                lslForumListesi.DisplayMember = null;
                lslForumListesi.DisplayMember = str;

                if (alttip.Count > 0)
                {
                    foreach (Control c in this.grpYetki.Controls)
                    {
                        if (c.Name.Contains("luealtgrup1"))
                        {
                            Inits.FormAltTipi((c as LookUpEdit), (int)e.NewValue);
                            (c as LookUpEdit).Properties.DataSource = alttip;
                            (c as LookUpEdit).Visible = true;
                            if (alttip.Count > 0)
                            {
                                (c as LookUpEdit).EditValueChanging += ucLookUpEdit_EditValueChanging;
                            }
                        }
                    }
                }
            }
        }

        private void ucKullaniciYetki_Load(object sender, EventArgs e)
        {
            fList = DataRepository.CS_KOD_FORM_LISTESIProvider.GetAll();
            Inits.FormGrupGetir(lueUstGrup);
        }

        private void ucLookUpEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            TList<CS_KOD_FORM_GRUP> alttip = DataRepository.CS_KOD_FORM_GRUPProvider.GetByUST_GRUP_ID((int)e.NewValue);
            if (e.NewValue != null)
            {
                TList<CS_KOD_FORM_LISTESI> formLis = DataRepository.CS_KOD_FORM_LISTESIProvider.Find("FORM_GRUP_ID = " + (int)e.NewValue);

                foreach (CS_KOD_FORM_LISTESI FormL in formLis)
                {
                    if (!fList.Contains(FormL))
                        fList.Add(FormL);
                }
                lslForumListesi.DataSource = fList;
                lslForumListesi.ValueMember = "ID";
                if (alttip.Count > 0)
                {
                    foreach (Control c in this.grpYetki.Controls)
                    {
                        if (c.Name.Contains("luealtgrup" + i.ToString()) && c.Visible == false)
                        {
                            LookUpEdit lue = (c as LookUpEdit);
                            Inits.FormAltTipi(lue, (int)e.NewValue);
                            lue.Properties.DataSource = alttip;
                            lue.Visible = true;
                            if (alttip != null)
                            {
                                lue.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(ucLookUpEdit_EditValueChanging);
                            }
                        }
                    }
                }
            }
        }
    }
}