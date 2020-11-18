using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalExpertSystem.Data;
using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalExpertSystem.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly MedicalContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(MedicalContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || !_context.Users.Any(
                q=>q.Email==Patient.AppUser.Email &&
                q.FirstName==Patient.AppUser.FirstName &&
                q.LastName==Patient.AppUser.LastName))
            {
                ModelState.AddModelError(string.Empty, "Nie znaleziono użytkownika.");
                return Page();
            }

            var user = _context.AppUser.FirstOrDefault(x => x.Email == Patient.AppUser.Email);

            if (_context.Patient.Any(x => x.AppUser.Id == user.Id))
            {
                ModelState.AddModelError(string.Empty, "Pacjent jest już zarejestrowany.");
                return Page();
            }


            _context.Patient.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
