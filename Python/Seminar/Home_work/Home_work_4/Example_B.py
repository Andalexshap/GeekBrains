'''B. Даны два файла, в каждом из которых находится запись многочлена. 
Задача - сформировать файл, содержащий сумму многочленов.'''

def convert_str_to_dictionary(line):
    new_dict = {}
    line = line.replace(" - ", " -").replace(" + ", " +").replace("- ", "-").replace("= 0", "").strip()
    line = line.split(" ")
    
    for i in range(len(line)):
        if line[i].find("x**") == -1 and line[i].find("x") == -1:
            line[i] += "x**0"
        elif line[i].find("x**") == -1 and line[i].find("x") > 1:
            line[i] += "**1"

    for i in range(len(line)):
        line[i] = line[i].replace("+", "").split("x**")
        new_dict[int(line[i][1])] = int(line[i][0])
    
    return new_dict

def Sum_of_polynomial(first_dict, second_dict):
    result_dict = {}
    maximum=(max(max(first_dict),max(second_dict)))
    
    for i in range(int(maximum), -1, -1):
        first = first_dict.get(i)
        second = second_dict.get(i)
        
        if first != None or second != None:
            result_dict[i] = (first if first != None else 0) + (second if second != None else 0)
        
    return result_dict

def convert_dictionary_to_str(dict):
    new_str = ''
    
    for i in dict.items():
        if i[1] < 0: new_str += ' - ' + str(abs(i[1])) + 'x**' + str(abs(i[0]))
        elif i[1] > 0:
            if new_str != '': new_str += ' + ' + str(abs(i[1])) + 'x**' + str(abs(i[0]))
            else: new_str += str(abs(i[1])) + 'x**' + str(abs(i[0]))
    
    new_str = new_str.replace("x**1 ","x ").replace("x**0", "")
    
    return new_str + " = 0"

path1 = R'Seminar\Home_work\Home_work_4\file1.txt'
path2 = R'Seminar\Home_work\Home_work_4\file2.txt'
with open(path1, 'r', encoding='utf-8') as data:
    first_response = data.readline()
with open(path2, 'r', encoding='utf-8') as data:
    second_response = data.readline()

first_response_dict = convert_str_to_dictionary(first_response)
second_response_dict = convert_str_to_dictionary(second_response)
sum_of_polynomial = Sum_of_polynomial(first_response_dict, second_response_dict)
result = convert_dictionary_to_str(sum_of_polynomial)

result_path = R'Seminar\Home_work\Home_work_4\result.txt'
with open(result_path, 'w', encoding='utf-8') as data:
    data.writelines(result)

