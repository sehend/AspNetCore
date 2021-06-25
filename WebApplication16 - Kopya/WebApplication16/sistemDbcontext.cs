using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication16.Models;

namespace WebApplication16
{
    public class sistemDbcontext : DbContext
    {
        public sistemDbcontext()
        {
        }

        public sistemDbcontext(DbContextOptions<sistemDbcontext> options)
            : base(options)
        {
        }


        public virtual DbSet<Apple> Apples { get; set; }
        public virtual DbSet<Mudur> Mudurs { get; set; }
        public virtual DbSet<Oppo> Oppos { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<Samsung> Samsungs { get; set; }
        public virtual DbSet<Urunler> Urunlers { get; set; }
        public virtual DbSet<Xiaomi> Xiaomis { get; set; }
    }
}
