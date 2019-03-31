using System;
using KycRiskClassification.Models;
using KycRiskClassification.TestSamples;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace KycRiskClassification
{
    static class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start Training the Model");
            MLContext mlContext = new MLContext();

            Trainers.KycRisksMulticlassClassification T = new Trainers.KycRisksMulticlassClassification();

            var model = T.TrainModel(mlContext);

            T.SaveModel(mlContext, model);

            Console.WriteLine("--Model Metrics--");
            Console.WriteLine($"Clustering.AvgMinScore: { T.TrainedModelMetrics.Clustering.AvgMinScore}");
            Console.WriteLine($"Clustering.Dbi        : { T.TrainedModelMetrics.Clustering.Dbi}");
            Console.WriteLine($"Clustering.Nmi        : { T.TrainedModelMetrics.Clustering.Nmi}");
            Console.WriteLine($"AccuracyMarcro        : { T.TrainedModelMetrics.MultiClassClassifier.AccuracyMarcro}");
            Console.WriteLine($"AccuracyMicro         : { T.TrainedModelMetrics.MultiClassClassifier.AccuracyMicro}");
            Console.WriteLine($"LogLoss               : { T.TrainedModelMetrics.MultiClassClassifier.LogLoss}");
            Console.WriteLine($"LogLossReduction      : { T.TrainedModelMetrics.MultiClassClassifier.LogLossReduction}");
            Console.WriteLine($"TopK                  : { T.TrainedModelMetrics.MultiClassClassifier.TopK}");
            Console.WriteLine($"TopKAccuracy          : { T.TrainedModelMetrics.MultiClassClassifier.TopKAccuracy}");
            Console.WriteLine("");

            Console.WriteLine("Running Scenarios.......");
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_NoIdDocument");
            var prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.Customer_NoIdDocument());
            var d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.CustomerAllDataChecked");
            prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.CustomerAllDataChecked());
            d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_NoLastNameCheck");
            prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.Customer_NoLastNameCheck());
            d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_NoWatchListCheck");
            prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.Customer_NoWatchListCheck());
            d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_OnlyEmailAndPhoneCheck");
            prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.Customer_OnlyEmailAndPhoneCheck());
            d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_OnlyEmailCheck");
            prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.Customer_OnlyEmailCheck());
            d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_Customer_SanctionListHit");
            prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.Customer_SanctionListHit());
            d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_WatchListHit");
            prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.Customer_WatchListHit());
            d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_PepListHit");
            prediction = model.CreatePredictionEngine<ModelClass, ModelPrediction>(mlContext).Predict(TestScenarios.Customer_PepListHit());
            d = prediction.Distances;
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");


            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }






    }
}
