using System.ComponentModel.DataAnnotations;

namespace Baitap1.Models
{
    public class NamThang
    {
        [Key]
        public int id_namthang { get; set; }
        public DateTime NLHD { get; set; }
    }
}
