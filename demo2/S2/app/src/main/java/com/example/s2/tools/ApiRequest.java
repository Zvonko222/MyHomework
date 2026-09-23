package com.example.s2.tools;

import okhttp3.Callback;
import okhttp3.FormBody;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;

public class ApiRequest {
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
