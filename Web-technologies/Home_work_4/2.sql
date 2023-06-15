
-- create
CREATE TABLE STUDENTS (
  empId INTEGER PRIMARY KEY AUTO_INCREMENT,
  name TEXT NOT NULL,
  age INTEGER NOT NULL,
  address TEXT NOT NULL
);

-- insert
INSERT INTO STUDENTS (name, age, address) VALUES ('Sam', 25, 'St.Peterburg');
INSERT INTO STUDENTS (name, age, address) VALUES ('Dave', 22, 'Stavropol');
INSERT INTO STUDENTS (name, age, address) VALUES ('Eva', 20, 'Cherkessk');
INSERT INTO STUDENTS (name, age, address) VALUES ('Vasya', 24, 'Nevinnomissk');
INSERT INTO STUDENTS (name, age, address) VALUES ('Vika', 30, 'Moskow');
INSERT INTO STUDENTS (name, age, address) VALUES ('Jon', 21, 'Rostov');
INSERT INTO STUDENTS (name, age, address) VALUES ('Ben', 17, 'Moskow');
INSERT INTO STUDENTS (name, age, address) VALUES ('Nik', 26, 'Moskow');
INSERT INTO STUDENTS (name, age, address) VALUES ('Sam', 24, 'Rostov');
INSERT INTO STUDENTS (name, age, address) VALUES ('Dave', 33, 'Moskow');

-- fetch 
SELECT name FROM STUDENTS WHERE address = 'Moskow' AND age <= 30 AND age >= 18;
