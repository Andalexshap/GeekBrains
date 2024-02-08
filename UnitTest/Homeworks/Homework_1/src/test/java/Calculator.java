package test.java;

/**
 * *Задание 1. * В классе Calculator создайте метод calculateDiscount, который принимает сумму покупки и процент
 * скидки и возвращает сумму с учетом скидки. Ваша задача - проверить этот метод с использованием библиотеки AssertJ.
 * Если метод calculateDiscount получает недопустимые аргументы, он должен выбрасывать исключение ArithmeticException.
 * Не забудьте написать тесты для проверки этого поведения.
 */
public class Calculator {
    public static void main(String[] args) {
        float sum = calculateDiscount(115,15);
        System.out.println("Сумма покупки: " + sum);
    }

    public static float calculateDiscount(float sum, int percent){
        assert sum >= 0 : "Сумма не может быть отрицательной";
        assert percent >= 0 : "Скидка не может быть отрицательной";
        if(sum < 0 ){
            throw new ArithmeticException();
        }
        if(percent < 0 ){
            throw new ArithmeticException();
        }
        float result = (sum / 100)  * (100 - percent);
        return result;
    }
}
