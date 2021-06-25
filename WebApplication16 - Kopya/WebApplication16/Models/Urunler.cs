using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication16.Models
{
    public class Urunler
    {
        public Urunler()
        {
            Mudurs = new HashSet<Mudur>();
        }
        [Key]
        public int UrunId { get; set; }
        public int? OppoId { get; set; }
        public int? AppleId { get; set; }
        public int? SamsungId { get; set; }
        public int? XiaomiId { get; set; }

        public virtual Apple Apple { get; set; }
        public virtual Oppo Oppo { get; set; }
        public virtual Samsung Samsung { get; set; }
        public virtual Xiaomi Xiaomi { get; set; }
        public virtual ICollection<Mudur> Mudurs { get; set; }
    }
}
