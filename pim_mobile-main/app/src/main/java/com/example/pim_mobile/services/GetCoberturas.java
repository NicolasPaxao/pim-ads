package com.example.pim_mobile.services;

import com.example.pim_mobile.model.ApoliceModel;
import com.example.pim_mobile.model.CoberturaModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface GetCoberturas {
    @GET("/NicolasPaxao/cdfb110a540928fd37f487601efd5ac7/raw/5fe4f4edc35f4e01a6bc5ac88b33f370c9aa4737/coberturas.json")
    Call<List<CoberturaModel>> getCoberturas();
}
