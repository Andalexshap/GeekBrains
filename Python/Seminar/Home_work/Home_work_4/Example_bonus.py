'''
НАПИСАТЬ СВОЙ РАНДОМАЙЗЕР (НЕ ИСПОЛЬЗОВАТЬ БИБЛИОТЕКУ RANDOM)
'''
from datetime import datetime as customRND
import GPUtil



def InputNumber(message):
    while True:
        try:
            number = int(input(f"{message}: "))
            break
        except ValueError:
            print("Это не число!")
    return number


def Custom_random(min_value, max_value):
    if min_value > max_value: return "Недопустимые значения!"
    if min_value == max_value: return min_value
    
    result = customRND.now().microsecond
    gpus = GPUtil.getGPUs()
    for gpu in gpus:
        gpu_temperature = gpu.temperature\
    
    result *= gpu_temperature
    
    if result < min_value:
        result *= min_value
    if result > max_value:
        while result > max_value:
            result = round(result/10)

    return result

def Fill_randomLlist(min,max,n=20):
    my_list = []
    for i  in range(n):
        my_list.append(Custom_random(min,max))
    return my_list

min = InputNumber("Введите минимальное значение")
max = InputNumber("Введите максимальное значение")
print(Fill_randomLlist(min,max))
