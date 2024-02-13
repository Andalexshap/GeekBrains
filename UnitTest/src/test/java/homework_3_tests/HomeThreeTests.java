package homework_3_tests;

import org.example.homework_3.HomeworkThree;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class HomeThreeTests {

    HomeworkThree h3;

    @BeforeEach
    void testinit() {
        h3 = new HomeworkThree();
    }

    // HW 3.1. Нужно покрыть тестами метод на 100%
    // Метод проверяет, является ли целое число записанное в переменную n, чётным (true) либо нечётным (false).
    @Test
    void oddCheckTrue() {
        assertTrue(h3.evenOddNumber(2));
    }

    @Test
    void oddCheckFalse() {
        assertFalse(h3.evenOddNumber(1));
    }


    // HW 3.2. Нужно написать метод который проверяет, попадает ли переданное число в интервал (25;100) и возвращает true, если попадает и false - если нет,
    // покрыть тестами метод на 100%

    @Test
    void numberInTrue() {
        assertTrue(h3.numberInInterval(25));
    }

    @Test
    void numberInFalse() {
        assertFalse(h3.numberInInterval(1));
    }
}
