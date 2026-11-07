package com.example.myapplication.ui.home;

import android.os.Bundle;
import android.view.View;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.fragment.app.Fragment;

import com.example.myapplication.R;
import com.example.myapplication.data.model.DeclarationDraft;
import com.example.myapplication.ui.home.cargo.CargoFragment;
import com.example.myapplication.ui.home.declaration.DeclarationFragment;
import com.example.myapplication.ui.home.main.MainFragment;
import com.example.myapplication.ui.home.vehicle.VehicleFragment;
import com.example.myapplication.util.NavUtils;
import com.google.android.material.bottomnavigation.BottomNavigationView;

public class HomeActivity extends AppCompatActivity {

    private DeclarationDraft declarationDraft = new DeclarationDraft();
    private BottomNavigationView bottomNav;

    public DeclarationDraft getDeclarationDraft() {
        return declarationDraft;
    }

    public void clearDeclarationDraft() {
        declarationDraft = new DeclarationDraft();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_home);
        View view = findViewById(R.id.main);
        ViewCompat.setOnApplyWindowInsetsListener(view, (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, 0);
            return insets;
        });


        initView(view);

        bottomNav.setOnItemSelectedListener(item -> {
            Fragment fragment = pageOf(item.getItemId());
            if (fragment == null) return false;

            NavUtils.clear(this);

            getSupportFragmentManager()
                    .beginTransaction()
                    .replace(R.id.fragment_container, fragment)
                    .commit();
            return true;
        });

        if(savedInstanceState == null){
            bottomNav.setSelectedItemId(R.id.nav_main_menu);
        }
    }

    private Fragment pageOf(int itemId) {
        if (itemId == R.id.nav_main_menu) return new MainFragment();
        if (itemId == R.id.nav_declaration_menu) return new DeclarationFragment();
        if (itemId == R.id.nav_cargo_menu) return new CargoFragment();
        if (itemId == R.id.nav_vehicle) return new VehicleFragment();
        return null;
    }

    private void initView(View view) {
        bottomNav = view.findViewById(R.id.bottom_nav);
    }
}
