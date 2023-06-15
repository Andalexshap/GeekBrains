""" Напишите программу, которая принимает на вход координаты точки (X и Y), 
причём X ≠ 0 и Y ≠ 0 и выдаёт номер четверти плоскости, в которой находится эта точка (или на какой оси она находится). 
Пример: - x=34; y=-30 -> 4 - x=2; y=4-> 1 - x=-34; y=-30 -> 3  """

def inputNumber(x):
    a = [0] * x
    for i in range(x):
        is_OK = False
        while not is_OK:
            try:
                number = float(input(f"Введите {i+1}ю координату: "))
                a[i] = number
                is_OK = True
                if a[i] == 0:
                    is_OK = False
                    print("Координата не должна быть равна 0 ")
            except:
                print("Необходимо вводить число!")                
    return a


def checkCoordinates(xy):
    plane = 4
    if xy[0] > 0 and xy[1] > 0:
        plane = 1
    elif xy[0] < 0 and xy[1] > 0:
        plane = 2
    elif xy[0] < 0 and xy[1] < 0:
        plane = 3
    print(f"Точка находится в {plane} четверти плоскости")


xy = inputNumber(2)
checkCoordinates(xy)