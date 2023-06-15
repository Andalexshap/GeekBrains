import model
import view

def user_chose()-> int:
    user_chose_item = view.show_main_menu()
    return user_chose_item

def start():
    match user_chose():
        case 1:
            view.show_clases()
        case 2:
            print('\033[31mВыход из электронного журнала...\033[0m')
            quit()