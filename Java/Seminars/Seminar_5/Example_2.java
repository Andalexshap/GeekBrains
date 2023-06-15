package Seminars.Seminar_5;

import java.util.Map;
import java.util.TreeMap;

public class Example_2 {
    public static void main(String[] args) {
        sortByLenght("Елена, добрый день! Возможно, вы использовали колесо мышки после запуска урока, эти действия могли уменьшить уровень звука в плеере. Если дело не в этом — напишите в техподдержку support@geekbrains.ru, коллеги помогут в решении вопроса.");
    }

    private static void sortByLenght(String text){
        //парсим текст на слова
        //печатаем слова в порядке возрастания длины
        String[] splitText = text.split(" ");
        Map<Integer, String> db = new TreeMap<>();
        for (String string : splitText) {
            int count = 0;

            while(db.containsKey(string.length() * 100 + count)){
                count++;
            }

            db.putIfAbsent(string.length() * 100 + count, string);
        }

        System.out.println(db);
    }
}
