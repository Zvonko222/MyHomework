package com.example.myapplication.data.model;

import org.json.JSONObject;

public class Voyage {
    public String voyageNumber;
    public String departureCountryName;
    public String departurePortName;
    public String destinationCountryName;
    public String destinationPortName;
    public String departureTime;
    public String actualArrivalTime;
    public String estimatedArrivalTime;
    public String newEstimatedArrivalTime;
    public String status;

    public Voyage(JSONObject item) {
        voyageNumber = item.optString("voyageNumber");
        departureCountryName = item.optString("departureCountryName");
        departurePortName = item.optString("departurePortName");
        destinationCountryName = item.optString("destinationCountryName");
        destinationPortName = item.optString("destinationPortName");
        departureTime = item.optString("departureTime");
        actualArrivalTime = item.optString("actualArrivalTime");
        estimatedArrivalTime = item.optString("estimatedArrivalTime");
        newEstimatedArrivalTime = item.optString("newEstimatedArrivalTime");
        status = item.optString("status");
    }
}
