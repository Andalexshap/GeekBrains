package homework_4_tests;

import org.example.seminar_4.book.Book;
import org.example.seminar_4.book.BookRepository;
import org.example.seminar_4.book.BookService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class BookServiceTest {
    // У вас есть класс BookService, который использует интерфейс BookRepository для получения информации
    // о книгах из базы данных. Ваша задача написать unit-тесты для BookService,
    // используя Mockito для создания мок-объекта BookRepository
    BookRepository bookRepository;
    BookService bookService;

    @BeforeEach
    void testinit() {
        bookRepository = mock(BookRepository.class);
        bookService = new BookService(bookRepository);
    }

    @Test
    void testBookServiceAll(){
        List<Book> fakeData = new ArrayList<>();
        fakeData.add(new Book("1","Sherlock", "Doyle"));
        fakeData.add(new Book("2","Titan", "Dreiser"));

        when(bookRepository.findAll()).thenReturn(fakeData);

        assertEquals(fakeData, bookService.findAllBooks());
    }

    @Test
    void testBookServiceId(){
        List<Book> fakeData = new ArrayList<>();
        fakeData.add(new Book("1","Sherlock", "Doyle"));
        fakeData.add(new Book("2","Titan", "Dreiser"));

        when(bookRepository.findById(anyString())).thenReturn(fakeData.get(1));

        assertEquals(fakeData.get(1), bookService.findBookById("2"));
    }
}
