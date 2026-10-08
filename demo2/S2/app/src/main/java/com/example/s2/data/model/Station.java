package com.example.s2.data.model;

public class Station {
    //      stationId = x.StationId,
    //      maximumPeople = x.ArrangementStation.MaximumPeople,
    //      isEnable = x.ArrangementStation.IsEnable,
    //      isCheckout = x.IsCheckout
    private int stationId;
    private int maximumPeople;
    private boolean isEnable;
    private boolean isCheckout;

    public int getStationId() {
        return stationId;
    }

    public void setStationId(int stationId) {
        this.stationId = stationId;
    }

    public int getMaximumPeople() {
        return maximumPeople;
    }

    public void setMaximumPeople(int maximumPeople) {
        this.maximumPeople = maximumPeople;
    }

    public boolean isEnable() {
        return isEnable;
    }

    public void setEnable(boolean enable) {
        isEnable = enable;
    }

    public boolean isCheckout() {
        return isCheckout;
    }

    public void setCheckout(boolean checkout) {
        isCheckout = checkout;
    }
}
