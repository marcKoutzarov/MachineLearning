using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace KycRiskClassification.Models
{ 
   public class ModelPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;

        [ColumnName("Score")]
        public float[] Distances;
    }
}
