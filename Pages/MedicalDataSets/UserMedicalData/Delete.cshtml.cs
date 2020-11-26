using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicalExpertSystem.Data;
using MedicalExpertSystem.Models;

namespace MedicalExpertSystem.Pages.MedicalDataSets.UserMedicalData
{
    public class DeleteModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;

        public DeleteModel(MedicalExpertSystem.Data.MedicalContext context)
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

            MedicalData = await _context.MedicalData.FirstOrDefaultAsync(m => m.Id == id);

            if (MedicalData == null)
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

            MedicalData = await _context.MedicalData.FindAsync(id);

            if (MedicalData != null)
            {
                _context.MedicalData.Remove(MedicalData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
