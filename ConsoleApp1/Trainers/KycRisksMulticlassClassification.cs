using System.Collections.Generic;
using System.IO;
using KycRiskClassification.Models;
using Microsoft.Data.DataView;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace KycRiskClassification.Trainers
{
    /// <summary>
    /// Using the StochasticDualCoordinateAscent trainer
    /// </summary>
    public class KycRisksMulticlassClassification
    {
        //fields of the trainingdata model
        private string[] _Fields = new string[]{"FirstName", "MiddleName", "LastName", "Email", "Mobile",
                "Address", "IdDocument", "SanctionList_Hit", "WatchList_Hit", "PEPList_Hit", "SanctionList_Check",
                "WatchList_Check", "PepList_Check", "BankAccount"};

        /// <summary>
        /// Property holding the Metrics data of the model.
        /// </summary>
        public ModelMetrics TrainedModelMetrics { get; set; }

        /// <summary>
        /// Trains a new Model
        /// </summary>
        /// <param name="mlContext">The current Machine learning Context</param>
        /// <returns>A trained Model</returns>
        public ITransformer TrainModel(MLContext mlContext)
        {
            ITransformer model;
            string TrainingsModelData = "Trainers/TrainingsModel.csv";

            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<ModelClass>(path: TrainingsModelData, hasHeader: false, separatorChar: ',');

            // create a new training pipeline
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Concatenate("Features", _Fields))
                .AppendCacheCheckpoint(mlContext)
                .Append(mlContext.MulticlassClassification.Trainers.StochasticDualCoordinateAscent(labelColumnName: "Label", featureColumnName: "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            //Train the model 
             model = pipeline.Fit(trainingDataView);

            //Evaluating Model's accuracy with Test data
            var predictions = model.Transform(trainingDataView);
            var clustering = mlContext.Clustering.Evaluate(data: predictions, label: DefaultColumnNames.Label, score: DefaultColumnNames.Score, features: DefaultColumnNames.Features);
            var metrics = mlContext.MulticlassClassification.Evaluate(data: predictions, label: DefaultColumnNames.Label, score: DefaultColumnNames.Score, predictedLabel: DefaultColumnNames.PredictedLabel,topK:0);
          
            // save the metrix into the property 
            TrainedModelMetrics = LoadMetrics(clustering, metrics);

            return model;
        }

        /// <summary>
        /// Save a trained model to disk
        /// </summary>
        /// <param name="model">The trained Model to save</param>
        /// <param name="TrainedModelPath">The Path the save the model</param>
        /// <param name="mlContext">The current Machine learning Context</param>
        public void SaveModel(MLContext mlContext, ITransformer model, string TrainedModelPath = "MulticlassClassification_trainedModel.zip") {
           //Save the trained model to a .ZIP file
            using (var fs = new FileStream(TrainedModelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                mlContext.Model.Save(model, fs);
            }
        }

        /// <summary>
        /// Loads a Trained model from Disk
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="TrainedModelPath"></param>
        /// <returns></returns>
        public ITransformer LoadModel(MLContext mlContext, string TrainedModelPath = "MulticlassClassification_trainedModel.zip")
        {
            ITransformer model;
            string TrainingsModelData = "Trainers/TrainingsModel.csv";
            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<ModelClass>(path: TrainingsModelData, hasHeader: false, separatorChar: ',');


            //Save the trained model to a .ZIP file
            using (var fs = new FileStream(TrainedModelPath, FileMode.Open))
            {
                model= mlContext.Model.Load(fs);
            }

            //Evaluating Model's accuracy with Test data
            var predictions = model.Transform(trainingDataView);
            var clustering = mlContext.Clustering.Evaluate(data: predictions, label: DefaultColumnNames.Label, score: DefaultColumnNames.Score, features: DefaultColumnNames.Features);
            var metrics = mlContext.MulticlassClassification.Evaluate(data: predictions, label: DefaultColumnNames.Label, score: DefaultColumnNames.Score, predictedLabel: DefaultColumnNames.PredictedLabel);
            TrainedModelMetrics = LoadMetrics(clustering, metrics);
            return model;
        }

        private ModelMetrics LoadMetrics(ClusteringMetrics cM, MultiClassClassifierMetrics mCCM) {
            var m = new ModelMetrics();

            m.Clustering = new ModelMetrics.ClusteringMetrics();
            m.Clustering.AvgMinScore = cM.AvgMinScore;
            m.Clustering.Dbi = cM.Dbi;
            m.Clustering.Nmi = cM.Nmi;

            m.MultiClassClassifier = new ModelMetrics.MultiClassClassifierMetrics();
            m.MultiClassClassifier.AccuracyMarcro = mCCM.AccuracyMacro;
            m.MultiClassClassifier.AccuracyMicro = mCCM.AccuracyMicro;
            m.MultiClassClassifier.LogLoss = mCCM.LogLoss;
            m.MultiClassClassifier.LogLossReduction = mCCM.LogLossReduction;
            m.MultiClassClassifier.TopK =  mCCM.TopK;
            m.MultiClassClassifier.TopKAccuracy =  mCCM.TopKAccuracy;
            for (int i= 0; i<  mCCM.PerClassLogLoss.Length; i++)
            {
                m.MultiClassClassifier.PerClassLogLoss.Add(mCCM.PerClassLogLoss[i]);
            }
            return m;
        }
    }
}
