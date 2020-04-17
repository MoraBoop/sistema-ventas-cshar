namespace HTGVentasMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HTGVentasMVCConect : DbContext
    {
        public HTGVentasMVCConect()
            : base("name=HTGVentasMVCConect")
        {
        }

        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<detalleVenta> detalleVenta { get; set; }
        public virtual DbSet<factura> factura { get; set; }
        public virtual DbSet<modoPago> modoPago { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<vendedor> vendedor { get; set; }
        public virtual DbSet<venta> venta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .HasMany(e => e.producto)
                .WithRequired(e => e.categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.idCliente)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cliente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.apPaterno)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.apMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.dni)
                .HasPrecision(8, 0);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.venta)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<detalleVenta>()
                .Property(e => e.numFactura)
                .HasPrecision(18, 0);

            modelBuilder.Entity<detalleVenta>()
                .Property(e => e.idVenta)
                .HasPrecision(18, 0);

            modelBuilder.Entity<detalleVenta>()
                .Property(e => e.descuento)
                .HasPrecision(19, 4);

            modelBuilder.Entity<factura>()
                .Property(e => e.numFactura)
                .HasPrecision(18, 0);

            modelBuilder.Entity<factura>()
                .Property(e => e.descuento)
                .HasPrecision(19, 4);

            modelBuilder.Entity<factura>()
                .HasMany(e => e.detalleVenta)
                .WithRequired(e => e.factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<modoPago>()
                .HasMany(e => e.factura)
                .WithRequired(e => e.modoPago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.precioUnitario)
                .HasPrecision(19, 4);

            modelBuilder.Entity<producto>()
                .HasMany(e => e.detalleVenta)
                .WithRequired(e => e.producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vendedor>()
                .HasMany(e => e.venta)
                .WithRequired(e => e.vendedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<venta>()
                .Property(e => e.idVenta)
                .HasPrecision(18, 0);

            modelBuilder.Entity<venta>()
                .Property(e => e.idCliente)
                .HasPrecision(18, 0);

            modelBuilder.Entity<venta>()
                .Property(e => e.IVA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<venta>()
                .HasMany(e => e.detalleVenta)
                .WithRequired(e => e.venta)
                .WillCascadeOnDelete(false);
        }
    }
}
