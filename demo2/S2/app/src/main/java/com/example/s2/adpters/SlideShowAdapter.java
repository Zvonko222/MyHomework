package com.example.s2.adpters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.s2.R;

import java.util.List;

public class SlideShowAdapter extends RecyclerView.Adapter<SlideShowAdapter.ViewHolder> {
    List<Integer> list;
    public SlideShowAdapter(List<Integer> vpList) {
        list = vpList;
    }

    @NonNull
    @Override
    public SlideShowAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_main_slide_show,parent,false );
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull SlideShowAdapter.ViewHolder holder, int position) {
        int src = list.get(position);
        holder.img.setImageResource(src);
    }

    @Override
    public int getItemCount() {
        return list.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        ImageView img;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            img = itemView.findViewById(R.id.img_item_slide_show);
        }
    }
}
