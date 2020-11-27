using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicalExpertSystem.Data;
using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalExpertSystem.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;
        private readonly UserManager<AppUser> _userManager;

        public IndexModel(MedicalExpertSystem.Data.MedicalContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Patient> Patients { get;set; }

        public async Task OnGetAsync()
        {
            Patients = await _context.Patient 
                .Include(q => q.AppUser)
                .Include(q => q.MedicalDataSet)
                .ToListAsync();

            foreach (var item in Patients)
            {
                item.AppUser.DecryptedUser = new Models.DecryptedUser(item.AppUser);
            }
        }
    }

    //public class DecryptedUser
    //{
    //    public string LastName { get; set; }
    //    public string FirstName { get; set; }

    //}
}
