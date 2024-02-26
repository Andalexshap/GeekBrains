package org.example.seminar_5.number;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.stream.Collectors;

public class RandomNumberModule {

    public List<Integer> randomIntegerList(int count){
        Random random = new Random();
        List<Integer> result = new ArrayList<>();

        for (int i = 0; i < count; i++) {
            result.add(random.nextInt());
        }

    return result;
    }
}
