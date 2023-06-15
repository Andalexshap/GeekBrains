package Home_work.Home_work_3.Models;

public enum Manufacturer {
    Simens,
    Asus,
    BQ,
    LG,
    Samsumg,
    Aser;

    public static Manufacturer getRandomValue() {
        int random = (int) (Math.random() * Manufacturer.values().length);
        return Manufacturer.values()[random];
     }
     
}
