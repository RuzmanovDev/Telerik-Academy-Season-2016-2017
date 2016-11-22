using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    class Startup
    {
        static void Main(string[] args)
        {
           
            var linkedList = new MyLinkedList<int>(2);

            linkedList.Append(new ListItem<int>(3));
            linkedList.Append(new ListItem<int>(3));
            linkedList.Append(new ListItem<int>(3));
            linkedList.Append(new ListItem<int>(3));
            linkedList.Prepend(new ListItem<int>(123));
            linkedList.Prepend(new ListItem<int>(123));
            linkedList.Prepend(new ListItem<int>(123));
            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            Console.WriteLine(linkedList.ToString());


        }
    }
}
