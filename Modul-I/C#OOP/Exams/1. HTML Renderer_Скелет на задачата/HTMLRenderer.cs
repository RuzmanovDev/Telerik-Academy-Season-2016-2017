using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HTMLTable(rows, cols);
        }
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            IElementFactory htmlFactory = new HTMLElementFactory();
            IElement html = htmlFactory.CreateElement("html");
            IElement h1 = htmlFactory.CreateElement("h1", "Welcome!");
            html.AddElement(h1);
            Console.WriteLine(html);
            ITable table = htmlFactory.CreateTable(3, 2);
            table[0, 0] = htmlFactory.CreateElement("b", "First Name");
            table[0, 1] = htmlFactory.CreateElement("b", "Last Name");
            table[1, 0] = htmlFactory.CreateElement(null, "Svetlin");
            table[1, 1] = htmlFactory.CreateElement(null, "Nakov");
            table[2, 0] = htmlFactory.CreateElement(null, "George");
            table[2, 1] = htmlFactory.CreateElement(null, "Georgiev");
            html.AddElement(table);
            IElement br = htmlFactory.CreateElement("br", null);
            html.AddElement(br);
            IElement div = htmlFactory.CreateElement("div",
              "(c) Nakov & Joro @ <Telerik Software Academy>");
            html.AddElement(div);
            Console.WriteLine(html);

        }
    }
}
