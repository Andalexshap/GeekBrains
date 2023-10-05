-- 2.1. Вывести название и цену для всех анализов, которые продавались 5 февраля 2020 и всю следующую неделю.

# Есть таблица анализов Analysis:
# an_id — ID анализа;
# an_name — название анализа;
# an_cost — себестоимость анализа;
# an_price — розничная цена анализа;
# an_group — группа анализов.

# Есть таблица групп анализов Groups:
# gr_id — ID группы;
# gr_name — название группы;
# gr_temp — температурный режим хранения.

# Есть таблица заказов Orders:
# ord_id — ID заказа;
# ord_datetime — дата и время заказа;
# ord_an — ID анализа.

set @date = date('2020-02-05');

select a.an_id, a.an_name, a.an_price, o.ord_datetime
from analysis a
join Orders o on a.an_id = o.ord_an
where date(o.ord_datetime) between @date and adddate(@date , interval 7 day);