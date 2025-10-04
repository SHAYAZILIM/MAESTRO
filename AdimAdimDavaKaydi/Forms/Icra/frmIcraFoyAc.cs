using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{

    public partial class frmIcraFoyAc : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIcraFoyAc()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Açýlan foy seçim/arama penceresinde foy seçilip Aç tuþuna týklandýðýnda fýrlayan olaydýr.
        /// Ýçerisinde seçilen foyu döndürür (e.AcilanIcraFoyu)
        ///</summary>
        public event FoyAcildiEventHandler OnFoyAcildi;

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IcraFoyGetir(false, FoyGrupTipi.Null);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listView1.View = View.Details;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IcraFoyGetir(true, FoyGrupTipi.FormKonu);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IcraFoyGetir(true, FoyGrupTipi.FormTipi);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IcraFoyGetir(true, FoyGrupTipi.Durum);
        }

        private void frmIcraFoyAc_Load(object sender, EventArgs e)
        {
            this.listView1.Visible = true;
            listView1.Columns.Add("Esas No", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Adli Birim", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("No", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Görev", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Tarihi", -2, HorizontalAlignment.Center);
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.MultiSelect = false;
            listView1.Groups.Add("DIGER", "Diðer");
            listView1.Groups.Add("DOSYALAR", "Dosyalar");

            if (BelgeUtil.Inits._TakipKonusuGetir_Enter == null)
                BelgeUtil.Inits._TakipKonusuGetir_Enter = AvukatProLib2.Data.DataRepository.per_TI_KOD_TAKIP_TALEPProvider.GetAll();
            foreach (per_TI_KOD_TAKIP_TALEP talep in BelgeUtil.Inits._TakipKonusuGetir_Enter)
            {
                listView1.Groups.Add("TT" + talep.ID, talep.FORM_TIPI + " - " + talep.TALEP_ADI);
            }

            if (BelgeUtil.Inits._FormTipiGetir == null)
                BelgeUtil.Inits._FormTipiGetir = BelgeUtil.Inits.context.per_TI_KOD_FORM_TIPs.ToList();
            foreach (AvukatProLib.Arama.per_TI_KOD_FORM_TIP tip in BelgeUtil.Inits._FormTipiGetir)
            {
                listView1.Groups.Add("FT" + tip.ID, tip.FORM_ORNEK_NO + "(" + tip.YENI_FORM_ORNEK_NO + ") - " + tip.FORM_ADI);
            }
            if (BelgeUtil.Inits._FoyDurumGetir_Enter == null)
                BelgeUtil.Inits._FoyDurumGetir_Enter = DataRepository.per_TDI_KOD_FOY_DURUMProvider.GetAll();
            foreach (per_TDI_KOD_FOY_DURUM durum in BelgeUtil.Inits._FoyDurumGetir_Enter)
            {
                listView1.Groups.Add("DR" + durum.ID, durum.DURUM);
            }
        }

        private void IcraFoyGetir(bool grupla, FoyGrupTipi grupTipi)
        {
            listView1.Items.Clear();

            DataTable foyler = null;
            try
            {
                foyler = BelgeUtil.Inits.IcraDosyalariGetir();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return;
            }
            foreach (DataRow foy in foyler.Rows)
            {
                ListViewItem item1 = new ListViewItem(foy["ESAS_NO"] + " " + foy["ADLI_BIRIM_ADLIYE"] + " " + foy["ADLI_BIRIM_NO"] + " " + foy["GOREV"], 0);

                // Place a check mark next to the item.
                item1.Checked = true;
                item1.Tag = foy;
                item1.ToolTipText =
                    String.Format(
                        "ÝCRA DOSYASI{0}{0}Foy No: {1}{0}Durum: {2}{0}Örnek Form: {3}{0}Takip Konusu: {4}{0}Takip Tarihi: {5}",
                        Environment.NewLine, foy["FOY_NO"], foy["DURUM"], foy["FORM_ORNEK_NO"], foy["TAKIP_TALEP"],
                        Convert.ToDateTime(foy["TAKIP_TARIHI"]).ToShortDateString());
                try
                {
                    if (grupla)
                    {
                        if (grupTipi == FoyGrupTipi.FormKonu)
                            item1.Group = listView1.Groups["TT" + foy["TAKIP_TALEP_ID"]];
                        else if (grupTipi == FoyGrupTipi.FormTipi)
                            item1.Group = listView1.Groups["FT" + foy["FORM_TIP_ID"]];
                        else if (grupTipi == FoyGrupTipi.Durum)
                            item1.Group = listView1.Groups["DR" + foy["FOY_DURUM_ID"]];
                    }
                    else
                    {
                        item1.Group = listView1.Groups["DOSYALAR"];
                    }
                }
                catch (Exception)
                {
                    item1.Group = listView1.Groups["DIGER"];
                }
                ListViewItem.ListViewSubItem fd = item1.SubItems.Add(foy["ADLI_BIRIM_ADLIYE"].ToString());
                item1.SubItems.Add(foy["ADLI_BIRIM_NO"].ToString());
                item1.SubItems.Add(foy["GOREV"].ToString());
                item1.SubItems.Add(Convert.ToDateTime(foy["TAKIP_TARIHI"]).ToShortDateString());
                listView1.Items.Add(item1);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = listView1.SelectedItems[0];
                    AvukatProLib.Arama.VTI_ICRA_DOSYALAR mFoy = (AvukatProLib.Arama.VTI_ICRA_DOSYALAR)lvi.Tag;
                    richTextBox1.Text = lvi.ToolTipText;
                    richTextBox1.Font = new Font("Courier New", 8, FontStyle.Regular);

                    string takipEden = Environment.NewLine + "Takip Edenler :" + Environment.NewLine;
                    string takipEdilen = Environment.NewLine + "Takip Edilenler :" + Environment.NewLine;
                    string sorumluAvs = Environment.NewLine + "Sorumlular :" + Environment.NewLine;

                    foreach (var item in BelgeUtil.Inits.TarafVeSifatGetirByFoyId(mFoy.ID))
                    {
                        if (item.HANGI_TARAFI == "TAKÝP EDEN")
                        {
                            takipEden += item.SIFAT + " : " + item.AD +
                                         Environment.NewLine;
                        }
                        else if (item.HANGI_TARAFI == "TAKÝP EDÝLEN")
                        {
                            takipEdilen += item.SIFAT + " : " + item.AD +
                                           Environment.NewLine;
                        }
                    }
                    foreach (var srm in BelgeUtil.Inits.SorumluAvukatGetirByFoyId(mFoy.ID))
                    {
                        sorumluAvs += srm.AD + Environment.NewLine;
                    }
                    richTextBox1.Text += Environment.NewLine + takipEden + takipEdilen + sorumluAvs;
                    richTextBox1.Find("ÝCRA DOSYASI", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                    richTextBox1.Find("Foy No:", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                    richTextBox1.Find("Durum:", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                    richTextBox1.Find("Örnek Form:", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                    richTextBox1.Find("Takip Konusu:", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                    richTextBox1.Find("Takip Tarihi:", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                    richTextBox1.Find("Takip Edenler :", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                    richTextBox1.Find("Takip Edilenler :", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                    richTextBox1.Find("Sorumlular :", RichTextBoxFinds.MatchCase);
                    richTextBox1.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            IcraFoyGetir(false, FoyGrupTipi.Null);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (OnFoyAcildi != null)
                    OnFoyAcildi(this, new FoyAcildiEventArgs((AV001_TI_BIL_FOY)listView1.SelectedItems[0].Tag));
            }
        }
    }
    public delegate void FoyAcildiEventHandler(object sender, FoyAcildiEventArgs e);

    public enum FoyGrupTipi
    {
        Null,
        FormTipi,
        FormKonu,
        Durum,
        LehAleh
    }

    public class FoyAcildiEventArgs : EventArgs
    {
        public FoyAcildiEventArgs(AV001_TI_BIL_FOY foy)
        {
            AcilanIcraFoyu = foy;
        }

        public AV001_TD_BIL_FOY AcilanDavaFoyu { get; set; }

        public AV001_TI_BIL_FOY AcilanIcraFoyu { get; set; }
    }
}