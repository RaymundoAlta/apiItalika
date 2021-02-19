using System;
using Italika.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Italika.Infrastructure.Data
{
    public partial class ItalikaContext : DbContext
    {
        public ItalikaContext()
        {
        }

        public ItalikaContext(DbContextOptions<ItalikaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Productos> Productos { get; set; }
        public object Publicacion { get; internal set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=Ray; Database=Italika; Integrated Security= True");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(e => e.Fechar).HasColumnType("datetime");

                entity.Property(e => e.Fert)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumeroSerie)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
