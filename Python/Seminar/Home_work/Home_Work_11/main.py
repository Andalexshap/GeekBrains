# f(x) = -12x^4*sin(cos(x)) - 18x^3+5x^2 + 10x - 30
# 1. Определить корни
# 2. Найти интервалы, на которых функция возрастает
# 3. Найти интервалы, на которых функция убывает
# 4. Построить график
# 5. Вычислить вершину
# 6. Определить промежутки, на котором f > 0
# 7. Определить промежутки, на котором f < 0

from numpy import sin, cos, arange
from scipy.optimize import fsolve
import matplotlib.pyplot as plt

minimum = -30
maximum = 30
# График функции при помощи библиотеки matplotlib:
def func(x):
    return -12*x**4*(sin(cos(x))) -18*x**3+5*x**2 + 10*x - 30

x = arange(minimum, maximum, 0.1)
plt.plot(x, func(x), "r-")
plt.grid()
plt.show()

# Определить корни
def f(x):
    return -12 * x ** 4 * sin(cos(x)) - 18 * x ** 3 + 5 * x ** 2 + 10 * x - 30
# Это тригонометрическая функция, имеющая бесконечное количество корней.
# Можно определить корни только на заданном интервале.
def find_sqrt():
    global minimum, maximum
    temp = minimum
    rightnum = maximum
    roots = []
    interval = []

    while temp < rightnum:
        if f(temp) >= 0 and f(temp + 1) <= 0:
            w = fsolve(f, temp)
            roots.append(*w)
        if f(temp) <= 0 and f(temp + 1) >= 0:
            w = fsolve(f, temp)
            roots.append(*w)
        if f(temp) > f(temp + 1) < f(temp + 2):
            interval.append(temp + 1)
        temp += 1
    roots = [round(i, 2) for i in roots]
    print(f'Корни уравнения для заданного интервала: {roots}')
    return roots

# Определить промежутки, на которых f>0 и f<0:
def func_interval(left, right):
    array = [[0,0]]
    temp = left
    while left < right:
        array.append([f(left), left])
        left += 0.1
    try:
        if array[0][0] > 0:
            print(f'f > 0 в промежутке {temp, right}')
            return max(array)
        else:
            print(f'f < 0 в промежутке {temp, right}')
            return min(array)
    except:
        return array


# Вычисляем координаты вершины функции на заданном интервале:
def maxima_and_minima():
    roots = find_sqrt()

    if len(roots) < 2:
        print('На заданном интервале нет вершин')
    else:
        top = []
        for i in range(len(roots) - 1):
            top.append(func_interval(roots[i], roots[i + 1]))
        for j in top:
            j = [round(i, 2) for i in j]
            print(f'Координаты вершин функции: [{j[1]}, {j[0]}]')
        if len(top) < 2:
            print('error')
        else:
            for i in range(len(top) - 1):
                if top[i][0] > top[i + 1][0]:
                    print('Функция убывает')
                else:
                    print('Функция возрастает')


maxima_and_minima()
# Корни уравнения для заданного интервала: [-29.9, -26.65, -23.63, -20.35, -17.37, -14.03, -11.13, -7.65, -5.03, -1.34, 2.27, 4.38, 8.04, 8.04, 14.24, 17.19, 20.49, 23.5, 26.76, 29.8]
# f < 0 в промежутке (-29.9, -26.65)
# f > 0 в промежутке (-26.65, -23.63)
# f < 0 в промежутке (-23.63, -20.35)
# f > 0 в промежутке (-20.35, -17.37)
# f < 0 в промежутке (-17.37, -14.03)
# f > 0 в промежутке (-14.03, -11.13)
# f > 0 в промежутке (-11.13, -7.65)
# f < 0 в промежутке (-7.65, -5.03)
# f < 0 в промежутке (-5.03, -1.34)
# f > 0 в промежутке (-1.34, 2.27)
# f < 0 в промежутке (2.27, 4.38)
# f > 0 в промежутке (4.38, 8.04)
# Координаты вершин функции: [-1.34, 0.11]
# Координаты вершин функции: [2.27, -0.88]
# Функция убывает