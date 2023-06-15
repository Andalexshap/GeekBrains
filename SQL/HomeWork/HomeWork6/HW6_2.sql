drop function if EXISTS hello;
create function hello()
RETURNS varchar(20)
    NO SQL
begin
    declare greeting VARCHAR(20);
    set greeting =
        case
            when time(now()) between '06:00:00' and '11:59:59' then 'Доброе утро'
            when time(now()) between '12:00:00' and '17:59:59' then 'Добрый день'
            when time(now()) between '18:00:00' and '23:59:59' then 'Добрый вечер'
            when time(now()) between '00:00:00' and '05:59:59' then 'Доброй ночи'
        end;
    return greeting;
end;

select hello();