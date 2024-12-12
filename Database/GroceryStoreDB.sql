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
    categoryID INT IDENTITY PRIMARY KEY,
    categoryName NVARCHAR(100) NOT NULL UNIQUE
);

-- Users Table
CREATE TABLE Users (
    userID INT IDENTITY PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    firstName NVARCHAR(50) NOT NULL,
    lastName NVARCHAR(50) NOT NULL,
    address NVARCHAR(255),
    email NVARCHAR(100) NOT NULL UNIQUE,
    phoneNumber NVARCHAR(15),
    password NVARCHAR(255) NOT NULL
    creditcardNumber INT,
    creditcardExpDate NVARCHAR(50),
    cvv INT,
    shippingLocation NVARCHAR(255)
);

-- Sale Table
CREATE TABLE Sale (
	saleID INT IDENTITY PRIMARY KEY,
	discountAmount DECIMAL(5, 2) NOT NULL,
	startDate DATE NOT NULL,
	endDate DATE NOT NULL,
    isPercentage BIT NOT NULL,
);

-- Products Table
CREATE TABLE Products (
    productID INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(255),
    price DECIMAL(10, 2) NOT NULL,
    images NVARCHAR(MAX),
    manufacturer NVARCHAR(100),
    dimensions NVARCHAR(50),
    weight DECIMAL(10, 2),
    rating DECIMAL(3, 2) CHECK (rating BETWEEN 0 AND 5),
    SKU NVARCHAR(50) UNIQUE NOT NULL,
    categoryID INT,
    stock INT NOT NULL CHECK (stock >= 0),
    saleID INT NULL, -- Foreign key to Sale
    FOREIGN KEY (categoryID) REFERENCES Category(categoryID),
    FOREIGN KEY (saleID) REFERENCES Sale(saleID)
);

-- Checkout Cart Table
CREATE TABLE CheckoutCart (
    cartID INT IDENTITY PRIMARY KEY,
    userID INT NOT NULL REFERENCES Users(userID) ON DELETE CASCADE,
    productID INT NOT NULL REFERENCES Products(productID) ON DELETE CASCADE,
    quantity INT NOT NULL CHECK (quantity >= 0),
);

-- Sample Data Insertion
-- Insert Categories
INSERT INTO Categories (categoryName) VALUES
('Electronics'),
('Clothing'),
('Home Appliances');

-- Insert Users
INSERT INTO Users (username, firstName, lastName, address, email, phoneNumber, password) VALUES
('jdoe', 'John', 'Doe', '123 Elm Street', 'jdoe@example.com', '555-1234', 'password123'),
('asmith', 'Alice', 'Smith', '456 Maple Avenue', 'asmith@example.com', '555-5678', 'alicepwd'),
('bwilliams', 'Bob', 'Williams', '789 Oak Lane', 'bwilliams@example.com', '555-9012', 'bobsecure'),
('mjohnson', 'Mary', 'Johnson', '101 Pine Road', 'mjohnson@example.com', '555-3456', 'marypass'),
('tjones', 'Tom', 'Jones', '202 Cedar Drive', 'tjones@example.com', '555-7890', 'tompwd'),
('lkhan', 'Liam', 'Khan', '303 Birch Blvd', 'lkhan@example.com', '555-6789', 'liamsecure'),
('pclark', 'Patricia', 'Clark', '404 Oakwood St', 'pclark@example.com', '555-2345', 'patpass'),
('edavis', 'Evan', 'Davis', '505 Spruce Ave', 'edavis@example.com', '555-5679', 'evanpwd'),
('nlewis', 'Nora', 'Lewis', '606 Maple Lane', 'nlewis@example.com', '555-4321', 'norapass'),
('rhall', 'Ryan', 'Hall', '707 Walnut Way', 'rhall@example.com', '555-8765', 'ryansecure');

-- Insert Products
INSERT INTO Products (name, description, price, images, manufacturer, dimensions, weight, rating, SKU, categoryID, stock) VALUES
('Smartphone', 'High-end smartphone', 699.99, 'image1.jpg', 'TechCorp', '6x3x0.3 inches', 0.4, 4.5, 'SKU123', 1, 50),
('Laptop', 'Powerful gaming laptop', 1299.99, 'image2.jpg', 'GameTech', '15x10x1 inches', 5.0, 4.8, 'SKU124', 1, 20),
('T-shirt', 'Comfortable cotton t-shirt', 19.99, 'image3.jpg', 'WearWell', 'Medium', 0.2, 4.0, 'SKU125', 2, 100),
('Jeans', 'Stylish denim jeans', 49.99, 'image4.jpg', 'DenimBrand', 'Large', 1.2, 4.3, 'SKU126', 2, 80),
('Washing Machine', 'Energy-efficient washing machine', 499.99, 'image5.jpg', 'CleanTech', '30x30x40 inches', 150.0, 4.6, 'SKU127', 3, 15),
('Refrigerator', 'Large double-door fridge', 999.99, 'image6.jpg', 'ChillHome', '35x30x70 inches', 200.0, 4.7, 'SKU128', 3, 10),
('Headphones', 'Noise-cancelling headphones', 149.99, 'image7.jpg', 'SoundPro', '8x7x3 inches', 0.5, 4.4, 'SKU129', 1, 60),
('Microwave Oven', 'Compact microwave oven', 89.99, 'image8.jpg', 'HeatUp', '20x15x12 inches', 25.0, 4.2, 'SKU130', 3, 25),
('Sneakers', 'Comfortable running shoes', 59.99, 'image9.jpg', 'RunFast', 'Size 10', 2.0, 4.3, 'SKU131', 2, 70),
('Tablet', 'Lightweight and portable tablet', 299.99, 'image10.jpg', 'TabWorld', '10x7x0.5 inches', 1.0, 4.5, 'SKU132', 1, 30);

-- Insert Checkout Cart
INSERT INTO CheckoutCart (userID, productID, quantity) VALUES
(1, 1, 1),
(2, 3, 2),
(3, 5, 1),
(4, 7, 2),
(5, 9, 3);

-- Show All Tables 
-- UNCOMMENT IF NEEDED 
-- select * from Users;
-- select * from Products;
-- select * from Discounts;
-- select * from CheckoutCart;
-- select * from Categories;
