package Seminars.Seminar_1;

//import java.util.Random;

public class Example_1 {
    public static void main(String[] args) {
        //Random r = new Random();
        //inr random = r.nextInt(100);
        //int[] array = { 1, 1, 0, 1, 1, 1 };
        print(new int[] { 1, 1, 0, 1, 1, 1 }); // 3
        print(new int[] { 0, 1, 1, 1, 1, 1 }); // 5
        print(new int[] { 1, 0, 0, 1, 0, 1 }); // 1
        print(new int[] { 1, 1, 0, 1, 0, 1 }); // 2
        print(new int[] { 1, 1, 1, 0, 1, 1 }); // 3

    }

    private static void print(int[] arr) {
        int count = 0;
        int temp = 0;
        for (int i = 0; i < arr.length; i++) {
            if (arr[i] == 1) temp++;
            else {
                if (temp > count) {
                    count = temp;
                }
                temp = 0;
            }
        }
        if (temp > count) count = temp;
        System.out.println(count);
    }
}