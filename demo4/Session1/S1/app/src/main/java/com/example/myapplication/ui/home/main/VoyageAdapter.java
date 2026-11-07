package com.example.myapplication.ui.home.main;

import android.text.SpannableStringBuilder;
import android.text.Spanned;
import android.text.style.ForegroundColorSpan;
import android.text.style.StrikethroughSpan;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.core.content.ContextCompat;
import androidx.recyclerview.widget.RecyclerView;

import com.example.myapplication.R;
import com.example.myapplication.data.model.Voyage;
import com.example.myapplication.util.FormatUtils;
import com.example.myapplication.util.UiUtils;

import java.util.List;

public class VoyageAdapter extends RecyclerView.Adapter<VoyageAdapter.ViewHolder> {
    private final List<Voyage> rowList;

    public VoyageAdapter(List<Voyage> rowList) {
        this.rowList = rowList;
    }

    @NonNull
    @Override
    public VoyageAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_voyages, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull VoyageAdapter.ViewHolder holder, int position) {
        Voyage voyage = rowList.get(position);
        holder.tvVoyageNumber.setText(voyage.voyageNumber);
        holder.tvDepartureCountryName.setText(voyage.departureCountryName);
        holder.tvDeparturePortName.setText(voyage.departurePortName);
        holder.tvDestinationCountryName.setText(voyage.destinationCountryName);
        holder.tvDestinationPortName.setText(voyage.destinationPortName);
        holder.tvDepartureTime.setText("Departure Date:" + voyage.departureTime);

        String estimatedTime = voyage.estimatedArrivalTime;
        String actualTime = voyage.actualArrivalTime;
        String newTime = voyage.newEstimatedArrivalTime;
        boolean hasActual = FormatUtils.hasText(actualTime);
        boolean hasNew = FormatUtils.hasText(newTime);

        if (hasActual) {
            holder.tvArrivedTime.setText("Actual Arrival Date: " + actualTime);
        } else if (hasNew) {
            SpannableStringBuilder timeText = new SpannableStringBuilder();
            timeText.append("Estimated Arrival Date: ");

            int estimatedStart = timeText.length();
            timeText.append(estimatedTime);
            timeText.setSpan(
                    new StrikethroughSpan(),
                    estimatedStart,
                    timeText.length(),
                    Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

            timeText.append("  ");

            int newStart = timeText.length();
            timeText.append(newTime);
            timeText.setSpan(
                    new ForegroundColorSpan(ContextCompat.getColor(
                            holder.itemView.getContext(), R.color.deep_red)),
                    newStart,
                    timeText.length(),
                    Spanned.SPAN_EXCLUSIVE_EXCLUSIVE
            );
            holder.tvArrivedTime.setText(timeText);
        } else {
            holder.tvArrivedTime.setText("Estimated Arrival Date: " + estimatedTime);
        }

        if ("Arrived".equals(voyage.status)) {
            holder.tvStatus.setTextColor(ContextCompat.getColor(
                    holder.itemView.getContext(), R.color.forest_green));
        } else {
            holder.tvStatus.setTextColor(ContextCompat.getColor(
                    holder.itemView.getContext(), R.color.deep_teal));
        }
        holder.tvStatus.setText(voyage.status);
    }

    @Override
    public int getItemCount() {
        return rowList.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView tvVoyageNumber, tvStatus, tvDepartureCountryName, tvDeparturePortName, tvDestinationCountryName, tvDestinationPortName, tvDepartureTime, tvArrivedTime;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            initView(itemView);
        }

        private void initView(View itemView) {
            tvDepartureTime = itemView.findViewById(R.id.tv_item_departure_time);
            tvVoyageNumber = itemView.findViewById(R.id.tv_item_voyage_number);
            tvStatus = itemView.findViewById(R.id.tv_item_voyage_status);
            tvArrivedTime = itemView.findViewById(R.id.tv_item_arrival_time);
            tvDepartureCountryName = itemView.findViewById(R.id.tv_item_departure_country_name);
            tvDeparturePortName = itemView.findViewById(R.id.tv_item_departure_port_name);
            tvDestinationCountryName = itemView.findViewById(R.id.tv_item_destination_country_name);
            tvDestinationPortName = itemView.findViewById(R.id.tv_item_destination_port_name);
        }
    }
}
