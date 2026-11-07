package com.example.myapplication.util;

import android.content.Context;
import android.content.SharedPreferences;

public final class UserUtils {
    private UserUtils() {
    }

    public static int getUserId(Context context) {
        return getShp(context).getInt("userId", -1);
    }

    public static String getUsername(Context context) {
        return getShp(context).getString("username", "");
    }

    public static String getPassword(Context context) {
        return getShp(context).getString("password", "");
    }

    public static void saveLogin(Context context, String username, String password, int userId) {
        getShp(context).edit()
                .putString("username", username)
                .putString("password", password)
                .putInt("userId", userId)
                .putBoolean("isLogin", true)
                .apply();
    }

    private static SharedPreferences getShp(Context context) {
        return context.getSharedPreferences("user_config", Context.MODE_PRIVATE);
    }
}
