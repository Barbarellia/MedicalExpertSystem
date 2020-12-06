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
            AI.AI ai = new AI.AI();

            PredictionModel model = new PredictionModel()
            {
                Age = emptyData.Age,
                Bmi = (float)emptyData.Bmi,
                Glucose = emptyData.Glucose,
                Insulin = emptyData.Insulin,
                Pregnancies = emptyData.Pregnancies,
                BloodPressure = emptyData.BloodPressure,
                SkinThickness = emptyData.SkinThickness,
                DiabetesPedigreeFunction = (float)emptyData.DiabetesPedigreeFunction,

            };

            if (await TryUpdateModelAsync<MedicalData>(
                emptyData,
                "medicalData",
                q=>q.Age,
                q=>q.BloodPressure, 
                q=>q.Bmi,
                q=>q.DiabetesPedigreeFunction,
                q=>q.Glucose, 
                q => q.Insulin, 
                q => q.Pregnancies, 
                q => q.SkinThickness
                ))
            {
                var result = ai.Predict(model);
                emptyData.Prediction = result.Prediction;
                _context.MedicalData.Add(emptyData);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index", new { id = emptyData.Patient.Id });
            }
            return Page();
        }
    }
}
