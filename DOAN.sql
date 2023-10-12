use master

go

use dental_clinic_management

CREATE TABLE PatientInformation (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Gender BIT NOT NULL,
    YearOfBirth DATE NOT NULL,
    PhoneNumber CHAR(10) NOT NULL,
    [Address] NVARCHAR(255) NOT NULL,
    FirstExaminationDate DATETIME DEFAULT GETDATE(),
    ReasonForExamination NVARCHAR(255) NOT NULL
);

CREATE TABLE [WarrantyInformation]
(
    WarrantyID CHAR(50) PRIMARY KEY,
    LaboName NVARCHAR(255) NULL
);


CREATE TABLE [SubClinicalInformation]
(
    PatientID INT NOT NULL REFERENCES PatientInformation(PatientID) ON DELETE CASCADE,
    BloodPressure NVARCHAR(50),
    PulseRate NVARCHAR(50),
    BloodSugarLevel NVARCHAR(50),
    BloodCoagulation bit default 0,
    CongenitalHeartDisease bit default 0,
    IntellectualDisability bit default 0,
    XRayFilm NVARCHAR(50),
    WarrantyID CHAR(50),
    Other NVARCHAR(255),
	Primary key(PatientID),
);

Create table [ClinicalInformation]
(
	ClinicalInfoID INT PRIMARY KEY,
    PatientID INT NOT NULL,
	ExaminationDate DATETIME DEFAULT GETDATE(),
	Diagnosis nvarchar(255),
    Treatment nvarchar(255),
	CONSTRAINT CI_Patient FOREIGN KEY (PATIENTID) REFERENCES PatientInformation(PatientID) ON DELETE CASCADE
)

CREATE TABLE [Diagnosis_Treatment]
(
    Diagnosis_Treatment_ID INT PRIMARY KEY,
    DiagnosisName NVARCHAR(255),
    TreatmentName NVARCHAR(255),
    Unit NVARCHAR(50),
    UnitPrice decimal(10,2),
);

Create table [ClinicalInformationDetails]
(
	ID INT PRIMARY KEY,
    ClinicalInfoID INT NOT NULL,
	Diagnosis_Treatment_ID INT NOT NULL,
	Unit NVARCHAR(50),
	Quantity int,
	UnitPrice decimal(10,2),
	TotalAmount as (Quantity * UnitPrice),
	CONSTRAINT CID_ClinicalInfoID FOREIGN KEY(CLINICALINFOID) REFERENCES ClinicalInformation(ClinicalInfoID) ON DELETE CASCADE,
	CONSTRAINT CID_Diagnosis_Treatment_ID FOREIGN KEY(Diagnosis_Treatment_ID) REFERENCES Diagnosis_Treatment(Diagnosis_Treatment_ID) ON DELETE CASCADE
)

CREATE TABLE Medicine
(
    MedicineID INT PRIMARY KEY,
    MedicineName NVARCHAR(100) NOT NULL,
    Unit NVARCHAR(50),
    UnitPrice DECIMAL(10, 2),
	Dosage nvarchar(255),
);
GO

create table Prescription
(
    PrescriptionID INT PRIMARY KEY,
	ClinicalInfoID int not null,
    TotalAmount decimal(10,2) default 0,
	CONSTRAINT P_ClinicalInfoID FOREIGN KEY(ClinicalInfoID) references ClinicalInformation(ClinicalInfoID) ON DELETE CASCADE
);

create table PrescriptionDetails(
	PrescriptionID int not null,
	MedicineID int not null,
	Unit NVARCHAR(50),
	Quantity int,
    UnitPrice DECIMAL(10, 2),
	TotalAmount as (Quantity * UnitPrice),
	PRIMARY KEY(PrescriptionID,MedicineID),
	CONSTRAINT PD_PrescriptionID FOREIGN KEY (PrescriptionID) REFERENCES Prescription(PrescriptionID) ON DELETE CASCADE,
	CONSTRAINT PD_MedicineID FOREIGN KEY (MedicineID) REFERENCES Medicine(MedicineID) ON DELETE CASCADE,
)

create table Invoice(
	InvoiceID INT PRIMARY KEY,
    ClinicalInfoID INT NOT NULL,
	[Date] datetime,
    TotalPayment DECIMAL(10, 2) default 0,
	CONSTRAINT I_ClinicalInfoID FOREIGN KEY (ClinicalInfoID) REFERENCES ClinicalInformation(ClinicalInfoID) ON DELETE CASCADE
)

create table InvoiceDetails(
	InvoiceID INT not null,
	ClinicalInfoDetailsID int not null,
	TotalAmount decimal(10,2) default 0,
	PRIMARY KEY (InvoiceID,ClinicalInfoDetailsID),
	CONSTRAINT ID_InvoiceID FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID) ON DELETE CASCADE,
	CONSTRAINT ID_ClinicalInfoDetailsID FOREIGN KEY (ClinicalInfoDetailsID) REFERENCES ClinicalInformationDetails(id),
)

CREATE TABLE DentalTools
(
    ToolID INT PRIMARY KEY,
    ToolName NVARCHAR(255) NOT NULL,
    Unit NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
);
create table DentalToolTransactions (
    TransactionID int PRIMARY KEY,
	TransactionType bit default 0,
	TransactionDate datetime,
	TotalAmount Decimal(10,2),
)
create table DentalToolTransactionsDetails (
	TransactionID int not null,
	ToolID int not null,
	Unit NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
	UnitPrice Decimal(10,2) not null,
	TotalAmount AS (Quantity * UnitPrice),
	PRIMARY KEY (TransactionID,ToolID),
	CONSTRAINT DTTD_ToolID FOREIGN KEY (ToolID) REFERENCES DentalTools(ToolID) ON DELETE CASCADE,
	CONSTRAINT DTTD_TransactionID FOREIGN KEY(TransactionID) REFERENCES DentalToolTransactions(TransactionID) ON DELETE CASCADE,
)

CREATE TABLE Account
(
    AccountID INT PRIMARY KEY,
    AccountName NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    AccountType BIT
);
