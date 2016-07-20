namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Common;
    using Contracts;
    public class Toothpaste : Product, IToothpaste
    {
        private IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.SetIngedients(ingredients);
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        private void SetIngedients(IList<string> ingr)
        {
            Validator.CheckIfNull(ingr, GlobalErrorMessages.ObjectCannotBeNull);
            // TODO: validate length
            this.ingredients = new List<string>(ingr);
        }


        public override string Print()
        {
            var result = new StringBuilder();
            result.AppendLine(base.Print());
            result.Append(string.Format("  * Ingredients: {0}", this.Ingredients));
            return result.ToString();
        }
    }
}
