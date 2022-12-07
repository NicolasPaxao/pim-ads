package com.example.pim_mobile.services;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class RetrofitClient {

    private static  Retrofit retrofit;
    public static final String API_BASE_URL = "https://gist.githubusercontent.com";

    private static Retrofit getRetrofitCliente(){
       if(retrofit == null) {
           retrofit =  new retrofit2.Retrofit.Builder()
                   .baseUrl(API_BASE_URL)
                   .addConverterFactory(GsonConverterFactory.create())
                   .build();
       }
       return retrofit;
    }

    public static <T> T createService(Class<T> serviceClass){
        return getRetrofitCliente().create(serviceClass);
    }
}
