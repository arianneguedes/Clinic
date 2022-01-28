
/*******************************************************************************

   Clinic Database 
   Description: it creates and populates the Clinic
   DB Server: SqlServer
   Author: Arianne Guedes, Jorge Gayer,  Robert Parker and Dario

********************************************************************************/
USE MASTER;

/*******************************************************************************
   Drop Database if it Exists
********************************************************************************/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Clinic')
BEGIN
	ALTER DATABASE [Clinic] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [Clinic] SET ONLINE;
	DROP DATABASE [Clinic];
END

GO

/*******************************************************************************
   Create Database
********************************************************************************/
CREATE DATABASE [Clinic];
GO

USE [Clinic];
GO

/*******************************************************************************
   Create Tables
********************************************************************************/

CREATE TABLE [dbo].[Patients]
(
    [PatientID] INT IDENTITY PRIMARY KEY,
    [FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Address] VARCHAR(30) NOT NULL, 
	[Number] VARCHAR(10) NOT NULL, 
	[Address2] VARCHAR(30) NULL, 
	[City] VARCHAR(30) NOT NULL, 
	[HealthCard] VARCHAR(30) NOT NULL, 
	[PostalCode] VARCHAR(30) NOT NULL, 
	[ProvinceID] SMALLINT NOT NULL ,
	[Phone] VARCHAR(30) NOT NULL, 
	[Email] VARCHAR(30) NOT NULL, 
	[DOB] DATE NOT NULL ,
);
GO

CREATE TABLE [dbo].[Doctors]
(
    [DoctorID] INT IDENTITY PRIMARY KEY,
    [FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Phone] VARCHAR(30) NOT NULL, 
	[Email] VARCHAR(30) NOT NULL, 
);
GO

CREATE TABLE [dbo].[Rooms]
(
    [RoomID] INT IDENTITY PRIMARY KEY,
    [Name] VARCHAR(30) NOT NULL UNIQUE,
);
GO

CREATE TABLE [dbo].[Appointments]
(
    [AppointmentID] INT IDENTITY PRIMARY KEY,
    [DoctorID] INT NOT NULL,
	[PatientID] INT NOT NULL,
	[RoomID] INT NOT NULL,
	[Date] DATE NOT NULL,
	[ScheduleID] TINYINT NOT NULL,
);
GO

CREATE TABLE [dbo].[Users]
(
    [UserID] INT IDENTITY PRIMARY KEY,
    [UserName] VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(30) NOT NULL,
);
GO

CREATE TABLE [dbo].[Provinces]
(
    [ProvinceID] SMALLINT IDENTITY PRIMARY KEY,
    [Name] VARCHAR(30) NOT NULL UNIQUE,
);
GO


-- Create the Foreign Key Between the Employees Table and the Provinces Table
ALTER TABLE Patients
ADD FOREIGN KEY (ProvinceID) REFERENCES Provinces(ProvinceID);

ALTER TABLE Appointments
ADD FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID);

ALTER TABLE Appointments
ADD FOREIGN KEY (PatientID) REFERENCES Patients(PatientID);

ALTER TABLE Appointments
ADD FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID);




