import model
import view

def user_chose()-> int:
    user_chose_item = view.show_menu()
    return user_chose_item

def input_handler():
    match user_chose():
        case 1:
            view.show_all_contact()
        case 2:
            model.create_contact()
        case 3:
            contact = model.find_contact()
            model.change_contact(contact)
        case 4:
            model.remove_contact_by_id()
        case 5:
            print('\033[31mВыход из стравочника...\033[0m')
            quit()

