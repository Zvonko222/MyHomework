package com.example.s2.ui.station;

import android.os.Bundle;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.s2.R;
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

public class StationActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_station);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        RecyclerView rvStation = findViewById(R.id.rv_station);
        GridLayoutManager layoutManager = new GridLayoutManager(this,2);
        rvStation.setLayoutManager(layoutManager);

        ApiRequest.get("station", new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {
                e.printStackTrace();
            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                String json = response.body().string();
                Type type = new TypeToken<ApiResult<List<Station>>>(){}.getType();
                ApiResult<List<Station>> result = new Gson().fromJson(json,type);
                int code = result.getCode();
                String msg = result.getMsg();
                if(code != 200){
                    runOnUiThread(()->{
                        Toast.makeText(StationActivity.this, msg, Toast.LENGTH_SHORT).show();
                    });
                    return;
                }
                List<Station> stations = result.getData();
                runOnUiThread(()->{
                    StationAdapter adapter = new StationAdapter(stations);
                    rvStation.setAdapter(adapter);
                });

            }
        });
    }
}