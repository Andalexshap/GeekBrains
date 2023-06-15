use lection;

-- create Table - создание таблицы

CREATE TABLE Customer
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Age INT,
    FirstName vARCHAR(20),
    LastName VARCHAR(20)
);

SELECT * FROM Customer;

-- Сложение
SELECT 3+5;

-- Вычитание
SELECT 3-5;

-- Умножение
SELECT 3*5;
