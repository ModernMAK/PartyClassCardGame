using System;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace CardGames
{
    public static class DeckUtility
    {
        //DECK COPIER
        public static void CopyDeckContents<TI, TO>(IEnumerable<TI> source, ICollection<TO> dest, Func<TI, TO> createFunc)
        {
            foreach (var item in source)
                dest.Add(createFunc(item));
        }

        public static void CreateInstance<TI, TO>(this Deck<TI> deck, Deck<TO> dest) where TI : IInstancable<TO>
        {
            TO Func(TI i) => i.CreateInstance();
            CopyDeckContents(deck, dest, Func);
        }

        public static void DeepClone<T>(this Deck<T> deck, Deck<T> dest) where T : IDeepCloneable<T>
        {
            T Func(T i) => i.DeepClone();
            CopyDeckContents(deck, dest, Func);
        }

        public static void ShallowClone<T>(this Deck<T> deck, Deck<T> dest) where T : IShallowCloneable<T>
        {
            T Func(T i) => i.ShallowClone();
            CopyDeckContents(deck, dest, Func);
        }

        // DECK CLONERS
        public static Deck<TO> CreateNewDeck<TI, TO>(IList<TI> deck, Func<TI, TO> createFunc)
        {
            var cloned = new TO[deck.Count];
            for (var i = 0; i < deck.Count; i++)
                cloned[i] = createFunc(deck[i]);
            return new Deck<TO>(cloned);
        }

        public static Deck<TO> CreateInstance<TI, TO>(this Deck<TI> deck) where TI : IInstancable<TO>
        {
            TO Func(TI i) => i.CreateInstance();
            return CreateNewDeck(deck, Func);
        }

        public static Deck<T> DeepClone<T>(this Deck<T> deck) where T : IDeepCloneable<T>
        {
            T Func(T i) => i.DeepClone();
            return CreateNewDeck(deck, Func);
        }

        public static Deck<T> ShallowClone<T>(this Deck<T> deck) where T : IShallowCloneable<T>
        {
            T Func(T i) => i.ShallowClone();
            return CreateNewDeck(deck, Func);
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
                var j = UnityEngine.Random.Range(0, list.Count);
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
        public static void PushFirst<T>(this IList<T> list, T item) => list.Insert(0, item);
        public static void PushLast<T>(this IList<T> list, T item) => list.Add(item);
        public static void PushLast<T>(this IList<T> list, IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                list.PushLast(item);
            }
        }


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
        public static T PopLast<T>(this IList<T> list) => PopAt(list, list.Count-1);

        public static IEnumerable<T> PopClear<T>(this IList<T> list)
        {
            while (list.Count > 0)
                yield return list.PopFirst();
        }

        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            foreach (var i in items)
                list.Add(i);
        }
    }
}