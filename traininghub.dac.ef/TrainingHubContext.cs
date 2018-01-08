using traininghub.dac.ef.Common;
using Traininghub.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace traininghub.dac.ef
{
    public class TrainingHubContext : DbContext, IDbDataProvider
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Challenge> Challenge { get; set; }

        public TrainingHubContext(DbContextOptions<TrainingHubContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(x => x.Organizer)
                .WithMany(u => u.Games)
                .HasForeignKey(x => x.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
               .HasOne(x => x.Venue)
               .WithMany(u => u.Games)
               .HasForeignKey(x => x.VenueId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Challenge>()
                .HasOne(x => x.Game)
                .WithMany(y => y.Challenges)
                .HasForeignKey(x => x.GameId);
        }

        IQueryable<T> IDbDataProvider.AsQueryable<T>()
        {
            return this.Set<T>().AsQueryable();
        }

        DbSet<T> IDbDataProvider.GetDbSet<T>()
        {
            return this.Set<T>();
        }

        public Task SaveAsync()
        {
            return SaveChangesAsync();
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
