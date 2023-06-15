package Home_work.Home_work_6.Models;

import java.util.Random;

public class Cat {
    String name;
    int appetite;
    volatile int satiety = new Random().nextInt(0,10);

    public Cat(String name) {
        this(name, new Random().nextInt(10,15));
    }

    public Cat(String name, int appetite) {
        this.name = name;
        this.appetite = appetite;

        new Thread(() -> {
            while(true){
                if(satiety > 1){
                    satiety -= new Random().nextInt(1,satiety);
                }
                try {
                    Thread.sleep(5*1000L);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
        }).start();
    }

    public void eat(Plate plate){
        if(satiety < appetite){
            satiety += plate.decreaseFood(appetite - satiety);
            System.out.println(name + " поел, его сытость = " + satiety + " и аппетит = " + appetite);
        }
    }

    @Override
    public String toString(){
        return name + " {appetite=" + appetite + ", satiety=" + satiety + "}";
    }
}