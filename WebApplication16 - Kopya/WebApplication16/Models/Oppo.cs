﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication16.Models
{
    public class Oppo
    {
        public Oppo()
        {
            Urunlers = new HashSet<Urunler>();
        }
        [Key]
        public int OppoId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("image Name")]
        public string imageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile imageFile { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string OppoAciklama { get; set; }
        public decimal? Fiyat { get; set; }

        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}