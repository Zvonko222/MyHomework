package com.example.myapplication.util;

public final class DutyUtils {

    private DutyUtils() {
    }

    public static double calculate(double amount, double hsRate, double countryRate, double tradeRate, String tradeName) {
        if (amount <= 0 || hsRate < 0 || countryRate < 0 || tradeRate < 0) return 0;
        if (countryRate == 0 || "Bonded".equals(tradeName)) return 0;

        double duty = amount * (hsRate + countryRate);
        if ("Processing Trade".equals(tradeName)) duty *= tradeRate;

        return Math.round(duty * 100) / 100;
    }

}
