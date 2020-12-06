﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.AI
{
    public class PredictionModel
    {
        public float Pregnancies { get; set; }
        public float Glucose { get; set; }
        public float BloodPressure { get; set; }
        public float SkinThickness { get; set; }
        public float Insulin { get; set; }
        public float Bmi { get; set; }
        public float DiabetesPedigreeFunction { get; set; }
        public float Age { get; set; }
    }
}
