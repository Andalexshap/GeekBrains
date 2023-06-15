'''Напишите программу, которая принимает на вход число N и выдаёт последовательность из N членов.
   *Пример:*
   - Для N = 5: 1, -3, 9, -27, 81
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




number = InputNumbers("Введите степень")
my_list = []

for deegree in range(number):
    my_list.append((-3)**deegree)

print(my_list)