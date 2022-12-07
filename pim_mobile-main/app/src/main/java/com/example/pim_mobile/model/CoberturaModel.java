package com.example.pim_mobile.model;

import com.google.gson.annotations.SerializedName;

public class CoberturaModel {
    @SerializedName("id")
    private int id;
    @SerializedName("idPlano")
    private int idPlano;
    @SerializedName("nome")
    private String nome;
    @SerializedName("descriacao")
    private String descriacao;
    @SerializedName("indenizacao")
    private int indenizacao;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getIdPlano() {
        return idPlano;
    }

    public void setIdPlano(int idPlano) {
        this.idPlano = idPlano;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getDescriacao() {
        return descriacao;
    }

    public void setDescriacao(String descriacao) {
        this.descriacao = descriacao;
    }

    public int getIndenizacao() {
        return indenizacao;
    }

    public void setIndenizacao(int indenizacao) {
        this.indenizacao = indenizacao;
    }
}
