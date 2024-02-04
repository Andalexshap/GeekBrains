package Unit tests.Homework_2.main;

/**
 * Класс ""Motorcycle"" также расширяет ""Vehicle"" и реализует его абстрактные методы. При создании объекта
 * ""Motorcycle"", число колес устанавливается в 2, а скорость в 0. В методе ""testDrive()"" скорость устанавливается
 * на 75, а в методе ""park()"" - обратно в 0.
 */
public class Motorcycle extends Vehicle{
    public Motorcycle(String company, String model, int yearRelease) {
        super(company, model, yearRelease, 2, 0);
    }

    @Override
    public void testDrive() {
        this.setSpeed(75);
    }

    @Override
    public void park() {
        this.setSpeed(0);
    }
}
