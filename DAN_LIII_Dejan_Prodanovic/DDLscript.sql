--we create database  
CREATE DATABASE MyHotelDb;
GO

use MyHotelDb;

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

 GO
CREATE VIEW vwEmployee 
AS

SELECT   dbo.tblEmployee.EmployeeID ,dbo.tblEmployee.HotelFloor,
         dbo.tblEmployee.Citizenship ,dbo.tblEmployee.Gender,
		 dbo.tblEmployee.Engagement ,dbo.tblEmployee.Salary ,        
		 dbo.tblUser.ID,dbo.tblUser.FullName,
         dbo.tblUser.Mail, dbo.tblUser.DateOfBirth,dbo.tblUser.Username
		 
FROM            dbo.tblUser INNER JOIN
            dbo.tblEmployee ON dbo.tblEmployee.UserID = dbo.tblUser.Id  
			 
           
GO

 GO
CREATE VIEW vwManager 
AS

SELECT   dbo.tblManager.ID ,dbo.tblManager.HotelFloor,
         dbo.tblManager.Experience ,dbo.tblManager.QualificationsLevel,	     
		 dbo.tblUser.ID as UserID,dbo.tblUser.FullName,
         dbo.tblUser.Mail, dbo.tblUser.DateOfBirth,dbo.tblUser.Username
		 
FROM            dbo.tblUser INNER JOIN
            dbo.tblManager ON dbo.tblManager.UserID = dbo.tblUser.Id  
			 
           
GO