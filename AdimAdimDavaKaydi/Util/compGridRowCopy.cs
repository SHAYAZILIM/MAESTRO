using System;
using System.ComponentModel;
using AvukatProLib2.Entities;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.Util
{
    public partial class compGridRowCopy : Component
    {
        public compGridRowCopy(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private bool KayitKopyala;

        private IEntity SecilenKayit;

        private GridView _myGridView;

        public GridView MyGridView
        {
            get { return _myGridView; }
            set
            {
                if (value != null)
                {
                    value.InitNewRow += value_InitNewRow;
                    _myGridView = value;
                }
            }
        }

        private ExtendedGridControl _myGridControl;

        public ExtendedGridControl MyGridControl
        {
            get { return _myGridControl; }
            set
            {
                if (value != null)
                {
                    value.EmbeddedNavigator.ButtonClick += EmbeddedNavigator_ButtonClick;
                    var button = value.EmbeddedNavigator.Buttons.CustomButtons.Add();
                    button.Enabled = true;
                    button.ImageIndex = 19;
                    button.Hint = "Kayıt Kopyala";
                    button.Visible = true;
                    _myGridControl = value;
                }
            }
        }

        private void EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Hint == "Kayıt Kopyala")
            {
                KayitKopyala = true;

                object secilenObje = MyGridView.GetFocusedRow();

                if (secilenObje != null && secilenObje is IEntity)
                    SecilenKayit = secilenObje as IEntity;

                MyGridView.AddNewRow();
            }
        }

        private void value_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (KayitKopyala && SecilenKayit != null)
            {
                var grid = sender as GridView;

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    try
                    {
                        var column = grid.Columns[i];

                        object degeR = SecilenKayit.GetType().GetProperty(column.FieldName).GetValue(SecilenKayit, null);

                        object yeniKayit = grid.GetRow(e.RowHandle);

                        yeniKayit.GetType().GetProperty(column.FieldName).SetValue(yeniKayit, degeR, null);
                    }
                    catch 
                    {
                    }
                }

                KayitKopyala = false;
            }
        }
    }
}