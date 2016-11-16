using System.Linq;
using Dealership.Engine;

namespace Dealership.Handlers
{
    public class RemoveCommentCmmandHandler : BaseCommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";
        private const string CommentRemovedSuccessfully = "{0} removed comment successfully!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "RemoveComment";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            var user = engine.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            base.ValidateRange(vehicleIndex, 0, user.Vehicles.Count, RemovedVehicleDoesNotExist);
            base.ValidateRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            engine.LoggedUser.RemoveComment(comment, vehicle);

            return string.Format(CommentRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
