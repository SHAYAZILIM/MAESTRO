using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib.Hesap;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util
{
    public partial class UcDovizliTutarAlani : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public UcDovizliTutarAlani()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Load += UcDovizliTutarAlani_Load;
            lueBirim.EditValueChanged += controls_TutarDegisti;
            spinTutar.ValueChanged += controls_TutarDegisti;
        }

        private void InitsData()
        {
            #region <YY-20090613>

            //Designmode + Nettiers bağlantı kontrolü yapıldı.
            if (DesignMode || !EntityBase.BagliKullaniciId.HasValue)
            {
                return;
            }

            #endregion </YY-20090613>

            BelgeUtil.Inits.DovizTipGetir(lueBirim);
            BelgeUtil.Inits.ParaBicimiAyarla(spinTutar);
        }

        private void UcDovizliTutarAlani_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //InitsData();

                if (lueBirim.Properties.Buttons.Count > 0)
                    lueBirim.Properties.Buttons[0].Visible = lueBirim.Properties.ReadOnly;

                if (spinTutar.Properties.Buttons.Count > 0)
                    spinTutar.Properties.Buttons[0].Visible = spinTutar.Properties.ReadOnly;
            }
        }

        #region Properties

        [Category("Ozellikler")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool ReadOnlyDoviz
        {
            get { return lueBirim.Properties.ReadOnly; }
            set
            {
                lueBirim.Properties.ReadOnly = value;
                if (lueBirim.Properties.Buttons.Count > 0)
                    lueBirim.Properties.Buttons[0].Visible = value;
            }
        }

        [Category("Ozellikler")]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool ReadOnlyTutar
        {
            get { return spinTutar.Properties.ReadOnly; }
            set
            {
                spinTutar.Properties.ReadOnly = value;
                if (spinTutar.Properties.Buttons.Count > 0)
                    spinTutar.Properties.Buttons[0].Visible = value;
            }
        }

        [Browsable(false)]
        public ParaVeDovizId Tutar
        {
            get
            {
                int birim = 1;
                if (lueBirim.EditValue != null)
                    birim = (int)lueBirim.EditValue;

                ParaVeDovizId para = new ParaVeDovizId(spinTutar.Value, birim);

                return para;
            }
            set
            {
                if (value != null)
                {
                    if (lueBirim.Properties.DataSource == null)
                    {
                        InitsData();
                    }

                    lueBirim.EditValue = value.DovizId;
                    spinTutar.Value = value.Para;
                }
                else if (value == null)
                {
                    lueBirim.EditValue = 1; // ytl
                    spinTutar.Value = decimal.Zero;
                }
            }
        }

        #endregion

        #region TutarDegisti Event

        public event EventHandler<EventArgs> TutarDegisti;

        private void controls_TutarDegisti(object sender, EventArgs e)
        {
            if (TutarDegisti != null)
                TutarDegisti(this, new EventArgs());
        }

        private void lueBirim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal tutar = (decimal)spinTutar.EditValue;
            int? dovizId = (int?)e.OldValue;
            if (tutar != 0 && dovizId.HasValue)
            {
                var eskiTutar = new ParaVeDovizId(tutar, dovizId);
                spinTutar.EditValue = DovizHelper.CaprazCevir(eskiTutar, (int)e.NewValue, DateTime.Today);
            }
        }

        #endregion
    }
}