package Home_work.Home_work_3;

import java.util.ArrayList;
import java.util.Collections;

import Home_work.Home_work_3.Models.Laptop;
import Home_work.Home_work_3.Services.AvtoGeneration;
import Home_work.Home_work_3.Services.Output;
import Home_work.Home_work_3.Services.Comparators.*;

public class Program {
    public static void main(String[] args) {
        // Создать класс Notebook с полями: 
        // 1. Стоимость (int)
        // 2. Оперативная память (int)
        // Нагенерить объектов этого класса, создать список и отсортировать его в трех вариантах:
        // 1. По возрастанию цены
        // 2. По убыванию цены
        // 3. По оперативке по убыванию. Если оперативки равны - по убыванию цены.
        // 4.+ придумать свои параметры и отсортировать по ним

        ArrayList<Laptop> laptopList = AvtoGeneration.createLaptopList(10);
        Output.PrintArray(laptopList);

        Collections.sort(laptopList, new NameComparator());
        Output.PrintArray(laptopList);

        Collections.sort(laptopList, new ModelComparator());
        Output.PrintArray(laptopList);

        Collections.sort(laptopList, new HddComparator());
        Output.PrintArray(laptopList);

        Collections.sort(laptopList, new DdrComparator());
        Output.PrintArray(laptopList);

        Collections.sort(laptopList, new PriceMinMaxComparator());
        Output.PrintArray(laptopList);

        Collections.sort(laptopList, new PriceMaxMinComparator());
        Output.PrintArray(laptopList);
    }
}
