using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Linq;

namespace AdimAdimDavaKaydi.Editor.UserControls
{
    public partial class ucBirdenFaziafoyileBirdenFazlaRapor : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBirdenFaziafoyileBirdenFazlaRapor()
        {
            InitializeComponent();
        }

        private AdimAdimDavaKaydi.UserControls.ucIcraFoy ucIcraFoy1;

        [Browsable(false)]
        public frmEditor SelectedEditor
        {
            get { return this.ucSablonEditoreGonder1.SelectedEditor; }
            set { this.ucSablonEditoreGonder1.SelectedEditor = value; }
        }

        private void gview_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            GridView gview = ((GridView)ucIcraFoy1.gcIcraFoy.MainView);
            int[] selRows = gview.GetSelectedRows();
            this.ucSablonEditoreGonder1.Foys =
                new AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY>();
            for (int i = 0; i < selRows.Length; i++)
            {
                this.ucSablonEditoreGonder1.Foys.Add(gview.GetRow(selRows[i]));
            }
        }

        private void ucBirdenFaziafoyileBirdenFazlaRapor_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            this.ucIcraFoy1 = new AdimAdimDavaKaydi.UserControls.ucIcraFoy();
            this.ucIcraFoy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraFoy1.Location = new System.Drawing.Point(0, 0);
            this.ucIcraFoy1.MyDataSource = null;
            this.ucIcraFoy1.Name = "ucIcraFoy1";
            this.ucIcraFoy1.Size = new System.Drawing.Size(559, 395);
            this.ucIcraFoy1.TabIndex = 0;
            this.Controls.Add(this.ucIcraFoy1);

            #region SUBEKONTROLLU VERI CEKME

            if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    ucIcraFoy1.MyDataSource = BelgeUtil.Inits.IcraDosyalariGetir();
                else
                {
                    if (BelgeUtil.Inits._IcraDosyalarArama != null)
                        ucIcraFoy1.MyDataSource = BelgeUtil.Inits.IcraDosyalariGetirAramaBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);
                    else
                        ucIcraFoy1.MyDataSource = BelgeUtil.Inits.IcraDosyalariGetirAramaBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);
                }

            #endregion SUBEKONTROLLU VERI CEKME

            if (BelgeUtil.Inits._SablonRaporGetir == null)
            {
                BelgeUtil.Inits._SablonRaporGetir = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.ToList();
            }
            this.ucSablonEditoreGonder1.MyDataSource = BelgeUtil.Inits._SablonRaporGetir;
            if (ucIcraFoy1.gcIcraFoy.MainView is GridView)
            {
                GridView gview = ((GridView)ucIcraFoy1.gcIcraFoy.MainView);
                gview.OptionsSelection.MultiSelect = true;

                gview.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                gview.SelectionChanged += gview_SelectionChanged;
            }
        }
    }
}