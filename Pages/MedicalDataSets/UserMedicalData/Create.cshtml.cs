using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MedicalExpertSystem.Pages.MedicalDataSets.UserMedicalData
{
    public class CreateModel : PageModel
    {
        private readonly MedicalExpertSystem.Data.MedicalContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(MedicalExpertSystem.Data.MedicalContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(q => q.AppUser)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            MedicalData = new MedicalData
            {
                Patient = patient
            };

            return Page();
        }

        public MedicalData MedicalData { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
