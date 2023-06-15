package Seminars.Seminar_6;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;
import java.util.concurrent.ThreadLocalRandom;

public class Example_1 {
    /*
     * 1. Напишите метод, который заполнит массив из 1000 элементов случайными
     * цифрами от 0 до 24.
     * 
     * 2. Создайте метод, в который передайте заполненный выше массив и с помощью
     * Set вычислите процент уникальных
     * значений в данном массиве и верните его в виде числа с плавающей запятой.
     * 
     * Для вычисления процента используйте формулу:
     * 
     * процент уникальных чисел = количество уникальных чисел * 100 / общее
     * количество чисел в массиве.
     */

    public static void main(String[] args) {
        int sizeArray = 1000;
        int[] array = new int[sizeArray];
        fillArray(array);

        //System.out.println(Arrays.toString(array));
        System.out.println(uniqueElement(array));
        System.out.println((uniqueElement(array)).size() * 100.0 / sizeArray + "%");

    }

    private static void fillArray(int[] array) {
        for (int i = 0; i < array.length; i++) {
            array[i] = ThreadLocalRandom.current().nextInt(200);
        }
    }

    private static Set uniqueElement(int[] array) {
        Set<Integer> set = new HashSet<>();
        Set<Integer> tempSet = new HashSet<>();
        for (int i = 0; i < array.length; i++) {
            if (set.contains(array[i])) {
                tempSet.add(array[i]);
            } else {
                set.add(array[i]);
            }
        }

        set.removeAll(tempSet);

        return set;
    }
}
