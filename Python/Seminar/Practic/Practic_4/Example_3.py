'''
Найдите корни квадратного уравнения Ax² + Bx + C = 0 
с помощью математических формул нахождения корней квадратного уравнения
'''
equation = '3*x**2 + 5*x - 6 = 0'
temp = equation.replace('**2','').replace('*x','').replace(' = 0','').replace(' ', '')
print(len(temp))
if len(temp) == 6:
    a = int(temp[1]) * -1
    if temp[2] == '-':
        b = int(temp[3]) * -1
    elif temp[2] == '+':
        b = int(temp[3]) 
    if temp[4] == '-':
        c = int(temp[5]) * -1
    elif temp[2] == '+':
        c = int(temp[5]) 
else:
    a = int(temp[0])
    if temp[1] == '-':
        b = int(temp[2]) * -1
    elif temp[1] == '+':
        b = int(temp[2]) 
    if temp[3] == '-':
        c = int(temp[4]) * -1
    elif temp[3] == '+':
        c = int(temp[4]) 
print(a,b,c)
discriminant = b**2 - 4*a*c
def func(d):
    if discriminant < 0:
        return "Уравнение не имеет корней"
    elif discriminant == 0:
        return -(b/(2*a))
    elif discriminant >0 :
        x1 = round((-(b+discriminant**0.5))/(2*a),3)
        x2 = round((-(b-discriminant**0.5))/(2*a),3)
    return f"X1 = {x1}, X2 = {x2}"

print(func(discriminant))