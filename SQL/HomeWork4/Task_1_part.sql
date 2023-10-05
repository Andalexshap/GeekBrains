-- Используя JOIN-ы, выполните следующие операции:

-- 1.1. Вывести всех котиков по магазинам по id (условие соединения shops.id = cats.shops_id)

select c.*
from shops s
join cats c on s.id = c.shops_id;

-- 1.2. Вывести магазин, в котором продается кот “Мурзик” (попробуйте выполнить 2 способами)

select s.shopname
from shops s
join cats c on s.id = c.shops_id
where c.name = 'Murzik';

select s.shopname
from shops s
join cats c on s.id = c.shops_id and c.name = 'Murzik'
where exists(select * from shops s1 where s1.shopname = s.shopname);

-- 1.3. Вывести магазины, в которых НЕ продаются коты “Мурзик” и “Zuza”

select s.*
from shops s
where s.id not in(
    select s1.id from shops s1
    join cats c on s1.id = c.shops_id
    where c.name in ('Murzik', 'Zuza')
);
