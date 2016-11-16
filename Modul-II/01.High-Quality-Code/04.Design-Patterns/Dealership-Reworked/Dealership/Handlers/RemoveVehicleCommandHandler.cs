using Dealership.Engine;

namespace Dealership.Handlers
{
    public class RemoveVehicleCommandHandler : BaseCommandHandler
    {
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "RemoveVehicle";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            base.ValidateRange(vehicleIndex, 0, engine.LoggedUser.Vehicles.Count, RemovedVehicleDoesNotExist);

            var vehicle = engine.LoggedUser.Vehicles[vehicleIndex];

            engine.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(VehicleRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
