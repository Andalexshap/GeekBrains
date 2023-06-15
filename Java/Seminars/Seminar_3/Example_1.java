package Seminars.Seminar_3;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

public class Example_1 {
    public static void main(String[] args) {
       //Создать список рандомных целых чисел от нуля до 100
       //отсортировать список
       // вывести на экран
       Random rnd = new Random();
    //    int n = rnd.nextInt(10); 
    //    System.out.println(n);
        int size = 20;
        
        ArrayList<Integer> myList = new ArrayList<>(size);
        for (int i = 0; i < size; i++) {
            myList.add(rnd.nextInt(10));
        }

        System.out.println("Not sorted List:");
        System.out.println(myList.toString());

        Collections.sort(myList);
        System.out.println("Sorted List:");
        System.out.println(myList.toString());
    }
}
