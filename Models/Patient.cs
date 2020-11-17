using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.Models
{
    public class Patient : AppUser
    {
        public List<MedicalData> MedicalDataSet { get; set; }
    }
}
