'''
Задайте список из вещественных чисел. 
Напишите программу, которая найдёт разницу между максимальным 
и минимальным значением дробной части элементов, отличной от 0.
Пример:
[1.1, 1.2, 3.1, 5, 10.01] => 0.19
'''

from random import uniform as ur
from random import randint as r

def fill_float_list():
    new_list = []
    size = r(5,10)
    for _ in range(size):
        rounding = r(0,3)
        number = round(ur(0,10), rounding)
        if number == int(number):
            new_list.append(int(number))
        else:
            new_list.append(number)
    return new_list


def diff_bw_max_min_farct_part_in_list(sm_list):
    min = 1
    max = 0
    for i in sm_list:
        if i % 1 > max and i % 1 != 0:
            max = round(i % 1, 3)
        elif i % 1 < min and i % 1 != 0:
            min = round(i % 1, 3)
    if max == 0 or min == 1:
        return -1
    print(f"Max = {max}")
    print(f"Min = {min}")
    return max - min



float_list = fill_float_list()
print(f"Создан список на {len(float_list)} элементов: {float_list}")
diff = diff_bw_max_min_farct_part_in_list(float_list)
if diff == -1:
    print("Дробная часть встречается только 1 раз!")
else:
    print(f"Разница между макс. и мин. дробными частями элементов, равна: {round(diff,3)}")