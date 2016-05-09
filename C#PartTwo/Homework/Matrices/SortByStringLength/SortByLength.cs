namespace SortByStringLength
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SortByLength
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(new char[] { ' ', ' ' }, StringSplitOptions.RemoveEmptyEntries);

             var sorted = Sort(text);

             // var sorted = text.OrderBy(t => t.Length);
            foreach (var word in sorted)
            {
                Console.WriteLine(word);
            }
        }
        private static IEnumerable<string> Sort(IEnumerable<string> text)
        {
            var sorted = from s in text
                         orderby s.Length ascending
                         select s;
            return sorted;
        }
    }
}