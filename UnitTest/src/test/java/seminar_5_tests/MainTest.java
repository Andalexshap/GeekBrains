package seminar_5_tests;

import org.example.seminar_5.number.MaxNumberModule;
import org.example.seminar_5.number.RandomNumberModule;
import org.example.seminar_5.user.UserRepository;
import org.example.seminar_5.user.UserService;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

import java.util.Arrays;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.anyInt;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class MainTest {
    //5.1.
    @Test
    void testRandomNumberModule(){
        List<Integer> integerList = Arrays.asList(1,3,2,5,6);
        RandomNumberModule randomNumberModule = mock(RandomNumberModule.class);

        when(randomNumberModule.randomIntegerList(anyInt())).thenReturn(integerList);

        assertEquals(integerList, randomNumberModule.randomIntegerList(7));
    }

    @Test
    void testMaxNumberModule(){
        List<Integer> integerList = Arrays.asList(1,3,2,5,6);
        MaxNumberModule maxNumberModule = mock(MaxNumberModule.class);

        when(maxNumberModule.maxNumber(integerList)).thenReturn(6);

        assertEquals(6, maxNumberModule.maxNumber(integerList));
    }

    @Test
    void testFullNumberModule(){
        List<Integer> integerList = Arrays.asList(1,3,2,5,6);
        RandomNumberModule randomNumberModule = mock(RandomNumberModule.class);
        MaxNumberModule maxNumberModule = new MaxNumberModule();

        when(randomNumberModule.randomIntegerList(anyInt())).thenReturn(integerList);
        List<Integer> result = randomNumberModule.randomIntegerList(7);

        assertEquals(6, maxNumberModule.maxNumber(result));
    }


    //5.2.
    @Test
    void testUserService(){
        UserRepository userRepository = new UserRepository();
        UserService userService = new UserService(userRepository);

        assertEquals(userRepository.getUserById(3), userService.getUserName(3));
    }


    //5.3.

    // 5.4.
    @Test
    void testSeleniumURL() {
        WebDriver webDriver = new ChromeDriver();
        webDriver.get("https://google.com");
        WebElement searchBox = webDriver.findElement(By.name("q"));
        searchBox.sendKeys("Selenium");
        searchBox.submit();
        webDriver.findElement(By.xpath("//*[text() = 'https://www.selenium.dev']"));        webDriver.quit();
    }
}