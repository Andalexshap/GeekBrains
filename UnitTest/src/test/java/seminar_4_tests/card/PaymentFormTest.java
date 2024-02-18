package seminar_4_tests.card;

import org.example.seminar_4.card.CreditCard;
import org.example.seminar_4.card.PaymentForm;
import org.junit.jupiter.api.Test;

import static org.mockito.Mockito.*;

class PaymentFormTest {

    /**
     * 4.2. Используя библиотеку Mockito, напишите модульные тесты для проверки функциональности формы оплаты на сайте.
     * * Вместо реальной кредитной карты используйте мок-объект.
     * Создайте класс `CreditCard` с методами `getCardNumber()`, `getCardHolder()`, `getExpiryDate()`, `getCvv()`, `charge(double amount)`.
     * Создайте класс `PaymentForm` с методом `pay(double amount)`.
     * В тестовом классе, создайте мок-объект для класса `CreditCard`.
     * Определите поведение мок-объекта с помощью метода `when()`.
     * Создайте объект класса `PaymentForm`, передайте ему мок-объект в качестве аргумента.
     * Вызовите метод `pay()` и убедитесь, что мок-объект вызывает метод `charge()`
     */

    @Test
    void testCharge(){
        CreditCard card = mock(CreditCard.class);
        when(card.getCardNumber()).thenReturn("1234");
        when(card.getCardHolder()).thenReturn("Ivan Ivanov");
        when(card.getExpiryDate()).thenReturn("12/28");
        when(card.getCvv()).thenReturn("123");

        PaymentForm paymentForm = new PaymentForm(card);
        paymentForm.pay(1000);

        verify(card, times(1)).charge(1000);
    }



}