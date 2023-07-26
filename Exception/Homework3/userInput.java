package Exception.Exeptions.Homework3;

import java.io.FileWriter;
import java.io.IOException;

import java.util.Arrays;
import java.util.Random;
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



public class userInput {
    static Scanner scanner = new Scanner(System.in);
    static Random random = new Random();

    public static void main(String[] args) {


//        try(FileWriter writer = new FileWriter("NameSurname.txt", false))
//        {
//            // запись всей строки
//            String[] surname = addSurname();
//            String text = "Hello Gold!";
//            writer.write(String.valueOf(surname));
//            // запись по символам
//            writer.append('\n');
//            writer.append('E');
//
//            writer.flush();
//        }
//        catch(IOException ex){
//
//            System.out.println(ex.getMessage());
//        }
    addSurname();
    addDateOfBirth();
    }

    static String[] addSurname() {
        String[] surname = new String[3];
        try(FileWriter writer = new FileWriter("NameSurname.txt", false)) {
            while (surname[2] == null) {
                System.out.print("Введите фамилию: ");
                if (scanner.hasNextLine()) {
                    surname[0] = scanner.nextLine();
                    writer.write(surname[0]);
                    writer.write(" ");
                } else System.out.println("Вы ввели не верно, введите корректно");
                System.out.print("Введите имя: ");
                if (scanner.hasNextLine()) {
                    surname[1] = scanner.nextLine();
                    writer.write(surname[1]);
                    writer.write(" ");
                } else System.out.println("Вы ввели не верно, введите корректно");

                System.out.print("Введите отчество: ");
                if (scanner.hasNextLine()) {
                    surname[2] = scanner.nextLine();
                    writer.write(surname[2]);
                    writer.write(" ");
                } else System.out.println("Вы ввели не верно, введите корректно");
            }
        }
        catch(IOException ex){

            System.out.println(ex.getMessage());
        }
        for (String str: surname
             ) {
            System.out.printf("%s ",str);

        }
        System.out.print("\n");
        return  surname;
        }


        static String[] addDateOfBirth() {
        String[] dateOfBirth = new String[3];
        try(FileWriter writer = new FileWriter("NameSurname.txt", true)) {
            int caunt = 0;
            while (caunt < 3) {
                System.out.print("Введите число месяца (даты рождения): ");
                if (scanner.hasNextInt()) {
                    dateOfBirth[0] = scanner.nextLine();
                    writer.write(dateOfBirth[0]);
                    writer.write(".");
                    caunt++;

                } else {
                    System.out.println("Вы ввели не верно, введите корректно");
                    scanner.nextLine();
                }
                System.out.print("Введите месяц числом: ");
                if (scanner.hasNextInt()) {
                    dateOfBirth[1] = scanner.nextLine();
                    writer.write(dateOfBirth[1]);
                    writer.write(".");
                    caunt++;
                } else System.out.println("Вы ввели не верно, введите корректно");

                System.out.print("Введите год: ");
                if (scanner.hasNextInt()) {
                    dateOfBirth[2] = scanner.nextLine();
                    writer.write(dateOfBirth[2]);
                    writer.write(" ");
                    caunt++;
                } else System.out.println("Вы ввели не верно, введите корректно");
            }
        }
        catch(IOException ex){

            System.out.println(ex.getMessage());
        }
        for (String str: dateOfBirth
        ) {
            System.out.printf("%s.",str);

        }
        return  dateOfBirth;
    }

}

