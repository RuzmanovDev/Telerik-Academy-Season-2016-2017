namespace Timer
{
    using System;

    public class Start
    {
        //TODO : not sute if it's correct
        public delegate void TimerDelegate(TimeSpan ts);

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i += 2)
            {
                var time = new Timer(i);
                var timerDel = new TimerDelegate(time.WhenTimerEnds);

                timerDel(time.Time);
            }
        }
    }
}