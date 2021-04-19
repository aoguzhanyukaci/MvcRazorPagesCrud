using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcRazorUrunler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRazorUrunler.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UrunlerDbContext _db;

        public IndexModel(UrunlerDbContext db)
        {
            _db = db;
        }

        public IList<Urun> Urun { get; set; }
        public async Task OnGetAsync()
        {
            Urun = await _db.Urunler.ToListAsync();
        }

    }
}