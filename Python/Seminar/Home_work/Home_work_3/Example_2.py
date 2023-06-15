'''
Напишите программу, которая найдёт произведение пар чисел списка. Парой считаем первый и последний элемент, второй и предпоследний и т.д.
Пример:
[2, 3, 4, 5, 6] => [12, 15, 16];
[2, 3, 5, 6] => [12, 15]
'''

from random import randint as r

def fill_int_list():
    new_list = []
    size = r(5,10)
    for _ in range(size):
        new_list.append(r(1,10))
    return new_list


def multiply_pair_list(sm_list):
    new_list = []
    for i in range(int((len(sm_list))/2)):
        new_list.append(sm_list[i] * sm_list[-i-1])
    else:
        if len(sm_list)%2 != 0:
            new_list.append(sm_list[i+1]*sm_list[i+1])
    return new_list


int_list = fill_int_list()
print(f"Создан список на {len(int_list)} элементов: {int_list}")
multy = multiply_pair_list(int_list)
print(f"Произведение противоположных элементов: {multy}")