package Lesson_2.Ex006.Interface;

import Lesson_2.Ex006.Document.TextDocument;

public interface Saveable {
    void SaveAs(TextDocument document, String path);
}
