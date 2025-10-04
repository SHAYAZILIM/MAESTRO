using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AvukatProLib.Controls
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DevExpress.XtraGrid.Views.Grid.GridView grid;

        /// <summary>
        /// girdview e ait Biçimlendirme degerlerini tutan class
        /// </summary>
        private List<Bilgi> liste = null;

        private bool secim = false;

        /// <summary>
        /// Biçimlendirme Yapýlacak GridView
        /// </summary>
        public DevExpress.XtraGrid.Views.Grid.GridView Grid
        {
            get
            {
                return grid;
            }
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

                //cbSutun.DataSource = listeT;
                rlkSutunlar.DataSource = listeT;
                lkSutun.Properties.DataSource = listeT;

                //cbKSutun1.DataSource = listeT;
                //cbKSutun2.DataSource = listeT;
            }
        }

        public static StyleFormatCondition ConvertBilgiToSFC(Bilgi b, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            StyleFormatCondition sf = new StyleFormatCondition();
            sf.Appearance.BackColor = b.ArkaPlanRengi;
            sf.Appearance.Options.UseBackColor = true;
            sf.Appearance.BackColor2 = b.ArkaPlanRengi2;
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

        private void buKuralýDeðiþtirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                propertyGridControl1.SelectedObject = listView1.SelectedItems[0].Tag as Bilgi;
                secim = true;
            }
        }

        private void buKuralýSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

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

                //b.Sutun = (cbSutun.SelectedItem as Tanim).FieldName;
                //b.Sutun1 = (cbKSutun1.SelectedItem as Tanim).FieldName;
                //b.Sutun2 = (cbKSutun2.SelectedItem as Tanim).FieldName;

                Bilgi b2 = new Bilgi();

                //propertyGrid1.SelectedObject = b2;
                propertyGridControl1.SelectedObject = b2;
                b2.PropertyChanged += new EventHandler<PropertyChangedEventArgler>(bilgiPropertyChanged);

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0 && MessageBox.Show("Seçilen koþulu silmek istediðinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Grid.FormatConditions.Clear();

                foreach (ListViewItem li in listView1.Items)
                {
                    Bilgi b = li.Tag as Bilgi;
                    StyleFormatCondition sf = ConvertBilgiToSFC(b, Grid);

                    //    new StyleFormatCondition();
                    //sf.Appearance.BackColor = b.ArkaPlanRengi;
                    //sf.Appearance.Options.UseBackColor = true;
                    //sf.Appearance.BackColor2 = b.ArkaPlanRengi2;
                    //sf.Tag = b;
                    //sf.ApplyToRow = b.SatiraUygula;
                    //sf.Column = grid.Columns[b.Sutun];
                    //sf.Condition = b.Kosul;
                    //if (b.Tip == KarsilastirmaTipi.Deger)
                    //{
                    //    sf.Value1 = this.Degistir(b.Deger1, b.DegerlerinTipi);
                    //    sf.Value2 = this.Degistir(b.Deger2, b.DegerlerinTipi);
                    //}
                    //else
                    //{
                    //    sf.Value1 = Grid.GetRowCellValue(Grid.FocusedRowHandle, Grid.Columns[b.Sutun1]);
                    //    sf.Value2 = Grid.GetRowCellValue(Grid.FocusedRowHandle, Grid.Columns[b.Sutun2]);
                    //}

                    Grid.FormatConditions.Add(sf);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Inits.RenkGecisYonuGetir(rlkRenkGecisYonu);
            Inits.RenkUygulamaTipiGetir(rlkRenkUygulamaTipi);
            Inits.BicimKosuluGetir(rlkBicimKosulu);
            Bilgi b = new Bilgi();

            //propertyGrid1.SelectedObject = b;
            propertyGridControl1.SelectedObject = b;
            b.PropertyChanged += new EventHandler<PropertyChangedEventArgler>(bilgiPropertyChanged);

            //gbSutun.Enabled = b.Tip == KarsilastirmaTipi.Sutun;
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

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Bilgi b = propertyGrid1.SelectedObject as Bilgi;

            //gbSutun.Enabled = b.Tip == KarsilastirmaTipi.Sutun;
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
                    try
                    {
                        if (tnm.GridColumn.ColumnEdit != null)
                        {
                            rowDeger1.Properties.RowEdit = tnm.GridColumn.ColumnEdit;
                            rowDeger2.Properties.RowEdit = tnm.GridColumn.ColumnEdit;
                        }
                        else
                        {
                            if (tnm.GridColumn.ColumnType.FullName.Contains("System.DateTime"))
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rdtTarih;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Boolean"))
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rchkKutucuk;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Decimal"))
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rtxtYazi;
                            }
                            else
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rtxtYazi;
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

        private void splitContainerControl1_Paint(object sender, PaintEventArgs e)
        {
        }
    }

    /// <summary>
    /// bier View üzerindeki Kolonlara ait deðerleri atamak için kullanýlýr
    /// </summary>
    public class Tanim
    {
        private string caption;
        private string fieldName;

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn;

        /// <summary>
        /// view üzerindeki Alanýn Caption
        /// </summary>
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        /// <summary>
        /// view uzerindeki Alan
        /// </summary>
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        /// <summary>
        /// view uzerindeki current kolon
        /// </summary>
        public GridColumn GridColumn
        {
            get { return gridColumn; }
            set { gridColumn = value; }
        }

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