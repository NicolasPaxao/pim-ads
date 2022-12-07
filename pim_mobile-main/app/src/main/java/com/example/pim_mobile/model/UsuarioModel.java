package com.example.pim_mobile.model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class UsuarioModel {
    @SerializedName("cliente")
    private ClienteModel cliente;

    @SerializedName("apolices")
    private List<ApoliceModel> apolices;

    public ClienteModel getCliente() {
        return cliente;
    }

    public void setCliente(ClienteModel cliente) {
        this.cliente = cliente;
    }

    public List<ApoliceModel> getApolices() {
        return apolices;
    }

    public void setApolices(List<ApoliceModel> apolices) {
        this.apolices = apolices;
    }
}
