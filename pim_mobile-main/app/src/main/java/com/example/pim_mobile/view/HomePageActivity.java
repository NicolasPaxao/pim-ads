package com.example.pim_mobile.view;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.TextView;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;

import com.example.pim_mobile.R;
import com.example.pim_mobile.model.Consts;
import com.google.android.material.navigation.NavigationView;

import java.util.Objects;

public class HomePageActivity extends AppCompatActivity {
    Toolbar toolbar;
    private DrawerLayout drawerLayout;
    private NavigationView navigationView;
    private Button btnCarList;
    private Button btnPlanList;
    private TextView mHelloUser;
    private String name = Consts.usuarioModel.getCliente().getNome();
    private String razaoSocial = Consts.usuarioModel.getCliente().getRazaoSocial();

    @Override
    public void onBackPressed() {
        //super.onBackPressed();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home_page);

        toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        Objects.requireNonNull(getSupportActionBar()).setDisplayShowTitleEnabled(false);

        this.btnCarList = findViewById(R.id.btnCarsList);
        this.btnPlanList = findViewById(R.id.btnPlanList);
        this.mHelloUser = (TextView) findViewById(R.id.helloUser);

        if(this.name != null || this.name != "")
            mHelloUser.setText("Olá, " + this.name);
        else
            mHelloUser.setText("Olá, " + this.razaoSocial);

        drawerLayout = findViewById(R.id.drawer_layout);
        final ActionBar actionBar = getSupportActionBar();
        assert actionBar != null;
        actionBar.setDisplayHomeAsUpEnabled(true);
        actionBar.setHomeAsUpIndicator(R.drawable.ic_menu);

        navigationView = findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener((item) ->{
            switch (item.getItemId()){
                case R.id.showPrivacy:
                    drawerLayout.closeDrawer(Gravity.LEFT);
                    showPrivacyDialog();
                    break;
                case R.id.showAbout:
                    drawerLayout.closeDrawer(Gravity.LEFT);
                    showAboutDialog();
                    break;
                case R.id.showHelp:
                    drawerLayout.closeDrawer(Gravity.LEFT);
                    showHelpDialog();
                    break;
                case R.id.showLogout:
                    drawerLayout.closeDrawer(Gravity.LEFT);
                    showLogoutDialog();
            }
            return false;
        });

        this.btnCarList.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(HomePageActivity.this, AutomoveisActivity.class);
                startActivity(intent);
            }
        });

        this.btnPlanList.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(HomePageActivity.this, PlanoActivity.class);
                startActivity(intent);
            }
        });
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            drawerLayout.openDrawer(GravityCompat.START);
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    void showAboutDialog(){
        final Dialog dialog = new Dialog(HomePageActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(true);
        dialog.setContentView(R.layout.about_dialog);
        Button btnClose = (Button) dialog.findViewById(R.id.closeDialog);
        btnClose.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dialog.dismiss();
            }
        });
        dialog.show();
    }

    void showPrivacyDialog(){
        final Dialog dialog = new Dialog(HomePageActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(true);
        dialog.setContentView(R.layout.privacy_dialog);
        Button btnClose = (Button) dialog.findViewById(R.id.closeDialog);
        btnClose.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dialog.dismiss();
            }
        });
        dialog.show();
    }

    void showHelpDialog(){
        final Dialog dialog = new Dialog(HomePageActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(true);
        dialog.setContentView(R.layout.help_dialog);
        Button btnClose = (Button) dialog.findViewById(R.id.closeDialog);
        btnClose.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dialog.dismiss();
            }
        });
        dialog.show();
    }

    void showLogoutDialog(){
        final Dialog dialog = new Dialog(HomePageActivity.this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setCancelable(true);
        dialog.setContentView(R.layout.logout_dialog);
        Button btnExit = (Button) dialog.findViewById(R.id.exitButton);
        Button btnClose = (Button) dialog.findViewById(R.id.closeDialog);
        Consts.usuarioModel = null;
        btnClose.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dialog.dismiss();
            }
        });
        btnExit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(HomePageActivity.this, LoginActivity.class);
                startActivity(intent);
            }
        });
        dialog.show();
    }

}