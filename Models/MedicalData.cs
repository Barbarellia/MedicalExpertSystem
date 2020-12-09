using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MedicalExpertSystem.AI;

namespace MedicalExpertSystem.Models
{
    public class MedicalData
    {
        public int Id { get; set; }
        public int Pregnancies { get; set; }
        public int Glucose { get; set; }
        public int BloodPressure { get; set; }
        public int SkinThickness { get; set; }
        public int Insulin { get; set; }

        [Display(Name="DPF")]
        public double DiabetesPedigreeFunction { get; set; }
        public double Bmi { get; set; }
        public int Age { get; set; }
        public bool? Prediction { get; set; }
        public bool? Result { get; set; }
        public Patient Patient { get; set; }
       
    }
}
