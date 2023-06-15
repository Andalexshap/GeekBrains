package Home_work.Home_Work_1.Models;

public abstract class Player {
    private static long counterId = 1L;
    protected long id;
    protected String name;
    protected double maxHp;
    protected double hp;
    protected double damage;
    protected float blokingDamage;
    protected boolean isAlive = true;
    protected int team = 0;

    public Player(String name, double maxHp, double damage, float blockingDamage) {
        this.id = counterId++;
        this.name = name;
        this.maxHp = maxHp;
        this.hp = maxHp;
        this.damage = damage;
        this.blokingDamage = blockingDamage;
    }

    public void attack(Player player) {
        double attackDamage = this.damage - player.blokingDamage;
        if (attackDamage < 0) {
            attackDamage = 0;
        }
        player.receiveDamage(attackDamage);
    }
    
    public void receiveDamage(double damage) {
        this.hp -= damage;
        if (this.hp <= 0) {
            this.isAlive = false;
        }
    }

    public double calculationOfTheMaximumPossibleDamage(){
        return 1 - this.blokingDamage;
    }

    @Override
    public String toString() {
        return "ID: " + this.id + 
            " Игрок: " + this.name + 
            " Здоровье: " + this.hp + 
            " Атака: " + this.damage + 
            " Блокировка атаки" + this.blokingDamage;
    }

    public boolean isAlive() {
        return this.isAlive;
    }

    public long getId() {
        return this.id;
    }
    public static long getCounterId() {
        return counterId;
    }

    public String getName() {
        return this.name;
    }

    public double getHp() {
        return this.hp;
    }

    public String getTeam(){
        return String.valueOf(this.team);
    }

    public void setTeam(int team){
        this.team = team;
    }

}
