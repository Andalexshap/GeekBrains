package Home_work.Home_work_5;

import java.util.Deque;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Map;

public class Example_1 {
    public static void main(String[] args) {
        /*
 * Написать метод, определяющую правильность расстановки скобок в выражении.
 * Могут содержаться следующие скобки: ()[]{}<>
 * () -> true
 * []{}((<>)) -> true
 * ) -> false
 * [) -> false
 * []{}(<)> -> false
 */
        System.out.println(isCorrectParentheses("()")); // -> true
        System.out.println(isCorrectParentheses("[]{}((<>))")); // -> true
        System.out.println(isCorrectParentheses(")")); //-> false
        System.out.println(isCorrectParentheses("[)")); //-> false
        System.out.println(isCorrectParentheses("[]{}(<)>")); //-> false
    }
    private static boolean isCorrectParentheses(String parentheses) {
        Map<Character, Character> brackets = new HashMap<>();
    brackets.put(')', '(');
    brackets.put('}', '{');
    brackets.put(']', '[');
    brackets.put('>', '<');

    Deque<Character> stack = new LinkedList<>();
for (char c : parentheses.toCharArray()) {
    if (brackets.containsValue(c)) {
        // одна из открывающих скобок
        stack.push(c);
    } else if (brackets.containsKey(c)) {
        // одна из закрывающих скобок
        if (stack.isEmpty() || stack.pop() != brackets.get(c)) {
            return false;
        }
    }
}
// в конце стек должен быть пустым
return stack.isEmpty();
    }
}
