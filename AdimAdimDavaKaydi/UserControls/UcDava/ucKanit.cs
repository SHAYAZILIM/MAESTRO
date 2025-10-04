using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

//using DevExpress.XtraRichTextEdit.API.Word;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucKanit : AvpXUserControl
    {
        public ucKanit()
        {
            this.Load += ucKanit_Load;
        }

        private TList<AV001_TD_BIL_KANIT> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_KANIT> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (MyDataSource == null) return;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TD_BIL_KANIT>));
                MyDataSource = MyFoy.AV001_TD_BIL_KANITCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                dataNavigatorExtended1.DataSource = MyDataSource;
                gridKanit.DataSource = MyDataSource;
                vgKanit.DataSource = MyDataSource;
            }
        }

        public bool FormDanmi;
        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    if (!FormDanmi)
                        MyDataSource = value.AV001_TD_BIL_KANITCollection;
                }
            }
        }

        private void ucKanit_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            IsLoaded = true;
            gridKanit.ButtonClick += gridKanit_ButtonClick;

            if (MView == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridKanit.Visible = true;
            }
            else if (MView == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridKanit.Visible = false;
            }

            if (!this.DesignMode)
            {
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);
                BelgeUtil.Inits.DavaAdNedenKodGetir(rLueDavaNedenKod);
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.perCariGetir(rlueCari);
                BelgeUtil.Inits.IncelemeTurGetir(rlueIncelemeTur);
                BelgeUtil.Inits.TebligatAlanBaglantiGetir(rlueYakinlikTip);
                BelgeUtil.Inits.KanitTipleriResimliGetir(rLueKanitTipResimli);
                BelgeUtil.Inits.KanitTipGetir(rlueKanitTip);
                BelgeUtil.Inits.CariGetirBilirkisi(rluePersonel);
                if (MyFoy != null)
                {
                    BelgeUtil.Inits.DavaNedenGetir(MyFoy, glueDavaNeden);

                    BelgeUtil.Inits.DavaTumTaraflar(myFoy, new[]
                                                               {
                                                                   rlueDosyaTaraflari
                                                               });
                }
                BindData();
            }
        }

        public static int KanitNo(TList<AV001_TD_BIL_KANIT> list, AV001_TD_BIL_FOY foy)
        {
            int i = 1;

            if (foy.AV001_TD_BIL_KANITCollection.Count > 0)
            {
                foy.AV001_TD_BIL_KANITCollection.Sort("KANIT_NO DESC");

                i = foy.AV001_TD_BIL_KANITCollection[0].KANIT_NO;

                i++;
            }

            if (list.Count > 0)
            {
                list.Sort("KANIT_NO DESC");

                i = list[0].KANIT_NO + 1;
            }

            return i;
        }

        public static string ReferansNo()
        {
            return "KR" + "-" + DateTime.Today.Year + "~" +
                   System.Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
        }

        public static string ListeNo(TList<AV001_TD_BIL_KANIT> list, AV001_TD_BIL_FOY foy, bool numaraDegisti)
        {
            int i = 1;
            List<int> result = new List<int>();

            if (foy.AV001_TD_BIL_KANITCollection.Count > 0)
            {
                foreach (AV001_TD_BIL_KANIT k in foy.AV001_TD_BIL_KANITCollection)
                {
                    if (k.LISTE_NO != string.Empty)
                        result.Add(Convert.ToInt32(k.LISTE_NO.Split('-')[1]));
                }
            }

            else if (list.Count > 0)
            {
                foreach (AV001_TD_BIL_KANIT k in list)
                {
                    if (k.LISTE_NO != string.Empty)
                        result.Add(Convert.ToInt32(k.LISTE_NO.Split('-')[1]));
                }
            }

            if (result.Count > 0)
            {
                result.Sort();

                i = result[result.Count - 1];

                if (!numaraDegisti)
                    i++;
            }

            return "KL" + "-" + i;
        }

        public static string Validate(AV001_TD_BIL_KANIT row)
        {
            StringBuilder sb = new StringBuilder();

            if (row.DAVA_NEDEN_ID == 0)
                sb.AppendLine("* Dava nedeni boþ olamaz.");
            if (row.KANIT_TIP_ID == 0)
                sb.AppendLine("* Kanýt tipi boþ olamaz");
            if (row.LISTE_NO == string.Empty)
                sb.AppendLine("* Liste no boþ olamaz");
            if (row.LISTE_TARIHI == DateTime.MinValue)
                sb.AppendLine("* Liste tarihi boþ olamaz");

            return sb.ToString();
        }

        private void gridKanit_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                frmKanitGirisi frm = new frmKanitGirisi();
                this.MyFoy = MyFoy;
                frm.Show(MyFoy);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TD_BIL_KANITProvider.DeepLoad(MyDataSource[gwKanit.FocusedRowHandle], false,
                                                                   DeepLoadType.IncludeChildren,
                                                                   typeof(TList<AV001_TD_BIL_KANIT>));
                TList<AV001_TD_BIL_KANIT> DvList = new TList<AV001_TD_BIL_KANIT>();
                DvList.Add(MyDataSource[gwKanit.FocusedRowHandle]);
                frmKanitGirisi frm = new frmKanitGirisi();
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
            }
        }

        [Description("Görünümü deðiþtirir.")]
        public ViewType MView { get; set; }

        private void rlueKanitTip_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if ((int)e.NewValue == 15)
                {
                    rowTARIH.Visible = true;
                    rowTARIH.Properties.Caption = "Tanýk Dinleme T";
                    e.NewValue = 15;
                    rowCARI_ID.Visible = true;
                    rowCARI_ID.Properties.Caption = "Tanýk Adý";
                }
                else if ((int)e.NewValue == 20)
                {
                    rowTARIH.Visible = true;
                    rowTARIH.Properties.Caption = "Yemin T";
                    e.NewValue = 20;
                    rowCARI_ID.Visible = true;
                    rowCARI_ID.Properties.Caption = "Yemin Eden";
                }
                else
                {
                    rowTARIH.Visible = false;
                    e.NewValue = e.NewValue;
                    rowCARI_ID.Visible = false;
                }
            }
        }
    }
}