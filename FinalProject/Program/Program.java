package Program;
//13.   Создать класс с Инкапсуляцией методов и наследованием по диаграмме.
//14.   Написать программу, имитирующую работу реестра домашних животных. В программе должен быть реализован следующий функционал:
//          Завести новое животное;
//          Определять животное в правильный класс;
//          Увидеть список команд, которое выполняет животное;
//          Обучить животное новым командам;
//          Реализовать навигацию по меню.
//15.   Создайте класс Счетчик, у которого есть метод add(), увеличивающий̆ значение внутренней̆ int переменной̆ на 1
//  при нажатии “Завести новое животное”.
//      Сделайте так, чтобы с объектом такого типа можно было работать в блоке try-with-resources.
//      Нужно бросить исключение, если работа с объектом типа счетчик была не в ресурсном try и/или ресурс остался открыт.
//
//      Значение считать в ресурсе try, если при заведении животного заполнены все поля.


import java.io.IOException;
import java.time.LocalDate;
import java.time.format.DateTimeParseException;
import java.util.InputMismatchException;
import java.util.Scanner;


public class Program {

    public static void main(String[] args) {

        UI ui = new UI(new Engine());
            boolean f = true;
            Scanner scanner = new Scanner(System.in);
            while (f) {
                System.out.println("*** Программа запущена ***");
                System.out.println("=======================");
                System.out.println("1. Добавить животное");
                System.out.println("2. Добавить команду");
                System.out.println("3. Показать команды");
                System.out.println("0. ЗАВЕРШЕНИЕ РАБОТЫ ПРИЛОЖЕНИЯ");
                System.out.print("Пожалуйста, выберите пункт меню: ");
                try(Counter counter = new Counter()) {
                    if (scanner.hasNextInt()) {
                        int no = scanner.nextInt();
                        scanner.nextLine();
                        try {
                            switch (no) {
                                case 0:
                                    System.out.println("Завершение работы приложения");
                                    f = false;
                                    break;
                                case 1:

                                    ui.addNewAnimal();
                                    System.out.println("Успешно добавлено.");
                                    counter.add();
                                    break;
                                case 2:
                                    ui.addNewCommand();
                                    System.out.println("Команда добавлена.");
                                    break;
                                case 3:
                                    ui.showCommands();
                                    break;

                                default:
                                    System.out.println("Укажите корректный пункт меню.");
                            }
                        } catch (DateTimeParseException e) {
                            System.out.println("Введена не корректная дата");
                            f = false;
                        } catch (InputMismatchException e) {
                            System.out.println("Введены не корректные данные");
                            f = false;
                        } catch (NullPointerException e) {
                            System.out.println("Что-то пошло не так либо животное не добавлено");
                            f = false;
                        }
                    } else {
                        System.out.println("Укажите корректный пункт меню.....");
                        scanner.nextLine();
                    }
                }catch (Exception e){
                    throw new RuntimeException("Не закрытый поток");
                }
            }
    }
}







