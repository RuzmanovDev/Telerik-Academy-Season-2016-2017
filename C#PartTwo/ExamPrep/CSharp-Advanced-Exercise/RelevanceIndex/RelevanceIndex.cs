namespace RelevanceIndex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class RelevanceIndex
    {
        static void Main(string[] args)
        {
            string search = Console.ReadLine();
            int numberOfParagraphs = int.Parse(Console.ReadLine());
            int searchWordCount = 0;
            SortedDictionary<int, string> result = new SortedDictionary<int, string>();

            for (int i = 0; i < numberOfParagraphs; i++)
            {
                string[] currentParagraph = Console.ReadLine().Split(new char[] { ',', '.', '(', ')', ';', '-', '!', '?', ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                searchWordCount = 0;
                StringBuilder formatedParagraph = new StringBuilder();
                for (int j = 0; j < currentParagraph.Length; j++)
                {
                    string currentWord = currentParagraph[j];
                    if (currentWord.ToLower() == search.ToLower())
                    {
                        searchWordCount++;
                        currentWord = currentWord.ToUpper();
                        formatedParagraph.Append(currentWord + " ");
                    }
                    else
                    {
                        formatedParagraph.Append(currentWord + " ");
                    }
                }
                try
                {
                    result.Add(searchWordCount, formatedParagraph.ToString());
                }
                catch (Exception)
                {
                    searchWordCount++;
                    result.Add(searchWordCount, formatedParagraph.ToString());

                }
               
                //formatedParagraph.Clear();

            }
            
            foreach (string paragraph in result.Values.Reverse())
            {
                Console.WriteLine("{0}", paragraph);
            }
        }
    }
}
