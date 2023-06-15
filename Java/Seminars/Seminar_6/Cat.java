package Seminars.Seminar_6;

public class Cat {
    String Name;
    int Appetit;
    boolean Satiety;
    
    public Cat(String name) {
        this(name, 10);
    }

    public Cat(String name, int appetit) {
        Name = name;
        Appetit = appetit;
        Satiety = false;
    }

    
}
