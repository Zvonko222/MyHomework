package com.example.myapplication.data.model;

public class DeclarationDraft {
    public String voyageNumber = "";
    public String containerNumber = "";
    public String hsCode = "";
    public String countryOfOrigin = "";
    public String countryName = "";
    public String tradeModeName = "";
    public String description = "";
    public String quantityText = "";
    public String amountText = "";

    public int tradeModeId = -1;
    public int unitId = -1;

    public double cargoAmount;
    public double dutyPayable;
    public double hsRate;
    public double countryRate;
    public double tradeRate = 1;
}
