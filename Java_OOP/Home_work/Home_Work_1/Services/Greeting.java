package Home_work.Home_Work_1.Services;

import java.util.ArrayList;

import Home_work.Home_Work_1.Models.Player;

public class Greeting {
    public static void greetingTeams(ArrayList<Player> players, int numberOfTeam){
        System.out.println("Команда №" + numberOfTeam + ":");
        System.out.println("=".repeat(players.get(0).toString().length()));
        for (int i = 0; i < players.size(); i++) {
            System.out.println(players.get(i));
        }
        System.out.println("=".repeat(players.get(players.size()-1).toString().length()));
    }
}
