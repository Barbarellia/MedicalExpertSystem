using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalExpertSystem.Data;
using MedicalExpertSystem.Models;

namespace MedicalExpertSystem.Pages.MedicalDataSets
{
    public class CreateModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;

        public CreateModel(MedicalExpertSystem.Data.MedicalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MedicalData MedicalData { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicalData.Add(MedicalData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
