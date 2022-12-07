package com.example.pim_mobile.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.pim_mobile.R;
import com.example.pim_mobile.model.AutomovelModel;
import com.example.pim_mobile.model.Consts;

import java.util.ArrayList;

public class CarsAdapter extends RecyclerView.Adapter<CarsAdapter.MyViewHolder> {
    public ArrayList<AutomovelModel> myValues ;
    public CarsAdapter (ArrayList<AutomovelModel> myValues){
        this.myValues= myValues;
    }

    @Override
    public MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View listItem = LayoutInflater.from(parent.getContext()).inflate(R.layout.card_automovel, parent, false);
        return new MyViewHolder(listItem);
    }

    @Override
    public void onBindViewHolder(@NonNull MyViewHolder holder, int position) {
        holder.mMarca.setText(myValues.get(position).getMarca());
        holder.mModelo.setText(myValues.get(position).getModelo());
        holder.mPlaca.setText(myValues.get(position).getPlaca());
        holder.mAnoModelo.setText(myValues.get(position).getAnoModelo());
        holder.mRenavam.setText(myValues.get(position).getRenavam());
        holder.mCor.setText(myValues.get(position).getCor());
    }

    @Override
    public int getItemCount() {
        return myValues.size();
    }

    public static class MyViewHolder extends RecyclerView.ViewHolder {
        private TextView mMarca;
        private TextView mModelo;
        private TextView mPlaca;
        private TextView mAnoModelo;
        private TextView mRenavam;
        private TextView mCor;
        public MyViewHolder(View itemView) {
            super(itemView);
            mMarca = (TextView)itemView.findViewById(R.id.car_marca);
            mRenavam = (TextView)itemView.findViewById(R.id.car_renavam);
            mPlaca = (TextView)itemView.findViewById(R.id.car_placa);
            mAnoModelo = (TextView)itemView.findViewById(R.id.car_ano);
            mModelo = (TextView)itemView.findViewById(R.id.model_card);
            mCor = (TextView)itemView.findViewById(R.id.car_color);
        }
    }
}
