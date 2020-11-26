using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.AI
{
    public class PredictionModel
    {
        public int Age { get; set; }
        public int Pregnancies { get; set; }
        public int Glucose { get; set; }
        public int BloodPressure { get; set; }
        public int SkinThickness { get; set; }
        public int Insuline { get; set; }
        public int Bmi { get; set; }
        public double DiabetesPedigreeFunction { get; set; }
    }
}
