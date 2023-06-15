import controller

def is_show_menu():
    is_runing = True
    while is_runing:
        is_show = input('\033[36mПоказать меню?\033[0m (\033[32mДа\033[0m / \033[31mНет\033[0m) ').lower()
        if is_show == 'да':
            controller.input_handler()
            is_runing = False
        elif is_show == 'нет':
            print("\033[33mПриложение закрыто!\033[0m")
            quit()
        else: 
            print("\033[31mВведите ДА или НЕТ\033[0m") 


def show_menu()->int:
    menu_list = ['Показать все контакты',
                 'Создать контакт',
                 'Изменить контакт',
                 'Удалить контакт',
                 'Выход']
    print('\033[36mМеню:\033[33m')
    for i in range(len(menu_list)):
        print(f'\t{i+1}. {menu_list[i]}')
    return input_menu_item(1,5)


def show_sub_menu()->int:
    menu_list = ['Фамилия',
                 'Имя',
                 'Телефон',
                 'Описание',
                 'Все',
                 'Выход в меню']
    print("\033[36mКакое поле требует замены?\033[0m")

    for i in range(len(menu_list)):
        print(f'\t\033[33m{i+1}. {menu_list[i]}\033[0m')
    return input_menu_item(1,6)


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
        

def show_all_contact():
    db = controller.model.get_db()
    if len(db) == 0:
        controller.model.open_db('r')
        db = controller.model.get_db()
        if len(db) == 0:
            print("\033[31mСправочник пуст\033[0m")
            is_show_menu()
    for i in range(len(db)):
        print(f"\t\033[33m{i+1}", end=". ")
        for key, value in db[i].items():
            if key != 'id':
                print(f'{value}', end=" ")
        print('\033[0m')
    is_show_menu()

def is_correct(message:str)->bool:
    is_runing = True
    while is_runing:
        is_all_correct = input(f'\033[33m{message}\033[0m (\033[32mДа\033[0m / \033[31mНет\033[0m) ').lower()
        if is_all_correct == 'да':
            return True
        elif is_all_correct == 'нет':
            return False
        else: 
            print("\033[31mВведите ДА или НЕТ\033[0m")