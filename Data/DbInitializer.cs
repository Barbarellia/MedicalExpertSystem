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

            //var appUsers = new AppUser[]
            //{
            //    new AppUser{LastName="Szweda",FirstName="Barbara", UserName="adam@malysz.pl",
            //            NormalizedUserName="ADAM@MALYSZ.PL",Email="adam@malysz.pl", NormalizedEmail="ADAM@MALYSZ.PL",
            //            PasswordHash="AQAAAAEAACcQAAAAEF2+bzkrQQJxx/o91I+qPiZo+hx5kd9BbVUsvEWk3S7s6yxnrUoyGh4GjZaxUd58VQ==",
            //            SecurityStamp="FD4VTY7VO3NXLA6RDQZ7UUTMICJGQAL6",ConcurrencyStamp="f47689b9-d29c-44e4-af26-00152339e041",
            //            PhoneNumber="123456789",LockoutEnabled=true,AccessFailedCount=0}
            //};

            //var medicalData = new MedicalData[]
            //{
            //    new MedicalData{}
            //};
        }
    }
}
