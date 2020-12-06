using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicalExpertSystem.Data;
using MedicalExpertSystem.Models;

namespace MedicalExpertSystem.Pages.MedicalDataSets
{
    public class IndexModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;

        public IndexModel(MedicalExpertSystem.Data.MedicalContext context)
        {
            _context = context;
        }

        public IList<Patient> Patients { get; set; }

        public async Task OnGetAsync()
        {
            Patients = await _context.Patient
                .Include(x=>x.AppUser)
                .ToListAsync();

            foreach (var item in Patients)
            {
                item.AppUser.DecryptedUser = new DecryptedUser(item.AppUser);
            }

        }
    }
}
