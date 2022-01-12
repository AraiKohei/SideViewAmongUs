using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace PPD
{
    public static class EX_Array
    {
        // 自作
        public static bool ContainsIndex<T>(this T[] array, int i)
        => 0 <= i && i < array.Length;
        public static T ElementAtOrDefault<T>(this T[] array, int i)
        => array.ContainsIndex(i) ? array[i] : default(T);

        // ArrayUtil
        public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] array)
        => Array.AsReadOnly(array);
        public static int BinarySearch<T>(this T[] array, T value, IComparer<T> comparer)
        => Array.BinarySearch(array, value, comparer);
        public static int BinarySearch<T>(this T[] array, T value)
        => Array.BinarySearch(array, value);
        public static int BinarySearch<T>(this T[] array, int index, int length, T value)
        => Array.BinarySearch(array, index, length, value);
        public static int BinarySearch<T>(this T[] array, int index, int length, T value, IComparer<T> comparer)
        => Array.BinarySearch(array, index, length, value, comparer);
        public static bool Exists<T>(this T[] array, Predicate<T> match)
        => Array.Exists(array, match);
        public static T Find<T>(this T[] array, Predicate<T> match)
        => Array.Find(array, match);
        public static T[] FindAll<T>(this T[] array, Predicate<T> match)
        => Array.FindAll(array, match);
        public static int FindIndex<T>(this T[] array, int startIndex, int count, Predicate<T> match)
        => Array.FindIndex(array, startIndex, count, match);
        public static int FindIndex<T>(this T[] array, int startIndex, Predicate<T> match)
        => Array.FindIndex(array, startIndex, match);
        public static int FindIndex<T>(this T[] array, Predicate<T> match)
        => Array.FindIndex(array, match);
        public static T FindLast<T>(this T[] array, Predicate<T> match)
        => Array.FindLast(array, match);
        public static int FindLastIndex<T>(this T[] array, int startIndex, int count, Predicate<T> match)
        => Array.FindLastIndex(array, startIndex, count, match);
        public static int FindLastIndex<T>(this T[] array, int startIndex, Predicate<T> match)
        => Array.FindLastIndex(array, startIndex, match);
        public static int FindLastIndex<T>(this T[] array, Predicate<T> match)
        => Array.FindLastIndex(array, match);
        public static void ForEach<T>(this T[] array, Action<T> action)
        => Array.ForEach(array, action);
        public static int IndexOf<T>(this T[] array, T value, int startIndex, int count)
        => Array.IndexOf(array, value, startIndex, count);
        public static int IndexOf<T>(this T[] array, T value, int startIndex)
        => Array.IndexOf(array, value, startIndex);
        public static int IndexOf<T>(this T[] array, T value)
        => Array.IndexOf(array, value);
        public static int LastIndexOf<T>(this T[] array, T value, int startIndex, int count)
        => Array.LastIndexOf(array, value, startIndex, count);
        public static int LastIndexOf<T>(this T[] array, T value, int startIndex)
        => Array.LastIndexOf(array, value, startIndex);
        public static int LastIndexOf<T>(this T[] array, T value)
        => Array.LastIndexOf(array, value);
        public static void Sort<T>(this T[] array, Comparison<T> comparison)
        => Array.Sort(array, comparison);
        public static void Sort<T>(this T[] array, int index, int length, IComparer<T> comparer)
        => Array.Sort(array, index, length, comparer);
        public static void Sort<T>(this T[] array, int index, int length)
        => Array.Sort(array, index, length);
        public static void Sort<T>(this T[] array, IComparer<T> comparer)
        => Array.Sort(array, comparer);
        public static void Sort<T>(this T[] array)
        => Array.Sort(array);
        public static bool TrueForAll<T>(this T[] array, Predicate<T> match)
        => Array.TrueForAll(array, match);
    }
}
