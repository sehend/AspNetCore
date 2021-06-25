
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
    public class Mudur
    {
        [Key]
        public int MudurId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("image Name")]
        public string imageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile imageFile { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string MudurAd { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string MudurSoyad { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string MudurEmail { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string MudurAdres { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public int? PersonelTc { get; set; }

        public int? UrunId { get; set; }

        public virtual Personel PersonelTcNavigation { get; set; }
        public virtual Urunler Urun { get; set; }
    }
}
