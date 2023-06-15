package Home_work.Home_work_1;

import java.util.Arrays;
import java.util.Random;

public class Example {
    public static void main(String[] args) {
        /*
            1. Написать метод, принимающий на вход два целых числа и проверяющий,
            что их сумма лежит в пределах от 10 до 20 (включительно), если да – вернуть true, в противном случае – false.
        */
        System.out.println("1: " + isSumBetween10And20(5, 15)); // true
        System.out.println("1: " + isSumBetween10And20(7, 15)); // false
        
        /*
            2. Метод проверяющий число на четность
        */
        System.out.println("2: " + isPositive(5));
        System.out.println("2: " + isPositive(-5));
        
        /*
            3. Напечатать строку source repeat раз
        */
        printString("abcd", 5); // abcdabcdabcdabcdabcd

        /*
            4. проверить, является ли год високосным. если да - return true
        */
        System.out.println("4: " + isLeapYear(2022));
        System.out.println("4: " + isLeapYear(2020));
        
        /*
            5. Метод должен вернуть массив длины len, каждое значение которого равно initialValue
        */
        int[] array = createArray(10, 5);
        System.out.println("5: " + Arrays.toString(array));

        /*
            6. Найти общий префикс среди слов из одного массива.
        */
        String[] stringArray = {"aaa", "aab", "aa"};
        System.out.println("6: " + findCommonPrefix(stringArray)); // aa
        String[] stringArray2 = {"abc", "bca", "cda"};
        System.out.println("6: " + findCommonPrefix(stringArray2)); // ""

        /*
            7. Задать целочисленный массив, состоящий из элементов 0 и 1.
            * Например: [ 1, 1, 0, 0, 1, 0, 1, 1, 0, 0 ]. 
            * С помощью цикла и условия заменить 0 на 1, 1 на 0;
        */
        array = createRandomArray(10, 0, 1);
        System.out.println("7: Созданный массив" + Arrays.toString(array));
        changeZeroToOneinArray(array);
        System.out.println("7: Инверсный массив" + Arrays.toString(array));

        /*
            8. Задать массив [ 1, 5, 3, 2, 11, 4, 5, 2, 4, 8, 9, 1 ] пройти по нему циклом, 
            и числа меньшие 6 умножить на 2;
        */
        array = createRandomArray(10, 0, 10);
        System.out.println("8: Созданный массив" + Arrays.toString(array));
        multiplyNumbersLessThanSixByTwoinArray(array);
        System.out.println("8: Результат       " + Arrays.toString(array));
        
        /*
            9. Создать квадратный двумерный целочисленный массив (количество строк и столбцов 
            одинаковое), и с помощью цикла(-ов) заполнить его диагональные элементы единицами 
            (можно только одну из диагоналей, если обе сложно). 
            Определить элементы одной из диагоналей можно по следующему принципу: индексы таких 
            элементов равны, то есть [0][0], [1][1], [2][2], …, [n][n];
        */
        var matrix = CreateMatrix(5,5);
        System.out.println("9: Созданная матрица");
        PrintMatrix(matrix);
        System.out.println("9: Заполнение диагоналей");
        fillingDiagonalsMatrix(matrix, 1);
        PrintMatrix(matrix);
         
        /*
            10. Задать одномерный массив и найти в нем минимальный и максимальный элементы ; 
        */
        array = createRandomArray(20, 0, 10);
        System.out.println("10: Созданный массив" + Arrays.toString(array));
        
        System.out.println("10: " + findMinMaxValueInArray(array));
    
    }
    
    
    private static boolean isSumBetween10And20(int a, int b) {
        // проверить, что сумма a и b лежит между 10 и 20
        return a + b <= 20 && a + b >=10 ? true : false; 
    }
    
    private static boolean isPositive(int x) {
        // проверить, что х положительное
        return x > 0? true:false;
    }
    
    private static void printString(String source, int repeat) {
        // напечатать строку source repeat раз
        System.out.println("3: " + source.repeat(repeat));
    }
    
    private static boolean isLeapYear(int year) {
        // проверить, является ли год високосным. если да - return true
      return ( ( ( year % 4 == 0 ) && ( year % 100 != 0 ) ) || ( year % 400 == 0 ) )? true:false;
    }
    
    private static int[] createArray(int len, int initalValue) {
        // должен вернуть массив длины len, каждое значение которого равно initialValue
        int[] arr = new int[len];
        for (int i = 0; i < arr.length; i++) {
            arr[i] = initalValue;
        }
        return arr;
    }
    
    private static String findCommonPrefix(String[] source) {
        // Найти общий префикс среди слов из одного массива.
        if (source.length == 0) return "";
        String prefix = "";
        int min_lenght = source[0].length();
        for (int i = 1; i < source.length; i++) {
            if(source[i].length()<min_lenght) min_lenght = source[i].length();
        }
        int count = 0;
        while(count < min_lenght){
            int temp = 0;
            for (int i = 0; i < source.length-1; i++) {
                String a = source[i];
               // a = a.substring(count, count+1);
               char first = a.charAt(count);
                String b = source[i+1];
                //b = b.substring(count, count+1);
                char second = b.charAt(count);
                //if(a.equals(b))
                if(first == second)
                temp++;
            }
            if(temp == source.length-1) {
                String sumbol = source[1];
                sumbol = sumbol.substring(count, count+1);
                prefix += sumbol;
            }
            else return prefix;
            count++;
        }

        return prefix;
    }

    private static int[] createRandomArray(int size, int min, int max){
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < array.length; i++) {
            array[i] = random.nextInt(min,max+1);
        }
        return array;
    }

    private static int[] changeZeroToOneinArray(int[] array){
        for (int i = 0; i < array.length; i++) {
            if(array[i] == 1) array[i] = 0;
            else array[i] = 1;
        }
        return array;
    }

    private static int[] multiplyNumbersLessThanSixByTwoinArray(int[] array){
        for (int i = 0; i < array.length; i++) {
            if(array[i] < 6) array[i] = array[i] * 2;
        }
        return array;
    }

    private static int[][] CreateMatrix(int lines, int colums){
        int[][] array = new int[lines][colums]; 
        return array;
    }

    private static void PrintMatrix(int[][] matrix){
        for (int i = 0; i < matrix.length; i++) {
            String line = "[ ";
            for (int j = 0; j < matrix.length; j++) {
                line += matrix[i][j];
                line += " ";
            }
            line += "]";
            System.out.println(line);
        }
    }

    private static int[][] fillingDiagonalsMatrix(int[][] matrix, int numbers){
        for (int i = 0; i < matrix.length; i++) {
            matrix[i][i] = numbers;
            matrix[i][matrix.length-i-1] = numbers; 
        }
        return matrix;
    }
    
    private static String findMinMaxValueInArray(int[] array){
        int min = array[0];
        int max = array[1];
        for (int i = 0; i < array.length; i++) {
            if(array[i] < min) min = array[i];
            if(array[i] > max) max = array[i];
        }
        return "Min = " + min + " Max = " + max;
    }
}