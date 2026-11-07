package com.example.myapplication.data.model;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class Departure {
    public String country;
    public final List<String> ports = new ArrayList<>();

    public Departure(JSONObject item) {
        country = item.optString("countryName");
        JSONArray array = item.optJSONArray("ports");
        if (array == null) return;
        for (int i = 0; i < array.length(); i++) {
            ports.add(array.optString(i));
        }
    }
}
