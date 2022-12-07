package com.example.pim_mobile.view;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.pim_mobile.model.AssistenciasModel;
import com.example.pim_mobile.model.ClienteModel;
import com.example.pim_mobile.model.CoberturaModel;
import com.example.pim_mobile.model.Consts;
import com.example.pim_mobile.model.UsuarioModel;
import com.example.pim_mobile.services.GetAssistencias;
import com.example.pim_mobile.services.GetCoberturas;
import com.example.pim_mobile.services.RetrofitClient;
import com.example.pim_mobile.viewmodel.LoginViewModel;
import com.example.pim_mobile.R;
import com.example.pim_mobile.services.GetClient;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {

    private GetClient mGetClient = RetrofitClient.createService(GetClient.class);
    private GetCoberturas mGetCoberturas = RetrofitClient.createService(GetCoberturas.class);
    private GetAssistencias mGetAssistencias = RetrofitClient.createService(GetAssistencias.class);
    private Button mButtonLogin;
    private EditText mEditEmail;
    private EditText mEditPassword;

    @Override
    public void onBackPressed() {
        //super.onBackPressed();
        finish();
        System.exit(0);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_NO);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        if(getSupportActionBar() != null){
            getSupportActionBar().hide();
        }

        this.mButtonLogin = findViewById(R.id.btnLogin);
        this.mEditEmail = findViewById(R.id.inputEmail);
        this.mEditPassword = findViewById(R.id.inputSenha);
        final LoginViewModel loginViewModel = new ViewModelProvider(this).get(LoginViewModel.class);
        Call<UsuarioModel> clients =  this.mGetClient.login();
        Call<List<AssistenciasModel>> assistencias = this.mGetAssistencias.getAssistencias();
        Call<List<CoberturaModel>> coberturas = this.mGetCoberturas.getCoberturas();

        this.mButtonLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String email = mEditEmail.getText().toString();
                String password = mEditPassword.getText().toString();
                loginViewModel.login(email, password);
                mEditEmail.setText("");
                mEditPassword.setText("");
            }
        });

        loginViewModel.mLogin.observe(this, new Observer<Boolean>() {
            @Override
            public void onChanged(Boolean success) {
                if(success){
                    Intent intent = new Intent(LoginActivity.this, HomePageActivity.class);
                    Toast.makeText(getApplicationContext(), "Sucesso!", Toast.LENGTH_SHORT).show();
                    startActivity(intent);
                }else{
                    Toast.makeText(getApplicationContext(), "Insira seu login corretamente.", Toast.LENGTH_SHORT).show();
                }
            }
        });

        clients.enqueue(new Callback<UsuarioModel>() {
            @Override
            public void onResponse(Call<UsuarioModel> call, Response<UsuarioModel> response) {
                Consts.usuarioModel = response.body();
                Toast.makeText(getApplicationContext(), "Cliente", Toast.LENGTH_SHORT).show();
            }
            @Override
            public void onFailure(Call<UsuarioModel> call, Throwable t) {
                Toast.makeText(getApplicationContext(), t.toString(), Toast.LENGTH_SHORT).show();
            }
        });

        assistencias.enqueue(new Callback<List<AssistenciasModel>>() {
            @Override
            public void onResponse(Call<List<AssistenciasModel>> call, Response<List<AssistenciasModel>> response) {
                Consts.assistenciasModels = response.body();
                Toast.makeText(getApplicationContext(), "Assistencias", Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<List<AssistenciasModel>> call, Throwable t) {
                Toast.makeText(getApplicationContext(), t.toString(), Toast.LENGTH_SHORT).show();
            }
        });

        coberturas.enqueue(new Callback<List<CoberturaModel>>() {
            @Override
            public void onResponse(Call<List<CoberturaModel>> call, Response<List<CoberturaModel>> response) {
                Consts.coberturaModels = response.body();
                Toast.makeText(getApplicationContext(), "Coberturas", Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<List<CoberturaModel>> call, Throwable t) {
                Toast.makeText(getApplicationContext(), t.toString(), Toast.LENGTH_SHORT).show();
            }
        });

    }
}