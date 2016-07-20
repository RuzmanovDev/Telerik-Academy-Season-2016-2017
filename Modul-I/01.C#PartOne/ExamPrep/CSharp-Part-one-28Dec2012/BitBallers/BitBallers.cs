namespace BitBallers
{
    using System;

    public class BitBallers
    {
        public static void Main(string[] args)
        {
            char[,] fields = new char[8, 8];
            string topTeam = string.Empty;
            string secondTeam = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                int number = int.Parse(Console.ReadLine());
                topTeam += Convert.ToString(number, 2).PadLeft(8, '0');
            }

            for (int i = 0; i < 8; i++)
            {
                int second = int.Parse(Console.ReadLine());
                secondTeam += Convert.ToString(second, 2).PadLeft(8, '0');
            }

            int index = 0;
            for (int r = 0; r < fields.GetLength(0); r++)
            {
                for (int c = 0; c < fields.GetLength(1); c++)
                {
                    fields[r, c] = topTeam[index];
                    index++;
                    if (fields[r, c] == '1')
                    {
                        fields[r, c] = 'T';
                    }
                }
            }

            index = 0;

            for (int r = 0; r < fields.GetLength(0); r++)
            {
                for (int c = 0; c < fields.GetLength(1); c++)
                {
                    if (fields[r, c] == 'T' && secondTeam[index] == '1')
                    {
                        fields[r, c] = '0';
                    }
                    else if (fields[r, c] != 'T')
                    {
                        fields[r, c] = secondTeam[index];

                        if (fields[r, c] == '1')
                        {
                            fields[r, c] = 'B';
                        }
                    }

                    index++;
                }
            }

            bool bottomCanScore = false;
            int row = 0;
            int col = 0;
            int bottomScore = 0;
            while (row <= 8 && col <= 7)
            {
                if (row == 8)
                {
                    col++;
                    row = 0;
                }
                else if (fields[row, col] == 'B')
                {
                    bottomCanScore = true;
                }
                else if (fields[row, col] == '0' && fields[row, col] != 'T')
                {
                    row++;
                }
                else if (fields[row, col] == 'T')
                {
                    bottomCanScore = false;
                    col++;
                    row = 0;
                }

                if (bottomCanScore)
                {
                    bottomScore++;
                    col++;
                    row = 0;
                    bottomCanScore = false;
                }
            }

            row = 7;
            col = 0;
            int topScore = 0;
            bool topCanScore = false;

            while (row >= 0 && col <= 7)
            {
                if (row == 0)
                {
                    row = 7;
                    col++;
                }
                else if (fields[row, col] == 'T')
                {
                    topCanScore = true;
                }
                else if (fields[row, col] == '0' && fields[row, col] != 'B')
                {
                    row--;
                }
                else if (fields[row, col] == 'B')
                {
                    topCanScore = false;
                    col++;
                    row = 7;
                }

                if (topCanScore)
                {
                    topScore++;
                    col++;
                    row = 7;
                    topCanScore = false;
                }
            }

            Console.WriteLine("{0}:{1}", topScore, bottomScore);
        }
    }
}
