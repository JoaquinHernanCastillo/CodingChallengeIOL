using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CodingChallenge.Models
{
    public partial class CodingChallengeContext : DbContext
    {
        public CodingChallengeContext()
        {
        }

        public CodingChallengeContext(DbContextOptions<CodingChallengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Forma> Formas { get; set; }
        public virtual DbSet<FormasIdioma> FormasIdiomas { get; set; }
        public virtual DbSet<Idioma> Idiomas { get; set; }
        public virtual DbSet<Traduccione> Traducciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CodingChallenge;user=sa,password=123456;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Forma>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CalculoArea)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CalculoPerimetro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Forma1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forma");
            });

            modelBuilder.Entity<FormasIdioma>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Plural)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Singular)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Idioma1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Idioma");
            });

            modelBuilder.Entity<Traduccione>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListaVacia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Perimetro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReporteDeFormas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
