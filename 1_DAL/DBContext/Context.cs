using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;
using Microsoft.EntityFrameworkCore;

/*
namespace _1_DAL.DBContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source={ServerName};Initial Catalog={NameOfDatabase};Persist Security Info=True;User ID={AccountOfServer};Password={password}");
        }

        public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual DbSet<ChiTietThietBi> ChiTietThietBis { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CongThucTinh> CongThucTinhs { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<HoaDonBanHang> HoaDonBanHangs { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<LoaiThietBi> LoaiThietBis { get; set; }
        public virtual DbSet<MatHang> MatHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<Tang> Tangs { get; set; }
        public virtual DbSet<ThietBi> ThietBis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
            {
                entity.Property(e => e.IdchiTietHoaDonBan).ValueGeneratedNever();

                entity.Property(e => e.IdtranngThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.Idusername).IsUnicode(false);

                entity.HasOne(d => d.IdhoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDonBans)
                    .HasForeignKey(d => d.IdhoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonBan_HoaDonBanHang");

                entity.HasOne(d => d.IdmatHangNavigation)
                    .WithMany(p => p.ChiTietHoaDonBans)
                    .HasForeignKey(d => d.IdmatHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonBan_MatHang");
            });

            modelBuilder.Entity<ChiTietHoaDonNhap>(entity =>
            {
                entity.Property(e => e.IdchiTietHoaDonNhap).ValueGeneratedNever();

                entity.Property(e => e.IdtranngThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdhoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.IdhoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonNhap_HoaDonNhap");

                entity.HasOne(d => d.IdmatHangNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.IdmatHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonNhap_MatHang1");
            });

            modelBuilder.Entity<ChiTietThietBi>(entity =>
            {
                entity.Property(e => e.IdchiTietThietBi).ValueGeneratedNever();

                entity.Property(e => e.IdmaTb).IsUnicode(false);

                entity.Property(e => e.IdtranngThai).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdmaTbNavigation)
                    .WithMany(p => p.ChiTietThietBis)
                    .HasForeignKey(d => d.IdmaTb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietThietBi_ThietBi");

                entity.HasOne(d => d.IdphongNavigation)
                    .WithMany(p => p.ChiTietThietBis)
                    .HasForeignKey(d => d.Idphong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietThietBi_Phong");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdtrangThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CongThucTinh>(entity =>
            {
                entity.Property(e => e.IdcongThucTinh).ValueGeneratedNever();

                entity.Property(e => e.ThoiGianNhanUuDai1).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThoiGianNhanUuDai2).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThoiGianNhanUuDai3).HasDefaultValueSql("((0))");

                entity.Property(e => e.UuDai1).HasDefaultValueSql("((0))");

                entity.Property(e => e.UuDai2).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<DonViTinh>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdtranngThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayCapNhap).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NguoiCapNhap).HasDefaultValueSql("('admin')");

                entity.Property(e => e.NguoiTao).HasDefaultValueSql("('admin')");
            });

            modelBuilder.Entity<HoaDonBanHang>(entity =>
            {
                entity.Property(e => e.IdhoaDon).ValueGeneratedNever();

                entity.Property(e => e.IdmaKh).IsUnicode(false);

                entity.Property(e => e.IdmaNv).IsUnicode(false);

                entity.Property(e => e.IdtranngThai).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdcongThucTinhNavigation)
                    .WithMany(p => p.HoaDonBanHangs)
                    .HasForeignKey(d => d.IdcongThucTinh)
                    .HasConstraintName("FK_HoaDonBanHang_CongThucTinh");

                entity.HasOne(d => d.IdmaKhNavigation)
                    .WithMany(p => p.HoaDonBanHangs)
                    .HasForeignKey(d => d.IdmaKh)
                    .HasConstraintName("FK_HoaDonBanHang_KhachHang");

                entity.HasOne(d => d.IdmaNvNavigation)
                    .WithMany(p => p.HoaDonBanHangs)
                    .HasForeignKey(d => d.IdmaNv)
                    .HasConstraintName("FK_HoaDonBanHang_NhanVien");

                entity.HasOne(d => d.IdphongNavigation)
                    .WithMany(p => p.HoaDonBanHangs)
                    .HasForeignKey(d => d.Idphong)
                    .HasConstraintName("FK_HoaDonBanHang_Phong");
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdnhanVienNhap).IsUnicode(false);

                entity.Property(e => e.IdtranngThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayCapNhap).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayNhap).IsFixedLength(true);

                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NguoiCapNhap).HasDefaultValueSql("('admin')");

                entity.Property(e => e.NguoiTao).HasDefaultValueSql("('admin')");

                entity.HasOne(d => d.IdnhaCcNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.IdnhaCc)
                    .HasConstraintName("FK_HoaDonNhap_NhaCungCap1");

                entity.HasOne(d => d.IdnhanVienNhapNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.IdnhanVienNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonNhap_NhanVien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.MaKh).IsUnicode(false);

                entity.Property(e => e.DienThoai).IsUnicode(false);

                entity.Property(e => e.IdtranngThai).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LoaiPhong>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdtranngThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LoaiThietBi>(entity =>
            {
                entity.Property(e => e.MaLoaiTb).IsUnicode(false);

                entity.Property(e => e.IdtranngThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MatHang>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdtranngThai).HasDefaultValueSql("((1))");

                entity.Property(e => e.NgayCapNhap).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NguoiCapNhap).HasDefaultValueSql("('admin')");

                entity.Property(e => e.NguoiTao).HasDefaultValueSql("('admin')");

                entity.HasOne(d => d.IddonViTinhNavigation)
                    .WithMany(p => p.MatHangs)
                    .HasForeignKey(d => d.IddonViTinh)
                    .HasConstraintName("FK_MatHang_DonViTinh");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.IdtranngThai).HasDefaultValueSql("((1))");

                entity.Property(e => e.NgayCapNhap).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NguoiCapNhap).HasDefaultValueSql("('admin')");

                entity.Property(e => e.NguoiTao).HasDefaultValueSql("('admin')");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.Property(e => e.MaNv).IsUnicode(false);

                entity.Property(e => e.IdtranngThai).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.IdchucVuNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdchucVu)
                    .HasConstraintName("FK_NhanVien_ChucVu");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdtranngThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayCapNhap).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NguoiCapNhap).HasDefaultValueSql("('admin')");

                entity.Property(e => e.NguoiTao).HasDefaultValueSql("('admin')");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdloaiPhongNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.IdloaiPhong)
                    .HasConstraintName("FK_Phong_LoaiPhong");

                entity.HasOne(d => d.IdtangNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.Idtang)
                    .HasConstraintName("FK_Phong_Tang");
            });

            modelBuilder.Entity<Tang>(entity =>
            {
                entity.Property(e => e.Idtang).ValueGeneratedNever();

                entity.Property(e => e.TenTang).IsFixedLength(true);
            });

            modelBuilder.Entity<ThietBi>(entity =>
            {
                entity.Property(e => e.MaTb).IsUnicode(false);

                entity.Property(e => e.IdmaLoaiTb).IsUnicode(false);

                entity.Property(e => e.IdtranngThai)
                    .HasDefaultValueSql("((1))")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdmaLoaiTbNavigation)
                    .WithMany(p => p.ThietBis)
                    .HasForeignKey(d => d.IdmaLoaiTb)
                    .HasConstraintName("FK_ThietBi_LoaiThietBi");
            });
        }
    }
}
}*/
