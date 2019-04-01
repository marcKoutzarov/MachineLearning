using System.Collections.Generic;

namespace KycRiskClassification.Models
{
    public class ModelMetrics
    {
        public MultiClassClassifierMetrics MultiClassClassifier { get; set; }
        public ClusteringMetrics Clustering { get; set; }

        public class MultiClassClassifierMetrics
        {

            /// <summary>
            /// The macro-average is computed by taking the average over all the classes of the fraction
            /// of correct predictions in this class (the number of correctly predicted instances in the class,
            /// divided by the total number of instances in the class).
            /// The macro-average metric gives the same weight to each class, no matter how many instances from
            /// that class the dataset contains.
            /// </summary>
            public double AccuracyMarcro { get; set; }

            /// <summary>
            /// The micro-average is the fraction of instances predicted correctly.
            /// The micro-average metric weighs each class according to the number of instances that belong
            /// to it in the dataset.
            /// </summary>
            public double AccuracyMicro { get; set; }

            /// <summary>
            /// The log-loss metric, is computed as follows:
            /// LL = - (1/m) * sum(log(p[i]))
            /// where m is the number of instances in the test set.
            /// p[i] is the probability returned by the classifier if the instance belongs to class 1,
            /// and 1 minus the probability returned by the classifier if the instance belongs to class 0.
            /// </summary>
            public double LogLoss { get; set; }

            /// <summary>
            /// The log-loss reduction is scaled relative to a classifier that predicts the prior for every example:
            /// (LL(prior) - LL(classifier)) / LL(prior)
            /// This metric can be interpreted as the advantage of the classifier over a random prediction.
            /// For example, if the RIG equals 20, it can be interpreted as "the probability of a correct prediction is
            /// 20% better than random guessing".
            /// </summary>
            public double LogLossReduction { get; set; }

            /// <summary>
            /// If TopK is positive, this is the relative number of examples where the true label is one of the top k predicted labels by the predictor.
            /// </summary>
            public double TopKAccuracy { get; set; }

            /// <summary>
            /// If positive, this is the top-K for which the TopKAccuracy is calculated.
            /// </summary>
            public int TopK { get; set; }

            public List<double> PerClassLogLoss { get; set; } = new List<double>();

        }
        public class ClusteringMetrics
        {
            /// <summary>
            /// Average Score. For the K-Means algorithm, the 'score' is the distance from the centroid to the example. 
            /// The average score is, therefore, a measure of proximity of the examples to cluster centroids. In other words, 
            /// it's the 'cluster tightness' measure. Note however, that this metric will only decrease if the number of clusters 
            /// is increased, and in the extreme case (where each distinct example is its own cluster) it will be equal to zero.
            /// </summary>
            public double AvgMinScore { get; set; }

            /// <summary>
            /// Davis Bouldin Index. How much Scatter ther is in the cluster and cluster separation
            /// </summary>
            public double Dbi { get; set; }

            /// <summary>
            /// Normalized Mutual Information NMI is a measure of the mutual dependence of the variables. 
            /// Normalized variants work on data that already has cluster labels. 
            /// Its value ranged from 0 to 1, where higher numbers are better.
            /// </summary>
            public double Nmi { get; set; }
        }
    }
}
