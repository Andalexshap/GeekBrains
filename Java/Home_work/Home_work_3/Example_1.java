package Home_work.Home_work_3;

import java.util.ArrayList;
import java.util.Random;

public class Example_1 {
    public static void main(String[] args) {
    //1. Пусть дан произвольный список целых чисел, удалить из него четные числа 
    //(в языке уже есть что-то готовое для этого)  

    ArrayList<Integer> ints = CreateRandomIntArrayList(20, -1000, 1000);
    PrintList("Заданный массив: ", ints);
    ArrayList<Integer> oddInts = DeleteEvenvaluesFromList(ints);
    PrintList("Удаление четных чисел, самописным методом: ", oddInts);

    ints.removeIf(n -> (n % 2 == 0));
    PrintList("Удаление четных чисел, встроенным методом: ", oddInts);    
}

public static ArrayList<Integer> CreateRandomIntArrayList(int size, int minValue, int maxvalue) {
    Random rnd = new Random();
    ArrayList<Integer> randomList =  new ArrayList<>(size);
    for (int i = 0; i < size; i++) {
        randomList.add(rnd.nextInt(minValue, maxvalue + 1));
    }
    return randomList;
}

private static void PrintList(String message, ArrayList<Integer> someList){
    System.out.println(message + someList.toString());
}

private static ArrayList<Integer> DeleteEvenvaluesFromList(ArrayList<Integer> someList){
    ArrayList<Integer> oddInts = new ArrayList<Integer>();
    for (Integer value : someList) {
        if(value % 2 == 0)
        oddInts.add(value);        
    }

    return oddInts;
}
}
