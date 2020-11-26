using MedicalExpertSystem.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExpertSystem.AI
{
    public class AI
    {
        private readonly Model _model;
        public AI()
        {
            _model = new Model(@"diabetes.csv");
        }

        public double InitialLearning()
        {
            return _model.InitialTraining();
        }

        public PredictionModelOutput Predict(PredictionModel input)
        {
            return _model.Predict(input);
        }

        public double DatabaseLearning(List<ModelInput> data)
        {
            return _model.TrainingWithDatabase(data);
        }
    }
}
