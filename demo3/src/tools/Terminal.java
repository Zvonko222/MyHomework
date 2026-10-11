package tools;

import java.util.Scanner;

public class Terminal {
    public static void clearScreen(){
        for (int i = 0; i < 50; i++) {
            System.out.println("");
        }
    }
    public static void operationExit(){
        System.out.println("\nEnter 0 to return");
        Scanner sc = new Scanner(System.in);
        while(true){
            String input = sc.nextLine();
            if(input.equals("0")){
                Terminal.clearScreen();
                return;
            }
        }
    }
}
