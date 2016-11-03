using SocialNetwork.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext()
            : base("SocialDb")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Friendship> Friendship { get; set; }

        public IDbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
