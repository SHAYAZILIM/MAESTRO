using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;

namespace AdimAdimDavaKaydi
{
    public partial class frmBicimlendirme : XtraForm
    {
        public frmBicimlendirme()
        {
            InitializeComponent();
        }

        /// <summary>
        /// girdview e ait Biçimlendirme degerlerini tutan class
        /// </summary>
        private List<Bilgi> liste;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bilgi b = propertyGridControl1.SelectedObject as Bilgi;

                if (b.Kosul == FormatConditionEnum.None)
                {
                    MessageBox.Show("Koþul Belirtilmemiþ");
                    return;
                }

                Bilgi b2 = new Bilgi();
                propertyGridControl1.SelectedObject = b2;
                b2.PropertyChanged += bilgiPropertyChanged;

                if (!secim)
                {
                    liste.Add(b);
                    secim = false;
                }

                this.Listele();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private static object Degistir(object deger, DegerTipi dt)
        {
            switch (dt)
            {
                case DegerTipi.Sayýsal:
                    return Convert.ToDecimal(deger);
                case DegerTipi.Alfabetik:
                    return deger;
                case DegerTipi.Tarih:
                    return Convert.ToDateTime(deger);
                case DegerTipi.Mantýksal:
                    return Convert.ToBoolean(deger);
                default:
                    return null;
            }
        }

        private bool secim;

