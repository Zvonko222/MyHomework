package com.example.s2.activties;

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

import com.example.s2.R;
import com.example.s2.tools.ApiRequest;

import org.json.JSONException;
import org.json.JSONObject;

public class MainActivity extends AppCompatActivity {

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

        Button btnLogin = findViewById(R.id.btn_login);
        EditText etStaffId = findViewById(R.id.et_staff_id);
        EditText etPassword = findViewById(R.id.et_password);

        btnLogin.setOnClickListener(v->{
            JSONObject jo = new JSONObject();
            try{
                jo.put("staffId",etStaffId.getText().toString());
                jo.put("password",etPassword.getText().toString());

            } catch (Exception e) {
                Log.e("TAG", "JSON ERROR ",e );
            }

            new Thread(()->{
                String result = ApiRequest.post("login",jo.toString());
                Log.d("TAG", "Result =  "+ result);

                // Result =  {"data":"S000001","code":200,"msg":"登入成功"}
                try {
                    JSONObject joResult = new JSONObject(result);
                    int code = joResult.getInt("code");
                    String staffId = joResult.getString("data");
                    String msg = joResult.getString("msg");
                    if(code != 200){
                        // no pass
                        runOnUiThread(()->{

                            Toast.makeText(this, msg, Toast.LENGTH_SHORT).show();
                        });
                        return;
                    }
                    // pass
                    runOnUiThread(()->{
                        Intent intent = new Intent(MainActivity.this, HomeActivity.class);
                        intent.putExtra("staffId",staffId);
                        startActivity(intent);
                        finish();
                    });

                } catch (JSONException e) {
                    Log.e("TAG", "JSON ERROR ",e );
                }
            }).start();


        });


    }
}