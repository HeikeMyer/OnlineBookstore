CREATE DATABASE [bookshop.com];


USE [bookshop.com];
GO


CREATE TABLE [User] (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Login varchar(100) NOT NULL,
	Password varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	PhoneNumber varchar(100),
	FirstName varchar(100),
	SecondName varchar(100)
);

CREATE TABLE Author (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Name varchar(200) 
);

CREATE TABLE Genre (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Name varchar(200)
);

CREATE TABLE LiteraryWork (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Name varchar(200),
	YearWritten integer
);

CREATE TABLE LiteraryWorkAuthor (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	LiteraryWorkFk uniqueidentifier FOREIGN KEY REFERENCES LiteraryWork(Id),
	AuthorFk uniqueidentifier FOREIGN KEY REFERENCES Author(Id)
);

CREATE TABLE LiteraryWorkGenre (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	LiteraryWorkFk uniqueidentifier FOREIGN KEY REFERENCES LiteraryWork(Id),
	GenreFk uniqueidentifier FOREIGN KEY REFERENCES Genre(Id) 
);

CREATE TABLE Country (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Abbreviation varchar(2) NOT NULL
);

CREATE TABLE City (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Name varchar(50) NOT NULL,
	CountryFk uniqueidentifier FOREIGN KEY REFERENCES Country(Id) 
);

CREATE TABLE Address (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	UserFk uniqueidentifier FOREIGN KEY REFERENCES [User](Id),
	CityFk uniqueidentifier FOREIGN KEY REFERENCES City(Id),
	PostIndex varchar(50),
	Street varchar(100),
	House varchar(10),
	Apartment varchar(10),
	IsDefult bit NOT NULL DEFAULT 0
);


INSERT INTO [User] (Id, Login, Password, Email) VALUES
	(NEWID(), 'user1', 'password1', 'smth`@gmail.com'), 
	(NEWID(), 'user2', 'password2', 'smth2@gmail.com')

INSERT INTO Country VALUES
	(NEWID(), 'Belarus', 'BY'),
	(NEWID(), 'Russian Federation', 'RU'),
	(NEWID(), 'Germany', 'DE'),
	(NEWID(), 'United Kingdom', 'UK')

DECLARE
	@byId uniqueidentifier = (SELECT Id FROM Country WHERE Abbreviation = 'BY'),
	@ruId uniqueidentifier = (SELECT Id FROM Country WHERE Abbreviation = 'RU'),
	@deId uniqueidentifier = (SELECT Id FROM Country WHERE Abbreviation = 'DE'),
	@ukId uniqueidentifier = (SELECT Id FROM Country WHERE Abbreviation = 'UK')
BEGIN
	INSERT INTO City VALUES
		(NEWID(), 'Minsk', @byId),
		(NEWID(), 'Brest', @byId),
		(NEWID(), 'Moscow', @ruId),
		(NEWID(), 'Saint Petersburg', @ruId),
		(NEWID(), 'Omsk', @ruId),
		(NEWID(), 'Berlin', @deId),
		(NEWID(), 'Hamburg', @deId),
		(NEWID(), 'Munich', @deId),
		(NEWID(), 'London', @ukId)
END

DECLARE 
	@cityId uniqueidentifier = (SELECT Id FROM City WHERE Name = 'Minsk'),
	@userId uniqueidentifier = (SELECT Id FROM [User] WHERE Login = 'user1')
BEGIN
	INSERT INTO Address (Id, UserFk, CityFk) VALUES 
		('A10C08FE-F78C-4CC4-AF19-14FA3B0EDE2C', @userId, @cityId),
		('EB1EAE34-9C5D-4410-B6DA-E42D28229A4F', @userId, @cityId)
END

INSERT INTO Author VALUES
	('32FFE549-B85D-4225-B719-D0F83C758F04', 'Agatha Christie'),
	('09CD4BD9-0A6E-4B98-A1CE-434F9CE55E57', 'Thomas Harris'),
	('2AA22DA0-EFD9-4FAB-96D4-FBB118DA2D6F', 'Stephen King'),
	('709CE101-54F7-44D8-B9F0-4409AFFC6AE5', 'Emily Bronte'),
	('47B6CD89-1502-48BA-A8A0-5D0031B0C2A7', 'Arthur Conan Doyle')

INSERT INTO Genre VALUES
	('292A0446-0465-4C00-A3C5-53D024AD339A', 'Crime'),
	('5D00E964-6242-4A41-A804-52181F995F62', 'Drama'),
	('025382C8-C23E-4F01-87AF-C47F65D42687', 'Horror'),
	('19ED8A28-3668-417C-933F-D20DF27481FE', 'Thriller')

