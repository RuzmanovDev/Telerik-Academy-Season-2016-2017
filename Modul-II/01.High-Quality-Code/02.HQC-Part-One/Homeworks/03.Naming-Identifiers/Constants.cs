namespace Minesweeper
{
    public static class Constants
    {
        public const char Asterix = '*';
        public const char Pipe = '|';
        public const char Dash = '-';
        public const string StartUpMessage = "Let's play \"Mines\". Try to find field withoud mine in it.";
        public const string CommandsHelp = "Command 'top' shows the scoarboard, 'restart' begins a new game , 'exit' exits the game!";
        public const string DeadMessage = "\nHrrrrrr! You have died! Your score is: {0} points. What is your name: ";
        public const string TopCommand = "top";
        public const string TurnCommand = "turn";
        public const string RestartCommand = "restart";
        public const string ExitComamnd = "exit";
        public const int MaximumCommandLength = 3;
    }
}
