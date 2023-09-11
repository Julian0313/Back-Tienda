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
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<SP_Registro> SP_Registro { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
            .HasKey(c => c.idCategoria);

            modelBuilder.Entity<Estado>()
            .HasKey(e => e.idEstado);              

            modelBuilder.Entity<Cargo>()
            .HasKey(ca => ca.idCargo);

            modelBuilder.Entity<Usuario>()
            .HasKey(u => u.idUsuario);

            modelBuilder.Entity<Producto>()
            .HasKey(p => p.idProducto);

            modelBuilder.Entity<Empleado>()
            .HasKey(em => em.idEmpleado);

            modelBuilder.Entity<Cliente>()
            .HasKey(cli => cli.idCliente);
            
            //Llaves foraneas 

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria) // Establecer la navegación a la entidad Categoria
                .WithMany() // La entidad Categoria tiene múltiples productos
                .HasForeignKey(p => p.fkIdCategoria); // Configurar la clave externa en Producto

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Estado)
                .WithMany() 
                .HasForeignKey(p => p.fkIdEstado);  

            modelBuilder.Entity<Empleado>()
                .HasOne(emp => emp.Estado)
                .WithMany() 
                .HasForeignKey(p => p.fkIdEstado); 

            modelBuilder.Entity<Empleado>()
                .HasOne(emp => emp.Cargo)
                .WithMany() 
                .HasForeignKey(p => p.fkIdCargo);  

            modelBuilder.Entity<Cliente>()
                .HasOne(cli => cli.Estado)
                .WithMany()
                .HasForeignKey(cli => cli.fkIdEstado);

            modelBuilder.Entity<Cliente>()
                .HasOne(cli => cli.Usuario)
                .WithMany()
                .HasForeignKey(cli => cli.fkIdUsuario);

            modelBuilder.Entity<Usuario>()
                .HasOne(usu => usu.Estado)
                .WithMany()
                .HasForeignKey(usu => usu.fkIdEstado);

            modelBuilder.Entity<SP_Registro>()
                .HasNoKey();

            base.OnModelCreating(modelBuilder);            
        }

    }

}
