package Home_work.Home_Work_1.Services;

import java.util.ArrayList;
import java.util.Random;

import Home_work.Home_Work_1.Models.Player;

public class Game {
    private static boolean isRuning = true;

    public static void StartGame(ArrayList<Player> team1, ArrayList<Player> team2) {
        var rnd = new Random();
        var firstTeam = team1;
        var secondTeam = team2;
        if (rnd.nextInt(1, 3) != 1) {
            firstTeam = team2;
            secondTeam = team1;
        }
        while (isRuning) {
            stepTeam(firstTeam, secondTeam);
            if(isRuning){
                stepTeam(secondTeam, firstTeam);
            }            
        }
    }

    public static void stepTeam(ArrayList<Player> firstTeam, ArrayList<Player> secondTeam) {
        var rnd = new Random();
        int firstPlayer = rnd.nextInt(firstTeam.size());
        int secondPlayer = rnd.nextInt(secondTeam.size());
        Player first_player = firstTeam.get(firstPlayer);
        Player second_player = secondTeam.get(secondPlayer);

        System.out.println("Игрок из команды №" + 
                           first_player.getTeam() + "(" + 
                           first_player.getName() + ") атакует Игрока из команды №" + 
                           second_player.getTeam() + "(" + 
                           second_player.getName() + ")");


        first_player.attack(second_player);
        var team = second_player.getTeam();
        if (!second_player.isAlive()) {
            Teams.resizeTeam(secondTeam, secondPlayer);
        }
        if (secondTeam.size() == 0) {
            isRuning = false;
            System.out.println("Битва Окончена! Победу одержала команда №" + team);
        }
    }
}
