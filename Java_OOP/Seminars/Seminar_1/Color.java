package Seminars.Seminar_1;

public enum Color {

    //    RESET("\u001B[0m"),
        GREEN("\u001B[32m"),
        RED("\u001B[31m"),
        BLACK("\u001B[30m");
    
        private final String color;
    
        Color(String color) {
            this.color = color;
        }
    
        public String getColor() {
            return color;
        }
    
        public String paint(String text) {
            return color + text + "\u001B[0m";
        }
    
        /**
         * @param value
         * @return
         */
        public static Color calculate(int value) {
            if (value < 20) {
                return BLACK;
            } else if (value < 60){
                return RED;
            } else if (value <= 100) {
                return GREEN;
            }
    
            throw new IllegalArgumentException("Value must be in range [0, 100]");
        }
    }
    
