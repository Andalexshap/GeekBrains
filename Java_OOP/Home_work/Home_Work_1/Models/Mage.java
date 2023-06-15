package Home_work.Home_Work_1.Models;

import java.util.concurrent.TimeUnit;

/*
 * Класс Mage 
 * Cреднее здоровье и магическая атака, которая игнорирует броню противника
 * Дополнительное поле mana.
 */
public class Mage extends Player {
    private double mana;

    public Mage(String name) {
        super(name, 100, 50, 0.2f);
        this.mana = 100;
    }

    @Override
    public void attack(Player player) {
        double damageDealt = this.damage * player.calculationOfTheMaximumPossibleDamage();
        if (this.mana >= 20) {
            damageDealt += 50;
            this.mana -= 20;
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
        if (this.mana >= 20) {
                this.mana -= 20;
            return (1 - this.blokingDamage) / 2;
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
            " Мана: " + this.mana;
    }
}