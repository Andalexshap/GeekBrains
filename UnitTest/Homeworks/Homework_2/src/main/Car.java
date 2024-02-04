package Unit tests.Homework_2.main;

/**
 * Класс ""Car"" расширяет ""Vehicle"" и реализует его абстрактные методы. При создании объекта ""Car"", число колес
 * устанавливается в 4, а скорость в 0. В методе ""testDrive()"" скорость устанавливается на 60, а в методе
 * ""park()"" - обратно в 0.
 */
public class Car extends Vehicle{

    public Car(String company, String model, int yearRelease) {
        super(company, model, yearRelease, 4, 0);
    }

    @Override
    public void testDrive() {
        this.setSpeed(60);
    }

    @Override
    public void park() {
        this.setSpeed(0);
    }
}
