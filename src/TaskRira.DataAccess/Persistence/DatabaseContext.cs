using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskRira.Core.Entities;

namespace TaskRira.DataAccess.Persistence
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options
            ) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
