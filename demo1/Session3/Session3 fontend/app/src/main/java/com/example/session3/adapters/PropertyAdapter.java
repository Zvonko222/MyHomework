package com.example.session3.adapters;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.graphics.Color;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import com.example.session3.R;
import com.example.session3.activities.PriceActivity;
import com.example.session3.models.Property;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class PropertyAdapter extends RecyclerView.Adapter<PropertyAdapter.ViewHolder> {
    private List<Property> properties = new ArrayList<>();
    public PropertyAdapter(List<Property> properties){
        this.properties = properties;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_properties,parent,false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {

        Property property = properties.get(position);
        holder.tvPropertyName.setText(property.title);
        holder.tvPropertyData.setText("Last date of pricing:" + property.date);

        if(property.isInnerFiveDay){
            holder.tvPropertyName.setTextColor(Color.parseColor("#F44336"));
            holder.tvPropertyData.setTextColor(Color.parseColor("#F44336"));
        }

        holder.cvPropertySet.setOnClickListener(v->{
            //set
            Intent intent = new Intent(holder.itemView.getContext(), PriceActivity.class);
            intent.putExtra("userId",property.userId);
            intent.putExtra("itemId",property.id);
            Log.d("TAG", "PropertyAdapter itemId = "+property.id);
            holder.itemView.getContext().startActivity(intent);
        });

    }

    @Override
    public int getItemCount() {
        return properties.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder {

        private CardView cvPropertySet;
        private TextView tvPropertyName, tvPropertyData;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);

            cvPropertySet = itemView.findViewById(R.id.cv_property_set);
            tvPropertyName = itemView.findViewById(R.id.tv_item_property_name);
            tvPropertyData = itemView.findViewById(R.id.tv_item_property_data);
        }
    }

}
