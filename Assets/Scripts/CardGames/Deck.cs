using System.Collections.Generic;
using System.Resources;
using UnityEngine;


namespace CardGames
{
    public class Deck<T> : ListWrapper<T>
    {
        public Deck(IEnumerable<T> items = null) : base(items)
        {
        }
        
        /// <summary>
        /// Draws the item at the specific index
        /// </summary>
        /// <param name="index">The index of the item in the deck.</param>
        /// <returns>The item at the given index.</returns>
        public T Draw(int index = 0) => this.PopAt(index);

        /// <summary>
        /// Draws the given item from the deck.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>The first item in the deck that matches the given item.</returns>
        public T Draw(T item) => this.PopFind(item);

    }
}