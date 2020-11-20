using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

namespace CardGames
{
    public class Deck<T> : IList<T>
    {
        private readonly List<T> _internal;

        public Deck(IEnumerable<T> items = null)
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

        /// <summary>
        /// Draws the item at the specific index
        /// </summary>
        /// <param name="index">The index of the item in the deck.</param>
        /// <returns>The item at the given index.</returns>
        public T Draw(int index = 0)
        {
            var item = this[index];
            RemoveAt(index);
            return item;
        }

        /// <summary>
        /// Draws the given item from the deck.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>The first item in the deck that matches the given item.</returns>
        /// <exception cref="KeyNotFoundException">If the item is not found in the deck.</exception>
        public T Draw(T item)
        {
            const int IndexOfFailed = -1;
            var index = IndexOf(item);
            if (index == IndexOfFailed)
                throw new KeyNotFoundException("Item not in deck!");
            return Draw(index);
        }

        public void InsertTop(T item) => Insert(0, item);
        public void InsertBottom(T item) => Add(item);

        public void Shuffle(System.Random random)
        {
            T temp;
            for (var i = 0; i < Count; i++)
            {
                var j = random.Next(Count);
                temp = this[i];
                this[i] = this[j];
                this[j] = temp;
            }
        }

        
    }
}