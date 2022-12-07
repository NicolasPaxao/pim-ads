package com.example.pim_mobile.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.pim_mobile.R;
import com.example.pim_mobile.model.AssistenciasModel;

import java.util.ArrayList;

public class AssistenciaAdapter extends RecyclerView.Adapter<AssistenciaAdapter.MyViewHolder>{
    public ArrayList<AssistenciasModel> myValues ;
    public AssistenciaAdapter (ArrayList<AssistenciasModel> myValues){
        this.myValues= myValues;
    }

    @Override
    public AssistenciaAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View listItem = LayoutInflater.from(parent.getContext()).inflate(R.layout.card_assistencia, parent, false);
        return new MyViewHolder(listItem);
    }

    @Override
    public void onBindViewHolder(@NonNull AssistenciaAdapter.MyViewHolder holder, int position) {
        holder.mNome.setText(myValues.get(position).getNome());
        holder.mEmpresa.setText(myValues.get(position).getEmpresaSuporte());
        holder.mDescricao.setText(String.format("DESCRIÇÃO: %s", myValues.get(position).getDescriacao()));
        holder.mContato.setText(myValues.get(position).getContato());
    }

    @Override
    public int getItemCount() {
        return myValues.size();
    }

    public static class MyViewHolder extends RecyclerView.ViewHolder {
        private TextView mNome;
        private TextView mEmpresa;
        private TextView mDescricao;
        private TextView mContato;
        public MyViewHolder(View itemView) {
            super(itemView);
            mNome = (TextView)itemView.findViewById(R.id.assist_name);
            mEmpresa = (TextView)itemView.findViewById(R.id.empresa_name);
            mDescricao = (TextView)itemView.findViewById(R.id.description_name_assist);
            mContato = (TextView)itemView.findViewById(R.id.contato_name);
        }
    }
}
