using System;
using System.Collections.Generic;
using Core;

namespace CardGames
{
    public static class DeckUtility
    {
        // DECK COPIERS
        private static Deck<O> CreateNewDeck<I, O>(Deck<I> deck, Func<I, O> createFunc)
        {
            
            var cloned = new O[deck.Count];
            for (var i = 0; i < deck.Count; i++)
                cloned[i] = createFunc(deck[i]);
            return new Deck<O>(cloned);
        }

        public static Deck<U> CreateInstance<T, U>(this Deck<T> deck) where T : IInstancable<U>
        {
            U Func(T i) => i.CreateInstance();
            return CreateNewDeck<T,U>(deck, Func);
        }

        public static Deck<T> DeepClone<T>(this Deck<T> deck) where T : IDeepCloneable<T>
        {
            T Func(T i) => i.DeepClone();
            return CreateNewDeck<T,T>(deck, Func);
        }
        public static Deck<T> ShallowClone<T>(this Deck<T> deck) where T : IShallowCloneable<T>
        {
            T Func(T i) => i.ShallowClone();
            return CreateNewDeck<T,T>(deck, Func);
        }
        
        // SHUFFLES
        public static void SystemShuffle<T>(this IList<T> list, System.Random random)
        {
            T temp;
            for (var i = 0; i < list.Count; i++)
            {
                var j = random.Next(list.Count);
                temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        public static void UnityShuffle<T>(this IList<T> list)
        {   
            T temp;
            for (var i = 0; i < list.Count; i++)
            {
                var j = UnityEngine.Random.Range(0,list.Count);
                temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        public static void UnityShuffle<T>(this IList<T> list, UnityEngine.Random.State random)
        {
            var temp = UnityEngine.Random.state;
            UnityEngine.Random.state = random;
            UnityShuffle(list);
            UnityEngine.Random.state = temp;
        }
        
        
        // PUSH
        public static void PushFirst<T>(this IList<T> list,T item) => list.Insert(0, item);
        public static void PushLast<T>(this IList<T> list, T item) => list.Add(item);
        
        
        // POP
        public static T PopAt<T>(this IList<T> list, int index)
        {
            var item = list[index];
            list.RemoveAt(index);
            return item;
        }
        public static T PopFind<T>(this IList<T> list, T search)
        {
            var index = list.IndexOf(search);
            return PopAt(list, index);
        }
        public static T PopFirst<T>(this IList<T> list) => PopAt(list, 0);
        public static T PopLast<T>(this IList<T> list)=> PopAt(list, list.Count);
    }
}