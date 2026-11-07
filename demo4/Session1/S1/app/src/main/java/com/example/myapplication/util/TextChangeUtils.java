package com.example.myapplication.util;

import android.text.Editable;
import android.text.TextWatcher;
import android.widget.TextView;

public class TextChangeUtils {

    public interface OnChanged {
        void run(String text);
    }

    public static void onChanged(TextView textView, OnChanged listener) {
        textView.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
            }

            @Override
            public void afterTextChanged(Editable s) {
                listener.run(s.toString());
            }
        });
    }
}
