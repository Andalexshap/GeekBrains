package Program;

import java.time.LocalDate;
import java.util.Calendar;
import java.util.Date;

public abstract class  Animals {

    protected String Name;
    protected LocalDate birthDate;
    protected String animalType;


    public Animals(String name, LocalDate birth_date) {
    }

    public String getName() {
        return Name;
    }

    public LocalDate getBirthDate() {
        return birthDate;
    }
    public abstract void getCommands();

    public  abstract void addCommand(Command command);


}
