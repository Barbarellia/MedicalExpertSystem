using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