INSERT INTO LiteraryWork (Id, Name) VALUES
	('E3DEADC0-3A1C-4E9A-B23E-27FB70972662', 'Murder on the Orient Express'),
	('B8D755FD-A89A-41E7-8BFC-DD319A2D0D1F', 'The Silence of the Lambs'),
	('0EF077DD-5F99-4438-B60B-D7DDC82774D0', 'Red Dragon'),
	('D61F2E2A-E4CC-4D9C-8D03-394C49B36A12', 'Pet Sematary')

INSERT INTO LiteraryWorkAuthor VALUES
	('20D8CD95-DC4F-4379-BC9B-6B7DF57BD498', 'E3DEADC0-3A1C-4E9A-B23E-27FB70972662', '32FFE549-B85D-4225-B719-D0F83C758F04'),
	('E3DCC946-6E5E-42BE-84A6-C0EE68EADE2D', 'B8D755FD-A89A-41E7-8BFC-DD319A2D0D1F', '09CD4BD9-0A6E-4B98-A1CE-434F9CE55E57'),
	('8F7C94CD-A285-4D1A-9574-A1CC863DE422', '0EF077DD-5F99-4438-B60B-D7DDC82774D0', '09CD4BD9-0A6E-4B98-A1CE-434F9CE55E57'),
	('9C107EFC-95AD-422C-A0F8-6CBC646156CB', 'D61F2E2A-E4CC-4D9C-8D03-394C49B36A12', '2AA22DA0-EFD9-4FAB-96D4-FBB118DA2D6F')

INSERT INTO LiteraryWorkGenre VALUES
	('A6B058D8-E8BF-468D-94BF-5A77E7092AB9', 'E3DEADC0-3A1C-4E9A-B23E-27FB70972662', '292A0446-0465-4C00-A3C5-53D024AD339A'),
	('7F9312BF-1F1B-4915-8F4D-B64CA0C176D8', 'B8D755FD-A89A-41E7-8BFC-DD319A2D0D1F', '292A0446-0465-4C00-A3C5-53D024AD339A'),
	('3F1BE8E2-6E1C-4D0D-BD83-BF4BE7BC24A4', 'B8D755FD-A89A-41E7-8BFC-DD319A2D0D1F', '19ED8A28-3668-417C-933F-D20DF27481FE'),
	('C2931FB9-1FC4-4253-B4A3-3F5FB8E23496', 'B8D755FD-A89A-41E7-8BFC-DD319A2D0D1F', '025382C8-C23E-4F01-87AF-C47F65D42687'),
	('B82FA596-470E-498D-A7FA-CF916283400F', '0EF077DD-5F99-4438-B60B-D7DDC82774D0', '19ED8A28-3668-417C-933F-D20DF27481FE'),
	('6FD051E7-9126-48E8-872C-D1C91BADB135', 'D61F2E2A-E4CC-4D9C-8D03-394C49B36A12', '025382C8-C23E-4F01-87AF-C47F65D42687')


ALTER TABLE [User] ADD CONSTRAINT AK_User_Login UNIQUE([Login]) 
ALTER TABLE [Country] ADD CONSTRAINT AK_Country_Abbreviation UNIQUE([Abbreviation])
ALTER TABLE [Country] ADD CONSTRAINT AK_Country_Name UNIQUE([Name])
ALTER TABLE [Genre] ADD CONSTRAINT AK_Genre_Name UNIQUE([Name]) 


ALTER TABLE [User] ADD Created datetime not null DEFAULT GETDATE();
ALTER TABLE [User] ADD Modified datetime not null DEFAULT GETDATE();

CREATE TABLE dbo.Role (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Name varchar(50) UNIQUE NOT NULL,
	Code varchar(50) UNIQUE NOT NULL
);

CREATE TABLE dbo.UserRole (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	UserFk uniqueidentifier FOREIGN KEY REFERENCES [User](Id) NOT NULL,
	RoleFk uniqueidentifier FOREIGN KEY REFERENCES Role(Id) NOT NULL,
	Created datetime not null DEFAULT GETDATE(),
	Modified datetime not null DEFAULT GETDATE()
);

ALTER TABLE UserRole ADD CONSTRAINT AK_UserRole_UserFk_RoleFk UNIQUE(UserFk, RoleFk) 


INSERT INTO Role VALUES
	('{61C3FF7E-C16F-4BAD-9B10-D28AEFFDF0B0}', 'Administrator', 'ADMINISTRATOR'),
	('{3230E51D-020A-4644-9152-21B82BF54219}', 'Storekeeper', 'STOREKEEPER'),
	('{DBADFFB7-6AF4-4558-AD17-D66FCB1D578D}', 'OrderMananager', 'ORDER_MANAGER')


EXEC sp_rename 'dbo.User.Password', 'PasswordHash', 'COLUMN';

ALTER TABLE [User] ADD NormalizedLogin varchar(100) DEFAULT '';
ALTER TABLE [User] ADD NormalizedEmail varchar(100) DEFAULT '';

ALTER TABLE [User] ADD CONSTRAINT AK_User_NormalizedLogin UNIQUE(NormalizedLogin)
ALTER TABLE [User] ADD CONSTRAINT AK_User_NormalizedEmail UNIQUE(NormalizedEmail)


