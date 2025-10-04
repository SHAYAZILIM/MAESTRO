using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucIcraTalimatlari : AvpXUserControl
    {
        private TList<AV001_TI_BIL_TALIMAT> _MyDataSource;

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucIcraTalimatlari()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucIcraTalimatlari_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_TALIMAT> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (gcIcraTalimatlari != null)
                    gcIcraTalimatlari.DataSource = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    if (value.AV001_TI_BIL_TALIMATCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TI_BIL_TALIMAT>));
                    if (value.AV001_TI_BIL_TALIMATCollection.Count > 0)
                        DataRepository.AV001_TI_BIL_TALIMATProvider.DeepLoad(value.AV001_TI_BIL_TALIMATCollection, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TI_BIL_TALIMAT_BORCLU>));
                    MyDataSource = value.AV001_TI_BIL_TALIMATCollection;
                }
            }
        }

        public void BindLookUps(bool newItem)
        {
            if ((!initsFilled && (MyDataSource.Count > 0)) || newItem)
            {
            }
        }

        private void gcIcraTalimatlari_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "YeniKayit")
            {
                frmIcraTalimatlari talimat = new frmIcraTalimatlari();
                talimat.MyFoy = MyFoy;

                //talimat.MdiParent = null;
                talimat.StartPosition = FormStartPosition.WindowsDefaultLocation;
                talimat.Show();
            }
            if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                frmIcraTalimatlari talimat = new frmIcraTalimatlari();
                TList<AV001_TI_BIL_TALIMAT> TalimatList = new TList<AV001_TI_BIL_TALIMAT>();
                TalimatList.Add(MyDataSource[gvIcraTalimatlari.FocusedRowHandle]);
                talimat.MyDataSource = TalimatList;
                talimat.MyFoy = MyFoy;

                //talimat.MdiParent = null;
                talimat.StartPosition = FormStartPosition.WindowsDefaultLocation;
                talimat.Show();
            }
        }

        private void ucIcraTalimatlari_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            if (_MyDataSource != null)
                gcIcraTalimatlari.DataSource = _MyDataSource;
            IsLoaded = true;
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliyeID);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNoID);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorevID);
            BelgeUtil.Inits.perCariGetir(rlueIslemYapanID);
            BelgeUtil.Inits.perSorumluAvukatGetir(rlueSorumluID);
            BelgeUtil.Inits.TalimatIslemGetir(rLueIslemTur);
        }
    }
}