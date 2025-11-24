using System;
using System.Collections.Generic;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class ETFormulasDBContext : DbContext
{
    public ETFormulasDBContext()
    {
    }

    public ETFormulasDBContext(DbContextOptions<ETFormulasDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Formula> Formulas { get; set; }

    public virtual DbSet<FormulaDetalle> FormulaDetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Formula>(entity =>
        {
            entity.HasKey(e => e.Idformula).HasName("PK__Formula__C9A955C51B343411");

            entity.ToTable("Formula");

            entity.Property(e => e.Idformula).HasColumnName("IDFormula");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.IdusuarioActualizacion).HasColumnName("IDUsuarioActualizacion");
            entity.Property(e => e.IdusuarioCreacion).HasColumnName("IDUsuarioCreacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Formulas)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Formula_Producto");

            entity.HasOne(d => d.IdusuarioActualizacionNavigation).WithMany(p => p.FormulaIdusuarioActualizacionNavigations)
                .HasForeignKey(d => d.IdusuarioActualizacion)
                .HasConstraintName("FK_Formula_Usuario_Act");

            entity.HasOne(d => d.IdusuarioCreacionNavigation).WithMany(p => p.FormulaIdusuarioCreacionNavigations)
                .HasForeignKey(d => d.IdusuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Formula_Usuario_Crea");
        });

        modelBuilder.Entity<FormulaDetalle>(entity =>
        {
            entity.HasKey(e => new { e.Idformula, e.Linea });

            entity.ToTable("FormulaDetalle");

            entity.Property(e => e.Idformula).HasColumnName("IDFormula");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdformulaNavigation).WithMany(p => p.FormulaDetalles)
                .HasForeignKey(d => d.Idformula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormulaDetalle_Formula");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__Producto__ABDAF2B495262392");

            entity.ToTable("Producto");

            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C8F133154");

            entity.ToTable("Rol");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97AE84A015");

            entity.ToTable("Usuario");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
