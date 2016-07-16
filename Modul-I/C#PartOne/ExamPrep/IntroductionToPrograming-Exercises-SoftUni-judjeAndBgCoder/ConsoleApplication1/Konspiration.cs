using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2x2SquaresInMatrix
{
    class Konspiration
    {
        static string ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sb.AppendLine(Console.ReadLine());
            }
            string code = sb.ToString();
            return code;
        }
        static string MethodInvokes(string code)
        {
            bool seeStatic = false;
            bool isInStatic = false;
            bool foundCapitalLetter = false;
            bool isInMethodParameter = false;


            StringBuilder methodNames = new StringBuilder();
            for (int i = 0; i < code.Length - 6; i++)
            {

                if (!seeStatic)
                {
                    if (code.Substring(i, 6) == "static") // search for static keyword
                    {
                        seeStatic = true;
                        //i += 6; // static found go to next word?
                    }
                }
                if (seeStatic)
                {
                    if (char.IsUpper(code[i]))
                    {
                        foundCapitalLetter = true;
                        seeStatic = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (foundCapitalLetter)
                {
                    if (code[i] != '(')
                    {
                        if (code[i] != ')')
                        {
                            methodNames.Append(code[i]);
                        }
                        else
                        {
                            foundCapitalLetter = false;
                        }

                    }
                    else if (code[i] == '(')
                    {
                        foundCapitalLetter = false;
                        isInMethodParameter = true;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (isInMethodParameter)
                {
                    if (code[i] == '{')
                    {
                        isInMethodParameter = false;
                        isInStatic = true;
                    }
                    else if (code[i] == '.' || char.IsUpper(code[i]))
                    {
                        i++;

                        foundCapitalLetter = true;
                        methodNames.Append(code[i]);
                        isInStatic = false;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (isInStatic)
                {
                    if (code[i] == '.')
                    {
                        i++;
                        foundCapitalLetter = true;
                        methodNames.Append(code[i]);
                        isInStatic = false;
                    }
                    else
                    {
                        continue;
                    }
                }


            }
            string res = methodNames.ToString();
            return res;

        }
        static void Main(string[] args)
        {
            string code = ReadInput();
            string str = MethodInvokes(code);
            Console.WriteLine(str);
        }

    }
}

