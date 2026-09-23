package com.example.s2.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.drawerlayout.widget.DrawerLayout;

import com.example.s2.R;
import com.example.s2.tools.ApiRequest;
import com.google.gson.Gson;
import com.google.gson.JsonObject;

import java.io.IOException;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;

public class MainActivity extends AppCompatActivity {

    private boolean verified = false;
    private int errorTag = 0;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {

            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        Button btnLogin = findViewById(R.id.btn_main_login);
        EditText etStaffId = findViewById(R.id.et_main_staff_id);
        EditText etPassword = findViewById(R.id.et_main_password);
        DrawerLayout drawer = findViewById(R.id.drawer);

        // Login Token
        SharedPreferences sp = getSharedPreferences("user",MODE_PRIVATE);
        boolean isLogin = sp.getBoolean("isLogin",false);
        if(isLogin){
            String staffId = sp.getString("staffId",null);
            Intent intent = new Intent(this, HomeActivity.class);
            intent.putExtra("staffId",staffId);
            startActivity(intent);
            finish();
        }

        // Slide block
        drawer.addDrawerListener(new DrawerLayout.DrawerListener() {
            @Override
            public void onDrawerSlide(@NonNull View drawerView, float slideOffset) {
                if (slideOffset >= 0.5f) {
                    verified = true;
                }
            }

            @Override
            public void onDrawerOpened(@NonNull View drawerView) {
                verified = true;
            }

            @Override
            public void onDrawerClosed(@NonNull View drawerView) {
                verified = false;
            }

            @Override
            public void onDrawerStateChanged(int newState) {

            }
        });

        btnLogin.setOnClickListener(v -> {
            // Slide verification
            if(errorTag >= 3){
                if (!verified) {
                    Toast.makeText(this, "Complete Slide Block Please", Toast.LENGTH_SHORT).show();
                    errorTag = 0;
                    return;
                }

            }

            String staffId = etStaffId.getText().toString();
            String password = etPassword.getText().toString();

            JsonObject jo = new JsonObject();
            jo.addProperty("staffId", staffId);
            jo.addProperty("password", password);


            ApiRequest.post("login", jo.toString(), new Callback() {
                @Override
                public void onFailure(@NonNull Call call, @NonNull IOException e) {
                    e.printStackTrace();
                }

                @Override
                public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                    String result = response.body().string();
                    JsonObject jo = new Gson().fromJson(result, JsonObject.class);
                    String msg = jo.get("msg").getAsString();

                    int code = jo.get("code").getAsInt();
                    if (code != 200) {
                        Log.d("TAG", "code : " + code);
                        runOnUiThread(()->{
                            Toast.makeText(MainActivity.this, msg, Toast.LENGTH_SHORT).show();
                        });
                        errorTag++;
                        return;
                    }
                    String staffId = jo.get("data").getAsString();
//                    Log.d("TAG", "staffId : "+staffId);
//                    Log.d("TAG", "msg : "+msg);

                    runOnUiThread(()->{
                        Toast.makeText(MainActivity.this, msg, Toast.LENGTH_SHORT).show();
                    });
                    Intent intent = new Intent(MainActivity.this, HomeActivity.class);
                    intent.putExtra("staffId", staffId);
                    startActivity(intent);
                    finish();

                    getSharedPreferences("user",MODE_PRIVATE)
                            .edit()
                            .putString("staffId",staffId)
                            .putBoolean("isLogin",true)
                            .apply();

                }
            });


        });

    }
}