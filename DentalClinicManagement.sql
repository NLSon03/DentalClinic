USE master;
GO
/*USE master;
GO
ALTER DATABASE DentalClinicManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE DentalClinicManagement;
GO*/
CREATE DATABASE DentalClinicManagement;
GO

USE DentalClinicManagement;
GO

CREATE TABLE [dbo].[PatientInformation]
(
    PatientID INT NOT NULL PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Gender BIT NOT NULL,
    YearOfBirth DATE NOT NULL,
    PhoneNumber CHAR(10) NOT NULL,
    [Address] NVARCHAR(255) NOT NULL,
    FirstExaminationDate DATE NOT NULL,
    ReasonForExamination NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE [dbo].[WarrantyInformation]
(
    WarrantyID CHAR(50) PRIMARY KEY,
    LaboName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE [dbo].[SubclinicalInformation]
(
    PatientID INT NOT NULL REFERENCES [dbo].PatientInformation(PatientID),
    BloodPressure NVARCHAR(50) NOT NULL,
    PulseRate NVARCHAR(50) NOT NULL,
    BloodSugarLevel NVARCHAR(50) NOT NULL,
    BloodCoagulation NVARCHAR(50) NOT NULL,
    CongenitalHeartDisease NVARCHAR(50) NOT NULL,
    IntellectualDisability NVARCHAR(50) NOT NULL,
    XRayFilm NVARCHAR(50) NOT NULL,
    WarrantyID CHAR(50) NOT NULL REFERENCES [dbo].WarrantyInformation(WarrantyID),
    Other NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE [dbo].[Diagnosis_Treatment]
(
    ID INT PRIMARY KEY,
    DiagnosisName NVARCHAR(100) NOT NULL,
    TreatmentName NVARCHAR(100) NOT NULL,
    Unit NVARCHAR(50) NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE [dbo].[ClinicalInformation]
(
	ClinicalInformationId INT PRIMARY KEY,
    PatientID INT NOT NULL REFERENCES [dbo].PatientInformation(PatientID),
    DiagnosisTreatmentID INT NOT NULL REFERENCES [dbo].Diagnosis_Treatment(ID),
    Quantity INT,
    TotalAmount DECIMAL(10, 2)
);
GO

CREATE TABLE [dbo].[Invoice]
(
    InvoiceID INT PRIMARY KEY,
    PatientID INT NOT NULL REFERENCES PatientInformation(PatientID),
    ClinicalInfoID INT NOT NULL REFERENCES ClinicalInformation(ClinicalInformationID),
	[Date] DATE NOT NULL,
    TotalPayment DECIMAL(10, 2)
);
GO

CREATE TABLE DentalMaterials
(
    ID INT PRIMARY KEY,
    [Content] NVARCHAR(255) NOT NULL,
    Unit NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
	[Date] DATE NOT NULL,
    TotalAmount AS (Quantity * UnitPrice)
);
GO

CREATE TABLE Medicine
(
    MedicineID INT PRIMARY KEY,
    MedicineName NVARCHAR(100) NOT NULL,
    Unit NVARCHAR(50) NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE Prescription
(
    PrescriptionID INT PRIMARY KEY,
    PatientID INT NOT NULL REFERENCES PatientInformation(PatientID),
    MedicineID INT NOT NULL REFERENCES Medicine(MedicineID),
    Quantity INT NOT NULL ,
    TotalAmount DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE MedicineInvoice
(
    InvoiceID INT PRIMARY KEY,
    PrescriptionID INT NOT NULL REFERENCES Prescription(PrescriptionID),
    TotalAmount DECIMAL(10, 2),
    InvoiceDate DATE
);
GO

CREATE TABLE Account
(
    AccountID INT PRIMARY KEY,
    AccountName NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    AccountType BIT
);
GO