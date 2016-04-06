using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DecodeAndDecryptt
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();
        string crypher = Console.ReadLine();
        Console.WriteLine(CrypherMessage(message, crypher));

    }
    private static string CrypherMessage(string messsage, string crypher)
    {
        var result = new StringBuilder(messsage);
        
        for (int i = 0, j = 0; i < messsage.Length; i++, j++)
        {
            if (i >= crypher.Length)
            {
                j = 0;
            }
            result.Append((char)((result[i] - 'A') ^ (crypher[j] - 'A') + 'A'));
        }
        
        return result.ToString();
    }

}

