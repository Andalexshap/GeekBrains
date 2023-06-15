import controller

__DB_PATH = "E:\GeekBrains\Python\Seminar\Home_work\Home_work_7\database.txt"
__db_list = []


def get_db() ->list:
    global __db_list
    return __db_list


def set_db(db:list):
    global __db_list
    __db_list = db

def check_db()->list:
    db = get_db()
    if len(db) == 0:
        open_db('r')
        db = get_db()
    return db


def open_db(flag:str) -> dict:
    global __DB_PATH
    global __db_list
    if flag == 'r':
        with open(__DB_PATH, flag, encoding='UTF-8') as file:
            db_list = file.readlines()
            set_db(parse_db(db_list))
    elif flag == 'w':
        with open(__DB_PATH, flag, encoding='UTF-8') as file:
            db = convert_list_to_db(__db_list)
            for line in db:
                file.writelines(line)
        print("\033[32mСправочник обновлен!\033[0m")

        controller.view.is_show_menu()


def parse_db(database:list)->list:
    db = get_db()
    for i in range(len(database)):
        if database[i] == "" or database[i] == "\n":
            database.pop(i)
    for line in database:
        id_dict = dict()
        line = line.strip().split(';')
        id_dict["id"] = line[0]
        id_dict["last_name"] = line[1]
        id_dict["first_name"] = line[2]
        id_dict["phone"] = line[3]
        id_dict["description"] = line[4]
        db.append(id_dict)
    return db


def create_contact():
    contact = []
    print("\033[36mЗаполните данные:\033[0m")
    contact.append(input("\t\033[33mФамилия: \033[0m"))
    contact.append(input("\t\033[33mИмя: \033[0m"))
    contact.append(input("\t\033[33mТелефон: \033[0m"))
    contact.append(input("\t\033[33mОписание: \033[0m"))
    if (contact[0] == "" and contact[1] == "") or contact[2]== "":
        print("\033[31mНе заполнены основные поля: \033[35mФамилия/Имя\033[31m или \033[35mномер телефона!\033[0m")
        print("\033[36mЗаполните контакт заново!\033[0m")
        create_contact()
    for i in contact:
        print(f'\033[32m{i}\033[0m', end=" ")
    print()
    is_correct = controller.view.is_correct("Все верно?")
    if is_correct:
        update_database(contact)
    else:
        create_contact()


def update_database(contact:list):
    db = check_db()
    last_id = 0
    for i in range(len(db)):
        for key, value in db[i].items():
            if key == 'id' and int(value) > last_id:
                last_id = int(value)

    contact_dict = {"id":last_id+1,
                    "last_name":contact[0],
                    "first_name": contact[1],
                    "phone": contact[2],
                    "description":contact[3]}
    db.append(contact_dict)
    set_db(db)
    open_db('w')


def convert_list_to_db(db_list:list)->list:
    db = []
    for contact in db_list:
        temp=""
        temp += f"{contact.get('id', '------;')};"
        temp += f"{contact.get('last_name', '------;')};"
        temp += f"{contact.get('first_name', '------;')};"
        temp += f"{contact.get('phone', '------;')};"
        temp += f"{contact.get('description', '------;')}\n"
        db.append(temp)
    return db

def find_contact()->dict:
    user_choice = input("\033[33mВведите порядковый номер контакта: \033[0m")
    db = check_db()
    is_find = False
    for contact in db:
        if str(contact.get("id")) == user_choice: 
            is_find = True  
            print("\033[31mВыбранный контакт:")
            print("\t", end="")
            for key, value in contact.items():
                if key == 'id':
                    print(f"{value}.", end=" ")
                else:
                    print(value, end=" ")
            print("\033[0m")
            return contact
    if not is_find:
        print("\033[31mКонтакт не найден!!!\033[0m")
        print("\033[33mВозврат в меню...\033[0m")
        controller.input_handler()
             
                            
def change_contact(contact:dict):
        match controller.view.show_sub_menu():
            case 1:
                last_name = input("\033[32mНовая Фамилия: \033[0m")
                contact["last_name"] = last_name
            case 2:
                first_name = input("\033[32mНовое Имя: \033[0m")
                contact["first_name"] = first_name
            case 3:
                phone = input("\033[32mНовый номер телефона: \033[0m")
                contact["phone"] = phone
            case 4:
                description = input("\033[32mНовое описание: \033[0m")
                contact["description"] = description
            case 5:
                temp_dict = {"id":contact.get("id"),
                             "last_name":input("\033[32mНовая Фамилия: \033[0m"),
                             "first_name":input("\033[32mНовое Имя: \033[0m"),
                             "phone":input("\033[32mНовый номер телефона: \033[0m"),
                             "description":input("\033[32mНовое описание: \033[0m")}
                contact.update(temp_dict)
                
            case 6:
                controller.input_handler()
        print
        print("\033[32mИзмененный контакт :\033[0m")
        print("\t\033[32m", end="")
        for key, value in contact.items():
            if key == 'id':
                print(f"{value}.", end=" ")
            else:
                print(value, end=" ")
        print("\033[0m")        
        is_correct = controller.view.is_correct("Все верно?")
        if is_correct:
            db = get_db()
            for cont in db:
                if cont.get("id")==contact.get("id"):
                    cont.update(contact)
                    set_db(db)
                    open_db('w')
        else:change_contact(contact)    
    

def remove_contact_by_id():
    contact = find_contact()
    is_correct = controller.view.is_correct("Удалить выбранный контакт?")
    if is_correct:
        db = get_db()
        for i in range(len(db)):
                if db[i].get("id")==contact.get("id"):
                    db.pop(i)
                    set_db(db)
                    open_db('w')
    else:
        print("\033[31mОтмена удаления...\033[0m")
        print("\033[33mВозврат в меню...\033[0m")
        controller.input_handler()

    
        
    
