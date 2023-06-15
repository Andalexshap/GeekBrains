import controller

def show_main_menu()->int:
    menu_list = ['Показать доступные классы',
                 'Выход']
    print('\033[36mМеню:\033[33m')
    for i in range(len(menu_list)):
        print(f'\t{i+1}. {menu_list[i]}')
    return controller.model.input_menu_item(1,2)

def show_sub_menu(menu_list: list, message: str, start_point:int, end_point:int)->int:
    menu_list.append('Выход в меню')
    print(f"\033[36m{message}\033[0m")

    for i in range(len(menu_list)):
        print(f'\t\033[33m{i+1}. {menu_list[i]}\033[0m')
    user_choise = controller.model.input_menu_item(start_point,end_point+1)
    if user_choise-1 == end_point:
        controller.start()
    else:
        return user_choise


def show_clases():
        end_point = len(controller.model.get_all_clases())
        message= 'Доступные классы:'
        clases_list = controller.model.get_all_clases()
        user_choise = show_sub_menu(clases_list, message, 1, len(clases_list))
        if(user_choise == end_point + 1):
            controller.start()
        else: 
            path = controller.model.get_main_directory() + clases_list[user_choise-1]
            controller.model.set_main_path_database(path)
            show_subjects(path)

def show_subjects(path: str) -> int:
    controller.model.set_database(path)
    data = controller.model.load_database()
    message = 'Список предметов:'
    subject_list = []
    for i in range(len(data)):
        subject_list.append(data[i][0])
    user_choise = show_sub_menu(subject_list, message, 1, len(subject_list))
    show_journal(subject_list[user_choise-1])

def show_journal(subject:str):
    if not controller.model.get_journal():
        controller.model.open_subject(subject)
    journal = controller.model.get_journal()
    student_list = []
    for student in journal:
        meddle_mark = controller.model.meddle_mark(journal.get(student))
        student_list.append(f"{str(student)} {str(journal.get(student))}. Cредний бал: {meddle_mark}")
    user_choise = show_sub_menu(student_list, "Кто пойдет к доске?", 1, len(student_list))
    student = student_list[user_choise-1].split(" ")[0] + " " + student_list[user_choise-1].split(" ")[1]
    print(f"\t\033[33m{student}, ответил(а), какую оценку поставим?\033[0m")
    while True:
        try:
            mark = int(input("\033[36mОценка:\033[0m"))
            if 1<mark<6:
                controller.model.set_mark(mark, student)
                show_journal(subject)
                break
            else: 
                print("\033[31mВведите цифру от 2 до 5!\033[0m")
                continue
        except ValueError:
            print("\033[31mНеобходимо вводить цифру!!!\033[0m")




