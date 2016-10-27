using Console.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Console.Client
{
    public static class NorthWindDAO
    {
        public static NorthwindEntities dbContext;

        static NorthWindDAO()
        {
            dbContext = new NorthwindEntities();
        }

        public static void InsertCustomer(
            string customerId,
            string companyName,
            string contactName = null,
            string contactTitle = null,
            string address = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string phone = null,
            string fax = null)
        {
            var customer = new Customers()
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };


            dbContext.Customers.Add(customer);

            dbContext.SaveChanges();
        }


        public static void DeleteCustomer(string companyName)
        {
            var customer = dbContext.Customers.FirstOrDefault(c => c.CompanyName == companyName);

            dbContext.Customers.Remove(customer);

            dbContext.SaveChanges();
        }

        public static void UpdateCustomerName(string id, string newCompanyName)
        {
            var customer = dbContext.Customers.FirstOrDefault(c => c.CustomerID == id);
            customer.CompanyName = newCompanyName;
            dbContext.SaveChanges();
        }

        public static void UpdateCustomerAddress(string companyName, string newAddress)
        {
            var customer = dbContext.Customers.FirstOrDefault(c => c.CompanyName == companyName);
            customer.Address = newAddress;
            dbContext.SaveChanges();
        }

        public static ICollection<Orders> OrdersMadeIn1997AndShippedToCanada()
        {
            var result = dbContext.Orders
                .Where(sc => sc.ShipCountry == "Canada" && sc.OrderDate.Value.Year == 1997);

            // Implement previous by using native SQL query and executing it through the DbContext.
            //var query = "SELECT * FROM Orders WHERE ShipCountry = 'Canada' AND YEAR(OrderDate) = 1997";
            //var result = dbContext.Orders.SqlQuery(query);

            return result.ToList();
        }

        public static ICollection<Orders> SalesBySpecifiedRegionAndPerion(string region, DateTime startDate, DateTime endDate)
        {
            var result = dbContext.Orders.
                Where(o => o.ShipRegion == region && (o.OrderDate >= startDate && o.RequiredDate <= endDate)).ToList();

            return result;
        }

        public static void CloneTheDB()
        {
            using (var db = new NorthwindEntities())
            {
                // You must change your App.config file in order to generate a clone of Northwind

                // Summary:
                //     Creates a new database on the database server for the model defined in the backing
                //     context, but only if a database with the same name does not already exist on
                //     the server.
                //
                // Returns:
                //     True if the database did not exist and was created; false otherwise.
                var flag = db.Database.CreateIfNotExists();
            }
        }
    }
}