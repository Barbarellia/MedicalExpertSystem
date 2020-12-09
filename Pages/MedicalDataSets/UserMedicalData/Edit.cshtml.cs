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

        public async Task<IActionResult> OnGetAsync(int? idP, int? idMD)
        {
            if (idP == null || idMD==null)
            {
                return NotFound();
            }

            MedicalData = await _context.MedicalData
                .Include(x => x.Patient)
                .ThenInclude(x => x.AppUser)
                .FirstOrDefaultAsync(m => m.Id == idMD);

            MedicalData.Patient.AppUser.DecryptedUser = new DecryptedUser(MedicalData.Patient.AppUser);


            if (MedicalData == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? idP)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(MedicalData).State = EntityState.Modified;

            var dataToUpdate = await _context.MedicalData
                .Include(x=>x.Patient)
                .FirstOrDefaultAsync(x => x.Id == idP);

            if(await TryUpdateModelAsync<MedicalData>(
                dataToUpdate,
                "medicalData",
                x=>x.Age,
                x=>x.BloodPressure,
                x=>x.Bmi,
                x=>x.DiabetesPedigreeFunction,
                x=>x.Glucose,
                x=>x.Insulin,
                x=>x.Pregnancies,
                x=>x.SkinThickness,
                x=>x.Prediction,
                x=>x.Result
                ))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index", new { id = dataToUpdate.Patient.Id });
            }

            return Page();
        }
    }
}
