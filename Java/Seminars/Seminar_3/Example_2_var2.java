package Seminars.Seminar_3;

import java.util.ArrayList;
import java.util.List;

public class Example_2_var2 {
    /**
 * Заполнить список любыми строкам в произвольном порядке с повторениями.
 * Вывести название каждой планеты и количество его повторений в списке.
    */
   public static void main(String[] args) {
    ArrayList<String> data = new ArrayList<String>(List.of(
    "Андрей", 
    "Василий", 
    "Женя",
    "Василий",
    "Василий",
    "Женя",
    "Женя",
    "Женя"));

   ArrayList<String> names = new ArrayList<>();
   for (int i = 0; i < data.size(); i++) {
      int count = 0;
      String name = data.get(i);
      if(!names.contains(name)){
         names.add(name);
         for (String value : data) {
            if(value.equals(name)){
               count++;
            }
         }
   
         System.out.print("Имя " + name + " встречается " + count + "раз(а)" + "\n");
      }
   }     
}
}
