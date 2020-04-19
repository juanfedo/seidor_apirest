using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Seidor_ApiRest.Models
{
    public partial class SeidorDbContext : DbContext
    {
        public SeidorDbContext()
        {
        }

        public SeidorDbContext(DbContextOptions<SeidorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("dbcon"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("ciudad");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("vendedor");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCiudad).HasColumnName("codigo_ciudad");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasColumnName("numero_identificacion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoCiudadNavigation)
                    .WithMany(p => p.Vendedor)
                    .HasForeignKey(d => d.CodigoCiudad)
                    .HasConstraintName("FK_vendedor_ciudad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
