using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalExpertSystem.Data;
using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalExpertSystem.Pages.Doctors
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
        public AppUser Doctor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || !_context.Users.Any(
                q => q.Email == Doctor.Email))
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return Page();
            }

            var user = _context.AppUser.FirstOrDefault(x => x.Email == Doctor.Email);
            var doctorExists = await _userManager.IsInRoleAsync(user, "Doctor");

            if (doctorExists)
            {
                ModelState.AddModelError(string.Empty, "Doctor is already added.");
                return Page();
            }

            await _userManager.AddToRoleAsync(user, "Doctor");
            await _userManager.RemoveFromRoleAsync(user, "Patient");
            var patient = _context.Patient.FirstOrDefault(x => x.AppUser == user);
            _context.Patient.Remove(patient);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
