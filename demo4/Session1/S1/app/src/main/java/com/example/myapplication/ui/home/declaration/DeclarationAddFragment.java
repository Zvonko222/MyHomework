package com.example.myapplication.ui.home.declaration;

import android.graphics.Color;
import android.os.Bundle;
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
import com.example.myapplication.util.FormatUtils;
import com.example.myapplication.util.api.JsonUtils;
import com.example.myapplication.util.NavUtils;
import com.example.myapplication.util.PickerUtils;
import com.example.myapplication.util.TextChangeUtils;
import com.example.myapplication.util.UiUtils;
import com.example.myapplication.util.UserUtils;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class DeclarationAddFragment extends Fragment {

    private EditText etVoyageNumber, etContainerNumber, etHsCode, etCountry, etDescription;
    private TextView tvArrivalDate, tvContainerTips;
    private Spinner spTradeMode;
    private View btnSearchContainer, btnNextPage;

    private final List<Option> hsCodeList = new ArrayList<>();
    private final List<Option> countryList = new ArrayList<>();
    private final List<Option> tradeModeList = new ArrayList<>();
    private DeclarationDraft draft;
    private int userId = -1;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_declaration_add, container, false);

        userId = UserUtils.getUserId(requireContext());
        draft = ((HomeActivity) requireActivity()).getDeclarationDraft();

        initView(view);
        restoreDraft();
        initListener();
        loadOptions();

        return view;
    }

    private void initView(View view) {
        etVoyageNumber = view.findViewById(R.id.et_add_declaration_voyage_number);
        etContainerNumber = view.findViewById(R.id.et_add_declaration_container_number);
        etHsCode = view.findViewById(R.id.et_add_declaration_hs_code);
        etCountry = view.findViewById(R.id.et_add_declaration_country);
        etDescription = view.findViewById(R.id.et_add_declaration_description);
        tvArrivalDate = view.findViewById(R.id.tv_declaration_add_estimated_arrival_date);
        tvContainerTips = view.findViewById(R.id.tv_declaration_add_container_tips);
        spTradeMode = view.findViewById(R.id.sp_add_declaration_trade_mode);
        btnSearchContainer = view.findViewById(R.id.btn_add_declaration_search_container);
        btnNextPage = view.findViewById(R.id.btn_add_declaration_next_page);
    }

    private void initListener() {
        etVoyageNumber.setOnFocusChangeListener((v, hasFocus) -> {
            if (!hasFocus && !UiUtils.getText(etVoyageNumber).isEmpty()) {
                checkVoyage();
            }
        });

        TextChangeUtils.onChanged(etVoyageNumber, text -> {
            draft.voyageNumber = text;
            clearContainerState();
            tvArrivalDate.setText("Estimated Arrival Date: --");
        });

        TextChangeUtils.onChanged(etContainerNumber, text -> {
            draft.containerNumber = text;
            clearContainerState();
        });

        TextChangeUtils.onChanged(etDescription, text -> draft.description = text);

        btnSearchContainer.setOnClickListener(v -> searchContainer());
        btnNextPage.setOnClickListener(v -> openNextPage());


        etHsCode.setOnClickListener(v -> selectHsCode());
        etCountry.setOnClickListener(v -> selectCountry());
    }

    private void restoreDraft() {
        etVoyageNumber.setText(draft.voyageNumber);
        etContainerNumber.setText(draft.containerNumber);
        etHsCode.setText(draft.hsCode);
        etCountry.setText(draft.countryName);
        etDescription.setText(draft.description);
    }

    private void selectCountry() {
        if (countryList.isEmpty()) {
            UiUtils.toast(this, "Country loading, please wait");
            return;
        }

        PickerUtils.show(requireContext(), Option.names(countryList), index -> {
            Option item = countryList.get(index);

            etCountry.setText(item.name);
            draft.countryName = item.name;
            draft.countryOfOrigin = item.code;
            draft.countryRate = item.rate;
        });
    }

    private void selectHsCode() {
        if (hsCodeList.isEmpty()) {
            UiUtils.toast(this, "HS Code loading, please wait");
            return;
        }
        PickerUtils.showList(
                requireContext(),
                Option.codes(hsCodeList),
                Option.descriptions(hsCodeList),
                index -> {
                    Option item = hsCodeList.get(index);
                    etHsCode.setText(item.code);
                    draft.hsCode = item.code;
                    draft.hsRate = item.rate;
                }
        );
    }

    private void openNextPage() {
        if (!checkRequired()) return;
        NavUtils.open(requireActivity(), new DeclarationAddNextFragment());
    }

    private boolean checkRequired() {
        if (!FormatUtils.hasText(UiUtils.getText(etVoyageNumber))) {
            UiUtils.toast(this, "Enter the voyage number");
            return false;
        }
        if (!FormatUtils.hasText(UiUtils.getText(etContainerNumber))) {
            UiUtils.toast(this, "Enter the container number");
            return false;
        }
        if (!FormatUtils.hasText(draft.hsCode)) {
            UiUtils.toast(this, "Select the HS Code");
            return false;
        }
        if (!FormatUtils.hasText(draft.countryOfOrigin)) {
            UiUtils.toast(this, "Select the country of origin");
            return false;
        }
        if (draft.tradeModeId <= 0) {
            UiUtils.toast(this, "Select the trade mode");
            return false;
        }
        if (!FormatUtils.hasText(UiUtils.getText(etDescription))) {
            UiUtils.toast(this, "Enter the description");
            return false;
        }
        return true;
    }

    private void checkVoyage() {
        String voyageNumber = UiUtils.getText(etVoyageNumber);

        tvArrivalDate.setText("Estimated Arrival Date: --");

        ApiUtils.get(this, "declaration/voyage/" + voyageNumber, result -> {
            if (!voyageNumber.equals(UiUtils.getText(etVoyageNumber))) return;
            if (!result.isSuccess()) {
                UiUtils.toast(this, result.getMsg());
                return;
            }

            JSONObject data = JsonUtils.parseObject(result.getData());
            if (data == null) {
                UiUtils.toast(this, "Cannot load the voyage data");
                return;
            }

            boolean arrived = data.optBoolean("isArrived");

            String arrivalTime = data.optString("arrivalTime");

            String _text = arrived
                    ? "Actual Arrival Date: " : "Estimated Arrival Date: ";
            tvArrivalDate.setText(_text + arrivalTime);
        });
    }

    private void searchContainer() {
        String voyageNumber = UiUtils.getText(etVoyageNumber);
        String containerNumber = UiUtils.getText(etContainerNumber);

        if (!FormatUtils.hasText(voyageNumber)) {
            UiUtils.toast(this, "Enter the voyage number");
            return;
        }
        if (!FormatUtils.hasText(containerNumber)) {
            UiUtils.toast(this, "Enter the container number");
            return;
        }

        clearContainerState();

        ApiUtils.get(this,
                "declaration/container?voyageNumber=" + voyageNumber
                        + "&containerNumber=" + containerNumber
                        + "&userId=" + userId,
                result -> checkContainer(voyageNumber, containerNumber, result));
    }

    private void checkContainer(String voyageNumber, String containerNumber, ApiUtils.Result result) {
        boolean sameVoyage = voyageNumber.equals(UiUtils.getText(etVoyageNumber));
        boolean sameContainer = containerNumber.equals(UiUtils.getText(etContainerNumber));
        if (!sameVoyage || !sameContainer) return;

        tvContainerTips.setVisibility(View.VISIBLE);
        tvContainerTips.setTextColor(result.isSuccess() ? Color.GREEN : Color.RED);
        tvContainerTips.setText(result.getMsg());
    }

    private void clearContainerState() {
        tvContainerTips.setText("");
        tvContainerTips.setVisibility(View.GONE);
    }

    private void loadOptions() {
        loadTradeMode();
        loadHsCode();
        loadCountry();
    }

    private void loadTradeMode() {
        ApiUtils.get(this, "tradeMode", result -> {
            JSONArray array = JsonUtils.parseArray(result.getData());
            if (array == null) return;

            tradeModeList.clear();
            for (int i = 0; i < array.length(); i++) {
                JSONObject item = array.optJSONObject(i);
                if (item != null) tradeModeList.add(new Option(item));
            }
            bindTradeMode();
        });
    }

    private void bindTradeMode() {
        int selected = 0;

        for (int i = 0; i < tradeModeList.size(); i++) {
            if (tradeModeList.get(i).id == draft.tradeModeId) {
                selected = i;
                break;
            }
        }
        UiUtils.bindSpinner(spTradeMode, Option.names(tradeModeList), selected, position -> {
            Option item = tradeModeList.get(position);
            draft.tradeModeId = item.id;
            draft.tradeModeName = item.name;
            draft.tradeRate = item.rate;
        });
    }

    private void loadHsCode() {
        ApiUtils.get(this, "hscode", result -> {
            JSONArray array = JsonUtils.parseArray(result.getData());
            if (array == null) return;

            hsCodeList.clear();
            for (int i = 0; i < array.length(); i++) {
                JSONObject item = array.optJSONObject(i);
                if (item != null) hsCodeList.add(new Option(item));
            }
        });
    }

    private void loadCountry() {
        ApiUtils.get(this, "country", result -> {
            JSONArray array = JsonUtils.parseArray(result.getData());
            if (array == null) return;

            countryList.clear();
            for (int i = 0; i < array.length(); i++) {
                JSONObject item = array.optJSONObject(i);
                if (item != null) countryList.add(new Option(item));
            }
        });
    }
}
