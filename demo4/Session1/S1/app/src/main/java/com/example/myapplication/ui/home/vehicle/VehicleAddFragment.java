package com.example.myapplication.ui.home.vehicle;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import androidx.fragment.app.Fragment;

import com.example.myapplication.R;
import com.example.myapplication.util.api.ApiUtils;
import com.example.myapplication.util.DateUtils;
import com.example.myapplication.util.DialogUtils;
import com.example.myapplication.util.FormatUtils;
import com.example.myapplication.util.NavUtils;
import com.example.myapplication.util.UiUtils;
import com.example.myapplication.util.UserUtils;

import org.json.JSONObject;

public class VehicleAddFragment extends Fragment {

    private EditText etPlate, etLength, etWidth, etCapacity, etStartDate, etExpiredDate;
    private View btnAdd;

    private String startDate = "";
    private int userId = -1;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_vehicle_add, container, false);

        userId = UserUtils.getUserId(requireContext());

        initView(view);
        initListener(view);

        return view;
    }

    private void initListener(View view) {
        etStartDate.setOnClickListener(v -> DateUtils.show(
                        requireContext(),
                        startDate,
                        date -> {
                            startDate = date;
                            etStartDate.setText(date);
                            etExpiredDate.setText("");
                        }
                )
        );

        etExpiredDate.setOnClickListener(v -> DateUtils.show(
                requireContext(),
                etExpiredDate.getText().toString(),
                date -> etExpiredDate.setText(date)
        ));

        btnAdd.setOnClickListener(v -> add());
    }

    private void initView(View view) {
        etPlate = view.findViewById(R.id.et_add_vehicle_plate);
        etLength = view.findViewById(R.id.et_add_vehicle_length);
        etWidth = view.findViewById(R.id.et_add_vehicle_width);
        etCapacity = view.findViewById(R.id.et_add_vehicle_capacity);
        etStartDate = view.findViewById(R.id.et_add_vehicle_start_date);
        etExpiredDate = view.findViewById(R.id.et_add_vehicle_expired_date);
        btnAdd = view.findViewById(R.id.btn_add_vehicle_add);
    }

    private void add() {
        String plate = UiUtils.getText(etPlate);
        String expiredDate = UiUtils.getText(etExpiredDate);

        if (!FormatUtils.hasText(plate)) {
            UiUtils.toast(this, "Enter the license plate number");
            return;
        }

        int length = parsePositiveInt(etLength, "Length");
        if (length < 1) return;

        int width = parsePositiveInt(etWidth, "Width");
        if (width < 1) return;

        int capacity = parsePositiveInt(etCapacity, "Capacity");
        if (capacity < 1) return;

        if (!FormatUtils.hasText(startDate)) {
            UiUtils.toast(this, "Select the start date");
            return;
        }
        if (!FormatUtils.hasText(expiredDate)) {
            UiUtils.toast(this, "Select the expired date");
            return;
        }
        if (expiredDate.compareTo(startDate) < 0) {
            UiUtils.toast(this, "Expired date cannot be earlier than start date");
            return;
        }

        DialogUtils.confirm(requireContext(), "Are you sure to add the vehicle?", () ->
                postVehicle(plate, length, width, capacity, expiredDate));
    }

    private int parsePositiveInt(EditText editText, String name) {
        String text = UiUtils.getText(editText);
        int value = FormatUtils.parseInt(text);
        if (!FormatUtils.isInteger(text) || value < 1) {
            UiUtils.toast(this, name + " must be an integer and at least 1");
            return -1;
        }
        return value;
    }

    private void postVehicle(String plate, int length, int width, int capacity, String expiredDate) {
        JSONObject json = new JSONObject();
        try {
            json.put("licensePlateNumber", plate);
            json.put("length", length);
            json.put("width", width);
            json.put("capacity", capacity);
            json.put("authorizedCargoOwner", userId);
            json.put("authorizationStart", startDate);
            json.put("authorizationExpired", expiredDate);
        } catch (Exception e) {
            Log.e("TAG", "postVehicle: JSON ERROR", e);
            return;
        }

        ApiUtils.post(this, "vehicle/add", json,
                result -> NavUtils.back(VehicleAddFragment.this));
    }
}
