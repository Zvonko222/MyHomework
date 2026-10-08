package com.example.s2.ui.station;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.s2.R;
import com.example.s2.ui.AddFlowersActivity;
import com.example.s2.util.network.ApiRequest;
import com.google.gson.JsonObject;

import java.io.IOException;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;

public class OpenStationActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_open_station);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        EditText etNumberOfPeople = findViewById(R.id.et_open_station_number_of_people);
        CheckBox cbHasVase = findViewById(R.id.cb_open_station_has_vase);
        Button btnOpenStation = findViewById(R.id.btn_open_station);

        // get intent data
        int stationId = getIntent().getIntExtra("stationId",-1);

        // onclick open station button
        btnOpenStation.setOnClickListener(v -> {
            int number;

            // check number is Integer
            try {
                number = Integer.parseInt(etNumberOfPeople.getText().toString());
            } catch (NumberFormatException e) {
                Toast.makeText(this, "Please enter number", Toast.LENGTH_SHORT).show();
                return;
            }
            boolean hasVase = cbHasVase.isChecked();

            // put data in intent
            JsonObject jo = new JsonObject();
            Intent intent = new Intent(this, AddFlowersActivity.class);
            intent.putExtra("numberOfPeople",number);
            intent.putExtra("hasVase",hasVase);
            intent.putExtra("stationId",stationId);

            /**
             * goto {@link AddFlowersActivity}
             * @param stationId
             * @param hasVase
             * @param numberOfPeople
             */
            startActivity(intent);

        });
    }
}