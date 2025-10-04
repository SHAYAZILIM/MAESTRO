using System;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AdimAdimDavaKaydi.IcraTakipForms;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.IcraTakip
{
    public partial class ucFoy : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public AvukatProLib2.Entities.AV001_TI_BIL_FOY MyDataSource
        {
            set
            {
                if (value != null)
                {
                    TList<AV001_TI_BIL_FOY> foyCix = new TList<AV001_TI_BIL_FOY>();
                    foyCix.Add(value);
                    vgFoy.DataSource = foyCix;
                }
            }
            get
            {
                if (vgFoy.DataSource is TList<AV001_TI_BIL_FOY>)
                {
                    TList<AV001_TI_BIL_FOY> foyCix = (TList<AV001_TI_BIL_FOY>)vgFoy.DataSource;
                    if (foyCix.Count > 0)
                        return foyCix[0];
                    foyCix[0].ColumnChanged += ucFoy_ColumnChanged;
                }
                return null;
            }
        }

        private void ucFoy_ColumnChanged(object sender, AV001_TI_BIL_FOYEventArgs e)
        {
        }

        public ucFoy()
        {
            InitializeComponent();
        }

        private void RepositoryTxtEdits()
        {
            //DevXHelp.AddRepositoryItemTextEdit_VerticalGrid(vgFoy, 0, "rHspFTxtEdit", "n");
            //DevXHelp.AddRepositoryItemTextEdit_VerticalGrid(vgFoy, 1, "rHspKKDFTxtEdit", "n");
            //DevXHelp.AddRepositoryItemTextEdit_VerticalGrid(vgFoy, 2, "rHspBSMVTxtEdit", "n");
            //DevXHelp.AddRepositoryItemTextEdit_VerticalGrid(vgFoy, 3, "rHspKDVTxtEdit", "n");
            //DevXHelp.AddRepositoryItemTextEdit_VerticalGrid(vgFoy, 4, "rHspOIVTxtEdit", "n");

            //DevXHelp.AddRepositoryItemTextEditMultiRow_VerticalGrid(vgFoy, 5, 1, "rOzelTutar1TxtEdit", "n");
            //DevXHelp.AddRepositoryItemTextEditMultiRow_VerticalGrid(vgFoy, 6, 1, "rOranTxt1", "P");
            //DevXHelp.AddRepositoryItemTextEditMultiRow_VerticalGrid(vgFoy, 7, 1, "rOzelTutar2TxtEdit", "n");
            //DevXHelp.AddRepositoryItemTextEditMultiRow_VerticalGrid(vgFoy, 8, 1, "rOranTxt2", "P");
            //DevXHelp.AddRepositoryItemTextEditMultiRow_VerticalGrid(vgFoy, 9, 1, "rOzelTutar3TxtEdit", "n");
            //DevXHelp.AddRepositoryItemTextEditMultiRow_VerticalGrid(vgFoy, 10, 1, "rOranTxt3", "P");
        }

        private void inits()
        {
            BelgeUtil.Inits.OzelTutarkonuGetir(rlkOzelTutarKonu);
            BelgeUtil.Inits.DovizTipGetir(rlkDoviz);
            BelgeUtil.Inits.ParaBicimiAyarla(rudPara);
            BelgeUtil.Inits.YuzdeBicimiAyarla(rudOran);
            BelgeUtil.Inits.FaizTipiGetir(rLueFaizTip);
        }

        private void ucFoy_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                //VerticalGrid ilk acilis

                RepositoryTxtEdits();
                inits();
            }

            if (rlkOzelTutarKonu.Buttons.Count == 1)
            {
                EditorButton eb = new EditorButton();
                eb.Kind = ButtonPredefines.Plus;
                eb.Tag = "mEkle";
                rlkOzelTutarKonu.Buttons.Add(eb);
            }
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp != null)
                if (e.SenderLookUp.Properties.Name.Contains("OzelTutar") && e.IsTypedValue)
                {
                    try
                    {
                        TDI_KOD_OZEL_TUTAR_KONU ozel = new TDI_KOD_OZEL_TUTAR_KONU();
                        //ozel.SUBE_KODU = "GENEL";
                        ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                        ozel.SUBE_KODU = 0;
                        ozel.KONTROL_KIM = "AVUKATPRO";
                        ozel.STAMP = 1;
                        ozel.KONTROL_VERSIYON = 1;
                        ozel.KONU = e.TypedValue;
                        DataRepository.TDI_KOD_OZEL_TUTAR_KONUProvider.Save(ozel);
                        ((TList<TDI_KOD_OZEL_TUTAR_KONU>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        //((TList<TDI_KOD_OZEL_TUTAR_KONU>)e.SenderLookUp.EditValue).Add(ozel);
                        XtraMessageBox.Show("Özel Tutar Konusu Baþarýyla Eklenmiþtir.");
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
        }

        private void rlkOzelTutarKonu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //c_lueKategori
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "mEkle")
            {
                frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.OzelTutarKonu, -1);
                frmalt.ShowDialog();

                //for (int i = 0; i < rlkOzelTutarKonu.Properties.Buttons.Count; i++)
                //{
                //    if (rlkOzelTutarKonu.Properties.Buttons[i].Tag != null)
                //    {
                //        if (rlkOzelTutarKonu.Properties.Buttons[i].Tag.ToString() == "mEkle")
                //        {
                //            rlkOzelTutarKonu.Properties.Buttons.RemoveAt(i);
                //            i = 0;
                //        }
                //    }
                //}

                BelgeUtil.Inits.OzelTutarkonuGetir(rlkOzelTutarKonu);
            }
        }
    }
}