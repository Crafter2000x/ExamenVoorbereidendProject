DROP DATABASE ExcellentTasteDB
CREATE DATABASE ExcellentTasteDB
GO
USE ExcellentTasteDB

-- Create user account to manipulate table with
CREATE LOGIN ExcellentTasteMaster WITH PASSWORD = '1234'

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'ExcellentTasteMaster')
BEGIN
	CREATE USER [ExcellentTasteMaster] FOR LOGIN [ExcellentTasteMaster]
	EXEC sp_addrolemember N'db_owner', N'ExcellentTasteMaster'
END;



-- Create Users table
CREATE TABLE [dbo].[Users](
	[Id] INT IDENTITY (1, 1),
	[Username] VARCHAR(32),
	[Password] NVARCHAR(60),
	[Admin] BIT,
	PRIMARY KEY (Id)
);

-- Create Users table
CREATE TABLE [dbo].[Reservations](
	[ReservationId] INT IDENTITY (1, 1),
	[Lastname] VARCHAR(32),
	[Amount] INT,
	[Date] DATE,
	[Time] TIME,
	[PhoneNum] VARCHAR(15),
	[TableNum] INT,
	[Notes] VARCHAR(255),
	[Arrived] BIT,
	PRIMARY KEY (ReservationId)
);



-- Dummy data for testing
INSERT INTO [dbo].[Users] SELECT 'Admin', '1234', 1;
INSERT INTO [dbo].[Users] SELECT 'Mod', '1234', 1;
INSERT INTO [dbo].[Reservations] SELECT 'Keesom', 4,'2020-05-03','21:00:00','0617114939',7,'Nothing special',0
INSERT INTO [dbo].[Reservations] SELECT 'Pieter',4,'2020-01-29','21:45:00','06174422336',3,'Birthdays',0

-- Select all for testing
SELECT * FROM [Users];
SELECT * FROM [Reservations];