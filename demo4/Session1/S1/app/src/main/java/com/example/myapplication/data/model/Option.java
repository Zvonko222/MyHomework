package com.example.myapplication.data.model;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class Option {
    public int id;
    public String name;
    public String code;
    public String description;
    public double rate;

    public Option(JSONObject item) {
        id = item.optInt("id");
        name = item.optString("name");
        code = item.optString("hsCode");
        if (code.isEmpty()) code = item.optString("countryCode");
        description = item.optString("description");
        rate = item.optDouble("dutyRate", 1);
    }

    public static List<String> names(List<Option> options) {
        List<String> values = new ArrayList<>();
        for (Option option : options) values.add(option.name);
        return values;
    }

    public static List<String> codes(List<Option> options) {
        List<String> values = new ArrayList<>();
        for (Option option : options) values.add(option.code);
        return values;
    }

    public static List<String> descriptions(List<Option> options) {
        List<String> values = new ArrayList<>();
        for (Option option : options) values.add(option.description);
        return values;
    }
}
