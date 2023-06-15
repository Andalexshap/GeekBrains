'''
Вывести на экран числа от -N до N
'''

def InputNumber(message):
    while True:
        try:
            number = int(input(f"{message}: "))
            break
        except ValueError:
            print("Это не число!")
    return number

def list_of_number(n):
    new_list = []
    count = -n
    while count<=n:
        new_list.append(count)
        count +=1
    return new_list

number = InputNumber("Введите число")
print(f"Последовательность чисел от -{number} до {number} равна: {list_of_number(number)}")
