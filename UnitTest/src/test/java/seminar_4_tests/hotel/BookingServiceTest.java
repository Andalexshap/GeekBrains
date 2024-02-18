package seminar_4_tests.hotel;


import org.example.seminar_4.hotel.BookingService;
import org.example.seminar_4.hotel.HotelService;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.mockito.ArgumentMatchers.anyInt;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class BookingServiceTest {
    @Test
    void testBookingRoom(){
        HotelService hotelService = mock(HotelService.class);

        when(hotelService.isRoomAvailable(anyInt())).thenReturn(true);

        BookingService bookingService = new BookingService(hotelService);

        assertTrue(bookingService.bookRoom(404));

    }
}