using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalExpertSystem.AI;
using MedicalExpertSystem.Models;

namespace MedicalExpertSystem.Utility
{
    public static class PredictData
    {
        private static AI.AI ai = new AI.AI();
        private static PredictionModel model = new PredictionModel();

        public static PredictionModelOutput SetPrediction(MedicalData medicalData)
        {
            model.Age = medicalData.Age;
            model.Bmi = (float)medicalData.Bmi;
            model.Glucose = medicalData.Glucose;
            model.Insulin = medicalData.Insulin;
            model.Pregnancies = medicalData.Pregnancies;
            model.BloodPressure = medicalData.BloodPressure;
            model.SkinThickness = medicalData.SkinThickness;
            model.DiabetesPedigreeFunction = (float)medicalData.DiabetesPedigreeFunction;
            

            PredictionModelOutput output = ai.Predict(model);
            return output;
        }
    }
}
