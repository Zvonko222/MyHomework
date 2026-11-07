package com.example.myapplication.ui.home.declaration;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageView;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.myapplication.R;
import com.example.myapplication.data.model.Declaration;
import com.example.myapplication.ui.home.HomeActivity;
import com.example.myapplication.util.api.ApiUtils;
import com.example.myapplication.util.api.JsonUtils;
import com.example.myapplication.util.NavUtils;
import com.example.myapplication.util.TextChangeUtils;
import com.example.myapplication.util.UiUtils;
import com.example.myapplication.util.UserUtils;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class DeclarationFragment extends Fragment {
    private final List<Declaration> declarationList = new ArrayList<>();
    private final List<Declaration> rowList = new ArrayList<>();
    private DeclarationAdapter adapter;
    private EditText etSearch;
    private View btnPending, btnRejected, btnApproved;
    private ImageView imgAdd;
    private String status = "Pending";
    private int userId;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_declaration, container, false);

        initView(view);
        userId = UserUtils.getUserId(requireContext());

        initRecyclerView(view);
        initListener(view);
        refreshStatusButtons();

        return view;
    }

    private void initListener(View view) {
        View.OnClickListener statusListener = v -> {
            if(v == btnPending){
                status = "Pending";
            } else if (v == btnRejected) {
                status = "Rejected";
            }else{
                status = "Approved";
            }
            refreshStatusButtons();
            filterDeclarations();
        };

        btnPending.setOnClickListener(statusListener);
        btnRejected.setOnClickListener(statusListener);
        btnApproved.setOnClickListener(statusListener);

        TextChangeUtils.onChanged(etSearch,text -> filterDeclarations());

        imgAdd.setOnClickListener(v -> {
            ((HomeActivity) requireActivity()).clearDeclarationDraft();
            NavUtils.open(requireActivity(), new DeclarationAddFragment());
        });
    }

    private void initRecyclerView(View view) {
        RecyclerView rv = view.findViewById(R.id.rv_declaration_customs_declarations);
        rv.setLayoutManager(new LinearLayoutManager(requireContext()));
        adapter = new DeclarationAdapter(rowList);
        rv.setAdapter(adapter);
    }

    private void initView(View view) {
        etSearch = view.findViewById(R.id.et_declaration_search_voyage_number_or_container_number);
        btnPending = view.findViewById(R.id.btn_declaration_pending);
        btnRejected = view.findViewById(R.id.btn_declaration_rejected);
        btnApproved = view.findViewById(R.id.btn_declaration_approved);
        imgAdd = view.findViewById(R.id.img_declaration_add_declaration);
    }

    @Override
    public void onResume() {
        super.onResume();
        loadDeclarations();
    }

    private void loadDeclarations() {
        ApiUtils.get(this, "declaration?userId=" + userId, result -> {
            JSONArray array = JsonUtils.parseArray(result.getData());
            if (array == null) return;

            declarationList.clear();
            for (int i = 0; i < array.length(); i++) {
                JSONObject item = array.optJSONObject(i);
                if (item != null) declarationList.add(new Declaration(item));
            }
            filterDeclarations();
        });
    }

    private void filterDeclarations() {
        String keyword = UiUtils.getText(etSearch);
        rowList.clear();

        for (Declaration d : declarationList) {
            if (!status.equals(d.status)) continue;

            boolean matchVoyage = d.voyageNumber !=null && d.voyageNumber.contains(keyword);
            boolean matchContainer = d.containerNumber !=null && d.containerNumber.contains(keyword);
            if(matchVoyage || matchContainer){
                rowList.add(d);
            }
        }
        adapter.notifyDataSetChanged();
    }

    private void refreshStatusButtons() {
        setStatusButton(btnPending, "Pending");
        setStatusButton(btnRejected, "Rejected");
        setStatusButton(btnApproved, "Approved");
    }

    private void setStatusButton(View button, String name) {
        button.setBackgroundResource(name.equals(status)
                ? R.drawable.bg_button_blue : R.drawable.bg_button_gray);
    }
}
