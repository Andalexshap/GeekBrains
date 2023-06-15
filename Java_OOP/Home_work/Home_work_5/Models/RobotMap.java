package Home_work.Home_work_5.Models;

import java.util.ArrayList;

public class RobotMap {
    
    private static int n;
    private static int m;

    private static boolean isCreated = false;
    private static ArrayList<Robot> robots;

    public static ArrayList<Robot> getRobots() {
        return robots;
    }

    public RobotMap(int n, int m) {
        if (n < 0 || m < 0) {
            throw new IllegalArgumentException("Недопустимые значения размера карты!");
        }
        this.n = n;
        this.m = m;
        this.robots = new ArrayList<Robot>();
        isCreated = true;
    }

    public static boolean isMapCreated(){
        return isCreated;
    }

    public static int[] getRobotMapSize(){
        int[] size = new int[]{n,m};
        return size;
    }

    public static void addRobot(Robot robot){
        
        robots.add(robot);
    }
}
