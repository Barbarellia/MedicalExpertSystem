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

        public async Task<IActionResult> OnGetAsync(int? idP, int? idMD)
        {
            if (idP == null || idMD == null)
            {
                return NotFound();
            }

            MedicalData = await _context.MedicalData
                .Include(x => x.Patient)
                .ThenInclude(x => x.AppUser)
                .FirstOrDefaultAsync(m => m.Id == idMD);            

            if (MedicalData == null)
            {
                return NotFound();
            }

            MedicalData.Patient.AppUser.DecryptedUser = new DecryptedUser(MedicalData.Patient.AppUser);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? idP, int? idMD)
        {
            if (idP == null)
            {
                return NotFound();
            }

            MedicalData = await _context.MedicalData
                .Include(x => x.Patient)
                .FirstOrDefaultAsync(x=>x.Id==idMD);

            if (MedicalData != null)
            {
                _context.MedicalData.Remove(MedicalData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = idP });
        }
    }
}
