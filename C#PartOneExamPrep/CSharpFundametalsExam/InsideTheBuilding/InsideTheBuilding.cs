using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideTheBuilding
{
    class InsideTheBuilding
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());

            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());

            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());

            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());

            int x4 = int.Parse(Console.ReadLine());
            int y4 = int.Parse(Console.ReadLine());

            int x5 = int.Parse(Console.ReadLine());
            int y5 = int.Parse(Console.ReadLine());

            isDotIn(x1, y1, h);
            isDotIn(x2, y2, h);
            isDotIn(x3, y3, h);
            isDotIn(x4, y4, h);
            isDotIn(x5, y5, h);


        }
        static void isDotIn(int x, int y, int h)
        {
            if ((x >= 0 & x <= 3 * h && y <= h && y >= 0)|| (x>=h && x<=2*h && y<=4* h && y>=h) )
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }



        }
    }
}