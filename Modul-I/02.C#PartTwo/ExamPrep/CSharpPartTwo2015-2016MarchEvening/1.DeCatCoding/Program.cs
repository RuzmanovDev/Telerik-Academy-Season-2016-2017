using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] text = input.Split(' ');

        char[] alphabet = new char[26];
        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)('a' + i);
        }
        
        string result = Decode(text, alphabet);
        string[] print = result.Split(' ');
        for (int i = 0; i < print.Length; i++)
        {
            string word = Reverse(print[i]);
            Console.Write(word + " ");

          

        }

        //Console.WriteLine(result);

    }
    private static string Decode(string[] text, char[] alphabet)
    {
       
        StringBuilder DecodedMessage = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            double result = 0;
            string word = text[i];
            for (int j = 0; j < word.Length; j++)
            {
                
              result += Array.IndexOf(alphabet, word[j]) * Math.Pow(21, (double)word.Length - j -1);
            }
            DecodedMessage.Append(Encode((long)result, alphabet));
        }

        return DecodedMessage.ToString();
    }

    private static string Encode(long number,char[] alphabet)
    {

        var sb = new StringBuilder();
        while (number>0)
        {
            long key = number % 26;
            sb.Append(alphabet[key]);

            number /= 26;
        }
        sb.Append(' ');



        return sb.ToString() ;
        
    }
    public static string Reverse(string text)
    {
        if (text == null) return null;

        // this was posted by petebob as well 
        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }
}

