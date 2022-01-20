using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReactProjectNET6.Api.Models
{
    public partial class dbSatCenterContext : DbContext
    {
        public dbSatCenterContext()
        {
        }

        public dbSatCenterContext(DbContextOptions<dbSatCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipos { get; set; } = null!;
        public virtual DbSet<EquipoTipo> EquipoTipos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP\\SQL;Database=dbSatCenter;user=sa;password=(8246*)?");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.IdEquipo);

                entity.Property(e => e.Alto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ancho).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CodigoEquipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ColorPrincipal)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionEquipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Largo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Serial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEquipoTipoNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.IdEquipoTipo)
                    .HasConstraintName("FK_EquipoTipos_Equipos");
            });

            modelBuilder.Entity<EquipoTipo>(entity =>
            {
                entity.HasKey(e => e.IdEquipoTipo);

                entity.Property(e => e.CodigoEquipoTipo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionEquipoTipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
