package com.example.myapplication.ui.home.vehicle;

import android.app.Dialog;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.myapplication.R;
import com.example.myapplication.data.model.Vehicle;
import com.example.myapplication.util.api.ApiUtils;
import com.example.myapplication.util.DateUtils;
import com.example.myapplication.util.DialogUtils;
import com.example.myapplication.util.api.JsonUtils;
import com.example.myapplication.util.NavUtils;
import com.example.myapplication.util.UiUtils;
import com.example.myapplication.util.UserUtils;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class VehicleFragment extends Fragment implements VehicleAdapter.OnReauthorizeListener {

    private RecyclerView recyclerView;
    private final List<Vehicle> vehicleList = new ArrayList<>();
    private VehicleAdapter adapter;
    private View btnAddVehicle;
    private int userId = -1;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_vehicle, container, false);

        initView(view);
        initRecyclerView(view);

        userId = UserUtils.getUserId(requireContext());

        initListener();


        return view;
    }

    private void initListener() {
        btnAddVehicle.setOnClickListener(v -> NavUtils.open(requireActivity(), new VehicleAddFragment()));
    }

    private void initRecyclerView(View view) {
        recyclerView.setLayoutManager(new LinearLayoutManager(requireContext()));
        adapter = new VehicleAdapter(vehicleList, this);
        recyclerView.setAdapter(adapter);
    }

    private void initView(View view) {
        recyclerView = view.findViewById(R.id.rv_vehicle_list);
        btnAddVehicle = view.findViewById(R.id.img_vehicle_add_vehicle);
    }

    @Override
    public void onResume() {
        super.onResume();
        loadVehicles();
    }

    private void loadVehicles() {
        ApiUtils.get(this, "vehicle?userId=" + userId, result -> {
            JSONArray array = JsonUtils.parseArray(result.getData());
            if (array == null) return;

            vehicleList.clear();
            for (int i = 0; i < array.length(); i++) {
                JSONObject item = array.optJSONObject(i);
                if (item != null) vehicleList.add(new Vehicle(item));
            }
            sortVehicles(vehicleList);
            adapter.notifyDataSetChanged();
        });
    }

    private void sortVehicles(List<Vehicle> list) {
        list.sort(Comparator.comparing(Vehicle::isExpired).thenComparing(v->v.expiredTime));
    }

    @Override
    public void onReauthorize(Vehicle vehicle) {
        Dialog dialog = new Dialog(requireContext());
        View view = getLayoutInflater().inflate(R.layout.dialog_reauthorize, null);

        dialog.setContentView(view);
        dialog.setCancelable(false);

        EditText etExpiredDate = view.findViewById(R.id.et_dialog_expired_date);
        View btnCancel = view.findViewById(R.id.btn_dialog_reauthorize_cancel);
        View btnConfirm = view.findViewById(R.id.btn_dialog_reauthorize_confirm);

        // Create Calendar dialog control
        etExpiredDate.setOnClickListener(v -> DateUtils.show(
                requireContext(),
                etExpiredDate.getText().toString(),
                date -> etExpiredDate.setText(date)
                )
        );

        btnCancel.setOnClickListener(v -> dialog.dismiss());

        btnConfirm.setOnClickListener(v -> {
            String date = UiUtils.getText(etExpiredDate);
            DialogUtils.confirm(
                    requireContext(),
                    "Are you sure to update the authorization?",
                    () -> postReauthorize(vehicle, date, dialog)
            );
        });

        dialog.show();
    }

    private void postReauthorize(Vehicle vehicle, String date, Dialog dialog) {
        JSONObject json = new JSONObject();
        try {
            json.put("authorizedId", vehicle.authorizedId);
            json.put("authorizationExpired", date);
        } catch (Exception ignored) {
        }

        ApiUtils.post(this, "vehicle/reauthorize", json, result -> {
            dialog.dismiss();
            loadVehicles();
        });
    }
}
