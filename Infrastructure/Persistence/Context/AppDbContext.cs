using airbnb_c_.Domain.Entities;
using airbnb_c_.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace airbnb_c_.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
