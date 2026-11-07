package com.example.myapplication.ui.login;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.myapplication.R;
import com.example.myapplication.ui.home.HomeActivity;
import com.example.myapplication.util.api.ApiUtils;
import com.example.myapplication.util.FormatUtils;
import com.example.myapplication.util.UiUtils;
import com.example.myapplication.util.UserUtils;

import org.json.JSONObject;

public class LoginActivity extends AppCompatActivity {

    private Button btnLogin;
    private EditText etUsername, etPassword;
    private TextView tvForget;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_login);
        View view = findViewById(R.id.main);

        ViewCompat.setOnApplyWindowInsetsListener(view, (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        initView(view);
        checkLogin();
        initListener();
    }

    private void initListener() {
        tvForget.setOnClickListener(v -> UiUtils.toast(this, "Not realized"));

        btnLogin.setOnClickListener(v -> onLogin());
    }

    private void onLogin() {
        String username = etUsername.getText().toString();
        String password = etPassword.getText().toString();

        if (!FormatUtils.hasText(username) || !FormatUtils.hasText(password)) {
            UiUtils.toast(this, "Enter username and password");
            return;
        }

        JSONObject json = new JSONObject();
        try {
            json.put("username", username);
            json.put("password", password);
        } catch (Exception ignored) {
        }
        ApiUtils.get("test",result -> {
            Log.e("TAG", "onLogin: msg "+result.getMsg());
        });

        ApiUtils.post("login", json, result -> {
            if (!result.isSuccess()) {
                UiUtils.toast(this, result.getMsg());
                return;
            }
            int id = FormatUtils.parseInt(result.getData());

            UserUtils.saveLogin(this, username, password, id);
            UiUtils.toast(this, result.getMsg());
            startActivity(new Intent(this, HomeActivity.class));
        });
    }

    private void checkLogin() {
        etUsername.setText(UserUtils.getUsername(this));
        etPassword.setText(UserUtils.getPassword(this));
    }

    private void initView(View view) {
        btnLogin = view.findViewById(R.id.btn_login);
        etUsername = view.findViewById(R.id.et_username_login);
        etPassword = view.findViewById(R.id.et_password_login);
        tvForget = view.findViewById(R.id.tv_forget_password_login);
    }
}
