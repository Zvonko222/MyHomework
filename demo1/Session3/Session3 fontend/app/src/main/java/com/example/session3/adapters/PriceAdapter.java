package com.example.session3.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.session3.R;
import com.example.session3.models.Price;

import java.util.ArrayList;
import java.util.List;
import java.util.zip.Inflater;

public class PriceAdapter extends RecyclerView.Adapter<PriceAdapter.ViewHolder> {
    List<Price> prices = new ArrayList<>();
    public PriceAdapter(List<Price> prices){
        this.prices = prices;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_price,parent,false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Price price = prices.get(position);
        holder.tvDate.setText(price.getDate());
        holder.tvPaid.setText(price.getPaid());


    }

    @Override
    public int getItemCount() {
        return prices.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder{
        private TextView tvDate,tvPaid;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);

            tvDate = itemView.findViewById(R.id.tv_item_price_date);
            tvPaid = itemView.findViewById(R.id.tv_item_price_paid);

        }
    }
}
