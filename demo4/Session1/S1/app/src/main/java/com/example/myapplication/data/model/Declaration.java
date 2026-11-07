package com.example.myapplication.data.model;

import org.json.JSONObject;

public class Declaration {
    public String declarationId;
    public String voyageNumber;
    public String containerNumber;
    public double cargoAmount;
    public double dutyPayable;
    public String status;
    public String reason;

    public Declaration(JSONObject item) {
        declarationId = item.optString("declarationId");
        voyageNumber = item.optString("voyageNumber");
        containerNumber = item.optString("containerNumber");
        cargoAmount = item.optDouble("cargoAmount");
        dutyPayable = item.optDouble("dutyPayable");
        status = item.optString("status");
        reason = item.optString("reason");
    }
}
