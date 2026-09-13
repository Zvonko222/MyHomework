package com.example.session3.tools;

import android.util.Log;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.StandardCharsets;

public class ApiRequest {
    public static int lastCode;

    public static String post(String api, String requestBody) {
        try {
            URL url = new URL("http://10.0.2.2:60556/api/" + api);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setDoOutput(true);
            conn.setRequestProperty("Content-Type", "application/json");
            conn.setRequestProperty("Host", "localhost:60556");

            OutputStream os = conn.getOutputStream();
            os.write(requestBody.getBytes(StandardCharsets.UTF_8));
            os.close();

            return readResponse(conn);
        } catch (Exception e) {
            Log.e("HTTP", "post: ERROR", e);
            return null;
        }
    }

    public static String get(String api) {
        try {
            URL url = new URL("http://10.0.2.2:60556/api/" + api);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Host", "localhost:60556");
            return readResponse(conn);
        } catch (Exception e) {
            Log.e("HTTP", "GET ERROR ", e);
            return null;
        }
    }

    public static String readResponse(HttpURLConnection conn) {
        try {
            int code = conn.getResponseCode();
            lastCode = code;

            InputStream is;
            Log.d("HTTP", "code = " + code);
            if (code >= 200 && code < 300) {
                is = conn.getInputStream();
            } else {
                is = conn.getErrorStream();
            }

            BufferedReader br = new BufferedReader(new InputStreamReader(is));
            StringBuilder sb = new StringBuilder();

            String line;
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }
            br.close();
            return sb.toString();
        } catch (Exception e) {
            Log.e("HTTP", "readResponse: ERROR", e);
            return null;
        }
    }
}
