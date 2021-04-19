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
    public class DuzenleModel : PageModel
    {
        private readonly UrunlerDbContext _db;

        public DuzenleModel(UrunlerDbContext db)
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

     
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Urun).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunExists(Urun.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UrunExists(int id)
        {
            return _db.Urunler.Any(e => e.Id == id);
        }
    }
}
