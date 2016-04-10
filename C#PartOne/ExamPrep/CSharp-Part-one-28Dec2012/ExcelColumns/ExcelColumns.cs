namespace ExcelColumns
{
    using System;

    public class ExcelColumns
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string column = string.Empty;

            for (int i = 0; i < n; i++)
            {
                column += Console.ReadLine();
            }

            int power = column.Length - 1;
            long result = 0;
            for (int i = 0; i < column.Length; i++)
            {
                result += (column[i] - 'A' + 1) * (long)Math.Pow(26, power);
                power--;
            }

            Console.WriteLine(result);
        }
    }
}
