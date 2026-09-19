package com.example.session3.activities;

import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.session3.R;
import com.example.session3.adapters.PropertyAdapter;
import com.example.session3.models.Property;
import com.example.session3.tools.ApiRequest;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class ListingActivity extends AppCompatActivity {

    private RecyclerView recyclerView;
    private Button btnEnd;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_listing);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        btnEnd = findViewById(R.id.btn_end);
        List<Property> properties = new ArrayList<>();
        recyclerView = findViewById(R.id.recyclerView);

        PropertyAdapter adapter = new PropertyAdapter(properties);
        recyclerView.setAdapter(adapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        btnEnd.setOnClickListener(v->{
            finishAffinity();
        });

        int userId = getIntent().getIntExtra("data",0);


        new Thread(() -> {


            try {
                Log.d("HTTP", "userId =  "+userId);

                String result = ApiRequest.post("property?userId="+userId,"");
                Log.d("HTTP", "result =  "+result);
                JSONObject _jo = new JSONObject(result);

                int code = _jo.getInt("code");
                if(code == 200){
                    JSONArray ja = _jo.getJSONArray("data");
                    
                    for (int i = 0; i < ja.length(); i++) {
                        JSONObject jo = ja.getJSONObject(i);
                        Property property = new Property();
                        property.title = jo.getString("itemTitle");
                        property.date = jo.getString("date");
                        property.id = jo.getInt("itemId");
                        property.minimumNights = jo.getInt("minimumNights");
                        property.maximumNights = jo.getInt("maximumNights");
                        property.isInnerFiveDay = jo.getBoolean("isInnerFiveDay");
                        property.userId = jo.getInt("userId");
                        properties.add(property);
                    }
                    runOnUiThread(()->{
                        adapter.notifyDataSetChanged();

                    });
                }
            } catch (Exception e) {
                Log.e("TAG", "JSON ERROR ", e);
            }

        }).start();
    }
}