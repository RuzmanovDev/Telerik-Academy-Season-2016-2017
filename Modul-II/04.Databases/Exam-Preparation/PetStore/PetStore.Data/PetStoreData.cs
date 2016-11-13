using PetStore.Data.Data;
using System;
using System.Data.Entity;

namespace PetStore.Data
{
    public class PetStoreData : IPetStoreData
    {
        private DbContext context;

        public PetStoreData(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.context = context;

            this.context.Configuration.AutoDetectChangesEnabled = false;
            this.context.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
