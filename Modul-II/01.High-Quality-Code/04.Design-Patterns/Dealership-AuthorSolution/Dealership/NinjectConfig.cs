using System;
using Ninject.Modules;
using Dealership.Factories;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Conventions;
using System.IO;
using System.Reflection;
using Dealership.Engine;
using Dealership.Contracts;
using Dealership.Models;
using Dealership.Handlers;
using Ninject;

namespace Dealership
{
    public class NinjectConfig : NinjectModule
    {
        private const string AddCommentCommandHandler = "AddCommentCommandHandler";
        private const string AddVehicleCommandHandler = "AddVehicleCommandHandler";
        private const string LoginCommandHandler = "LoginCommandHandler";
        private const string LogoutCommandHandler = "LogoutCommandHandler";
        private const string RegisterUserCommandHandler = "RegisterUserCommandHandler";
        private const string RemoveCommentCommantHandler = "RemoveCommentCmmandHandler";
        private const string RemoveVehicleCommandHandler = "RemoveVehicleCommandHandler";
        private const string ShowUsersCommandHandler = "ShowUsersCommandHandler";
        private const string ShowVehiclesCommandHandler = "ShowVehiclesCommandHandler";

        public override void Load()
        {
            this.Bind<ICommand>().To<Command>();
            this.Bind<IUser>().To<User>();
            this.Bind<IComment>().To<Comment>();
            this.Bind<IVehicle>().To<Car>().Named("Car");
            this.Bind<IVehicle>().To<Truck>().Named("Truck");
            this.Bind<IVehicle>().To<Motorcycle>().Named("Motorcycle");

            this.Bind<ICommandHandler>().To<AddCommentCommandHandler>().Named(AddCommentCommandHandler);
            this.Bind<ICommandHandler>().To<AddVehicleCommandHandler>().Named(AddVehicleCommandHandler);
            this.Bind<ICommandHandler>().To<LoginCommandHandler>().Named(LoginCommandHandler);
            this.Bind<ICommandHandler>().To<LogoutCommandHandler>().Named(LogoutCommandHandler);
            this.Bind<ICommandHandler>().To<RegisterUserCommandHandler>().Named(RegisterUserCommandHandler);
            this.Bind<ICommandHandler>().To<RemoveCommentCmmandHandler>().Named(RemoveCommentCommantHandler);
            this.Bind<ICommandHandler>().To<RemoveVehicleCommandHandler>().Named(RemoveVehicleCommandHandler);
            this.Bind<ICommandHandler>().To<ShowUsersCommandHandler>().Named(ShowUsersCommandHandler);
            this.Bind<ICommandHandler>().To<ShowVehiclesCommandHandler>().Named(ShowVehiclesCommandHandler);

            this.Bind<ICommandHandler>().ToMethod(ctx =>
            {
                var registerUserHandler = ctx.Kernel.Get<ICommandHandler>(RegisterUserCommandHandler);
                var loginHandler = ctx.Kernel.Get<ICommandHandler>(LoginCommandHandler);
                var logoutHandler = ctx.Kernel.Get<ICommandHandler>(LogoutCommandHandler);
                var addVehicleHandler = ctx.Kernel.Get<ICommandHandler>(AddVehicleCommandHandler);
                var removeVehicleHandler = ctx.Kernel.Get<ICommandHandler>(RemoveVehicleCommandHandler);
                var addCommnentHandler = ctx.Kernel.Get<ICommandHandler>(AddCommentCommandHandler);
                var removeCommentHandler = ctx.Kernel.Get<ICommandHandler>(RemoveCommentCommantHandler);
                var showUsersHandler = ctx.Kernel.Get<ICommandHandler>(ShowUsersCommandHandler);
                var showVehiclesHandler = ctx.Kernel.Get<ICommandHandler>(ShowVehiclesCommandHandler);

                registerUserHandler.AddCommandHandler(loginHandler);
                loginHandler.AddCommandHandler(logoutHandler);
                logoutHandler.AddCommandHandler(addVehicleHandler);
                addVehicleHandler.AddCommandHandler(removeVehicleHandler);
                removeVehicleHandler.AddCommandHandler(addCommnentHandler);
                addCommnentHandler.AddCommandHandler(removeCommentHandler);
                removeCommentHandler.AddCommandHandler(showUsersHandler);
                showUsersHandler.AddCommandHandler(showVehiclesHandler);

                return registerUserHandler;
            })
           .WhenInjectedInto<DealershipEngine>()
           .InSingletonScope();

            this.Bind<IDealershipEngine>().To<DealershipEngine>().InSingletonScope();
            this.Bind<IDealershipFactory>().ToFactory().InSingletonScope();
            this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            this.Bind<IInputOutputProcessor>().To<ConsoleIOProcessor>().InSingletonScope();
        }
    }
}