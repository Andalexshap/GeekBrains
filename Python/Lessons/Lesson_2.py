# Файлы
'''
Как работать с файлами:
Связать файловую переменную с файлом,
определив модификатор работы
a – открытие для добавления данных
r – открытие для чтения данных
w – открытие для записи данных
w+, r+
'''
with open('file.txt', 'w') as data:
 data.write('line 1\n')
 data.write('line 2\n')

colors = ['red', 'green', 'blue']
data = open('file.txt', 'a',encoding='UTF8')
data.writelines(colors) # разделителей не будет
data.close()

path = 'file.txt'
data = open(path, 'r')
for line in data:
    print(line)
data.close() 

# Функции
#import Lesson_1 as L
#print(L.f(2))

def new_string(symbol, count=3):
    return symbol*count

print(new_string('!', 5)) # !!!!!
print(new_string("!"))    # !!!
print(new_string(4))      # 12


#Неограниченное количество переменных
def concatenatio(*params):
    res: str = ""                   #': str' - указание типа переменной 
    for item in params:
        res += item
    return res

        
print(concatenatio('a', 's', 'd', 'w')) #asdw
print(concatenatio('a', '1'))         #a1
# print(concatenatio(1,2,3,4))       #TypeError:...

def concatenatioList(*params):
    my_list = []
    for item in params:
        my_list.append(item)
    return my_list

print(concatenatioList('a', 's', 'd', 'w')) #['a', 's', 'd', 'w']
print(concatenatioList('a', '1'))           #['a', '1']
print(concatenatioList(1,2,3,4))            #[1, 2, 3, 4]

#Рекурсия
def fib(n):
    if n in [1,2]:
        return 1
    else:
        return fib(n-1) + fib(n-2)
my_list = []
for e in range(1,10):
    my_list.append(fib(e))
print( my_list)                         #[1, 1, 2, 3, 5, 8, 13, 21, 34]

#Кортежи
a = (3,4)
print(a)
print(a[0])
print(a[-1])
#a[0] =12                #Работать не будет, так как кортеж, неизменяем
for item in a:
    print(item)

# Словари Dictionary
dictionary = {}
dictionary = \
    {
        'up': '↑',
        'left': '←',
        'down': '↓',
        'right': '→'
    }
print(dictionary)           #{'up': '↑', 'left': '←', 'down': '↓', 'right': '→'}
print(dictionary['left'])   #←

for k in dictionary.keys():
    print(k)
del dictionary['left'] # удаление элемента
for item in dictionary: # for (k,v) in dictionary.items():
 print(item, dictionary[item])

 #Множества
colors = {'red', 'green', 'blue'}
print(colors)           # {'red', 'green', 'blue'}
colors.add('red')
print(colors)           # {'red', 'green', 'blue'}
colors.add('gray')
print(colors)           # {'red', 'green', 'blue','gray'}
colors.remove('red')
print(colors)           # {'green', 'blue','gray'}
# colors.remove('red')  # KeyError: 'red'
colors.discard('red')   # ok
print(colors)           # {'green', 'blue','gray'}
colors.clear()          # { }
print(colors)           # set()

a = {1, 2, 3, 5, 8}
b = {2, 5, 8, 13, 21}
c = a.copy()            # c = {1, 2, 3, 5, 8}
u = a.union(b)          # u = {1, 2, 3, 5, 8, 13, 21}
i = a.intersection(b)   # i = {8, 2, 5}
dl = a.difference(b)    # dl = {1, 3}
dr = b.difference(a)    # dr = {13, 21}
q = a \
 .union(b) \
 .difference(a.intersection(b)) # {1, 21, 3, 13}

 
#Неизменяемое множество
a = {1, 2, 3, 5, 8}
b = frozenset(a)
print(b) # frozenset({1, 2, 3, 5, 8})

#списки

list1 = [1,2,3,4,5]
List2 = list1.copy()
list1[0] = 123
print (list1)
print(List2)