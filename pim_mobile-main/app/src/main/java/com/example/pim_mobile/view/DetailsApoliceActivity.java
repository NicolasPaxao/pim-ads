package com.example.pim_mobile.view;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;

import com.example.pim_mobile.R;
import com.example.pim_mobile.adapters.AssistenciaAdapter;
import com.example.pim_mobile.adapters.CoberturaAdapter;
import com.example.pim_mobile.model.AssistenciasModel;
import com.example.pim_mobile.model.CoberturaModel;
import com.example.pim_mobile.model.Consts;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;

public class DetailsApoliceActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_details_apolice);

        final ActionBar actionBar = getSupportActionBar();
        assert actionBar != null;
        actionBar.setDisplayHomeAsUpEnabled(true);
        actionBar.setHomeAsUpIndicator(R.drawable.ic_arrow_back_white);
        actionBar.setBackgroundDrawable(new ColorDrawable(0xff397349));
        actionBar.setDisplayShowTitleEnabled(false);
        actionBar.setDisplayShowCustomEnabled(true);
        LayoutInflater inflator = (LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View v = inflator.inflate(R.layout.custom_imageview, null);
        actionBar.setCustomView(v);

        ArrayList<AssistenciasModel> myValues = new ArrayList<AssistenciasModel>();
        List<AssistenciasModel> assistencias = Consts.assistenciasModels;
        ArrayList<CoberturaModel> myValuesCobertura = new ArrayList<CoberturaModel>();
        List<CoberturaModel> coberturas = Consts.coberturaModels;

        int idPlano = this.getData();

        for (AssistenciasModel item: assistencias) {
            if(item.getIdPlano() == idPlano)
                myValues.add(item);
        }
        for (CoberturaModel item: coberturas) {
            if(item.getIdPlano() == idPlano)
                myValuesCobertura.add(item);
        }
        AssistenciaAdapter adapter = new AssistenciaAdapter(myValues);
        RecyclerView myViewAssist =  (RecyclerView)findViewById(R.id.recyclerview1);
        myViewAssist.setHasFixedSize(false);
        myViewAssist.setAdapter(adapter);

        CoberturaAdapter adapterCobertura = new CoberturaAdapter(myValuesCobertura);
        RecyclerView myViewCobertura =  (RecyclerView)findViewById(R.id.recyclerview2);
        myViewCobertura.setHasFixedSize(false);
        myViewCobertura.setAdapter(adapterCobertura);

        myViewAssist.setLayoutManager(new LinearLayoutManager(this));
        myViewCobertura.setLayoutManager(new LinearLayoutManager(this));

    }

    private int getData(){
        Bundle bundle = getIntent().getExtras();
        int id = 0;
        if(bundle != null){

            id = bundle.getInt("planId");
        }
        return id;
    }
}