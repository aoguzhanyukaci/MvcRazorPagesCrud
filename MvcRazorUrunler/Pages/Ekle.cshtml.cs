using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcRazorUrunler.Models;

namespace MvcRazorUrunler.Pages
{
    public class EkleModel : PageModel
    {
        private readonly ILogger<EkleModel> _logger;
        private readonly UrunlerDbContext _db;

        public EkleModel(ILogger<EkleModel> logger, UrunlerDbContext db)
        {
            _logger = logger;
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
