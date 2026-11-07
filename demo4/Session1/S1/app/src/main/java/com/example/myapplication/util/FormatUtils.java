package com.example.myapplication.util;

import android.util.Log;
import android.widget.EditText;

public class FormatUtils {
    private FormatUtils() {
    }

    public static boolean hasText(String value) {
        return value != null
                && !value.trim().isEmpty()
                && !"null".equals(value.trim());
    }


    public static boolean isInteger(String value) {
        try {
            Integer.parseInt(value);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    public static int parseInt(String value) {
        int result;
        try {
            result = Integer.parseInt(value);
        } catch (NumberFormatException e) {
            result = -1;
            Log.e("TAG", "parseInt: ERROR", e);
        }
        return result;
    }
}
