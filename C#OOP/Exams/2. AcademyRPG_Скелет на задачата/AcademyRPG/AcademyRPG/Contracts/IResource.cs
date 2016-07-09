using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG.Contracts
{
    public interface IResource : IWorldObject
    {
        int Quantity
        {
            get;
        }

        ResourceType Type
        {
            get;
        }
    }
}
