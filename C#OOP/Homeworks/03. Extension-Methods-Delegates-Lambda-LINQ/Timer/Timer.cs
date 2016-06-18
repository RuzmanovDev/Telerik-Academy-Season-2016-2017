namespace Timer
{
    using System;
    using System.Threading;

    public class Timer
    {
        public delegate void TimerDelegate(TimeSpan timespan);

        public Timer(int second)
        {
            this.Time = new TimeSpan(0, 0, second);
        }
        public TimeSpan Time { get; set; }

        public void WhenTimerEnds(TimeSpan timespan)
        {
            Thread.Sleep(timespan.Seconds * 1000);
            Console.WriteLine($"BRRRRRRRRRRR. Time's up! The Method took {timespan.Seconds} seconds to execute");
        }
    }
}
