using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialMedia.Core.Entities;

namespace PruebaEmergia.Infrastructure.Data
{
    public partial class emergiaContext : DbContext
    {
        public emergiaContext()
        {
        }

        public emergiaContext(DbContextOptions<emergiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Ciclo> Ciclo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoCiclo> ProductoCiclo { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__CD54BC5AEC937A2E");

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoriaPadre).HasColumnName("categoria_padre");

                entity.Property(e => e.Detalle)
                    .HasColumnName("detalle")
                    .HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("text");

                entity.HasOne(d => d.CategoriaPadreNavigation)
                    .WithMany(p => p.InverseCategoriaPadreNavigation)
                    .HasForeignKey(d => d.CategoriaPadre)
                    .HasConstraintName("FK__categoria__categ__37A5467C");
            });

            modelBuilder.Entity<Ciclo>(entity =>
            {
                entity.HasKey(e => e.IdCiclo)
                    .HasName("PK__ciclo__A78E2FA32FA62C69");

                entity.ToTable("ciclo");

                entity.Property(e => e.IdCiclo)
                    .HasColumnName("id_ciclo")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fecha_fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fecha_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numero).HasColumnName("numero");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__677F38F56F8E5BBD");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasColumnType("text");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("text");

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasColumnType("text");

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasColumnType("text");

                entity.Property(e => e.Instagram)
                    .HasColumnName("instagram")
                    .HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("text");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("text");

                entity.Property(e => e.Twitter)
                    .HasColumnName("twitter")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Detalle>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("PK__detalle__4F1332DE9CBC621B");

                entity.ToTable("detalle");

                entity.Property(e => e.IdDetalle)
                    .HasColumnName("id_detalle")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.NumFactura).HasColumnName("num_factura");

                entity.Property(e => e.NumProductoCiclo).HasColumnName("num_producto_ciclo");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.NumFacturaNavigation)
                    .WithMany(p => p.Detalle)
                    .HasForeignKey(d => d.NumFactura)
                    .HasConstraintName("FK__detalle__num_fac__4BAC3F29");

                entity.HasOne(d => d.NumProductoCicloNavigation)
                    .WithMany(p => p.Detalle)
                    .HasForeignKey(d => d.NumProductoCiclo)
                    .HasConstraintName("FK__detalle__num_pro__4AB81AF0");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__factura__6C08ED53E3B937F3");

                entity.ToTable("factura");

                entity.Property(e => e.IdFactura)
                    .HasColumnName("id_factura")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumCliente).HasColumnName("num_cliente");

                entity.Property(e => e.NumVendedor).HasColumnName("num_vendedor");

                entity.HasOne(d => d.NumClienteNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.NumCliente)
                    .HasConstraintName("FK__factura__num_cli__46E78A0C");

                entity.HasOne(d => d.NumVendedorNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.NumVendedor)
                    .HasConstraintName("FK__factura__num_ven__47DBAE45");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__producto__FF341C0D76BA21A8");

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .HasColumnType("text");

                entity.Property(e => e.Detalle)
                    .HasColumnName("detalle")
                    .HasColumnType("text");

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("text");

                entity.Property(e => e.NumeroCategoria).HasColumnName("numero_categoria");

                entity.HasOne(d => d.NumeroCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.NumeroCategoria)
                    .HasConstraintName("FK__producto__numero__403A8C7D");
            });

            modelBuilder.Entity<ProductoCiclo>(entity =>
            {
                entity.HasKey(e => e.IdProductoCiclo)
                    .HasName("PK__producto__F56F4BD3C3E11E06");

                entity.ToTable("producto_ciclo");

                entity.Property(e => e.IdProductoCiclo)
                    .HasColumnName("id_producto_ciclo")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cannon).HasColumnName("cannon");

                entity.Property(e => e.ComisionVendedor).HasColumnName("comision_vendedor");

                entity.Property(e => e.NumCiclo).HasColumnName("num_ciclo");

                entity.Property(e => e.NumProducto).HasColumnName("num_producto");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.PrecioPromocional).HasColumnName("precio_promocional");

                entity.HasOne(d => d.NumCicloNavigation)
                    .WithMany(p => p.ProductoCiclo)
                    .HasForeignKey(d => d.NumCiclo)
                    .HasConstraintName("FK__producto___num_c__4316F928");

                entity.HasOne(d => d.NumProductoNavigation)
                    .WithMany(p => p.ProductoCiclo)
                    .HasForeignKey(d => d.NumProducto)
                    .HasConstraintName("FK__producto___num_p__440B1D61");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdVendedor)
                    .HasName("PK__vendedor__009303088B4C7180");

                entity.ToTable("vendedor");

                entity.Property(e => e.IdVendedor)
                    .HasColumnName("id_vendedor")
                    .ValueGeneratedNever();

                entity.Property(e => e.Condicion).HasColumnName("condicion");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasColumnType("text");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("text");

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasColumnType("text");

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasColumnType("text");

                entity.Property(e => e.Instagram)
                    .HasColumnName("instagram")
                    .HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("text");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("text");

                entity.Property(e => e.Twitter)
                    .HasColumnName("twitter")
                    .HasColumnType("text");

                entity.Property(e => e.UsuarioContra)
                    .HasColumnName("usuario_contra")
                    .HasMaxLength(42)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioNombre)
                    .HasColumnName("usuario_nombre")
                    .HasMaxLength(42)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
