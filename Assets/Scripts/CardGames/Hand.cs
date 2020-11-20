using System.Collections;
using System.Collections.Generic;

namespace CardGames
{
    public class Hand<T> : ListWrapper<T>
    {

        public Hand(IEnumerable<T> items = null) : base(items)
        {
        }
    }
}