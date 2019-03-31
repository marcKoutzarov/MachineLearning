
**The Problem**

-When onboarding a customer it happens in phases. Whenever a customer sends data this data has to be verified.

the following data we recieve from the customer. 

- FirstName
- MiddleName
- LastName 
- Email
- Mobile
- Address
- IdDocument
- BankAccount

The Backoffice Verifies this data following a verification process. For example the Lastname send must match the last name on the IdDocument uploaded. We will not elaborated on this process at this moment. Once we receive the data we will check the person if he appears in certain Saction Lists

- SanctionList_Check = Internation Sanctions lists like the VN and EU List
- WatchList_Check  = Local (National) Police and criminal Lists 
- PepList_Check   = Check if the Person is a Political Exposed Person

If one of the Lists returns a Hit we will mark it in the folloning Features

- SanctionList_Hit 
- WatchList_Hit 
- PEPList_Hit 

Every Feature has a possible value of 1 or 0 Meaning it has been verified or not. (for the SanctionList_Hit - WatchList_Hit - PEPList_Hit it means it appears on the list or not).Based on the results a person is classified into a KYC Risk factor.Meaning the chance het might be involved in Terrorist funding or money laudering activities.

The Classification is :
- Certain Risk
- High Risk 
- Moderate Risk 
- or Low Risk


**What do we predict?**

Based on the Data send this programm Classifies the Client into a Risk Category

**Training model?**

the trainingsmodel has the following features:
1= is verified , 0= not verified


- FirstName = value 0 or 1
- MiddleName  = value 0 or 1
- LastName = value 0 or 1
- Email = value 0 or 1
- Mobile = value 0 or 1
- Address  = value 0 or 1
- IdDocument = value 0 or 1
- SanctionList_Hit = value 0 or 1
- WatchList_Hit = value 0 or 1
- PEPList_Hit = value 0 or 1
- SanctionList_Check = value 0 or 1
- WatchList_Check = value 0 or 1
- PepList_Check = value 0 or 1
- BankAccount = value 0 or 1
- RiskClass= as Label Certain High Moderate or low


**Sample data**


- 0,0,0,0,0,0,0,0,0,0,0,0,0,0,certain
- 0,0,0,1,0,0,0,0,0,0,0,0,0,0,high
- 0,0,0,1,1,0,0,0,0,0,0,0,0,0,high
- 1,1,1,1,1,0,1,0,0,0,0,0,0,0,moderate
- 1,1,1,1,1,1,1,0,0,0,0,0,0,0,moderate
- 1,1,1,1,1,1,1,0,0,0,1,1,1,1,low
- 1,1,1,0,1,1,1,0,0,0,1,1,1,1,moderate
- 1,1,1,1,0,1,1,0,0,0,1,1,1,1,moderate
- 1,1,1,0,0,1,1,0,0,0,1,1,1,1,moderate
- 1,1,1,1,1,1,1,1,0,0,1,1,1,1,high
- 1,1,1,1,1,1,1,0,1,0,1,1,1,1,high
- 1,1,1,1,1,1,1,0,0,1,1,1,1,1,high
- 1,1,1,1,1,1,1,1,1,0,1,1,1,1,certain
- 1,1,1,1,1,1,1,1,1,1,1,1,1,1,certain
- 1,1,1,1,1,1,1,1,0,1,1,1,1,1,certain
- 1,1,1,1,1,1,0,0,0,0,0,0,0,0,high
- 1,1,1,1,1,1,0,0,0,0,1,1,1,1,high
- 1,1,1,1,1,0,1,0,0,0,1,1,1,1,moderate
- 1,1,1,1,1,1,1,0,0,0,0,1,1,0,high
- 1,1,0,1,1,1,1,0,0,0,0,0,0,1,high
- 1,1,0,1,1,1,1,0,0,0,0,0,0,0,high
- 1,1,0,1,1,1,1,0,0,0,1,1,1,0,high
- 1,1,0,1,1,1,1,0,0,0,1,1,1,1,high
- 1,1,0,1,1,1,1,0,0,0,0,1,1,1,high
- 1,1,0,1,1,1,1,0,0,0,0,0,1,1,high
- 1,1,0,1,1,1,1,0,0,0,0,0,0,1,high
- 0,0,1,1,1,1,1,0,0,0,1,1,1,1,moderate
- 0,0,1,1,1,1,1,0,0,0,1,1,1,0,moderate
- 1,0,1,1,1,1,1,0,0,0,1,1,1,0,moderate
- 0,1,1,1,1,1,1,0,0,0,1,1,1,0,moderate
- 1,1,1,1,1,1,1,0,0,0,1,1,1,0,moderate
- 1,1,1,1,1,1,1,0,0,0,1,1,0,0,moderate
- 1,1,1,1,1,1,1,0,0,0,1,0,0,0,moderate
- 1,1,1,1,1,1,1,0,0,0,1,1,0,1,moderate
- 1,1,1,1,1,1,1,0,0,0,1,0,0,1,moderate


