package Home_work.Home_work_2.Servises;

public class TextColor {
    private static final String ANSI_RESET = "\u001B[0m";
    private static final String ANSI_YELLOW = "\u001B[33m";
    private static final String ANSI_RED = "\u001B[31m";
    private static final String ANSI_GREEN = "\u001B[32m";

    static String getColor(String color) {
        switch (color.toLowerCase()) {
            case ("red"):
                return ANSI_RED;
            case ("green"):
                return ANSI_GREEN;
            case ("yellow"):
                return ANSI_YELLOW;
            default:
                return ANSI_RESET;
        }
    }

    static String reset() {
        return ANSI_RESET;
    }
}
