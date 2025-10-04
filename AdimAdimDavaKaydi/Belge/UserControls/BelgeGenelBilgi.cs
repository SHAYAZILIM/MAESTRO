using AvukatProLib2.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace AdimAdimDavaKaydi.UserControls
{
    /// <summary>
    /// Belge Hakkındaki Genel Bilgiler
    /// </summary>
    public class BelgeGenelBilgi
    {
        private AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE belge;
        private AvukatProLib2.Entities.IEntity kayit;
        private int kayitId;
        private AvukatProLib2.Entities.IEntity modul;
        private string modulesTable;
        private RowInfoCollection rows;

        public AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE Belge
        {
            get { return belge; }
            set { belge = value; }
        }

        public AvukatProLib2.Entities.IEntity Kayit
        {
            get { return kayit; }
            set { kayit = value; }
        }

        public int KayitID
        {
            get { return kayitId; }
            set { kayitId = value; }
        }

        public AvukatProLib2.Entities.IEntity Modul
        {
            get { return modul; }
            set { modul = value; }
        }

        public string ModulesTable
        {
            get { return modulesTable; }
            set { modulesTable = value; }
        }

        public RowInfoCollection Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public string Table { get; set; }

        public AV001_TDIE_BIL_BELGE ConvertRecordToBelge(IEntity record)
        {
            this.kayit = record;
            GetModul();
            FillRowsByModulsTable();
            FillModulsValues();
            SetValues();
            FillBelgeWithValues();
            return this.belge;
        }

        public TList<AV001_TDIE_BIL_BELGE_TARAF> ConvertTarafToBelgeTaraf()
        {
            TList<AV001_TDIE_BIL_BELGE_TARAF> lstTarafs = new TList<AV001_TDIE_BIL_BELGE_TARAF>();

            string name = this.modul.GetType().Name;

            object tarafs = new object(); //Tablolar.GetListByTableName( name+ "_TARAF" );
            IList lsT = (IList)tarafs;

            //TODO : Yarım kaldı
            for (int i = 0; i < lsT.Count; i++)
            {
                object cari = lsT[i].GetType().GetProperty("CARI_ID").GetValue(lsT[i], null);
                object sifat = lsT[i].GetType().GetProperty("TARAF_SIFAT_ID").GetValue(lsT[i], null);
                AV001_TDIE_BIL_BELGE_TARAF tr = new AV001_TDIE_BIL_BELGE_TARAF();
                tr.CARI_ID = Convert.ToInt32(cari);
                tr.SIFAT_ID = Convert.ToInt32(sifat);

                lstTarafs.Add(tr);
            }
            return lstTarafs;
        }

        public TarafCollection ConvertTypedTarafToTaraf()
        {
            TarafCollection lstTarafs = new TarafCollection();

            string name = this.modul.GetType().Name;

            object tarafs = new object(); //Tablolar.GetListByTableName(name + "_TARAF");
            IList lsT = (IList)tarafs;

            //TODO : Yarım kaldı
            for (int i = 0; i < lsT.Count; i++)
            {
                object cari = lsT[i].GetType().GetProperty("CARI_ID").GetValue(lsT[i], null);
                object sifat = lsT[i].GetType().GetProperty("TARAF_SIFAT_ID").GetValue(lsT[i], null);
                string hangiTarafi =
                    AvukatProLib2.Data.DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID((int)sifat).HANGI_TARAFI;

                Taraflar tr = new Taraflar();
                tr.CARI_ID = Convert.ToInt32(cari);
                tr.TARAF_SIFAT_ID = Convert.ToInt32(sifat);
                tr.HangiTarafi = ConvertTarafSifatToHangiTaraf(modulesTable, hangiTarafi);
                tr.YETKILI_MI =
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(tr.CARI_ID).YETKILI_MI;
                lstTarafs.Add(tr);
            }
            return lstTarafs;
        }

        public TList<AV001_TDIE_BIL_BELGE_SORUMLU> GetBelgeSorumlu()
        {
            return getSorumluByModul();
        }

        public TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE_SORUMLU> getSorumluByModul()
        {
            TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE_SORUMLU> returnValue =
                new TList<AV001_TDIE_BIL_BELGE_SORUMLU>();
            switch (this.modulesTable)
            {
                case "AV001_TD_BIL_FOY":

                    //AV001_TD_BIL_FOY __________________________________
                    TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> lstSAvukat = new TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>();
                    lstSAvukat =
                        AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.GetByDAVA_FOY_ID(
                            kayitId);

                    for (int i = 0; i < lstSAvukat.Count; i++)
                    {
                        AV001_TDI_BIL_CARI cri = new AV001_TDI_BIL_CARI();
                        cri =
                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                lstSAvukat[i].SORUMLU_AVUKAT_CARI_ID.Value);
                        AV001_TDIE_BIL_BELGE_SORUMLU bs = new AV001_TDIE_BIL_BELGE_SORUMLU();
                        bs.CARI_ID = cri.ID;
                        bs.CARI_IDSource = cri;
                        bs.SORUMLU_TIP = lstSAvukat[i].SORUMLU_TIP;
                        returnValue.Add(bs);
                    }
                    break;

                case "AV001_TI_BIL_FOY":

                    //AV001_TI_BIL_FOY __________________________________

                    TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> lstSAvukat2 = new TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>();
                    lstSAvukat2 =
                        AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByICRA_FOY_ID(
                            kayitId);

                    for (int i = 0; i < lstSAvukat2.Count; i++)
                    {
                        AV001_TDI_BIL_CARI cri = new AV001_TDI_BIL_CARI();
                        cri =
                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                lstSAvukat2[i].SORUMLU_AVUKAT_CARI_ID.Value);
                        AV001_TDIE_BIL_BELGE_SORUMLU bs = new AV001_TDIE_BIL_BELGE_SORUMLU();
                        bs.CARI_ID = cri.ID;
                        bs.CARI_IDSource = cri;
                        bs.SORUMLU_TIP = lstSAvukat2[i].SORUMLU_TIP;
                        returnValue.Add(bs);
                    }
                    break;

                case "AV001_TD_BIL_HAZIRLIK":

                    //AV001_TD_BIL_FOY __________________________________
                    TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> lstSAvukat3 = new TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>();
                    lstSAvukat3 =
                        AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.GetByDAVA_FOY_ID(
                            kayitId);

                    for (int i = 0; i < lstSAvukat3.Count; i++)
                    {
                        AV001_TDI_BIL_CARI cri = new AV001_TDI_BIL_CARI();
                        cri =
                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                lstSAvukat3[i].SORUMLU_AVUKAT_CARI_ID.Value);
                        AV001_TDIE_BIL_BELGE_SORUMLU bs = new AV001_TDIE_BIL_BELGE_SORUMLU();
                        bs.CARI_ID = cri.ID;
                        bs.CARI_IDSource = cri;
                        bs.SORUMLU_TIP = lstSAvukat3[i].SORUMLU_TIP;
                        returnValue.Add(bs);
                    }
                    break;

                case "AV001_TD_BIL_RUCU":

                    //AV001_TD_BIL_FOY __________________________________
                    TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> lstSAvukat4 = new TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>();
                    lstSAvukat4 =
                        AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.GetByDAVA_FOY_ID(
                            kayitId);

                    for (int i = 0; i < lstSAvukat4.Count; i++)
                    {
                        AV001_TDI_BIL_CARI cri = new AV001_TDI_BIL_CARI();
                        cri =
                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                lstSAvukat4[i].SORUMLU_AVUKAT_CARI_ID.Value);
                        AV001_TDIE_BIL_BELGE_SORUMLU bs = new AV001_TDIE_BIL_BELGE_SORUMLU();
                        bs.CARI_ID = cri.ID;
                        bs.CARI_IDSource = cri;
                        bs.SORUMLU_TIP = lstSAvukat4[i].SORUMLU_TIP;
                        returnValue.Add(bs);
                    }
                    break;

                case "AV001_TD_BIL_SORUSTURMA":

                    //AV001_TD_BIL_FOY __________________________________
                    TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> lstSAvukat5 = new TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>();
                    lstSAvukat5 =
                        AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.GetByDAVA_FOY_ID(
                            kayitId);

                    for (int i = 0; i < lstSAvukat5.Count; i++)
                    {
                        AV001_TDI_BIL_CARI cri = new AV001_TDI_BIL_CARI();
                        cri =
                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(
                                lstSAvukat5[i].SORUMLU_AVUKAT_CARI_ID.Value);
                        AV001_TDIE_BIL_BELGE_SORUMLU bs = new AV001_TDIE_BIL_BELGE_SORUMLU();
                        bs.CARI_ID = cri.ID;
                        bs.CARI_IDSource = cri;
                        bs.SORUMLU_TIP = lstSAvukat5[i].SORUMLU_TIP;
                        returnValue.Add(bs);
                    }
                    break;

                default:

                    break;
            }

            return returnValue;
        }

        private HangiTaraf ConvertTarafSifatToHangiTaraf(string modul, string HangiTarafi)
        {
            switch (modul)
            {
                case "AV001_TD_BIL_FOY":
                    if (HangiTarafi == "DAVA EDEN")
                    {
                        return HangiTaraf.Eden;
                    }
                    else if (HangiTarafi == "DAVA EDİLEN")
                    {
                        return HangiTaraf.Edilen;
                    }
                    break;

                default:
                    break;
            }
            return HangiTaraf.None;
        }

        //5
        /// <summary>
        ///belge yi degerlerle doldurur
        /// </summary>
        private void FillBelgeWithValues()
        {
            try
            {
                belge.ESAS_NO = this.rows[0].Text;
                belge.ADLI_BIRIM_ADLIYE_ID = Convert.ToInt32(this.rows[1].Text);
                belge.ADLI_BIRIM_NO_ID = Convert.ToInt32(this.rows[2].Text);
                belge.ADLI_BIRIM_GOREV_ID = Convert.ToInt32(this.rows[3].Text);
                belge.OZEL_KOD_1_ID = Convert.ToInt32(this.rows[4].Text);
                belge.OZEL_KOD_2_ID = Convert.ToInt32(this.rows[5].Text);
                belge.OZEL_KOD_3_ID = Convert.ToInt32(this.rows[6].Text);
                belge.OZEL_KOD_4_ID = Convert.ToInt32(this.rows[7].Text);
                belge.ACIKLAMA = this.rows[4].Text;
            }
            catch 
            {
#warning ex;

                //TODO : Eror meror olabilir sonra bak...
            }
        }

        //3
        /// <summary>
        ///Modulun degerlerini alır...
        /// </summary>
        private void FillModulsValues()
        {
            for (int i = 0; i < this.rows.Count; i++)
            {
                object val = modul.GetType().GetProperty(this.rows[i].FieldName).GetValue(modul, null);
                this.rows[i].Value = val;
            }
        }

        //2
        /// <summary>
        ///Modul Tablosu Adına Gore Rowları Doldur
        /// </summary>
        private void FillRowsByModulsTable()
        {
            List<BelgeGenelBilgi> lstBilgiler = new List<BelgeGenelBilgi>();

            RowInfo rinfEsasNo = new RowInfo();
            rinfEsasNo.FieldName = "ESAS_NO";
            rinfEsasNo.Name = "ESAS_NO";

            RowInfo rinfAdliye = new RowInfo();
            rinfAdliye.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            rinfAdliye.Name = "ADLI_BIRIM_ADLIYE_ID";

            RowInfo rinfAdliBirimNo = new RowInfo();
            rinfAdliBirimNo.FieldName = "ADLI_BIRIM_NO_ID";
            rinfAdliBirimNo.Name = "ADLI_BIRIM_NO_ID";

            RowInfo rinfGorev = new RowInfo();
            rinfGorev.FieldName = "ADLI_BIRIM_GOREV_ID";
            rinfGorev.Name = "ADLI_BIRIM_GOREV_ID";

            RowInfo rinfOKod1 = new RowInfo();
            rinfOKod1.FieldName = "OZEL_KOD_1_ID";
            rinfOKod1.Name = "OZEL_KOD_1_ID";

            RowInfo rinfOKod2 = new RowInfo();
            rinfOKod2.FieldName = "OZEL_KOD_21_ID";
            rinfOKod2.Name = "OZEL_KOD_2_ID";

            RowInfo rinfOKod3 = new RowInfo();
            rinfOKod3.FieldName = "OZEL_KOD_3_ID";
            rinfOKod3.Name = "OZEL_KOD_3_ID";

            RowInfo rinfOKod4 = new RowInfo();
            rinfOKod4.FieldName = "OZEL_KOD_4_ID";
            rinfOKod4.Name = "OZEL_KOD_4_ID";

            RowInfo rinfAciklama = new RowInfo();
            rinfAciklama.FieldName = "ACIKLAMA";
            rinfAciklama.Name = "ACIKLAMA";

            //RowInfo rinfAvukat = new RowInfo();
            //rinfAvukat.FieldName = "AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection";
            //rinfAvukat.Name = "SORUMLU_AVUKAT_ID";

            RowInfoCollection lstRinf = new RowInfoCollection();
            lstRinf.Add(rinfEsasNo);
            lstRinf.Add(rinfAdliye);
            lstRinf.Add(rinfAdliBirimNo);
            lstRinf.Add(rinfGorev);
            lstRinf.Add(rinfOKod1);
            lstRinf.Add(rinfOKod2);
            lstRinf.Add(rinfOKod3);
            lstRinf.Add(rinfOKod4);
            lstRinf.Add(rinfAciklama);

            BelgeGenelBilgi belgeBilgisi = new BelgeGenelBilgi();
            switch (this.modulesTable)
            {
                case "AV001_TD_BIL_FOY":

                    //AV001_TD_BIL_FOY __________________________________

                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TD_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    this.rows = lstRinf;
                    break;

                case "AV001_TI_BIL_FOY":

                    //AV001_TI_BIL_FOY __________________________________

                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TI_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    this.rows = lstRinf;
                    break;

                case "AV001_TD_BIL_HAZIRLIK":

                    //AV001_TD_BIL_FOY __________________________________

                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TD_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    this.rows = lstRinf;
                    break;

                case "AV001_TD_BIL_RUCU":

                    //AV001_TD_BIL_FOY __________________________________

                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TD_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    this.rows = lstRinf;
                    break;

                case "AV001_TD_BIL_SORUSTURMA":

                    //AV001_TD_BIL_FOY __________________________________

                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TD_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    this.rows = lstRinf;
                    break;

                default:

                    break;
            }
        }

        //1
        /// <summary>
        /// Kayıt ın bulur doldurur
        /// </summary>
        private void GetModul()
        {
            List<Type> lstTypes = GetModules();
            for (int i = 0; i < lstTypes.Count; i++)
            {
                if (kayit.GetType().Name == lstTypes[i].Name)
                {
                    object idValue = kayit.GetType().GetProperty("ID").GetValue(kayit, null);
                    this.modul = GetModulesrecordById(Convert.ToInt32(idValue), lstTypes[i].Name);
                    this.modulesTable = modul.TableName;
                    return;
                }
            }
            PropertyInfo[] pinfs = this.kayit.GetType().GetProperties();
            for (int i = 0; i < pinfs.Length; i++)
            {
                for (int y = 0; y < lstTypes.Count; y++)
                {
                    if (pinfs[i].PropertyType.IsSubclassOf(lstTypes[y]))
                    {
                        object value =
                            this.kayit.GetType().GetProperty(pinfs[i].Name.Remove(pinfs[i].Name.Length - 6)).GetValue(
                                this.kayit, null);
                        if (value != null)
                        {
                            if (value is int)
                            {
                                this.modul = GetModulesrecordById(Convert.ToInt32(value), lstTypes[y].Name);
                                this.modulesTable = modul.TableName;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tum modul tiplerini ver
        /// </summary>
        /// <returns></returns>
        private List<Type> GetModules()
        {
            List<Type> returnValue = new List<Type>();
            returnValue.Add(typeof(AvukatProLib2.Entities.AV001_TI_BIL_FOY));
            returnValue.Add(typeof(AvukatProLib2.Entities.AV001_TD_BIL_FOY));
            returnValue.Add(typeof(AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK));

            return returnValue;
        }

        /// <summary>
        /// Module Gore Kaydı geitirir
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modtypeName"></param>
        private IEntity GetModulesrecordById(int id, string modtypeName)
        {
            switch (modtypeName)
            {
                case "AV001_TD_BIL_FOY":

                    // this.modul=((AV001_TD_BIL_FOY)Tablolar.GetListByTableNameAndId("AV001_TD_BIL_FOY",id));
                    break;

                case "AV001_TI_BIL_FOY":

                    // this.modul = ((AV001_TI_BIL_FOY)Tablolar.GetListByTableNameAndId("AV001_TI_BIL_FOY", id));
                    break;

                default:
                    break;
            }
            return this.modul;
        }

        //4
        /// <summary>
        /// Degerler uzerindeki son duzenlemeleri yap
        /// </summary>
        private void SetValues()
        {
            for (int i = 0; i < this.rows.Count; i++)
            {
                if (rows[i].Value != null)
                {
                    this.rows[i].Text = rows[i].Value.ToString();
                }
            }
        }
    }

    public class RowInfo
    {
        public string FieldName { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public object Value { get; set; }
    }

    public class RowInfoCollection
    {
        #region IList Members

        private object list = new object();

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public RowInfo this[int index]
        {
            get { return ((List<RowInfo>)list)[index]; }
            set { ((List<RowInfo>)list)[index] = value; }
        }

        public int Add(object value)
        {
            if (list == null || !(list is List<RowInfo>))
            {
                list = new List<RowInfo>();
            }
            ((List<RowInfo>)list).Add((RowInfo)value);
            return ((List<RowInfo>)list).Count;
        }

        public void Clear()
        {
        }

        public bool Contains(object value)
        {
            return false;
        }

        public int IndexOf(object value)
        {
            return 0;
        }

        public void Insert(int index, object value)
        {
            return;
        }

        public void Remove(object value)
        {
            return;
        }

        public void RemoveAt(int index)
        {
            return;
        }

        #endregion IList Members

        #region ICollection Members

        public int Count
        {
            get
            {
                if (this.list is List<RowInfo> && this.list != null)
                {
                    return ((List<RowInfo>)this.list).Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return new object(); }
        }

        public void CopyTo(Array array, int index)
        {
            return;
        }

        #endregion ICollection Members

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion IEnumerable Members
    }
}