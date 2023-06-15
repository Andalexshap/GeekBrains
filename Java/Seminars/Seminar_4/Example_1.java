package Seminars.Seminar_4;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Random;

public class Example_1 {
    public static void main(String[] args) {
       Random rnd = new Random();
       int size = 2000000;
       
       long arrayListTime = 0;
       long linkedListTime = 0;
       
       ArrayList<Integer> arrayList = new ArrayList<>();
       LinkedList<Integer> linkedList = new LinkedList<>();

       long start = System.currentTimeMillis();
       for (int i = 0; i < size; i++) {
            arrayList.add(rnd.nextInt(100));        
       }
       long end = System.currentTimeMillis();
       arrayListTime = end - start;

       start = System.currentTimeMillis();
       for (int i = 0; i < size; i++) {
            linkedList.add(rnd.nextInt(100));        
       }
       end = System.currentTimeMillis();
       linkedListTime = end - start;

       System.out.println("Время заполнения ArrayList: " + arrayListTime);
       System.out.println("Время заполнения LinkedList: " + linkedListTime);

    }
}
