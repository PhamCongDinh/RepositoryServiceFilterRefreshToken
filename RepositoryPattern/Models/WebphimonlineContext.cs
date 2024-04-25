using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models.Req;

namespace RepositoryPattern.Models;

public partial class WebphimonlineContext : DbContext
{
    public WebphimonlineContext()
    {
    }

    public WebphimonlineContext(DbContextOptions<WebphimonlineContext> options)
        : base(options)
    {
    }
    public virtual DbSet<FunctionSQL> Functions { get; set; }   
    public virtual DbSet<product> products { get; set; }
    public virtual DbSet<DanhSach> danhsach { get; set; }
    public virtual DbSet<Binhluan> Binhluans { get; set; }

    public virtual DbSet<Chitiethd> Chitiethds { get; set; }

    public virtual DbSet<Chitiethdn> Chitiethdns { get; set; }

    public virtual DbSet<Danhgia> Danhgia { get; set; }

    public virtual DbSet<Hangphim> Hangphims { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Hoadonnhap> Hoadonnhaps { get; set; }

    public virtual DbSet<Lichsuphim> Lichsuphims { get; set; }

    public virtual DbSet<Loaiphim> Loaiphims { get; set; }

    public virtual DbSet<Phim> Phims { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Tapphim> Tapphims { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-TGUQGH9P\\SQLEXPRESS;Initial Catalog=webphimonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Binhluan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__binhluan__3214EC275BC9BBC8");

            entity.ToTable("binhluan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdTapPhim).HasColumnName("ID_TapPhim");
            entity.Property(e => e.IdTk).HasColumnName("ID_TK");
            entity.Property(e => e.NoiDung)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ThoiGian)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdTapPhimNavigation).WithMany(p => p.Binhluans)
                .HasForeignKey(d => d.IdTapPhim)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__binhluan__ID_Tap__6EF57B66");

            entity.HasOne(d => d.IdTkNavigation).WithMany(p => p.Binhluans)
                .HasForeignKey(d => d.IdTk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__binhluan__ID_TK__6FE99F9F");
        });

        modelBuilder.Entity<Chitiethd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__chitieth__3214EC27E9CEB0C5");

            entity.ToTable("chitiethd");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdHd)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_HD");
            entity.Property(e => e.IdTk)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_TK");
            entity.Property(e => e.NgayNhan).HasColumnType("datetime");
            entity.Property(e => e.SoTien).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdHdNavigation).WithMany(p => p.Chitiethds)
                .HasForeignKey(d => d.IdHd)
                .HasConstraintName("FK__chitiethd__ID_HD__76969D2E");

            entity.HasOne(d => d.IdTkNavigation).WithMany(p => p.Chitiethds)
                .HasForeignKey(d => d.IdTk)
                .HasConstraintName("FK__chitiethd__ID_TK__75A278F5");
        });

        modelBuilder.Entity<Chitiethdn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__chitieth__3214EC27F2764427");

            entity.ToTable("chitiethdn");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GiaPhim).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdPnk)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_PNK");
            entity.Property(e => e.IdTapPhim)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_TapPhim");

            entity.HasOne(d => d.IdPnkNavigation).WithMany(p => p.Chitiethdns)
                .HasForeignKey(d => d.IdPnk)
                .HasConstraintName("FK__chitiethd__ID_PN__7C4F7684");

            entity.HasOne(d => d.IdTapPhimNavigation).WithMany(p => p.Chitiethdns)
                .HasForeignKey(d => d.IdTapPhim)
                .HasConstraintName("FK__chitiethd__ID_Ta__7D439ABD");
        });

        modelBuilder.Entity<Danhgia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__danhgia__3214EC27B0908A04");

            entity.ToTable("danhgia");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdTapPhim).HasColumnName("ID_TapPhim");
            entity.Property(e => e.IdTk).HasColumnName("ID_TK");
            entity.Property(e => e.SoDiem).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ThoiGian)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdTapPhimNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.IdTapPhim)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__danhgia__ID_TapP__693CA210");

            entity.HasOne(d => d.IdTkNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.IdTk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__danhgia__ID_TK__6A30C649");
        });

        modelBuilder.Entity<Hangphim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hangphim__3214EC2776FC360C");

            entity.ToTable("hangphim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenHangPhim)
                .HasMaxLength(50)
                .HasColumnName("Ten_HangPhim");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hoadon__3214EC2794FBD058");

            entity.ToTable("hoadon");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
        });

        modelBuilder.Entity<Hoadonnhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hoadonnh__3214EC272B346CEC");

            entity.ToTable("hoadonnhap");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
        });

        modelBuilder.Entity<Lichsuphim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lichsuph__3214EC2734C1EBF4");

            entity.ToTable("lichsuphim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.IdTapphim).HasColumnName("ID_Tapphim");
            entity.Property(e => e.IdTk).HasColumnName("ID_TK");

            entity.HasOne(d => d.IdTapphimNavigation).WithMany(p => p.Lichsuphims)
                .HasForeignKey(d => d.IdTapphim)
                .HasConstraintName("FK__lichsuphi__ID_Ta__40F9A68C");

            entity.HasOne(d => d.IdTkNavigation).WithMany(p => p.Lichsuphims)
                .HasForeignKey(d => d.IdTk)
                .HasConstraintName("FK__lichsuphi__ID_TK__41EDCAC5");
        });

        modelBuilder.Entity<Loaiphim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__loaiphim__3214EC2716994132");

            entity.ToTable("loaiphim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenLp)
                .HasMaxLength(50)
                .HasColumnName("Ten_LP");
        });

        modelBuilder.Entity<Phim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__phim__3214EC2749695C36");

            entity.ToTable("phim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnhPhim)
                .HasMaxLength(50)
                .HasColumnName("Anh_Phim");
            entity.Property(e => e.DanhGia).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdHangPhim)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_HangPhim");
            entity.Property(e => e.IdLp)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_LP");
            entity.Property(e => e.MoTa)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.NgayPhatHanh).HasColumnType("datetime");
            entity.Property(e => e.TenPhim)
                .HasMaxLength(50)
                .HasColumnName("Ten_Phim");
            entity.Property(e => e.ThoiLuongPhim)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.IdHangPhimNavigation).WithMany(p => p.Phims)
                .HasForeignKey(d => d.IdHangPhim)
                .HasConstraintName("FK__phim__ID_HangPhi__5CD6CB2B");

            entity.HasOne(d => d.IdLpNavigation).WithMany(p => p.Phims)
                .HasForeignKey(d => d.IdLp)
                .HasConstraintName("FK__phim__ID_LP__5DCAEF64");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__taikhoan__3214EC272A392132");

            entity.ToTable("taikhoan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LoaiTk).HasColumnName("Loai_TK");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenTk)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("Ten_TK");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RefreshToken");
        });

        modelBuilder.Entity<Tapphim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tapphim__3214EC27E875C46D");

            entity.ToTable("tapphim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPhim)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_Phim");
            entity.Property(e => e.ThoiGianChieu).HasColumnType("datetime");
            entity.Property(e => e.ThoiHan).HasColumnType("datetime");
            entity.Property(e => e.ThoiLuong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UrlPhim)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("URL_Phim");
            entity.Property(e => e.UrlTrailer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("URL_Trailer");

            entity.HasOne(d => d.IdPhimNavigation).WithMany(p => p.Tapphims)
                .HasForeignKey(d => d.IdPhim)
                .HasConstraintName("FK__tapphim__ID_Phim__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
