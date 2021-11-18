using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoesAPI.Models;

namespace ShoesAPI.Helpers
{
    public partial class QLBanGiayDbContext : DbContext
    {
        public QLBanGiayDbContext()
        {
        }

        public QLBanGiayDbContext(DbContextOptions<QLBanGiayDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Ctgiay> Ctgiays { get; set; }
        public virtual DbSet<Cthdban> Cthdbans { get; set; }
        public virtual DbSet<Cthdnhap> Cthdnhaps { get; set; }
        public virtual DbSet<Giay> Giays { get; set; }
        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TA8B4IGR\\SQLEXPRESS;Database=QLBanGiay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.IdchucVu);

                entity.ToTable("ChucVu");

                entity.Property(e => e.IdchucVu).HasColumnName("IDChucVu");

                entity.Property(e => e.TenChucVu).HasMaxLength(50);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Idcolor);

                entity.ToTable("Color");

                entity.Property(e => e.Idcolor).HasColumnName("IDColor");

                entity.Property(e => e.Color1)
                    .HasMaxLength(10)
                    .HasColumnName("Color")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Ctgiay>(entity =>
            {
                entity.ToTable("CTGiay");

                entity.Property(e => e.Idgiay).HasColumnName("IDGiay");

                entity.Property(e => e.Idsize).HasColumnName("IDSize");

                entity.HasOne(d => d.IdgiayNavigation)
                    .WithMany(p => p.Ctgiays)
                    .HasForeignKey(d => d.Idgiay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTGiay_Giay1");

                entity.HasOne(d => d.IdsizeNavigation)
                    .WithMany(p => p.Ctgiays)
                    .HasForeignKey(d => d.Idsize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTGiay_Size1");
            });

            modelBuilder.Entity<Cthdban>(entity =>
            {
                entity.ToTable("CTHDBan");

                entity.Property(e => e.MaHdb)
                    .HasMaxLength(10)
                    .HasColumnName("MaHDB")
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaHdbNavigation)
                    .WithMany(p => p.Cthdbans)
                    .HasForeignKey(d => d.MaHdb)
                    .HasConstraintName("FK_CTHDBan_HoaDonBan");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Cthdbans)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CTHDBan_Giay");
            });

            modelBuilder.Entity<Cthdnhap>(entity =>
            {
                entity.ToTable("CTHDNhap");

                entity.Property(e => e.MaHdn)
                    .HasMaxLength(10)
                    .HasColumnName("MaHDN")
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaHdnNavigation)
                    .WithMany(p => p.Cthdnhaps)
                    .HasForeignKey(d => d.MaHdn)
                    .HasConstraintName("FK_CTHDNhap_HoaDonNhap");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Cthdnhaps)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CTHDNhap_Giay");
            });

            modelBuilder.Entity<Giay>(entity =>
            {
                entity.HasKey(e => e.Idgiay)
                    .HasName("PK_SanPham");

                entity.ToTable("Giay");

                entity.Property(e => e.Idgiay).HasColumnName("IDGiay");

                entity.Property(e => e.Cover).IsUnicode(false);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.Idcolor).HasColumnName("IDColor");

                entity.Property(e => e.IdthuongHieu).HasColumnName("IDThuongHieu");

                entity.Property(e => e.TenGiay).HasMaxLength(50);

                entity.HasOne(d => d.IdcolorNavigation)
                    .WithMany(p => p.Giays)
                    .HasForeignKey(d => d.Idcolor)
                    .HasConstraintName("FK_Giay_Color");

                entity.HasOne(d => d.IdthuongHieuNavigation)
                    .WithMany(p => p.Giays)
                    .HasForeignKey(d => d.IdthuongHieu)
                    .HasConstraintName("FK_Giay_ThuongHieu");
            });

            modelBuilder.Entity<HoaDonBan>(entity =>
            {
                entity.HasKey(e => e.MaHdb);

                entity.ToTable("HoaDonBan");

                entity.Property(e => e.MaHdb)
                    .HasMaxLength(10)
                    .HasColumnName("MaHDB")
                    .IsFixedLength(true);

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayLapHd)
                    .HasColumnType("date")
                    .HasColumnName("NgayLapHD");

                entity.Property(e => e.NgayLayHang).HasColumnType("date");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDonBans)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_HoaDonBan_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDonBans)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_HoaDonBan_NhanVien");
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaHdn);

                entity.ToTable("HoaDonNhap");

                entity.Property(e => e.MaHdn)
                    .HasMaxLength(10)
                    .HasColumnName("MaHDN")
                    .IsFixedLength(true);

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(10)
                    .HasColumnName("MaNCC")
                    .IsFixedLength(true);

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayLapHd)
                    .HasColumnType("date")
                    .HasColumnName("NgayLapHD");

                entity.Property(e => e.NgayNhanHang).HasColumnType("date");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK_HoaDonNhap_NhaCungCap");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_HoaDonNhap_NhanVien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.HoTenKh)
                    .HasMaxLength(100)
                    .HasColumnName("HoTenKH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc);

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(10)
                    .HasColumnName("MaNCC")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GiamDoc).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(50)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.Cmnd)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CMND")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdchucVu).HasColumnName("IDChucVu");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.IdchucVuNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdchucVu)
                    .HasConstraintName("FK_NhanVien_ChucVu");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.Idsize);

                entity.ToTable("Size");

                entity.Property(e => e.Idsize).HasColumnName("IDSize");
            });

            modelBuilder.Entity<ThuongHieu>(entity =>
            {
                entity.HasKey(e => e.IdthuongHieu);

                entity.ToTable("ThuongHieu");

                entity.Property(e => e.IdthuongHieu).HasColumnName("IDThuongHieu");

                entity.Property(e => e.TenThuongHieu).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
