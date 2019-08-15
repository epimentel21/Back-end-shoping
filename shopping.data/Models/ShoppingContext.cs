using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace shopping.data.Models
{
    public partial class ShoppingContext : DbContext
    {
        public ShoppingContext()
        {
        }

        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaProductos> CategoriaProductos { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<FacturaDetalle> FacturaDetalle { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<ProductosActivo> ProductosActivo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DRLT15;Database=Shopping;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CategoriaProductos>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.DocumentoIdentidad)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.LiminteCredito).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NumberFactura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion).IsRowVersion();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Cliente");

                
            });

            modelBuilder.Entity<FacturaDetalle>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RowVersion).IsRowVersion();

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.FacturaDetalle)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaDetalle_Factura");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.FacturaDetalle)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaDetalle_Productos");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(e => e.CodigoProducto)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RowVersion).IsRowVersion();

                entity.HasOne(d => d.IdCategoriaProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoriaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_ProductosCategory");
            });

            modelBuilder.Entity<ProductosActivo>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdCliente, e.TipoTransacion, e.NumeroActivo });

                entity.Property(e => e.TipoTransacion)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroActivo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CantidaActivo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FechaActivo).HasColumnType("datetime");

                entity.Property(e => e.RowVersion).IsRowVersion();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ProductosActivo)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosActivo_Cliente");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductosActivo)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosActivo_ProductosActivo");
            });
        }
    }
}
