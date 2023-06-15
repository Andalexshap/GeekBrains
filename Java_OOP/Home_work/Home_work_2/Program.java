package Home_work.Home_work_2;

import Home_work.Home_work_2.Models.Building;
import Home_work.Home_work_2.Models.Warrior;
import Home_work.Home_work_2.Servises.Render;

public class Program {
    /*
     * Представьте, что вы пишете класс Reder, который отвечает за вывод на экран
     * текущего уровня жизней и усталости какого-то объекта.
     * (Подразумеваем, что вывод на экран - это просто печать в консоль)
     * У класса есть 1 метод, который принимает тип Object и делает следующее:
     * 1. Если object типа HasHealthPoint, то выводим его уровень жизни
     * 2. Если object типа Tiredness, то выводим его уровень усталости
     * При этом текст значения должен иметь цвет в соответствии с правилом:
     * BLACK(0, 24), RED(25, 50), GREEN(51-100)
     * 3. Создать несколько классов:
     * 3.1 Здание. Имеет только жизни.
     * 3.2 Персноаж. Имеет и жизни, и усталость
     */
    public static void main(String[] args) {
        Building citadel = new Building(200, 100);
        Warrior warrior = new Warrior(100, 80);

        Render render = new Render("#", 20, 60);
        while (citadel.getCurrentHealthPoint() > 0) {
            render.render(citadel);
            render.render(warrior);

            warrior.attack(citadel);
            try {
                Thread.sleep(3 * 1000L);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
        }

    }
}
