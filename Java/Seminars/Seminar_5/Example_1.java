package Seminars.Seminar_5;

import java.util.HashMap;
import java.util.Map;

public class Example_1 {
    public static void main(String[] args) {
        System.out.println(isIsomorph("title", "piple"));
        System.out.println(isIsomorph("piple", "Ditle"));
        System.out.println(isIsomorph("Ditle", "piple"));



    }
    private static boolean isIsomorph(String firstStr, String secondStr){
        if(firstStr.length() == secondStr.length()){
            Map<Character, Character> symbol = new HashMap<>();
            for (int i = 0; i < firstStr.length(); i++) {
                if(!symbol.containsKey(firstStr.charAt(i))){
                    symbol.put(firstStr.charAt(i), secondStr.charAt(i));
                }
                else
                    if(!symbol.get(firstStr.charAt(i)).equals(secondStr.charAt(i))){
                        return false;
                }
            }
            return true && isIsomorphReverse(secondStr, firstStr);
        }   
        return false;             
    }

    private static boolean isIsomorphReverse(String firstStr, String secondStr){
        if(firstStr.length() == secondStr.length()){
            Map<Character, Character> symbol = new HashMap<>();
            for (int i = 0; i < firstStr.length(); i++) {
                if(!symbol.containsKey(firstStr.charAt(i))){
                    symbol.put(firstStr.charAt(i), secondStr.charAt(i));
                }
                else
                    if(!symbol.get(firstStr.charAt(i)).equals(secondStr.charAt(i))){
                        return false;
                }
            }
            return true;
        }   
        return false;             
    }
}