        /// <summary>
        /// View e ait Bilgilerin ListView uzeirne bawsýldýgý metod ...
        /// </summary>
        private void Listele()
        {
            ///degerlerin basýlacagý listview içerisindeki degerleri temizle
            listView1.Items.Clear();
            ///listedeki Biçimlendirme Deðerlerini listview e bas...
            foreach (Bilgi b in liste)
            {
                ListViewItem li = new ListViewItem();
                b.ArkaPlanRengiArgb = b.ArkaPlanRengi.ToArgb();
                b.ArkaPlanRengi2Argb = b.ArkaPlanRengi2.ToArgb();
                b.KenarlikRengiArgb = b.KenarlikRengi.ToArgb();
                b.YaziRengiArgb = b.YaziRengi.ToArgb();
                li.Tag = b;
                li.Text = b.Sutun;
                li.SubItems.Add(b.Kosul.ToString());
                if (b.Deger1 != null)
                    li.SubItems.Add(b.Deger1.ToString());
                if (b.Deger2 != null)
                    li.SubItems.Add(b.Deger2.ToString());

                listView1.Items.Add(li);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0 &&
                    MessageBox.Show("Seçilen koþulu silmek istediðinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private DevExpress.XtraGrid.Views.Grid.GridView grid;

        /// <summary>
        /// Biçimlendirme Yapýlacak GridView
        /// </summary>
        public DevExpress.XtraGrid.Views.Grid.GridView Grid
        {
            get { return grid; }
            set
            {
                ///View üzerindeki kolonlari tanim tipine Donusturup Tutacagýmýz List
                List<Tanim> listeT = new List<Tanim>();
                ///View uzerindeki kolonlarý Tanimn Tipine Atýoruz ...
                foreach (DevExpress.XtraGrid.Columns.GridColumn gc in value.Columns)
                {
                    Tanim t = new Tanim();
                    t.Caption = gc.Caption;
                    t.FieldName = gc.FieldName;
                    t.GridColumn = gc;
                    listeT.Add(t);
                }

                grid = value;

                try
                {
                    this.GriddenKosulGetir();
                    this.Listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Test" + ex.Message);
                }

                rlkSutunlar.DataSource = listeT;
                lkSutun.Properties.DataSource = listeT;
            }
        }

        private void GriddenKosulGetir()
        {
            if (liste == null)
                liste = new List<Bilgi>();

            ///Gridview e ait Formnat tanýmlamalarýnýn tag lerini bilgi class ý olarak alýoruz ...
            foreach (StyleFormatCondition sf in Grid.FormatConditions)
            {
                Bilgi b = sf.Tag as Bilgi;

                liste.Add(b);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.RenkGecisYonuGetir(rlkRenkGecisYonu);
            BelgeUtil.Inits.RenkUygulamaTipiGetir(rlkRenkUygulamaTipi);
            BelgeUtil.Inits.BicimKosuluGetir(rlkBicimKosulu);
            Bilgi b = new Bilgi();
            propertyGridControl1.SelectedObject = b;
            b.PropertyChanged += bilgiPropertyChanged;

            ricmbKarsilastirmaTipi.Items.AddEnum(typeof(KarsilastirmaTipi));
            ricmbDegerlerinTipi.Items.AddEnum(typeof(DegerTipi));
        }

        private void bilgiPropertyChanged(object sender, PropertyChangedEventArgler e)
        {
            Bilgi bilgi = sender as Bilgi;
            if (bilgi == null)
                return;
            if (e.PropertyName == "Tip")
            {
                switch (bilgi.Tip)
                {
                    case KarsilastirmaTipi.Sutun:
                        rowDeger1.Visible = rowDeger2.Visible = false;
                        rowSutun1.Visible = rowSutun2.Visible = true;
                        break;
                    case KarsilastirmaTipi.Deger:
                        rowDeger1.Visible = rowDeger2.Visible = true;
                        rowSutun1.Visible = rowSutun2.Visible = false;
                        break;
                }
            }
        }

        private void buKuralýSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void buKuralýDeðiþtirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                propertyGridControl1.SelectedObject = listView1.SelectedItems[0].Tag as Bilgi;
                secim = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Grid.FormatConditions.Clear();
                List<Bilgi> bilgiler = new List<Bilgi>();
                foreach (ListViewItem li in listView1.Items)
                {
                    Bilgi b = li.Tag as Bilgi;
                    StyleFormatCondition sf = ConvertBilgiToSFC(b, Grid, true);
                    bilgiler.Add(b);
                    Grid.FormatConditions.Add(sf);
                }
                BinaryFormatter bf = new BinaryFormatter();
                if (!Directory.Exists(Application.StartupPath + "\\StyleConditions"))
                    Directory.CreateDirectory(Application.StartupPath + "\\StyleConditions");
                bf.Serialize(
                    File.Create(Application.StartupPath + "\\StyleConditions\\" +
                                ((ExtendedGridControl)grid.GridControl).UniqueId + "_" + grid.Name + ".scxx"), bilgiler);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        public static StyleFormatCondition ConvertBilgiToSFC(Bilgi b, DevExpress.XtraGrid.Views.Grid.GridView gridView, bool IsNew)
        {
            StyleFormatCondition sf = new StyleFormatCondition();
            if (IsNew)
            {
                sf.Appearance.BackColor = b.ArkaPlanRengi;
                sf.Appearance.BackColor2 = b.ArkaPlanRengi2;
                sf.Appearance.BorderColor = b.KenarlikRengi;
                sf.Appearance.ForeColor = b.YaziRengi;
            }
            sf.Appearance.BackColor = System.Drawing.Color.FromArgb(b.ArkaPlanRengiArgb);
            sf.Appearance.Options.UseBackColor = true;
            sf.Appearance.BackColor2 = System.Drawing.Color.FromArgb(b.ArkaPlanRengi2Argb);
            sf.Appearance.Options.UseForeColor = true;
            sf.Appearance.Options.UseBorderColor = true;
            sf.Appearance.ForeColor = System.Drawing.Color.FromArgb(b.YaziRengiArgb);
            sf.Appearance.BorderColor = System.Drawing.Color.FromArgb(b.KenarlikRengiArgb);
            sf.Tag = b;
            sf.ApplyToRow = b.SatiraUygula;
            sf.Column = gridView.Columns[b.Sutun];
            sf.Condition = b.Kosul;
            if (b.Tip == KarsilastirmaTipi.Deger)
            {
                sf.Value1 = Degistir(b.Deger1, b.DegerlerinTipi);
                sf.Value2 = Degistir(b.Deger2, b.DegerlerinTipi);
            }
            else
            {
                sf.Value1 = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns[b.Sutun1]);
                sf.Value2 = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns[b.Sutun2]);
            }

            return sf;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Bilgi b = propertyGrid1.SelectedObject as Bilgi;
        }

        private void rlkSutunlar_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookup = (LookUpEdit)sender;

            if (lookup.EditValue != null)
            {
                Tanim tnm = (Tanim)lookup.EditValue;
                if (tnm != null)
                {
                    Bilgi bilgim = (Bilgi)propertyGridControl1.SelectedObject;
                    bilgim.Sutun = tnm.FieldName;
                    bilgim.Tip = KarsilastirmaTipi.Deger;
                    bilgim.Kosul = FormatConditionEnum.Equal;

                    try
                    {
                        if (tnm.GridColumn.ColumnEdit != null)
                        {
                            rowDeger1.Properties.RowEdit = tnm.GridColumn.ColumnEdit;
                            rowDeger2.Properties.RowEdit = tnm.GridColumn.ColumnEdit;
                            if (tnm.GridColumn.ColumnType.FullName.Contains("System.DateTime"))
                            {
                                bilgim.DegerlerinTipi = DegerTipi.Tarih;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Boolean"))
                            {
                                bilgim.DegerlerinTipi = DegerTipi.Mantýksal;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Decimal"))
                            {
                                bilgim.DegerlerinTipi = DegerTipi.Sayýsal;
                            }
                            else
                            {
                                bilgim.DegerlerinTipi = DegerTipi.Alfabetik;
                            }
                        }
                        else
                        {
                            if (tnm.GridColumn.ColumnType.FullName.Contains("System.DateTime"))
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rdtTarih;
                                bilgim.DegerlerinTipi = DegerTipi.Tarih;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Boolean"))
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rchkKutucuk;
                                bilgim.DegerlerinTipi = DegerTipi.Mantýksal;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Decimal"))
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rtxtYazi;
                                bilgim.DegerlerinTipi = DegerTipi.Sayýsal;
                            }
                            else
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rtxtYazi;
                                bilgim.DegerlerinTipi = DegerTipi.Alfabetik;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }
    }

    /// <summary>
    /// bier View üzerindeki Kolonlara ait deðerleri atamak için kullanýlýr
    /// </summary>
    public class Tanim
    {
        /// <summary>
        /// view uzerindeki Alan
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// view üzerindeki Alanýn Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// view uzerindeki current kolon
        /// </summary>
        public GridColumn GridColumn { get; set; }

        /// <summary>
        /// view uzerindeki current kolonun Caption degeri
        /// </summary>
        /// <returns> Caption </returns>
        public override string ToString()
        {
            return this.Caption;
        }
    }
}