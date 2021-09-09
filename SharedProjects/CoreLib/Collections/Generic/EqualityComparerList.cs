using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mohammad.Collections.Generic
{
    public class EqualityComparerList<TItem, TIdentity> : IList<TItem>
    {
        private readonly Func<TItem, TIdentity, bool> _Predicator;
        private readonly List<TItem> _Repository;
        public IEnumerable<TItem> this[TIdentity identity] { get { return this._Repository.Where(item => this._Predicator(item, identity)); } }

        public EqualityComparerList(Func<TItem, TIdentity, bool> predicator)
        {
            this._Predicator = predicator;
            this._Repository = new List<TItem>();
        }

        public EqualityComparerList(int capacity, Func<TItem, TIdentity, bool> predicator)
        {
            this._Predicator = predicator;
            this._Repository = new List<TItem>(capacity);
        }

        public EqualityComparerList(IEnumerable<TItem> collection, Func<TItem, TIdentity, bool> predicator)
        {
            this._Predicator = predicator;
            this._Repository = new List<TItem>(collection);
        }

        public int RemoveAll(TIdentity identity) { return this._Repository.RemoveAll(item => this._Predicator(item, identity)); }

        public int IndexOf(TIdentity identity)
        {
            for (var index = 0; index < this._Repository.Count; index++)
                if (this._Predicator(this._Repository[index], identity))
                    return index;
            return -1;
        }

        public bool Contains(TIdentity identity) { return this._Repository.Any(item => this._Predicator(item, identity)); }
        public TItem this[int index] { get { return this._Repository[index]; } set { this._Repository[index] = value; } }
        public int Count { get { return this._Repository.Count; } }
        bool ICollection<TItem>.IsReadOnly { get { return false; } }
        public IEnumerator<TItem> GetEnumerator() { return this._Repository.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
        public void Add(TItem item) { this._Repository.Add(item); }
        public void Clear() { this._Repository.Clear(); }
        public bool Contains(TItem item) { return this._Repository.Contains(item); }
        public void CopyTo(TItem[] array, int arrayIndex) { this._Repository.CopyTo(array, arrayIndex); }
        public bool Remove(TItem item) { return this._Repository.Remove(item); }
        public int IndexOf(TItem item) { return this._Repository.IndexOf(item); }
        public void Insert(int index, TItem item) { this._Repository.Insert(index, item); }
        public void RemoveAt(int index) { this._Repository.RemoveAt(index); }
    }
}