﻿using MedicalExpertSystem.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [NotMapped]
        public DecryptedUser DecryptedUser { get; set; }
    }

    public class DecryptedUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DecryptedUser(AppUser appUser)
        {
            this.LastName = RSACipher.Decrypt(appUser.LastName);
            this.FirstName = RSACipher.Decrypt(appUser.FirstName);
        }
    }
}
