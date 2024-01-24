package com.example.applicationgi

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Handler
import android.util.Log

class SplashSuccessActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_splash_success)
        supportActionBar?.hide()

        Handler().postDelayed({
            val intent=Intent(this,MainActivity::class.java )
            startActivity(intent)
            finish()
        },3000)
    }
}