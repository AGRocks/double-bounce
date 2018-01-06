using traininghub.dac.ef.Common;
using Traininghub.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace traininghub.dac.ef
{
    public class TrainingHubContext : DbContext, IDbDataProvider
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<AcceptedGameInvitation> AcceptedGameInvitations { get; set; }

        public TrainingHubContext(DbContextOptions<TrainingHubContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().ToTable("Student");
        }

        IQueryable<T> IDbDataProvider.AsQueryable<T>()
        {
            return this.Set<T>().AsQueryable();
        }
    }
}
