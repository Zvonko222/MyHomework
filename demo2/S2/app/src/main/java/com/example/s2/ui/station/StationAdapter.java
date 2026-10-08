package com.example.s2.ui.station;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.PopupMenu;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import com.example.s2.R;
import com.example.s2.ui.AddFlowersActivity;
import com.example.s2.data.model.Station;
import com.example.s2.util.network.ApiRequest;
import com.example.s2.util.network.ApiResult;
import com.google.gson.Gson;
import com.google.gson.JsonObject;
import com.google.gson.reflect.TypeToken;

import java.io.IOException;
import java.util.List;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;

public class StationAdapter extends RecyclerView.Adapter<StationAdapter.ViewHolder> {
    private final List<Station> stations;


    public StationAdapter(List<Station> stations) {
        this.stations = stations;
    }

    @NonNull
    @Override
    public StationAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_station, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull StationAdapter.ViewHolder holder, int position) {
        Station station = stations.get(position);

        holder.tvStationId.setText("Station " + station.getStationId());
        holder.tvMaximumPeople.setText("Maximum People:" + station.getMaximumPeople());

        if (!station.isEnable()) {
            holder.tvBtn.setText("Unavilable");
            holder.cvStation.setCardBackgroundColor(Color.GRAY);

        } else if (!station.isCheckout()) {
            holder.tvBtn.setText("Occupied");
            holder.cvStation.setCardBackgroundColor(Color.RED);
            holder.cvStation.setOnLongClickListener(v -> {
                PopupMenu popupMenu = new PopupMenu(v.getContext(),holder.cvStation );
                popupMenu.getMenu().add("Check Out");
                popupMenu.getMenu().add("Add Flowers");

                popupMenu.setOnMenuItemClickListener(item->{
                    if(item.getTitle().equals("Check Out")){
//                        Toast.makeText(v.getContext(), "Check Out Station" + station.getStationId() , Toast.LENGTH_SHORT).show();
                        JsonObject jo = new JsonObject();
                        jo.addProperty("stationId",station.getStationId());

                        ApiRequest.post("station/checkout", jo.toString(), new Callback() {
                            @Override
                            public void onFailure(@NonNull Call call, @NonNull IOException e) {
                                e.printStackTrace();
                            }

                            @Override
                            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {

                                // restart data
                                ApiResult<Object> result = new Gson().fromJson(
                                        response.body().string(),
                                        new TypeToken<ApiResult<Object>>(){}.getType()
                                );
                                if(result.getCode() != 200 ){
                                    ((Activity)v.getContext()).runOnUiThread(()->{
                                        Toast.makeText(v.getContext(), result.getMsg(), Toast.LENGTH_SHORT).show();
                                    });
                                    return;
                                }

                                Intent intent = new Intent(v.getContext(),StationActivity.class );
                                v.getContext().startActivity(intent);
                                ((Activity)v.getContext()).finish();
                            }
                        });
                    }else if(item.getTitle().equals("Add Flowers")){
                        Intent intent = new Intent(v.getContext(), AddFlowersActivity.class);
                        intent.putExtra("stationId",station.getStationId());
                        v.getContext().startActivity(intent);
                    }
                    return true;
                });
                popupMenu.show();
                return true;
            });
        } else {
            holder.tvBtn.setText("Free");
            holder.cvStation.setCardBackgroundColor(Color.WHITE);

            // onclick free button to OpenStationActivity context
            holder.tvBtn.setOnClickListener(v->{
                Intent intent = new Intent(v.getContext(), OpenStationActivity.class);
                intent.putExtra("stationId",station.getStationId());
                v.getContext().startActivity(intent);
            });
        }


    }

    @Override
    public int getItemCount() {
        return stations.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView tvStationId, tvMaximumPeople, tvBtn;
        CardView cvStation;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            tvStationId = itemView.findViewById(R.id.tv_item_station_station_id);
            tvMaximumPeople = itemView.findViewById(R.id.tv_item_station_maximum_people);
            tvBtn = itemView.findViewById(R.id.tv_item_station_btn);
            cvStation = itemView.findViewById(R.id.cv_item_station);
        }
    }
}
