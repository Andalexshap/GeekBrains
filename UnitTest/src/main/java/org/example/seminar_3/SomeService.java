package org.example.seminar_3;

public class SomeService {

    /**
     * 3.1. Метод возвращает Fizz для чисел кратных 3,
     * Buzz для кратных 5, и FizzBuzz для кратных 3 и 5
     * одновременно
     */
    public String fizzBuzz(int i) {
        String result = "";
        if (i % 15 == 0) {
            result = "FizzBuzz";
        } else if (i % 5 == 0) {
            result = "Buzz";
        } else if (i % 3 == 0) {
            result = "Fizz";
        }

        return result; // вместо этого напишите свою реализацию
    }

    /**
     * 3.2. Метод возвращает true для массивов,
     * которые начинаются или заканчиваются 6,
     * и false - если 6 нет ни в начале ни в конце массива
     */
    public boolean firstLast6(int[] nums) {
        return (nums[0] == 6 || nums[nums.length - 1] == 6);
    }


    /**
     * 3.3. Метод подсчета скидки
     */
//    public double calculatingDiscount(double purchaseAmount, int discountAmount) {
//
//        return purchaseAmount;
//    }


    /**
     * 3.4. Метод принимает на вход 3 числа (int a, b, c).
     * Нужно вернуть их сумму. Однако, если одно из значений
     * равно 13,
     * то оно не учитывается в сумме.
     * Так, например, если b равно 13,
     * то считается сумма только a и c.
     */
    public int luckySumm(int a, int b, int c){
        int result = 0;

        if (a != 13) result = result + a;
        if (b != 13) result = result + b;
        if (c != 13) result = result + c;

        return result;
    }

    // 3.5 Анализатор если "хорошее" то настроение хорошее
    // если "плохое"
    public String mood(String str){
        String result = "";
        if (str.contains("хорош")) {
            result = "good";
        } else if (str.contains("плох")) {
            result = "bad";
        } else {
            result = "neutral";
        }

        return result;
    }


}