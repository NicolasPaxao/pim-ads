package com.example.pim_mobile.view;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;


import com.example.pim_mobile.R;


public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        if(getSupportActionBar() != null){
            getSupportActionBar().hide();
        }

        new Handler().postDelayed(new Runnable(){
            @Override
            public void run() {
                Intent navegar = new Intent(MainActivity.this, LoginActivity.class);
                startActivity(navegar);
                finish();
            }
       },3000);
    }
}