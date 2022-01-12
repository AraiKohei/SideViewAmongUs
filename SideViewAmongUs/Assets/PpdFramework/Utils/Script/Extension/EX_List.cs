using System;
using System.Collections;
using System.Collections.Generic;

namespace PPD
{
    /// <summary>
    /// Linqは使用していません。
    /// </summary>
    public static class EX_List
    {
        public static bool ContainsIndex<T>(this IList<T> list, int i)
        => 0 <= i && i < list.Count;

        public static T ElementAtOrDefault<T>(this IList<T> list, int i)
        => list.ContainsIndex(i) ? list.ElementAtOrDefault(i) : default(T);

        public static int LastIndex<T>(this IList<T> list) => list.Count - 1;
        public static T First<T>(this IList<T> list) => list[0];
        public static T Last<T>(this IList<T> list) => list[list.LastIndex()];

        public static T RemoveHead<T>(this IList<T> list)
        {
            var ret = list[0];
            list.RemoveAt(0);
            return ret;
        }

        public static T RemoveTail<T>(this IList<T> list)
        {
            var ret = list.Last();
            list.RemoveAt(list.Count - 1);
            return ret;
        }

        public static void Shuffle_Fisher_Yates<T>(this IList<T> list)
        {
            var rng = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
