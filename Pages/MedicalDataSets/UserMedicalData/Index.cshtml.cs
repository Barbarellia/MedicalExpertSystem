using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicalExpertSystem.Utility;

namespace MedicalExpertSystem.Pages.MedicalDataSets.UserMedicalData
{
    public class IndexModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;

        public IndexModel(MedicalExpertSystem.Data.MedicalContext context)
        {
            _context = context;
        }

        public IList<MedicalData> MedicalDatas { get; set; }
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient
                .Include(z=>z.AppUser)
                .FirstOrDefaultAsync(x=>x.Id==id);

            Patient.AppUser.DecryptedUser = new DecryptedUser(Patient.AppUser);

            MedicalDatas = await _context.MedicalData
                //.Include(x => x.Patient)
                //.ThenInclude(x => x.AppUser)
                .Where(x => x.Patient.Id == id)
                .ToListAsync();


            Patient.MedicalDataSet = (List<MedicalData>)MedicalDatas;


            //if (MedicalDatas.Any())
            //{
            //    return Page();
            //}

            ////if we got this far, something went wrong
            return Page();
        }

        public async Task<IActionResult> OnPostCalculatePrediction(int? idMD, int? idP)
        {          
            var dataToUpdate = await _context.MedicalData.FirstOrDefaultAsync(x => x.Id == idMD);
                        
            var prediction = PredictData.SetPrediction(dataToUpdate);

            dataToUpdate.Prediction = prediction.Prediction;

            if (await TryUpdateModelAsync<MedicalData>(
                dataToUpdate,
                "medicalData",
                x => x.Prediction))
            {
                await _context.SaveChangesAsync();                
            }

            Patient = await _context.Patient
                .Include(z => z.AppUser)
                .FirstOrDefaultAsync(x => x.Id == idP);

            Patient.AppUser.DecryptedUser = new DecryptedUser(Patient.AppUser);

            MedicalDatas = await _context.MedicalData
                .Where(x => x.Patient.Id == idP)
                .ToListAsync();

            if(MedicalDatas ==null || Patient == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
