using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Arifarma.Models
{
    public partial class drogueria_arifarmaContext : DbContext
    {
        public drogueria_arifarmaContext()
        {
        }

        public drogueria_arifarmaContext(DbContextOptions<drogueria_arifarmaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<CompraMedicamento> CompraMedicamentos { get; set; } = null!;
        public virtual DbSet<DetalleCompraMedicaman> DetalleCompraMedicamen { get; set; } = null!;
        public virtual DbSet<DetalleFact> DetalleFacts { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-LRVDPR2;Initial Catalog=drogueria_arifarma;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CodCategoria)
                    .HasName("PK__categori__F0522207ED64D65E");

                entity.ToTable("categoria");

                entity.Property(e => e.CodCategoria)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("cod_categoria");

                entity.Property(e => e.Descripción)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("descripción");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PK__cliente__08ED61F3F060F079");

                entity.ToTable("cliente");

                entity.Property(e => e.CodCliente)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("cod_cliente");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("dirección");

                entity.Property(e => e.Email)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<CompraMedicamento>(entity =>
            {
                entity.HasKey(e => e.CodCompraMedicamentos)
                    .HasName("PK__compra_m__F976245A1D4A83A1");

                entity.ToTable("compra_medicamentos");

                entity.Property(e => e.CodCompraMedicamentos)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("cod_compra_medicamentos");

                entity.Property(e => e.CodProveedor)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("cod_proveedor");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.ValorCompra).HasColumnName("valor_compra");

                entity.HasOne(d => d.CodProveedorNavigation)
                    .WithMany(p => p.CompraMedicamentos)
                    .HasForeignKey(d => d.CodProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__compra_me__cod_p__33D4B598");
            });

            modelBuilder.Entity<DetalleCompraMedicaman>(entity =>
            {
                entity.HasKey(e => e.CodDetalleCompraMedicamentos)
                    .HasName("PK__detalle___D2999D74B2B1F718");

                entity.ToTable("detalle_compra_medicamen");

                entity.Property(e => e.CodDetalleCompraMedicamentos)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_detalle_compra_medicamentos");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cantidad");

                entity.Property(e => e.CodCompraMedicamentos)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("cod_compra_medicamentos");

                entity.Property(e => e.CodProducto)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_producto");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.CodCompraMedicamentosNavigation)
                    .WithMany(p => p.DetalleCompraMedicamen)
                    .HasForeignKey(d => d.CodCompraMedicamentos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_c__cod_c__34C8D9D1");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.DetalleCompraMedicamen)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_c__cod_p__35BCFE0A");
            });

            modelBuilder.Entity<DetalleFact>(entity =>
            {
                entity.HasKey(e => e.CodDetalleFactura)
                    .HasName("PK__detalle___3A175F651EC71DC2");

                entity.ToTable("detalle_fact");

                entity.Property(e => e.CodDetalleFactura)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_detalle_factura");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cantidad");

                entity.Property(e => e.CodFactura)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_factura");

                entity.Property(e => e.CodProducto)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_producto");

                entity.Property(e => e.SubtotalVenta).HasColumnName("subtotal_venta");

                entity.HasOne(d => d.CodFacturaNavigation)
                    .WithMany(p => p.DetalleFacts)
                    .HasForeignKey(d => d.CodFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_f__cod_f__36B12243");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.DetalleFacts)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_f__cod_p__37A5467C");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.CodEmpleado)
                    .HasName("PK__empleado__2E2827A0AEB8EB48");

                entity.ToTable("empleado");

                entity.Property(e => e.CodEmpleado)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_empleado");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("dirección");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.CodFactura)
                    .HasName("PK__factura__94EEA410F8BAE64B");

                entity.ToTable("factura");

                entity.Property(e => e.CodFactura)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_factura");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cantidad");

                entity.Property(e => e.CodCliente)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("cod_cliente");

                entity.Property(e => e.CodEmpleado)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_empleado");

                entity.Property(e => e.CostoTotal).HasColumnName("costo_total");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__factura__cod_cli__38996AB5");

                entity.HasOne(d => d.CodEmpleadoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CodEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__factura__cod_emp__398D8EEE");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodProducto)
                    .HasName("PK__producto__118203AD219C2CBD");

                entity.ToTable("producto");

                entity.Property(e => e.CodProducto)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("cod_producto");

                entity.Property(e => e.CodCategoria)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("cod_categoria");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_vencimiento");

                entity.Property(e => e.Impuesto)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("impuesto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioCompra).HasColumnName("precio_compra");

                entity.Property(e => e.PrecioVenta).HasColumnName("precio_venta");

                entity.HasOne(d => d.CodCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__cod_ca__3A81B327");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.CodProveedor)
                    .HasName("PK__proveedo__D4A662EBB68942A5");

                entity.ToTable("proveedor");

                entity.Property(e => e.CodProveedor)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("cod_proveedor");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("dirección");

                entity.Property(e => e.Email)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
