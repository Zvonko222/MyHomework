package com.example.myapplication.ui.home.vehicle;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.myapplication.R;
import com.example.myapplication.data.model.Vehicle;

import java.util.List;

public class VehicleAdapter extends RecyclerView.Adapter<VehicleAdapter.ViewHolder> {
    private final List<Vehicle> rowList;
    private final OnReauthorizeListener listener;

    public interface OnReauthorizeListener {
        void onReauthorize(Vehicle vehicle);
    }

    public VehicleAdapter(List<Vehicle> rowList, OnReauthorizeListener listener) {
        this.rowList = rowList;
        this.listener = listener;
    }

    @NonNull
    @Override
    public VehicleAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_vehicle, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull VehicleAdapter.ViewHolder holder, int position) {
        Vehicle vehicle = rowList.get(position);

        holder.tvPlate.setText(vehicle.licensePlateNumber);
        holder.tvSize.setText(vehicle.length + "m x " + vehicle.width + "m");
        holder.tvCapacity.setText(vehicle.capacity + " ton");
        holder.tvStartDate.setText("Authorization Start Date: " + vehicle.startTime);
        holder.tvExpiredDate.setText("Authorization Expired Date: " + vehicle.expiredTime);

        holder.imgPhoto.setImageResource(R.drawable.no_picture);

        if (vehicle.isExpired()) {
            holder.tvExpired.setVisibility(View.VISIBLE);
            holder.btnReauthorize.setVisibility(View.VISIBLE);
        }
        holder.btnReauthorize.setOnClickListener(v -> listener.onReauthorize(vehicle));
    }

    @Override
    public int getItemCount() {
        return rowList.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        ImageView imgPhoto;
        TextView tvPlate, tvSize, tvCapacity, tvStartDate, tvExpiredDate, tvExpired;
        Button btnReauthorize;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            initView(itemView);
        }

        private void initView(View itemView) {
            imgPhoto = itemView.findViewById(R.id.img_item_vehicle_photo);
            tvPlate = itemView.findViewById(R.id.tv_item_vehicle_plate);
            tvSize = itemView.findViewById(R.id.tv_item_vehicle_size);
            tvCapacity = itemView.findViewById(R.id.tv_item_vehicle_capacity);
            tvStartDate = itemView.findViewById(R.id.tv_item_vehicle_start_date);
            tvExpiredDate = itemView.findViewById(R.id.tv_item_vehicle_expired_date);
            tvExpired = itemView.findViewById(R.id.tv_item_vehicle_expired);
            btnReauthorize = itemView.findViewById(R.id.btn_item_vehicle_reauthorize);
        }
    }
}
