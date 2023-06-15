package Home_work.Home_work_3.Services;

import java.util.ArrayList;
import java.util.Random;
import java.util.stream.Stream;

import Home_work.Home_work_3.Models.Laptop;
import Home_work.Home_work_3.Models.Manufacturer;

public class AvtoGeneration {
    private static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".toCharArray();
    private static char[] numbers = "0123456789".toCharArray();
    private static char[] allSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".toCharArray();
    private static Random rnd = new Random();

    public static String generateModel(int countLetter, int countNumber){
        String model = "";
        for (int i = 0; i < countLetter; i++) {
            model += alphabet[rnd.nextInt(alphabet.length)];
        }
        for (int i = 0; i < countNumber; i++) {
            model += numbers[rnd.nextInt(numbers.length)];
        }

        return model;
    }

    public static String generateModel(int lenghtWord){
        String model = "";
        for (int i = 0; i < lenghtWord; i++) {
            var index = rnd.nextInt(allSymbols.length);
            model += allSymbols[index];
        }
        return model;
    }

    public static String getRandomManufacturer (){
        return Manufacturer.getRandomValue().toString();        

    }

    public static ArrayList<Laptop> createLaptopList(int count){
        ArrayList<Laptop> list = new ArrayList<>();
        
        for (int i = 0; i < count; i++) {
            String manufacturer = getRandomManufacturer();
            String model = generateModel(10); 
            int hddSize = (int)Math.pow(2, rnd.nextInt(1,4)) *128;
            int ddrSize = rnd.nextInt(2,9);
            double price = rnd.nextInt(20,40)*31;

            Laptop laptop = new Laptop(manufacturer, model, hddSize, ddrSize, price);
            list.add(laptop);
        }
        return list;
    }

}
