package Home_work.Home_Work_1.Models;

import java.util.concurrent.TimeUnit;

/*
 * Класс Assassin 
 * Низкое здоровье, но с очень высокая атака, которая игнорирует часть брони противника. 
 * Дополнительное поле dodgeChance.
 */
public class Assassin extends Player {
    private double dodgeChance;

    public Assassin(String name) {
        super(name, 70, 100,0.1f);
        this.dodgeChance = 0.2;
    }

    @Override
    public void attack(Player player) {
        double damageDealt = this.damage * player.calculationOfTheMaximumPossibleDamage();
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
        if (Math.random() < this.dodgeChance) {
            return (1 - this.blokingDamage);
        }        
        return (1 - this.blokingDamage) - dodgeChance;
    }

    @Override
    public String toString() {
        return "ID: " + this.id + 
            " Игрок: " + this.name + 
            " Здоровье: " + this.hp + 
            " Атака: " + this.damage + 
            " Блокировка атаки " + this.blokingDamage + 
            " Шанс увернуться: " + this.dodgeChance;
    }
}