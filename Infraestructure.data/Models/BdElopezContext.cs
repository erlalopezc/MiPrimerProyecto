using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.data.Models;

public partial class BdElopezContext : DbContext
{
    public BdElopezContext()
    {
    }

    public BdElopezContext(DbContextOptions<BdElopezContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=elopez-server.database.windows.net;Database=bd_elopez;User Id=admin_elopez;Password=4dmin_2023;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CodigoCat).HasName("pk_categoria");

            entity.ToTable("categoria");

            entity.Property(e => e.CodigoCat).HasColumnName("codigo_cat");
            entity.Property(e => e.NombreCat)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre_cat");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.CodigoCompra).HasName("pk_compra");

            entity.ToTable("compra");

            entity.Property(e => e.CodigoCompra).HasColumnName("codigo_compra");
            entity.Property(e => e.NombreCompra)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_compra");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProd).HasName("pk_producto");

            entity.ToTable("producto");

            entity.Property(e => e.CodigoProd).HasColumnName("codigo_prod");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cantidad");
            entity.Property(e => e.CodigoCat).HasColumnName("codigo_cat");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.NombreProd)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_prod");
            entity.Property(e => e.PrecioCompra).HasColumnName("precio_compra");
            entity.Property(e => e.PrecioVenta).HasColumnName("precio_venta");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.CodigoVenta).HasName("pk_venta");

            entity.ToTable("venta");

            entity.Property(e => e.CodigoVenta).HasColumnName("codigo_venta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoProd).HasColumnName("codigo_prod");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.CodigoProdNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CodigoProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_venta_producto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
