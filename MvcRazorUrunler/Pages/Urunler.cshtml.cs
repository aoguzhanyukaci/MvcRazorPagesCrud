using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MvcRazorUrunler.Models;

namespace MvcRazorUrunler.Pages
{
    public class UrunlerModel : PageModel
    {
        private readonly UrunlerDbContext _db;

        public UrunlerModel(UrunlerDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Urun Urun { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Urunler.Add(Urun);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
