using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_TareaIII.Controllers.Producto
{
    public partial class Producto_Context : DbContext
    {
        public Producto_Context() { }
        public Producto_Context(DbContextOptions<Producto_Context> options) : base(options) { }

        public virtual DbSet<WebApplication_TareaIII.Models.Producto.asociar_producto> Registros_Producto { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVLLMUB;Database=TareaIII;Trusted_Connection=True;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebApplication_TareaIII.Models.Producto.asociar_producto>(entity =>
            {
                entity.ToTable("datosProducto");

                entity.Property(e => e.Informacion_Proveedor)
                    .HasMaxLength(300)
                    .IsUnicode(false);

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
