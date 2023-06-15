# Для решения задач используется база созданная на основе данных из файла Task.sql

# 1. Создайте представление, в которое попадет информация о пользователях (имя, фамилия, город и пол), которые не старше 20 лет.

create view view1 as
select u.lastname as `имя`, u.firstname as `фамилия`, p.hometown as `город`, p.gender as `пол`
from users u
join profiles p on u.id = p.user_id and TIMESTAMPDIFF(YEAR, p.birthday, curdate()) <= 20;

select * from view1

# 2. Найдите кол-во, отправленных сообщений каждым пользователем и выведите ранжированный список пользователей,
# указав имя и фамилию пользователя, количество отправленных сообщений и место в рейтинге (первое место у пользователя с
# максимальным количеством сообщений) . (используйте DENSE_RANK)

select u.lastname, u.firstname,
       count(m.id),
       dense_rank() over (order by count(m.id) desc)
from users u
join messages m on u.id = m.from_user_id
group by u.id;

# 3. Выберите все сообщения, отсортируйте сообщения по возрастанию даты отправления (created_at) и
# найдите разницу дат отправления между соседними сообщениями, получившегося списка. (используйте LEAD или LAG)

select
    TIMESTAMPDIFF(SECOND, created_at, LEAD(created_at) OVER (ORDER BY created_at)) AS time_diff,
    m.*
from users u
join messages m on u.id = m.from_user_id
order by m.created_at