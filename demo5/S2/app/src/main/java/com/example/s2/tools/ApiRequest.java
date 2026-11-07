package com.example.s2.tools;

import android.util.Log;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.StandardCharsets;

public class ApiRequest {
    private static String TAG = "ApiRequest";
    public static int lastCode;
    public static String post(String api,String requestBody ){
        try{
            URL url = new URL("http://10.0.2.2:51276/api/"+api);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Host","localhost:51276");
            conn.setRequestProperty("Content-Type","application/json");
            conn.setDoOutput(true);

            OutputStream os = conn.getOutputStream();
            os.write(requestBody.getBytes(StandardCharsets.UTF_8));
            os.close();

            return readResponse(conn);
        } catch (Exception e) {
            Log.e(TAG, "post: ERROR", e);
            return null;
        }
    }
    public static String get(String api){
        try{
            URL url = new URL("http:10.0.2.2:51276/api/"+api);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();

            conn.setRequestMethod("GET");
            conn.setRequestProperty("Host","localhost:51276");

            return readResponse(conn);
        } catch (Exception e) {
            Log.e(TAG, "get: ERROR", e);
            return null;
        }
    }

    private static String readResponse(HttpURLConnection conn) {
        try{
            int code = conn.getResponseCode();
            lastCode = code;

            InputStream is ;
            if(code>=200 && code<400){
                is = conn.getInputStream();
            }else{
                is = conn.getErrorStream();
            }
            StringBuilder sb = new StringBuilder();
            BufferedReader br = new BufferedReader(new InputStreamReader(is));

            String line;
            while((line= br.readLine())!=null){
                sb.append(line);
            }
            br.close();
            return sb.toString();
        } catch (Exception e) {
            Log.e(TAG, "readResponse: ERROR", e);
            return null;
        }
    }
}
