package homework_1_tests;


import static org.assertj.core.api.Assertions.*;

public class HomeworkOne {
    public static void calculatorDiscount(double purchaseAmount, int discountAmount){
        assertThat(discountAmount > 0).isFalse();

        double discount = purchaseAmount * (double) discountAmount / 100;
        System.out.println(purchaseAmount - discount);
    }
}
