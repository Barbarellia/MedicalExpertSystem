using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MedicalExpertSystem.AI;

namespace MedicalExpertSystem.NeuralNetwork
{
    public class Model
    {
        private readonly string _file;
        private ITransformer _model;

        public Model(string file)
        {
            _file = file;
            LoadModel();
        }

        private void LoadModel()
        {
            var ctx = new MLContext();
            if (File.Exists("model.zip"))
            {
                _model = ctx.Model.Load("model.zip", out _);
            }
            else
            {
                InitialTraining();
            }
        }
        public double InitialTraining()
        {
            var ctx = new MLContext();
            var data = ctx.Data.LoadFromTextFile<ModelInput>(path: _file, hasHeader: true, separatorChar: ',');
            return Train(data, ctx);
        }

        public double TrainingWithDatabase(List<ModelInput> listData)
        {
            var ctx = new MLContext();
            IDataView data = ctx.Data.LoadFromEnumerable<ModelInput>(listData);
            return Train(data, ctx);
        }

        private double Train(IDataView data, MLContext ctx)
        {
            var split = ctx.Data.TrainTestSplit(data, testFraction: 0.25);

            var features = split.TrainSet.Schema
                .Select(col => col.Name)
                .Where(col => col != "Label")
                .ToArray();
            var trainer = new LbfgsLogisticRegressionBinaryTrainer.Options()
            {
                MaximumNumberOfIterations = 100,
            };
            var pipeline=ctx.Transforms.Concatenate("Features", features).Append(ctx.BinaryClassification.Trainers.LbfgsLogisticRegression());

            var model = pipeline.Fit(split.TrainSet);

            var predictions = model.Transform(split.TestSet);

            var metrics = ctx.BinaryClassification.Evaluate(predictions);

            Console.WriteLine($"Accuracy - {metrics.Accuracy}");
            ctx.Model.Save(model, data.Schema, "model.zip");
            _model = model;
            return metrics.Accuracy;
        }

        public PredictionModelOutput Predict(PredictionModel input)
        {
            var ctx = new MLContext();
            var model = ctx.Model.Load("model.zip", out _);
            PredictionEngine<ModelInput, PredictionModelOutput> predictionEngine =
                ctx.Model.CreatePredictionEngine<ModelInput, PredictionModelOutput>(model);
            ModelInput data = new ModelInput()
            {
                Age = input.Age,
                Bmi = input.Bmi,
                Glucose = input.Glucose,
                Insulin = input.Insulin,
                Pregnancies = input.Pregnancies,
                BloodPressure = input.BloodPressure,
                SkinThickness = input.SkinThickness,
                DiabetesPedigreeFunction = input.DiabetesPedigreeFunction,
            };
            PredictionModelOutput prediction = predictionEngine.Predict(data);
            return prediction;
        }
    }
}
