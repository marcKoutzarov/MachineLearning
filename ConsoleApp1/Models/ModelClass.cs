using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.ML.Data;

namespace KycRiskClassification.Models
{
   public class ModelClass
    {
        [LoadColumn(0)]
        public float FirstName;

        [LoadColumn(1)]
        public float MiddleName;

        [LoadColumn(2)]
        public float LastName;

        [LoadColumn(3)]
        public float Email ;

        [LoadColumn(4)]
        public float Mobile;

        [LoadColumn(5)]
        public float Address;

        [LoadColumn(6)]
        public float IdDocument;

        [LoadColumn(7)]
        public float SanctionList_Hit;

        [LoadColumn(8)]
        public float WatchList_Hit;

        [LoadColumn(9)]
        public float PEPList_Hit;

        [LoadColumn(10)]
        public float SanctionList_Check ;

        [LoadColumn(11)]
        public float WatchList_Check ;

        [LoadColumn(12)]
        public float PepList_Check;

        [LoadColumn(13)]
        public float BankAccount;

        [LoadColumn(14)]
        public string Label;
    }
}
