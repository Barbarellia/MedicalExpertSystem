using MedicalExpertSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.Data
{
    public class DbInitializer
    {
        public static void Initialize(MedicalContext context)
        {
            context.Database.EnsureCreated();

            if (context.AppUser.Any())
            {
                return;
            }

            var appUsers = new AppUser[]
            {
                new AppUser{LastName="Szweda",FirstName="Barbara", UserName="barbara@szweda.pl",
                        NormalizedUserName="BARBARA@SZWEDA.PL",Email="barbara@szweda.pl", NormalizedEmail="BARBARA@SZWEDA.PL",
                        PasswordHash="AQAAAAEAACcQAAAAEPbsk93uC8jC/AxyAxFdCWVgjQP/jy3f++bLeWXf0/9/1WmwwV5gZZ9arqkeiEtrIA==",
                        SecurityStamp="CTU7AXGWSVBYFHQUTHNLWGZYOLVHYLAJ",
                        PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0}
            };

            foreach (AppUser user in appUsers)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            //var medicalData = new MedicalData[]
            //{
            //    new MedicalData{}
            //};
        }
    }
}
