using LarDePaz_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LarDePaz_API.DAL.DB
{
    public class APIContext(DbContextOptions<APIContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configurar el filtro global para las entidades que tienen DeletedAt
            builder.Entity<Cliente>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<Cobrador>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<Contrato>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<ContratoCuotaHistorial>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<ContratoExpensasHistorial>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<Cuota>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<Expensa>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<Manzana>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<Parcela>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<ParcelaContratoHistorial>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<User>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<Zona>().HasQueryFilter(x => x.DeletedAt == null);


        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cobrador> Cobrador { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<ContratoCuotaHistorial> ContratoCuotaHistorial { get; set; }
        public DbSet<ContratoExpensasHistorial> ContratoExpensasHistorial { get; set; }
        public DbSet<Cuota> Cuota { get; set; }
        public DbSet<Expensa> Expensa { get; set; }
        public DbSet<Manzana> Manzana { get; set; }
        public DbSet<Parcela> Parcela { get; set; }
        public DbSet<ParcelaContratoHistorial> ParcelaContratoHistorial { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Zona> Zona { get; set; }





    }
}
