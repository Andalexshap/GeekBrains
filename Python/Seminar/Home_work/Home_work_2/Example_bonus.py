'''
Напишите программу, которая принимает на вход число N и выдает набор произведений чисел от 1 до N.
Пример:
- пусть N = 4, тогда [ 1, 2, 6, 24 ] (1, 1*2, 1*2*3, 1*2*3*4)
'''

def InputNumbers(message):
    is_OK = False
    while not is_OK:
        try:
            number = int(input(f"{message}: "))
            is_OK = True
        except ValueError:
            print("Это не число!")
    return number


def ListMultiplyNumber(num):
    my_list = [1]
    
    if num == 1:
        return my_list

    for num in range(2, number+1):
        my_list.append(my_list[-1]*num)
    return my_list


number = InputNumbers("Введите число")
print(ListMultiplyNumber(number))