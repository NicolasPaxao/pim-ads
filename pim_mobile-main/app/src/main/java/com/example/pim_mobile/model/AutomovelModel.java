package com.example.pim_mobile.model;

import com.google.gson.annotations.SerializedName;


public class AutomovelModel {
    @SerializedName("id")
    private int id;
    @SerializedName("idCliente")
    private int idCliente;
    @SerializedName("modelo")
    private String modelo;
    @SerializedName("marca")
    private String marca;
    @SerializedName("anoModelo")
    private String anoModelo;
    @SerializedName("cor")
    private String cor;
    @SerializedName("placa")
    private String placa;
    @SerializedName("renavam")
    private String renavam;
    @SerializedName("numeroMotor")
    private String numeroMotor;
    @SerializedName("crlv")
    private String crlv;
    @SerializedName("status")
    private Status status;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(int idCliente) {
        this.idCliente = idCliente;
    }

    public String getModelo() {
        return modelo;
    }

    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    public String getMarca() {
        return marca;
    }

    public void setMarca(String marca) {
        this.marca = marca;
    }

    public String getAnoModelo() {
        return anoModelo;
    }

    public void setAnoModelo(String anoModelo) {
        this.anoModelo = anoModelo;
    }

    public String getCor() {
        return cor;
    }

    public void setCor(String cor) {
        this.cor = cor;
    }

    public String getPlaca() {
        return placa;
    }

    public void setPlaca(String placa) {
        this.placa = placa;
    }

    public String getRenavam() {
        return renavam;
    }

    public void setRenavam(String renavam) {
        this.renavam = renavam;
    }

    public String getNumeroMotor() {
        return numeroMotor;
    }

    public void setNumeroMotor(String numeroMotor) {
        this.numeroMotor = numeroMotor;
    }

    public String getCrlv() {
        return crlv;
    }

    public void setCrlv(String crlv) {
        this.crlv = crlv;
    }

    public Status getStatus() {
        return status;
    }

    public void setStatus(Status status) {
        this.status = status;
    }
}
