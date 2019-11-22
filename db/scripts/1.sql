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
