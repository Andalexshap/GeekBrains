package org.example.homework_6;

import java.util.ArrayList;
import java.util.List;

/*Задание 1. Создайте программу на Python или Java, которая принимает два списка чисел и выполняет следующие действия:
        a. Рассчитывает среднее значение каждого списка.
        b. Сравнивает эти средние значения и выводит соответствующее сообщение:
        - ""Первый список имеет большее среднее значение"", если среднее значение первого списка больше.
        - ""Второй список имеет большее среднее значение"", если среднее значение второго списка больше.
        - ""Средние значения равны"", если средние значения списков равны.*/
public class ListsCompare {
    public double average(List<Integer> request) {
        return request.stream()
                .mapToDouble(d -> d)
                .average()
                .orElse(0.0);
    }

    public String compareAverage(List<Integer> listOne, List<Integer> listTwo) {
        double resultListOne = average(listOne);
        double resultListTwo = average(listTwo);

        if (resultListTwo > resultListOne) {
            return "Второй список имеет большее среднее значение";
        } else if (resultListTwo < resultListOne) {
            return "Первый список имеет большее среднее значение";
        } else {
            return "Средние значения равны";
        }
    }
}
