'''
3. Напишите программу, которая определит позицию второго
вхождения строки в списке либо сообщит, что её нет.

*Пример:*

- список: ["qwe", "asd", "zxc", "qwe", "ertqwe"], ищем: "qwe", ответ: 3
- список: ["йцу", "фыв", "ячс", "цук", "йцукен", "йцу"], ищем: "йцу", ответ: 5
- список: ["йцу", "фыв", "ячс", "цук", "йцукен"], ищем: "йцу", ответ: -1
- список: ["123", "234", 123, "567"], ищем: "123", ответ: -1
- список: [], ищем: "123", ответ: -1

'''
text = ['dfds', 'sdfsdf','sdfsdfs','dsfs','sdf']
search = 'df23'
position = 2

def find_text(list, position):
    count = 0
    for i in range(0, len(list)):
        if search in list[i]:
            if count == position:
                return i
            else:
                count += 1
    if count < position:
        return -1            


response = find_text(text, position)
print(response)