CREATE TABLE dbo.Provider (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Name varchar(200) NOT NULL UNIQUE
);

CREATE TABLE dbo.Publisher (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Name varchar(200) NOT NULL UNIQUE
);

CREATE TABLE dbo.Book (
	Id uniqueidentifier PRIMARY KEY NOT NULL,
	LiteraryWorkFk uniqueidentifier FOREIGN KEY REFERENCES LiteraryWork(Id) NOT NULL,
	PublisherFk uniqueidentifier FOREIGN KEY REFERENCES Publisher(Id) NOT NULL,
	PageAmount integer NOT NULL,
	Size varchar(10) NOT NULL,
	Price decimal NOT NULL,
	Created datetime not null DEFAULT GETDATE(),
	Modified datetime not null DEFAULT GETDATE(),
	UpdatedBy uniqueidentifier FOREIGN KEY REFERENCES [User](Id) NOT NULL
);

CREATE TABLE dbo.Item (
	Id uniqueidentifier NOT NULL PRIMARY KEY,
	Barcode varchar(200) NOT NULL UNIQUE,
	BookFk uniqueidentifier FOREIGN KEY REFERENCES Book(Id) NOT NULL,
	ProviderFk uniqueidentifier FOREIGN KEY REFERENCES Provider(Id) NOT NULL,
	Created datetime not null DEFAULT GETDATE(),
	Modified datetime not null DEFAULT GETDATE(),
	UpdatedBy uniqueidentifier FOREIGN KEY REFERENCES [User](Id) NOT NULL
);

CREATE TABLE dbo.OperationType (
	Id uniqueidentifier PRIMARY KEY NOT NULL,
	Name varchar(50) NOT NULL,
	Code varchar(20) UNIQUE NOT NULL
);

CREATE TABLE dbo.Notification (
	Id uniqueidentifier PRIMARY KEY NOT NULL,
	UserFk uniqueidentifier FOREIGN KEY REFERENCES [User](Id) NOT NULL,
	OperationTypeFk uniqueidentifier FOREIGN KEY REFERENCES OperationType(Id) NOT NULL,
	Message nvarchar(max) NOT NULL,
	Created datetime NOT NULL DEFAULT GETDATE(),
	Modified datetime NOT NULL DEFAULT GETDATE()
);



CREATE TABLE dbo.PaymentMethod (
	Id uniqueidentifier PRIMARY KEY NOT NULL,
	Name varchar(50) NOT NULL,
	Code varchar(50) UNIQUE NOT NULL
);

CREATE TABLE dbo.PaymentStatus (
	Id uniqueidentifier PRIMARY KEY NOT NULL,
	Name varchar(20) NOT NULL,
	Code varchar(20) UNIQUE NOT NULL
);

CREATE TABLE dbo.Payment (
	Id uniqueidentifier PRIMARY KEY NOT NULL,
	UserFk uniqueidentifier FOREIGN KEY REFERENCES [User](Id) NOT NULL,
	PaymentMethodFk uniqueidentifier FOREIGN KEY REFERENCES PaymentMethod(Id) NOT NULL,
	PaymentStatusFk uniqueidentifier FOREIGN KEY REFERENCES PaymentStatus(Id) NOT NULL,
	Amount decimal NOT NULL DEFAULT 0,
	Created datetime NOT NULL DEFAULT GETDATE(),
	Modified datetime NOT NULL DEFAULT GETDATE()
);

CREATE TABLE dbo.Basket (
	Id uniqueidentifier PRIMARY KEY NOT NULL,
	UserFk uniqueidentifier FOREIGN KEY REFERENCES [User](Id) NOT NULL,
	PaymentFk uniqueidentifier FOREIGN KEY REFERENCES Payment(Id),
	Price decimal NOT NULL DEFAULT 0,
	IsPaid bit NOT NULL DEFAULT 0,
	Created datetime NOT NULL DEFAULT GETDATE(),
	Modified datetime NOT NULL DEFAULT GETDATE(),
	IsActive bit NOT NULL DEFAULT 1,
	IsDeleted bit NOT NULL DEFAULT 0
);

CREATE TABLE dbo.Purchase (
	Id uniqueidentifier PRIMARY KEY NOT NULL,
	UserFk uniqueidentifier FOREIGN KEY REFERENCES [User](Id) NOT NULL,
	BasketFk uniqueidentifier FOREIGN KEY REFERENCES Basket(Id) NOT NULL,
	ItemFk uniqueidentifier FOREIGN KEY REFERENCES Item(Id) NOT NULL,
	Created datetime NOT NULL DEFAULT GETDATE(),
	Modified datetime NOT NULL DEFAULT GETDATE(),
	IsActive bit NOT NULL DEFAULT 1,
	IsDeleted bit NOT NULL DEFAULT 0
);




