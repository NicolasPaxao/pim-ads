package com.example.pim_mobile.model;

import com.google.gson.annotations.SerializedName;

public class AssistenciasModel {
    @SerializedName("id")
    private int id;
    @SerializedName("idPlano")
    private int idPlano;
    @SerializedName("nome")
    private String nome;
    @SerializedName("empresaSuporte")
    private String empresaSuporte;
    @SerializedName("descriacao")
    private String descriacao;
    @SerializedName("contato")
    private String contato;

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

    public String getEmpresaSuporte() {
        return empresaSuporte;
    }

    public void setEmpresaSuporte(String empresaSuporte) {
        this.empresaSuporte = empresaSuporte;
    }

    public String getDescriacao() {
        return descriacao;
    }

    public void setDescriacao(String descriacao) {
        this.descriacao = descriacao;
    }

    public String getContato() {
        return contato;
    }

    public void setContato(String contato) {
        this.contato = contato;
    }
}
