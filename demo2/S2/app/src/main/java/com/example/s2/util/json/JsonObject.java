package com.example.s2.util.json;

import androidx.annotation.NonNull;

import org.json.JSONException;
import org.json.JSONObject;

public class JsonObject {
    private final JSONObject json = new JSONObject();
    public JsonObject put(String key,Object value){
        try{
            json.put(key,value);
        } catch (JSONException e) {
            throw new RuntimeException(e);
        }
        return this;
    }

    @NonNull
    @Override
    public String toString() {
        return json.toString();
    }
}
