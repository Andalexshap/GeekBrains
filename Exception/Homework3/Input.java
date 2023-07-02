package Exception.Homework3;

import java.io.FileWriter;
import java.io.IOException;
import java.util.InputMismatchException;
import java.util.Scanner;

/**
 Напишите приложение, которое будет запрашивать у пользователя
 следующие данные в произвольном порядке, разделенные пробелом:
 Фамилия Имя Отчество датарождения номертелефона пол
 Форматы данных:
 фамилия, имя, отчество - строки
 дата_рождения - строка формата dd.mm.yyyy
 номер_телефона - целое беззнаковое число без форматирования
 пол - символ латиницей f или m.
 Приложение должно проверить введенные данные по количеству.
 Если количество не совпадает с требуемым, вернуть код ошибки,
 обработать его и показать пользователю сообщение, что он ввел меньше и больше данных, чем требуется.
 Приложение должно попытаться распарсить полученные значения и выделить из них требуемые параметры.
 Если форматы данных не совпадают, нужно бросить исключение, соответствующее типу проблемы.
 Можно использовать встроенные типы java и создать свои. Исключение должно быть корректно обработано,
 пользователю выведено сообщение с информацией, что именно неверно.
 Если всё введено и обработано верно, должен создаться файл с названием, равным фамилии,
 в него в одну строку должны записаться полученные данные, вида
 <Фамилия><Имя><Отчество><датарождения> <номертелефона><пол>
 Однофамильцы должны записаться в один и тот же файл, в отдельные строки.
 Не забудьте закрыть соединение с файлом.
 При возникновении проблемы с чтением-записью в файл,
 исключение должно быть корректно обработано, пользователь должен увидеть стектрейс ошибки.
 */

public class Input {

    static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        inputSurname();
    }
    static void inputSurname(){
        System.out.println("Введите фамилию: ");
        String surname = scanner.next();
        System.out.println("Введите имя: ");
        String name = scanner.next();
        System.out.println("Введите отчетво: ");
        String patronymic = scanner.next();

        System.out.println("Введите дату рождения формата dd.mm.yyyy: ");
        String birthday = scanner.next();
        // проверяем что ввел пользователь (переберем строку по элементам)
        String forBirthday = "12.12.1988"; // для проверки создаем образец

        while (true) {
            try {
                if (birthday.charAt(2) == forBirthday.charAt(2) && birthday.charAt(5) == forBirthday.charAt(5) &&
                        birthday.length() == 10)  {
                    break;}
                else {
                    System.out.println("Введите корректно дату рождения dd.mm.yyyy:");
                    birthday = scanner.next();
                    break;
                }
            } catch (StringIndexOutOfBoundsException ex2){

                System.out.println(ex2.getMessage());
                System.out.println("Введите корректно дату рождения dd.mm.yyyy: ");
                birthday = scanner.nextLine();
                break;
            }



        }




        String phone;
        while (true) {
            try {
                System.out.println("Введите номер телефона ");
                phone = String.valueOf(scanner.nextInt()); // преобразовали int  в строку, так как в файл пишется строка
                break;
            } catch (InputMismatchException ex1) {
                System.out.println(ex1.getMessage());
                System.out.println("Введите корректно номер телефона");
                scanner.nextLine();
            }
        }


        String gender = null;
        while (true){
            System.out.println("Введите пол (f или m ): ");
            gender = scanner.next();
            if (gender.equals("f") || gender.equals("m")) {
                break;
            }
                else System.out.println("Вы ввели не верно, введите один из вариантов");
        }





        try(FileWriter writer = new FileWriter(surname, true)) { // создаем файл для записи
            writer.write(surname);
            writer.write(" ");
            writer.write(name);
            writer.write(" ");
            writer.write(patronymic);
            writer.write(" ");
            writer.write(birthday);
            writer.write(" ");
            writer.write(phone);
            writer.write(" ");
            writer.write(gender);

        }
        catch(IOException ex) {

            System.out.println(ex.getMessage());
        }
    }


}