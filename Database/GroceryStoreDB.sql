-- Terminate all active connections to the database
USE master;
GO
IF DB_ID('QuikShopDB') IS NOT NULL
BEGIN
    ALTER DATABASE QuikShopDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuikShopDB;
END;
GO

-- Make a database
CREATE DATABASE QuikShopDB;
GO

USE QuikShopDB;
GO

-- Categories Table
CREATE TABLE Categories (
    categoryID INT IDENTITY PRIMARY KEY,
    categoryName NVARCHAR(100) NOT NULL UNIQUE
);

-- Users Table
CREATE TABLE users (
    userID INT IDENTITY PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    firstName NVARCHAR(50) NOT NULL,
    lastName NVARCHAR(50) NOT NULL,
    address NVARCHAR(255),
    email NVARCHAR(100) NOT NULL UNIQUE,
    phoneNumber NVARCHAR(15),
    password NVARCHAR(255) NOT NULL,
    creditcardNumber NVARCHAR(255),
    creditcardExpDate NVARCHAR(255),
    cvv INT,
    shippingLocation NVARCHAR(255)
);

-- Sales Table
CREATE TABLE Sales (
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
    description NVARCHAR(255) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    images NVARCHAR(MAX) NOT NULL,
    manufacturer NVARCHAR(100) NOT NULL,
    dimensions NVARCHAR(50) NOT NULL,
    weight DECIMAL(10, 2) NOT NULL,
    rating DECIMAL(3, 2) CHECK (rating BETWEEN 0 AND 5) NOT NULL,
    SKU NVARCHAR(50) UNIQUE NOT NULL,
    categoryID INT NOT NULL,
    stock INT NOT NULL CHECK (stock >= 0),
    saleID INT NULL, -- Foreign key to Sale
    FOREIGN KEY (categoryID) REFERENCES Categories(categoryID),
    FOREIGN KEY (saleID) REFERENCES Sales(saleID)
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
INSERT INTO Categories (CategoryName)
VALUES ('Produce'), ('Dairy'), ('Meats');

-- Insert Users
INSERT INTO Users (username, firstName, lastName, address, email, phoneNumber, password, creditcardNumber, creditcardExpDate, cvv, shippingLocation)
VALUES
('user1', 'First1', 'Last1', '123 Address Ln Apt 1', 'user1@example.com', '555-123-001', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 1'),
('user2', 'First2', 'Last2', '123 Address Ln Apt 2', 'user2@example.com', '555-123-002', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 2'),
('user3', 'First3', 'Last3', '123 Address Ln Apt 3', 'user3@example.com', '555-123-003', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 3'),
('user4', 'First4', 'Last4', '123 Address Ln Apt 4', 'user4@example.com', '555-123-004', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 4'),
('user5', 'First5', 'Last5', '123 Address Ln Apt 5', 'user5@example.com', '555-123-005', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 5'),
('user6', 'First6', 'Last6', '123 Address Ln Apt 6', 'user6@example.com', '555-123-006', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 6'),
('user7', 'First7', 'Last7', '123 Address Ln Apt 7', 'user7@example.com', '555-123-007', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 7'),
('user8', 'First8', 'Last8', '123 Address Ln Apt 8', 'user8@example.com', '555-123-008', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 8'),
('user9', 'First9', 'Last9', '123 Address Ln Apt 9', 'user9@example.com', '555-123-009', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 9'),
('user10', 'First10', 'Last10', '123 Address Ln Apt 10', 'user10@example.com', '555-123-010', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 10'),
('user11', 'First11', 'Last11', '123 Address Ln Apt 11', 'user11@example.com', '555-123-011', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 11'),
('user12', 'First12', 'Last12', '123 Address Ln Apt 12', 'user12@example.com', '555-123-012', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 12'),
('user13', 'First13', 'Last13', '123 Address Ln Apt 13', 'user13@example.com', '555-123-013', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 13'),
('user14', 'First14', 'Last14', '123 Address Ln Apt 14', 'user14@example.com', '555-123-014', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 14'),
('user15', 'First15', 'Last15', '123 Address Ln Apt 15', 'user15@example.com', '555-123-015', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 15'),
('user16', 'First16', 'Last16', '123 Address Ln Apt 16', 'user16@example.com', '555-123-016', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 16'),
('user17', 'First17', 'Last17', '123 Address Ln Apt 17', 'user17@example.com', '555-123-017', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 17'),
('user18', 'First18', 'Last18', '123 Address Ln Apt 18', 'user18@example.com', '555-123-018', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 18'),
('user19', 'First19', 'Last19', '123 Address Ln Apt 19', 'user19@example.com', '555-123-019', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 19'),
('user20', 'First20', 'Last20', '123 Address Ln Apt 20', 'user20@example.com', '555-123-020', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 20'),
('user21', 'First21', 'Last21', '123 Address Ln Apt 21', 'user21@example.com', '555-123-021', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 21'),
('user22', 'First22', 'Last22', '123 Address Ln Apt 22', 'user22@example.com', '555-123-022', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 22'),
('user23', 'First23', 'Last23', '123 Address Ln Apt 23', 'user23@example.com', '555-123-023', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 23'),
('user24', 'First24', 'Last24', '123 Address Ln Apt 24', 'user24@example.com', '555-123-024', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 24'),
('user25', 'First25', 'Last25', '123 Address Ln Apt 25', 'user25@example.com', '555-123-025', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 25'),
('user26', 'First26', 'Last26', '123 Address Ln Apt 26', 'user26@example.com', '555-123-026', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 26'),
('user27', 'First27', 'Last27', '123 Address Ln Apt 27', 'user27@example.com', '555-123-027', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 27'),
('user28', 'First28', 'Last28', '123 Address Ln Apt 28', 'user28@example.com', '555-123-028', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 28'),
('user29', 'First29', 'Last29', '123 Address Ln Apt 29', 'user29@example.com', '555-123-029', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 29'),
('user30', 'First30', 'Last30', '123 Address Ln Apt 30', 'user30@example.com', '555-123-030', 'password', 1234567812345678, '12/25', 123, 'Shipping Address 30');

-- Insert Sales (Discounts)
INSERT INTO Sales (discountAmount, startDate, endDate, isPercentage)
VALUES 
(15.00, GETDATE(), DATEADD(DAY, 30, GETDATE()), 1), -- 15% discount for Produce
(1.50, GETDATE(), DATEADD(DAY, 30, GETDATE()), 0); -- $1.5 off for Meats

-- Insert Products for Produce
INSERT INTO Products (name, description, price, images, manufacturer, dimensions, weight, rating, SKU, categoryID, stock, saleID)
VALUES
('Tomatoes', 'Ripe roma tomatoes', 1.10, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-1', 1, 9, 1),
('Lettuce', 'Fresh green lettuce', 1.20, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-2', 1, 9, 1),
('Apples', 'Ripe red apples from the farms of Roca', 1.30, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-3', 1, 9, 1),
('Oranges', 'Imported oranges', 1.40, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-4', 1, 9, 1),
('Bananas', 'Underripe bananas imported from Honduras', 1.50, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-5', 1, 9, 1),
('Strawberries', 'Fresh local strawberries', 1.60, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-6', 1, 9, 1),
('Blackberries', 'Fresh local blackberries', 1.70, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-7', 1, 9, 1),
('Dates', 'Fresh sweet dates imported from Iraq', 1.80, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-8', 1, 9, 1),
('Celery', 'Fresh Celery', 1.90, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-9', 1, 9, 1),
('Peppers', 'Hot peppers fresh from local farms', 2.00, 'image.jpg', 'manufacturer', '1x2x2', 2.5, 4, 'P-SKU-10', 1, 9, 1);

-- Insert Products for Dairy
INSERT INTO Products (name, description, price, images, manufacturer, dimensions, weight, rating, SKU, categoryID, stock, saleID)
VALUES
('Full Fat Milk', 'Fresh full fat milk', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-1', 2, 9, 2),
('Skim Milk', 'Fresh skim milk', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-2', 2, 9, 2),
('Salted Butter', 'Fresh salted butter', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-3', 2, 9, 2),
('Unsalted Butter', 'Fresh unsalted butter', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-4', 2, 9, 2),
('Yogurt', 'Fresh yogurt from the top of a mountain in Greece', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-5', 2, 9, 2),
('Sour Cream', 'Fresh sour cream', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-6', 2, 9, 2),
('Cheddar Cheese', 'Fresh cheddar cheese', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-7', 2, 9, 2),
('Vanilla Ice Cream', 'Fresh vanilla ice cream', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-8', 2, 9, 2),
('Chocolate Ice Cream', 'Fresh chocolate ice cream', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-9', 2, 9, 2),
('Fat Free Ice Cream', 'Fresh fat free ice cream', 2.49, 'image.jpg', 'manufacturer', '1x2x5', 6.2, 4.5, 'D-SKU-10', 2, 9, 2);

-- Insert Products for Meats
INSERT INTO Products (name, description, price, images, manufacturer, dimensions, weight, rating, SKU, categoryID, stock, saleID)
VALUES
('Ground Beef', 'Fresh ground beef', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-1', 3, 9, NULL),
('Bacon', 'Fresh bacon', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-2', 3, 9, NULL),
('Ham', 'Fresh ham', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-3', 3, 9, NULL),
('Salami', 'Fresh salami', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-4', 3, 9, NULL),
('Meatballs', 'Fresh meatballs', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-5', 3, 9, NULL),
('Whole Chicken', 'Fresh whole chicken', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-6', 3, 9, NULL),
('Lamb Shank', 'Fresh lamb shank', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-7', 3, 9, NULL),
('Meat Patties', 'Fresh meat patties', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-8', 3, 9, NULL),
('Meatloaf', 'Fresh meatloaf', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-9', 3, 9, NULL),
('Steak Beef', 'Fresh steak beef', 9.99, 'image.jpg', 'manufacturer', '2x5x4', 4.5, 3.75, 'M-SKU-10', 3, 9, NULL);

-- Show All Tables 
-- UNCOMMENT IF NEEDED 
-- select * from Users;
-- select * from Products;
-- select * from Sales;
-- select * from CheckoutCart;
-- select * from Categories;
