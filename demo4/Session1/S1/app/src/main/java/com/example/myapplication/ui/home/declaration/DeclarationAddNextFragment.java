package com.example.myapplication.ui.home.declaration;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.fragment.app.Fragment;

import com.example.myapplication.R;
import com.example.myapplication.data.model.DeclarationDraft;
import com.example.myapplication.data.model.Option;
import com.example.myapplication.ui.home.HomeActivity;
import com.example.myapplication.util.api.ApiUtils;
import com.example.myapplication.util.DialogUtils;
import com.example.myapplication.util.DutyUtils;
import com.example.myapplication.util.FormatUtils;
import com.example.myapplication.util.api.JsonUtils;
import com.example.myapplication.util.NavUtils;
import com.example.myapplication.util.TextChangeUtils;
import com.example.myapplication.util.UiUtils;

import org.json.JSONArray;
import org.json.JSONObject;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.Random;

public class DeclarationAddNextFragment extends Fragment {
    private EditText etQuantity, etCargoTotal;
    private Spinner spUnit;
    private TextView tvDuty;
    private View btnPreviousPage, btnSubmit;
    private final List<Option> unitList = new ArrayList<>();

    private HomeActivity home;
    private DeclarationDraft draft;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_declaration_add_next, container, false);

        home = (HomeActivity) requireActivity();
        draft = home.getDeclarationDraft();
        initView(view);

        initListener();
        restoreDraft();
        updateTotal();
        loadUnits();
        return view;
    }

    private void initListener() {
        TextChangeUtils.onChanged(etQuantity, text -> draft.quantityText = text.trim());
        TextChangeUtils.onChanged(etCargoTotal, text -> {
            draft.amountText = text.trim();
            updateTotal();
        });
        btnPreviousPage.setOnClickListener(v -> NavUtils.back(this));
        btnSubmit.setOnClickListener(v -> {
            if (!checkRequired()) return;
            DialogUtils.confirm(
                    requireContext(),
                    "Are you sure to submit?",
                    this::submitDeclaration);
        });
    }

    private void initView(View view) {
        etQuantity = view.findViewById(R.id.et_declaration_add_next_quantity);
        spUnit = view.findViewById(R.id.sp_declaration_add_next_unit);
        etCargoTotal = view.findViewById(R.id.tv_declaration_add_next_cargo_total);
        tvDuty = view.findViewById(R.id.tv_declaration_add_next_duty);
        btnPreviousPage = view.findViewById(R.id.btn_declaration_add_next_previous_page);
        btnSubmit = view.findViewById(R.id.btn_declaration_add_next_submit);
    }

    private void restoreDraft() {
        etQuantity.setText(draft.quantityText);
        etCargoTotal.setText(draft.amountText);
    }

    private void loadUnits() {
        ApiUtils.get(this, "unit", result -> {
            JSONArray array = JsonUtils.parseArray(result.getData());
            if (array == null) return;

            unitList.clear();
            for (int i = 0; i < array.length(); i++) {
                JSONObject item = array.optJSONObject(i);
                if (item != null) unitList.add(new Option(item));
            }
            bindUnit();
        });
    }

    private void bindUnit() {
        int selected = 0;
        for (int i = 0; i < unitList.size(); i++) {
            if (unitList.get(i).id == draft.unitId) {
                selected = i;
                break;
            }
        }
        UiUtils.bindSpinner(spUnit, Option.names(unitList), selected,
                position -> draft.unitId = unitList.get(position).id);
    }

    private void updateTotal() {
        draft.cargoAmount = parseAmount(draft.amountText);
        draft.dutyPayable = 0;

        if (draft.cargoAmount < 1) {
            if (FormatUtils.hasText(draft.amountText)) {
                UiUtils.toast(this, "Amount must be at least 1");
            }
        } else if (!FormatUtils.hasText(draft.hsCode)
                || !FormatUtils.hasText(draft.countryOfOrigin)
                || draft.tradeModeId <= 0) {
            UiUtils.toast(this, "Complete the previous page");
        } else {
            draft.dutyPayable = DutyUtils.calculate(draft.cargoAmount, draft.hsRate, draft.countryRate,
                    draft.tradeRate, draft.tradeModeName);
        }
        tvDuty.setText(String.format(Locale.US, "Duty: %.2f CNY", draft.dutyPayable));
    }

    private boolean checkRequired() {
        if (parseQuantity() < 1) {
            UiUtils.toast(this, "Quantity must be an integer and at least 1");
            return false;
        }
        if (draft.unitId <= 0) {
            UiUtils.toast(this, "Select the unit");
            return false;
        }
        draft.cargoAmount = parseAmount(draft.amountText);
        if (draft.cargoAmount < 1) {
            UiUtils.toast(this, "Cargo amount must be at least 1");
            return false;
        }
        return true;
    }

    private void submitDeclaration() {
        JSONObject json = new JSONObject();
        try {
            json.put("id", createDeclarationId());
            json.put("containerNumber", draft.containerNumber);
            json.put("hsCode", draft.hsCode);
            json.put("countryOfOrigin", draft.countryOfOrigin);
            json.put("tradeMode", draft.tradeModeId);
            json.put("description", draft.description);
            json.put("quantity", parseQuantity());
            json.put("unitId", draft.unitId);
            json.put("cargoAmount", draft.cargoAmount);
            json.put("dutyPayable", draft.dutyPayable);
        } catch (Exception e) {
            Log.e("TAG", "submitDeclaration: JSON ERROR", e);
            return;
        }
        ApiUtils.post(this, "declaration/add", json, ignored -> {
            home.clearDeclarationDraft();
            NavUtils.clear(requireActivity());
        });
    }

    private String createDeclarationId() {
        Random r = new Random();
        String newVoyageNumber = "CDA"
                + new SimpleDateFormat("yyyyMMdd").format(new Date())
                + (char) ('A' + r.nextInt(26))
                + String.format("%04d", r.nextInt(10000));

        return newVoyageNumber;
    }

    private double parseAmount(String text) {
        try {
            double value = Double.parseDouble(text.trim());
            return Double.isFinite(value) && value >= 1 ? value : -1;
        } catch (NumberFormatException e) {
            return -1;
        }
    }

    private int parseQuantity() {
        try {
            return Integer.parseInt(draft.quantityText);
        } catch (NumberFormatException e) {
            return 0;
        }
    }

}
