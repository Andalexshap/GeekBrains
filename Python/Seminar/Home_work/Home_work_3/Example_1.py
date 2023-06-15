'''
Задайте список из нескольких чисел. 
Напишите программу, которая найдёт сумму элементов списка, 
стоящих на позиции с нечетным индексом.
Пример:
[2, 3, 5, 9, 3] -> на нечётных позициях элементы 3 и 9, ответ: 12
'''
from random import randint as r

def fill_int_list():
    new_list = []
    size = r(5,10)
    for i in range(size):
        new_list.append(r(1,50))
    return new_list


def sum_ood_index_elements(sm_list):
    sum = 0
    for i in range(len(sm_list)):
        if i % 2 != 0:
            sum += sm_list[i]
    return sum

int_list = fill_int_list()
print(f"Созданный список: {int_list}")
sum = sum_ood_index_elements(int_list)
print(f"Сумма элементов с нечетными индексами равна: {sum}")

