using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class HTMLTable : AbstractElement, ITable
    {
        private int rows;
        private int cols;
        private IElement[,] elements;

        public HTMLTable(int rows, int cols) 
            : base()
        {
            this.Rows = rows;
            this.Cols = cols;
            elements = new IElement[rows, cols];
        }

        public HTMLTable(string name) : base(name)
        {
        }

        public HTMLTable(string name, string content) : base(name, content)
        {
        }

        public IElement this[int row, int col]
        {
            get
            {
              return  this.elements[row, col];
            }

            set
            {
                this.elements[row, col] = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                this.cols = value;
            }
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                this.rows = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", base.Name);
            for (int r = 0; r < this.elements.GetLength(0); r++)
            {
                output.Append("<tr>");
                for (int c = 0; c < this.elements.GetLength(1); c++)
                {
                    output.AppendFormat("<td>{0}</td>",
                        this.elements[r, c]);
                }
                output.Append("</tr>");
            }

            output.AppendFormat("</{0}>", base.Name);

        }

    
    }
}
