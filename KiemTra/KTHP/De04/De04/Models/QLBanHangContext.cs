using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace De04.Models
{
    public partial class QLBanHangContext : DbContext
    {
        public QLBanHangContext()
        {
        }

        public QLBanHangContext(DbContextOptions<QLBanHangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DanhMucHang> DanhMucHangs { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=THANG02\\SQLEXPRESS04;Initial Catalog=QLBanHang;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<DanhMucHang>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DanhMucH__2725866E4D0462DA");

                entity.ToTable("DanhMucHang");

                entity.Property(e => e.MaDm)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaDM")
                    .IsFixedLength(true);

                entity.Property(e => e.TenDm)
                    .HasMaxLength(50)
                    .HasColumnName("TenDM");
            });

            modelBuilder.Entity<Hang>(entity =>
            {
                entity.HasKey(e => e.MaHang)
                    .HasName("PK__Hang__19C0DB1DAC306575");

                entity.ToTable("Hang");

                entity.Property(e => e.MaHang)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaDm)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaDM")
                    .IsFixedLength(true);

                entity.Property(e => e.TenHang).HasMaxLength(30);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.Hangs)
                    .HasForeignKey(d => d.MaDm)
                    .HasConstraintName("FK__Hang__MaDM__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
