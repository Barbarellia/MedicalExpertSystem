using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicalExpertSystem.Data;
using MedicalExpertSystem.Models;

namespace MedicalExpertSystem.Pages.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;

        public DeleteModel(MedicalExpertSystem.Data.MedicalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient.FirstOrDefaultAsync(m => m.Id == id);

            if (Patient == null)
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

            Patient = await _context.Patient.FindAsync(id);

            if (Patient != null)
            {
                _context.Patient.Remove(Patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
