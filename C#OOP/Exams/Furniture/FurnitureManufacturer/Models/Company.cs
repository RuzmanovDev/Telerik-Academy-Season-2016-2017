namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    public class Company : ICompany
    {
        private ICollection<IFurniture> furnitures;
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name can not be null!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("The name must be atleast 5 symbols");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            protected set
            {
                if (!this.IsAllDigit(value))
                {
                    throw new ArgumentException("The number must consist ony of digits!");
                }

                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var catalog = new StringBuilder();

            catalog.AppendFormat(
                "{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            catalog.AppendLine();
            if (this.Furnitures.Count != 0)
            {
                var sortedFurnitured = this.Furnitures
                    .OrderBy(p => p.Price)
                    .ThenBy(m => m.Model);

                foreach (var item in sortedFurnitured)
                {
                    catalog.AppendLine(item.ToString());
                }
            }

            return catalog.ToString().TrimEnd();
        }

        public IFurniture Find(string model)
        {
            model = model.ToLower();
            foreach (var item in this.Furnitures)
            {
                string itemName = item.Model.ToLower();
                if (itemName.Equals(model))
                {
                    return item;
                }
            }

            return null;
        }

        public void Remove(IFurniture furniture)
        {
            if (this.Furnitures.Contains(furniture))
            {
                this.furnitures.Remove(furniture);
            }
        }

        private bool IsAllDigit(string str)
        {
            foreach (var ch in str)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
