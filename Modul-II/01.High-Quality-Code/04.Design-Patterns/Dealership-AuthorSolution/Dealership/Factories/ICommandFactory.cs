using Dealership.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string input);
    }
}
