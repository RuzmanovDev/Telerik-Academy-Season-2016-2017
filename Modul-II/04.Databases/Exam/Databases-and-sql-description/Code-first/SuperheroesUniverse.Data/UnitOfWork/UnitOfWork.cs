using System;
using System.Data.Entity;

namespace SuperheroesUniverse.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
