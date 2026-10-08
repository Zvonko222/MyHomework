package com.example.s2.util.json;

import androidx.annotation.NonNull;

import org.json.JSONArray;
import org.json.JSONException;

public class JsonArray {
    private final JSONArray array = new JSONArray();
    public JsonArray put (Object value){
        try{
            array.put(value);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
        return this;
    }

    @NonNull
    @Override
    public String toString() {
        return array.toString();
    }
}
