package Home_work.Home_work_5.View;

import java.util.ArrayList;

import Home_work.Home_work_5.Models.Direction;
import Home_work.Home_work_5.Models.Robot;
import Home_work.Home_work_5.Models.RobotMap;

public class Views { 

    public static void displayMainMenu(){
        System.out.println("1. Создать Карту.\n" +
                           "2. Создать Робота.\n" +
                           "3. Передвинуть Робота.\n" + 
                           "4. Изменить Направление Робота.\n" +
                           "5. Показать команды.\n" +
                           "6. Выход");
    }
    
    public static void displaySubMenu(){
        System.out.println("1. Создать Робота.\n" +
                           "2. Передвинуть Робота.\n" + 
                           "3. Изменить Направление Робота.\n" +
                           "4. Показать Всех роботов \n" + 
                           "5. Показать команды.\n" +
                           "6. Выход");
    }

    public static void displayCommands(){
        System.out.println("Список команд:\n" + 
                           "\tcreate-map N M\n" +
                           "\tcreate-robot x y\n" +
                           "\tmove-robot id\n" + 
                           "\tchange-direction id direction");
    }

    public static void displayMap(){
        ArrayList<Robot> robots = RobotMap.getRobots();
        var sizeMap = RobotMap.getRobotMapSize();
        String[][] graphMap = new String[sizeMap[0]][sizeMap[1]];
       
        for (Robot robot : robots) {
            graphMap[robot.getPosition().getX()-1][robot.getPosition().getY()-1] = characterSelection(robot.getDirection()); 
        }
        for (int i = 0; i < graphMap.length; i++) {
			for (int j = 0; j < graphMap[i].length; j++) {
                if(graphMap[i][j] == null){
                    System.out.print("[ ]");
                } 
                else{
                    System.out.print(graphMap[i][j]);
                }
			}
			System.out.print("\n");
		}

    }

    public static String characterSelection(Direction direction){
        switch (direction) {
            case TOP:
                return "[\u001B[32m\u005e\u001B[0m]";
            case RIGHT:
                return "[\u001B[32m\u003e\u001B[0m]";
            case LEFT:
                return "[\u001B[32m\u003c\u001B[0m]";
            case BOTTOM:
                return "[\u001B[32m\u0076\u001B[0m]"; 
        }
        return null;
    }
    
}
