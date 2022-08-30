﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace De02.Models
{
    public partial class QuanLySanPhamDBContext : DbContext
    {
        public QuanLySanPhamDBContext()
        {
        }

        public QuanLySanPhamDBContext(DbContextOptions<QuanLySanPhamDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhomHang> NhomHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=THANG02\\SQLEXPRESS04;Initial Catalog=QuanLySanPhamDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<NhomHang>(entity =>
            {
                entity.HasKey(e => e.MaNhomHang)
                    .HasName("PK__NhomHang__2C886681BD5E2E1C");

                entity.ToTable("NhomHang");

                entity.Property(e => e.MaNhomHang).ValueGeneratedNever();

                entity.Property(e => e.TenNhomHang).HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081C4FFD1D87");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .ValueGeneratedNever()
                    .HasColumnName("MaSP");

                entity.Property(e => e.TenSanPham).HasMaxLength(50);

                entity.HasOne(d => d.MaNhomHangNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNhomHang)
                    .HasConstraintName("FK__SanPham__MaNhomH__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}