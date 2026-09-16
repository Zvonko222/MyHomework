package com.example.session3.activities;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.session3.R;
import com.example.session3.adapters.PriceAdapter;
import com.example.session3.models.Price;
import com.example.session3.tools.ApiRequest;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class PriceActivity extends AppCompatActivity {
    private Button btnBack;
    private TextView tvTitle,tvCalendar1,tvCalendar2;
    private RecyclerView recyclerView;
    private ImageView imgCalendar1, imgCalendar2;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_price);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        btnBack = findViewById(R.id.btn_back_to_Listing);
        tvTitle = findViewById(R.id.tv_title_price);
        recyclerView = findViewById(R.id.recyclerview_price);
        tvCalendar1 = findViewById(R.id.tv_price_calendar_1);
        tvCalendar2 = findViewById(R.id.tv_price_calendar_2);

        List<Price> prices = new ArrayList<>();

        PriceAdapter adapter = new PriceAdapter(prices);
        recyclerView.setAdapter(adapter);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));


        imgCalendar1 = findViewById(R.id.img_price_calendar_1);
        imgCalendar2 = findViewById(R.id.img_price_calendar_2);

        int userId = getIntent().getIntExtra("userId",0);
        int itemId = getIntent().getIntExtra("itemId",0);

        imgCalendar1.setOnClickListener(v -> {
            Calendar calendar = Calendar.getInstance();

            int year = calendar.get(Calendar.YEAR);
            int month = calendar.get(Calendar.MONTH);
            int day = calendar.get(Calendar.DAY_OF_MONTH);

            DatePickerDialog dialog = new DatePickerDialog(this, ((view, year1, month1, dayOfMonth) -> {
                String date = year1 + "/" + month1 + "/" + dayOfMonth;
                Log.d("DATE", "Selected day = " + date);
                tvCalendar1.setText(date);
            }), year, month, day);
            dialog.show();
        });


        imgCalendar2.setOnClickListener(v -> {
            Calendar calendar = Calendar.getInstance();

            int year = calendar.get(Calendar.YEAR);
            int month = calendar.get(Calendar.MONTH);
            int day = calendar.get(Calendar.DAY_OF_MONTH);

            DatePickerDialog dialog = new DatePickerDialog(this, ((view, year1, month1, dayOfMonth) -> {
                String date = year1 + "/" + month1 + "/" + dayOfMonth;
                Log.d("DATE", "Selected day = " + date);
                tvCalendar2.setText(date);
            }), year, month, day);
            dialog.show();
        });

        new Thread(() -> {


            runOnUiThread(() -> {

                try {
                    JSONObject _jo = new JSONObject();
                    _jo.put("userId",userId );
                    _jo.put("itemId",itemId);

                    String result = ApiRequest.post("price",_jo.toString());


                    Log.d("HTTP", "result = " + result);
                    JSONObject _jo = new JSONObject(result);
                    int code = _jo.getInt("code");

                    if(code == 200){

                        JSONArray ja = _jo.getJSONArray("data");

                        for (int i = 0; i < ja.length(); i++) {
                            JSONObject jo = ja.getJSONObject(i);

                            Price price = new Price();
                            price.setPaid(jo.getString("paid"));
                            price.setDate(jo.getString("date"));

                            prices.add(price);
                        }
                        adapter.notifyDataSetChanged();
                    }
                } catch (JSONException e) {
                    Log.e("TAG", "JSON ERROR", e);
                }
            });
        }).start();

        btnBack.setOnClickListener(v -> {
            Intent intent = new Intent(PriceActivity.this, ListingActivity.class);
            startActivity(intent);
            finish();
        });
    }
}