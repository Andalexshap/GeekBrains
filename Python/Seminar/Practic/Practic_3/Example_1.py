'''
Задайте список. Напишите программу, которая определит, присутствует ли в заданном списке строк некое число.
'''
text = ['dfds', 'sdfsdf','sdfsdfs','dsfs','sdf']
search = 'df'

for i in range(0, len(text)):
    if search in text[i]:
        print(f"В элементе с индексом: {i} - 'Да'")
    else:
        print(f"В элементе с индексом: {i} - 'Нет'")
        
    


