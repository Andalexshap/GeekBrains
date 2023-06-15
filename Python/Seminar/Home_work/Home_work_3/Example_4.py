'''
Напишите программу, которая будет преобразовывать десятичное число в двоичное.
Пример:
45 -> 101101
3 -> 11
2 -> 10
'''

from random import uniform as ur
from random import randint as r

def convert_float_from_dec_to_bin(number):
    new_str = ''
    whole_part = int(number)
    fractional_part = number%1
    
    while whole_part > 0:
        new_str = str(whole_part % 2) + new_str
        whole_part //= 2
    else:
        new_str += ','
    count = 0
    while fractional_part*2 != 0 and count != 20:
        new_str += str(int(fractional_part*2))
        fractional_part = round((fractional_part*2) % 1, 3)
        count += 1
    else:
        return new_str


def convert_int_from_dec_to_bin(number):
    new_str = ''
    while number > 0:
        new_str = str(number % 2) + new_str
        number //= 2
    return new_str

int_number = r(0,100)
print(f"Созданное целое число равно: {int_number}")
bin_number = bin(int_number)
print(f"Встроенный перевод в двоичную систему: 10({int_number}) = 2({bin_number})")
my_int_bin_number = convert_int_from_dec_to_bin(int_number)
print(f"Самописный перевод целого числа в двоичную систему: 10({int_number}) = 2({my_int_bin_number})")
float_number = round(ur(0,100),3)
print(f"Созданное вещественное число равно: {float_number}")
my_float_bin_number = convert_float_from_dec_to_bin(float_number)
print(f"Самописный перевод вещественного числа в двоичную систему: 10({float_number}) = 2({my_float_bin_number})")