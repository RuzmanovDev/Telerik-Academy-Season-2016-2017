using SocialNetwork.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SocialNetwork.Data
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext()
            : base("Social")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual IDbSet<UserProfile> UserProfiles { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Post> Post { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
