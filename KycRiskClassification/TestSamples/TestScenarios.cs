using System;
using System.Collections.Generic;
using System.Text;
using KycRiskClassification.Models;

namespace KycRiskClassification.TestSamples
{
    public static class TestScenarios
    {


        public static ModelClass CustomerAllDataChecked() {
            return new ModelClass
            {
                Address = 1f,
                Email = 1f,
                Mobile = 1f,
                FirstName = 1f,
                IdDocument = 1f,
                LastName = 1f,
                MiddleName = 1f,
                BankAccount = 1f,
                PepList_Check = 1f,
                SanctionList_Check = 1f,
                WatchList_Check = 1f,
                PEPList_Hit = 0f,
                SanctionList_Hit = 0f,
                WatchList_Hit = 0f,
            };
        }

        public static ModelClass Customer_NoIdDocument()
        {
            return new ModelClass
            {
                Address = 1f,
                Email = 1f,
                Mobile = 1f,
                FirstName = 1f,
                IdDocument = 0f,
                LastName = 1f,
                MiddleName = 1f,
                BankAccount = 1f,
                PepList_Check = 1f,
                SanctionList_Check = 1f,
                WatchList_Check = 1f,
                PEPList_Hit = 0f,
                SanctionList_Hit = 0f,
                WatchList_Hit = 0f,
            };
        }

        public static ModelClass Customer_NoWatchListCheck()
        {
            return new ModelClass
            {
                Address = 1f,
                Email = 1f,
                Mobile = 1f,
                FirstName = 1f,
                IdDocument = 1f,
                LastName = 1f,
                MiddleName = 1f,
                BankAccount = 1f,
                PepList_Check = 1f,
                SanctionList_Check = 1f,
                WatchList_Check = 0f,
                PEPList_Hit = 0f,
                SanctionList_Hit = 0f,
                WatchList_Hit = 0f,
            };
        }

        public static ModelClass Customer_NoLastNameCheck()
        {
            return new ModelClass
            {
                Address = 1f,
                Email = 1f,
                Mobile = 1f,
                FirstName = 1f,
                IdDocument = 1f,
                LastName = 0f,
                MiddleName = 1f,
                BankAccount = 1f,
                PepList_Check = 1f,
                SanctionList_Check = 1f,
                WatchList_Check = 1f,
                PEPList_Hit = 0f,
                SanctionList_Hit = 0f,
                WatchList_Hit = 0f,
            };
        }

        public static ModelClass Customer_OnlyEmailCheck()
        {
            return new ModelClass
            {
                Address = 0f,
                Email = 1f,
                Mobile = 0f,
                FirstName = 0f,
                IdDocument = 0f,
                LastName = 0f,
                MiddleName = 0f,
                BankAccount = 0f,
                PepList_Check = 0f,
                SanctionList_Check = 0f,
                WatchList_Check = 0f,
                PEPList_Hit = 0f,
                SanctionList_Hit = 0f,
                WatchList_Hit = 0f,
            };
        }

        public static ModelClass Customer_OnlyEmailAndPhoneCheck()
        {
            return new ModelClass
            {
                Address = 0f,
                Email = 1f,
                Mobile = 1f,
                FirstName = 0f,
                IdDocument = 0f,
                LastName = 0f,
                MiddleName = 0f,
                BankAccount = 0f,
                PepList_Check = 0f,
                SanctionList_Check = 0f,
                WatchList_Check = 0f,
                PEPList_Hit = 0f,
                SanctionList_Hit = 0f,
                WatchList_Hit = 0f,
            };
        }

        public static ModelClass Customer_SanctionListHit()
        {
            return new ModelClass
            {
                Address = 1f,
                Email = 1f,
                Mobile = 1f,
                FirstName = 1f,
                IdDocument = 1f,
                LastName = 1f,
                MiddleName = 1f,
                BankAccount = 1f,
                PepList_Check = 1f,
                SanctionList_Check = 1f,
                WatchList_Check = 1f,
                PEPList_Hit = 0f,
                SanctionList_Hit = 1f,
                WatchList_Hit = 0f,
            };
        }

        public static ModelClass Customer_WatchListHit()
        {
            return new ModelClass
            {
                Address = 1f,
                Email = 1f,
                Mobile = 1f,
                FirstName = 1f,
                IdDocument = 1f,
                LastName = 1f,
                MiddleName = 1f,
                BankAccount = 1f,
                PepList_Check = 1f,
                SanctionList_Check = 1f,
                WatchList_Check = 1f,
                PEPList_Hit = 0f,
                SanctionList_Hit = 0f,
                WatchList_Hit = 1f,
            };
        }

        public static ModelClass Customer_PepListHit()
        {
            return new ModelClass
            {
                Address = 1f,
                Email = 1f,
                Mobile = 1f,
                FirstName = 1f,
                IdDocument = 1f,
                LastName = 1f,
                MiddleName = 1f,
                BankAccount = 1f,
                PepList_Check = 1f,
                SanctionList_Check = 1f,
                WatchList_Check = 1f,
                PEPList_Hit = 1f,
                SanctionList_Hit = 0f,
                WatchList_Hit = 0f,
            };
        }


    }
}
