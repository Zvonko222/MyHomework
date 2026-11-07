package com.example.myapplication.util;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;

import com.example.myapplication.R;

public class NavUtils {

    public static void open(FragmentActivity activity, Fragment fragment) {
        activity.getSupportFragmentManager()
                .beginTransaction()
                .replace(R.id.fragment_container, fragment)
                .addToBackStack(null)
                .commit();
    }


    public static void back(Fragment fragment) {
        fragment.requireActivity().getSupportFragmentManager().popBackStack();
    }

    public static void clear(FragmentActivity activity) {
        activity.getSupportFragmentManager()
                .popBackStack(null, FragmentManager.POP_BACK_STACK_INCLUSIVE);
    }
}
