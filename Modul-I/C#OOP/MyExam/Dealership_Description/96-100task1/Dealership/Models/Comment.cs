using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string author;
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                this.author = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                Validator.ValidateNull(value, "Content canno be null");
                this.content = value;
            }
        }

        public override string ToString()
        {
            // ----------
            //Unikalen motor pichove
            //  User: pesho
            //----------
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("    {0}",new string('-', 10)));
            builder.AppendLine(string.Format("    {0}",this.Content));
            builder.AppendLine(string.Format("      User: {0}", this.Author));
            builder.AppendLine(string.Format("    {0}", new string('-', 10)));
            return builder.ToString();
        }
    }
}
