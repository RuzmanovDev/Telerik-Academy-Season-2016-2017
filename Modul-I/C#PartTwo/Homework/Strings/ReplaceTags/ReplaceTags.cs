namespace ReplaceTags
{
    using System;
    using System.Text;

    class ReplaceTags
    {
        static void Main(string[] args)
        {
            string document = Console.ReadLine();

            bool isInA = false;
            var newTest = new StringBuilder();
            for (int i = 0; i < document.Length - 1; i++)
            {

                if (document[i] == '<' && document[i + 1] == 'a')
                {
                    isInA = true;
                }

                if (isInA)
                {
                    int indexOfEqual = document.IndexOf('"', i);
                    int indexOfClosing = document.IndexOf("\">", indexOfEqual);

                    indexOfEqual++; // goes to the h of http
                
                    string link = document.Substring(indexOfEqual, indexOfClosing - indexOfEqual);
                    int indexOfClosingA = document.IndexOf("</a>", indexOfEqual);
                    indexOfClosing += 2;

                    string linkText = document.Substring(indexOfClosing, indexOfClosingA - indexOfClosing);

                    newTest.AppendFormat("[{0}]({1})", linkText, link);
                    isInA = false;
                    i = indexOfClosingA + 3;

                }
                else
                {
                    newTest.Append(document[i]);
                }
            }

            newTest.Append(document[document.Length - 1]); // append the last symbol
            Console.WriteLine(newTest.ToString());
        }
    }
}
