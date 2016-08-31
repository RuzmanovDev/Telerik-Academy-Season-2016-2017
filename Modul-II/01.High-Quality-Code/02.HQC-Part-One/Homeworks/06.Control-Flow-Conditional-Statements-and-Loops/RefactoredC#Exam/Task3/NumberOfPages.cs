namespace Task3
{
    using System;

    public class NumberOfPages
    {
        public static void Main(string[] args)
        {
            int numberOfPages = int.Parse(Console.ReadLine());

            int totalDigits = 0;
            for (int i = numberOfPages; i >= 0; i--)
            {
                int digitsInCurrentPage = 0;
                int currentPageNumber = i;
                while (currentPageNumber != 0)
                {
                    currentPageNumber /= 10;
                    digitsInCurrentPage++;
                }

                totalDigits += digitsInCurrentPage;
            }

            Console.WriteLine(totalDigits);
        }
    }
}
