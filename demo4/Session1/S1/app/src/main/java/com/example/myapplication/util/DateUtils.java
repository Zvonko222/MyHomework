package com.example.myapplication.util;

import android.app.DatePickerDialog;
import android.content.Context;
import android.util.Log;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

public class DateUtils {
    public interface OnDatePick {
        void onDate(String date);
    }

    public static void show(Context context, String currentDate, OnDatePick listener) {
        Calendar currentCalendar = Calendar.getInstance();

        if (currentDate != null && !currentDate.isEmpty()) {
            try {
                Date date = new SimpleDateFormat("yyyy-MM-dd").parse(currentDate);
                currentCalendar.setTime(date);
            } catch (ParseException e) {
                Log.e("TAG", "Date parse Error ", e);
                return;
            }
        }

        new DatePickerDialog(context, (view, year, month, dayOfMonth) -> {
            Calendar newCalendar = Calendar.getInstance();
            newCalendar.set(year, month, dayOfMonth);
            String date = new SimpleDateFormat("yyyy-MM-dd").format(newCalendar.getTime());
            if(listener !=null) listener.onDate(date);
        },
                currentCalendar.get(Calendar.YEAR),
                currentCalendar.get(Calendar.MONTH),
                currentCalendar.get(Calendar.DAY_OF_MONTH)
        ).show();
    }
}
