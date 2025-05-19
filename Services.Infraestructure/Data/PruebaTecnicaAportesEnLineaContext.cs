using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Services.Core.Entities;

namespace Services.Infraestructure.Data;

public partial class PruebaTecnicaAportesEnLineaContext : DbContext
{
    public PruebaTecnicaAportesEnLineaContext()
    {
    }

    public PruebaTecnicaAportesEnLineaContext(DbContextOptions<PruebaTecnicaAportesEnLineaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.IdDepartament).HasName("PK__Departme__3ABB940FB7F1E00A");

            entity.ToTable("Department");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07A9491531");

            entity.ToTable("Employee");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

            entity.Property(e => e.Position) 
        .HasConversion<string>()
        .HasMaxLength(50)
        .IsUnicode(false);

            entity.HasOne(d => d.IdDepartamentNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdDepartament)
                .HasConstraintName("FK__Employee__IdDepa__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
