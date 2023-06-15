'''
Задайте список из n чисел последовательности (1 + 1/n)^n, выведеите его на экран, а так же сумму элементов списка.
Пример:
Для n=4 -> [2, 2.25, 2.37, 2.44]
Сумма 9.06
'''

def InputNumber(message):
    is_OK = False
    while not is_OK:
        try:
            number = int(input(f"{message}: "))
            is_OK = True
        except ValueError:
            print("Это не число! Либо число не целое")
    return number


def CreateSubsequence(n):
    my_list =[]
    
    for i in range(1, n+1):
        value = round((1 + 1/i)**i,2)
        
        if (value*10)%10 == 0:
             my_list.append(int(value))
        else:
            my_list.append(value)
    
    return my_list
    

def SumOfElemetnsList(sm_list):
    sum = 0

    for i in sm_list:
        sum += i

    return sum


n = InputNumber("Введите натуральное число")
my_list = CreateSubsequence(n)
sum = SumOfElemetnsList(my_list)
print(f"Для n = {n}, последовательность равна: {my_list}")
print(f"Сумма элементов последовательности, равна: {sum}")

