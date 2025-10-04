using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AvukatProRaporlar.Raport.Util
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Bilgi GBilgi;

        public string uniqueID;

        private DevExpress.XtraGrid.Views.Grid.GridView grid;

        /// <summary>
        /// girdview e ait Bi�imlendirme degerlerini tutan class
        /// </summary>
        private List<Bilgi> liste = null;

        private bool secim = false;

        /// <summary>
        /// Bi�imlendirme Yap�lacak GridView
        /// </summary>
        public DevExpress.XtraGrid.Views.Grid.GridView Grid
        {
            get
            {
                return grid;
            }
            set
            {
                ///View �zerindeki kolonlari tanim tipine Donusturup Tutacag�m�z List
                List<Tanim> listeT = new List<Tanim>();

                ///View uzerindeki kolonlar� Tanimn Tipine At�oruz ...
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

        public static void BicimKosuluGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AraKararTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");

            foreach (DevExpress.XtraGrid.FormatConditionEnum tipi in Enum.GetValues(typeof(DevExpress.XtraGrid.FormatConditionEnum)))
            {
                switch (tipi)
                {
                    case FormatConditionEnum.None:
                        dt.Rows.Add(tipi, "Yok");
                        break;

                    case FormatConditionEnum.Equal:
                        dt.Rows.Add(tipi, "E�it");
                        break;

                    case FormatConditionEnum.NotEqual:
                        dt.Rows.Add(tipi, "E�it de�il");
                        break;

                    case FormatConditionEnum.Between:
                        dt.Rows.Add(tipi, "Aras�nda");
                        break;

                    case FormatConditionEnum.NotBetween:
                        dt.Rows.Add(tipi, "Aras�nda de�il");
                        break;

                    case FormatConditionEnum.Less:
                        dt.Rows.Add(tipi, "K���kt�r");
                        break;

                    case FormatConditionEnum.Greater:
                        dt.Rows.Add(tipi, "B�y�kt�r");
                        break;

                    case FormatConditionEnum.GreaterOrEqual:
                        dt.Rows.Add(tipi, "B�y�k yada e�ittir");
                        break;

                    case FormatConditionEnum.LessOrEqual:
                        dt.Rows.Add(tipi, "K���k yada e�ittir");

                        break;
                }
            }

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Se�";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Ge�i� Y�n�"));
        }

        public static StyleFormatCondition ConvertBilgiToSFC(Bilgi b, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            StyleFormatCondition sf = new StyleFormatCondition();
            sf.Appearance.BackColor = b.ArkaPlanRengi;
            sf.Appearance.Options.UseBackColor = true;
            sf.Appearance.BackColor2 = b.ArkaPlanRengi2;
            sf.Appearance.Options.UseForeColor = true;
            sf.Appearance.Options.UseBorderColor = true;
            sf.Appearance.ForeColor = b.YaziRengi;
            sf.Appearance.BorderColor = b.KenarlikRengi;
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

        public static void RenkGecisYonuGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AraKararTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");

            foreach (System.Drawing.Drawing2D.LinearGradientMode tipi in Enum.GetValues(typeof(System.Drawing.Drawing2D.LinearGradientMode)))
            {
                switch (tipi)
                {
                    case LinearGradientMode.Horizontal:
                        dt.Rows.Add(tipi, "Yatay");
                        break;

                    case LinearGradientMode.Vertical:
                        dt.Rows.Add(tipi, "Dikey");
                        break;

                    case LinearGradientMode.ForwardDiagonal:
                        dt.Rows.Add(tipi, "�leri �apraz");
                        break;

                    case LinearGradientMode.BackwardDiagonal:
                        dt.Rows.Add(tipi, "Geri �apraz");
                        break;
                }
            }

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Se�";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Ge�i� Y�n�"));
        }

        public static void RenkUygulamaTipiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AraKararTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            dt.Rows.Add(true, "T�m Sat�ra Uygula");
            dt.Rows.Add(false, "Sadece H�creye Uygula");

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Se�";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Uygulama Tipi"));
        }

        private static object Degistir(object deger, DegerTipi dt)
        {
            switch (dt)
            {
                case DegerTipi.Say�sal:
                    return Convert.ToDecimal(deger);

                case DegerTipi.Alfabetik:
                    return deger;

                case DegerTipi.Tarih:
                    return Convert.ToDateTime(deger);

                case DegerTipi.Mant�ksal:
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

        private void buKural�De�i�tirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                propertyGridControl1.SelectedObject = listView1.SelectedItems[0].Tag as Bilgi;
                secim = true;
            }
        }

        private void buKural�SilToolStripMenuItem_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Ko�ul Belirtilmemi�");
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
                if (listView1.SelectedItems.Count > 0 && MessageBox.Show("Se�ilen ko�ulu silmek istedi�inize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                List<Bilgi> bilgiler = new List<Bilgi>();
                foreach (ListViewItem li in listView1.Items)
                {
                    Bilgi b = li.Tag as Bilgi;
                    StyleFormatCondition sf = ConvertBilgiToSFC(b, Grid);
                    bilgiler.Add(b);

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
                BinaryFormatter bf = new BinaryFormatter();
                if (!Directory.Exists(Application.StartupPath + "\\StyleConditions"))
                    Directory.CreateDirectory(Application.StartupPath + "\\StyleConditions");
                bf.Serialize(File.Create(Application.StartupPath + "\\StyleConditions\\" + uniqueID + "_" + ".scxx"), bilgiler);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void DegerDoldur(Tanim tnm)
        {
            var source = Grid.DataSource;
            rlkDeger.DisplayMember = tnm.FieldName;
            rlkDeger.ValueMember = tnm.FieldName;
            rlkDeger.Columns.Clear();
            rlkDeger.Columns.Add(new LookUpColumnInfo(tnm.FieldName, 10, tnm.Caption));
            rlkDeger.DataSource = source;
            rlkDeger.NullText = "Se�";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RenkGecisYonuGetir(rlkRenkGecisYonu);
            RenkUygulamaTipiGetir(rlkRenkUygulamaTipi);
            BicimKosuluGetir(rlkBicimKosulu);
            Bilgi b = new Bilgi();

            //propertyGrid1.SelectedObject = b;
            propertyGridControl1.SelectedObject = b;
            b.PropertyChanged += new EventHandler<PropertyChangedEventArgler>(bilgiPropertyChanged);
            rcimKarsilastirmaTipi.Items.AddEnum(typeof(KarsilastirmaTipi));
            rcimDegerlerinTipi.Items.AddEnum(typeof(DegerTipi));
        }

        private void GriddenKosulGetir()
        {
            if (liste == null)
                liste = new List<Bilgi>();

            ///Gridview e ait Formnat tan�mlamalar�n�n tag lerini bilgi class � olarak al�oruz ...
            foreach (StyleFormatCondition sf in Grid.FormatConditions)
            {
                Bilgi b = sf.Tag as Bilgi;

                liste.Add(b);
            }
        }

        /// <summary>
        /// View e ait Bilgilerin ListView uzeirne baws�ld�g� metod ...
        /// </summary>
        private void Listele()
        {
            ///degerlerin bas�lacag� listview i�erisindeki degerleri temizle
            listView1.Items.Clear();

            ///listedeki Bi�imlendirme De�erlerini listview e bas...
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

        private void propertyDescriptionControl1_Click(object sender, EventArgs e)
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
                    DegerDoldur(tnm);
                    Bilgi bilgim = (Bilgi)propertyGridControl1.SelectedObject;
                    bilgim.Sutun = tnm.FieldName;
                    bilgim.Tip = KarsilastirmaTipi.Deger;
                    bilgim.Kosul = FormatConditionEnum.Equal;

                    try
                    {
                        if (tnm.GridColumn.ColumnEdit != null)
                        {
                            //rowDeger1.Properties.RowEdit = tnm.GridColumn.ColumnEdit;
                            //rowDeger2.Properties.RowEdit = tnm.GridColumn.ColumnEdit;
                            if (tnm.GridColumn.ColumnType.FullName.Contains("System.DateTime"))
                            {
                                bilgim.DegerlerinTipi = DegerTipi.Tarih;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Boolean"))
                            {
                                bilgim.DegerlerinTipi = DegerTipi.Mant�ksal;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Decimal"))
                            {
                                bilgim.DegerlerinTipi = DegerTipi.Say�sal;
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
                                bilgim.DegerlerinTipi = DegerTipi.Mant�ksal;
                            }
                            else if (tnm.GridColumn.ColumnType.FullName.Contains("System.Decimal"))
                            {
                                rowDeger1.Properties.RowEdit =
                                    rowDeger2.Properties.RowEdit = rtxtYazi;
                                bilgim.DegerlerinTipi = DegerTipi.Say�sal;
                            }
                            else
                            {
                                //rowDeger1.Properties.RowEdit =
                                //    rowDeger2.Properties.RowEdit = rtxtYazi;
                                //bilgim.DegerlerinTipi = DegerTipi.Alfabetik;
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
    /// bier View �zerindeki Kolonlara ait de�erleri atamak i�in kullan�l�r
    /// </summary>
    public class Tanim
    {
        private string caption;
        private string fieldName;

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn;

        /// <summary>
        /// view �zerindeki Alan�n Caption
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
        /// <returns>Caption</returns>
        public override string ToString()
        {
            return this.Caption;
        }
    }
}