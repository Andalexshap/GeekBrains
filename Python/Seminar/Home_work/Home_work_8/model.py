import os
import controller
__path_databases = 'Seminar\Home_work\Home_work_8\DataBases\\'
__main_directory = 'Seminar\Home_work\Home_work_8\DataBases\\'
__database =''
__journal = {}
__current_subject=''

class_list = []


def get_main_directory()->str:
    global __main_directory
    return __main_directory
def get_main_path_database() -> str:
    global __path_databases
    return __path_databases

def set_main_path_database(path:str):
    global __path_databases
    __path_databases = path

def get_current_subject()->str:
    global __current_subject
    return __current_subject

def set_current_subject(subject:str):
    global __current_subject
    __current_subject = subject


def get_all_clases() -> list:
    files = os.walk(get_main_directory()) 
    for filename in files:
        return filename[2]

def set_database(path: str, attribute = 'r'):
    global __database
    __database = open_file(path, attribute)

def load_database()->str:
    global __database
    return __database

def get_journal()->dict:
    global __journal
    return __journal


def set_journal(journal:dict):
    global __journal
    __journal = journal


def open_file(path: str, attribute = 'r') -> list:
    with open(path, attribute, encoding="UTF-8") as data:
        file = data.readlines()
        for i in range(len(file)):
            file[i] = file[i].strip().split(";")
    return file

def save_file():
    database = load_database()
    subject = get_current_subject()
    journal = get_journal()
    temp =''
    for k, v in journal.items():
        temp += k + ":" + str(v).replace(",", "").replace("[","").replace("]","")+", "
    temp = temp[:len(temp)-2]
    for i in range(len(database)):
        if database[i][0] == subject:
            database[i][1] = temp
    path = get_main_path_database()
    temp=''
    for i in range(len(database)):
        temp += database[i][0]+';'+database[i][1]+'\n'
    with open(path, 'w', encoding="UTF-8") as data:
        data.writelines(temp)
        


def open_subject(subject:str):
    set_current_subject(subject)
    data = load_database()
    for subj in data:
        if subj[0] == subject:
            for study in subj[1].strip().split(", "):
                __journal[study.split(":")[0]] = list(map(int, study.split(":")[1].split()))


def input_menu_item(min:int,max:int)->int:
    while True:
        menu_item = input('\n\033[36mВыберите пункт: \033[0m')
        try:
            if not min-1<int(menu_item)<max+1:
                print(f"\033[31mПункт {menu_item} отсутствует!\033[0m")
                continue
            return int(menu_item)
        except:
            print("\033[31mНеобходимо вводить цифру!!!\033[0m")


def meddle_mark(int_list) -> float:
    meddle_mark = 0
    for i in int_list:
         meddle_mark+=i
    meddle_mark /= len(int_list)
    return round(meddle_mark, 1) 

def set_mark(mark:int, student: str):
    journal = get_journal()
    marks = journal.get(student)
    marks.append(mark)
    set_journal(journal)
    print("\033[32mЖурнал обновлен...\033[0m")
    save_file()

    
