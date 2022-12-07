package com.example.pim_mobile.services;

import com.example.pim_mobile.model.ClienteModel;
import com.example.pim_mobile.model.UsuarioModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface GetClient {
    @GET("/NicolasPaxao/b9f487c36c17ebe43038a37143d84ebc/raw/663c3520862e01926bc99fabe0aa3034430ae91d/cliente.json")
    Call<UsuarioModel> login();
}