** Results **

Start Training the Model
--Model Metrics--
Clustering.AvgMinScore: 0.000374129482648307
Clustering.Dbi        : 2.92438090975868
Clustering.Nmi        : 0.472670508296455
AccuracyMarcro        : 1
AccuracyMicro         : 1
LogLoss               : 0.0138676708708346
LogLossReduction      : 98.8098997853043
TopK                  : 0
TopKAccuracy          : 0

Running Scenarios.......

Testing the trained model: TestScenarios.Customer_NoIdDocument
Predicted riskFactor is: high
--Prediction Metrics--
Distance 0 : 4.347628E-09
Distance 1 : 0.981851398944855
Distance 2 : 2.86212E-09
Distance 3 : 0.018148684874177

Testing the trained model: TestScenarios.CustomerAllDataChecked
Predicted riskFactor is: low
--Prediction Metrics--
Distance 0 : 1.53327889E-07
Distance 1 : 0.020768782123923
Distance 2 : 0.031757809221745
Distance 3 : 0.947473287582398

Testing the trained model: TestScenarios.Customer_NoLastNameCheck
Predicted riskFactor is: high
--Prediction Metrics--
Distance 0 : 3.109742E-09
Distance 1 : 0.984220445156097
Distance 2 : 1.828039E-09
Distance 3 : 0.015779674053192

Testing the trained model: TestScenarios.Customer_NoWatchListCheck
Predicted riskFactor is: moderate
--Prediction Metrics--
Distance 0 : 8.086333E-08
Distance 1 : 0.000154004432261
Distance 2 : 0.988747477531433
Distance 3 : 0.011098497547209

Testing the trained model: TestScenarios.Customer_OnlyEmailAndPhoneCheck
Predicted riskFactor is: high
--Prediction Metrics--
Distance 0 : 7.0414760557E-05
Distance 1 : 0.999929428100586
Distance 2 : 5.1699747E-08
Distance 3 : 2.2946405E-07

Testing the trained model: TestScenarios.Customer_OnlyEmailCheck
Predicted riskFactor is: high
--Prediction Metrics--
Distance 0 : 0.004369782283902
Distance 1 : 0.99555766582489
Distance 2 : 7.2227456258E-05
Distance 3 : 2.61469523E-07

Testing the trained model: TestScenarios.Customer_Customer_SanctionListHit
Predicted riskFactor is: high
--Prediction Metrics--
Distance 0 : 0.03095468506217
Distance 1 : 0.952528476715088
Distance 2 : 0.005403296556324
Distance 3 : 0.011113584972918

Testing the trained model: TestScenarios.Customer_WatchListHit
Predicted riskFactor is: high
--Prediction Metrics--
Distance 0 : 0.008958702906966
Distance 1 : 0.974636852741242
Distance 2 : 0.005333174951375
Distance 3 : 0.011071344837546

Testing the trained model: TestScenarios.Customer_PepListHit
Predicted riskFactor is: high
--Prediction Metrics--
Distance 0 : 0.008959454484284
Distance 1 : 0.97463196516037
Distance 2 : 0.005335906986147
Distance 3 : 0.01107267010957






