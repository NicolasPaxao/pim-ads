package com.example.pim_mobile.view;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.pim_mobile.R;
import com.example.pim_mobile.adapters.CarsAdapter;
import com.example.pim_mobile.model.ApoliceModel;
import com.example.pim_mobile.model.AutomovelModel;
import com.example.pim_mobile.model.Consts;

import android.content.Context;
import android.content.Intent;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.function.Consumer;

public class AutomoveisActivity extends AppCompatActivity {
    private Button backButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_automoveis);

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

        ArrayList<AutomovelModel> myValues = new ArrayList<AutomovelModel>();
        List<ApoliceModel> apolices = Consts.usuarioModel.getApolices();

        for (int i = 0; i < apolices.size(); i++) {
            myValues.add(apolices.get(i).getAutomovel());
        }
        CarsAdapter adapter = new CarsAdapter(myValues);
        RecyclerView myView =  (RecyclerView)findViewById(R.id.recyclerview);
        myView.setHasFixedSize(false);
        myView.setAdapter(adapter);
        LinearLayoutManager llm = new LinearLayoutManager(this);
        llm.setOrientation(LinearLayoutManager.VERTICAL);
        myView.setLayoutManager(llm);

    }
}