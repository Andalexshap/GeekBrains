package Home_work.Home_work_2;

import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

public class Example {
    public static void main(String[] args) {
        // 1. Создать метод, который проверяет, является ли строка палиндромом.
        // Палиндром - шалаш
        System.out.println("1. " + isPolondrom("шалаш"));
        // 2. С помощью Java создать файл file.txt, и записать в него слово TEST 100
        // раз.
        // Если уже файл создан, то перезаписываем его.
        Path path = Path.of("Home_work\\Home_work_2\\file.txt");
        String word = "TEST";
        int count = 100;
        if(createFile(path))
        {
            writeInFile(path, word, count, false);
        };
        // 3. Задание 2, но добавление построчно
        Path path_2 = Path.of("Home_work\\Home_work_2\\file_2.txt");
        if(createFile(path_2))
        {
            writeInFile(path_2, word, count, true);
        };

    }

    private static boolean isPolondrom(String str) {
        boolean isPolindrome = true;
        int j = str.length() - 1;
        for (int i = 0; i < str.length(); i++) {
            if (str.charAt(i) != str.charAt(j)) {
                return false;
            }
            j--;
        }
        return isPolindrome;
    }
    private static boolean createFile(Path path){
        boolean isExist = Files.exists(path);
        if(!isExist){
            try {
                Files.createFile(path);
                return true;
            } catch (Exception e) {
                System.out.println(e.getMessage());
                return false;
            }
        }
        return true;
    }

    private static void writeInFile(Path path, String word, int count, boolean variant){
        try(FileWriter fw = new FileWriter(path.toString())) {
            String temp = "";
            for (int i = 0; i < count; i++) {
                if(!variant) temp += word;
                else {
                    temp += word;
                    if(i != count-1){
                        temp += "\n";          
                    }
                }
            }
            fw.write(temp);
            
        } catch (IOException e) {
           System.out.println(e.getMessage());
        }
    }
}
