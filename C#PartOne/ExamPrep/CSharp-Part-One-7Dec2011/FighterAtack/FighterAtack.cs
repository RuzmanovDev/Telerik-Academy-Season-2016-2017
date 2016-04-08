namespace FighterAtack
{
    using System;

    class FighterAtack
    {
        static void Main(string[] args)
        {
            int plantX1 = int.Parse(Console.ReadLine());
            int plantY1 = int.Parse(Console.ReadLine());
            int plantX2 = int.Parse(Console.ReadLine());
            int plantY2 = int.Parse(Console.ReadLine());

            int missleX = int.Parse(Console.ReadLine());
            int missleY = int.Parse(Console.ReadLine());
            int misslePathLenght = int.Parse(Console.ReadLine());

            missleX += misslePathLenght;
            int maxX = Math.Max(plantX1, plantX2);
            int minX = Math.Min(plantX1, plantX2);
            int maxY = Math.Max(plantY1, plantY2);
            int minY = Math.Min(plantY1, plantY2);
            int dmg = 0;

            if ((missleX >= minX && missleX <= maxX) && (missleY >= minY && missleY <= maxY))
            {
                dmg += 100;
            }
            missleX++;
            if ((missleX >= minX && missleX <= maxX) && (missleY >= minY && missleY <= maxY))
            {
                dmg += 75;
            }
            missleX--;
            missleY++;
            if ((missleX >= minX && missleX <= maxX) && (missleY >= minY && missleY <= maxY))
            {
                dmg += 50;
            }
            missleY -= 2;
            if ((missleX >= minX && missleX <= maxX) && (missleY >= minY && missleY <= maxY))
            {
                dmg += 50;
            }
            Console.WriteLine("{0}%", dmg);
        }
    }
}
