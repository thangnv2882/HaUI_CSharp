using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoEFCore.Models
{
    public partial class DemoBai11Context : DbContext
    {
        public DemoBai11Context()
        {
        }

        public DemoBai11Context(DbContextOptions<DemoBai11Context> options)
            : base(options)
        {
        }

        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=THANG02\\SQLEXPRESS04;Initial Catalog=DemoBai11;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LoaiSanP__734B3AEA116942BA");

                entity.ToTable("LoaiSanPham");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(20)
                    .HasColumnName("maloai");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(30)
                    .HasColumnName("tenloai");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PK__SanPham__7A2176722E409668");

                entity.ToTable("SanPham");

                entity.Property(e => e.Masp)
                    .HasMaxLength(20)
                    .HasColumnName("masp");

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Maloai)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("maloai");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Tensp)
                    .HasMaxLength(30)
                    .HasColumnName("tensp");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.Maloai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lsp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
