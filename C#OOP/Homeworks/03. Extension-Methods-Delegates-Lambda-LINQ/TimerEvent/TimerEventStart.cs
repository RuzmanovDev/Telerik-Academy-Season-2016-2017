namespace TimerEvent
{
    using System;

    public delegate void TimerChangedEvenHandler(object sender, TimeChangedEventArgs EventArgs);

    public class TimerEventStart
    {

        public static void TimerTimeChanged(object aSender, TimeChangedEventArgs EventArgs)
        {
            Console.WriteLine("Timer! Ticks left = {0}",
            EventArgs.TicksLeft);
        }
        public static void Main()
        {
            Timer timer = new Timer(10, 1000);
            timer.TimeChanged += TimerTimeChanged;
            Console.WriteLine(
            "Timer started for 10 ticks at interval 1000 ms.");
            timer.Run();
        }
    }

    class Timer
    {
        public event TimerChangedEvenHandler TimeChanged;

        public Timer(int tickCount, int interval)
        {
            this.TickCount = tickCount;
            this.Interval = interval;

        }
        public int TickCount { get; private set; }

        public int Interval { get; private set; }

        protected virtual void OnTimeChanged(int ticks)
        {
            if (TimeChanged != null)
            {
                TimeChangedEventArgs args = new TimeChangedEventArgs(ticks);
                //TimeChanged(this, args);

                TimeChanged.Invoke(this, args);
            }
        }

        public void Run()
        {
            int tick = this.TickCount;
            while (tick > 0)
            {
                System.Threading.Thread.Sleep(this.Interval);
                tick--;
                OnTimeChanged(tick);
            }
        }

    }
    public class TimeChangedEventArgs : EventArgs
    {

        public TimeChangedEventArgs(int ticksLeft)
        {
            this.TicksLeft = ticksLeft;
        }

        public int TicksLeft { get; private set; }
    }
}
