using System.Linq;
using Dealership.Engine;
using Dealership.Factories;

namespace Dealership.Handlers
{
    public class AddCommentCommandHandler : BaseCommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        private const string CommentAddedSuccessfully = "{0} added comment successfully!";

        private IDealershipFactory factory;

        public AddCommentCommandHandler(IDealershipFactory factory)
        {
            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "AddComment";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            var comment = this.factory.CreateComment(content);
            comment.Author = engine.LoggedUser.Username;
            var user = engine.Users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(NoSuchUser, author);
            }

            base.ValidateRange(vehicleIndex, 0, user.Vehicles.Count, VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            engine.LoggedUser.AddComment(comment, vehicle);

            return string.Format(CommentAddedSuccessfully, engine.LoggedUser.Username);

        }
    }
}
