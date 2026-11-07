package com.example.myapplication.ui.home.declaration;

import android.graphics.drawable.Drawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.core.content.ContextCompat;
import androidx.recyclerview.widget.RecyclerView;

import com.example.myapplication.R;
import com.example.myapplication.data.model.Declaration;
import com.example.myapplication.util.DialogUtils;
import com.example.myapplication.util.UiUtils;

import java.util.List;
import java.util.Locale;

public class DeclarationAdapter extends RecyclerView.Adapter<DeclarationAdapter.ViewHolder> {
    private final List<Declaration> rowList;

    public DeclarationAdapter(List<Declaration> rowList) {
        this.rowList = rowList;
    }

    @NonNull
    @Override
    public DeclarationAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_declaration, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull DeclarationAdapter.ViewHolder holder, int position) {
        Declaration item = rowList.get(position);

        boolean isRejected = "Rejected".equals(item.status);
        boolean isApproved = "Approved".equals(item.status);

        // set control text
        holder.tvDeclarationId.setText(item.declarationId);
        holder.tvVoyageNumber.setText("Voyage Number: " + item.voyageNumber);
        holder.tvContainerNumber.setText("Container Number: " + item.containerNumber);
        holder.tvCargoAmount.setText("Cargo Amount: " + String.format( "%.2f", item.cargoAmount));
        holder.tvDutyPayable.setText("Duty Payable: " + String.format("%.2f", item.dutyPayable));

        // get resource id
        int dutyColor = isApproved ? R.color.green : R.color.red;
        int bgStatus = isRejected ? R.drawable.bg_red : R.drawable.bg_green;


        // get color value
        int colorValue = ContextCompat.getColor(holder.itemView.getContext(),dutyColor);
        holder.tvDutyPayable.setTextColor(colorValue);

        // set control resource
        holder.tvStatus.setText(item.status);
        holder.tvStatus.setBackgroundResource(bgStatus);
        holder.tvStatus.setPadding(5, 5, 5, 5);

        holder.tvStatus.setVisibility(isRejected || isApproved ? View.VISIBLE : View.INVISIBLE);

        int visibleButton = isRejected ? View.VISIBLE : View.INVISIBLE;
        holder.btnModify.setVisibility(visibleButton);
        holder.btnReason.setVisibility(visibleButton);

        holder.btnReason.setOnClickListener(v -> DialogUtils.info(
                v.getContext(),
                "Rejected Reason",
                item.reason
        ));
        holder.btnModify.setOnClickListener(v -> UiUtils.toast(v.getContext(), "Does not realized"));
    }

    @Override
    public int getItemCount() {
        return rowList.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView tvDeclarationId, tvVoyageNumber, tvCargoAmount, tvContainerNumber, tvDutyPayable, tvStatus;
        Button btnModify, btnReason;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            initView(itemView);
        }

        private void initView(View itemView) {
            tvDeclarationId = itemView.findViewById(R.id.tv_item_declaration_id);
            tvCargoAmount = itemView.findViewById(R.id.tv_item_declaration_cargo_amount);
            tvVoyageNumber = itemView.findViewById(R.id.tv_item_declaration_voyage_number);
            tvContainerNumber = itemView.findViewById(R.id.tv_item_declaration_container_number);
            tvDutyPayable = itemView.findViewById(R.id.tv_item_declaration_duty_payable);

            tvStatus = itemView.findViewById(R.id.tv_item_declaration_status);
            btnModify = itemView.findViewById(R.id.btn_item_declaration_modify);
            btnReason = itemView.findViewById(R.id.btn_item_declaration_reason);
        }
    }
}
