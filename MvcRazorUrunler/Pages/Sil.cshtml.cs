using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcRazorUrunler.Models;

namespace MvcRazorUrunler.Pages
{
    public class SilModel : PageModel
    {
        private readonly UrunlerDbContext _db;

        public SilModel(UrunlerDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Urun Urun { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Urun = await _db.Urunler.FirstOrDefaultAsync(m => m.Id == id);

            if (Urun == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Urun = await _db.Urunler.FindAsync(id);

            if (Urun != null)
            {
                _db.Urunler.Remove(Urun);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
