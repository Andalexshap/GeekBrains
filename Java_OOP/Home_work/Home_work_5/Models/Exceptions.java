package Home_work.Home_work_5.Models;

public class Exceptions extends Exception {

    public class PositionException extends Exception {

        public PositionException(String message) {
            super(message);
        }
    
    }

    public class MoveningExeptions extends Exception {
        public MoveningExeptions(String message) {
            super(message);
        }

    }

    public class CreateException extends Exception {
        public CreateException(String message) {
            super(message);
        }
    }
}
