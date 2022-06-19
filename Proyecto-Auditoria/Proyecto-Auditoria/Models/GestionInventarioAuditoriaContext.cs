using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_Auditoria.Models
{
    public partial class GestionInventarioAuditoriaContext : DbContext
    {
        public GestionInventarioAuditoriaContext()
        {
        }

        public GestionInventarioAuditoriaContext(DbContextOptions<GestionInventarioAuditoriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activo> Activos { get; set; } = null!;
        public virtual DbSet<Auditorium> Auditoria { get; set; } = null!;
        public virtual DbSet<CaracteristicaActivo> CaracteristicaActivos { get; set; } = null!;
        public virtual DbSet<EventosActivo> EventosActivos { get; set; } = null!;
        public virtual DbSet<HallazgosAuditorium> HallazgosAuditoria { get; set; } = null!;
        public virtual DbSet<ListadoCaracteristicaTipoActivo> ListadoCaracteristicaTipoActivos { get; set; } = null!;
        public virtual DbSet<TipoActivo> TipoActivos { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-7EK03LQ\SQLEXPRESS; Database=Gestion-Inventario-Auditoria;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activo>(entity =>
            {
                entity.HasKey(e => e.CodigoActivo);

                entity.ToTable("Activo");

                entity.Property(e => e.CodigoActivo).HasColumnName("codigoActivo");

                entity.Property(e => e.CodigoTipoActivo).HasColumnName("codigoTipoActivo");

                entity.Property(e => e.CodigoUbicacion).HasColumnName("codigoUbicacion");

                entity.Property(e => e.Depreciacion).HasColumnName("depreciacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaAdquisicion)
                    .HasColumnType("date")
                    .HasColumnName("fechaAdquisicion");

                entity.Property(e => e.ValorActual)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorActual");

                entity.Property(e => e.ValorInicial)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorInicial");

                entity.HasOne(d => d.CodigoTipoActivoNavigation)
                    .WithMany(p => p.Activos)
                    .HasForeignKey(d => d.CodigoTipoActivo)
                    .HasConstraintName("FK_Activo_TipoActivo");

                entity.HasOne(d => d.CodigoUbicacionNavigation)
                    .WithMany(p => p.Activos)
                    .HasForeignKey(d => d.CodigoUbicacion)
                    .HasConstraintName("FK_Activo_Ubicacion");
            });

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.HasKey(e => e.CodigoAuditoria);

                entity.Property(e => e.CodigoAuditoria).HasColumnName("codigoAuditoria");

                entity.Property(e => e.CodigoActivo).HasColumnName("codigoActivo");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("date")
                    .HasColumnName("fechaFinal");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicial");

                entity.Property(e => e.Objetivo).HasMaxLength(50);

                entity.Property(e => e.Responsable).HasMaxLength(50);

                entity.Property(e => e.Titulo).HasMaxLength(50);

                entity.HasOne(d => d.CodigoActivoNavigation)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.CodigoActivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Auditoria_Activo");
            });

            modelBuilder.Entity<CaracteristicaActivo>(entity =>
            {
                entity.HasKey(e => e.CodigoCaracteristica);

                entity.ToTable("CaracteristicaActivo");

                entity.Property(e => e.CodigoCaracteristica).HasColumnName("codigoCaracteristica");

                entity.Property(e => e.CodigoActivo).HasColumnName("codigoActivo");

                entity.Property(e => e.CodigoListadoCaracteristica).HasColumnName("codigoListadoCaracteristica");

                entity.Property(e => e.DescripcionCaracteristica)
                    .IsUnicode(false)
                    .HasColumnName("descripcionCaracteristica");

                entity.HasOne(d => d.CodigoActivoNavigation)
                    .WithMany(p => p.CaracteristicaActivos)
                    .HasForeignKey(d => d.CodigoActivo)
                    .HasConstraintName("FK_CaracteristicaActivo_Activo");

                entity.HasOne(d => d.CodigoListadoCaracteristicaNavigation)
                    .WithMany(p => p.CaracteristicaActivos)
                    .HasForeignKey(d => d.CodigoListadoCaracteristica)
                    .HasConstraintName("FK_CaracteristicaActivo_ListadoCaracteristicaTipoActivo");
            });

            modelBuilder.Entity<EventosActivo>(entity =>
            {
                entity.HasKey(e => e.CodigoEventoActivo)
                    .HasName("PK_Table_1");

                entity.ToTable("EventosActivo");

                entity.Property(e => e.CodigoEventoActivo).HasColumnName("codigoEventoActivo");

                entity.Property(e => e.CodigoActivo).HasColumnName("codigoActivo");

                entity.Property(e => e.DescripcionEvento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionEvento");

                entity.Property(e => e.FechaEvento)
                    .HasColumnType("date")
                    .HasColumnName("fechaEvento");

                entity.HasOne(d => d.CodigoActivoNavigation)
                    .WithMany(p => p.EventosActivos)
                    .HasForeignKey(d => d.CodigoActivo)
                    .HasConstraintName("FK_EventosActivo_Activo");
            });

            modelBuilder.Entity<HallazgosAuditorium>(entity =>
            {
                entity.HasKey(e => e.CodigoHallazgos);

                entity.Property(e => e.CodigoHallazgos)
                    .ValueGeneratedNever()
                    .HasColumnName("codigoHallazgos");

                entity.Property(e => e.CodigoAuditoria).HasColumnName("codigoAuditoria");

                entity.Property(e => e.DescripcionHallazgo)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.TituloHallazgo)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.CodigoAuditoriaNavigation)
                    .WithMany(p => p.HallazgosAuditoria)
                    .HasForeignKey(d => d.CodigoAuditoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HallazgosAuditoria_Auditoria");
            });

            modelBuilder.Entity<ListadoCaracteristicaTipoActivo>(entity =>
            {
                entity.HasKey(e => e.CodigoListadoCaracteristica);

                entity.ToTable("ListadoCaracteristicaTipoActivo");

                entity.Property(e => e.CodigoListadoCaracteristica).HasColumnName("codigoListadoCaracteristica");

                entity.Property(e => e.CodigoTipoActivo).HasColumnName("codigoTipoActivo");

                entity.Property(e => e.DescripcionCaracteristica)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionCaracteristica");

                entity.HasOne(d => d.CodigoTipoActivoNavigation)
                    .WithMany(p => p.ListadoCaracteristicaTipoActivos)
                    .HasForeignKey(d => d.CodigoTipoActivo)
                    .HasConstraintName("FK_ListadoCaracteristicaTipoActivo_TipoActivo");
            });

            modelBuilder.Entity<TipoActivo>(entity =>
            {
                entity.HasKey(e => e.CodigoTipoActivo);

                entity.ToTable("TipoActivo");

                entity.Property(e => e.CodigoTipoActivo).HasColumnName("codigoTipoActivo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.CodigoUbicacion);

                entity.ToTable("Ubicacion");

                entity.Property(e => e.CodigoUbicacion).HasColumnName("codigoUbicacion");

                entity.Property(e => e.CentroCosto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("centroCosto");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.CuentaGastos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cuentaGastos");

                entity.Property(e => e.DescripcionUbicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionUbicacion");

                entity.Property(e => e.NombreServidor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreServidor");

                entity.Property(e => e.NumeroEstante).HasColumnName("numeroEstante");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
