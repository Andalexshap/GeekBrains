package Home_work.Home_work_2.Models;

import Home_work.Home_work_2.Interfaces.Attack;
import Home_work.Home_work_2.Interfaces.GetDamage;
import Home_work.Home_work_2.Interfaces.HasHealthPoint;
import Home_work.Home_work_2.Interfaces.Tiredness;

public class Warrior implements HasHealthPoint, Tiredness, Attack {
    private int damage;
    private final int maxHealthPoint;
    private int currentHealthPoint;
    private final int maxTiredness;
    private int currentTiredness;

    public Warrior(int maxHealthPoint, int currentHealthPoint, int maxTiredness, int currentTiredness) {
        this.damage = 20;
        this.maxHealthPoint = maxHealthPoint;
        this.currentHealthPoint = currentHealthPoint;
        this.maxTiredness = maxTiredness;
        this.currentTiredness = currentTiredness;
        recoveryEnergy();

    }

    public Warrior(int maxHealthPoint, int currentHealthPoint) {
        this(maxHealthPoint, currentHealthPoint, 100, 100);
    }

    public Warrior(int maxHealthPoint) {
        this(maxHealthPoint, maxHealthPoint);
    }

    public Warrior() {
        this(100);
    }

    @Override
    public int getMaxEnergy() {
        return maxTiredness;
    }

    @Override
    public int getCurrentEnergy() {
        return currentTiredness;
    }

    @Override
    public void setCurrentEnergy(int value) {
        this.currentTiredness -= value;
    }

    @Override
    public void recoveryEnergy() {
        var thread = new Thread(() -> {
            while (true) {
                if (currentTiredness < maxTiredness) {
                    currentTiredness += 10;
                    System.out.println("Энергия " + Warrior.class.getSimpleName() + " увеличина на 10 очков");
                    System.out.println();
                }
                try {
                    Thread.sleep(7 * 1000L);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
        });
        thread.setDaemon(true);
        thread.start();
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
    public void attack(Object object) {
        if (this.currentTiredness < 20) {
            System.out.println("Игрок" + Warrior.class.getSimpleName() + "пропускает ход");
            System.out.println();

            return;
        }
        if (object instanceof GetDamage) {
            GetDamage building = (GetDamage) object;
            building.getDamage(this.damage);
        }
        System.out.println("Warior наносит " + object.getClass().getSimpleName() + " " + damage + " урона ");
        System.out.println();

        this.currentTiredness -= 20;
        System.out.println("Выносливость " + Warrior.class.getSimpleName() + " снижена на 20 очков");
        System.out.println();
    }

}
