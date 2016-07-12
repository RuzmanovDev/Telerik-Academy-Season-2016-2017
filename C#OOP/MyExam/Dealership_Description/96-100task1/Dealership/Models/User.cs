namespace Dealership.Models
{
    using Dealership.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dealership.Common.Enums;
    using Common;

    public class User : IUser
    {
        private readonly string firstName;
        private readonly string lastName;
        private string password;
        private Role role;
        private readonly string username;
        public IList<IVehicle> vehicles;

        private int vehiclesAdded;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            Validator.ValidateNull(username, "Username cannot be null");
            Validator.ValidateNull(firstName, "Firsname cannot be null");
            Validator.ValidateNull(lastName, "LastName cannot be null");
            Validator.ValidateNull(username, "UserName cannot be null");
            Validator.ValidateNull(password, "PassWord cannot be null");
            Validator.ValidateNull(role, "Role cannot be null");

            Validator.ValidateSymbols(username, Constants.UsernamePattern, string.Format(
                Constants.InvalidSymbols, "Username"));
            Validator.ValidateIntRange(username.Length, Constants.MinNameLength, Constants.MaxNameLength,
               string.Format(Constants.StringMustBeBetweenMinAndMax, "Username", Constants.MinNameLength, Constants.MaxNameLength));
            Validator.ValidateIntRange(firstName.Length, Constants.MinNameLength, Constants.MaxNameLength,
                string.Format(Constants.StringMustBeBetweenMinAndMax, "Firstname", Constants.MinNameLength, Constants.MaxNameLength));
            Validator.ValidateIntRange(lastName.Length, Constants.MinNameLength, Constants.MaxNameLength,
               string.Format(Constants.StringMustBeBetweenMinAndMax, "Lastname", Constants.MinNameLength, Constants.MaxNameLength));
            

            this.vehicles = new List<IVehicle>();

            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.Password = password;
            this.Role = ParseEnum<Role>(role);

            this.vehiclesAdded = 0;

        }

        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                Validator.ValidateSymbols(value, Constants.PasswordPattern, string.Format(
              Constants.InvalidSymbols, "Password"));
                Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength,
               string.Format(Constants.StringMustBeBetweenMinAndMax, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));
                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }

            private set
            {
                this.role = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                // TODO Maybe copy
                return this.vehicles;
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            Validator.ValidateNull(commentToAdd, string.Format(Constants.CommentCannotBeNull));
            Validator.ValidateNull(vehicleToAddComment, string.Format(Constants.VehicleCannotBeNull));

            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, string.Format(Constants.VehicleCannotBeNull));
            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }
            if (this.Role != Role.VIP && this.vehiclesAdded >= Constants.MaxVehiclesToAdd)
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd, Constants.MaxVehiclesToAdd));
            }
            this.vehicles.Add(vehicle);

            this.vehiclesAdded++;
        }

        public string PrintVehicles()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("--USER {0}--", this.Username));
            if (this.Vehicles.Count == 0)
            {
                builder.Append("--NO VEHICLES--");
            }
            for (int i = 0; i < this.vehicles.Count; i++)
            {
                builder.Append(string.Format("{0}. {1}", i + 1, this.vehicles[i]));
            }

            return builder.ToString().Trim();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {

            Validator.ValidateNull(commentToRemove, string.Format(Constants.CommentCannotBeNull));
            Validator.ValidateNull(vehicleToRemoveComment, string.Format(Constants.VehicleCannotBeNull));
            if (commentToRemove.Author != this.Username)
            {
                throw new ArgumentException(Constants.YouAreNotTheAuthor);
            }

            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {

            Validator.ValidateNull(vehicle, string.Format(Constants.VehicleCannotBeNull));

            this.vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(string.Format("Username: {0}, FullName: {1} {2}, Role: {3}",
                this.Username, this.FirstName, this.LastName, this.Role));
            return builder.ToString();
        }
    }
}
