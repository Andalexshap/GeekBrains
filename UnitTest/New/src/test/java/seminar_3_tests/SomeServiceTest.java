package seminar_3_tests;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import static org.junit.jupiter.api.Assertions.*;

import org.example.seminar_3.SomeService;

class SomeServiceTest {

    SomeService ss;
    // 3.1.

    void multipleThreeNotFiveReturnsFizz(int n) {
        // assertEquals...
    }

    @BeforeEach
    void testinit() {
        ss = new SomeService();
    }

    // 3.1

    @ParameterizedTest
    @ValueSource(ints = {4, 8, 14, 26})
    void fizzBuzzModFour(int i) {
        assertEquals("", ss.fizzBuzz(i));
    }

    @ParameterizedTest
    @ValueSource(ints = {3, 6, 9, 33})
    void fizzBuzzModThree(int i) {
        assertEquals("Fizz", ss.fizzBuzz(i));
    }

    @ParameterizedTest
    @ValueSource(ints = {5, 10, 25, 145})
    void fizzBuzzModFive(int i) {
        assertEquals("Buzz", ss.fizzBuzz(i));
    }

    @ParameterizedTest
    @ValueSource(ints = {15, 45, 150, 1515})
    void fizzBuzzModThreeFive(int i) {
        assertEquals("FizzBuzz", ss.fizzBuzz(i));
    }

    // 3.2
    int[] nums1 = {6, 4, 1, 3, 5, 7, 2};
    int[] nums2 = {2, 4, 1, 3, 5, 7, 6};
    int[] nums3 = {2, 4, 1, 3, 5, 7, 2};

    @Test
    void firstLast6True1() {
        assertTrue(ss.firstLast6(nums1));
    }

    @Test
    void firstLast6True2() {
        assertTrue(ss.firstLast6(nums2));
    }

    @Test
    void firstLast6False() {
        assertFalse(ss.firstLast6(nums3));
    }

    // 3.4

    @Test
    void notThirteenA(){
        assertEquals(17, ss.luckySumm(13 , 5, 12));
    }

    @Test
    void notThirteeB(){
        assertEquals(17, ss.luckySumm(5 , 13, 12));
    }

    @Test
    void notThirteenC(){
        assertEquals(17, ss.luckySumm(12 , 5, 13));
    }

    @Test
    void moodGood(){
        assertEquals("good", ss.mood("У меня хорошее настроение"));
    }

    @Test
    void moodBad(){
        assertEquals("bad", ss.mood("У меня плохое настроение"));
    }

    @Test
    void moodNeutral(){
        assertEquals("neutral", ss.mood("У меня  настроение"));
    }


}
