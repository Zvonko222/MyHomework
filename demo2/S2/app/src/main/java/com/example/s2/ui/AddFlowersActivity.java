package com.example.s2.ui;

import android.os.Bundle;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.s2.R;
import com.example.s2.data.model.Flower;
import com.example.s2.data.model.Station;
import com.example.s2.util.network.ApiRequest;
import com.example.s2.util.network.ApiResult;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.IOException;
import java.lang.reflect.Type;
import java.util.List;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;

public class AddFlowersActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_add_flowers);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        TextView tvTitle = findViewById(R.id.tv_add_flowers_title);
//        * @param stationId
//                * @param hasVase
//                * @param numberOfPeople
        // get intent data
        String stationId = getIntent().getStringExtra("stationId");
        boolean hasVase = getIntent().getBooleanExtra("hasVase",false);
        int numberOfPeople = getIntent().getIntExtra("numberOfPeople",0);

        // init ui
        tvTitle.setText(stationId);

        // get request
        ApiRequest.get("station/flower", new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {
                e.printStackTrace();
            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                String json = response.body().string();
                Type type = new TypeToken<ApiResult<List<Station>>>(){}.getType();
                ApiResult<List<Flower>> result = new Gson().fromJson(json,type);
                int code = result.getCode();
                String msg = result.getMsg();

                // request is not found
                if(code != 200){
                    Toast.makeText(AddFlowersActivity.this, msg , Toast.LENGTH_SHORT).show();
                    return;
                }
            }
        });
    }
}