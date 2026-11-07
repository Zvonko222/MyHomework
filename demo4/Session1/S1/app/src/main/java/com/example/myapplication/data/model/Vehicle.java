package com.example.myapplication.data.model;

import org.json.JSONObject;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class Vehicle {
    public int authorizedId;
    public String licensePlateNumber;
    public int length;
    public int width;
    public int capacity;
    public String startTime;
    public String expiredTime;
    public boolean expired;

    public Vehicle(JSONObject item) {
        authorizedId = item.optInt("authorizedId");
        licensePlateNumber = item.optString("licensePlateNumber");
        length = item.optInt("length");
        width = item.optInt("width");
        capacity = item.optInt("capacity");
        startTime = item.optString("startTime");
        expiredTime = item.optString("expiredTime");
        expired = item.optBoolean("expired");
    }

    public boolean isExpired() {
        if (expired) return true;
        if (expiredTime == null || expiredTime.length() < 10) return false;
        String today = new SimpleDateFormat("yyyy-MM-dd", Locale.US).format(new Date());
        return expiredTime.substring(0, 10).compareTo(today) < 0;
    }
}
