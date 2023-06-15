package Home_work.Home_work_5.Services;

import java.util.Scanner;
import java.util.concurrent.TimeUnit;

import Home_work.Home_work_5.Models.Robot;
import Home_work.Home_work_5.Models.RobotMap;
import Home_work.Home_work_5.View.Views;

public class DeserializeSrvice {
    
    public static void DeserializeMainMenuMessage(String message) throws Exception{
        Scanner sc = new Scanner(System.in);
        if(message.length() == 1){
            switch (message) {
                case "1":
                    System.out.println("Введите размер карты(2 Числа через пробел): ");
                    try {
                        ValidationService.validateCommand("create-map " + sc.nextLine());
                    } catch (Exception e) {
                        throw e;
                    }
                    break;
                case "2":
                case "3":
                case "4":
                    System.out.println("\u001B[31mНеобходимо создать карту!\u001B[0m");
                    TimeUnit.SECONDS.sleep(2);
                    break;
                case "5":
                    Views.displayCommands();
                    TimeUnit.SECONDS.sleep(5);
                    break;
                case "6":
                    System.exit(0);
                    break;
            }
        }
        else{
            try {
                ValidationService.validateCommand(message);
            } catch (Exception e) {
                throw new Exception("Ошибка команды. Попробуйте снова!");
            }
        }        
    }
    public static void DeserializeSubMenuMessage(String message) throws Exception{
        Scanner sc = new Scanner(System.in);
        if(message.length() == 1){
            switch (message) {
                case "1":
                    System.out.println("Введите точку спавна робота(2 Числа через пробел): ");
                    try {
                        ValidationService.validateCommand("create-robot " + sc.nextLine());
                    } catch (Exception e) {
                        throw e;
                    }
                    break;
                case "2":
                    System.out.println("Введите id робота: ");
                    try {
                        ValidationService.validateCommand("move-robot " + sc.nextLine());
                    } catch (Exception e) {
                        throw e;
                    }
                    break;
                case "3":
                System.out.println("Введите id робота и направление в формате (123 LEFT): ");
                try {
                    ValidationService.validateCommand("change-direction " + sc.nextLine());
                } catch (Exception e) {
                    throw e;
                }
                break;
                case "4":
                    var robots = RobotMap.getRobots();
                    for (Robot robot : robots) {
                        System.out.println(robot);
                    }
                    System.out.println("Для продолжения нажмите Enter");
                    sc.nextLine();
                    break;
                case "5":
                    Views.displayCommands();
                    TimeUnit.SECONDS.sleep(5);
                    break;
                case "6":
                    System.exit(0);
                    break;
            }
        }
        else{
            try {
                ValidationService.validateCommand(message);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
