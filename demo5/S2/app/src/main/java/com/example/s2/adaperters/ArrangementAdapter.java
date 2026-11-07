package com.example.s2.adaperters;


import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.s2.R;
import com.example.s2.models.ArrangementModel;

import java.util.ArrayList;
import java.util.List;

public class ArrangementAdapter extends RecyclerView.Adapter<ArrangementAdapter.ViewHolder> {
    List<ArrangementModel> list = new ArrayList<>();

    public ArrangementAdapter(List<ArrangementModel> arrangementlist) {
        this.list   = arrangementlist;
    }

    @NonNull
    @Override
    public ArrangementAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_arrangement,parent,false );
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ArrangementAdapter.ViewHolder holder, int position) {
        ArrangementModel model = list.get(position);

        holder.stationId.setText(model.getStationId()+"-");
        holder.totalAmount.setText(model.getTotalAmount()+"-");
        holder.openTime.setText(model.getOpenTime()+"-");
        holder.checkoutTime.setText(model.getCheckoutTime()+"-");

    }

    @Override
    public int getItemCount() {
        return list.size();
    }
//       stationId = o.StationId
//       //openTime = o.OpenTime,
//       //checkoutTime = o.CheckOutTime,
//       //totalAmount = o.TotalAmount,
//       //isCheckout = o.IsCheckout
    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView stationId,openTime,checkoutTime,totalAmount,isCheckout;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            stationId = itemView.findViewById(R.id.tv_item_station_number);
            openTime= itemView.findViewById(R.id.tv_item_start_time);
            checkoutTime = itemView.findViewById(R.id.tv_item_checkout_time);
            totalAmount = itemView.findViewById(R.id.tv_item_total);
        }
    }
}
