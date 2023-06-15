package Seminars.Seminar_5;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

public class Example_2Var_2 {
    public static void main(String[] args) {
        sortByLenght("Елена, добрый день! Возможно, вы использовали колесо мышки после запуска урока, эти действия могли уменьшить уровень звука в плеере. Если дело не в этом — напишите в техподдержку support@geekbrains.ru, коллеги помогут в решении вопроса.");
    }

    private static void sortByLenght(String text){
        //парсим текст на слова
        //печатаем слова в порядке возрастания длины
        String[] splitText = text.split(" ");
        Map<Integer, List<String>> db = new TreeMap<>();
        for (String string : splitText) {
            List<String> temp = new ArrayList<String>();
            
            if(db.containsKey(string.length())){
                temp = db.get(string.length());
            }
            
            temp.add(string);
            db.putIfAbsent(string.length(), temp);            
        }

        for (var item : db.entrySet()) {
            System.out.printf("[%d: %s]\n", item.getKey(), item.getValue());
        }
    }
}
