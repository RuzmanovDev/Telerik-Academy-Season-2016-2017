using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class HTMLElement : AbstractElement, IElement
    {
        public HTMLElement(string name) 
            : base(name)
        {
        }

        public HTMLElement(string name, string content) 
            : base(name, content)
        {
        }
    }
}
