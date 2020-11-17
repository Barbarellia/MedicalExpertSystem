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
    public class IndexModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;

        public IndexModel(MedicalExpertSystem.Data.MedicalContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patient.ToListAsync();
        }
    }
}
