'''
Задайте число. Составьте список чисел Фибоначчи, в том числе для отрицательных индексов.
Пример:
для k = 8 список будет выглядеть так: [-21 ,13, -8, 5, −3, 2, −1, 1, 0, 1, 1, 2, 3, 5, 8, 13, 21] Негафибоначчи
'''

def fibonachi(n):
    new_list = [1,0,1]
    if n == 1:
        return new_list
    for i in range(1, n):
        new_list.insert(0, new_list[1] - new_list[0])
        new_list.append(new_list[-1] + new_list[-2])
    return new_list
    
my_list = fibonachi(10)
print (my_list)
