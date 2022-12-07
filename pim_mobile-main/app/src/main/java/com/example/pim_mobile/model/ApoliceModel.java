package com.example.pim_mobile.model;

import com.google.gson.annotations.SerializedName;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Date;

public class ApoliceModel {
    @SerializedName("id")
    private int id;
    @SerializedName("planoId")
    private int planoId;
    @SerializedName("automovel")
    private AutomovelModel automovel;
    @SerializedName("clienteNome")
    private String clienteNome;
    @SerializedName("planoNome")
    private String planoNome;
    @SerializedName("planoValor")
    private float planoValor;
    @SerializedName("tempoVigencia")
    private int tempoVigencia;
    @SerializedName("formaPagamento")
    private int formaPagamento;
    @SerializedName("dataCriacao")
    private String  dataCriacao;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public AutomovelModel getAutomovel() {
        return automovel;
    }

    public void setAutomovel(AutomovelModel automovel) {
        this.automovel = automovel;
    }

    public String getClienteNome() {
        return clienteNome;
    }

    public void setClienteNome(String clienteNome) {
        this.clienteNome = clienteNome;
    }

    public String getPlanoNome() {
        return planoNome;
    }

    public void setPlanoNome(String planoNome) {
        this.planoNome = planoNome;
    }

    public float getPlanoValor() {
        return planoValor;
    }

    public void setPlanoValor(float planoValor) {
        this.planoValor = planoValor;
    }

    public int getTempoVigencia() {
        return tempoVigencia;
    }

    public void setTempoVigencia(int tempoVigencia) {
        this.tempoVigencia = tempoVigencia;
    }

    public int getFormaPagamento() {
        return formaPagamento;
    }

    public void setFormaPagamento(int formaPagamento) {
        this.formaPagamento = formaPagamento;
    }

    public String getDataCriacao() {
        return dataCriacao;
    }

    public void setDataCriacao(String dataCriacao) {
        this.dataCriacao = dataCriacao;
    }

    public int getPlanoId() {
        return planoId;
    }

    public void setPlanoId(int planoId) {
        this.planoId = planoId;
    }
}
