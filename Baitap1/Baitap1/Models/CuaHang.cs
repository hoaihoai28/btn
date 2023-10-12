using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baitap1.Models
{
    public class CuaHang
    {
        [Key]
        public int id_cuahang { get; set; }
        public string? TenCH { get; set; }

    }
}
