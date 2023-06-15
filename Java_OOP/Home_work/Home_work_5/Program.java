package Home_work.Home_work_5;

import java.util.Scanner;
import java.util.concurrent.TimeUnit;

import Home_work.Home_work_5.Models.RobotMap;
import Home_work.Home_work_5.Services.DeserializeSrvice;
import Home_work.Home_work_5.View.Views;

public class Program {
    
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        while(true){
            System.out.print("\033[H\033[J");
            if(!RobotMap.isMapCreated()){
                Views.displayMainMenu();
                try {
                    DeserializeSrvice.DeserializeMainMenuMessage(sc.nextLine());                    
                } catch (Exception e) {
                    System.out.println(e.getMessage());
                    System.out.println("Для продолжения Нажмите Enter.");
                    sc.nextLine();
                }
            }else{
                Views.displayMap();
                Views.displaySubMenu();
                try {
                    DeserializeSrvice.DeserializeSubMenuMessage(sc.nextLine());                    
                } catch (Exception e) {
                    System.out.println(e.getMessage());
                    System.out.println("Для продолжения Нажмите Enter.");
                    sc.nextLine();
                }
            }
        }
    }
}
