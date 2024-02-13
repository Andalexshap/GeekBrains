package homework_6_tests;

import org.example.homework_6.ListsCompare;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

/*Используйте Pytest (для Python) или JUnit (для Java) для написания тестов,
которые проверяют правильность работы программы. Тесты должны учитывать
различные сценарии использования вашего приложения.
Используйте pylint (для Python) или Checkstyle (для Java) для проверки качества кода.*/

// Тут негде моки использовать, задание неподходящее
public class ListsCompareTests {
    ListsCompare listsCompare;

    private final List<Integer> listOne = Arrays.asList(2,4,23,7,6);
    private final List<Integer> listTwo = Arrays.asList(1,3,2,51,1);
    private final List<Integer> listNull = new ArrayList<>();

    @BeforeEach
    void testinit() {
        listsCompare = new ListsCompare();
    }

    // Unit test
    @Test
    void UTestAverageWithValues(){
        assertEquals(listsCompare.average(listOne), 8.4);
    }

    // Unit test null
    @Test
    void UTestAverageNull(){
        assertEquals(listsCompare.average(listNull), 0.0);
    }

    // Integration Test
    @Test
    void ITestCompareAverageTwo(){
        assertEquals(listsCompare.compareAverage(listOne, listTwo), "Второй список имеет большее среднее значение");
    }

    // Integration Test
    @Test
    void ITestCompareAverageOne(){
        assertEquals(listsCompare.compareAverage(listTwo, listOne), "Первый список имеет большее среднее значение");
    }

    // Integration Test
    @Test
    void ITestCompareAverageNone(){
        assertEquals(listsCompare.compareAverage(listOne, listOne), "Средние значения равны");
    }
}
