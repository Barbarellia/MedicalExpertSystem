using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MedicalExpertSystem.AI;

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

            PatientToUpdate = await _context.Patient
                .Include(q => q.AppUser)
                .FirstOrDefaultAsync(q => q.Id == id);

            PatientToUpdate.AppUser.DecryptedUser = new DecryptedUser(PatientToUpdate.AppUser);            

            if (PatientToUpdate == null)
            {
                return NotFound();
            }

            MedicalData = new MedicalData
            {
                Patient = PatientToUpdate
            };

            return Page();
        }

        [BindProperty]
        public MedicalData MedicalData { get; set; }
        public Patient PatientToUpdate { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emptyData = new MedicalData();
            emptyData.Patient = await _context.Patient.FirstOrDefaultAsync(q => q.Id == id);

            PredictionModel model = new PredictionModel();
                      

            if (await TryUpdateModelAsync<MedicalData>(
                emptyData,
                "medicalData",
                q=>q.Age,
                q=>q.BloodPressure, 
                q=>q.Bmi,
                q=>q.DiabetesPedigreeFunction,
                q=>q.Glucose, 
                q => q.Insuline, 
                q => q.Pregnancies, 
                q => q.SkinThickness))
            {
                _context.MedicalData.Add(emptyData);
                await _context.SaveChangesAsync();
                return RedirectToPage("MedicalDataSets/UserMedicalData/Index");
            }
            return Page();
        }
    }
}
