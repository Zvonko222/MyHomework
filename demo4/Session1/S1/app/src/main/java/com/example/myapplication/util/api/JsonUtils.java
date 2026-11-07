package com.example.myapplication.util.api;

import org.json.JSONArray;
import org.json.JSONObject;

public class JsonUtils {

    public static JSONArray parseArray(String data) {
        try {
            return new JSONArray(data);
        } catch (Exception e) {
            return null;
        }
    }

    public static JSONObject parseObject(String data) {
        try {
            return new JSONObject(data);
        } catch (Exception e) {
            return null;
        }
    }
}
