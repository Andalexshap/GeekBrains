package Home_work.Home_Work_1.Services;

import java.util.ArrayList;
import java.util.Random;

import Home_work.Home_Work_1.Models.Assassin;
import Home_work.Home_Work_1.Models.Mage;
import Home_work.Home_Work_1.Models.Player;
import Home_work.Home_Work_1.Models.Tank;

public class Teams {
    public static ArrayList<Player> createTeam(int teamSize, int numberOfTeam) {
        Random random = new Random();
        var team = new ArrayList<Player>(teamSize);

        for (int i = 0; i < teamSize; i++) {
            switch (random.nextInt(3)) {
                case 0:
                    var tank = new Tank("Tank_" + (Player.getCounterId() - 1));
                    tank.setTeam(numberOfTeam);
                    team.add(tank);
                    break;
                case 1:
                    var assassin = new Assassin("Assassin_" + (Player.getCounterId() - 1));
                    assassin.setTeam(numberOfTeam);
                    team.add(assassin);
                    break;
                case 2:
                    var mage = new Mage("Mage_" + (Player.getCounterId() - 1));
                    mage.setTeam(numberOfTeam);
                    team.add(mage);
                    break;
            }
        }
        return team;
    }

    public static void resizeTeam(ArrayList<Player> players, int player) {
        players.remove(player);
    }

}