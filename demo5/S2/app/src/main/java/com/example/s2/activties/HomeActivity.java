package com.example.s2.activties;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.viewpager2.widget.ViewPager2;

import com.example.s2.R;
import com.example.s2.adaperters.ArrangementAdapter;
import com.example.s2.adaperters.ViewpagerAdapter;
import com.example.s2.models.ArrangementModel;

import java.util.ArrayList;
import java.util.List;

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

        String staffId = getIntent().getStringExtra("staffId");
        Log.d("TAG", "staffId = "+staffId);

        // ViewPager
        List<Integer> list = new ArrayList<>();
        list.add(R.drawable.store_1);
        list.add(R.drawable.store_2);
        list.add(R.drawable.store_3);

        ViewPager2 vp = findViewById(R.id.viewpager2);
        ViewpagerAdapter adapter = new ViewpagerAdapter(list);
        vp.setAdapter(adapter);
        // loop
        Handler handler = new Handler();
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                int position = vp.getCurrentItem();
                if(position>=3){
                    position=0;
                }
                position++;
                handler.postDelayed(this,3000);
                vp.setCurrentItem(position);
            }
        };
        handler.postDelayed(runnable,300);
        //Recyclerview
        //工作台编号、开始时间、结账时间、总金额。未结账的工作台显示在上方，按开始时间升序排列；已结账的
        //工作台显示在下方，按结账时间降序排列
        //       stationId = o.StationId
        //       //openTime = o.OpenTime,
        //       //checkoutTime = o.CheckOutTime,
        //       //totalAmount = o.TotalAmount,
        //       //isCheckout = o.IsCheckout
        RecyclerView recyclerView = findViewById(R.id.recyclerview_home);
        ArrangementModel model = new ArrangementModel();
        model.setIsCheckout(false);
        model.setCheckoutTime("12:22");
        model.setOpenTime("08:22");
        model.setStationId("station 01");
        model.setTotalAmount("222.00");

        List<ArrangementModel> arrangementlist = new ArrayList<>();
        arrangementlist.add(model);

        ArrangementAdapter adapter1 = new ArrangementAdapter(arrangementlist);

        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        recyclerView.setAdapter(adapter1);

        // drawer

        TextView tvStaffId = findViewById(R.id.tv_drawer_staff_id);
        tvStaffId.setText( "Staff ID:"+staffId);

        TextView tvStationList = findViewById(R.id.tv_drawer_station_list);
        tvStationList.setOnClickListener(v->{
            Intent intent = new Intent(HomeActivity.this, StationActivity.class);
            startActivity(intent);
            finish();
        });
        TextView tvSaleData = findViewById(R.id.tv_drawer_sale_data_statistics);
        tvSaleData.setOnClickListener(v->{
            Intent intent = new Intent(HomeActivity.this,SaleDataActivity.class );
            startActivity(intent);
            finish();
        });
        TextView tvLogout = findViewById(R.id.tv_drawer_logout);
        tvLogout.setOnClickListener(v->{
            Intent intent = new Intent(HomeActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        });
    }
}