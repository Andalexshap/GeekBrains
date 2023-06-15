package Seminars.Seminar_4;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class Example_2 {
    public static void main(String[] args) {
        /** 
        Реализовать консольное приложение, которое:

        1. Принимает от пользователя и “запоминает” строки.
        2. Если введено print, выводит строки так, чтобы последняя введенная была первой в списке, а первая - последней.
        3. Если введено revert, удаляет предыдущую введенную строку из памяти.
        */
        // foo
        // bar
        // buzz
        // print -> [buzz, bar, foo]
        // revert
        // print -> [bar, foo]

        Scanner in = new Scanner(System.in);
        Deque<String> queue = new ArrayDeque<String>();
        
        boolean run = true;
        
        while(run){
            String word = in.nextLine();
            if(word.toLowerCase().equals("print")){
                System.out.println(queue.toString());
            }
            else if(word.toLowerCase().equals("revert")){
                queue.pollFirst();
            }
            else if(word.toLowerCase().equals("exit")){
                run = false;
            }
            else{
                queue.addFirst(word);
            }
        }
        in.close();
    }
}
