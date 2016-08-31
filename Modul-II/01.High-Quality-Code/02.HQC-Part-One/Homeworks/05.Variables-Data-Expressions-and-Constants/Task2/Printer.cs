namespace Task2
{
    public class Printer
    {
        public void PrintStatistics(double[] numbers, int numbersCount)
        {
            // First calculate the values -> better design will be if they are passed as method parameters
            this.CalculateMinimumvalue(numbers, numbersCount);
            this.CalculateMaximumValue(numbers, numbersCount);
            this.CalculateAverageValue(numbers, numbersCount);

            // Some kind of printing logic
        }

        private void CalculateMinimumvalue(double[] numbers, int numbersCount)
        {
            double minimum = numbers[0];

            for (int i = 0; i < numbersCount; i++)
            {
                double number = numbers[i];
                if (number < minimum)
                {
                    minimum = number;
                }
            }
        }

        private void CalculateMaximumValue(double[] numbers, int numbersCount)
        {
            double maximum = numbers[0];

            for (int i = 0; i < numbersCount; i++)
            {
                double number = numbers[i];
                if (number > maximum)
                {
                    maximum = number;
                }
            }
        }

        private void CalculateAverageValue(double[] numbers, int numbersCount)
        {
            double sum = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                double number = numbers[i];
                sum += number;
            }

            double average = sum / numbersCount;
        }
    }
}
