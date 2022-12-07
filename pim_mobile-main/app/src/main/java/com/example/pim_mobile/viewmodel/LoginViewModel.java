package com.example.pim_mobile.viewmodel;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import com.example.pim_mobile.model.Consts;

import java.util.Objects;

public class LoginViewModel extends ViewModel {

    private final MutableLiveData<Boolean> isLogin = new MutableLiveData<>();
    public LiveData<Boolean> mLogin = isLogin;

    public void login(String email, String password){
        String emailUser = Consts.usuarioModel.getCliente().getEmail();
        String passwordUser = Consts.usuarioModel.getCliente().getSenha();
        if(Objects.equals(email, emailUser) && Objects.equals(password, passwordUser)){
            this.isLogin.setValue(true);
        }else{
            this.isLogin.setValue(false);
        }
    }
}
