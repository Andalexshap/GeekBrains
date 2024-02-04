package Unit tests.Homework_2.test;

/**
 * Базовый класс ""Vehicle"" содержит абстрактные методы ""testDrive()"" и ""park()"", а также поля ""company"",
 * ""model"", ""yearRelease"", ""numWheels"" и ""speed"".
 */
public abstract class Vehicle {
    public Vehicle(String company, String model, int yearRelease, int numWheels, int speed) {
        this.company = company;
        this.model = model;
        this.yearRelease = yearRelease;
        this.numWheels = numWheels;
        this.speed = speed;
    }

    public abstract void testDrive();
    public abstract void park();

    private String company;
    private String model;
    private int yearRelease;
    private int numWheels;
    private int speed;


    public int getNumWheels() {
        return numWheels;
    }

    public int getSpeed() {
        return speed;
    }

    public void setSpeed(int speed) {
        this.speed = speed;
    }
}
