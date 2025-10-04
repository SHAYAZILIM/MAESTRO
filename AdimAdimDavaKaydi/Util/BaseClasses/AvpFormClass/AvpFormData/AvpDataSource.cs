using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil;

namespace AdimAdimDavaKaydi.Util.BaseClasses.AvpFormData
{
    [Serializable]
    public class AvpDataSource
    {
        public event OnVeriEkleme VeriEklendi;
        public event OnVeriEkleme VeriEklenecek;

        private List<AvpDatas> _datas;

        public virtual List<AvpDatas> Datas
        {
            get { return _datas; }
            set { _datas = value; }
        }

        private List<AvpDatas> _selectedDatas;

        public List<AvpDatas> SelectedDatas
        {
            get { return _selectedDatas; }
            set { _selectedDatas = value; }
        }

        public virtual void AddToDatas(IBindingList data, Control dataOwner)
        {
            AvpDatas datas = new AvpDatas();
            datas.Datas = data;
            AvpFormDataEventArgs e = new AvpFormDataEventArgs();
            e.Data = datas;
            if (VeriEklenecek != null)
            {
                VeriEklenecek(this, e);
            }

            if (data.Count > 0)
            {
                if (data[0] is AvukatProLib2.Entities.IEntity)
                {
                    datas.Table = ((AvukatProLib2.Entities.IEntity)data[0]).TableName;
                }
            }

            datas.DataSourceOwner = dataOwner;
            if (this.Datas == null)
            {
                this.Datas = new List<AvpDatas>();
            }
            this.Datas.Add(datas);
            if (VeriEklendi != null)
            {
                VeriEklendi(this, e);
            }
        }
    }
}