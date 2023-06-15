'''Реализуйте алгоритм перемешивания списка. 
НЕ ИСПОЛЬЗОВАТЬ ВСТРОЕННЫЕ БИБЛИОТЕКИ SHUFFLE, максимум использование библиотеки Random для и получения случайного int
'''
from random import randint as RI


def FillRandomListInt(size):
    my_list = []
    for i in range(size):
        my_list.append(RI(-100,100))

    return my_list


def ListItemShuffle(sm_list):
    for i in range(len(sm_list)-1):
        pos = RI(0,len(sm_list)-1)
        temp = sm_list[pos]
        sm_list[pos] = sm_list[i]
        sm_list[i] = temp

    return sm_list




size = RI(5,20)
my_list = FillRandomListInt(size)
print(f"Рандомно созданнй список: {my_list}")
print(f"Перемешанный список: {ListItemShuffle(my_list)}")