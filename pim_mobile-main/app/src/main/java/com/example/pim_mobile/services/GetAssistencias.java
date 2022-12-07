package com.example.pim_mobile.services;

import com.example.pim_mobile.model.AssistenciasModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface GetAssistencias {
    @GET("/NicolasPaxao/1626d075a9f35fb055c755d5ff3c571b/raw/403d977a4c9d6dfd6518febae59e8e4d72e5af74/assistencias.json")
    Call<List<AssistenciasModel>> getAssistencias();
}
