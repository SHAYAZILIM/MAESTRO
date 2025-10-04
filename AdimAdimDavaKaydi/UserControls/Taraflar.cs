using System;
using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public class Taraflar : IEntity
    {
        public int Id { get; set; }

        public string Table { get; set; }

        public int CARI_ID { get; set; }

        public int TARAF_SIFAT_ID { get; set; }

        public bool YETKILI_MI { get; set; }

        public string Ad { get; set; }

        public string Kod { get; set; }

        public HangiTaraf HangiTarafi { get; set; }

        #region IEntity Members

        public void AcceptChanges()
        {
        }

        public EntityState EntityState
        {
            get { return EntityState.Unchanged; }
        }

        public string EntityTrackingKey
        {
            get { return ""; }
            set { }
        }

        public bool IsDeleted
        {
            get { return false; }
        }

        public bool IsDirty
        {
            get { return false; }
        }

        public bool IsEntityTracked
        {
            get { return false; }
            set { }
        }

        public bool IsNew
        {
            get { return true; }
        }

        public bool IsValid
        {
            get { return true; }
        }

        public void MarkToDelete()
        {
        }

        public object ParentCollection { get; set; }

        public string[] TableColumns
        {
            get { return new[] { "", "" }; }
        }

        public string TableName
        {
            get { return ""; }
        }

        public object Tag { get; set; }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TarafCollection
    {
        private object taraflar;

        #region IList Members

        public int Add(object value)
        {
            if (taraflar == null)
            {
                taraflar = new TList<Taraflar>();
            }

            ((TList<Taraflar>)taraflar).Add((Taraflar)value);
            return ((TList<Taraflar>)taraflar).Count;
        }

        public void AddRange(TList<Taraflar> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                this.Add(lst[i]);
            }
        }

        public void AddRange(TarafCollection col)
        {
            for (int i = 0; i < col.Count; i++)
            {
                this.Add(col[i]);
            }
        }

        public void Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Taraflar this[int index]
        {
            get { return ((TList<Taraflar>)taraflar)[index]; }
            set
            {
                if (value == null)
                {
                    return;
                }
                ((TList<Taraflar>)taraflar)[index] = value;
            }
        }

        #endregion

        #region ICollection Members

        public int Count
        {
            get
            {
                if (taraflar == null)
                {
                    return 0;
                }
                return ((TList<Taraflar>)taraflar).Count;
            }
        }

        #endregion
    }

    public enum HangiTaraf
    {
        Eden,
        Edilen,
        Sorumlu,
        None
    }
}