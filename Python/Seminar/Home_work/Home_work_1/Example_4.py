# Напишите программу, которая по заданному номеру четверти, показывает диапазон возможных координат точек в этой четверти (x и y).

def posibleValues(plate):
    message = f"Возможные значения для {plate}-й четверти:"
    if(plate == 1):
        print(f"{message} X = (0 ; +infinity) ; Y = (0 ; +infinity)" )
    elif(plate == 2):
        print(f"{message} X = (-infinity ; 0) ; Y = (0 ; +infinity)" )
    elif(plate == 1):
        print(f"{message} X = (-infinity ; 0) ; Y = (-infinity ; 0)" )
    elif(plate == 1):
        print(f"{message} X = (0 ; +infinity) ; Y = (-infinity ; 0)" )
    else:
        print(f"Четверти {plate} не существует!" )


plate = int(input("Введите номер четверти от 1 до 4: "))
posibleValues(plate)