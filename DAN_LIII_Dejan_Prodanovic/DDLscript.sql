--we create database  
CREATE DATABASE HotelDataBase;
GO

use HotelDataBase;

GO

 --we delete tables in case they exist
DROP TABLE IF EXISTS tblUser;
 DROP TABLE IF EXISTS tblEmployee;
DROP TABLE IF EXISTS tblManager;
DROP TABLE IF EXISTS tblVacationRequest;



 
 CREATE TABLE tblUser (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FullName varchar(50),
	DateOfBirth date,
	Mail varchar(50),
	Username varchar(50),
	Passwd varchar(50)
	 
);

 
 
 CREATE TABLE tblManager (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    HotelFloor varchar(50),
	Experience int,
    QualificationsLevel varchar(10),
	 UserId int FOREIGN KEY REFERENCES tblUser(ID) 

);

 
 CREATE TABLE tblEmployee (
    EmployeeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	HotelFloor varchar(50),
	Citizenship varchar(50),
	Gender varchar(50),
	Engagement varchar(50),
	Salary decimal,
	UserId int FOREIGN KEY REFERENCES tblUser(ID) 

 	 
);

 CREATE TABLE tblVacationRequest (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstDayDate date,
	LastDayDate date,
	RequestState varchar(40),
	ReasonOfRefuse varchar(200),
	ReasonOfDelete varchar(200), 
    EmployeeID int FOREIGN KEY REFERENCES tblEmployee(EmployeeID) 
	 
);

 