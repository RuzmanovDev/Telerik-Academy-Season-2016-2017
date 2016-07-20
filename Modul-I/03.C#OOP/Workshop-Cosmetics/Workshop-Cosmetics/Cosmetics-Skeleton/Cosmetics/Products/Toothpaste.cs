namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using System.Text;
    public class Toothpaste : Product, IToothpaste
    {
        private const int IngridiantMinValue = 4;
        private const int IngridiantMaxValue = 12;

        private readonly string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            // validate
            ValidateIngrediants(ingredients);
            this.ingredients = string.Join(", ", this.ingredients);
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        private void ValidateIngrediants(IList<string> ingredients)
        {
            foreach (var item in ingredients)
            {
                Validator.CheckIfStringIsNullOrEmpty(item, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "The ingridiant"));
                Validator.CheckIfStringLengthIsValid(item, IngridiantMaxValue, IngridiantMinValue, string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingrediant", IngridiantMinValue, IngridiantMaxValue));
            }
        }

        public override string Print()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.Print());

            builder.AppendLine(string.Format("   * Ingredients: {0}", this.Ingredients));


            return builder.ToString();
        }
    }
}
