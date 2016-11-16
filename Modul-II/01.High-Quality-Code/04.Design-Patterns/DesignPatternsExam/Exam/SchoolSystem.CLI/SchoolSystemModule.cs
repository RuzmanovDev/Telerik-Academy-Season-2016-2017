using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Cli.Interceptors;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Db;
using SchoolSystem.Framework.Factories;
using System.IO;
using System.Reflection;
using SchoolSystem.Framework.IdGenerators;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string ConsoleReaderProvider = "ConsoleReaderProvider";
        private const string ConsoleWritterProvider = "ConsoleWriiterProvider";
        private const string CommandParserProvider = "CommandParserProvider";
        private const string CreateStudentCommand = "CreateStudentCommand";
        private const string CreateTeacherCommand = "CreateTeacherCommand";
        private const string RemoveStudentCommand = "RemoveStudentCommand";
        private const string RemoveTeacherCommand = "RemoveTeacherCommand";
        private const string StudentListMarksCommand = "StudentListMarksCommand";
        private const string TeacherAddMarkCommand = "TeacherAddMarkCommand";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                this.Bind<ICommandFactory>().ToFactory().InSingletonScope().Intercept().With<MeasureExecutionTime>();
                this.Bind<IStudentFactory>().ToFactory().InSingletonScope().Intercept().With<MeasureExecutionTime>();
                this.Bind<IMarkFactory>().ToFactory().InSingletonScope().Intercept().With<MeasureExecutionTime>();

            }
            else
            {
                this.Bind<IStudentFactory>().ToFactory().InSingletonScope();
                this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
                this.Bind<IMarkFactory>().ToFactory().InSingletonScope();
            }

            this.Bind<IIdGenerator>().To<TeacherIdGenerator>().WhenInjectedInto<CreateTeacherCommand>().InSingletonScope();
            this.Bind<IIdGenerator>().To<StudentIdGenerator>().WhenInjectedInto<CreateStudentCommand>().InSingletonScope();


            this.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope().Named(ConsoleReaderProvider);
            this.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope().Named(ConsoleWritterProvider);
            this.Bind<IParser>().To<CommandParserProvider>().InSingletonScope().Named(CommandParserProvider);

            this.Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommand);
            this.Bind<ICommand>().To<CreateTeacherCommand>().Named(CreateTeacherCommand);
            this.Bind<ICommand>().To<RemoveStudentCommand>().Named(RemoveStudentCommand);
            this.Bind<ICommand>().To<RemoveTeacherCommand>().Named(RemoveTeacherCommand);
            this.Bind<ICommand>().To<StudentListMarksCommand>().Named(StudentListMarksCommand);
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().Named(TeacherAddMarkCommand);

            this.Bind<ITeacherFactory>().ToFactory().InSingletonScope();

            this.Bind<IDbProvider>().To<SchoolDbProvider>().InSingletonScope();
        }
    }
}