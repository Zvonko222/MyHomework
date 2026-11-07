package com.example.s2.adaperters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.s2.R;

import java.util.ArrayList;
import java.util.List;

public class ViewpagerAdapter extends RecyclerView.Adapter<ViewpagerAdapter.ViewHolder>{
    List<Integer> list = new ArrayList<>();
    public ViewpagerAdapter(List<Integer> list) {
        this.list = list;
    }

    @NonNull
    @Override
    public ViewpagerAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_viewpager,parent,false   );
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewpagerAdapter.ViewHolder holder, int position) {
        int item = list.get(position);
        holder.img.setImageResource(item);
    }

    @Override
    public int getItemCount() {
        return list.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        ImageView img;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);

            img = itemView.findViewById(R.id.img_item_viewpager );
        }
    }
}
