package com.example.s2.util.network;

import android.os.Handler;
import android.os.Looper;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.StandardCharsets;

import okhttp3.Callback;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;


public class ApiRequest {
//    private static final String BASE_URL = "http://10.0.2.2:50913/api/";
//
//    // get request
//    public static void get(String api, ApiCallback callback) {
//        request(
//                "GET",
//                api,
//                null,
//                callback
//        );
//    }
//
//    public static void post(String api, String json, ApiCallback callback) {
//        request(
//                "POST",
//                api,
//                json,
//                callback
//        );
//    }
//
//    private static void request(String method, String api, String json, ApiCallback callback) {
//        new Thread(() -> {
//            try {
//                URL url = new URL(BASE_URL + api);
//                HttpURLConnection conn = (HttpURLConnection) url.openConnection();
//                // Request Method
//                conn.setRequestMethod(method);
//                // Timeout
//                conn.setConnectTimeout(5000);
//                conn.setReadTimeout(5000);
//                // Header
//                conn.setRequestProperty("Host", "localhost:50913");
//                conn.setRequestProperty("Content-Type", "application/json");
//                // Post
//                if ("POST".equals(method)) {
//                    conn.setDoOutput(true);
//
//                    OutputStream os = conn.getOutputStream();
//                    os.write(json.getBytes(StandardCharsets.UTF_8));
//                    os.close();
//                }
//                // Response Code
//                int code = conn.getResponseCode();
//                // Response Body
//                InputStream is = code >= 200 && code < 400 ? conn.getInputStream() : conn.getErrorStream();
//
//                String response = readResponse(is);
//
//                new Handler(Looper.getMainLooper()).post(()->callback.onResponse(code,response));
//                conn.disconnect();
//
//            } catch (Exception e) {
//                new Handler(Looper.getMainLooper()).post(()->callback.onFailure(e));
//            }
//        }).start();
//    }
//
//    private static String readResponse(InputStream is) throws Exception {
//        if (is == null) {
//            return "";
//        }
//        BufferedReader reader = new BufferedReader(new InputStreamReader(is, StandardCharsets.UTF_8));
//        StringBuilder result = new StringBuilder();
//
//        String line;
//        while ((line = reader.readLine()) != null) {
//            result.append(line);
//        }
//        reader.close();
//        return result.toString();
//    }
    private static final OkHttpClient client = new OkHttpClient();
    private static final String BASE_URL = "http://10.0.2.2:50913/api/";
    private static final MediaType JSON = MediaType.get("application/json;charset=utf-8");



    public static void get(String api, Callback callback){
        String url = BASE_URL + api ;
        Request request = new Request.Builder()
                .url(url)
                .header("Host","localhost:50913")
                .get()
                .build();
        client.newCall(request).enqueue(callback);
    }
    public static void post(String api,String json,Callback callback){
        String url = BASE_URL + api;
        RequestBody body = RequestBody.create(json, JSON);
        Request request = new Request.Builder()
                .url(url)
                .header("Host","localhost:50913")
                .post(body)
                .build();
        client.newCall(request).enqueue(callback);
    }
}
