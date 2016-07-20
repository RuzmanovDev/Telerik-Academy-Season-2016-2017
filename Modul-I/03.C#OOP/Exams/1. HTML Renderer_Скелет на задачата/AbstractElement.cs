using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class AbstractElement : IElement
    {
        private string name;
        protected ICollection<IElement> childElements;
        private string textContent;

        public AbstractElement()
        {
            this.childElements = new List<IElement>();
        }
        public AbstractElement(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public AbstractElement(string name,string content)
        {
            this.Name = name;
            this.TextContent = content;
            this.childElements = new List<IElement>();
        }

        public virtual IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                this.name = value;
            }
        }

        public virtual string TextContent
        {
            get
            {
                return this.textContent;
            }

            set
            {
                this.textContent = value;
            }
        }

        public virtual void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            // <(name)>(text_content)(child_content)</(name)>
            output.AppendLine(string.Format("<{0}>{1}{2}</{3}>", this.Name,
               this.textContent!=null? this.TextContent
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("&", "&amp;")
                : ""
                , string.Join("", this.childElements), this.Name));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            this.Render(sb);

            return sb.ToString().Trim();
        }
    }
}