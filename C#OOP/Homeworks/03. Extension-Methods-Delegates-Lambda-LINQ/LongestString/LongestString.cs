// Problem 17. Longest string
namespace LongestString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LongestString
    {
        public static void Main(string[] args)
        {
            var listOfStr = new List<string>()
            {
                "Az sam dalag string",
                "Az sam po-dalag string",
                "Da ama az sam po dalag ot vas i shte se pokaja na consolata"
            };

            // Write a program to return the string with maximum length from an array of strings.
            var longestStr = from st in listOfStr
                             orderby st.Length
                             select st;
                             
            Console.WriteLine(longestStr.Last());
        }
    }
}
