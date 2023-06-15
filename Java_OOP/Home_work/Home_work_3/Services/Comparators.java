package Home_work.Home_work_3.Services;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

import Home_work.Home_work_3.Models.Laptop;

public class Comparators {
    private static ArrayList<String> alphabet = new ArrayList<String>(
            Arrays.asList("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".split("")));

    public static class NameComparator implements Comparator<Laptop> {

        @Override
        public int compare(Laptop o1, Laptop o2) {
            int count = Math.min(o1.manufacturer.length(), o2.manufacturer.length());
            for (int i = 0; i < count; i++) {
                int tmp = alphabet.indexOf((o1.manufacturer.split("")[i]).toUpperCase())
                        - alphabet.indexOf((o2.manufacturer.split("")[i]).toUpperCase());
                if (tmp != 0) {
                    return tmp;
                }
            }
            return 0;
        }
    }

    public static class ModelComparator implements Comparator<Laptop> {

        @Override
        public int compare(Laptop o1, Laptop o2) {
            int count = Math.min(o1.model.length(), o2.model.length());
            for (int i = 0; i < count; i++) {
                int tmp = alphabet.indexOf((o1.model.split("")[i]).toUpperCase())
                        - alphabet.indexOf((o2.model.split("")[i]).toUpperCase());
                if (tmp != 0) {
                    return tmp;
                }
            }
            return 0;
        }

    }

    public static class HddComparator implements Comparator<Laptop> {

        @Override
        public int compare(Laptop o1, Laptop o2) {
            return o1.hddSize - o2.hddSize;
        }

    }

    public static class DdrComparator implements Comparator<Laptop> {

        @Override
        public int compare(Laptop o1, Laptop o2) {
            return o1.ddrSize - o2.ddrSize;
        }

    }

    public static class PriceMinMaxComparator implements Comparator<Laptop> {

        @Override
        public int compare(Laptop o1, Laptop o2) {
            return Double.compare(o1.price, o2.price);
        }
    }
    public static class PriceMaxMinComparator implements Comparator<Laptop> {

        @Override
        public int compare(Laptop o1, Laptop o2) {
            return Double.compare(o2.price, o1.price);
        }
    }
}
