package com.example.myapplication.util.api;

import android.os.Handler;
import android.os.Looper;
import android.util.Log;

import androidx.fragment.app.Fragment;

import com.example.myapplication.util.UiUtils;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public final class ApiUtils {

    private static final String BASE_URL = "http://10.0.2.2:8015/api/";

    private static final Handler MAIN = new Handler(Looper.getMainLooper());

    public interface OnResult {
        void onResult(Result result);
    }

    public static final class Result {
        private final JSONObject json;
        private Result(String body) {
            json = JsonUtils.parseObject(body);
        }

        public boolean isSuccess() {
            return json != null && json.optInt("code",-1) == 200;
        }

        public String getMsg() {
            return isSuccess() ? json.optString("msg","") : "Request ERROR";

        }

        public String getData() {
            return json == null ? "" : json.optString("data","");
        }
    }

    private ApiUtils() {
    }
    public static void get( String api, OnResult listener) {
        request("GET", api, null, listener);
    }

    public static void get(Fragment fragment, String api, OnResult listener) {
        request("GET", api, null, result -> {
            if (!fragment.isAdded()) return;
            if (!result.isSuccess()) {
                UiUtils.toast(fragment, result.getMsg());
                return;
            }
            if (listener != null) listener.onResult(result);
        });
    }

    public static void post(Fragment fragment,
                            String api, JSONObject json,
                            OnResult listener) {
        request("POST", api, json, result -> {
            if (!fragment.isAdded()) return;
            if (!result.isSuccess()) {
                UiUtils.toast(fragment, result.getMsg());
                return;
            }
            if (listener != null) listener.onResult(result);
        });
    }

    public static void post(String api, JSONObject json, OnResult listener) {
        request("POST", api, json, listener);
    }

    private static void request(String method, String api, JSONObject json, OnResult listener) {
        new Thread(() -> {
            String body = null;
            HttpURLConnection conn = null;
            try {
                conn = openConnection(api);
                conn.setRequestMethod(method);

                if (json != null) {
                    conn.setDoOutput(true);
                    conn.setRequestProperty("Content-Type", "application/json");

                    try (OutputStream output = conn.getOutputStream()) {
                        output.write(json.toString().getBytes());
                    }
                }
                int code = conn.getResponseCode();

                InputStream input = code >= 200 && code < 300
                        ? conn.getInputStream() : conn.getErrorStream();

                body = readResponse(input);
            } catch (Exception e) {
                Log.e("TAG", "request: ERROR", e);
            } finally {
                if (conn != null) {
                    conn.disconnect();
                }
            }
            Result result = new Result(body);

            MAIN.post(() -> {
                if (listener != null) listener.onResult(result);
            });
        }).start();
    }

    private static HttpURLConnection openConnection(String api) throws IOException {
        HttpURLConnection conn = (HttpURLConnection) new URL(BASE_URL + api).openConnection();

//        conn.setRequestProperty("Host", "localhost:8090");
        return conn;
    }

    private static String readResponse(InputStream input) throws IOException {
        if (input == null) return "";

        StringBuilder result = new StringBuilder();

        try (BufferedReader reader = new BufferedReader(new InputStreamReader(input))) {
            String line;
            while ((line = reader.readLine()) != null) result.append(line);
        }
        return result.toString();
    }
}
