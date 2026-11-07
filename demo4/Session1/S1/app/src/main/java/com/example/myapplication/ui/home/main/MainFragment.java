package com.example.myapplication.ui.home.main;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.myapplication.R;
import com.example.myapplication.data.model.Departure;
import com.example.myapplication.data.model.Voyage;
import com.example.myapplication.util.api.ApiUtils;
import com.example.myapplication.util.DateUtils;
import com.example.myapplication.util.FormatUtils;
import com.example.myapplication.util.api.JsonUtils;
import com.example.myapplication.util.PickerUtils;
import com.example.myapplication.util.TextChangeUtils;
import com.example.myapplication.util.UiUtils;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

public class MainFragment extends Fragment {
    private final List<Voyage> voyageList = new ArrayList<>();
    private final List<Voyage> rowList = new ArrayList<>();
    private final List<Departure> departureList = new ArrayList<>();
    private VoyageAdapter adapter;
    private TextView tvNumberOfVoyages, tvDepartureFrom, tvDepartureDate, tvArrivalDate;
    private EditText etSearch;
    private CheckBox cbDepartureDate, cbArrivalDate;
    private Spinner spStatus;
    private String departureDate = "";
    private String arrivalDate = "";

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_main, container, false);

        initView(view);

        initRecyclerView(view);
        setupStatusSpinner();

        initListener();
        loadVoyages();

        return view;
    }

    private void initRecyclerView(View view) {
        RecyclerView rv = view.findViewById(R.id.rv_main_voyage);
        rv.setLayoutManager(new LinearLayoutManager(requireContext()));
        adapter = new VoyageAdapter(rowList);
        rv.setAdapter(adapter);
    }

    private void initView(View view) {
        tvNumberOfVoyages = view.findViewById(R.id.tv_main_number_of_voyages);
        etSearch = view.findViewById(R.id.et_main_search_voyage_number);
        tvDepartureFrom = view.findViewById(R.id.tv_main_departure_from);
        tvDepartureDate = view.findViewById(R.id.tv_main_departure_date);
        tvArrivalDate = view.findViewById(R.id.tv_main_arrival_date);
        cbDepartureDate = view.findViewById(R.id.cb_main_departure_date);
        cbArrivalDate = view.findViewById(R.id.cb_main_arrival_date);
        spStatus = view.findViewById(R.id.sp_main_voyage_status);
    }

    private void initListener() {
        tvDepartureFrom.setFocusable(false);
        tvDepartureFrom.setOnClickListener(v -> {
            if (departureList.isEmpty()) {
                loadDepartures();
            } else {
                showDepartureDialog();
            }
        });

        tvDepartureDate.setOnClickListener(v -> pickDepartureDate());
        tvArrivalDate.setOnClickListener(v -> pickArrivalDate());
        cbDepartureDate.setOnCheckedChangeListener((buttonView, isChecked) -> filterVoyages());
        cbArrivalDate.setOnCheckedChangeListener((buttonView, isChecked) -> filterVoyages());

        TextChangeUtils.onChanged(etSearch, text -> filterVoyages());
    }

    private void pickArrivalDate() {
        DateUtils.show(requireContext(), arrivalDate, date -> {
            arrivalDate = date;
            tvArrivalDate.setText(date);
            filterVoyages();
        });
    }

    private void pickDepartureDate() {
        DateUtils.show(requireContext(), departureDate, date -> {
            departureDate = date;
            tvDepartureDate.setText(date);
            filterVoyages();
        });
    }

    private void setupStatusSpinner() {
        UiUtils.bindSpinner(
                spStatus,
                Arrays.asList("All", "Arrived", "On Passage"),
                0,
                ignored -> filterVoyages()
        );
    }


    private void showDepartureDialog() {
        if (departureList.isEmpty()) {
            UiUtils.toast(this, "No departure data");
            return;
        }

        List<String> leftList = new ArrayList<>();
        List<List<String>> rightGroupList = new ArrayList<>();

        for (Departure d : departureList) {
            leftList.add(d.country);
            rightGroupList.add(d.ports);
        }

        PickerUtils.showGroups(requireContext(), leftList, rightGroupList, (countryIndex, portIndex) -> {
            List<String> selectedPorts = rightGroupList.get(countryIndex);
            if (selectedPorts.isEmpty()) return;
            tvDepartureFrom.setText(selectedPorts.get(portIndex));
            filterVoyages();
        });
    }

    private void loadDepartures() {
        ApiUtils.get(this, "voyage/departure", result -> {
            JSONArray array = JsonUtils.parseArray(result.getData());
            if (array == null) return;

            departureList.clear();
            for (int i = 0; i < array.length(); i++) {
                JSONObject item = array.optJSONObject(i);
                if (item != null) departureList.add(new Departure(item));
            }
        });
        showDepartureDialog();
    }

    private void loadVoyages() {
        ApiUtils.get(this, "voyage", result -> {
            JSONArray array = JsonUtils.parseArray(result.getData());
            if (array == null) return;

            voyageList.clear();
            for (int i = 0; i < array.length(); i++) {
                JSONObject item = array.optJSONObject(i);
                if (item != null) voyageList.add(new Voyage(item));
            }
            filterVoyages();
        });
    }

    private void filterVoyages() {
        String keyword = UiUtils.getText(etSearch);
        String from = UiUtils.getText(tvDepartureFrom);
        String status = spStatus.getSelectedItem().toString();

        rowList.clear();

        for (Voyage v : voyageList) {
            String voyageNumber = v.voyageNumber == null
                    ? "" : v.voyageNumber;
            if (!voyageNumber.contains(keyword)) continue;
            if (FormatUtils.hasText(from) && !from.equals(v.departurePortName)) continue;

            if (cbDepartureDate.isChecked() && FormatUtils.hasText(departureDate) && !departureDate.equals(v.departureTime))
                continue;
            if (cbArrivalDate.isChecked() && FormatUtils.hasText(arrivalDate) && !arrivalDate.equals(arrivalTime(v)))
                continue;
            if (!status.equals("All") && !status.equals(v.status)) continue;

            rowList.add(v);
        }

        rowList.sort(Comparator.comparing(this::isArrived).reversed().thenComparing(this::arrivalTime));

        adapter.notifyDataSetChanged();
        tvNumberOfVoyages.setText(rowList.size() + " voyages found");
    }

    private String arrivalTime(Voyage v) {
        if (FormatUtils.hasText(v.actualArrivalTime)) return v.actualArrivalTime;
        if (FormatUtils.hasText(v.newEstimatedArrivalTime)) return v.newEstimatedArrivalTime;

        return FormatUtils.hasText(v.estimatedArrivalTime)
                ? v.estimatedArrivalTime : "";
    }

    private boolean isArrived(Voyage voyage) {
        return "Arrived".equals(voyage.status);
    }
}
