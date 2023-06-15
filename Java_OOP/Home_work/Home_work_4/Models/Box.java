package Home_work.Home_work_4.Models;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class Box<T extends Fruit> implements Iterable<T> {
    private int weight;
    private List<T> fruitList = new ArrayList<>();

    public void add(T fruit) {
        fruitList.add(fruit);
        weight += fruit.getWeight();
    }

    public int getWeight() {
        return weight;
    }

    public void moveTo(Box<? super T> target) {
        for (T fruit : fruitList) {
            target.add(fruit);
          }
          fruitList.clear();
          weight = 0;
    }

    @Override
    public Iterator<T> iterator() {
        return new Iterator<T>() {
            private int cursor = 0;

            @Override
            public boolean hasNext() {
                return cursor < fruitList.size();
            }

            @Override
            public T next() {
                return fruitList.get(cursor++);
            }
            
        };
    }

}
