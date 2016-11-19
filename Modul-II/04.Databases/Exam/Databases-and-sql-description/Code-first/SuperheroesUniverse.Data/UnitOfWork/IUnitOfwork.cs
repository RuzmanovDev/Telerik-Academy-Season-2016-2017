using System;

namespace SuperheroesUniverse.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
