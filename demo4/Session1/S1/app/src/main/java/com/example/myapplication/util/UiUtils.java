package com.example.myapplication.util;

import android.content.Context;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.fragment.app.Fragment;

import java.util.List;

public final class UiUtils {

    public interface OnItem {
        void onItem(int position);
    }

    private UiUtils() {
    }

    public static void toast(Context context, String message) {
        Toast.makeText(context, message, Toast.LENGTH_SHORT).show();
    }

    public static void toast(Fragment fragment, String message) {
        if (fragment.isAdded()) {
            toast(fragment.requireContext(), message);
        }
    }
    public static String getText(TextView view) {
        return view.getText().toString().trim();
    }
    public static void bindSpinner(Spinner spinner, List<String> items) {

        ArrayAdapter<String> adapter = new ArrayAdapter<>(
                spinner.getContext(),
                android.R.layout.simple_spinner_item,
                items
        );
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner.setAdapter(adapter);
    }

    public static void bindSpinner(
            Spinner spinner,
            List<String> items,
            int selected,
            OnItem listener
    ) {
        bindSpinner(spinner, items);
        if (items.isEmpty()) return;

        spinner.setSelection(selected);

        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if (listener != null) {
                    listener.onItem(position);
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        if (listener != null) listener.onItem(spinner.getSelectedItemPosition());
    }
}
