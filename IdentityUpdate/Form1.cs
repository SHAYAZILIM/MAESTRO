using ADODB;
using MSDASC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IdentityUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private dbDataContext db;
        private string strConnectionString;

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            IsSelect(lkEditTable.Text, false, null);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            IsSelect(lkEditTable.Text, true, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridControl1.DataSource != null)
                {
                    string tableName = "";

                    #region TA_KOD_ISLETIM_SIRASI

                    if (gridControl1.DataSource is List<TA_KOD_ISLETIM_SIRASI>)
                    {
                        tableName = "TA_KOD_ISLETIM_SIRASI";

                        //---
                        var maxSayi = from c in db.TA_KOD_ISLETIM_SIRASI orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TA_KOD_ISLETIM_SIRASI>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TA_KOD_ISLETIM_SIRASI>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "TABLO_ADI,  " +
                                    "ISLETIM_SIRASI,  " +
                                    "RES_KODU,  " +
                                    "YEDEGI_ALINACAK,  " +
                                    "SIRKET_DATASI)" +
                                    " VALUES ({1},'{2}',{3},{4},{5},{6})",
                                    tableName,
                                    sayim,
                                    ls.TABLO_ADI.Replace('\'', '?'),
                                    ls.ISLETIM_SIRASI,
                                    ls.RES_KODU,
                                    ls.YEDEGI_ALINACAK,
                                    ls.SIRKET_DATASI);

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TA_KOD_ISLETIM_SIRASI.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TA_KOD_ISLETIM_SIRASI,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TA_KOD_ISLETIM_SIRASI

                    #region TD_KOD_DAVA_TALEP

                    if (gridControl1.DataSource is List<TD_KOD_DAVA_TALEP>)
                    {
                        tableName = "TD_KOD_DAVA_TALEP";

                        //---
                        var maxSayi = from c in db.TD_KOD_DAVA_TALEP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TD_KOD_DAVA_TALEP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TD_KOD_DAVA_TALEP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ADLI_BIRIM_BOLUM_ID,  " +
                                    "ADLI_BIRIM_BOLUM_KOD,  " +
                                    "DAVA_TALEP,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},'{7}','{8}',{9},{10},{11},{12})",
                                    tableName,
                                    sayim,
                                    ls.ADLI_BIRIM_BOLUM_ID,
                                    ls.ADLI_BIRIM_BOLUM_KOD.Replace('\'', '?'),
                                    ls.DAVA_TALEP.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TD_KOD_DAVA_TALEP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TD_KOD_DAVA_TALEP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TD_KOD_DAVA_TALEP

                    #region TD_KOD_HAZIRLIK_DURUM

                    if (gridControl1.DataSource is List<TD_KOD_HAZIRLIK_DURUM>)
                    {
                        tableName = "TD_KOD_HAZIRLIK_DURUM";

                        //---
                        var maxSayi = from c in db.TD_KOD_HAZIRLIK_DURUM orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TD_KOD_HAZIRLIK_DURUM>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TD_KOD_HAZIRLIK_DURUM>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "DURUM,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.DURUM.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TD_KOD_HAZIRLIK_DURUM.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TD_KOD_HAZIRLIK_DURUM,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TD_KOD_HAZIRLIK_DURUM

                    #region TDI_KOD_ARAC_TIP

                    if (gridControl1.DataSource is List<TDI_KOD_ARAC_TIP>)
                    {
                        tableName = "TDI_KOD_ARAC_TIP";

                        //---
                        var maxSayi = from c in db.TDI_KOD_ARAC_TIP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ARAC_TIP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ARAC_TIP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "TIP,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "GEMI_UCAK_ARAC_TIP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10},{11})",
                                    tableName,
                                    sayim,
                                    ls.TIP.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.GEMI_UCAK_ARAC_TIP == null ? "null" : ls.GEMI_UCAK_ARAC_TIP.ToString()),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_ARAC_TIP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_ARAC_TIP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_ARAC_TIP

                    #region TDI_KOD_BANKA

                    if (gridControl1.DataSource is List<TDI_KOD_BANKA>)
                    {
                        tableName = "TDI_KOD_BANKA";

                        //---
                        var maxSayi = from c in db.TDI_KOD_BANKA orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "BANKA,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "TIP_ID,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10},{11})",
                                    tableName,
                                    sayim,
                                    ls.BANKA.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    ls.TIP_ID,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_BANKA.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_BANKA,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_BANKA

                    #region TDI_KOD_BANKA_BOLGE

                    if (gridControl1.DataSource is List<TDI_KOD_BANKA_BOLGE>)
                    {
                        tableName = "TDI_KOD_BANKA_BOLGE";

                        //---
                        var maxSayi = from c in db.TDI_KOD_BANKA_BOLGE orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_BOLGE>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_BOLGE>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "BOLGE,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.BOLGE.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_BANKA_BOLGE.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_BANKA_BOLGE,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_BANKA_BOLGE

                    #region TDI_KOD_BANKA_KART_TIP

                    if (gridControl1.DataSource is List<TDI_KOD_BANKA_KART_TIP>)
                    {
                        tableName = "TDI_KOD_BANKA_KART_TIP";

                        //---
                        var maxSayi = from c in db.TDI_KOD_BANKA_KART_TIP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_KART_TIP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_KART_TIP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "KART_TIPI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.KART_TIPI.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_BANKA_KART_TIP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_BANKA_KART_TIP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_BANKA_KART_TIP

                    #region TDI_KOD_BANKA_SUBE

                    if (gridControl1.DataSource is List<TDI_KOD_BANKA_SUBE>)
                    {
                        tableName = "TDI_KOD_BANKA_SUBE";

                        //---
                        var maxSayi = from c in db.TDI_KOD_BANKA_SUBE orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_SUBE>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_SUBE>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "BANKA_ID,  " +
                                    "BANKA,  " +
                                    "BOLGE_ID,  " +
                                    "BOLGE,  " +
                                    "KODU,  " +
                                    "SUBE,  " +
                                    "ACIKLAMA,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "IL,  " +
                                    "ILCE,  " +
                                    "TELEFON,  " +
                                    "FAX,  " +
                                    "ADRES,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}',{4},'{5}','{6}','{7}','{8}',{9},{10},'{11}','{12}',{13},{14},'{15}','{16}','{17}','{18}','{19}',{20},{21})",
                                    tableName,
                                    sayim,
                                    ls.BANKA_ID,
                                    ls.BANKA.Replace('\'', '?'),
                                    (ls.BOLGE_ID == null ? "null" : ls.BOLGE_ID.ToString()),
                                    ls.BOLGE.Replace('\'', '?'),
                                    ls.KODU,
                                    ls.SUBE.Replace('\'', '?'),
                                    ls.ACIKLAMA.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    ls.IL,
                                    ls.ILCE,
                                    ls.TELEFON,
                                    ls.FAX,
                                    ls.ADRES,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_BANKA_SUBE.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_BANKA_SUBE,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_BANKA_SUBE

                    #region TDI_KOD_DAVA_ADI

                    if (gridControl1.DataSource is List<TDI_KOD_DAVA_ADI>)
                    {
                        tableName = "TDI_KOD_DAVA_ADI";

                        //---
                        var maxSayi = from c in db.TDI_KOD_DAVA_ADI orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_DAVA_ADI>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_DAVA_ADI>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ADLI_BIRIM_BOLUM_ID,  " +
                                    "ADLI_BIRIM_BOLUM_KOD,  " +
                                    "GOREVLI_MAHKEME_ID,  " +
                                    "GOREVLI_MAHKEME,  " +
                                    "DAVA_ADI,  " +
                                    "HARC_HESAPLANSIN_MI,  " +
                                    "HARC_TIPI,  " +
                                    "NISPI_HARC_KOD_ID,  " +
                                    "NISPI_HARC_ADI,  " +
                                    "SABIT_KALEM_MI,  " +
                                    "ADLI_TATILDEN_ETKILENIR_MI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "DAVA_ANA_KOD_ID,  " +
                                    "DAVA_ANA_KOD,  " +
                                    "DAVA_OZEL_KOD1_ID,  " +
                                    "DAVA_OZEL_KOD1,  " +
                                    "DAVA_OZEL_KOD2_ID,  " +
                                    "DAVA_OZEL_KOD2,  " +
                                    "DAVA_OZEL_KOD3_ID,  " +
                                    "DAVA_OZEL_KOD3,  " +
                                    "DAVA_OZEL_KOD4_ID,  " +
                                    "DAVA_OZEL_KOD4,  " +
                                    "DAVA_OZEL_KOD5_ID,  " +
                                    "DAVA_OZEL_KOD5,  " +
                                    "DAVA_OZEL_KOD6_ID,  " +
                                    "DAVA_OZEL_KOD6,  " +
                                    "DAVA_OZEL_KOD7_ID,  " +
                                    "DAVA_OZEL_KOD7,  " +
                                    "DAVA_OZEL_KOD8_ID,  " +
                                    "DAVA_OZEL_KOD8,  " +
                                    "DAVA_OZEL_KOD9_ID,  " +
                                    "DAVA_OZEL_KOD9,  " +
                                    "DAVA_OZEL_KOD10_ID,  " +
                                    "DAVA_OZEL_KOD10,  " +
                                    "REFERANS_NO,  " +
                                    "DAVA_EK_ACIKLAMA,  " +
                                    "DAVA_NOTLARI,  " +
                                    "ZAMAN_ASIMI_SURE_GUN,  " +
                                    "ZAMAN_ASIMI_SURE_AY,  " +
                                    "ZAMAN_ASIMI_SURE_YIL,  " +
                                    "HAK_DUSUMU_SURE_GUN,  " +
                                    "HAK_DUSUMU_SURE_AY,  " +
                                    "HAK_DUSUMU_SURE_YIL,  " +
                                    "DAVA_ALT_KOD_ID,  " +
                                    "DAVA_ALT_KOD,  " +
                                    "YUKSEK_MAHKEME_ID,  " +
                                    "YUKSEK_MAHKEME,  " +
                                    "YUKSEK_MAHKEME_DAIRE_NO_ID,  " +
                                    "YUKSEK_MAHKEME_DAIRE_NO,  " +
                                    "YUKSEK_MAHKEME_GOREV_ID,  " +
                                    "YUKSEK_MAHKEME_GOREV,  " +
                                    "ZAMAN_ASIMI_VAR_MI,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}',{4},'{5}','{6}',{7},{8},{9},'{10}',{11},{12},{13},{14},'{15}','{16}',{17},{18},{19},'{20}',{21},'{22}',{23},'{24}',{25},'{26}',{27},'{28}',{29},'{30}',{31},'{32}',{33},'{34}',{35},'{36}',{37},'{38}',{39},'{40}','{41}','{42}','{43}',{44},{45},{46},{47},{48},{49},{50},'{51}',{52},'{53}',{54},'{55}',{56},'{57}',{58},{59},{60})",
                                    tableName,
                                    sayim,
                                    ls.ADLI_BIRIM_BOLUM_ID,
                                    ls.ADLI_BIRIM_BOLUM_KOD.Replace('\'', '?'),
                                    ls.GOREVLI_MAHKEME_ID,
                                    ls.GOREVLI_MAHKEME.Replace('\'', '?'),
                                    ls.DAVA_ADI.Replace('\'', '?'),
                                    (ls.HARC_HESAPLANSIN_MI == true ? 1 : 0),
                                    ls.HARC_TIPI,
                                    (ls.NISPI_HARC_KOD_ID == null ? "null" : ls.NISPI_HARC_KOD_ID.ToString()),
                                    ls.NISPI_HARC_ADI.Replace('\'', '?'),
                                    (ls.SABIT_KALEM_MI == true ? 1 : 0),
                                    (ls.ADLI_TATILDEN_ETKILENIR_MI == true ? 1 : 0),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.DAVA_ANA_KOD_ID == null ? "null" : ls.DAVA_ANA_KOD_ID.ToString()),
                                    ls.DAVA_ANA_KOD.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD1_ID == null ? "null" : ls.DAVA_OZEL_KOD1_ID.ToString()),
                                    ls.DAVA_OZEL_KOD1.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD2_ID == null ? "null" : ls.DAVA_OZEL_KOD2_ID.ToString()),
                                    ls.DAVA_OZEL_KOD2.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD3_ID == null ? "null" : ls.DAVA_OZEL_KOD3_ID.ToString()),
                                    ls.DAVA_OZEL_KOD3.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD4_ID == null ? "null" : ls.DAVA_OZEL_KOD4_ID.ToString()),
                                    ls.DAVA_OZEL_KOD4.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD5_ID == null ? "null" : ls.DAVA_OZEL_KOD5_ID.ToString()),
                                    ls.DAVA_OZEL_KOD5.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD6_ID == null ? "null" : ls.DAVA_OZEL_KOD6_ID.ToString()),
                                    ls.DAVA_OZEL_KOD6.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD7_ID == null ? "null" : ls.DAVA_OZEL_KOD7_ID.ToString()),
                                    ls.DAVA_OZEL_KOD7.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD8_ID == null ? "null" : ls.DAVA_OZEL_KOD8_ID.ToString()),
                                    ls.DAVA_OZEL_KOD8.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD9_ID == null ? "null" : ls.DAVA_OZEL_KOD9_ID.ToString()),
                                    ls.DAVA_OZEL_KOD9.Replace('\'', '?'),
                                    (ls.DAVA_OZEL_KOD10_ID == null ? "null" : ls.DAVA_OZEL_KOD10_ID.ToString()),
                                    ls.DAVA_OZEL_KOD10.Replace('\'', '?'),
                                    ls.REFERANS_NO.Replace('\'', '?'),
                                    ls.DAVA_EK_ACIKLAMA.Replace('\'', '?'),
                                    ls.DAVA_NOTLARI.Replace('\'', '?'),
                                    ls.ZAMAN_ASIMI_SURE_GUN,
                                    ls.ZAMAN_ASIMI_SURE_AY,
                                    ls.ZAMAN_ASIMI_SURE_YIL,
                                    ls.HAK_DUSUMU_SURE_GUN,
                                    ls.HAK_DUSUMU_SURE_AY,
                                    ls.HAK_DUSUMU_SURE_YIL,
                                    (ls.DAVA_ALT_KOD_ID == null ? "null" : ls.DAVA_ALT_KOD_ID.ToString()),
                                    ls.DAVA_ALT_KOD.Replace('\'', '?'),
                                    (ls.YUKSEK_MAHKEME_ID == null ? "null" : ls.YUKSEK_MAHKEME_ID.ToString()),
                                    ls.YUKSEK_MAHKEME.Replace('\'', '?'),
                                    (ls.YUKSEK_MAHKEME_DAIRE_NO_ID == null ? "null" : ls.YUKSEK_MAHKEME_DAIRE_NO_ID.ToString()),
                                    ls.YUKSEK_MAHKEME_DAIRE_NO.Replace('\'', '?'),
                                    (ls.YUKSEK_MAHKEME_GOREV_ID == null ? "null" : ls.YUKSEK_MAHKEME_GOREV_ID.ToString()),
                                    ls.YUKSEK_MAHKEME_GOREV.Replace('\'', '?'),
                                    (ls.ZAMAN_ASIMI_VAR_MI == true ? 1 : 0),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_DAVA_ADI.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_DAVA_ADI,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_DAVA_ADI

                    #region TDI_KOD_FAIZ_TIP

                    if (gridControl1.DataSource is List<TDI_KOD_FAIZ_TIP>)
                    {
                        tableName = "TDI_KOD_FAIZ_TIP";

                        //---
                        var maxSayi = from c in db.TDI_KOD_FAIZ_TIP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FAIZ_TIP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FAIZ_TIP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "FAIZ_TIP,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "UYAP_KOD,  " +
                                    "UYAP_ACIKLAMA,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},'{9}','{10}',{11},{12})",
                                    tableName,
                                    sayim,
                                    ls.FAIZ_TIP.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    ls.UYAP_KOD.Replace('\'', '?'),
                                    ls.UYAP_ACIKLAMA.Replace('\'', '?'),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_FAIZ_TIP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_FAIZ_TIP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_FAIZ_TIP

                    #region TDI_KOD_FIRMA_TUR

                    if (gridControl1.DataSource is List<TDI_KOD_FIRMA_TUR>)
                    {
                        tableName = "TDI_KOD_FIRMA_TUR";

                        //---
                        var maxSayi = from c in db.TDI_KOD_FIRMA_TUR orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FIRMA_TUR>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FIRMA_TUR>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "TUR,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.TUR.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_FIRMA_TUR.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_FIRMA_TUR,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_FIRMA_TUR

                    #region TDI_KOD_FORM_LISTESI

                    if (gridControl1.DataSource is List<TDI_KOD_FORM_LISTESI>)
                    {
                        tableName = "TDI_KOD_FORM_LISTESI";

                        //---
                        var maxSayi = from c in db.TDI_KOD_FORM_LISTESI orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FORM_LISTESI>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FORM_LISTESI>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "VB_ADI,  " +
                                    "FORM_ACIKLAMA,  " +
                                    "TREE_ACIKLAMA,  " +
                                    "MENU_NESNE_ADI,  " +
                                    "SUZME_KRITER,  " +
                                    "FORM_KOD,  " +
                                    "DB_TABLO_ADI,  " +
                                    "BUTTON_GORUNUM_LIST,  " +
                                    "MODUL,  " +
                                    "MODUL2,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}',{10},{11},{12},{13},'{14}','{15}',{16},{17},{18},{19})",
                                    tableName,
                                    sayim,
                                    ls.VB_ADI.Replace('\'', '?'),
                                    ls.FORM_ACIKLAMA.Replace('\'', '?'),
                                    ls.TREE_ACIKLAMA.Replace('\'', '?'),
                                    ls.MENU_NESNE_ADI.Replace('\'', '?'),
                                    ls.SUZME_KRITER.Replace('\'', '?'),
                                    (ls.FORM_KOD == null ? "null" : ls.FORM_KOD.ToString()),
                                    ls.DB_TABLO_ADI.Replace('\'', '?'),
                                    ls.BUTTON_GORUNUM_LIST.Replace('\'', '?'),
                                    ls.MODUL,
                                    ls.MODUL2,
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_FORM_LISTESI.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_FORM_LISTESI,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_FORM_LISTESI

                    #region TDI_KOD_FOY_BIRIM

                    if (gridControl1.DataSource is List<TDI_KOD_FOY_BIRIM>)
                    {
                        tableName = "TDI_KOD_FOY_BIRIM";

                        //---
                        var maxSayi = from c in db.TDI_KOD_FOY_BIRIM orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_BIRIM>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_BIRIM>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "FOY_BIRIM,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.FOY_BIRIM.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_FOY_BIRIM.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_FOY_BIRIM,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_FOY_BIRIM

                    #region TDI_KOD_FOY_DURUM

                    if (gridControl1.DataSource is List<TDI_KOD_FOY_DURUM>)
                    {
                        tableName = "TDI_KOD_FOY_DURUM";

                        //---
                        var maxSayi = from c in db.TDI_KOD_FOY_DURUM orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_DURUM>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_DURUM>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "DURUM,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.DURUM.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_FOY_DURUM.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_FOY_DURUM,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_FOY_DURUM

                    #region TDI_KOD_FOY_OZEL_DURUM

                    if (gridControl1.DataSource is List<TDI_KOD_FOY_OZEL_DURUM>)
                    {
                        tableName = "TDI_KOD_FOY_OZEL_DURUM";

                        //---
                        var maxSayi = from c in db.TDI_KOD_FOY_OZEL_DURUM orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_OZEL_DURUM>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_OZEL_DURUM>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "FOY_BIRIM_ID,  " +
                                    "FOY_BIRIM,  " +
                                    "FOY_OZEL_DURUM,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},'{7}','{8}',{9},{10},{11},{12})",
                                    tableName,
                                    sayim,
                                    (ls.FOY_BIRIM_ID == null ? "null" : ls.FOY_BIRIM_ID.ToString()),
                                    ls.FOY_BIRIM.Replace('\'', '?'),
                                    ls.FOY_OZEL_DURUM.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_FOY_OZEL_DURUM.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_FOY_OZEL_DURUM,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_FOY_OZEL_DURUM

                    #region TDI_KOD_FOY_YERI

                    if (gridControl1.DataSource is List<TDI_KOD_FOY_YERI>)
                    {
                        tableName = "TDI_KOD_FOY_YERI";

                        //---
                        var maxSayi = from c in db.TDI_KOD_FOY_YERI orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_YERI>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_YERI>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "FOY_BIRIM_ID,  " +
                                    "FOY_BIRIM,  " +
                                    "FOY_YERI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},'{7}','{8}',{9},{10},{11},{12})",
                                    tableName,
                                    sayim,
                                    (ls.FOY_BIRIM_ID == null ? "null" : ls.FOY_BIRIM_ID.ToString()),
                                    ls.FOY_BIRIM.Replace('\'', '?'),
                                    ls.FOY_YERI.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_FOY_YERI.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_FOY_YERI,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_FOY_YERI

                    #region TDI_KOD_IL

                    if (gridControl1.DataSource is List<TDI_KOD_IL>)
                    {
                        tableName = "TDI_KOD_IL";

                        //---
                        var maxSayi = from c in db.TDI_KOD_IL orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_IL>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_IL>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ULKE_ID,  " +
                                    "ULKE,  " +
                                    "IL,  " +
                                    "PLAKA_NO,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}','{5}',{6},{7},'{8}','{9}',{10},{11},{12},{13})",
                                    tableName,
                                    sayim,
                                    ls.ULKE_ID,
                                    ls.ULKE.Replace('\'', '?'),
                                    ls.IL.Replace('\'', '?'),
                                    ls.PLAKA_NO.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_IL.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_IL,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_IL

                    #region TDI_KOD_ILCE

                    if (gridControl1.DataSource is List<TDI_KOD_ILCE>)
                    {
                        tableName = "TDI_KOD_ILCE";

                        //---
                        var maxSayi = from c in db.TDI_KOD_ILCE orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ILCE>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ILCE>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "IL_ID,  " +
                                    "IL,  " +
                                    "ILCE,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KOD,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},'{7}','{8}',{9},{10},'{11}',{12},{13})",
                                    tableName,
                                    sayim,
                                    ls.IL_ID,
                                    ls.IL,
                                    ls.ILCE.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    ls.KOD.Replace('\'', '?'),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_ILCE.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_ILCE,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_ILCE

                    #region TDI_KOD_IS_TARAF

                    if (gridControl1.DataSource is List<TDI_KOD_IS_TARAF>)
                    {
                        tableName = "TDI_KOD_IS_TARAF";

                        //---
                        var maxSayi = from c in db.TDI_KOD_IS_TARAF orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_IS_TARAF>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_IS_TARAF>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "IS_TARAF,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.IS_TARAF.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_IS_TARAF.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_IS_TARAF,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_IS_TARAF

                    #region TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP

                    if (gridControl1.DataSource is List<TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP>)
                    {
                        tableName = "TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP";

                        //---
                        var maxSayi = from c in db.TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "TARAF_TIP,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.TARAF_TIP.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP

                    #region TDI_KOD_KREDI_GRUP

                    if (gridControl1.DataSource is List<TDI_KOD_KREDI_GRUP>)
                    {
                        tableName = "TDI_KOD_KREDI_GRUP";

                        //---
                        var maxSayi = from c in db.TDI_KOD_KREDI_GRUP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_KREDI_GRUP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_KREDI_GRUP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "FOY_BIRIM_ID,  " +
                                    "FOY_BIRIM,  " +
                                    "KREDI_GRUP,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID,  " +
                                    "BANKA_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},'{7}','{8}',{9},{10},{11},{12},{13})",
                                    tableName,
                                    sayim,
                                    (ls.FOY_BIRIM_ID == null ? "null" : ls.FOY_BIRIM_ID.ToString()),
                                    ls.FOY_BIRIM.Replace('\'', '?'),
                                    ls.KREDI_GRUP.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()),
                                    (ls.BANKA_ID == null ? "null" : ls.BANKA_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_KREDI_GRUP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_KREDI_GRUP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_KREDI_GRUP

                    #region TDI_KOD_MESLEK

                    if (gridControl1.DataSource is List<TDI_KOD_MESLEK>)
                    {
                        tableName = "TDI_KOD_MESLEK";

                        //---
                        var maxSayi = from c in db.TDI_KOD_MESLEK orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MESLEK>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MESLEK>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "MESLEK,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.MESLEK.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_MESLEK.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_MESLEK,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_MESLEK

                    #region TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI

                    if (gridControl1.DataSource is List<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>)
                    {
                        tableName = "TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI";

                        //---
                        var maxSayi = from c in db.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ANA_KATEGORI_ID,  " +
                                    "ANA_KATEGORI,  " +
                                    "ALT_KATEGORI,  " +
                                    "MANUAL_KAYIT_YAPABILIR_MI,  " +
                                    "MAKTU_VEKALET_KOD_NO,  " +
                                    "HESAPLANACAKMI_KDV,  " +
                                    "HESAPLANACAKMI_STOPAJ_SSDF,  " +
                                    "ICINDEMI_KDV,  " +
                                    "ICINDEMI_STOPAJ_SSDF,  " +
                                    "DEGISTIREBILIRMI_HESAPLANACAKMI_KDV,  " +
                                    "DEGISTIREBILIRMI_HESAPLANACAKMI_STOPAJ_SSDF,  " +
                                    "DEGISTIREBILIRMI_ICINDEMI_KDV,  " +
                                    "DEGISTIREBILIRMI_ICINDEMI_STOPAJ_SSDF,  " +
                                    "TEKDUZEN_HESAP_KOD,  " +
                                    "KDV_TUR_ID,  " +
                                    "KDV_TUR,  " +
                                    "ICON,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "TO_HESAP_CETVEL_YERI,  " +
                                    "TS_HESAP_CETVEL_YERI,  " +
                                    "DO_HESAP_CETVEL_YERI,  " +
                                    "DS_HESAP_CETVEL_YERI,  " +
                                    "KOLAY_SIRA,  " +
                                    "GORUSME_MI,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},'{15}',{16},'{17}',{18},{19},{20},'{21}','{22}',{23},{24},{25},{26},{27},{28},{29},{30},{31},{32})",
                                    tableName,
                                    sayim,
                                    ls.ANA_KATEGORI_ID,
                                    ls.ANA_KATEGORI.Replace('\'', '?'),
                                    ls.ALT_KATEGORI.Replace('\'', '?'),
                                    (ls.MANUAL_KAYIT_YAPABILIR_MI == true ? 1 : 0),
                                    ls.MAKTU_VEKALET_KOD_NO,
                                    (ls.HESAPLANACAKMI_KDV == true ? 1 : 0),
                                    (ls.HESAPLANACAKMI_STOPAJ_SSDF == true ? 1 : 0),
                                    (ls.ICINDEMI_KDV == true ? 1 : 0),
                                    (ls.ICINDEMI_STOPAJ_SSDF == true ? 1 : 0),
                                    (ls.DEGISTIREBILIRMI_HESAPLANACAKMI_KDV == true ? 1 : 0),
                                    (ls.DEGISTIREBILIRMI_HESAPLANACAKMI_STOPAJ_SSDF == true ? 1 : 0),
                                    (ls.DEGISTIREBILIRMI_ICINDEMI_KDV == true ? 1 : 0),
                                    (ls.DEGISTIREBILIRMI_ICINDEMI_STOPAJ_SSDF == true ? 1 : 0),
                                    ls.TEKDUZEN_HESAP_KOD.Replace('\'', '?'),
                                    (ls.KDV_TUR_ID == null ? "null" : ls.KDV_TUR_ID.ToString()),
                                    ls.KDV_TUR.Replace('\'', '?'),
                                    (ls.ICON == null ? "null" : ls.ICON.ToString()),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.TO_HESAP_CETVEL_YERI == null ? "null" : ls.TO_HESAP_CETVEL_YERI.ToString()),
                                    (ls.TS_HESAP_CETVEL_YERI == null ? "null" : ls.TS_HESAP_CETVEL_YERI.ToString()),
                                    (ls.DO_HESAP_CETVEL_YERI == null ? "null" : ls.DO_HESAP_CETVEL_YERI.ToString()),
                                    (ls.DS_HESAP_CETVEL_YERI == null ? "null" : ls.DS_HESAP_CETVEL_YERI.ToString()),
                                    ls.KOLAY_SIRA,
                                    (ls.GORUSME_MI == true ? 1 : 0),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI

                    #region TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI

                    if (gridControl1.DataSource is List<TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI>)
                    {
                        tableName = "TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI";

                        //---
                        var maxSayi = from c in db.TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ANA_KATEGORI,  " +
                                    "GORUNECEK_MI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "CARI_BORCU_MU,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},{5},'{6}','{7}',{8},{9},{10},{11},{12})",
                                    tableName,
                                    sayim,
                                    ls.ANA_KATEGORI.Replace('\'', '?'),
                                    (ls.GORUNECEK_MI == true ? 1 : 0),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.CARI_BORCU_MU == true ? 1 : 0),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI

                    #region TDI_KOD_ODEME_TIP

                    if (gridControl1.DataSource is List<TDI_KOD_ODEME_TIP>)
                    {
                        tableName = "TDI_KOD_ODEME_TIP";

                        //---
                        var maxSayi = from c in db.TDI_KOD_ODEME_TIP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ODEME_TIP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ODEME_TIP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ODEME_TIP,  " +
                                    "LIKIT_MI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},{5},'{6}','{7}',{8},{9},{10},{11})",
                                    tableName,
                                    sayim,
                                    ls.ODEME_TIP.Replace('\'', '?'),
                                    (ls.LIKIT_MI == true ? 1 : 0),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_ODEME_TIP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_ODEME_TIP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_ODEME_TIP

                    #region TDI_KOD_OZEL_TUTAR_KONU

                    if (gridControl1.DataSource is List<TDI_KOD_OZEL_TUTAR_KONU>)
                    {
                        tableName = "TDI_KOD_OZEL_TUTAR_KONU";

                        //---
                        var maxSayi = from c in db.TDI_KOD_OZEL_TUTAR_KONU orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_OZEL_TUTAR_KONU>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_OZEL_TUTAR_KONU>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "KONU,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.KONU.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_OZEL_TUTAR_KONU.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_OZEL_TUTAR_KONU,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_OZEL_TUTAR_KONU

                    #region TDI_KOD_POLICE_BRANS

                    if (gridControl1.DataSource is List<TDI_KOD_POLICE_BRANS>)
                    {
                        tableName = "TDI_KOD_POLICE_BRANS";

                        //---
                        var maxSayi = from c in db.TDI_KOD_POLICE_BRANS orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_POLICE_BRANS>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_POLICE_BRANS>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "POLICE_BRANS,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.POLICE_BRANS.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_POLICE_BRANS.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_POLICE_BRANS,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_POLICE_BRANS

                    #region TDI_KOD_SOZLESME_ALT_TIP

                    if (gridControl1.DataSource is List<TDI_KOD_SOZLESME_ALT_TIP>)
                    {
                        tableName = "TDI_KOD_SOZLESME_ALT_TIP";

                        //---
                        var maxSayi = from c in db.TDI_KOD_SOZLESME_ALT_TIP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_ALT_TIP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_ALT_TIP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ANA_TIP_ID,  " +
                                    "ANA_TIP,  " +
                                    "ALT_TIP,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},'{7}','{8}',{9},{10},{11},{12})",
                                    tableName,
                                    sayim,
                                    ls.ANA_TIP_ID,
                                    ls.ANA_TIP.Replace('\'', '?'),
                                    ls.ALT_TIP.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_SOZLESME_ALT_TIP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_SOZLESME_ALT_TIP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_SOZLESME_ALT_TIP

                    #region TDI_KOD_SOZLESME_DURUM

                    if (gridControl1.DataSource is List<TDI_KOD_SOZLESME_DURUM>)
                    {
                        tableName = "TDI_KOD_SOZLESME_DURUM";

                        //---
                        var maxSayi = from c in db.TDI_KOD_SOZLESME_DURUM orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_DURUM>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_DURUM>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "SOZLESME_DURUM,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.SOZLESME_DURUM.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_SOZLESME_DURUM.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_SOZLESME_DURUM,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_SOZLESME_DURUM

                    #region TDI_KOD_SOZLESME_OZEL

                    if (gridControl1.DataSource is List<TDI_KOD_SOZLESME_OZEL>)
                    {
                        tableName = "TDI_KOD_SOZLESME_OZEL";

                        //---
                        var maxSayi = from c in db.TDI_KOD_SOZLESME_OZEL orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_OZEL>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_OZEL>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "SOZLESME_OZEL,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.SOZLESME_OZEL.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_SOZLESME_OZEL.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_SOZLESME_OZEL,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_SOZLESME_OZEL

                    #region TDI_KOD_SOZLESME_TARAF_SIFAT

                    if (gridControl1.DataSource is List<TDI_KOD_SOZLESME_TARAF_SIFAT>)
                    {
                        tableName = "TDI_KOD_SOZLESME_TARAF_SIFAT";

                        //---
                        var maxSayi = from c in db.TDI_KOD_SOZLESME_TARAF_SIFAT orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_TARAF_SIFAT>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_TARAF_SIFAT>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "TARAF_SIFAT,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.TARAF_SIFAT.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_SOZLESME_TARAF_SIFAT.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_SOZLESME_TARAF_SIFAT,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_SOZLESME_TARAF_SIFAT

                    #region TDI_KOD_SOZLESME_TIP

                    if (gridControl1.DataSource is List<TDI_KOD_SOZLESME_TIP>)
                    {
                        tableName = "TDI_KOD_SOZLESME_TIP";

                        //---
                        var maxSayi = from c in db.TDI_KOD_SOZLESME_TIP orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_TIP>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_TIP>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "TIP,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.TIP.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_SOZLESME_TIP.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_SOZLESME_TIP,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_SOZLESME_TIP

                    #region TDI_KOD_SURE_OZEL

                    if (gridControl1.DataSource is List<TDI_KOD_SURE_OZEL>)
                    {
                        tableName = "TDI_KOD_SURE_OZEL";

                        //---
                        var maxSayi = from c in db.TDI_KOD_SURE_OZEL orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SURE_OZEL>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SURE_OZEL>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "SURE_OZEL,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.SURE_OZEL.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_SURE_OZEL.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_SURE_OZEL,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_SURE_OZEL

                    #region TDI_KOD_TAHSILAT_DURUM

                    if (gridControl1.DataSource is List<TDI_KOD_TAHSILAT_DURUM>)
                    {
                        tableName = "TDI_KOD_TAHSILAT_DURUM";

                        //---
                        var maxSayi = from c in db.TDI_KOD_TAHSILAT_DURUM orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_TAHSILAT_DURUM>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_TAHSILAT_DURUM>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "FOY_BIRIM_ID,  " +
                                    "FOY_BIRIM,  " +
                                    "TAHSILAT_DURUM,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},'{7}','{8}',{9},{10},{11},{12})",
                                    tableName,
                                    sayim,
                                    (ls.FOY_BIRIM_ID == null ? "null" : ls.FOY_BIRIM_ID.ToString()),
                                    ls.FOY_BIRIM.Replace('\'', '?'),
                                    ls.TAHSILAT_DURUM.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_TAHSILAT_DURUM.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_TAHSILAT_DURUM,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_TAHSILAT_DURUM

                    #region TDI_KOD_TEBLIGAT_KONU

                    if (gridControl1.DataSource is List<TDI_KOD_TEBLIGAT_KONU>)
                    {
                        tableName = "TDI_KOD_TEBLIGAT_KONU";

                        //---
                        var maxSayi = from c in db.TDI_KOD_TEBLIGAT_KONU orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_TEBLIGAT_KONU>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDI_KOD_TEBLIGAT_KONU>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ANA_TUR_ID,  " +
                                    "ANA_TUR,  " +
                                    "ALT_TUR_ID,  " +
                                    "ALT_TUR,  " +
                                    "KONU,  " +
                                    "MODUL,  " +
                                    "ADLI_BIRIM_BOLUM_ID,  " +
                                    "ADLI_BIRIM_BOLUM_KOD,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "SABLON_ID,  " +
                                    "Sablon_Rapor_Id,  " +
                                    "MUHATAP_YABANCI_MI,  " +
                                    "ILK_TEBLIGAT_MI,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}',{4},'{5}','{6}',{7},{8},'{9}',{10},{11},'{12}','{13}',{14},{15},{16},{17},{18},{19},{20},{21})",
                                    tableName,
                                    sayim,
                                    ls.ANA_TUR_ID,
                                    ls.ANA_TUR.Replace('\'', '?'),
                                    ls.ALT_TUR_ID,
                                    ls.ALT_TUR.Replace('\'', '?'),
                                    ls.KONU.Replace('\'', '?'),
                                    ls.MODUL,
                                    ls.ADLI_BIRIM_BOLUM_ID,
                                    ls.ADLI_BIRIM_BOLUM_KOD.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.SABLON_ID == null ? "null" : ls.SABLON_ID.ToString()),
                                    (ls.Sablon_Rapor_Id == null ? "null" : ls.Sablon_Rapor_Id.ToString()),
                                    (ls.MUHATAP_YABANCI_MI == true ? 1 : 0),
                                    (ls.ILK_TEBLIGAT_MI == true ? 1 : 0),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDI_KOD_TEBLIGAT_KONU.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDI_KOD_TEBLIGAT_KONU,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDI_KOD_TEBLIGAT_KONU

                    #region TDIE_KOD_SABLON

                    if (gridControl1.DataSource is List<TDIE_KOD_SABLON>)
                    {
                        tableName = "TDIE_KOD_SABLON";

                        //---
                        var maxSayi = from c in db.TDIE_KOD_SABLON orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_SABLON>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_SABLON>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ADI,  " +
                                    "SABLON_DOSYA_ADI,  " +
                                    "KATEGORI_ID,  " +
                                    "KATEGORI,  " +
                                    "ALT_KATEGORI_ID,  " +
                                    "ALT_KATEGORI,  " +
                                    "VERSIYONU,  " +
                                    "LISTE_YERI,  " +
                                    "OTOMATIK_YAZDIRILABILIR,  " +
                                    "ICERIK,  " +
                                    "CHECK_OUT_USER,  " +
                                    "CHECK_OUT_USER_NAME,  " +
                                    "CHECK_OUT_TIME,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}','{3}',{4},'{5}',{6},'{7}','{8}','{9}',{10},{11},{12},'{13}','{14}',{15},{16},'{17}','{18}',{19},{20},{21},{22})",
                                    tableName,
                                    sayim,
                                    ls.ADI.Replace('\'', '?'),
                                    ls.SABLON_DOSYA_ADI.Replace('\'', '?'),
                                    ls.KATEGORI_ID,
                                    ls.KATEGORI.Replace('\'', '?'),
                                    (ls.ALT_KATEGORI_ID == null ? "null" : ls.ALT_KATEGORI_ID.ToString()),
                                    ls.ALT_KATEGORI.Replace('\'', '?'),
                                    ls.VERSIYONU.Replace('\'', '?'),
                                    ls.LISTE_YERI.Replace('\'', '?'),
                                    ls.OTOMATIK_YAZDIRILABILIR,
                                    (ls.ICERIK == null ? "null" : ls.ICERIK.ToString()),
                                    (ls.CHECK_OUT_USER == null ? "null" : ls.CHECK_OUT_USER.ToString()),
                                    ls.CHECK_OUT_USER_NAME.Replace('\'', '?'),
                                    ls.CHECK_OUT_TIME,
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDIE_KOD_SABLON.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDIE_KOD_SABLON,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDIE_KOD_SABLON

                    #region TDIE_KOD_SABLON_ALT_KATEGORI

                    if (gridControl1.DataSource is List<TDIE_KOD_SABLON_ALT_KATEGORI>)
                    {
                        tableName = "TDIE_KOD_SABLON_ALT_KATEGORI";

                        //---
                        var maxSayi = from c in db.TDIE_KOD_SABLON_ALT_KATEGORI orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_SABLON_ALT_KATEGORI>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_SABLON_ALT_KATEGORI>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "ANA_KATEGORI_ID,  " +
                                    "ADI,  " +
                                    "LISTE_YERI,  " +
                                    "ALT_KATEGORI_SIRASI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}','{4}',{5},{6},{7},'{8}','{9}',{10},{11},{12},{13})",
                                    tableName,
                                    sayim,
                                    ls.ANA_KATEGORI_ID,
                                    ls.ADI.Replace('\'', '?'),
                                    ls.LISTE_YERI.Replace('\'', '?'),
                                    ls.ALT_KATEGORI_SIRASI,
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDIE_KOD_SABLON_ALT_KATEGORI.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDIE_KOD_SABLON_ALT_KATEGORI,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDIE_KOD_SABLON_ALT_KATEGORI

                    #region TDIE_KOD_TARAF_SIFAT

                    if (gridControl1.DataSource is List<TDIE_KOD_TARAF_SIFAT>)
                    {
                        tableName = "TDIE_KOD_TARAF_SIFAT";

                        //---
                        var maxSayi = from c in db.TDIE_KOD_TARAF_SIFAT orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_TARAF_SIFAT>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_TARAF_SIFAT>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "MODUL,  " +
                                    "MODUL_ACIKLAMA,  " +
                                    "ADLI_BIRIM_BOLUM_ID,  " +
                                    "ADLI_BIRIM_BOLUM_KOD,  " +
                                    "SIFAT,  " +
                                    "HANGI_TARAF_NO,  " +
                                    "HANGI_TARAFI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "UYAP_KOD,  " +
                                    "UYAP_ACIKLAMA,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}',{4},'{5}','{6}',{7},'{8}',{9},{10},'{11}','{12}',{13},{14},'{15}','{16}',{17},{18})",
                                    tableName,
                                    sayim,
                                    ls.MODUL,
                                    ls.MODUL_ACIKLAMA,
                                    (ls.ADLI_BIRIM_BOLUM_ID == null ? "null" : ls.ADLI_BIRIM_BOLUM_ID.ToString()),
                                    ls.ADLI_BIRIM_BOLUM_KOD.Replace('\'', '?'),
                                    ls.SIFAT.Replace('\'', '?'),
                                    ls.HANGI_TARAF_NO,
                                    ls.HANGI_TARAFI.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    ls.UYAP_KOD.Replace('\'', '?'),
                                    ls.UYAP_ACIKLAMA.Replace('\'', '?'),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TDIE_KOD_TARAF_SIFAT.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TDIE_KOD_TARAF_SIFAT,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TDIE_KOD_TARAF_SIFAT

                    #region TI_KOD_ALACAK_NEDEN

                    if (gridControl1.DataSource is List<TI_KOD_ALACAK_NEDEN>)
                    {
                        tableName = "TI_KOD_ALACAK_NEDEN";

                        //---
                        var maxSayi = from c in db.TI_KOD_ALACAK_NEDEN orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TI_KOD_ALACAK_NEDEN>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TI_KOD_ALACAK_NEDEN>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "TAKIP_TALEP_KOD_ID,  " +
                                    "TAKIP_TALEP_KODU,  " +
                                    "FORM_TIPI,  " +
                                    "ALACAK_NEDENI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "NAKTI_GAYRINAKTI,  " +
                                    "DEPO_ALACAGI,  " +
                                    "ALACAK_NEDEN_GRUP_NO,  " +
                                    "FORM_TIP_ID,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}',{4},'{5}',{6},{7},'{8}','{9}',{10},{11},{12},{13},{14},{15},{16},{17})",
                                    tableName,
                                    sayim,
                                    ls.TAKIP_TALEP_KOD_ID,
                                    ls.TAKIP_TALEP_KODU.Replace('\'', '?'),
                                    ls.FORM_TIPI,
                                    ls.ALACAK_NEDENI.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.NAKTI_GAYRINAKTI == null ? "null" : ls.NAKTI_GAYRINAKTI.ToString()),
                                    (ls.DEPO_ALACAGI == true ? 1 : 0),
                                    (ls.ALACAK_NEDEN_GRUP_NO == null ? "null" : ls.ALACAK_NEDEN_GRUP_NO.ToString()),
                                    (ls.FORM_TIP_ID == null ? "null" : ls.FORM_TIP_ID.ToString()),
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TI_KOD_ALACAK_NEDEN.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TI_KOD_ALACAK_NEDEN,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TI_KOD_ALACAK_NEDEN

                    #region TI_KOD_FOY_GELISME_ADIM

                    if (gridControl1.DataSource is List<TI_KOD_FOY_GELISME_ADIM>)
                    {
                        tableName = "TI_KOD_FOY_GELISME_ADIM";

                        //---
                        var maxSayi = from c in db.TI_KOD_FOY_GELISME_ADIM orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TI_KOD_FOY_GELISME_ADIM>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TI_KOD_FOY_GELISME_ADIM>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "GELISME_ADIM,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10})",
                                    tableName,
                                    sayim,
                                    ls.GELISME_ADIM.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TI_KOD_FOY_GELISME_ADIM.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TI_KOD_FOY_GELISME_ADIM,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TI_KOD_FOY_GELISME_ADIM

                    #region TI_KOD_MAL_CINS

                    if (gridControl1.DataSource is List<TI_KOD_MAL_CINS>)
                    {
                        tableName = "TI_KOD_MAL_CINS";

                        //---
                        var maxSayi = from c in db.TI_KOD_MAL_CINS orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TI_KOD_MAL_CINS>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TI_KOD_MAL_CINS>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "KATEGORI_ID,  " +
                                    "KATEGORI,  " +
                                    "TUR_ID,  " +
                                    "TUR,  " +
                                    "CINS,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},{2},'{3}',{4},'{5}','{6}',{7},{8},'{9}','{10}',{11},{12},{13},{14})",
                                    tableName,
                                    sayim,
                                    ls.KATEGORI_ID,
                                    ls.KATEGORI.Replace('\'', '?'),
                                    ls.TUR_ID,
                                    ls.TUR.Replace('\'', '?'),
                                    ls.CINS.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TI_KOD_MAL_CINS.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TI_KOD_MAL_CINS,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TI_KOD_MAL_CINS

                    #region TI_KOD_MAL_KATEGORI

                    if (gridControl1.DataSource is List<TI_KOD_MAL_KATEGORI>)
                    {
                        tableName = "TI_KOD_MAL_KATEGORI";

                        //---
                        var maxSayi = from c in db.TI_KOD_MAL_KATEGORI orderby c.ID descending where c.ID < 10000 select c.ID;

                        //null kontrolu
                        int sayim = 0;
                        if (maxSayi.Count() > 0)
                            sayim = maxSayi.First() + 1;
                        else
                            sayim++;

                        string updateQuery;

                        //iliskili oldugu tablolari getirir.
                        var tableRelationList = db.ID_UPDATE_TABLE_GET_RELATIONS(tableName);

                        IList<ID_UPDATE_TABLE_GET_RELATIONSResult> tableRelations = tableRelationList.ToList();
                        bool IsSelected = false;

                        foreach (var ls in gridControl1.DataSource as List<TI_KOD_MAL_KATEGORI>)
                        {
                            if (ls.IsSelected == true)
                            {
                                IsSelected = true;
                                break;
                            }
                        }
                        if (IsSelected)
                        {
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "OFF");

                            foreach (var ls in gridControl1.DataSource as List<TI_KOD_MAL_KATEGORI>)
                            {
                                if (ls.IsSelected == true)
                                {
                                    if (chkOldIdSave.Checked)
                                    {
                                        IU_ID_BACKUP bak = new IU_ID_BACKUP()
                                        {
                                            NewID = sayim,
                                            OldID = ls.ID,
                                            TableName = tableName,
                                            OperationTime = DateTime.Now
                                        };
                                        db.IU_ID_BACKUP.InsertOnSubmit(bak);
                                    }

                                    //Yeni Row insert edilecek
                                    string command = string.Format("Insert Into {0} ( " +
                                    "ID,  " +
                                    "KOD,  " +
                                    "KATEGORI,  " +
                                    "SUBE_KODU,  " +
                                    "ADMIN_KAYIT_MI,  " +
                                    "KONTROL_NE_ZAMAN,  " +
                                    "KONTROL_KIM,  " +
                                    "KONTROL_VERSIYON,  " +
                                    "STAMP,  " +
                                    "KONTROL_KIM_ID,  " +
                                    "SUBE_KOD_ID)" +
                                    " VALUES ({1},'{2}','{3}',{4},{5},'{6}','{7}',{8},{9},{10},{11})",
                                    tableName,
                                    sayim,
                                    ls.KOD.Replace('\'', '?'),
                                    ls.KATEGORI.Replace('\'', '?'),
                                    ls.SUBE_KODU,
                                    1,
                                    DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"),
                                    ls.KONTROL_KIM.Replace('\'', '?'),
                                    (ls.KONTROL_VERSIYON + 1),
                                    ls.STAMP,
                                    (ls.KONTROL_KIM_ID == null ? "null" : ls.KONTROL_KIM_ID.ToString()),
                                    (ls.SUBE_KOD_ID == null ? "null" : ls.SUBE_KOD_ID.ToString()));

                                    db.ExecuteCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON {1} SET IDENTITY_INSERT dbo.{0} OFF", tableName, command));

                                    //iliskili tablolar guncellenir
                                    foreach (var tableRelation in tableRelations)
                                    {
                                        if (!(tableRelation.RelatedTable.ToUpper() == tableRelation.MainTable.ToUpper() &&
                                            tableRelation.RelatedColumn.ToUpper() == tableRelation.MainColumn.ToUpper()))
                                        {
                                            updateQuery = "UPDATE " + tableRelation.RelatedTable +
                                                " SET " + tableRelation.RelatedColumn + " = " + sayim +
                                                " WHERE " + tableRelation.RelatedColumn + " = " + ls.ID.ToString();

                                            db.ExecuteCommand(updateQuery);
                                        }
                                    }

                                    //ls.ID li Eski datalar silinecek.
                                    db.TI_KOD_MAL_KATEGORI.DeleteOnSubmit(ls);
                                    db.SubmitChanges();

                                    //En son sayim 1 artirilacak
                                    sayim++;
                                }
                            }

                            db.ExecuteCommand("DBCC CHECKIDENT(TI_KOD_MAL_KATEGORI,reseed,10000)");
                            db.ID_UPDATE_TABLE_INDEXES_ON_OFF(tableName, "ON");
                        }
                    }

                    #endregion TI_KOD_MAL_KATEGORI

                    FillDataSource(tableName);
                    FillLookupEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (db.Connection.State == ConnectionState.Open)
                    db.Connection.Close();
            }
        }

        private void FillDataSource(string tableName)
        {
            try
            {
                switch (tableName)
                {
                    case "TA_KOD_ISLETIM_SIRASI":
                        gridControl1.DataSource = (from c in db.TA_KOD_ISLETIM_SIRASI where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TD_KOD_DAVA_TALEP":
                        gridControl1.DataSource = (from c in db.TD_KOD_DAVA_TALEP where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TD_KOD_HAZIRLIK_DURUM":
                        gridControl1.DataSource = (from c in db.TD_KOD_HAZIRLIK_DURUM where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_ARAC_TIP":
                        gridControl1.DataSource = (from c in db.TDI_KOD_ARAC_TIP where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_BANKA":
                        gridControl1.DataSource = (from c in db.TDI_KOD_BANKA where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_BANKA_BOLGE":
                        gridControl1.DataSource = (from c in db.TDI_KOD_BANKA_BOLGE where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_BANKA_KART_TIP":
                        gridControl1.DataSource = (from c in db.TDI_KOD_BANKA_KART_TIP where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_BANKA_SUBE":
                        gridControl1.DataSource = (from c in db.TDI_KOD_BANKA_SUBE where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_DAVA_ADI":
                        gridControl1.DataSource = (from c in db.TDI_KOD_DAVA_ADI where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_FAIZ_TIP":
                        gridControl1.DataSource = (from c in db.TDI_KOD_FAIZ_TIP where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_FIRMA_TUR":
                        gridControl1.DataSource = (from c in db.TDI_KOD_FIRMA_TUR where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_FORM_LISTESI":
                        gridControl1.DataSource = (from c in db.TDI_KOD_FORM_LISTESI where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_FOY_BIRIM":
                        gridControl1.DataSource = (from c in db.TDI_KOD_FOY_BIRIM where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_FOY_DURUM":
                        gridControl1.DataSource = (from c in db.TDI_KOD_FOY_DURUM where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_FOY_OZEL_DURUM":
                        gridControl1.DataSource = (from c in db.TDI_KOD_FOY_OZEL_DURUM where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_FOY_YERI":
                        gridControl1.DataSource = (from c in db.TDI_KOD_FOY_YERI where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_IL":
                        gridControl1.DataSource = (from c in db.TDI_KOD_IL where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_ILCE":
                        gridControl1.DataSource = (from c in db.TDI_KOD_ILCE where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_IS_TARAF":
                        gridControl1.DataSource = (from c in db.TDI_KOD_IS_TARAF where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP":
                        gridControl1.DataSource = (from c in db.TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP orderby c.ID where c.ID > 10000 select c).ToList();
                        break;

                    case "TDI_KOD_KREDI_GRUP":
                        gridControl1.DataSource = (from c in db.TDI_KOD_KREDI_GRUP where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_MESLEK":
                        gridControl1.DataSource = (from c in db.TDI_KOD_MESLEK where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI":
                        gridControl1.DataSource = (from c in db.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI orderby c.ID where c.ID > 10000 select c).ToList();
                        break;

                    case "TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI":
                        gridControl1.DataSource = (from c in db.TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI orderby c.ID where c.ID > 10000 select c).ToList();
                        break;

                    case "TDI_KOD_ODEME_TIP":
                        gridControl1.DataSource = (from c in db.TDI_KOD_ODEME_TIP where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_OZEL_TUTAR_KONU":
                        gridControl1.DataSource = (from c in db.TDI_KOD_OZEL_TUTAR_KONU where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_POLICE_BRANS":
                        gridControl1.DataSource = (from c in db.TDI_KOD_POLICE_BRANS where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_SOZLESME_ALT_TIP":
                        gridControl1.DataSource = (from c in db.TDI_KOD_SOZLESME_ALT_TIP where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_SOZLESME_DURUM":
                        gridControl1.DataSource = (from c in db.TDI_KOD_SOZLESME_DURUM where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_SOZLESME_OZEL":
                        gridControl1.DataSource = (from c in db.TDI_KOD_SOZLESME_OZEL where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_SOZLESME_TARAF_SIFAT":
                        gridControl1.DataSource = (from c in db.TDI_KOD_SOZLESME_TARAF_SIFAT where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_SOZLESME_TIP":
                        gridControl1.DataSource = (from c in db.TDI_KOD_SOZLESME_TIP where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_SURE_OZEL":
                        gridControl1.DataSource = (from c in db.TDI_KOD_SURE_OZEL where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_TAHSILAT_DURUM":
                        gridControl1.DataSource = (from c in db.TDI_KOD_TAHSILAT_DURUM where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDIE_KOD_SABLON":
                        gridControl1.DataSource = (from c in db.TDIE_KOD_SABLON where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDIE_KOD_SABLON_ALT_KATEGORI":
                        gridControl1.DataSource = (from c in db.TDIE_KOD_SABLON_ALT_KATEGORI orderby c.ID where c.ID > 10000 select c).ToList();
                        break;

                    case "TDIE_KOD_TARAF_SIFAT":
                        gridControl1.DataSource = (from c in db.TDIE_KOD_TARAF_SIFAT where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TI_KOD_ALACAK_NEDEN":
                        gridControl1.DataSource = (from c in db.TI_KOD_ALACAK_NEDEN where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TI_KOD_FOY_GELISME_ADIM":
                        gridControl1.DataSource = (from c in db.TI_KOD_FOY_GELISME_ADIM where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TI_KOD_MAL_CINS":
                        gridControl1.DataSource = (from c in db.TI_KOD_MAL_CINS where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TI_KOD_MAL_KATEGORI":
                        gridControl1.DataSource = (from c in db.TI_KOD_MAL_KATEGORI where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TI_KOD_MAL_TUR":
                        gridControl1.DataSource = (from c in db.TI_KOD_MAL_TUR where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    case "TDI_KOD_TEBLIGAT_KONU":
                        gridControl1.DataSource = (from c in db.TDI_KOD_TEBLIGAT_KONU where c.ID > 10000 orderby c.ID select c).ToList();
                        break;

                    default: break;
                }

                gridControl1.MainView.PopulateColumns();
                gridControl1.MainView.LayoutChanged();
                gridView1.Columns[gridView1.Columns.Count - 1].VisibleIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillLookupEdit()
        {
            var tabloListesi = db.ID_UPDATE_Table_GET_LIST();
            lkEditTable.Properties.DataSource = null;

            lkEditTable.Properties.DataSource = tabloListesi;
            lkEditTable.Properties.DisplayMember = "TableName";
            lkEditTable.Properties.NullText = "Şeç";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                strConnectionString = GetConnectionString();
                db = new dbDataContext(strConnectionString);

                string[] commandLine = GetEmbeddedResource("StoredProcedures.sql");
                foreach (string line in commandLine)
                {
                    db.ExecuteCommand(line);
                }

                gridView1.OptionsDetail.EnableMasterViewMode = false;
                FillLookupEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private string GetConnectionString()
        {
            //SqlNative Client Secilmeli
            string[] str;
            string[] conStr;
            string tempStr = null;

            DataLinksClass dtLink = new DataLinksClass();
            ConnectionClass connection = new ConnectionClass();
            object obj = connection;
            if (dtLink.PromptEdit(ref obj))
            {
                str = ((ConnectionClass)(obj)).ConnectionString.Split(';');

                for (int i = 0; i < str.Length; i++)
                {
                    conStr = str[i].Split('=');
                    if ("Integrated Security".ToUpper() == conStr[0].ToString().ToUpper())
                        tempStr += str[i] + ";";
                    else if ("Persist Security Info".ToUpper() == conStr[0].ToString().ToUpper())
                        tempStr += str[i] + ";";
                    else if ("User ID".ToUpper() == conStr[0].ToString().ToUpper())
                        tempStr += str[i] + ";";
                    else if ("Data Source".ToUpper() == conStr[0].ToString().ToUpper())
                        tempStr += str[i] + ";";
                    else if ("Initial File Name".ToUpper() == conStr[0].ToString().ToUpper())
                        tempStr += str[i] + ";";
                    else if ("Password".ToUpper() == conStr[0].ToString().ToUpper())
                        tempStr += str[i] + ";";
                    else if ("Initial Catalog".ToUpper() == conStr[0].ToString().ToUpper())
                        tempStr += str[i] + ";";
                }
            }
            else
            {
                throw new Exception("Baglantı kurulamadı.");
            }
            return tempStr;
        }

        private string[] GetEmbeddedResource(string FileName)
        {
            string[] SqlLine;
            Regex regex = new Regex("GOGO", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            Assembly asm = Assembly.GetExecutingAssembly();
            System.IO.Stream str = asm.GetManifestResourceStream(asm.GetName().Name + "." + FileName);
            System.IO.StreamReader reader = new System.IO.StreamReader(str);
            SqlLine = regex.Split(reader.ReadToEnd());
            return SqlLine;
        }

        private void IsSelect(string tableName, bool select, Type lType)
        {
            try
            {
                switch (tableName)
                {
                    case "TA_KOD_ISLETIM_SIRASI":

                        foreach (var ls in gridControl1.DataSource as List<TA_KOD_ISLETIM_SIRASI>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TD_KOD_DAVA_TALEP":
                        foreach (var ls in gridControl1.DataSource as List<TD_KOD_DAVA_TALEP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TD_KOD_HAZIRLIK_DURUM":
                        foreach (var ls in gridControl1.DataSource as List<TD_KOD_HAZIRLIK_DURUM>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_ARAC_TIP":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ARAC_TIP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_BANKA":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_BANKA_BOLGE":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_BOLGE>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_BANKA_KART_TIP":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_KART_TIP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_BANKA_SUBE":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_BANKA_SUBE>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_DAVA_ADI":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_DAVA_ADI>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_FAIZ_TIP":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FAIZ_TIP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_FIRMA_TUR":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FIRMA_TUR>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_FORM_LISTESI":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FORM_LISTESI>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_FOY_BIRIM":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_BIRIM>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_FOY_DURUM":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_DURUM>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_FOY_OZEL_DURUM":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_OZEL_DURUM>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_FOY_YERI":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_FOY_YERI>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_IL":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_IL>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_ILCE":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ILCE>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_IS_TARAF":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_IS_TARAF>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_KIYMETLI_EVRAK_TARAF_TIP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_KREDI_GRUP":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_KREDI_GRUP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_MESLEK":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MESLEK>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_ODEME_TIP":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_ODEME_TIP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_OZEL_TUTAR_KONU":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_OZEL_TUTAR_KONU>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_POLICE_BRANS":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_POLICE_BRANS>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_SOZLESME_ALT_TIP":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_ALT_TIP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_SOZLESME_DURUM":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_DURUM>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_SOZLESME_OZEL":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_OZEL>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_SOZLESME_TARAF_SIFAT":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_TARAF_SIFAT>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_SOZLESME_TIP":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SOZLESME_TIP>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_SURE_OZEL":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_SURE_OZEL>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_TAHSILAT_DURUM":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_TAHSILAT_DURUM>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDIE_KOD_SABLON":
                        foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_SABLON>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDIE_KOD_SABLON_ALT_KATEGORI":
                        foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_SABLON_ALT_KATEGORI>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDIE_KOD_TARAF_SIFAT":
                        foreach (var ls in gridControl1.DataSource as List<TDIE_KOD_TARAF_SIFAT>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TI_KOD_ALACAK_NEDEN":
                        foreach (var ls in gridControl1.DataSource as List<TI_KOD_ALACAK_NEDEN>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TI_KOD_FOY_GELISME_ADIM":
                        foreach (var ls in gridControl1.DataSource as List<TI_KOD_FOY_GELISME_ADIM>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TI_KOD_MAL_CINS":
                        foreach (var ls in gridControl1.DataSource as List<TI_KOD_MAL_CINS>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TI_KOD_MAL_KATEGORI":
                        foreach (var ls in gridControl1.DataSource as List<TI_KOD_MAL_KATEGORI>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    case "TDI_KOD_TEBLIGAT_KONU":
                        foreach (var ls in gridControl1.DataSource as List<TDI_KOD_TEBLIGAT_KONU>)
                        {
                            ls.IsSelected = select;
                        }
                        break;

                    default: break;
                }

                gridControl1.MainView.PopulateColumns();
                gridControl1.MainView.LayoutChanged();
                gridView1.Columns[gridView1.Columns.Count - 1].VisibleIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lkEditTable_EditValueChanged(object sender, EventArgs e)
        {
            FillDataSource(lkEditTable.Text);
        }
    }
}