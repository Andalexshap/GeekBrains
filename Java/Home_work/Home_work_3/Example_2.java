package Home_work.Home_work_3;

import java.util.ArrayList;

public class Example_2 {
    public static void main(String[] args) {
        //2. Задан целочисленный список ArrayList. 
        //Найти минимальное, максимальное и среднее арифметическое из этого списка.

        ArrayList<Integer> ints = Example_1.CreateRandomIntArrayList(10, -100, 100);
        int min = FindMinOrMaxValueFromArrayList(ints, "min");
        int max = FindMinOrMaxValueFromArrayList(ints, "max");
        int average =Average(ints);

        System.out.println("Созданный список " + ints.toString());
        System.out.println("Минимальный эелемент: " + min);
        System.out.println("Максимальный эелемент: " + max);
        System.out.println("Среднее значение: " + average);
    }

    private static int FindMinOrMaxValueFromArrayList(ArrayList<Integer> someList, String condition ){
        int value = someList.get(0);
        for (Integer val : someList) {
            switch (condition.toLowerCase()) {
                case "min":
                    if( val < value){
                        value = val;
                    }
                    break;
                case "max":
                    if( val > value){
                        value = val;
                    }
                    break;
                default:
                    break;
            }                    
        }

        return value;
    }

    private static int Average(ArrayList<Integer> someList){
        int average = 0;
        for (Integer value : someList) {
                average += value;
        }

        return average/someList.size();
    }
}
