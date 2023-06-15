package Home_work.Home_work_6.Models;

import java.util.Random;

public class Plate {
    public int food;

    public Plate(int food) {
        this.food = food;
    }

    public int decreaseFood(int foodToDecrease) {
        if (food >= foodToDecrease) {
            int countFood = new Random().nextInt(1, foodToDecrease);
            food = food - countFood;
            return countFood;
        }
        else{
            int countFood = new Random().nextInt(1, food);
            food = food - countFood;
            return countFood;
        }
    }

    public int increaseFood() {
        var upFood = new Random().nextInt(20, 100);
        food += upFood;
        System.out.println("В миску добавили " + upFood + " еды");
        return upFood;
    }

    @Override
    public String toString() {
        return "Plate[" + food + "ед. еды]";
    }
}
