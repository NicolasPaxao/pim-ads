package com.example.pim_mobile.adapters;

import android.annotation.SuppressLint;
import android.media.Image;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.pim_mobile.OnListClick;
import com.example.pim_mobile.R;
import com.example.pim_mobile.model.ApoliceModel;
import com.example.pim_mobile.model.FormaPagamento;
import com.example.pim_mobile.model.UsuarioModel;

import java.util.ArrayList;

public class ApolicesAdapter extends RecyclerView.Adapter<ApolicesAdapter.MyViewHolder>{
    public ArrayList<ApoliceModel> myValues ;
    public OnListClick onListClick;
    public ApolicesAdapter (ArrayList<ApoliceModel> myValues, OnListClick listener){
        this.myValues= myValues;
        this.onListClick = listener;
    }

    @Override
    public ApolicesAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View listItem = LayoutInflater.from(parent.getContext()).inflate(R.layout.card_apolice, parent, false);
        return new ApolicesAdapter.MyViewHolder(listItem);
    }

    @SuppressLint("SetTextI18n")
    @Override
    public void onBindViewHolder(@NonNull ApolicesAdapter.MyViewHolder holder, int position) {
        int formaPagemento = myValues.get(position).getFormaPagamento();
        String fp = FormaPagamento.values()[formaPagemento].toString();
        holder.mId.setText(Integer.toString(myValues.get(position).getId()));
        holder.mCarroModelo.setText(myValues.get(position).getAutomovel().getModelo());
        holder.mPlano.setText(myValues.get(position).getPlanoNome());
        holder.mContratante.setText(myValues.get(position).getClienteNome());
        holder.mDataCriacao.setText(myValues.get(position).getDataCriacao());
        holder.mTempoVigencia.setText(Integer.toString(myValues.get(position).getTempoVigencia()));
        holder.mValor.setText(Float.toString(myValues.get(position).getPlanoValor()));
        holder.mFormaPagamento.setText(fp);
        holder.bind(myValues.get(position), onListClick);
    }

    @Override
    public int getItemCount() {
        return myValues.size();
    }

    public static class MyViewHolder extends RecyclerView.ViewHolder {
        private TextView mId;
        private TextView mCarroModelo;
        private TextView mPlano;
        private TextView mContratante;
        private TextView mDataCriacao;
        private TextView mTempoVigencia;
        private TextView mValor;
        private TextView mFormaPagamento;
        private ImageButton mBtnDetails;
        public MyViewHolder(View itemView) {
            super(itemView);
            mId = (TextView)itemView.findViewById(R.id.id_apolice);
            mCarroModelo = (TextView)itemView.findViewById(R.id.automovel_name);
            mPlano = (TextView)itemView.findViewById(R.id.plano_name);
            mContratante = (TextView)itemView.findViewById(R.id.contratante_name);
            mDataCriacao = (TextView)itemView.findViewById(R.id.dt_contratacao_name);
            mTempoVigencia = (TextView)itemView.findViewById(R.id.tempo_name);
            mValor = (TextView)itemView.findViewById(R.id.vl_name);
            mFormaPagamento = (TextView)itemView.findViewById(R.id.pagamento_title_name);
            mBtnDetails = (ImageButton)itemView.findViewById(R.id.go_details_btn);
        }
        public void bind (final ApoliceModel apolice, final OnListClick listener){
            mBtnDetails.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    listener.OnClick(apolice.getPlanoId());
                }
            });
        }
    }
}
