package org.example.homework_3;

public class HomeworkThree {
    // Напишите тесты, покрывающие на 100% метод evenOddNumber,
    // который проверяет, является ли
    // переданное число четным или нечетным:
    public boolean evenOddNumber(int n) {
        return n % 2 == 0;
    }

    // Разработайте и протестируйте метод numberInInterval,
    // который проверяет, попадает ли
    // переданное число в интервал (25;100)
    public boolean numberInInterval(int n) {
        return n > 24 && n < 101;
    }

}
