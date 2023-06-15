import mysql.connector
from prettytable import PrettyTable
from dotenv import load_dotenv
import os

def cursor_to_table(cursor):
    table = PrettyTable()
    table.field_names = list(cursor.column_names)
    for i in cursor:
        table.add_row(list(i))
    return table

def ex1(db):
    cursor = db.cursor()

    cursor.execute("USE hw2;")

    cursor.execute("""
        CREATE TABLE IF NOT EXISTS sales
        (
        	id INT PRIMARY KEY AUTO_INCREMENT,
            order_date DATE NOT NULL,
            count_product INT NOT NULL
        );
        """)

    cursor.execute("""
            INSERT INTO sales(order_date, count_product)
            VALUES
        	(DATE '2022-01-01', 156),
        	(DATE '2022-01-02', 180),
        	(DATE '2022-01-03', 21),
        	(DATE '2022-01-04', 124),
        	(DATE '2022-01-05', 341);
        """)

    cursor.execute("""
        SELECT 
        	id,
            CASE
        		WHEN count_product < 100 THEN "Маленький заказ"
                WHEN count_product BETWEEN 100 AND 300 THEN "Средний заказ"
                ELSE "Большой заказ"
            END AS "Тип заказа"
        FROM sales;
        """)

    table = cursor_to_table(cursor)
    text = "Сгруппируйте значений количества в 3 сегмента — меньше 100, 100-300 и больше 300."
    print(text, table, sep='\n')

def ex2(db):
    cursor = db.cursor()

    cursor.execute("CREATE DATABASE IF NOT EXISTS hw2;")
    cursor.execute("USE hw2;")

    cursor.execute("""
       CREATE TABLE IF NOT EXISTS orders
       (
       	id INT PRIMARY KEY AUTO_INCREMENT,
           employee_id VARCHAR(20),
           amount FLOAT DEFAULT 0.0,
       	order_status VARCHAR(20)
       );
       """)

    cursor.execute("""
       INSERT INTO orders (employee_id, amount, order_status)
       VALUES
       ('s03', 15.00, "OPEN"),
       ('e01', 25.50, "OPEN"),
       ('e05', 100.70, "CLOSED"),
       ('e02', 22.18, "OPEN"),
       ('e04', 9.50, "CANCELLED");
       """)

    cursor.execute("""
       SELECT
       	id,
           employee_id,
           amount,
           order_status,
       	CASE
       		WHEN order_status = "OPEN" THEN "Order is in open state"
               WHEN order_status = "CLOSED" THEN "Order is closed"
               WHEN order_status = "CANCELLED" THEN "Order is cancelled"
               ELSE ""
           END AS full_order_status
       FROM orders;
       """)

    table = cursor_to_table(cursor)
    text = "Создайте таблицу “orders”, заполните ее значениями. Покажите “полный” статус заказа, используя оператор CASE"
    print(text, table, sep='\n')

def main_function():

    load_dotenv()

    db = mysql.connector.connect(
        host=os.getenv('HOST'),
        user=os.getenv('USER'),
        passwd=os.getenv('PASSWORD')
    )

    cursor = db.cursor()
    cursor.execute("DROP DATABASE IF EXISTS hw2;")
    cursor.execute("CREATE DATABASE IF NOT EXISTS hw2;")

    ex1(db)
    ex2(db)

    db.close()


main_function()
