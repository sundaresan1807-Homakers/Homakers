-- ******** Table Creation ********
--ALTER TABLE Professionals DROP CONSTRAINT FK_Profession;
--ALTER TABLE Professionals DROP CONSTRAINT FK_District;
--Drop Table Professionals
--Drop Table Profession
--Drop Table Customers
--Drop Table BookService
--DROP TABLE Districts


--Select * from Professionals
--Select * from Profession
--Select * from Customers
--Select * from BookService
-- Profession
Create table Profession
(
	ProfessionID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID()
	, ProfessionName NVARCHAR(255) NOT NULL
	, MinPrice decimal(3) NOT NULL
	, MaxPrice decimal(3) NOT NULL
);

Create Table Districts
(
	DistrictID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID() NOT NULL
	, DistrictName nvarchar(100) NOT NULL
	, IsActive int NOT NULL
	, CreatedDateTime datetime NOT NULL
	, UpdatedDateTime datetime NULL 
);

-- Professionals
Create Table Professionals
(
	ProfessionalsID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID() NOT NULL
	, Name NVARCHAR(255) NOT NULL
	, Email NVARCHAR(70) NOT NULL
	, Username NVARCHAR(50) NOT NULL
	, Password NVARCHAR(255) NOT NULL
	, Mobile int NOT NULL
	, ProfessionID UNIQUEIDENTIFIER NOT NULL
	, DistrictID UNIQUEIDENTIFIER NOT NULL
);

ALTER TABLE Professionals ADD CONSTRAINT FK_Profession FOREIGN KEY (ProfessionID) REFERENCES Profession(ProfessionID);
ALTER TABLE Professionals ADD CONSTRAINT FK_District FOREIGN KEY (DistrictID) REFERENCES Districts(DistrictID);


-- Customers
Create Table Customers
(
	CustomerID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID() NOT NULL
	, Name NVARCHAR(255) NOT NULL
	, Email NVARCHAR(70) NOT NULL
	, Username NVARCHAR(50) NOT NULL
	, Password NVARCHAR(255) NOT NULL
	, Mobile int NOT NULL
);


CREATE TABLE BookService(
	BookServiceID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID() NOT NULL 
	, CustomerID uniqueidentifier NOT NULL
	, ProfessionID uniqueidentifier NOT NULL
	, ProfessionalsID uniqueidentifier NULL
	, BookingStatus nvarchar(20) NOT NULL
	, AcceptedDateTime datetime NULL
	, RejectedDateTime datetime NULL
	, Price decimal(3, 0) NOT NULL
	, SGST decimal(3, 0) NOT NULL
	, CGST decimal(3, 0) NOT NULL
	, TotalPrice decimal(3, 0) NOT NULL
	, CreatedDateTime datetime NOT NULL
	, UpdatedDateTime datetime NULL
);

