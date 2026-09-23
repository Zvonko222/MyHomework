package com.example.s2.adpters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.s2.R;
import com.example.s2.models.Arrangement;

import java.util.List;

public class ArrangementAdapter extends RecyclerView.Adapter<ArrangementAdapter.ViewHolder> {
    private List<Arrangement> list;

    public ArrangementAdapter(List<Arrangement> list) {
        this.list = list;
    }

    @NonNull
    @Override
    public ArrangementAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_home_arrangement, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ArrangementAdapter.ViewHolder holder, int position) {
        Arrangement arrangement = list.get(position);
        //Station 01 - Start 10:10 - Checkout -- 96:00
        if (arrangement.getCheckoutTime() == null ){
            arrangement.setCheckoutTime("");
        }
        holder.tvItem.setText(
                "Station " +
                        arrangement.getStationId() +
                        " - Start " +
                        arrangement.getOpenTime() +
                        " - Checkout " +
                        arrangement.getCheckoutTime() +
                        " - " +
                        arrangement.getTotalAmount()
        );
    }

    @Override
    public int getItemCount() {
        return list.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView tvItem;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            tvItem = itemView.findViewById(R.id.tv_item_arrangement);
        }
    }
}
