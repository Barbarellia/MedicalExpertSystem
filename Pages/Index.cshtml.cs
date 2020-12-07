using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MedicalExpertSystem.AI;
using Microsoft.AspNetCore.Identity;
using MedicalExpertSystem.Models;

namespace MedicalExpertSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public IndexModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var allUsers = _userManager.Users.ToList();

            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(user, "Patient");
                    //await _context.SaveChangesAsync();
                }
            }

            return Page();
        }
    }
}
