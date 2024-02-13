package seminar_4_tests.message;


import org.example.seminar_4.message.MessageService;
import org.example.seminar_4.message.NotificationService;
import org.junit.jupiter.api.Test;

import static org.mockito.Mockito.*;

class NotificationServiceTest {
    @Test
    void testMessage(){
        MessageService messageService = mock(MessageService.class);

        NotificationService notificationService = new NotificationService(messageService);
        notificationService.sendNotification("Hello World", "user");

        verify(messageService, times(1)).sendMessage("Hello World", "user");
    }
}