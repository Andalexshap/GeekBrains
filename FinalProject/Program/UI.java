package Program;

public class UI {


    private final Engine engine;


    public UI(Engine engeine) {
        this.engine = engeine;
    }
    public void start(){
        engine.startProgramm();
    }
    public void addNewAnimal(){
        engine.addAnimal();
    }
    public void addNewCommand(){
        engine.addCommand();
    }
    public void showCommands(){
        engine.showCommands();
    }

    }


