package tools;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

public class DBHelper {
    private static final String url = "jdbc:mysql://localhost:3306/library_system";
    private static final String username = "root";
    private static final String password = "123";

    public static ResultSet ExecuteQuery(String sql){
        try{
            Class.forName("com.mysql.cj.jdbc.Driver");

            Connection conn = DriverManager.getConnection(url,username,password);
            Statement sm = conn.createStatement();


            return sm.executeQuery(sql);
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }
    public static int ExecuteUpdate(String sql){
        try(Connection conn = DriverManager.getConnection(url,username,password);
            Statement sm = conn.createStatement()
        ){
            int result = sm.executeUpdate(sql);
            return result;
        }catch (Exception e){
            e.printStackTrace();
            return  0;
        }
    }

}
