using LarDePaz_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LarDePaz_API.DAL.DB
{
    public class APIContext(DbContextOptions<APIContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasQueryFilter(x => x.DeletedAt == null);
            // Agregar el filtro de los que tienen un no fecha de baja

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }


    }
}
