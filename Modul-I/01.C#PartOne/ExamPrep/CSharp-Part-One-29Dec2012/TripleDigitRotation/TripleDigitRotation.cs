namespace TripleDigitRotation
{
    using System;

    public class TripleDigitRotation
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = 0; i < 3; i++)
            {
                int edinici = number % 10;
                number /= 10;
                int desetici = number % 10;
                number /= 10;
                int stotici = number % 10;
                number /= 10;
                int hilqdni = number % 10;
                number /= 10;
                int desetohilqdni = number % 10;
                number /= 10;
                int stohilqdni = number % 10;

                if (stohilqdni != 0)
                {
                    result = (100000 * edinici) + (10000 * stohilqdni) + (1000 * desetohilqdni) + (100 * hilqdni) + (10 * stotici) + (1 * desetici);
                    number = result;
                }
                else if (desetohilqdni != 0)
                {
                    result = (10000 * edinici) + (1000 * desetohilqdni) + (100 * hilqdni) + (10 * stotici) + (1 * desetici);
                    number = result;
                }
                else if (hilqdni != 0)
                {
                    result = (1000 * edinici) + (100 * hilqdni) + (10 * stotici) + (1 * desetici);
                    number = result;
                }
                else if (stotici != 0)
                {
                    result = (100 * edinici) + (10 * stotici) + (1 * desetici);
                    number = result;
                }
                else if (desetici != 0)
                {
                    result = (10 * edinici) + (1 * desetici);
                    number = result;
                }
                else if (desetici != 0)
                {
                    result = desetici;
                    number = result;
                }
                else if (edinici != 0)
                {
                    result = edinici;
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
