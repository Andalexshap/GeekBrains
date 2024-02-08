package Unit tests.Homework_2.test;

import org.junit.jupiter.api.Test;

import seminars.second.hw.Car;
import seminars.second.hw.Motorcycle;

import static org.assertj.core.api.Assertions.assertThat;

/**
 * Написать следующие тесты с использованием JUnit5
 */

public  class VehicleTest {
    Car car = new Car("Honda", "Insight", 2010);
    Motorcycle motorcycle = new Motorcycle("BMW", "GS", 2010);

    /**
     * Проверить, что экземпляр объекта Car также является экземпляром транспортного средства
     * (используя оператор instanceof).
     */
    @Test
    void instanceOf() {
        assertThat(car instanceof Vehicle);
    }

    /**
     * Проверить, что объект Car создается с 4-мя колесами.
     */
    @Test
    void CarWheels() {
        assertThat(car.getNumWheels()).isEqualTo(4);
    }

    /**
     * Проверить, что объект Motorcycle создается с 2-мя колесами.
     */
    @Test
    void MotorcycleWheels() {
        assertThat(motorcycle.getNumWheels()).isEqualTo(2);
    }

    /**
     * Проверить, что объект Car развивает скорость 60 в режиме тестового вождения (используя метод testDrive()).
     */
    @Test
    void testDriveCar() {
        car.testDrive();
        assertThat(car.getSpeed()).isEqualTo(60);
    }

    /**
     * Проверить, что объект Motorcycle развивает скорость 75 в режиме тестового вождения (используя метод testDrive()).
     */
    @Test
    void testDriveMotorcycle() {
        motorcycle.testDrive();
        assertThat(motorcycle.getSpeed()).isEqualTo(75);
    }

    /**
     * Проверить, что в режиме парковки (сначала testDrive, потом park, т.е. эмуляция движения транспорта)
     * машина останавливается (speed = 0).
     */
    @Test
    void parkCar() {
        car.testDrive();
        car.park();
        assertThat(car.getSpeed()).isEqualTo(0);
    }

    /**
     * Проверить, что в режиме парковки (сначала testDrive, потом park, т.е. эмуляция движения транспорта) мотоцикл останавливается (speed = 0).
     */
    @Test
    void parkMotorcycle() {
        motorcycle.testDrive();
        motorcycle.park();
        assertThat(motorcycle.getSpeed()).isEqualTo(0);
    }
}