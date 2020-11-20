using System.Collections;
using System.Collections.Generic;

namespace CardGames
{
    public class Hand<T> : IList<T>
    {
        private readonly List<T> _internal;

        public Hand(IEnumerable<T> items = null)
        {
            _internal = new List<T>(items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _internal.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _internal).GetEnumerator();
        }

        public void Add(T item)
        {
            _internal.Add(item);
        }

        public void Clear()
        {
            _internal.Clear();
        }

        public bool Contains(T item)
        {
            return _internal.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _internal.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _internal.Remove(item);
        }

        public int Count => _internal.Count;

        public bool IsReadOnly => ((IList<T>) _internal).IsReadOnly;

        public int IndexOf(T item)
        {
            return _internal.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _internal.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _internal.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _internal[index];
            set => _internal[index] = value;
        }
    }
}