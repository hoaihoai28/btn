using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Baitap1.Models
{
    public class PhanQuyen
    {
        [Key]
        public int id_phanquyen { get; set; }

        [ForeignKey("GiaoVien")]
        public int id_nhanvien { get; set; }
        public NhanVien? NhanVien { get; set; }

        [ForeignKey("CuaHang")]
        public int id_cuahang { get; set; }
        public CuaHang? CuaHang { get; set; }

        [ForeignKey("SanPham")]
        public int id_sanpham { get; set; }
        public SanPham? SanPham { get; set; }

        [ForeignKey("NamThang")]
        public int id_namthang { get; set; }
        public NamThang? NamThang { get; set; }
    }
}
