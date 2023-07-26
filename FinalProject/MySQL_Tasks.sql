CREATE DATABASE Друзья_человека;
USE Друзья_человека;
CREATE TABLE Animals
(
Animal_id INT AUTO_INCREMENT PRIMARY KEY,
Animal_type VARCHAR(20) NOT NULL
);

INSERT INTO Animals (Animal_type)
VALUES
('Собака'),
('Собака'),
('Собака'),
('Кот'),
('Хомяк'),
('Кошка'),
('Лошадь'),
('Конь'),
('Верблюд'),
('Осел');
SELECT * FROM Animals;

DROP TABLE IF EXISTS Animals;
CREATE TABLE Pets
(
Animal_id INT,
Pet_id INT PRIMARY KEY,
Pet_type VARCHAR(20) NOT NULL,
Pet_name VARCHAR(20) NOT NULL,
Pet_birthdate date,
FOREIGN KEY (Animal_id) REFERENCES Animals (Animal_id) 
);

CREATE TABLE Pack_animals
(
Animal_id INT,
Pack_id INT PRIMARY KEY,
Pack_type VARCHAR(20) NOT NULL,
Pack_name VARCHAR(20) NOT NULL,
Pack_birthdate date,
FOREIGN KEY (Animal_id) REFERENCES Animals (Animal_id) 
);
CREATE TABLE Comands 
(
Pet_id INT,
Pack_id INT,
Command VARCHAR(20) NOT NULL,
FOREIGN KEY (Pet_id) REFERENCES Pets (Pet_id) ON DELETE CASCADE,
FOREIGN KEY (Pack_id) REFERENCES Pack_animals (Pack_id) ON DELETE CASCADE
);

INSERT INTO Pets (Animal_id, Pet_id,Pet_type, Pet_Name, Pet_Birthdate)
VALUES
('1','1', 'Собака','Борис', '2022-03-28'),
('2','2', 'Собака','Джек', '2017-08-10'),
('3','3', 'Собака','Томас Шелби', '2010-11-17'),
('4','4', 'Кот','Санчес', '2021-03-21'),
('5','5', 'Хомяк','Диего', '2020-01-08'),
('6','6', 'Кошка','Валли', '2022-03-28');

INSERT INTO Pack_animals (Animal_id, Pack_id,Pack_type, Pack_Name, Pack_Birthdate)
VALUES
('7','1', 'Лошадь','Сандра Булок', '2019-03-14'),
('8','2', 'Конь','Ричард', '2013-07-10'),
('9','3', 'Верблюд','Чук', '2018-11-23'),
('10','4', 'Осел','Хорхе', '2018-01-21');

INSERT INTO Comands (Pet_id, Pack_id, Command)
VALUES
('1',null, 'лежать'),
('1',null, 'голос'),
('1',null, 'сидеть'),
('2',null, 'лежать'),
('2',null, 'голос'),
('3',null, 'фас'),
('4',null, 'есть'),
('5',null, 'крутить колесо'),
('6',null, 'лежать'),
(null,'1', 'голоп'),
(null,'1', 'шагом'),
(null,'2', 'голоп'),
(null,'2', 'рысью'),
(null,'2', 'шагом'),
(null,'3', 'идти'),
(null,'3', 'лечь'),
(null,'4', 'идти'),
(null,'4', 'голос');

SET SQL_SAFE_UPDATES = 0;
SELECT * FROM Young_animals;

DELETE FROM Pack_animals WHERE Pack_type = 'верблюд';

CREATE TABLE young_animals
  SELECT * FROM Pets where YEAR(CURRENT_TIMESTAMP) - YEAR(Pet_birthdate) - (RIGHT(CURRENT_TIMESTAMP, 5) < RIGHT(Pet_birthdate, 5))>1 and YEAR(CURRENT_TIMESTAMP) - YEAR(Pet_birthdate) - (RIGHT(CURRENT_TIMESTAMP, 5) < RIGHT(Pet_birthdate, 5))<3  
    UNION
  SELECT * FROM Pack_animals WHERE YEAR(CURRENT_TIMESTAMP) - YEAR(Pack_birthdate) - (RIGHT(CURRENT_TIMESTAMP, 5) < RIGHT(Pack_birthdate, 5))>1 and YEAR(CURRENT_TIMESTAMP) - YEAR(Pack_birthdate) - (RIGHT(CURRENT_TIMESTAMP, 5) < RIGHT(Pack_birthdate, 5))<3;

SELECT *, (TIMESTAMPDIFF(MONTH, Pet_birthdate, curdate())) as month_age  FROM young_animals;


#12 Задание не понял что именно требуется
SELECT * FROM Pets JOIN Pack_animals JOIN young_animals;

SELECT * FROM Pets JOIN Comands
	UNION
SELECT * FROM Pack_animals JOIN Comands;

