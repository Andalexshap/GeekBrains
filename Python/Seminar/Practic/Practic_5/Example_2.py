# Дан список чисел. Создайте список, в который попадают числа, 
# описываемые возрастающую последовательность. Порядок элементов менять нельзя.
# *Пример:*
# 1, 5, 2, 3, 4, 6, 1, 7] => [1, 2, 3] или [1, 7] или [1, 6, 7] и т.д.

data = [1, 5, 2, 3, 4, 6, 7, 1, 7]
result = []
tmp = min(data)
start = data.index(tmp)
print(start)
for i in range(start, len(data) -1):
    temp = []
    temp.append(data[i])
    prev = data[i]
    for j in range(i+1, len(data)):
        if prev < data[j]:
            temp.append(data[j])
            prev = data[j]
        else: continue
    if len(temp) != 1:
        result.append(temp)
print(result)
    