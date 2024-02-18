package seminar_4_tests.weather;


import org.example.seminar_4.weather.WeatherReporter;
import org.example.seminar_4.weather.WeatherService;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class WeatherReporterTest {

    @Test
    void testWeather(){
        WeatherService weatherService = mock(WeatherService.class);
        int currentTemperature = 25;
        when(weatherService.getCurrentTemperature()).thenReturn(currentTemperature);

        WeatherReporter weatherReporter = new WeatherReporter(weatherService);
        assertEquals("Текущая температура: 25 градусов.", weatherReporter.generateReport());
    }


}