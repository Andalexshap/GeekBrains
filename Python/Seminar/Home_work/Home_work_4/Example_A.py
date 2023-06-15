'''
A. Задана натуральная степень k. Сформировать случайным образом список коэффициентов (значения от 0 до 100) многочлена и записать в файл многочлен степени k.
Пример:
если k = 2, то многочлены могут быть => 2*x² + 4*x + 5 = 0 или x² + 5 = 0 или 10*x² = 0
Расширить значение коэффициентов до [-100..100]
'''

from random import randint as RI

def InputNumber(message):
    while True:
        try:
            number = int(input(f"{message}: "))
            break
        except ValueError:
            print("Это не число!")
    return number


def convert_txt_to_dict(path):
    new_dict = {}
    with open(path, "r", encoding='utf-8') as data:
        for line in data:
            key, value = line.replace(',','').replace('\n','').replace(' ','').split(':')
            new_dict[key] = value
    return new_dict


def create_polynomial(degree, dict_of_degree):
    polinomial = ""

    while degree != 0:
        value = RI(-100,100)
        if value == 0:
            degree -= 1
            continue
        elif value > 1 and polinomial != "": value = f"+ {value}"
        elif value < -1: value = f"- {value*-1}"
        elif value == -1: value = f"- "
        elif value == 1 and polinomial != "": value = "+ "
        elif value == 1 and polinomial == "": value = ""

        if degree > 9:
            degree_of_number = dict_of_degree[str(int(degree/10))] + dict_of_degree[str(int(degree%10))]
            polinomial += f"{value}x{degree_of_number} "
        elif 1<degree<=9:
            degree_of_number = dict_of_degree[str(degree)]
            polinomial += f"{value}x{degree_of_number} "
        else: polinomial += f"{value}x "

        degree -= 1
    else: polinomial += f"{value} = 0"
    return polinomial
    
degree = InputNumber("Задайте натуральную стень k")
path = "Seminar\Home_work\Home_work_4\degree_of_numbers.txt"
degree_of_numbers = convert_txt_to_dict(path)
polinomial = create_polynomial(degree, degree_of_numbers)
print(polinomial)