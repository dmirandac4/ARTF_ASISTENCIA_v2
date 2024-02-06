using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ARTF_ASISTENCIA_v2.Models;

public partial class BaseasistenciaContext : DbContext
{
    public BaseasistenciaContext()
    {
    }

    public BaseasistenciaContext(DbContextOptions<BaseasistenciaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Asistencium> Asistencia { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=baseasistencia;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Area1).HasName("PRIMARY");

            entity.ToTable("area");

            entity.Property(e => e.Area1)
                .HasMaxLength(20)
                .HasColumnName("area");
            entity.Property(e => e.Numarea)
                .HasPrecision(30)
                .HasColumnName("numarea");
        });

        modelBuilder.Entity<Asistencium>(entity =>
        {
            entity.HasKey(e => e.DiaReg).HasName("PRIMARY");

            entity.ToTable("asistencia");

            entity.HasIndex(e => e.Numemp, "Asistencia_Numemp_FK");

            entity.Property(e => e.DiaReg).HasColumnType("datetime");
            entity.Property(e => e.HrfhIng)
                .HasColumnType("datetime")
                .HasColumnName("hrfh_Ing");
            entity.Property(e => e.HrfhSal)
                .HasColumnType("datetime")
                .HasColumnName("hrfh_Sal");
            entity.Property(e => e.Justificaciones)
                .HasMaxLength(50)
                .HasColumnName("justificaciones");
            entity.Property(e => e.Numemp).HasPrecision(20);
            entity.Property(e => e.Observaciones)
                .HasMaxLength(50)
                .HasColumnName("observaciones");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Numemp).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.Area, "Empleados_area_FK");

            entity.Property(e => e.Numemp).HasPrecision(20);
            entity.Property(e => e.Area)
                .HasMaxLength(20)
                .HasColumnName("area");
            entity.Property(e => e.Curp)
                .HasMaxLength(20)
                .HasColumnName("CURP");
            entity.Property(e => e.Huella)
                .HasColumnType("blob")
                .HasColumnName("huella");
            entity.Property(e => e.Huella2)
                .HasColumnType("blob")
                .HasColumnName("huella2");
            entity.Property(e => e.Huella3)
                .HasColumnType("blob")
                .HasColumnName("huella3");
            entity.Property(e => e.Huella4)
                .HasColumnType("blob")
                .HasColumnName("huella4");
            entity.Property(e => e.Huella5)
                .HasColumnType("blob")
                .HasColumnName("huella5");
            entity.Property(e => e.NombreEmp)
                .HasMaxLength(50)
                .HasColumnName("Nombre_emp");
            entity.Property(e => e.Puesto)
                .HasMaxLength(30)
                .HasColumnName("puesto");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .HasColumnName("RFC");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.Idusuario).ValueGeneratedNever();
            entity.Property(e => e.Contraseña)
                .HasMaxLength(30)
                .HasColumnName("contraseña");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(30)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
