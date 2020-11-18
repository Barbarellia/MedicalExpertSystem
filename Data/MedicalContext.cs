using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalExpertSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MedicalExpertSystem.Data
{
    public class MedicalContext : IdentityDbContext<AppUser,IdentityRole<int>, int>
    {
        public MedicalContext (DbContextOptions<MedicalContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<MedicalData> MedicalData { get; set; }

    }
}
