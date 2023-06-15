package Seminars.Seminar_2;

import java.nio.file.Files;
import java.nio.file.Path;

public class Example_3 {
    public static void main(String[] args) {
        Path file = Path.of("Seminars\\Seminar_2\\file.txt");
        try {
            Files.createFile(file); 
            //Files.delete(file);           
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
