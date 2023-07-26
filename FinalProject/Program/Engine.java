package Program;

import java.time.LocalDate;
import java.util.Scanner;

public class Engine implements Controller {


    private Animals animal;
    private Counter counter;
    private PetsBase petsBase = new PetsBase();
    private PackBase packsBase = new PackBase();


    static final Scanner scanner = new Scanner(System.in);
    @Override
    public void startProgramm() {
        System.out.println("Программа запущена");
        System.out.println("__________________________");
        System.out.println("1. Добавить новое животное");
        System.out.println("2. Обучить команде");
        System.out.println("3. Показать все команды");
        System.out.println("0. Выход");
    }

    @Override
    public void addAnimal() {
        boolean flag = false;
        while(flag == false) {
            System.out.println("Какое животное хотите добавить?");
            System.out.println("1. Домашнее животное");
            System.out.println("2. Вьючное животное");
            System.out.println("Введите номер");

            int animalType = scanner.nextInt();
                if (animalType == 1 || animalType == 2) {
//                    flag = true;
                    if (animalType == 1) {
                        String animalName = "";
                        System.out.println("Введите вид домашнего животного");
                        String petType = readSmth();

                        if (checkType(readSmth(), animalType) == false) {
                            flag = false;
                        } else {

                            System.out.println("Введите Имя домашнего животного");
                            String name = readSmth();
                            animalName = name;
                        }
                        LocalDate birthday = LocalDate.parse(readDate());
                        this.animal = new Pet(animalName, birthday);
                        petsBase.add((Pet) animal);
                        flag = true;

                    }
                    if (animalType == 2) {
                        String animalName = "";
                        System.out.println("Введите вид вьючного животного");
                        String packType = readSmth();
                        if (checkType(readSmth(), animalType) == false) {
                            flag = false;
                        } else {

                            System.out.println("Введите Имя вьючного животного");
                            String packName = readSmth();
                            animalName = packName;
                        }
                        LocalDate birthday = LocalDate.parse(readDate());
                        this.animal = new PackAnimal(animalName, birthday);
                        packsBase.add((PackAnimal) animal);
                        flag = true;

                    }
                } else flag = false;
        }


    }
    public String readDate(){
        System.out.println("Введите дату рождения в формате YYYY-MM-DD");
        String date = scanner.nextLine();
        LocalDate localDate = LocalDate.parse(date);
        return date;
    }
    public String  readSmth(){
        String result=null;
        boolean flag = false;
        while (flag == false&& result ==null) {
            String smth = scanner.nextLine();
            if (smth == "") {
                flag = false;
                System.out.println("Данные пустые. Попробуйте снова");
                break;
            } else {
                result = smth;
                flag = true;
            }
        }
        return result;
    }

    @Override
    public boolean checkType(String string, int animalType) {
        String newString = string.toLowerCase();
        boolean flag = false;
        String[] petArray = {"собака", "кошка", "кот","попугай", "канарейка", "хомяк", "кролик","крыса","рыбка","черепаха", "змея", "ящереца", "паук","мини-пиг"};
        String[] packArray = {"верблюд","осел","лошадь","конь","слон","бык"};
        if(animalType == 1) {
            for (String s : petArray
            ) {
                if (newString.equals(s)) {
                    System.out.println("Это домашнее животное");
                    flag = true;
                    break;
                }
            }
        }
        if(animalType ==2) {

            for (String s : packArray
            ) {
                if (newString.equals(s)) {
                    System.out.println("Это вьючное животное");
                    flag = true;
                    break;
                }
            }
        }
        if (flag == false) {
                System.out.println("Похоже такого типа животных не существует или оно не соответствует виду");
            }
        return flag;
    }


    public void showCommands() {
        System.out.println("Животное обучено командам: ");
        animal.getCommands();

    }


    public void addCommand() {
        String comandName = null;
        boolean flag = false;
        while (flag == false && comandName == null) {
            System.out.println("Введите название команды");
            String someCommand = scanner.nextLine();
            if (someCommand == ""||someCommand == null){
                flag = false;

            }else {
                comandName = someCommand;
                Command comand = new Command(comandName);
                animal.addCommand(comand);
                flag = true;
            }
        }
    }
}
