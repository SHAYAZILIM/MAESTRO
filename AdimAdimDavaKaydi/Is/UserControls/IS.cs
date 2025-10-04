using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using AdimAdimDavaKaydi.UserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Is.UserControls
{
    /// <summary>
    /// Belge Hakkındaki Genel Bilgiler
    /// </summary>
    public class IS
    {
        private int id;
        private AV001_TDI_BIL_IS isKaydi;
        private IEntity kayit;
        private int kayitId;
        private IEntity modul;
        private string modulesTable;
        private RowInfoCollection rows;

        public IS()
        {
            if (isKaydi == null)
            {
                isKaydi = new AV001_TDI_BIL_IS();
                isKaydi.STAMP = 0;
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_IS IsKaydi
        {
            get { return isKaydi; }
            set { isKaydi = value; }
        }

        [Browsable(false)]
        public IEntity Kayit
        {
            get { return kayit; }
            set { kayit = value; }
        }

        public int KayitID
        {
            get { return kayitId; }
            set { kayitId = value; }
        }
        
        public string ModulesTable
        {
            get { return modulesTable; }
            set { modulesTable = value; }
        }
        
        public string Table { get; set; }

        public AV001_TDI_BIL_IS ConvertRecordToIs(IEntity record)
        {
            kayit = record;
            GetModul();
            FillRowsByModulsTable();
            FillModulsValues();
            SetValues();
            FillIsWithValues();
            return IsKaydi;
        }

        public AV001_TDI_BIL_IS_TARAF ConvertTarafToIsTaraf(IEntity tarafi)
        {
            var sonucTaraf = new AV001_TDI_BIL_IS_TARAF();
            switch (tarafi.TableName)
            {
                case "AV001_TD_BIL_FOY_TARAF":
                    sonucTaraf.CARI_ID = ((AV001_TD_BIL_FOY_TARAF)tarafi).CARI_ID;
                    TDIE_KOD_TARAF_SIFAT sifat =
                        DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(
                            ((AV001_TD_BIL_FOY_TARAF)tarafi).TARAF_SIFAT_ID.Value);
                    if (sifat.HANGI_TARAFI == "DAVA EDEN")
                    {
                        sonucTaraf.IS_TARAF_ID = 1;
                    }
                    if (sifat.HANGI_TARAFI == "DAVA EDİLEN")
                    {
                        sonucTaraf.IS_TARAF_ID = 3;
                    }

                    break;

                case "AV001_TI_BIL_FOY_TARAF":
                    sonucTaraf.CARI_ID = ((AV001_TI_BIL_FOY_TARAF)tarafi).CARI_ID;
                    sifat =
                        DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(
                            ((AV001_TI_BIL_FOY_TARAF)tarafi).TARAF_SIFAT_ID);
                    if (sifat.HANGI_TARAFI == "TAKİP EDEN")
                    {
                        sonucTaraf.IS_TARAF_ID = 1;
                    }
                    if (sifat.HANGI_TARAFI == "TAKİP EDİLEN")
                    {
                        sonucTaraf.IS_TARAF_ID = 3;
                    }
                    break;
                default:
                    break;
            }

            return sonucTaraf;
        }
                
        //5
        /// <summary>
        ///belge yi degerlerle doldurur
        /// </summary>
        private void FillIsWithValues()
        {
            try
            {
                //                isKaydi.OZEL_KOD_1_ID = Convert.ToInt32(this.rows[4].Text);
                //isKaydi.OZEL_KOD_2_ID = Convert.ToInt32(this.rows[5].Text);
                //isKaydi.OZEL_KOD_3_ID = Convert.ToInt32(this.rows[6].Text);
                //isKaydi.OZEL_KOD_4_ID = Convert.ToInt32(this.rows[7].Text);isKaydi.ESAS_NO = this.rows[0].Text;

                isKaydi.ADLI_BIRIM_ADLIYE_ID = Convert.ToInt32(rows[1].Text);
                isKaydi.ADLI_BIRIM_NO_ID = Convert.ToInt32(rows[2].Text);
                isKaydi.ADLI_BIRIM_GOREV_ID = Convert.ToInt32(rows[3].Text);

                isKaydi.ACIKLAMA = rows[4].Text;
            }
            catch 
            {
                //#warning ex;
                //TODO : Eror meror olabilir sonra bak...
            }
        }

        //3
        /// <summary>
        ///Modulun degerlerini alır...
        /// </summary>
        private void FillModulsValues()
        {
            for (int i = 0; i < rows.Count; i++)
            {
                object val = modul.GetType().GetProperty(rows[i].FieldName).GetValue(modul, null);
                rows[i].Value = val;
            }
        }

        //2
        /// <summary>
        ///Modul Tablosu Adına Gore Rowları Doldur
        /// </summary>
        private void FillRowsByModulsTable()
        {
            var lstBilgiler = new List<BelgeGenelBilgi>();

            var rinfEsasNo = new RowInfo();
            rinfEsasNo.FieldName = "ESAS_NO";
            rinfEsasNo.Name = "ESAS_NO";

            var rinfAdliye = new RowInfo();
            rinfAdliye.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            rinfAdliye.Name = "ADLI_BIRIM_ADLIYE_ID";

            var rinfAdliBirimNo = new RowInfo();
            rinfAdliBirimNo.FieldName = "ADLI_BIRIM_NO_ID";
            rinfAdliBirimNo.Name = "ADLI_BIRIM_NO_ID";

            var rinfGorev = new RowInfo();
            rinfGorev.FieldName = "ADLI_BIRIM_GOREV_ID";
            rinfGorev.Name = "ADLI_BIRIM_GOREV_ID";

            var rinfAciklama = new RowInfo();
            rinfAciklama.FieldName = "ACIKLAMA";
            rinfAciklama.Name = "ACIKLAMA";

            var lstRinf = new RowInfoCollection();
            lstRinf.Add(rinfEsasNo);
            lstRinf.Add(rinfAdliye);
            lstRinf.Add(rinfAdliBirimNo);
            lstRinf.Add(rinfGorev);
            lstRinf.Add(rinfAciklama);

            var belgeBilgisi = new BelgeGenelBilgi();
            switch (modulesTable)
            {
                case "AV001_TD_BIL_FOY":

                    //AV001_TD_BIL_FOY __________________________________
                    //    isKaydi.DAVA_FOY_ID = this.id;
                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TD_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    rows = lstRinf;
                    break;

                case "AV001_TI_BIL_FOY":

                    //AV001_TI_BIL_FOY __________________________________
                    //   isKaydi.ICRA_FOY_ID = this.id;
                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TI_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    rows = lstRinf;
                    break;

                case "AV001_TD_BIL_HAZIRLIK":

                    //AV001_TD_BIL_FOY __________________________________
                    // isKaydi.HAZIRLIK_ID = this.id;
                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TD_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    rows = lstRinf;
                    break;

                case "AV001_TD_BIL_RUCU":

                    //AV001_TD_BIL_FOY __________________________________
                    //  isKaydi.RUCU_ID = this.id;
                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TD_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    rows = lstRinf;
                    break;

                case "AV001_TD_BIL_SORUSTURMA":

                    //AV001_TD_BIL_FOY __________________________________
                    // isKaydi.HAZIRLIK_ID = this.id;
                    belgeBilgisi.Rows = lstRinf;
                    belgeBilgisi.Table = "AV001_TD_BIL_FOY";
                    lstBilgiler.Add(belgeBilgisi);
                    rows = lstRinf;
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
                    modul = GetModulesrecordById(Convert.ToInt32(idValue), lstTypes[i].Name);
                    modulesTable = modul.TableName;
                    id = (int)idValue;
                    return;
                }
            }
            PropertyInfo[] pinfs = kayit.GetType().GetProperties();
            for (int i = 0; i < pinfs.Length; i++)
            {
                for (int y = 0; y < lstTypes.Count; y++)
                {
                    if (pinfs[i].PropertyType.IsSubclassOf(lstTypes[y]))
                    {
                        object value =
                            kayit.GetType().GetProperty(pinfs[i].Name.Remove(pinfs[i].Name.Length - 6)).GetValue(kayit,
                                                                                                                 null);
                        if (value != null)
                        {
                            if (value is int)
                            {
                                modul = GetModulesrecordById(Convert.ToInt32(value), lstTypes[y].Name);
                                modulesTable = modul.TableName;
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
            var returnValue = new List<Type>();
            returnValue.Add(typeof(AV001_TI_BIL_FOY));
            returnValue.Add(typeof(AV001_TD_BIL_FOY));
            returnValue.Add(typeof(AV001_TD_BIL_HAZIRLIK));

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
                    modul = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(id);
                    break;

                case "AV001_TI_BIL_FOY":
                    modul = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(id);
                    break;
                default:
                    break;
            }
            return modul;
        }

        //4
        /// <summary>
        /// Degerler uzerindeki son duzenlemeleri yap
        /// </summary>
        private void SetValues()
        {
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Value != null)
                {
                    rows[i].Text = rows[i].Value.ToString();
                }
            }
        }
    }
}