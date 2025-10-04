using System;
using System.Collections;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public interface IChildItem<P> where P : class
    {
        P Parent { get; set; }
    }

    [Serializable]
    public class ChildItemCollection<P, T> : IList<T>, IEnumerable<T>, ICollection<T>, IList
        where P : class
        where T : IChildItem<P>
    {
        private IList<T> _collection;
        private P _parent;

        public ChildItemCollection(P parent)
        {
            this._parent = parent;
            this._collection = new List<T>();
        }

        public ChildItemCollection(P parent, IList<T> collection)
        {
            this._parent = parent;
            this._collection = collection;
        }

        object IList.this[int index]
        {
            get
            {
                return _collection[index];
            }
            set
            {
                T oldItem = _collection[index];
                if (value != null)
                    ((T)value).Parent = _parent;
                _collection[index] = (T)value;
                if (oldItem != null)
                    oldItem.Parent = null;
            }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public int Add(object value)
        {
            this.Add((T)value);
            return _collection.Count - 1;
        }

        public bool Contains(object value)
        {
            return this.Contains((T)value);
        }

        public void CopyTo(System.Array array, int index)
        {
            this.CopyTo((T[])array, index);
        }

        public int IndexOf(object value)
        {
            return this.IndexOf((T)value);
        }

        public void Insert(int index, object value)
        {
            this.Insert(index, (T)value);
        }

        public void Remove(object value)
        {
            this.Remove((T)value);
        }

        public void SetParent(P parent)
        {
            //if (parentSet)
            //    return;
            _parent = parent;
            foreach (var item in _collection)
            {
                item.Parent = _parent;
            }
        }

        public void SetParent(P parent, bool isset)
        {
            _parent = parent;
            foreach (var item in _collection)
            {
                item.Parent = _parent;
            }
        }

        #region IList<T> Members

        public T this[int index]
        {
            get
            {
                return _collection[index];
            }
            set
            {
                T oldItem = _collection[index];
                if (value != null)
                    value.Parent = _parent;
                _collection[index] = value;
                if (oldItem != null)
                    oldItem.Parent = null;
            }
        }

        public int IndexOf(T item)
        {
            return _collection.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (item != null)
                item.Parent = _parent;
            _collection.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            T oldItem = _collection[index];
            _collection.RemoveAt(index);
            if (oldItem != null)
                oldItem.Parent = null;
        }

        #endregion IList<T> Members

        #region ICollection<T> Members

        public int Count
        {
            get { return _collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return _collection.IsReadOnly; }
        }

        public void Add(T item)
        {
            if (item != null)
                item.Parent = _parent;
            _collection.Add(item);
        }

        public void Clear()
        {
            foreach (T item in _collection)
            {
                if (item != null)
                    item.Parent = null;
            }
            _collection.Clear();
        }

        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            bool b = _collection.Remove(item);
            if (item != null)
                item.Parent = null;
            return b;
        }

        #endregion ICollection<T> Members

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        #endregion IEnumerable<T> Members

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (_collection as System.Collections.IEnumerable).GetEnumerator();
        }

        #endregion IEnumerable Members
    }
}