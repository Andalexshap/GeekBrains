package Program;

import java.util.ArrayList;
import java.util.Collection;

public class PetsBase implements DataBase<Pet> {

    private ArrayList<Pet> petsCollection = new ArrayList<>();
//    private final Pet pet;

//    public PetsBase(Pet pet) {
//        this.pet = pet;
//    }




    @Override
    public void add(Pet item) {
        petsCollection.add(item);
    }

    @Override
    public Collection<Pet> getAll() {
//        for (Pet pet: petsCollection) {
//            System.out.println();
//        }
        return petsCollection;
    }

}
