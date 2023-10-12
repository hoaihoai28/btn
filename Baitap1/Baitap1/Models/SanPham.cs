using System.ComponentModel.DataAnnotations;

namespace Baitap1.Models
{
    public class SanPham
    {
        [Key]
        public int id_sanpham { get; set; }
        public string? TenSP { get; set; }
        public int GiaBan { get; set; }
        public string? DienThoai { get; set; }
    }
}
