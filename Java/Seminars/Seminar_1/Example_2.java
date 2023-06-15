package Seminars.Seminar_1;

import java.util.Arrays;

public class Example_2 {
    /**
 * Дан массив nums = [3,2,2,3] и число val = 3.
 * Если в массиве есть числа, равные заданному, нужно перенести эти элементы в конец массива.
 * Таким образом, первые несколько (или все) элементов массива должны быть отличны от заданного, а остальные - равны ему.
 */
public static void main(String[] args) {
    int[] array = {3, 2, 2, 3,5,3};
    swap(array, 3);
    System.out.println(Arrays.toString(array)); // [2, 2, 3, 3]
}

private static void swap(int[] array, int val) {
    for (int i = 0; i < array.length; i++) {
        int count = 1;
        int temp = 0;
        if (array[i] == val)
        {
            while (array[array.length - count] == val  && i < array.length - count){
                count++;
            }
            temp = array[array.length - count];
            array[array.length - count] = array[i];
            array[i] = temp;
            count++;
        }        
    }
}

}
