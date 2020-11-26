using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalExpertSystem.Data;
using MedicalExpertSystem.Models;

namespace MedicalExpertSystem.Pages.MedicalDataSets.UserMedicalData
{
    public class EditModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;

        public EditModel(MedicalExpertSystem.Data.MedicalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicalData MedicalData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalData = await _context.MedicalData
                .Include(x => x.Patient)
                .ThenInclude(x => x.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (MedicalData == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MedicalData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalDataExists(MedicalData.Id))
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

        private bool MedicalDataExists(int id)
        {
            return _context.MedicalData.Any(e => e.Id == id);
        }
    }
}
