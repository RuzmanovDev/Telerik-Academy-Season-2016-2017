using Dealership.Engine;

namespace Dealership.Handlers
{
    public interface ICommandHandler
    {
        void AddCommandHandler(ICommandHandler handler);

        string HandleCommand(ICommand command, IDealershipEngine engine);
    }
}
