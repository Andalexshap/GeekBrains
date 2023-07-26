package Program;

public class Counter implements AutoCloseable{

    private int counter;

    public int getCounter() {
        return counter;
    }

    public void setCounter(int counter) {
        this.counter = counter;
    }

    public void add(){
        ++counter;
        System.out.printf("Значение счетчика: %d\n",counter);
    }

    @Override
    public void close() {
        System.out.println("Счетчик закрыт");
    }
}
