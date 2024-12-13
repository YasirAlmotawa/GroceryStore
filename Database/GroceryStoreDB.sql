-- Terminate all active connections to the database
USE master;
GO
IF DB_ID('GroceryStoreDB') IS NOT NULL
BEGIN
    ALTER DATABASE GroceryStoreDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE GroceryStoreDB;
END;
GO

-- Make a database
CREATE DATABASE GroceryStoreDB;
GO

USE GroceryStoreDB;
GO

-- Categories Table
CREATE TABLE Categories (
    CategoryID INT IDENTITY PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE
);

-- Users Table
CREATE TABLE Users (
    UserID INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Address NVARCHAR(255),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR(15),
    Password NVARCHAR(255) NOT NULL
    CreditcardNumber INT,
    CreditcardExpDate NVARCHAR(50),
    cvv INT,
    ShippingLocation NVARCHAR(255)
);

-- Sale Table
CREATE TABLE Sale (
	SaleID INT IDENTITY PRIMARY KEY,
	DiscountAmount DECIMAL(5, 2) NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
    IsPercentage BIT NOT NULL,
);

-- Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10, 2) NOT NULL,
    Images NVARCHAR(MAX),
    Manufacturer NVARCHAR(100),
    Dimensions NVARCHAR(50),
    Weight DECIMAL(10, 2),
    Rating DECIMAL(3, 2) CHECK (Rating BETWEEN 0 AND 5),
    SKU NVARCHAR(50) UNIQUE NOT NULL,
    CategoryID INT,
    Stock INT NOT NULL CHECK (Stock >= 0),
    SaleID INT NULL, -- Foreign key to Sale
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    FOREIGN KEY (SaleID) REFERENCES Sale(SaleID)
);

-- Checkout Cart Table
CREATE TABLE CheckoutCart (
    CartID INT IDENTITY PRIMARY KEY,
    UserID INT NOT NULL REFERENCES Users(UserID) ON DELETE CASCADE,
    ProductID INT NOT NULL REFERENCES Products(ProductID) ON DELETE CASCADE,
    Quantity INT NOT NULL CHECK (Quantity >= 0),
);

-- Show All Tables 
-- UNCOMMENT IF NEEDED 
-- select * from Users;
-- select * from Products;
-- select * from Discounts;
-- select * from CheckoutCart;
-- select * from Categories;
