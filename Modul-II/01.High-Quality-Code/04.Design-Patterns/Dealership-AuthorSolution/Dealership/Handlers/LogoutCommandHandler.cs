using Dealership.Engine;

namespace Dealership.Handlers
{
    public class LogoutCommandHandler : BaseCommandHandler
    {
        private const string UserLoggedOut = "You logged out!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "Logout";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            engine.SetLoggedUser(null);
            return UserLoggedOut;
        }
    }
}
