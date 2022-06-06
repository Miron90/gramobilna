using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EqService.Model
{
    public partial class UpgradesContext : DbContext
    {
        public UpgradesContext()
        {
        }

        public UpgradesContext(DbContextOptions<UpgradesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eq> Eqs { get; set; }
        public virtual DbSet<Eqnow> Eqnows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:upgradesserver.database.windows.net,1433;Initial Catalog=eqDatabase;Persist Security Info=False;User ID=upgradesserver;Password=Upgrades!23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Eq>(entity =>
            {
                entity.Property(e => e.Typ).IsUnicode(false);
            });

            modelBuilder.Entity<Eqnow>(entity =>
            {
                entity.Property(e => e.Typ).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
