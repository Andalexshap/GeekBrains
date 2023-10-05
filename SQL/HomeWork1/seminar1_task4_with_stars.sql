SELECT *
FROM phone
WHERE model LIKE '%IPhone%';

SELECT *
FROM phone
WHERE model LIKE '%Galaxy%';

SELECT *
FROM phone
WHERE REGEXP_LIKE(model, '[0-9]+$');

SELECT *
FROM phone
WHERE model LIKE '%8%';