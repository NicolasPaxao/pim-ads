package com.example.pim_mobile.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.pim_mobile.R;
import com.example.pim_mobile.model.AssistenciasModel;
import com.example.pim_mobile.model.CoberturaModel;

import java.util.ArrayList;

public class CoberturaAdapter extends RecyclerView.Adapter<CoberturaAdapter.MyViewHolder>{
    public ArrayList<CoberturaModel> myValues ;
    public CoberturaAdapter (ArrayList<CoberturaModel> myValues){
        this.myValues= myValues;
    }

    @Override
    public CoberturaAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View listItem = LayoutInflater.from(parent.getContext()).inflate(R.layout.card_cobertura, parent, false);
        return new CoberturaAdapter.MyViewHolder(listItem);
    }

    @Override
    public void onBindViewHolder(@NonNull CoberturaAdapter.MyViewHolder holder, int position) {
        holder.mNome.setText(myValues.get(position).getNome());
        holder.mIndenizacao.setText(String.format("%s%%", Integer.toString(myValues.get(position).getIndenizacao())));
        holder.mDescricao.setText(String.format("DESCRIÇÃO: %s", myValues.get(position).getDescriacao()));
    }

    @Override
    public int getItemCount() {
        return myValues.size();
    }

    public static class MyViewHolder extends RecyclerView.ViewHolder {
        private TextView mNome;
        private TextView mIndenizacao;
        private TextView mDescricao;
        public MyViewHolder(View itemView) {
            super(itemView);
            mNome = (TextView)itemView.findViewById(R.id.cobertura_name);
            mIndenizacao = (TextView)itemView.findViewById(R.id.indenizacao_name);
            mDescricao = (TextView)itemView.findViewById(R.id.description_title_cobertura);
        }
    }
}
