package com.example.myapplication.util;

import android.content.Context;

import androidx.appcompat.app.AlertDialog;

public class DialogUtils {

    public static void confirm(Context context, String msg, Runnable onOk) {
        new AlertDialog.Builder(context)
                .setTitle("Confirm")
                .setMessage(msg)
                .setPositiveButton("Confirm", (dialog, which) -> onOk.run())
                .setNegativeButton("Cancel", null)
                .show();
    }


    public static void info(Context context, String title, String msg) {
        new AlertDialog.Builder(context)
                .setTitle(title)
                .setMessage(msg)
                .setPositiveButton("OK", null)
                .show();
    }
}
