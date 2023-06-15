'''
2. Напишите программу, которая на вход принимает 5 чисел и находит максимальное из них.

Примеры:
- 1, 4, 8, 7, 5 -> 8
- 78, 55, 36, 90, 2 -> 90
'''
list_of_numbers = []
for i in range(5):
    count = i + 1
    number = int(input(f"Введите {count}-е число:"))
count = 1
maximal = list_of_numbers[0]
while(count == 4):
    if(list_of_numbers[count]>maximal):
        maximal = list_of_numbers[count]

print(f"Максимальное число {maximal}")