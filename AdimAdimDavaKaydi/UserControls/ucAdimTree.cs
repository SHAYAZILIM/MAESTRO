using System;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucAdimTree : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucAdimTree()
        {
            InitializeComponent();
        }

        private TreeListColumn col1;

        private class MyData : TreeList.IVirtualTreeListData
        {
            protected MyData parentCore;
            protected ArrayList childrenCore = new ArrayList();
            protected object[] cellsCore;

            public MyData(MyData parent, object[] cells)
            {
                this.parentCore = parent;

                this.cellsCore = cells;
                if (this.parentCore != null)
                {
                    this.parentCore.childrenCore.Add(this);
                }
            }

            void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
            {
                info.Children = childrenCore;
            }

            void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
            {
                info.CellData = cellsCore[info.Column.VisibleIndex];
            }

            public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
            {
                cellsCore[info.Column.VisibleIndex] = info.NewCellData;
            }
        }

        private void initData()
        {
            treeList1.BeginUnboundLoad();

            MyData tlDataSource = new MyData(null, null);

            MyData Adim1 = new MyData(tlDataSource, new[] { "Form Tipi ve Konusu" });
            MyData node1 = new MyData(Adim1, new[] { "Form Tipi" });
            MyData node2 = new MyData(Adim1, new[] { "Form Konusu" });

            MyData Adim2 = new MyData(tlDataSource, new[] { "Dosya Bilgileri" });
            MyData node3 = new MyData(Adim2, new[] { "Dosya No" });
            MyData node4 = new MyData(Adim2, new[] { "Takip Tarihi" });
            MyData node5 = new MyData(Adim2, new[] { "Avukata �ntikal Tarihi" });
            MyData node6 = new MyData(Adim2, new[] { "Dosya Durumu" });

            MyData Adim3 = new MyData(tlDataSource, new[] { "M�d�rl�k Bilgileri" });
            MyData node8 = new MyData(Adim3, new[] { "M�d�rl�k" });
            MyData node9 = new MyData(Adim3, new[] { "Esas No" });
            MyData node10 = new MyData(Adim3, new[] { "Takip Yolu" });

            MyData Adim4 = new MyData(tlDataSource, new[] { "�zel Tan�mlar" });
            MyData node11 = new MyData(Adim4, new[] { "�zel Kod 1" });
            MyData node12 = new MyData(Adim4, new[] { "�zel Kod 2" });
            MyData node13 = new MyData(Adim4, new[] { "�zel Kod 3" });
            MyData node14 = new MyData(Adim4, new[] { "�zel Kod 4" });
            MyData node15 = new MyData(Adim4, new[] { "Referans1" });
            MyData node16 = new MyData(Adim4, new[] { "Referans2" });
            MyData node17 = new MyData(Adim4, new[] { "Referans3" });

            MyData Adim5 = new MyData(tlDataSource, new[] { "Sorumlu Bilgileri" });
            MyData node18 = new MyData(Adim5, new[] { "Sorumlu Avukat" });

            MyData Adim6 = new MyData(tlDataSource, new[] { "Alacakl�lar" });
            MyData node19 = new MyData(Adim6, new[] { "Alacakl� Taraf" });

            MyData Adim7 = new MyData(tlDataSource, new[] { "Alacakl� Vekilleri" });
            MyData node20 = new MyData(Adim7, new[] { "Alacakl� Taraf Vekil" });

            MyData Adim8 = new MyData(tlDataSource, new[] { "Bor�lular" });
            MyData node21 = new MyData(Adim8, new[] { "Bor�lu Taraf" });

            MyData Adim9 = new MyData(tlDataSource, new[] { "Bor�lu Vekilleri" });
            MyData node22 = new MyData(Adim9, new[] { "Bor�lu Taraf Vekil" });

            MyData Adim10 = new MyData(tlDataSource, new[] { "Hesaplanm�� Kalemler" });

            MyData node24 = new MyData(Adim10, new[] { "Hesaplanm�� Tutar" });
            MyData node25 = new MyData(Adim10, new[] { "�zel Kodlar" });

            MyData Adim11 = new MyData(tlDataSource, new[] { "Alacak Nedenleri" });
            MyData node26 = new MyData(Adim11, new[] { "Alacak Neden Giri�i" });
            MyData node27 = new MyData(Adim11, new[] { "Alacak Neden Taraflar�" });
            MyData node28 = new MyData(Adim11, new[] { "Seri Kay�t Giri�i" });

            MyData Adim12 = new MyData(tlDataSource, new[] { "Alacak Neden Ba�lant�lar�" });
            MyData node29 = new MyData(Adim12, new[] { "S�zle�me Bilgileri" });
            MyData node30 = new MyData(Adim12, new[] { "K�ymetli Evrak" });

            MyData Adim13 = new MyData(tlDataSource, new[] { "Takip �ncesi �demeler" });
            MyData node31 = new MyData(Adim13, new[] { "Bor�lu �deme Bilgileri" });

            MyData Adim14 = new MyData(tlDataSource, new[] { "�htiyati Tedbir/Haciz" });
            MyData node32 = new MyData(Adim14, new[] { "De�i�ik �� Bilgileri" });

            MyData Adim15 = new MyData(tlDataSource, new[] { "�lam Bilgileri" });
            MyData node33 = new MyData(Adim15, new[] { "�laml� Alacak" });

            treeList1.DataSource = tlDataSource;

            treeList1.EndUnboundLoad();
        }

        public void NodeVisible(string[] NodeValues)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                for (int i = 0; i < NodeValues.Length; i++)
                {
                    if (NodeValues[i] == var.GetDisplayText(col1))
                    {
                        var.Visible = false;
                    }

                    else if (var.HasChildren)
                    {
                        foreach (TreeListNode child in var.Nodes)
                        {
                            if (NodeValues[i] == child.GetDisplayText(col1))
                            {
                                var.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        public void NodeVisible(string NodeValue)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                if (NodeValue == var.GetDisplayText(col1))
                {
                    var.Visible = false;
                    break;
                }
                else if (var.HasChildren)
                {
                    foreach (TreeListNode child in var.Nodes)
                    {
                        if (NodeValue == child.GetDisplayText(col1))
                        {
                            var.Visible = false;
                            break;
                        }
                    }
                }
            }
        }

        public void NodeVisibleTrue(string[] NodeValues)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                for (int i = 0; i < NodeValues.Length; i++)
                {
                    if (NodeValues[i] == var.GetDisplayText(col1))
                    {
                        var.Visible = true;
                    }

                    else if (var.HasChildren)
                    {
                        foreach (TreeListNode child in var.Nodes)
                        {
                            if (NodeValues[i] == child.GetDisplayText(col1))
                            {
                                var.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        public void NodeVisibleTrue(string NodeValue)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                if (NodeValue == var.GetDisplayText(col1))
                {
                    var.Visible = true;
                    break;
                }
                else if (var.HasChildren)
                {
                    foreach (TreeListNode child in var.Nodes)
                    {
                        if (NodeValue == child.GetDisplayText(col1))
                        {
                            var.Visible = true;
                            break;
                        }
                    }
                }
            }
        }

        public bool NodeChecked(string NodeValue)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                if (NodeValue == var.GetDisplayText(col1))
                {
                    var.ExpandAll();
                    var.Checked = true;
                    treeList1.FocusedNode = treeList1.Nodes[0];
                    // CheckKontrol(treeList1);
                    return true;
                }
                else if (var.HasChildren)
                {
                    foreach (TreeListNode child in var.Nodes)
                    {
                        if (NodeValue == child.GetDisplayText(col1))
                        {
                            child.ExpandAll();
                            child.Checked = true;
                            treeList1.FocusedNode = var;
                            // CheckKontrol(treeList1);
                            return true;
                        }
                    }
                }
            }
            //CheckKontrol(treeList1);
            return false;
        }

        public bool VekilChecked(string NodeValue)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                foreach (TreeListNode child in var.Nodes)
                {
                    if (NodeValue == "Alacakl� Taraf Vekil") //child.GetDisplayText(col1))
                    {
                        treeList1.Nodes[6].Checked = true;
                        child.Checked = true;
                        treeList1.FocusedNode = var;
                        //CheckKontrol(treeList1);
                        return true;
                    }
                }
            }
            //CheckKontrol(treeList1);
            return false;
        }

        public void NodeChecked(string[] NodeValues)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                for (int i = 0; i < NodeValues.Length; i++)
                {
                    if (NodeValues[i] == var.GetDisplayText(col1))
                    {
                        var.ExpandAll();
                        var.Checked = true;
                    }

                    else if (var.HasChildren)
                    {
                        foreach (TreeListNode child in var.Nodes)
                        {
                            if (NodeValues[i] == child.GetDisplayText(col1))
                            {
                                var.ExpandAll();
                                var.Checked = true;
                            }
                        }
                    }
                }
            }
            // CheckKontrol(treeList1);
        }

        public void NodeUnChecked(string[] NodeValues)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                for (int i = 0; i < NodeValues.Length; i++)
                {
                    if (NodeValues[i] == var.GetDisplayText(col1))
                    {
                        var.Checked = false;
                    }

                    else if (var.HasChildren)
                    {
                        foreach (TreeListNode child in var.Nodes)
                        {
                            if (NodeValues[i] == child.GetDisplayText(col1))
                            {
                                var.Checked = false;
                            }
                        }
                    }
                }
            }
            //CheckKontrol(treeList1);
        }

        public void NodeUnChecked(string NodeValue)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                if (NodeValue == var.GetDisplayText(col1))
                {
                    var.Checked = false;
                    break;
                }
                else if (var.HasChildren)
                {
                    foreach (TreeListNode child in var.Nodes)
                    {
                        if (NodeValue == child.GetDisplayText(col1))
                        {
                            child.Checked = false;
                            break;
                        }
                    }
                }
            }
            //CheckKontrol(treeList1);
        }

        public void CheckKontrol(TreeList tList)
        {
            foreach (TreeListNode nd in tList.Nodes)
            {
                if (nd.Nodes.Count > 0)
                {
                    nd.Checked = true;
                    nd.Expanded = false;
                    foreach (TreeListNode cnd in nd.Nodes)
                    {
                        nd.Checked = nd.Checked && cnd.Checked;
                        nd.Expanded = nd.Expanded || cnd.Checked;
                    }
                }
            }
            tList.Refresh();
        }

        public void NodeExpend(string NodeValue)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                if (NodeValue == var.GetDisplayText(col1))
                {
                    var.Expanded = true;
                    break;
                }
            }
        }

        public void NodeUnExpend(string NodeValue)
        {
            foreach (TreeListNode var in treeList1.Nodes)
            {
                if (NodeValue == var.GetDisplayText(col1))
                {
                    var.Expanded = false;
                    break;
                }
            }
        }

        private void AddColumn()
        {
            col1 = new TreeListColumn();
            col1.Caption = "Dosya Kay�t Ad�mlar�";
            col1.VisibleIndex = 0;
            treeList1.Columns.AddRange(new[] { col1 });
        }

        private void TreeListLoad()
        {
            treeList1.OptionsView.ShowCheckBoxes = true;
            //treeList1.Enabled = false;

            AddColumn();

            initData();
        }

        private void ucAdimTree_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                initData();
                TreeListLoad();
            }
        }
    }
}