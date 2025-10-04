using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Is;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucYapılacakIsAramaGrid : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucYapılacakIsAramaGrid()
        {
            InitializeComponent();
            exGrdYapilacakIs.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            exGrdYapilacakIs.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Name == "Issurec")
            {
                int FoySorumluId = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                DataRowView secilenIs = e.Item.Tag as DataRowView;
                AV001_TDI_BIL_IS isim = DataRepository.AV001_TDI_BIL_ISProvider.GetByID((int)secilenIs["ID"]);
                frmIsSureOlcer SureOlcer = new frmIsSureOlcer();
                //SureOlcer.MdiParent = null;
                SureOlcer.StartPosition = FormStartPosition.WindowsDefaultLocation;
                TList<NN_IS_ICRA_FOY> NNFoy = DataRepository.NN_IS_ICRA_FOYProvider.GetByIS_ID(isim.ID);
                TList<NN_IS_DAVA_FOY> NNDavaFoy = DataRepository.NN_IS_DAVA_FOYProvider.GetByIS_ID(isim.ID);
                TList<NN_IS_SOZLESME> NNSozlesme = DataRepository.NN_IS_SOZLESMEProvider.GetByIS_ID(isim.ID);
                TList<NN_IS_HAZIRLIK> NNSorusturma = DataRepository.NN_IS_HAZIRLIKProvider.GetByIS_ID(isim.ID);
                if (NNFoy.Count > 0)
                {
                    AV001_TI_BIL_FOY icra = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(NNFoy[0].ICRA_FOY_ID);
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icra, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                    FoySorumluId = icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID.Value;
                }
                if (NNDavaFoy.Count > 0)
                {
                    AV001_TD_BIL_FOY dava = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(NNDavaFoy[0].DAVA_FOY_ID);
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(dava, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
                    FoySorumluId = dava.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID.Value;
                }
                if (NNSozlesme.Count > 0)
                {
                    AV001_TDI_BIL_SOZLESME sozlesme =
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(NNSozlesme[0].SOZLESME_ID);
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>
                                                                               ));
                    FoySorumluId = sozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection[0].SORUMLU_CARI_ID.Value;
                }
                if (NNSorusturma.Count > 0)
                {
                    AV001_TD_BIL_HAZIRLIK sorusturma =
                        DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(NNSorusturma[0].HAZIRLIK_ID);
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(sorusturma, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));
                    FoySorumluId = sorusturma.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection[0].CARI_ID.Value;
                }
                SureOlcer.SorumluCariId = FoySorumluId;
                DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(isim, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_IS>));
                TList<AV001_TDIE_BIL_PROJE_IS> myProje =
                    DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.GetByIS_ID(isim.ID);

                if (myProje.Count > 0)
                {
                    myProje[0].PROJE_IDSource = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(myProje[0].PROJE_ID);
                    SureOlcer.projeadi = myProje[0].PROJE_IDSource.ADI;
                    SureOlcer.projeID = myProje[0].PROJE_ID;
                }

                SureOlcer.MyIs = isim;
                SureOlcer.Show();
            }
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            BarSubItem bus = new BarSubItem(e.Manager, "İş Süreci");
            bus.Tag = e.Rows;
            bus.Name = "Issurec";
            e.MyPopupMenu.ItemLinks.Insert(0, bus);
        }

        private DataTable _MyDataSource;

        public DataTable MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                if (value == null)
                    exGrdYapilacakIs.DataSource = value;
                _MyDataSource = value;
                if (!this.DesignMode)
                {
                    exGrdYapilacakIs.DataSource = _MyDataSource;
                }
            }
        }

        private int foyId;

        [Browsable(false)]
        public IEntity SelectedRecord { get; set; }

        [Browsable(false)]
        public int SelectedRecordId { get; set; }

        public event EventHandler<EventArgs> KayitSilindi;

        private void exGrdYapilacakIs_EmbeddedNavigator_ButtonClick(object sender,
                                                                    DevExpress.XtraEditors.NavigatorButtonClickEventArgs
                                                                        e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "YeniKayit")
            {
                #region <cc-20090723>

                AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                frmisKayit.ucIsKayitUfak1.Saved += ucIsKayitUfak1_Saved;
                if (SelectedRecord != null)
                    switch (SelectedRecord.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 1;
                            break;
                        case "AV001_TD_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 2;
                            break;
                        case "AV001_TD_BIL_HAZIRLIK":
                            frmisKayit.ucIsKayitUfak1.ModulID = 3;
                            break;
                        case "AV001_TDI_BIL_SOZLESME":
                            frmisKayit.ucIsKayitUfak1.ModulID = 5;
                            break;
                        default:
                            break;
                    }
                frmisKayit.ucIsKayitUfak1.OpenedRecord = SelectedRecord;
                if (SelectedRecord is AV001_TI_BIL_FOY)
                {
                    if (((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.HasValue)
                    {
                        foyId = ((AV001_TI_BIL_FOY)SelectedRecord).ID;
                        frmisKayit.ucIsKayitUfak1.formTipi = ((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.Value;
                        frmisKayit.ucIsKayitUfak1.Modul = 1;
                    }
                }
                // frmisKayit.MdiParent = null;
                frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmisKayit.FormClosed += frmisKayit_FormClosed;
                frmisKayit.Show();

                #endregion</cc-20090723>
            }
            if (e.Button.Tag.ToString() == "KayitDuzenleme")
            {
                AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                frmisKayit.ucIsKayitUfak1.Saved += ucIsKayitUfak1_Saved;
                if (SelectedRecord != null)
                    switch (SelectedRecord.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 1;
                            break;
                        case "AV001_TD_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 2;
                            break;
                        case "AV001_TD_BIL_HAZIRLIK":
                            frmisKayit.ucIsKayitUfak1.ModulID = 3;
                            break;
                        case "AV001_TDI_BIL_SOZLESME":
                            frmisKayit.ucIsKayitUfak1.ModulID = 5;
                            break;
                        default:
                            break;
                    }

                frmisKayit.ucIsKayitUfak1.OpenedRecord = SelectedRecord;
                //AvukatProLib.Arama.AV001_TDI_BIL_I isara =
                //    gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TDI_BIL_I;

                AV001_TDI_BIL_IS acilacakis = DataRepository.AV001_TDI_BIL_ISProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                frmisKayit.Record = acilacakis;
                if (SelectedRecord is AV001_TI_BIL_FOY)
                {
                    if (((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.HasValue)
                    {
                        foyId = ((AV001_TI_BIL_FOY)SelectedRecord).ID;
                        frmisKayit.ucIsKayitUfak1.formTipi = ((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.Value;
                        frmisKayit.ucIsKayitUfak1.Modul = 1;
                    }
                }
                // frmisKayit.MdiParent = null;
                frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmisKayit.FormClosed += frmisKayit_FormClosed;
                frmisKayit.Show();
            }
            if (e.Button.Tag.ToString() == "KayitSil")
            {
                //AvukatProLib.Arama.AV001_TDI_BIL_I cari =
                //    gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TDI_BIL_I;

                string Foy_no = "";

                if (gridView1.GetFocusedRowCellValue("REFERANS_NO") != null)
                {
                    if (gridView1.GetFocusedRowCellValue("REFERANS_NO") != DBNull.Value)
                        Foy_no = gridView1.GetFocusedRowCellValue("REFERANS_NO").ToString();
                }

                frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_IS", "ID = " + gridView1.GetFocusedRowCellValue("ID"));
                if (kayitSil.ShowDialog() == DialogResult.OK)
                {
                    if (KayitSilindi != null)
                        KayitSilindi(this, new EventArgs());

                    XtraMessageBox.Show(Foy_no + " 'nolu Kayit Silinmiştir");
                }
            }
        }

        private AvukatProLib.Arama.AvpDataContext db =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        private void frmisKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exGrdYapilacakIs.DataSource = db.AV001_TDI_BIL_Is.ToArray();
            MessageBox.Show("Lütfen yeni kayıtların listelenmesi için tekrar sorulama yapın...");
        }

        public delegate void OnSaved(IList Records, IEntity Record);

        public event OnSaved Saved;

        private void ucIsKayitUfak1_Saved(System.Collections.IList Records, IEntity Record)
        {
            if (DesignMode)
            {
                return;
            }

            if (this.Saved != null)
                this.Saved(Records, Record);
            //gcGorev.RefreshDataSource();
        }

        private void ucYapılacakIsAramaGrid_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
                BelgeUtil.Inits.IsSozlesmeGetir(rLueSozlesme);
            }
            gridView1.RowStyle += gridView1_RowStyle;
        }
        private void gridView1_RowStyle(object sender,
DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                var stamp = view.GetRowCellDisplayText(e.RowHandle, view.Columns["STAMP"]);
                bool isRed = false;
                bool.TryParse(stamp, out isRed);
                if (stamp != "1")
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }
        private void exGrdYapilacakIs_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                frmisKayit.ucIsKayitUfak1.Saved += ucIsKayitUfak1_Saved;
                if (SelectedRecord != null)
                    switch (SelectedRecord.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 1;
                            break;
                        case "AV001_TD_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 2;
                            break;
                        case "AV001_TD_BIL_HAZIRLIK":
                            frmisKayit.ucIsKayitUfak1.ModulID = 3;
                            break;
                        case "AV001_TDI_BIL_SOZLESME":
                            frmisKayit.ucIsKayitUfak1.ModulID = 5;
                            break;
                        default:
                            break;
                    }

                frmisKayit.ucIsKayitUfak1.OpenedRecord = SelectedRecord;
                //AvukatProLib.Arama.AV001_TDI_BIL_I isara =
                //    gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TDI_BIL_I;

                AV001_TDI_BIL_IS acilacakis = DataRepository.AV001_TDI_BIL_ISProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                frmisKayit.Record = acilacakis;
                if (SelectedRecord is AV001_TI_BIL_FOY)
                {
                    if (((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.HasValue)
                    {
                        foyId = ((AV001_TI_BIL_FOY)SelectedRecord).ID;
                        frmisKayit.ucIsKayitUfak1.formTipi = ((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.Value;
                        frmisKayit.ucIsKayitUfak1.Modul = 1;
                    }
                }
                // frmisKayit.MdiParent = null;
                frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmisKayit.FormClosed += frmisKayit_FormClosed;
                frmisKayit.Show();
            }
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                var chIsDurum = sender as CheckEdit;
                AV001_TDI_BIL_IS acilacakis = DataRepository.AV001_TDI_BIL_ISProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
                if (chIsDurum.Checked)
                {
                    acilacakis.BITIS_TARIHI = DateTime.Now;
                    acilacakis.HATIRLATILSIN_MI = false;
                    acilacakis.STAMP = 1;
                }
                else if (!chIsDurum.Checked)
                {
                    acilacakis.BITIS_TARIHI = null;
                    acilacakis.HATIRLATILSIN_MI = true;
                    acilacakis.STAMP = 1;
                }
                DataRepository.AV001_TDI_BIL_ISProvider.Save(acilacakis);
            }
        }
    }
}