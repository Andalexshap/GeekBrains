--1.Отсортируйте данные по полю заработная плата (salary) в порядке: убывания; возрастания 

SELECT * FROM staff 
ORDER BY salary DESC;

SELECT * FROM staff 
ORDER BY salary;

--2.Выведите 5 максимальных заработных плат (saraly)

SELECT lastname, salary  
FROM staff LIMIT 5;

--3.Посчитайте суммарную зарплату (salary) по каждой специальности (роst)

SELECT specialty, SUM(salary) AS "Sum of salaries"
FROM staff
GROUP BY specialty;

--4.Найдите кол-во сотрудников с специальностью (post) 
--«Рабочий» в возрасте от 24 до 49 лет включительно.

SELECT specialty, COUNT(*)  AS "Number of employees"
FROM staff 
WHERE specialty = 'Рабочий' && age >= 24 && age <= 49
GROUP BY specialty;

--5.Найдите количество специальностей

SELECT  COUNT(distinct specialty) AS "Quantity of specialties"
FROM staff;

--6.Выведите специальности, у которых средний возраст сотрудников меньше 40 лет 

SELECT specialty, AVG(age)
FROM staff 
GROUP BY specialty
HAVING AVG(age) < 40;
