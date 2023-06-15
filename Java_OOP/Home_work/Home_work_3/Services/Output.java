package Home_work.Home_work_3.Services;

import java.util.ArrayList;

import Home_work.Home_work_3.Models.Laptop;

public class Output {
    public static void PrintArray (ArrayList<Laptop> list){
        String head = "Manyfacture |   Model    | hddSize | ddrSize | Price";
        System.out.println(head);
        for (Laptop laptop : list) {

            System.out.println(laptop.manufacturer + " ".repeat(11 - laptop.manufacturer.length()) + " |" 
                              + " " + laptop.model + " ".repeat(10 - laptop.model.length()) + " |"
                              + " " + " ".repeat(2) + laptop.hddSize + " ".repeat(laptop.hddSize > 999 ? 2 : 3) + "|"
                              + " " + " ".repeat(3) + laptop.ddrSize + " ".repeat(3) + " |"
                              + " " + laptop.price + " ".repeat(2));
        }
        System.out.println();
        System.out.println("=".repeat(head.length()));
        System.out.println();

    }
}
