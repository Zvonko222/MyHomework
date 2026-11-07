package com.example.s2.models;

public class ArrangementModel {
    //       stationId = o.StationId
    //       //openTime = o.OpenTime,
    //       //checkoutTime = o.CheckOutTime,
    //       //totalAmount = o.TotalAmount,
    //       //isCheckout = o.IsCheckout
    private String stationId;
    private String openTime ;
    private String checkoutTime;
    private String totalAmount;
    private boolean isCheckout  ;

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

    public boolean isCheckout() {
        return isCheckout;
    }

    public void setIsCheckout(boolean checkout) {
        isCheckout = checkout;
    }
}
