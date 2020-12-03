using System.Collections;
using System.Collections.Generic;

namespace CardGames
{
    public class Hand<T> : EventList<T>
    {
        public Hand() : base() { }
        public Hand(IEnumerable<T> items) : base(items) { }
    }
}