using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.Models
{
    public class Patient 
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public List<MedicalData> MedicalDataSet { get; set; }
    }
}
