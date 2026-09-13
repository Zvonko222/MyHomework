package com.example.session3.activities;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.session3.R;
import com.example.session3.tools.ApiRequest;

import org.json.JSONException;
import org.json.JSONObject;

public class MainActivity extends AppCompatActivity {
    private Button btnLogin;
    private EditText etUsername, etPassword;

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

        btnLogin = findViewById(R.id.btn_login);
        etUsername = findViewById(R.id.et_username);
        etPassword = findViewById(R.id.et_password);


        btnLogin.setOnClickListener(v -> {
            JSONObject jo = new JSONObject();
            try {

                String uid = etUsername.getText().toString();
                String pwd = etPassword.getText().toString();
                jo.put("username", uid);
                jo.put("password", pwd);
                new Thread(() -> {
                    String result = ApiRequest.post("login", jo.toString());

                    try {
                        JSONObject _jo = new JSONObject(result);
                        boolean isSuccess = _jo.getBoolean("success");
                        if(!isSuccess){
                            String msg = _jo.getString("message");
                            Toast.makeText(this, msg, Toast.LENGTH_SHORT).show();
                        }
                        if(isSuccess){
                            Intent intent = new Intent(MainActivity.this, ListingActivity.class);
                            startActivity(intent);
                        }
                    } catch (JSONException e) {
                        Log.e("TAG", "JSON ERROR", e);
                    }
                }).start();

            } catch (Exception e) {
                Log.e("HTTP", "GET ERROR ", e);

            }
        });


//        btnLogin.setOnClickListener(v->{
//            new Thread(()->{
//                String result = ApiRequest.get("test");
//                runOnUiThread(()->{
//
//                    Toast.makeText(this, result, Toast.LENGTH_SHORT).show();
//                });
//
//            }).start();
//        });
    }
}