using System;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util
{
    public partial class compVGridRecordCopy : Component
    {
        public compVGridRecordCopy(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private bool KayitKopyala;
        private object SecilenKayit;

        private VGridControl _myVGridControl;

        [Browsable(false)]
        public VGridControl MyVGridControl
        {
            get { return _myVGridControl; }
            set
            {
                if (value != null)
                    KayitSatiriOlusturur(value);
                _myVGridControl = value;
            }
        }

        private void KayitSatiriOlusturur(VGridControl value)
        {
            RepositoryItemButtonEdit rBtnKopyala = new RepositoryItemButtonEdit();
            EditorRow rowKopyala = new EditorRow();
            rowKopyala.Visible = true;
            rowKopyala.Tag = "H";
            rBtnKopyala.AutoHeight = false;
            rBtnKopyala.Buttons.AddRange(new[]
                                             {
                                                 new DevExpress.XtraEditors.Controls.EditorButton(
                                                     DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph,
                                                     "Bu Kaydı Çoğalt", -1, true, true, false,
                                                     DevExpress.XtraEditors.ImageLocation.MiddleCenter, null)
                                             });
            rBtnKopyala.Name = "repositoryItemButtonEdit1";
            rBtnKopyala.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            rBtnKopyala.ButtonClick += rBtnKopyala_ButtonClick;

            value.InitNewRecord += MyVGridControl_InitNewRecord;

            rowKopyala.Name = "rowKopyala";
            rowKopyala.Properties.RowEdit = rBtnKopyala;
            rowKopyala.Properties.Caption = "Kopyala";
            value.Rows.Add(rowKopyala);
        }

        private void rBtnKopyala_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            KayitKopyala = true;

            SecilenKayit = MyVGridControl.GetRecordObject(MyVGridControl.FocusedRecord);
            MyVGridControl.AddNewRecord();
        }

        private void MyVGridControl_InitNewRecord(object sender, DevExpress.XtraVerticalGrid.Events.RecordIndexEventArgs e)
        {
            if (KayitKopyala && SecilenKayit != null)
            {
                VGridControl vGrid = sender as VGridControl;
                object yeniKayit = vGrid.GetRecordObject(e.RecordIndex);

                vGrid.CloseEditor();

                var vRows = vGrid.Rows;

                KayitlariEkle(yeniKayit, vRows);

                if (yeniKayit is AV001_TI_BIL_ALACAK_NEDEN)
                    (yeniKayit as AV001_TI_BIL_ALACAK_NEDEN).VADE_TARIHI = (SecilenKayit as AV001_TI_BIL_ALACAK_NEDEN).VADE_TARIHI.Value.AddMonths(1);

                if ((SecilenKayit as AV001_TI_BIL_ALACAK_NEDEN).AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.Count > 0)
                    (yeniKayit as AV001_TI_BIL_ALACAK_NEDEN).AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.Add(new AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW() { SOZLESME_ID = (SecilenKayit as AV001_TI_BIL_ALACAK_NEDEN).AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection[0].SOZLESME_ID });

                KayitKopyala = false;
                vGrid.Refresh();
            }
        }

        private void KayitlariEkle(object yeniKayit, VGridRows vRows)
        {
            for (int i = 0; i < vRows.Count; i++)
            {
                try
                {
                    var column = vRows[i];

                    if (column is MultiEditorRow)
                    {
                        MultiEditorRow rows = column as MultiEditorRow;
                        for (int z = 0; z < rows.PropertiesCollection.Count; z++)
                        {
                            string field = rows.PropertiesCollection[z].FieldName;

                            object degeRr = SecilenKayit.GetType().GetProperty(field).GetValue(SecilenKayit, null);

                            yeniKayit.GetType().GetProperty(field).SetValue(yeniKayit, degeRr, null);
                        }
                    }
                    else if (column is EditorRow)
                    {
                        object degeR =
                            SecilenKayit.GetType().GetProperty(column.Properties.FieldName).GetValue(SecilenKayit, null);
                        yeniKayit.GetType().GetProperty(column.Properties.FieldName).SetValue(yeniKayit, degeR, null);
                    }
                    else
                    {
                    }

                    if (column.ChildRows.Count > 0)
                        KayitlariEkle(yeniKayit, column.ChildRows);
                }
                catch 
                {
                }
            }
        }
    }
}