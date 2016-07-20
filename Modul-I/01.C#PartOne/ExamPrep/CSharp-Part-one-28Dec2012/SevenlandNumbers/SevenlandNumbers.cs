namespace SevenlandNumbers
{
    using System;

    public class SevenlandNumbers
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int edinici = number % 10;
            number /= 10;
            int desetici = number % 10;
            number /= 10;
            int stotici = number % 10;
            int result = 0;

            while (true)
            {
                if (edinici < 6)
                {
                    result = (100 * stotici) + (10 * desetici) + (edinici + 1);
                    break;
                }

                if (edinici >= 6)
                {
                    edinici = 0;

                    if (desetici < 6)
                    {
                        result = (100 * stotici) + (10 * (desetici + 1)) + edinici;
                        break;
                    }

                    if (desetici >= 6)
                    {
                        desetici = 0;

                        if (stotici < 6)
                        {
                            result = (100 * (stotici + 1)) + (10 * desetici) + edinici;
                            break;
                        }
                        else
                        {
                            result = 1000;
                            break;
                        }                  
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
