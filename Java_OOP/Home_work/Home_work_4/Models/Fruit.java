package Home_work.Home_work_4.Models;

public class Fruit {

    private final int weight;

    public Fruit(int weight) {
        this.weight = weight;
    }

    public int getWeight() {
        return weight;
    }

    @Override
    public String toString() {
        return  "Фрукт: " + this.getClass().getSimpleName() + ", Вес: " + weight;
    }
}
