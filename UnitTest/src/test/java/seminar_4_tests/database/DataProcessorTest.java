package seminar_4_tests.database;


import org.example.seminar_4.database.DataProcessor;
import org.example.seminar_4.database.Database;
import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class DataProcessorTest {

    @Test
    void testDatabase(){
        Database db = mock(Database.class);

        List<String> fakeData = Arrays.asList("1","2","3");
        when(db.query(anyString())).thenReturn(fakeData);

        DataProcessor dataProcessor = new DataProcessor(db);
        List<String> result = dataProcessor.processData("SELECT * FROM data");

        assertEquals(fakeData, result);

    }
}