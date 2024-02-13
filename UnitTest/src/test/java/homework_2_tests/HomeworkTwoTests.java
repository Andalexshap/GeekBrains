package homework_2_tests;

import org.example.homework_2.Car;
import org.example.homework_2.Motorcycle;
import org.example.homework_2.Vehicle;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

class HomeworkTwoTests {
    // Проверить, что экземпляр объекта Car также является экземпляром
    // транспортного средства (используя оператор instanceof).
    @Test
    public void isCarInstanceOfVehicle(){
        Car car = new Car("BMW", "Z3", 2005);
        assertThat(car).isInstanceOf(Vehicle.class);
    }

    // Проверить, что объект Car создается с 4-мя колесами.
    @Test
    public void isCarHaveFourWheels(){
        Car car = new Car("BMW", "Z3", 2005);
        assertThat(car.getNumWheels()).isEqualTo(4);
    }

    // Проверить, что объект Motorcycle создается с 2-мя колесами.
    @Test
    public void isMotoHaveTwoWheels(){
        Motorcycle motorcycle = new Motorcycle("Honda", "CBR 600", 2018);
        assertThat(motorcycle.getNumWheels()).isEqualTo(2);
    }


    // Проверить, что объект Car развивает скорость 60 в режиме
    // тестового вождения (используя метод testDrive()).
    @Test
    public void isCarTestDriveSpeed(){
        Car car = new Car("BMW", "Z3", 2005);
        car.testDrive();
        assertThat(car.getSpeed()).isEqualTo(60);
    }

    // Проверить, что объект Motorcycle развивает
    // скорость 75 в режиме тестового вождения (используя метод testDrive()).
    @Test
    public void isMotoTestDriveSpeed(){
        Motorcycle motorcycle = new Motorcycle("Honda", "CBR 600", 2018);
        motorcycle.testDrive();
        assertThat(motorcycle.getSpeed()).isEqualTo(75);
    }

    // Проверить, что в режиме парковки (сначала testDrive, потом park, т.е. эмуляция движения транспорта)
    // машина останавливается (speed = 0).
    @Test
    public void isCarParkSpeed(){
        Car car = new Car("BMW", "Z3", 2005);
        car.testDrive();
        car.park();
        assertThat(car.getSpeed()).isEqualTo(0);
    }

    // Проверить, что в режиме парковки (сначала testDrive, потом park, т.е. эмуляция движения транспорта)
    // мотоцикл останавливается (speed = 0).
    @Test
    public void isMotoParkSpeed(){
        Motorcycle motorcycle = new Motorcycle("Honda", "CBR 600", 2018);
        motorcycle.testDrive();
        motorcycle.park();
        assertThat(motorcycle.getSpeed()).isEqualTo(0);
    }
}