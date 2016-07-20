namespace CompanyInfo
{
    using System;

    public class CompanyInfo
    {
        public static void Main(string[] args)
        {
            string companyName = Console.ReadLine();
            string companyAddress = Console.ReadLine();
            string phoneNumbr = Console.ReadLine();
            string faxNumber = Console.ReadLine();
            string webSite = Console.ReadLine();
            string managerFirsName = Console.ReadLine();
            string managerLastname = Console.ReadLine();
            string managerAge = Console.ReadLine();
            string managerPhone = Console.ReadLine();

            if (string.IsNullOrEmpty(faxNumber))
            {
                faxNumber = "(no fax)";
            }

            Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})", companyName, companyAddress, phoneNumbr, faxNumber, webSite, managerFirsName, managerLastname, managerAge, managerPhone);
        }
    }
}
