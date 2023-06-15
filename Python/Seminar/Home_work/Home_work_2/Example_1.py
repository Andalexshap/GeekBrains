'''
Напишите программу, которая принимает на вход вещественное число и показывает сумму его цифр.
Пример:
- 6782 -> 23
- 0,56 -> 11
'''

def InputNumber(message):
    is_OK = False
    while not is_OK:
        try:
            number = float(input(f"{message}: "))
            is_OK = True
        except ValueError:
            print("Это не число!")
    return number


def SumDigitsOfNumber(number):
    sum = 0
    for i in str(number):
        if i != "." and i != "-":
            sum += int(i)
    return sum


number = InputNumber("Введите число")

print(f"Сумма цифр = {SumDigitsOfNumber(number)}")