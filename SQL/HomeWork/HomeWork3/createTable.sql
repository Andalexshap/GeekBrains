create table staff
(
    Id INT auto_increment primary key,
    firstname varchar(15) NOT NULL,
    lastname varchar(15) NOT NULL,
    post varchar(15),
    seniority INT,
    salary INT,
    age TINYINT
);