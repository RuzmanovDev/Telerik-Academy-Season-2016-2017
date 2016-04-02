using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11NumberPronunciation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int x = int.Parse(Console.ReadLine());
            int ones = x % 10;
            int tens = (x / 10) % 10;
            int hundrets = x / 100;
            if (x >= 0 && x <= 999)
            {
                switch (hundrets)
                {
                    case 1:
                        Console.Write("Сто ");
                        break;
                    case 2:
                        Console.Write("Двеста ");
                        break;
                    case 3:
                        Console.Write("Триста ");
                        break;
                    case 4:
                        Console.Write("Четиристотин ");
                        break;
                    case 5:
                        Console.Write("Петстотин ");
                        break;
                    case 6:
                        Console.Write("Шестстотин ");
                        break;
                    case 7:
                        Console.Write("Седемстотин ");
                        break;
                    case 8:
                        Console.Write("Осемстотин ");
                        break;
                    case 9:
                        Console.Write("Деветстотин ");
                        break;
                    case 0:
                        break;
                }

                if (ones == 0 && tens == 0)
                    Console.WriteLine();
                if (ones == 0 && tens != 1 && tens != 0)
                    Console.Write("и ");
                switch (tens)
                {
                    case 1:
                        if (hundrets != 0 && (tens != 0 || ones > 0))
                            Console.Write("и ");
                        switch (ones)
                        {
                            case 1:
                                Console.WriteLine("Единадесет ");
                                break;
                            case 2:
                                Console.WriteLine("Дванадесет ");
                                break;
                            case 3:
                                Console.WriteLine("Тринадесет ");
                                break;
                            case 4:
                                Console.WriteLine("Четиринадесет ");
                                break;
                            case 5:
                                Console.WriteLine("Петнадесет ");
                                break;
                            case 6:
                                Console.WriteLine("Шеснадесет ");
                                break;
                            case 7:
                                Console.WriteLine("Седемнадесет ");
                                break;
                            case 8:
                                Console.WriteLine("Осемнадесет ");
                                break;
                            case 9:
                                Console.WriteLine("Деветнадесет ");
                                break;
                            case 0:
                                Console.WriteLine("Десет ");
                                break;
                        }
                        break;
                    case 2:
                        Console.Write("Двадесет ");
                        break;
                    case 3:
                        Console.Write("Тридесет ");
                        break;
                    case 4:
                        Console.Write("Четирдесет ");
                        break;
                    case 5:
                        Console.Write("Педесет ");
                        break;
                    case 6:
                        Console.Write("Шестдесет ");
                        break;
                    case 7:
                        Console.Write("Седемдесет ");
                        break;
                    case 8:
                        Console.Write("Осемдесет ");
                        break;
                    case 9:
                        Console.Write("Деветдесет ");
                        break;
                    case 0:
                        break;
                }
                if (tens != 1)
                {
                    if (tens != 0 || (hundrets != 0 && ones != 0))
                        if (ones > 0)
                        {
                            Console.Write("и ");
                        }

                    switch (ones)
                    {
                        case 1:
                            Console.WriteLine("Едно ");
                            break;
                        case 2:
                            Console.WriteLine("Две");
                            break;
                        case 3:
                            Console.WriteLine("Три ");
                            break;
                        case 4:
                            Console.WriteLine("Четири ");
                            break;
                        case 5:
                            Console.WriteLine("Пет ");
                            break;
                        case 6:
                            Console.WriteLine("Шест ");
                            break;
                        case 7:
                            Console.WriteLine("Седем ");
                            break;
                        case 8:
                            Console.WriteLine("Осем ");
                            break;
                        case 9:
                            Console.WriteLine("Девет ");
                            break;
                        case 0:
                            if (tens != 0)
                                Console.WriteLine();
                            break;
                    }
                }
                if (ones == 0 && tens == 0 && hundrets == 0)
                    Console.WriteLine("Нула");
            }
        }else Console.WriteLine("Out of range");
    }
}



