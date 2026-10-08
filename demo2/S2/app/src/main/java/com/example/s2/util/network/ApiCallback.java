package com.example.s2.util.network;

import java.io.IOException;

public interface ApiCallback {
    void onResponse(int code, String response);

    void onFailure(Exception e);
}

