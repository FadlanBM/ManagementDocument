package com.example.applicationgi

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.example.applicationgi.databinding.ActivityListdataBinding
import com.example.applicationgi.databinding.ActivityRegisterBinding
import com.example.applicationgi.databinding.ActivityResetPassBinding

class ResetPassActivity : AppCompatActivity() {
    private  lateinit var binding: ActivityResetPassBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding=ActivityResetPassBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnBack.setOnClickListener {
            startActivity(Intent(this,SettingsActivity::class.java))
        }
    }
}