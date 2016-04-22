using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPVars
{
    class PHPVars
    {

        static string ReadInput()
        {
            string input = Console.ReadLine().Trim();
            StringBuilder sb = new StringBuilder();

            while (input != "?>")
            {
                sb.AppendLine(input);
                input = Console.ReadLine().Trim();
            }
            string result = sb.ToString();
            return result;

        }
        static void ExtractWords(string inputCode)
        {
            HashSet<string> allVars = new HashSet<string>();
            StringBuilder currentVar = new StringBuilder();
            bool inOneLineComment = false;
            bool inMultiLineComment = false;
            bool inSigngleQuoteString = false;
            bool inDoubleQuoteString = false;
            bool inVariable = false;
            
            for (int i = 0; i < inputCode.Length; i++)
            {
                char currentSymbol = inputCode[i];
                // we are in one line comment 
                if (inOneLineComment)
                {
                    if (currentSymbol == '\n')
                    {
                        // one line comments ends here 
                        inOneLineComment = false;
                        continue;
                    }
                    else
                    {
                        // we are still in one line comment, move to next char
                        continue;

                    }
                }
                // we are in multi line comment 
                if (inMultiLineComment)
                {
                    if (currentSymbol == '*' 
                        && i + 1 < inputCode.Length 
                        && inputCode[i + 1] == '/')
                    {
                        inMultiLineComment = false;
                        i++;// next symbol is checked we don't need it
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (inVariable)
                {
                    if (IsValidVar(currentSymbol))
                    {
                        currentVar.Append(currentSymbol);
                        continue;
                    }
                    else
                    {
                        if (currentVar.Length>0)
                        {
                            allVars.Add(currentVar.ToString());
                        }
                       
                        currentVar.Clear();
                        inVariable = false;
                        continue;
                    }
                }


                if (inSigngleQuoteString)
                {
                    if (currentSymbol =='\'')
                    {
                        inSigngleQuoteString = false;
                        continue;
                    }
                    else
                    {
                        continue;
                    }           
                }

                if (inDoubleQuoteString)
                {
                    if (currentSymbol == '\'')
                    {
                        inSigngleQuoteString = false;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (!inSigngleQuoteString && !inDoubleQuoteString)
                {
                    if (currentSymbol =='#')
                    {
                        inOneLineComment = true;
                        continue;
                    }
                    //startione line comment with //
                    if (currentSymbol=='/'
                         && i + 1 < inputCode.Length
                         && inputCode[i+1] =='/')
                    {
                        inOneLineComment = true;
                        i++;
                        continue;
                    }
                    // TODO NOT FINISHED!!!
                }


            }

        }
        static bool IsValidVar(char symbol)
        {
            if (char.IsLetterOrDigit(symbol) || symbol == '_')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            string inputCode = ReadInput();
            Console.WriteLine(inputCode);
        }
    }
}
