package Home_work.Home_work_2.Models;

import Home_work.Home_work_2.Interfaces.GetDamage;
import Home_work.Home_work_2.Interfaces.HasHealthPoint;
import Home_work.Home_work_2.Interfaces.Treatment;

public class Building implements HasHealthPoint, Treatment, GetDamage {
    private final int maxHealthPoint;
    private int currentHealthPoint;

    public Building(int maxHealthPoint, int currentHealthPoint) {
        this.maxHealthPoint = maxHealthPoint;
        this.currentHealthPoint = currentHealthPoint;
        treatment();
    }

    @Override
    public int getMaxHealthPoint() {
        return maxHealthPoint;
    }

    @Override
    public int getCurrentHealthPoint() {
        return currentHealthPoint;
    }

    @Override
    public void treatment() {
        var thread = new Thread(() -> {
            while (true) {
                try {
                    Thread.sleep(10 * 1000L);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
                if (currentHealthPoint + 50 < maxHealthPoint) {
                    currentHealthPoint += 50;
                    System.out.println("Здоровье " + Building.class.getSimpleName() + " увеличено на 100 едениц");
                }
            }
        });
        thread.setDaemon(true);
        thread.start();
    }

    @Override
    public void getDamage(int damage) {
        this.currentHealthPoint -= damage;
    }

}
