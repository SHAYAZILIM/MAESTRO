using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;

namespace AdimAdimDavaKaydi.IcraTakip.UserControls
{
    public partial class ucAlacakNedenTaraf : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucAlacakNedenTaraf()
        {
            InitializeComponent();
        }

        public TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> DtAlacakNeden
        {
            get { return (TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>)vgAlacakNedenTaraf.DataSource; }
            set
            {
                if (value != null)
                {
                    this.vgAlacakNedenTaraf.DataSource = value;
                    value.ListChanged += value_ListChanged;
                }
            }
        }

        public int RecordIndex
        {
            get { return vgAlacakNedenTaraf.FocusedRecord; }
        }

        private void value_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (FocusedTarafChanged != null)
            {
                FocusedTarafChanged(sender, new IndexChangedEventArgs(0, 0));
            }
        }

        public AV001_TI_BIL_ALACAK_NEDEN_TARAF CurrentNedenTaraf
        {
            get
            {
                if (DtAlacakNeden == null || DtAlacakNeden.Count == 0 || vgAlacakNedenTaraf.FocusedRecord < 0)
                    return null;
                return DtAlacakNeden[vgAlacakNedenTaraf.FocusedRecord];
            }
        }

        private void initData()
        {
            BelgeUtil.Inits.perCariGetir(rlkTarafCari);
            BelgeUtil.Inits.CariSifatGetir(rlkTarafSifat);
            BelgeUtil.Inits.DovizTipGetir(rlkGenericDovizId);
            BelgeUtil.Inits.ParaBicimiAyarla(rudIhtarGideri);
        }

        private void ucAlacakNedenTaraf_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                initData();
            }
        }

        public event DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler FocusedTarafChanged;

        private void vgAlacakNedenTaraf_FocusedRecordChanged(object sender,
                                                             DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (FocusedTarafChanged != null)
            {
                FocusedTarafChanged(sender, e);
            }
        }

        private bool _CanEditCari;

        public bool CanEditCari
        {
            get { return _CanEditCari; }
            set
            {
                _CanEditCari = value;
                foreach (
                    DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties prp in
                        mrowTarafSifatTarafAdi.PropertiesCollection)
                {
                    prp.ReadOnly = !value;
                }
                dataNavigatorExtended1.Buttons.Append.Visible = true;
            }
        }


        private void rlkTarafCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;
                cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);
                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rlkTarafCari);
                                           }
                                       };
            }
        }

        private void rlkTarafCari_ProcessNewValue(object sender,
                                                  DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (lue.Text != string.Empty)
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;
                cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);
                // cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rlkTarafCari);
                                           }
                                       };
            }
        }
    }
}