USE master;
GO

/*GO
//ALTER DATABASE Students SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
//GO
//DROP DATABASE Students;
//GO*/
CREATE DATABASE DentalClinicManagement;
GO

USE Dental_Clinic_Management;
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

CREATE  TABLE [dbo].[Diagnosis](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[Treatment](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
)

INSERT INTO Diagnosis (Name)
SELECT DISTINCT DiagnosisName FROM Diagnosis_Treatment
WHERE DiagnosisName NOT IN (SELECT Name FROM Diagnosis)
GO

INSERT INTO Treatment (Name)
SELECT DISTINCT TreatmentName FROM Diagnosis_Treatment
WHERE TreatmentName NOT IN (SELECT Name FROM Treatment)
GO


CREATE TABLE [dbo].[ClinicalInfor](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Patient_ID INT FOREIGN KEY REFERENCES [dbo].[PatientInformation],
	Diagnosis_ID INT FOREIGN KEY REFERENCES [dbo].[Diagnosis] (ID),
	Treatment_ID INT FOREIGN KEY REFERENCES [dbo].[Treatment] (ID),
	Quantity INT NOT NULL,
	TotalAmount MONEY
)

CREATE TABLE [dbo].[Diagnosis](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	PatientID INT FOREIGN KEY REFERENCES [dbo].[PatientInformation](PatientID),
	Diagnosis NVARCHAR(100),
	ExaminationTime DATETIME
)


INSERT INTO Diagnosis (PatientID, ExaminationTime, Diagnosis)
SELECT PatientID, ExaminationDate, Diagnosis FROM Clinical_Information;

SELECT f.name AS ForeignKey,
       OBJECT_NAME(f.parent_object_id) AS TableName,
       COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName,
       OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName,
       COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferenceColumnName
FROM sys.foreign_keys AS f
INNER JOIN sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id
WHERE OBJECT_NAME(f.referenced_object_id) = 'Clinical_Information';

ALTER TABLE Invoice DROP CONSTRAINT I_ClinicalInfoID
GO

DROP TABLE Clinical_Information;

-- Bắt đầu giao dịch
BEGIN TRANSACTION;

-- Sao chép dữ liệu vào bảng ClinicalInfor
INSERT INTO [dbo].[ClinicalInfor] (Patient_ID, Diagnosis_ID, Treatment_ID, Quantity, TotalAmount)
SELECT D.PatientID, D.ID, T.ID, CID.Quantity, CID.Quantity * T.UnitPrice
FROM Diagnosis D
INNER JOIN Treatment T ON D.ID = T.ID
INNER JOIN ClinicalInformationDetails CID ON D.ID = CID.ID;

-- Kết thúc giao dịch
COMMIT TRANSACTION;


CREATE TABLE [dbo].[ClinicalInformation](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Patient_ID INT FOREIGN KEY REFERENCES [dbo].[PatientInformation],
	Diagnosis_ID INT FOREIGN KEY REFERENCES [dbo].[Diagnosis] (ID),
	Treatment_ID INT FOREIGN KEY REFERENCES [dbo].[Treatment] (ID),
	Quantity INT NOT NULL,
	TotalAmount MONEY
)

INSERT INTO [dbo].[ClinicalInformation](Patient_ID, Diagnosis_ID,Treatment_ID,Quantity,TotalAmount)
SELECT Patient_ID, Diagnosis_ID,Treatment_ID,Quantity,TotalAmount FROM ClinicalInfor
GO

SELECT f.name AS ForeignKey,
       OBJECT_NAME(f.parent_object_id) AS TableName,
       COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName,
       OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName,
       COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferenceColumnName
FROM sys.foreign_keys AS f
INNER JOIN sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id
WHERE OBJECT_NAME(f.referenced_object_id) = 'ClinicalInformationDetails'
GO

ALTER TABLE InvoiceDetails DROP CONSTRAINT ID_ClinicalInfoDetailsID
GO

DROP TABLE ClinicalInformationDetails


DROP TABLE WarrantyInformation

CREATE TABLE TreatmentInvoiceDetail (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ClinicInfor_ID INT,
    Date DATETIME,
    FOREIGN KEY (ClinicInfor_ID) REFERENCES ClinicalInformation(ID)
)

DROP TABLE TreatmentInvoiceDetail

CREATE TABLE TreatmentInvoiceDetail (
    InvoiceID INT,
    ClinicInfor_ID INT,
    FOREIGN KEY (InvoiceID) REFERENCES TreatmentInvoice(ID),
    FOREIGN KEY (ClinicInfor_ID) REFERENCES ClinicalInformation(ID)
)

CREATE TABLE TreatmentInvoice (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Date DATETIME,
    TotalAmount MONEY
)