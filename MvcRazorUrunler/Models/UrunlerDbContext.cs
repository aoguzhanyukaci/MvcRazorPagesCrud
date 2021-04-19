using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRazorUrunler.Models
{
    public class UrunlerDbContext : DbContext
    {
        public UrunlerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Urun> Urunler { get; set; }
    }
}
