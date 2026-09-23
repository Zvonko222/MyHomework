package com.example.s2.activities;

import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.GravityCompat;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.viewpager2.widget.ViewPager2;

import com.example.s2.R;
import com.example.s2.adpters.ArrangementAdapter;
import com.example.s2.adpters.SlideShowAdapter;
import com.example.s2.models.Arrangement;
import com.example.s2.tools.ApiRequest;
import com.example.s2.tools.ApiResult;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.IOException;
import java.lang.reflect.Type;
import java.util.Arrays;
import java.util.List;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;

public class HomeActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_home);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });



        ViewPager2 vp  = findViewById(R.id.vp_home);
        RecyclerView rv = findViewById(R.id.rv_home);
        ImageView imgTab = findViewById(R.id.img_home);
        DrawerLayout drawer = findViewById(R.id.main);

        List<Integer> vpList = Arrays.asList(
                R.drawable.store_01,
                R.drawable.store_02,
                R.drawable.store_03
        );

        imgTab.setOnClickListener(v->{
            drawer.openDrawer(GravityCompat.START);
        });

        // RecyclerView
        rv.setLayoutManager(new LinearLayoutManager(this));
        ApiRequest.get("home/arrangement", new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {
                e.printStackTrace();
            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                String json = response.body().string();
                Type type = new TypeToken<ApiResult<List<Arrangement>>>(){}.getType();
                ApiResult<List<Arrangement>> result = new Gson().fromJson(json,type);
                int code = result.getCode();
                if(code !=200){
                    runOnUiThread(()->{
                        Toast.makeText(HomeActivity.this, result.getMsg(), Toast.LENGTH_SHORT).show();
                    });
                    return;
                }
                List<Arrangement> arrangementList = result.getData();
                runOnUiThread(()->{
                    ArrangementAdapter arrangementAdapter = new ArrangementAdapter(arrangementList);
                    rv.setAdapter(arrangementAdapter);
                });

            }
        });


        // Slide Show
        SlideShowAdapter adapter = new SlideShowAdapter(vpList);
        vp.setAdapter(adapter);

        Handler handler = new Handler();
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                int position = vp.getCurrentItem();
                position++;
                if (position >= vpList.size()) {
                    position = 0;
                }
                vp.setCurrentItem(position);
                handler.postDelayed(this,3000);
            }
        };
        handler.postDelayed(runnable,3000);

        String staffId = getIntent().getStringExtra("staffId");
        Log.d("TAG", "getIntent staffId : "+staffId);


    }
}