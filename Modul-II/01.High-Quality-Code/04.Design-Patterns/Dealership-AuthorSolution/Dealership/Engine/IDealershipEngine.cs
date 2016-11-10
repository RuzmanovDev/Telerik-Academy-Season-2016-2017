using Dealership.Contracts;
using System.Collections.Generic;

namespace Dealership.Engine
{
    public interface IDealershipEngine
    {
        void Start();

        IUser LoggedUser { get; }

        ICollection<IUser> Users { get; }

        void SetLoggedUser(IUser user);
    }
}
