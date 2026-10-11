package tools;

import java.time.DateTimeException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class InputUtil {
    public static final Scanner sc = new Scanner(System.in);

    public static boolean isInt(String input){
        try{
            Integer.parseInt(input);
            return true;
        }catch (NumberFormatException e){
            return false;
        }
    }
    public static boolean isDouble(String input){
        try{
            Double.parseDouble(input);
            return true;
        }catch (NumberFormatException e){
            return false;
        }
    }
    public static boolean isDate(String input){
        try{
            LocalDate.parse(input,DateTimeFormatter.ofPattern("yyyy-M-d"));
            return true;
        } catch (DateTimeException e) {
            return false;
        }
    }
    public static String enterDoubleDigital() {
        while (true) {
            String input = sc.nextLine();
            if(isDouble(input)){
                return input;
            }
            System.out.println("Please enter an double digital");
        }

    }
    public static String enterIntDigital(){
        while(true){
            String input = sc.nextLine();
            if(isInt(input)){
                return input;
            }
            System.out.println("Please enter an int digital");
        }
    }
    public static String enterDateFormat(){
        while(true){
            String date = sc.nextLine();

            if(isDate(date)){
                return date;
            }
            System.out.println("Please enter an Date,such as 2026-6-11");
        }
    }
}
