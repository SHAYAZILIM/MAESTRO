using AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge;
using AvukatProLib2.Entities;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AdimAdimDavaKaydi.Editor.UserControls
{
    public partial class ucDosyaAc : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDosyaAc()
        {
            InitializeComponent();
        }

        private static List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> lstRapors;

        private IRecordable _parent;

        private object selectedRecord;

        private RecordInfos selectedrecordInfo;

        [Browsable(false)]
        public ViewColumnFilterInfo[] Filter
        {
            get
            {
                List<ViewColumnFilterInfo> LstFilters = new List<ViewColumnFilterInfo>();
                if (this.gridControl1.MainView is GridView)
                {
                    for (int i = 0; i < ((GridView)this.gridControl1.MainView).ActiveFilter.Count; i++)
                    {
                        LstFilters.Add(((GridView)this.gridControl1.MainView).ActiveFilter[i]);
                    }
                }
                if (this.gridControl1.MainView is CardView)
                {
                    for (int i = 0; i < ((CardView)this.gridControl1.MainView).ActiveFilter.Count; i++)
                    {
                        LstFilters.Add(((CardView)this.gridControl1.MainView).ActiveFilter[i]);
                    }
                }

                return LstFilters.ToArray();
            }
            set
            {
                if (this.gridControl1.MainView is GridView)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        ((GridView)this.gridControl1.MainView).ActiveFilter.Add(value[i]);
                    }
                }

                if (this.gridControl1.MainView is CardView)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        ((CardView)this.gridControl1.MainView).ActiveFilter.Add(value[i]);
                    }
                }
            }
        }

        [Browsable(false)]
        public IRecordable MyParent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        [Browsable(false)]
        public object SelectedRecord
        {
            get { return selectedRecord; }
            set { selectedRecord = value; }
        }

        [Browsable(false)]
        public RecordInfos SelectedrecordInfo
        {
            get { return selectedrecordInfo; }
            set { selectedrecordInfo = value; }
        }

        public void Open(IRecordable parent)
        {
            _parent = parent;
        }

        public void OpenSelected()
        {
            selectedrecordInfo = new RecordInfos();
            selectedrecordInfo.Data = selectedRecord;
            selectedrecordInfo.SelectedFrom = LoadFromType.FromTable;
            selectedrecordInfo.Name = ((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)selectedRecord).AD;
            MyParent.SelectedStreamType = TXTextControl.StreamType.InternalFormat;
            MyParent.OpenRecord(selectedrecordInfo);
        }

        private void cardView1_FocusedRowChanged(object sender,
                                                 DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DetayGoster();
        }

        private void cardView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DetayGoster();
        }

        private void DetayGoster()
        {
            if (DesignMode)
            {
                return;
            }
            TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> lstRapors = new TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>();
            object value = gridView1.GetRow(gridView1.FocusedRowHandle);
            selectedRecord = value;
            if (value is AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)
            {
                lstRapors.Add(AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)value).ID));
            }
            this.ucSablonRaporKaydet1.Datas = lstRapors;
        }

        private void ucDosyaAc_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolum);
            BelgeUtil.Inits.SablonAltKategoriGetir(rLueKategori);
            BelgeUtil.Inits.ModulGetir(rLueModul);
            BelgeUtil.Inits.TakipKonusuGetir(rLueTakipTalepKonu);
            BelgeUtil.Inits.DavaTalepGetir(rLueDavaTalep);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTip);
            BelgeUtil.Inits.DavaNedenGetir(rLueDavaNeden);
            BelgeUtil.Inits.DilKodGetir(rLuedilGetir);
            BelgeUtil.Inits.SektorKodGetir(rLueSektorId);
            BelgeUtil.Inits.FormTipiGetir(rLueFormOrnekNo);

            //TODO : Rapor Tipi için DB bir iliþki atanmamýþ dolayýsýyla RepositoryLookup ý dolduramýyorumbilgine ..
            //rLueRaporTip

            gridView1.SelectionChanged += cardView1_SelectionChanged;
            gridView1.FocusedRowChanged += cardView1_FocusedRowChanged;

            BelgeUtil.Inits._SablonRaporGetir = BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.ToList();
            lstRapors = BelgeUtil.Inits._SablonRaporGetir;

            this.gridControl1.DataSource = lstRapors;
        }
    }
}