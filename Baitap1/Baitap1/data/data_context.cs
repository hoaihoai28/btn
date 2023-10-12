using Baitap1.Models;
using Microsoft.EntityFrameworkCore;

namespace Baitap1.data
{
    public class data_context:DbContext
    {
        public data_context()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {

            option.UseSqlServer("Server=DESKTOP-92O3OC3\\VANHOAI; Database = QLCH;" +
                "User ID=sa;Password=123;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        public DbSet<PhanQuyen> PhanQuyens { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<CuaHang> CuaHangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<NamThang> NamThangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình các mối quan hệ giữa các bảng
            modelBuilder.Entity<PhanQuyen>()
                .HasOne(pq => pq.NhanVien)
                .WithMany()
                .HasForeignKey(pq => pq.id_nhanvien);

            modelBuilder.Entity<PhanQuyen>()
                .HasOne(pq => pq.CuaHang)
                .WithMany()
                .HasForeignKey(pq => pq.id_cuahang);

            modelBuilder.Entity<PhanQuyen>()
                .HasOne(pq => pq.SanPham)
                .WithMany()
                .HasForeignKey(pq => pq.id_sanpham);

            modelBuilder.Entity<PhanQuyen>()
                .HasOne(pq => pq.NamThang)
                .WithMany()
                .HasForeignKey(pq => pq.id_namthang);
        }
    }
}
