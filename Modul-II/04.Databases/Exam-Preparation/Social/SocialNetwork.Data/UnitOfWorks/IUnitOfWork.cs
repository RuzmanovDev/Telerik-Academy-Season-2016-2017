using System;

namespace SocialNetwork.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
