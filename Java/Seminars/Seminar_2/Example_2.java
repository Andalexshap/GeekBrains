package Seminars.Seminar_2;

public class Example_2 {
    public static void main(String[] args) {
        //Напишите метод, который сжимает строку. Пример: вход aaaabbbcdd. результат - a4b3cd2
        System.out.println(encryptionString("aaaabbbcdda"));


    }

    private static String encryptionString(String string){
        String result = "";
        int count = 1;
        for (int i = 0; i < string.length()-1; i++) {
            if(string.charAt(i) == string.charAt(i+1)) count ++;                
            else{
                result += string.charAt(i);
                if (count!= 1){
                    result += count;    
                }               
               count = 1;
            }  
        }
        result += string.charAt(string.length()-1);
        if (count!= 1) result += count;             
        return result;
    }

    // private static String dencryptionString(String string){
    //     String result = "";
    //     for (int i = 0; i < string.length(); i++) {
    //         try {
    //             char ch = string.charAt(i);
    //             int temp = Integer.parseInt(ch);
    //             result = result.charAt(i-1) * temp;
    //         } catch (NumberFormatException e) {
    //             return false;
    //         }
    //     }
    //     return result;
    // }
    
        
        
}
    
