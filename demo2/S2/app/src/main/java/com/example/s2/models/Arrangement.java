package com.example.s2.models;

public class Arrangement {
    //
//    stationId = x.StationId,
//    openTime = x.OpenTime,
//    checkoutTime = x.CheckOutTime,
//    totalAmount = x.TotalAmount
    private String stationId;
    private String openTime;
    private String checkoutTime;
    private String totalAmount;

    public String getStationId() {
        return stationId;
    }

    public void setStationId(String stationId) {
        this.stationId = stationId;
    }

    public String getOpenTime() {
        return openTime;
    }

    public void setOpenTime(String openTime) {
        this.openTime = openTime;
    }

    public String getCheckoutTime() {
        return checkoutTime;
    }

    public void setCheckoutTime(String checkoutTime) {
        this.checkoutTime = checkoutTime;
    }

    public String getTotalAmount() {
        return totalAmount;
    }

    public void setTotalAmount(String totalAmount) {
        this.totalAmount = totalAmount;
    }
}
