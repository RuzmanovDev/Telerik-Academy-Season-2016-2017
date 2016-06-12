namespace Exercises_5_7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            var list = new MyList<int>();
            var secondList = new MyList<int>(22);
            list.Add(5);
            list.Add(3);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.RemoveAt(2);
            list.RemoveAt(2);
            list.RemoveAt(2);
            list.Remove(4);

            Console.WriteLine(list.Capacity);
            Console.WriteLine(list.Count);
            Console.WriteLine(list);
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());

            // version attribute usage (Last Problem)
            Type type = typeof(MyList<int>);
            object[] attr = type.GetCustomAttributes(false);
            foreach (var item in attr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
