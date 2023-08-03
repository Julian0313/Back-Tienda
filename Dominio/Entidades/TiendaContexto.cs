using Microsoft.EntityFrameworkCore;

namespace Dominio.Entidades
{
    public class TiendaContexto : DbContext
    {
        public TiendaContexto(DbContextOptions<TiendaContexto> options) : base(options)
        {
        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
            .HasKey(c => c.idCategoria);

            modelBuilder.Entity<Estado>()
            .HasKey(e => e.idEstado);              

            modelBuilder.Entity<Cargo>()
            .HasKey(ca => ca.idCargo);

            modelBuilder.Entity<Producto>()
            .HasKey(p => p.idProducto);

            modelBuilder.Entity<Empleado>()
            .HasKey(em => em.idEmpleado);
            
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria) // Establecer la navegación a la entidad Categoria
                .WithMany() // La entidad Categoria tiene múltiples productos
                .HasForeignKey(p => p.fkIdCategoria); // Configurar la clave externa en Producto

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Estado)
                .WithMany() 
                .HasForeignKey(p => p.fkIdEstado);  

            modelBuilder.Entity<Empleado>()
                .HasOne(p => p.Estado)
                .WithMany() 
                .HasForeignKey(p => p.fkIdEstado); 

            modelBuilder.Entity<Empleado>()
                .HasOne(ca => ca.Cargo)
                .WithMany() 
                .HasForeignKey(p => p.fkIdCargo);  

            base.OnModelCreating(modelBuilder);
        }

    }

}
