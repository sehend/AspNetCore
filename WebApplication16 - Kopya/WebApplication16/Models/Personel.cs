using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication16.Models
{
    public class Personel
    {
        public Personel()
        {
            Mudurs = new HashSet<Mudur>();
        }
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("image Name")]
        public string imageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile imageFile { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PersonelAd { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string PersonelEmail { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string PersonelAdres { get; set; }

        public virtual ICollection<Mudur> Mudurs { get; set; }
    }
}
