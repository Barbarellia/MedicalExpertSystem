using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

            Patient = await _context.Patient.FirstOrDefaultAsync(x=>x.Id==id);
            
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
    }
}
