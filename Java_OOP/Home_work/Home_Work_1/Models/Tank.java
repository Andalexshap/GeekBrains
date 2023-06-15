package Home_work.Home_Work_1.Models;

import java.util.concurrent.TimeUnit;

/*
 * Класс Tank 
 * Увевеличенное максимальное здоровье и броня, которая блокирует часть урона.
 * Дополнительное поле armor.
 */
public class Tank extends Player {
    private double armor;

    public Tank(String name) {
        super(name, 150.0, 30.0, 0.4f);
        this.armor = 50;
    }

    @Override
    public void attack(Player player) {
        double damageDealt = this.damage * player.calculationOfTheMaximumPossibleDamage();
        if (damageDealt < 0) {
            damageDealt = 0;
        }
        if(player.hp<damageDealt){
            player.hp = 0;
        }else{
            player.hp -= damageDealt;
        }
        System.out.println("Игрок " + this.name + " наносит игроку " + player.getName()+ " " + Math.ceil(damageDealt) + " урона");
        System.out.println("Остаток здоровья у игрока " + player.getName() + ": " + Math.ceil(player.getHp()) + " единиц");
        try {
            TimeUnit.SECONDS.sleep(1);            
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        } 
        if (player.hp <= 0) {
            player.isAlive = false;
        }
    }

    @Override
    public double calculationOfTheMaximumPossibleDamage(){
        if (this.armor >= 10) {
                this.armor -= 10;
            return (1 - this.blokingDamage) - 0.1f;
        }
        return (1 - this.blokingDamage);
    }

    @Override
    public String toString() {
        return "ID: " + this.id + 
            " Игрок: " + this.name + 
            " Здоровье: " + this.hp + 
            " Атака: " + this.damage + 
            " Блокировка атаки " + this.blokingDamage + 
            " Броня: " + this.armor;
    }
}
