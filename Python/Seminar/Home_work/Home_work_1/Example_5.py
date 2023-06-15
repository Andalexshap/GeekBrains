'''
Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 2D пространстве.
Пример:
- A (3,6); B (2,1) -> 5,09
- A (7,-5); B (1,-1) -> 7,21
'''

def inputNumbers(x):
    xyz = ["X", "Y"]
    a = []
    for i in range(x):
        a.append(int(input(f"Введите значение {xyz[i]}: ")))
    return a


def distance(a, b):
    distance = ((b[0] - a[0]) ** 2 + (b[1] - a[1]) ** 2) ** (0.5)
    return distance


print("Введите координаты точки А")
pointA = inputNumbers(2)
print("Введите координаты точки В")
pointB = inputNumbers(2)

print(f"Длина отрезка: {format(distance(pointA, pointB), '.2f')}")