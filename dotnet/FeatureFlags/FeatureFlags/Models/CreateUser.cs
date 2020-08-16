using FeatureFlags.Models.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlags.Models
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContexts _context;

        public CreateModel(DatabaseContexts context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FeatureFlagUser FeatureFlagUser { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FeatureFlagUsers.Add(FeatureFlagUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
