using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TXTextControl;
using Dt = AvukatProLib2.Data.DataRepository;
using Ent = AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Editor.UserControls
{
    public partial class ucRaporBilgi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucRaporBilgi()
        {
            InitializeComponent();
        }

        private Ent.TList<Ent.AV001_TDIE_BIL_BELGE> _myBelgeDataSource;

        private Ent.TList<Ent.AV001_TDIE_BIL_SABLON_DEGISKENLER> _myDegiskenDataSource;

        private Ent.TList<Ent.AV001_TDIE_BIL_SABLON_SECILI_BELGE> _mySeciliBelgeDataSource;

        [Browsable(false)]
        public Ent.TList<Ent.AV001_TDIE_BIL_BELGE> MyBelgeDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (
                    this.c_bndBelge.DataSource is
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>)
                {
                    return
                        (AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>)
                        this.c_bndBelge.DataSource;
                }
                return null;
            }

            set
            {
                if (!DesignMode && value != null &&
                    value is AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>)
                {
                    _myBelgeDataSource = value;
                    this.c_bndBelge.DataSource = value;
                    this.ucBelgeKayitUfak1.Record = (Ent.IEntity)this.aV001_TDIE_BIL_SABLON_RAPORBindingSource.Current;
                    this.ucBelgeKayitUfak1.MyDataSource = value;
                }
            }
        }

        [Browsable(false)]
        public Ent.TList<Ent.AV001_TDIE_BIL_SABLON_RAPOR> MyDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (this.ucSablonRaporKaydet1.Datas is Ent.TList<Ent.AV001_TDIE_BIL_SABLON_RAPOR>)
                {
                    Ent.TList<Ent.AV001_TDIE_BIL_SABLON_RAPOR> rprr = this.ucSablonRaporKaydet1.Datas;
                    return rprr;
                }
                return null;
            }

            set
            {
                if (!DesignMode && value != null)
                {
                    this.ucSablonRaporKaydet1.Datas = value;
                }
            }
        }

        [Browsable(false)]
        public Ent.TList<Ent.AV001_TDIE_BIL_SABLON_DEGISKENLER> MyDegiskenDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (
                    this.aV001_TDIE_BIL_SABLON_DEGISKENLERBindingSource.DataSource is
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_DEGISKENLER>)
                {
                    return
                        (AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_DEGISKENLER>)
                        this.aV001_TDIE_BIL_SABLON_DEGISKENLERBindingSource.DataSource;
                }
                return null;
            }

            set
            {
                if (!DesignMode && value != null &&
                    value is AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_DEGISKENLER>)
                {
                    _myDegiskenDataSource = value;
                    this.aV001_TDIE_BIL_SABLON_DEGISKENLERBindingSource.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        public Ent.TList<Ent.AV001_TDIE_BIL_SABLON_SECILI_BELGE> MySeciliBelgeDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (
                    this.aV001_TDIE_BIL_SABLON_SECILI_BELGECollectionGridControl.DataSource is
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE>)
                {
                    return
                        (AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE>)
                        this.aV001_TDIE_BIL_SABLON_SECILI_BELGECollectionGridControl.DataSource;
                }
                return null;
            }

            set
            {
                if (!DesignMode && value != null &&
                    value is AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE>)
                {
                    _mySeciliBelgeDataSource = value;
                    this.aV001_TDIE_BIL_SABLON_SECILI_BELGECollectionBindingSource.DataSource = value;
                }
            }
        }

        public TextControl Sender { get; set; }

        public void Save()
        {
            if (MyDegiskenDataSource != null)
            {
                if (MyDegiskenDataSource.Count > 0)
                {
                    Dt.AV001_TDIE_BIL_SABLON_DEGISKENLERProvider.Save(MyDegiskenDataSource);
                }
            }

            if (MyBelgeDataSource != null)
            {
                if (MyBelgeDataSource.Count > 0)
                {
                    foreach (var item in MyBelgeDataSource)
                    {
                        if (item.ID == 0)
                            item.STAMP = 0;
                    }
                    Dt.AV001_TDIE_BIL_BELGEProvider.Save(MyBelgeDataSource);
                }
            }
            if (MySeciliBelgeDataSource != null)
            {
                if (MySeciliBelgeDataSource.Count > 0)
                {
                    Dt.AV001_TDIE_BIL_SABLON_SECILI_BELGEProvider.Save(MySeciliBelgeDataSource);
                }
            }

            if (MyDataSource != null)
            {
                MyDataSource.ForEach(item =>
                    {
                        item.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                    });
                Dt.AV001_TDIE_BIL_SABLON_RAPORProvider.DeepSave(MyDataSource);
                XtraMessageBox.Show("Kayýt Ýþlemi Baþarýlý ! ");

                //Þablon kaydýndan yeni sablonun ilgili yere gelmesini saðlamak için eklendi. MB
                BelgeUtil.Inits.DeleteAndCreateFolder(Application.StartupPath + "//CodeData//" + typeof(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR).FullName + ".code");
            }
        }

        private void aV001_TDIE_BIL_SABLON_RAPORBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (this.MySeciliBelgeDataSource != null)
            {
                if (this.MySeciliBelgeDataSource.Count <= 0)
                {
                    Dt.AV001_TDIE_BIL_SABLON_RAPORProvider.DeepLoad(
                        (Ent.AV001_TDIE_BIL_SABLON_RAPOR)this.aV001_TDIE_BIL_SABLON_RAPORBindingSource.Current, false,
                        AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                        typeof(Ent.TList<Ent.AV001_TDIE_BIL_SABLON_SECILI_BELGE>));
                    MySeciliBelgeDataSource =
                        ((Ent.AV001_TDIE_BIL_SABLON_RAPOR)this.aV001_TDIE_BIL_SABLON_RAPORBindingSource.Current).
                            AV001_TDIE_BIL_SABLON_SECILI_BELGECollection;
                }
            }
            else
            {
                ((Ent.AV001_TDIE_BIL_SABLON_RAPOR)this.aV001_TDIE_BIL_SABLON_RAPORBindingSource.Current).
                    AV001_TDIE_BIL_SABLON_SECILI_BELGECollection =
                    new AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE>();
            }
        }

        private void dOSYA_ADRESTextEdit_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogSave = new SaveFileDialog();
            dialogSave.ShowDialog();
            this.Sender.Save(dialogSave.FileName + ".tx", StreamType.InternalFormat);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (MyDegiskenDataSource != null)
            {
                if (MyDegiskenDataSource.Count > 0)
                {
                    this.aV001_TDIE_BIL_SABLON_DEGISKENLERBindingSource.MoveNext();
                }
            }

            if (MyBelgeDataSource != null)
            {
                if (MyBelgeDataSource.Count > 0)
                {
                    this.c_bndBelge.MoveNext();
                }
            }
            if (MySeciliBelgeDataSource != null)
            {
                if (MySeciliBelgeDataSource.Count > 0)
                {
                    this.aV001_TDIE_BIL_SABLON_SECILI_BELGECollectionBindingSource.MoveNext();
                }
            }

            if (MyDataSource != null)
            {
                if (MyDataSource != null && MyDataSource.Count > 0)
                {
                    this.aV001_TDIE_BIL_SABLON_DEGISKENLERBindingSource.MoveNext();
                }
            }
        }
    }
}