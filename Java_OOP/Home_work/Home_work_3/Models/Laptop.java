package Home_work.Home_work_3.Models;

public class Laptop implements Comparable<Laptop> {
    private static long counterId = 1;
    public long id;
    public String manufacturer;
    public String model;
    public int hddSize;
    public int ddrSize;
    public double price;
    private final static int defaultHddSize = 512;
    private final static int defaultDdrSize = 8;
    private final static int defaultPrice = 999;

    public Laptop(String manufacturer, String model, int hddSize, int ddrSize, double price) {
        this.id = counterId++;
        this.manufacturer = manufacturer;
        this.model = model;
        this.hddSize = hddSize;
        this.ddrSize = ddrSize;
        this.price = price;
    }

    public Laptop(String manufacturer, String model, double price) {
        this(manufacturer, model, defaultHddSize, defaultDdrSize, defaultPrice);
    }

    @Override
    public String toString() {
        return manufacturer + " " + model + " " + hddSize + " " + ddrSize + " " + price + " ";
    }

    @Override
    public int compareTo(Laptop o) {
        if (price > o.price) {
            return 1;
        } else if (price == o.price) {
            if (hddSize > o.hddSize) {
                return 1;
            } else if (hddSize == o.hddSize) {
                if (ddrSize > o.ddrSize) {
                    return 1;
                } else if (ddrSize == o.ddrSize) {
                    return 0;
                }
                return -1;
            }
            return -1;
        }
        return -1;
    }
}
