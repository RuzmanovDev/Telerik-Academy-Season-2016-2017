using System;

namespace Console.Client
{
   public class Startup
    {
        static void Main(string[] args)
        {
            //NorthWindDAO.InsertCustomer("TSTST", "Test");
            //NorthWindDAO.DeleteCustomer("Test");
            //NorthWindDAO.UpdateCustomerAddress("Test", "peshoStreet");

            var orderFromCanada = NorthWindDAO.OrdersMadeIn1997AndShippedToCanada();
            var ordersFromSpecifiedCountry = NorthWindDAO.SalesBySpecifiedRegionAndPerion("RJ", new DateTime(1994,12,4), new DateTime(1996,10,2));

            foreach (var item in ordersFromSpecifiedCountry)
            {
                System.Console.WriteLine(item.Customers.CompanyName);
            }
        }
    }
}
