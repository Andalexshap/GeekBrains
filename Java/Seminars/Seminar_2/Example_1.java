package Seminars.Seminar_2;


public class Example_1 {
    public static void main(String[] args) {
        System.out.println(buildString(5, 'f', 'b'));
    }   
    

    private static String buildString(int n, char first, char second){
        String result = "";
        
        for (int i = 0; i < n; i++) {
            if(i % 2 == 0) result += first;
            else result += second;            
        }        
        return result;
    }
}
