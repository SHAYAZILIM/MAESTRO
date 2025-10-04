using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class rFrmTaahhut : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private int BcariId, AcariId;
        private bool isModul;

        private AV001_TI_BIL_FOY myFoy;

        private int SiraNo;

        private TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD> taahhutChild;

        private TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> taahhutList;

        public rFrmTaahhut()
        {
            InitializeComponent();
            InitializeEvents();
            InitData();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl1.Visible = value;
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
                    BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rlueBorcluCari });
                    BelgeUtil.Inits.AlacakliTarafByFoy(MyFoy, new[] { rlueAlacakliCari });
                    TList<AV001_TI_BIL_FOY_TARAF> tB =
                        AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy);
                    TList<AV001_TI_BIL_FOY_TARAF> tA =
                        AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy);
                    if (tB.Count > 0)
                        BcariId = Convert.ToInt32(tB[0].CARI_ID);
                    if (tA.Count > 0)
                        AcariId = Convert.ToInt32(tA[0].CARI_ID);
                    if (TaahhutList == null)
                        TaahhutList = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD> TaahhutChild
        {
            get { return taahhutChild; }
            set
            {
                taahhutChild = value;

                if (value != null)
                {
                    gcChild.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> TaahhutList
        {
            get { return taahhutList; }
            set
            {
                taahhutList = value;
                vgCMaster.DataSource = value;
                //if (value != null)
                //{
                //    SetTaahhut(value);
                //}
            }
        }

        public static short TaahhutChildSiraNo(AV001_TI_BIL_BORCLU_TAAHHUT_MASTER taahhut)
        {
            short i = 1;

            if (taahhut.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.Count == 0)
                DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(taahhut, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList
                                                                                       <
                                                                                       AV001_TI_BIL_BORCLU_TAAHHUT_CHILD
                                                                                       >));

            if (taahhut.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.Count > 0)
            {
                int taahhutChildSiraNo = taahhut.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.Last().SIRA_NO;

                i = (short)++taahhutChildSiraNo;
            }

            return i;
        }

        public static int TaahhutSiraNo(AV001_TI_BIL_FOY foy)
        {
            int i = 1;

            if (foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));

            if (foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Count > 0)
            {
                int taahhutSiraNo = foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Last().TAAHHUT_SIRA_NO;

                i = ++taahhutSiraNo;
            }

            return i;
        }

        public bool Save()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                if (MyFoy != null)
                {
                    foreach (var item in TaahhutList)
                    {
                        item.ICRA_FOY_ID = MyFoy.ID;

                        if (item.ID == 0)
                        {
                            MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Clear();
                            MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Add(item);
                        }
                    }

                    tran.BeginTransaction();
                    //DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepSave(tran,
                    //                                                                   MyFoy.
                    //                                                                       AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection,
                    //                                                                   DeepSaveType.IncludeChildren,
                    //                                                                   typeof(
                    //                                                                       TList
                    //                                                                       <
                    //                                                                       AV001_TI_BIL_BORCLU_TAAHHUT_CHILD
                    //                                                                       >));

                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepSave(tran, taahhutList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));

                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDProvider.DeepSave(tran, (TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>)gcChild.DataSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));

                    tran.Commit();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return false;
            }
        }

        public void Show(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> taahhutMaster)
        {
            this.TaahhutList = taahhutMaster;
            this.Show();
        }

        public void ShowDialog(AV001_TI_BIL_FOY foy)
        {
            DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(
                foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection, false, DeepLoadType.IncludeChildren,
                typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));

            MyFoy = foy;

            TaahhutList = foy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        public void SiraNoKontrol()
        {
            if (MyFoy != null)
            {
                TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> Taahhut = MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection;
                foreach (AV001_TI_BIL_BORCLU_TAAHHUT_MASTER var in Taahhut)
                {
                    SiraNo = var.TAAHHUT_SIRA_NO;
                }
                SiraNo++;
            }
        }

        private void childList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_BORCLU_TAAHHUT_CHILD tchild = new AV001_TI_BIL_BORCLU_TAAHHUT_CHILD();
            tchild.ODEME_MIKTARI_DOVIZ_ID = (int)DovizTip.TL;
            tchild.TAAHHUT_MIKTARI_DOVIZ_ID = (int)DovizTip.TL;

            tchild.SIRA_NO = TaahhutChildSiraNo(TaahhutList[vgCMaster.FocusedRecord]);
            e.NewObject = tchild;
            tchild.ColumnChanging += tchild_ColumnChanging;
        }

        private void dnTaahhutChild_OnCevirClick(object sender, EventArgs e)
        {
            if (vgCChild.Visible)
            {
                vgCChild.Visible = false;
                gcChild.Visible = true;
                vgCChild.BringToFront();
            }
            else
            {
                gcChild.Visible = false;
                vgCChild.Visible = true;
                gcChild.BringToFront();
            }
        }

        private void dnTaahhutMaster_OnCevirClick(object sender, EventArgs e)
        {
            if (vgCMaster.Visible)
            {
                vgCMaster.Visible = false;
                gcMaster.Visible = true;
                vgCMaster.BringToFront();
            }
            else
            {
                gcMaster.Visible = false;
                vgCMaster.Visible = true;
                gcMaster.BringToFront();
            }
        }

        private void glueDosya_EditValueChanged(object sender, EventArgs e)
        {
            MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)glueDosya.EditValue);
            TaahhutList = MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection;
        }

        private void InitData()
        {
            BelgeUtil.Inits.ParaBicimiAyarla(tutar);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.TaahhutDurumGetir(rlueDurum);
            BelgeUtil.Inits.TaahhutTipGetir(rlueTahhutTip);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmTaahhut_Button_Kaydet_Click;

            //this.Button_AdimAdimEditore_Click += rFrmTaahhut_Button_AdimAdimEditore_Click;//Taahhüt sihirbazı takip ekranında üst menüye alındı.Merve
        }

        private void list_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (MyFoy == null)
                MessageBox.Show("Lütfen bir dosya seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                AV001_TI_BIL_BORCLU_TAAHHUT_MASTER TMaster = new AV001_TI_BIL_BORCLU_TAAHHUT_MASTER();
                TMaster.TAAHHUT_EDEN_ID = BcariId;
                TMaster.TAAHHUDU_KABUL_EDEN_ID = AcariId;
                TMaster.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                TMaster.KAYIT_TARIHI = DateTime.Now;
                TMaster.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                TMaster.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                TMaster.KONTROL_NE_ZAMAN = DateTime.Now;
                TMaster.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                TMaster.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                TMaster.TAAHHUT_SIRA_NO = TaahhutSiraNo(MyFoy);

                TMaster.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.AddingNew += childList_AddingNew;
                dnTaahhutChild.DataSource = TMaster.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection;
                vgCChild.DataSource = dnTaahhutChild.DataSource;
                gcChild.DataSource = dnTaahhutChild.DataSource;

                e.NewObject = TMaster;
            }
        }

        private void rFrmTaahhut_Button_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    MessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "Kayıt", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Kayıt sırasında bir sorunla karşılaşıldı.", "İptal", MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void rFrmTaahhut_Load(object sender, EventArgs e)
        {
            if (isModul)
            {
                glueDosya.Enter += delegate { glueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Icra"); };
                glueDosya.Properties.DisplayMember = "FOY_NO";
                glueDosya.Properties.ValueMember = "ID";
                glueDosya.Properties.NullText = "Dosya Seçiniz...";
            }
            else
                glueDosya.Visible = false;

            TaahhutList.AddingNew +=new AddingNewEventHandler(list_AddingNew);
            
        }

        private void tchild_ColumnChanging(object sender, AV001_TI_BIL_BORCLU_TAAHHUT_CHILDEventArgs e)
        {
            AV001_TI_BIL_BORCLU_TAAHHUT_CHILD child = sender as AV001_TI_BIL_BORCLU_TAAHHUT_CHILD;
            if (e.Column == AV001_TI_BIL_BORCLU_TAAHHUT_CHILDColumn.ODEME_MIKTARI)
            {
                ParaVeDovizId kal =
                    ParaVeDovizId.Cikart(new ParaVeDovizId(child.TAAHHUT_MIKTARI, child.TAAHHUT_MIKTARI_DOVIZ_ID),
                                         new ParaVeDovizId((decimal)e.Value, child.ODEME_MIKTARI_DOVIZ_ID));
                child.TAAHHUTTEN_KALAN_MIKTAR = kal.Para;
                child.TAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID = kal.DovizId;
            }
        }

        private void vGridControl1_FocusedRecordChanged(object sender,
                                                        DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            int childIndex = vgCMaster.FocusedRecord;

            AV001_TI_BIL_BORCLU_TAAHHUT_MASTER obj =
                (AV001_TI_BIL_BORCLU_TAAHHUT_MASTER)vgCMaster.GetRecordObject(vgCMaster.FocusedRecord);

            if (taahhutList != null && TaahhutList.Count > 0)
            {
                if (obj != null)
                {
                    vgCChild.DataSource = obj.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection;
                    gcChild.DataSource = vgCChild.DataSource;
                }
            }
        }
    }
}