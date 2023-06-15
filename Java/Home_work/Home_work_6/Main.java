package Home_work.Home_work_6;

import Home_work.Home_work_6.Models.Cat;
import Home_work.Home_work_6.Models.Plate;

// ДЗ:
// while (true) -> while (!plate.isEmpty())
// 1. Создать массив котов. Пусть все коты из массива по очереди едят из одной тарелки.
// В конце каждого цикла мы досыпаем в тарелку еду.
// Для досыпания еды сделать метод increaseFood в классе Plate.
// 2. Поменять поле satiety у кота с boolean на int.
// Допустим у кота апптит 10, сытность 3. Значит кот захочет поесть 7 единиц.
// 3. * Доработать поток thread в классе Cat, чтобы он каждую секунду уменьшал сытость кота на 1.
public class Main {
    public static void main(String[] args) {
        Plate plate = new Plate(200);
        
        Cat[] cats = new Cat[]{
        new Cat("Barsik"),
        new Cat("Murzik"),
        new Cat("Vasilii"),
        new Cat("Matroskin"),
        new Cat("Leopold")};

        for (Cat cat : cats) {
            System.out.println(cat);
        }

        while(plate.food !=0){
            for (Cat cat : cats) {
                cat.eat(plate);
                System.out.println("В тарелке осталось " + plate.food + " едениц еды");
            }

            if(plate.food < 50){
                plate.increaseFood();
            }
            try {
                Thread.sleep(5000);
                
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
            System.out.println("__________________________________");
        }




    }
}
