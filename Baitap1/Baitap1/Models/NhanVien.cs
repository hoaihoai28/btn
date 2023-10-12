using System.ComponentModel.DataAnnotations;

namespace Baitap1.Models
{
    public class NhanVien
    {
        [Key]
        public int id_nhanvien { get; set; }
        public string? hoten { get; set; }
        public string? gioitinh { get; set; }
        public DateTime ngaysinh { get; set; }
        public string? TenDangNhap { get; set; }
        public string? MatKhau { get; set; }
        public string? DienThoai { get; set; }
        public bool Admins { get; set; }
    }
}
