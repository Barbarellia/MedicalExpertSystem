using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalExpertSystem.AI;
using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedicalExpertSystem.Pages.Learn
{
    public class IndexModel : PageModel
    {
        private readonly Data.MedicalContext _context;

        public IndexModel(Data.MedicalContext context)
        {
            _context = context;
        }

        public IList<MedicalData> MedicalDatas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            MedicalDatas = await _context.MedicalData
                .Where(x => x.Prediction != null)
                .ToListAsync();

            AI.AI ai = new AI.AI();

            var preparedList = new List<ModelInput>();
            foreach (var medicalData in MedicalDatas)
            {
                var item = new ModelInput()
                {
                    Age = medicalData.Age,
                    Bmi = (float)medicalData.Bmi,
                    Glucose = medicalData.Glucose,
                    Insulin = medicalData.Insulin,
                    Outcome = medicalData.Prediction != null && (bool)medicalData.Prediction,
                    Pregnancies = medicalData.Pregnancies,
                    BloodPressure = medicalData.BloodPressure,
                    SkinThickness = medicalData.SkinThickness,
                    DiabetesPedigreeFunction = (float)medicalData.DiabetesPedigreeFunction,
                };
                preparedList.Add(item);
            }

            //if (preparedList.Count < 15)
            //{
            //    return NotFound();
            //}
            try
            {
                var accuracy = ai.DatabaseLearning(preparedList);
            }
            catch (Exception e)
            {
                throw e;
            }


            return Page();
        }
    }
}
