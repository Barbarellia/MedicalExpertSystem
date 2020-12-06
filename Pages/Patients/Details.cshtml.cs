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
    public class DetailsModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;

        public DetailsModel(MedicalExpertSystem.Data.MedicalContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient
                .Include(x=>x.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            Patient.AppUser.DecryptedUser = new Models.DecryptedUser(Patient.AppUser);
            
            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
