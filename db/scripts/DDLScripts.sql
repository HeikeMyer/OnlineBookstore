CREATE DATABASE [bookshop.com];

USE [bookshop.com];
GO

CREATE TABLE [dbo].[User]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Login] varchar(100) NOT NULL,
	[NormalizedLogin] varchar(100) UNIQUE NOT NULL,	
	[Email] varchar(100) NOT NULL,
	[NormalizedEmail] varchar(100) UNIQUE NOT NULL,
	[PasswordHash] varchar(250) NOT NULL,
	[PhoneNumber] varchar(100),
	[FirstName] varchar(100),
	[SecondName] varchar(100),
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE(),
	[IsBlocked] bit NOT NULL DEFAULT 0
);

CREATE TABLE [dbo].[LoginActivity]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[UserFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[IpAddressRaw] binary(128) NOT NULL,
	[IpAddress] varchar(46) NOT NULL,
	[LoginDate] datetime NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [dbo].[Role]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Code] varchar(50) UNIQUE NOT NULL,
	[Name] varchar(50) NOT NULL
);

CREATE TABLE [dbo].[UserRole] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[UserFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[RoleFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Role]([Id]) NOT NULL,
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE(),
	[UpdatedBy] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL
);

ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT AK_UserRole_UserFk_RoleFk UNIQUE([UserFk], [RoleFk]);

CREATE TABLE [dbo].[Country] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(50) UNIQUE NOT NULL,
	[Abbreviation] varchar(2) UNIQUE NOT NULL
);

CREATE TABLE [dbo].[City]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(50) NOT NULL,
	[CountryFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Country]([Id]) NOT NULL
);

CREATE TABLE [dbo].[Address]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[UserFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[CountryFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Country]([Id]) NOT NULL,
	[CityFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[City]([Id]) NOT NULL,
	[PostIndex] varchar(50),
	[Street] varchar(100),
	[House] varchar(10),
	[Apartment] varchar(10),
	[IsDefault] bit NOT NULL DEFAULT 0,
	[IsDeleted] bit NOT NULL DEFAULT 0,
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE()	
);

CREATE TABLE [dbo].[Language]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(50) UNIQUE NOT NULL,
	[Code] varchar(2) UNIQUE NOT NULL
);

CREATE TABLE [dbo].[Author] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(200) NOT NULL, 
);

CREATE TABLE [dbo].[Genre] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(200) NOT NULL, 
);

CREATE TABLE [dbo].[DataStorage]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Data] varbinary(max) NOT NULL,
	[IsDeleted] bit NOT NULL DEFAULT 0
);

CREATE TABLE [dbo].[LiteraryWorkSummary]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[LanguageFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Language]([Id]) NOT NULL,
	[DataStorageFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[DataStorage]([Id]) NOT NULL,
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE(),
	[UpdatedBy] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[IsDeleted] bit NOT NULL DEFAULT 0
);

CREATE TABLE [dbo].[LiteraryWork] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(200) NOT NULL,
	[YearWritten] integer,
	[LiteraryWorkSummaryFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[LiteraryWorkSummary]([Id]),
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE(),
	[UpdatedBy] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[IsDeleted] bit NOT NULL DEFAULT 0
);

CREATE TABLE [dbo].[LiteraryWorkAuthor] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[LiteraryWorkFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[LiteraryWork]([Id]) NOT NULL,
	[AuthorFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Author]([Id]) NOT NULL
);

ALTER TABLE [dbo].[LiteraryWorkAuthor] ADD CONSTRAINT AK_LiteraryWorkAuthor_LiteraryWorkFk_AuthorFk UNIQUE([LiteraryWorkFk], [AuthorFk]);

CREATE TABLE [dbo].[LiteraryWorkGenre]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[LiteraryWorkFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[LiteraryWork]([Id]) NOT NULL,
	[GenreFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Genre]([Id]) NOT NULL
);

ALTER TABLE [dbo].[LiteraryWorkGenre] ADD CONSTRAINT AK_LiteraryWorkGenre_LiteraryWorkFk_GenreFk UNIQUE([LiteraryWorkFk], [GenreFk]);

CREATE TABLE [dbo].[Provider] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(200) NOT NULL UNIQUE
);

CREATE TABLE [dbo].[Publisher] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(200) NOT NULL UNIQUE
);

CREATE TABLE [dbo].[Book] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[LiteraryWorkFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[LiteraryWork]([Id]) NOT NULL,
	[PublisherFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Publisher]([Id]) NOT NULL,
	[PageAmount] integer NOT NULL,
	[Size] varchar(10) NOT NULL,
	[Price] decimal NOT NULL,
	[Created] datetime not null DEFAULT GETDATE(),
	[Updated] datetime not null DEFAULT GETDATE(),
	[UpdatedBy] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[IsSoldOut] bit NOT NULL DEFAULT 0,
	[IsDeleted] bit NOT NULL DEFAULT 0
);

CREATE TABLE [dbo].[Item] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Barcode] varchar(200) NOT NULL UNIQUE,
	[BookFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Book]([Id]) NOT NULL,
	[ProviderFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Provider]([Id]) NOT NULL,
	[Created] datetime not null DEFAULT GETDATE(),
	[Updated] datetime not null DEFAULT GETDATE(),
	[UpdatedBy] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[IsSold] bit NOT NULL DEFAULT 0,
	[IsDeleted] bit NOT NULL DEFAULT 0
);

CREATE TABLE [dbo].[OperationType] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(20) NOT NULL,
	[Code] varchar(20) UNIQUE NOT NULL
);

CREATE TABLE [dbo].[Notification] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[UserFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[OperationTypeFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[OperationType]([Id]) NOT NULL,
	[Message] nvarchar(max) NOT NULL,
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE(),
	[IsSent] bit NOT NULL DEFAULT 0,
);

CREATE TABLE [dbo].[PaymentMethod] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(50) NOT NULL,
	[Code] varchar(50) UNIQUE NOT NULL
);

CREATE TABLE [dbo].[PaymentStatus] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[Name] varchar(50) NOT NULL,
	[Code] varchar(50) UNIQUE NOT NULL
);

CREATE TABLE [dbo].[Payment] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[UserFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[PaymentMethodFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[PaymentMethod]([Id]) NOT NULL,
	[PaymentStatusFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[PaymentStatus]([Id]) NOT NULL,
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [dbo].[Basket] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[UserFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[PaymentFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Payment]([Id]),
	[Price] decimal NOT NULL DEFAULT 0,
	[IsPaid] bit NOT NULL DEFAULT 0,
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE(),
	[IsActive] bit NOT NULL DEFAULT 1,
	[IsDeleted] bit NOT NULL DEFAULT 0
);

CREATE TABLE [dbo].[Purchase] 
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL,
	[UserFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[User]([Id]) NOT NULL,
	[BasketFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Basket]([Id]),	
	[ItemFk] uniqueidentifier FOREIGN KEY REFERENCES [dbo].[Item]([Id]) NOT NULL,
	[Created] datetime NOT NULL DEFAULT GETDATE(),
	[Updated] datetime NOT NULL DEFAULT GETDATE(),
	[IsActive] bit NOT NULL DEFAULT 1,
	[IsDeleted] bit NOT NULL DEFAULT 0
);
