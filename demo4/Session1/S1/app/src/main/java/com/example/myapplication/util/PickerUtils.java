package com.example.myapplication.util;

import android.app.Dialog;
import android.content.Context;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.Window;
import android.widget.NumberPicker;
import android.widget.TextView;

import com.example.myapplication.R;

import java.text.Format;
import java.util.Arrays;
import java.util.List;

public class PickerUtils {

    public interface OnItemSelected {
        void onSelected(int index);
    }

    public interface OnGroupSelected {
        void onSelected(int leftIndex, int rightIndex);
    }

    // set dialog confirm and cancel, dismiss at end
    private static void setButton(View view, Dialog dialog, Runnable onConfirm) {
        TextView tvConfirm = view.findViewById(R.id.tv_dialog_confirm);
        TextView tvCancel = view.findViewById(R.id.tv_dialog_cancel);

        // show
        dialog.show();

        Window window = dialog.getWindow();
        if (window == null) return;

        window.setGravity(Gravity.BOTTOM);
        window.setBackgroundDrawableResource(R.color.white);

        // on click listener
        tvConfirm.setOnClickListener(v -> {
            onConfirm.run();
            dialog.dismiss();
        });
        tvCancel.setOnClickListener(v -> dialog.dismiss());
    }


    public static void show(Context context, List<String> list, OnItemSelected listener) {
        Dialog dialog = new Dialog(context);
        View view = LayoutInflater.from(context).inflate(R.layout.dialog_picker, null);
        dialog.setContentView(view);

        NumberPicker npLeft = view.findViewById(R.id.np_dialog_left);
        NumberPicker npRight = view.findViewById(R.id.np_dialog_right);
        npRight.setVisibility(View.GONE);

        setPicker(npLeft, list);

        // () return selected index
        setButton(view, dialog, () -> {
            int index = npLeft.getValue();
            if (listener != null) listener.onSelected(index);
        });
    }

    public static void showList(Context context, List<String> leftList, List<String> rightList, OnItemSelected listener) {
        Dialog dialog = new Dialog(context);
        View view = LayoutInflater.from(context).inflate(R.layout.dialog_picker, null);
        dialog.setContentView(view);

        NumberPicker npLeft = view.findViewById(R.id.np_dialog_left);
        NumberPicker npRight = view.findViewById(R.id.np_dialog_right);

        setPicker(npLeft, leftList);
        setPicker(npRight, rightList);

        npLeft.setOnValueChangedListener((picker, oldValue, newValue) -> npRight.setValue(newValue));
        npRight.setOnValueChangedListener((picker, oldValue, newValue) -> npLeft.setValue(newValue));

        setButton(view, dialog, () -> {
            int index = npLeft.getValue();
            if (listener != null) listener.onSelected(index);
        });
    }

    public static void showGroups(Context context, List<String> leftList,
                                  List<List<String>> rightGroupList, OnGroupSelected listener) {
        Dialog dialog = new Dialog(context);
        View view = LayoutInflater.from(context).inflate(R.layout.dialog_picker, null);
        dialog.setContentView(view);

        NumberPicker npLeft = view.findViewById(R.id.np_dialog_left);
        NumberPicker npRight = view.findViewById(R.id.np_dialog_right);

        setPicker(npLeft, leftList);

        Runnable updateRight = () -> {
            int leftIndex = npLeft.getValue();

            if (rightGroupList != null && leftIndex < rightGroupList.size()) {
                List<String> rightList = rightGroupList.get(leftIndex);
                setPicker(npRight, rightList);
            } else {
                setPicker(npRight, null);
            }
        };

        updateRight.run();

        npLeft.setOnValueChangedListener((picker, oldVal, newVal) -> updateRight.run());

        setButton(view, dialog, () -> {
            if (listener != null) {
                int leftIndex = npLeft.getValue();
                int rightIndex = npRight.getValue();
                listener.onSelected(leftIndex, rightIndex);
            }
        });


    }


    private static void setPicker(NumberPicker picker, List<String> list) {
        picker.setDisplayedValues(null);
        picker.setMinValue(0);

        if (list == null || list.isEmpty()) {
            list = Arrays.asList("No data");
            picker.setEnabled(false);
        } else {
            picker.setEnabled(true);
        }

        picker.setMaxValue(list.size() - 1);
        picker.setDisplayedValues(list.toArray(new String[0]));
        picker.setDescendantFocusability(NumberPicker.FOCUS_BLOCK_DESCENDANTS);
    }
}
