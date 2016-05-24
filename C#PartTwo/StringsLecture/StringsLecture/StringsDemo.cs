namespace StringsLecture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StringsDemo
    {
        static T Min<T>(T[] objects)
            where T : IComparable
        {
            T min = objects[0];

            foreach (var next in objects)
            {
                if (min.CompareTo(next) > 0)
                {
                    min = next;
                }
            }
            return min;
        }

        static void Main(string[] args)
        {
            /*  immutable type - не се променя, създава се нов обект всеки път
             *  стринговете се пазят в managed heap
             *  .Length се попълва при създаването на стринга
             *  
             *  стрнига прилича на масив НО не е масив!!!
             *  
             *  string name с малка буква
             *  
             *  MSIL, CIL ,IL Microsoft intermidiate language
             *  
             *  float = Single IL
             *  string default value = null;
             *  
             *  Nullable<int> = int ? --- референтен тип
             *  
             *  string.Compare(sr1, sr2 ,true); лексикографски нарастващ ред ( Азбучен ред )
             *  
             *  == трябва да се имплементира за всеки тип .Equals е стандартния начин за сравнение .Equals идва от object
             *  
             *  SB appendva символ по символ baba=> b a b a 
             *  
             */
        }
    }
}
