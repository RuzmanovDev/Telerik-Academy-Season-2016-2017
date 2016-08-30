namespace Events
{
    using System;
    using System.Text;

    public static class Messages
    {
        private static StringBuilder output;

        private static string eventsAddedMsg = "Event added" + Environment.NewLine;
        private static string eventsDeletedMsg = "{0} events deleted" + Environment.NewLine;
        private static string eventsNotFoundMsg = "No events found" + Environment.NewLine;

        static Messages()
        {
            output = new StringBuilder();
        }

        public static void EventAdded()
        {
            output.Append(eventsAddedMsg);
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat(eventsDeletedMsg, x);
            }
        }

        public static void NoEventsFound()
        {
            output.Append(eventsNotFoundMsg);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + Environment.NewLine);
            }
        }
    }
}
