using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    public class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public ListItem<T> Next { get; set; }
    }
}
