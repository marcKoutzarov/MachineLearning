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






            ModelPrediction prediction; 

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_NoIdDocument");
            prediction =T.Predict (mlContext ,model , TestScenarios.Customer_NoIdDocument());
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.CustomerAllDataChecked");
            prediction = T.Predict(mlContext, model, TestScenarios.CustomerAllDataChecked());
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_NoLastNameCheck");
            prediction = T.Predict(mlContext, model, TestScenarios.Customer_NoLastNameCheck());
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_NoWatchListCheck");
            prediction = T.Predict(mlContext, model, TestScenarios.Customer_NoWatchListCheck());
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_OnlyEmailAndPhoneCheck");
            prediction = T.Predict(mlContext, model, TestScenarios.Customer_OnlyEmailAndPhoneCheck());
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_OnlyEmailCheck");
            prediction = T.Predict(mlContext, model, TestScenarios.Customer_OnlyEmailCheck());
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_Customer_SanctionListHit");
            prediction = T.Predict(mlContext, model, TestScenarios.Customer_SanctionListHit());
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_WatchListHit");
            prediction = T.Predict(mlContext, model, TestScenarios.Customer_WatchListHit());
            Console.WriteLine($"Predicted riskFactor is: {prediction.PredictedLabels}");
            Console.WriteLine("--Prediction Metrics--");
            for (int i = 0; i < prediction.Distances.Length; ++i)
            {
                var v = prediction.Distances[i];
                Console.WriteLine($"Distance {i} : {Math.Round(v, 15)}");
            }
            Console.WriteLine("");

            Console.WriteLine("Testing the trained model: TestScenarios.Customer_PepListHit");
            prediction = T.Predict(mlContext, model, TestScenarios.Customer_PepListHit());
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
