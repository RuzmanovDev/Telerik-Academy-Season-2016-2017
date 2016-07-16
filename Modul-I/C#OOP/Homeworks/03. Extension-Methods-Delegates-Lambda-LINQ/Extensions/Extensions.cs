namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Extensions
    {
        // Problem 1. StringBuilder.Substring
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            string text = sb.ToString();

            return new StringBuilder(text.Substring(index, length));
        }

        // Problem 2. IEnumerable extensions
        public static dynamic Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = default(T);

            foreach (var item in collection)
            {
                sum += item;
            }

            return sum;
        }

        public static dynamic Average<T>(this IEnumerable<T> collection)
        {
            dynamic average = default(T);

            average = collection.Sum() / (dynamic)collection.Length();

            return average;
        }

        public static int Length<T>(this IEnumerable<T> collection)
        {
            int length = 0;

            foreach (var item in collection)
            {
                length += 1;
            }

            return length;
        }

        public static dynamic Product<T>(this IEnumerable<T> collection)
        {
            dynamic product = 1;

            foreach (var item in collection)
            {
                product *= item;
            }

            return product;
        }

        public static dynamic Min<T>(this IEnumerable<T> collection)
            where T : IComparable<T>
        {
            dynamic min = long.MaxValue;
            foreach (var item in collection)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static dynamic Max<T>(this IEnumerable<T> collection)
            where T : IComparable<T>
        {
            dynamic max = long.MinValue;
            foreach (var item in collection)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }

        private static int MaxValue(int dummy)
        {
            return int.MaxValue;
        }

        private static double MaxValue(double dummy)
        {
            return double.MaxValue;
        }
    }
}
