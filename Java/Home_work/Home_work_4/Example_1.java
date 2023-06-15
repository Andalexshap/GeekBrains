// Реализовать консольное приложение, которое:

// Принимает от пользователя строку вида
// text~num

// Нужно рассплитить строку по ~, сохранить text в связный список на позицию num.
// Если введено print~num, выводит строку из позиции num в связном списке и удаляет её из списка.

// text~num (например, word~4)
// print~num (распечатать текст)

// word~1
// foo~5
// qwerty~10
// bar~5
// print~10 -> qwerty
// print~1 -> word
// print~2 -> пустая строка или исключение NoSuchElementException
// print~5 -> bar
package Home_work.Home_work_4;

import java.util.ArrayList;
import java.util.Scanner;

public class Example_1 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        ArrayList<String> data = new ArrayList<>();
        boolean isRun = true;

        while (isRun) {
            System.out.print("Введите данные: ");
            String str = input.nextLine();
            if (str.equalsIgnoreCase("exit")) {
                isRun = false;
            } else {
                String[] split = str.split("~");
                if (split.length != 2) {
                    System.out.println("Введите данные формата => text~index");
                    continue;
                }
                String word = split[0];
                int num = 0;
                try {
                    num = Integer.parseInt(split[1]);
                } catch (Exception e) {
                    System.out.println("После знака => ~ <= должно идти число!!!");
                    continue;
                }

                if (word.equalsIgnoreCase("print")) {
                    System.out.println(data.get(num - 1));
                } else {
                    int startIndex = data.size();
                    if (startIndex < num) {
                        for (int i = startIndex; i < num; i++) {
                            if (i != num - 1) {
                                data.add("");
                            } else {
                                data.add(word);
                            }
                        }
                    } else {
                        data.set(num - 1, word);
                    }
                }
            }
        }
        input.close();
    }
}
