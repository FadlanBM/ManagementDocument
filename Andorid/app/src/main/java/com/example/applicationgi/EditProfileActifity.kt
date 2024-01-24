package com.example.applicationgi

import android.content.Context
import android.content.Intent
import android.os.AsyncTask
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Adapter
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.AutoCompleteTextView
import com.example.applicationgi.databinding.ActivityEditProfileActifityBinding
import com.example.applicationgi.util.BaseApi
import com.example.applicationgi.util.SharePref
import org.json.JSONObject
import java.io.InputStreamReader
import java.net.HttpURLConnection
import java.net.URL
import kotlin.math.log

class EditProfileActifity : AppCompatActivity() {
    private lateinit var binding:ActivityEditProfileActifityBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding=ActivityEditProfileActifityBinding.inflate(layoutInflater)
        setContentView(binding.root)
        getData(binding).execute()
        var item= arrayListOf("Nama","Lisy")
        var autocom:AutoCompleteTextView=binding.comboBoxListIden
        var adapater=ArrayAdapter(this,R.layout.item_listiden,item)
        autocom.setAdapter(adapater)
        autocom.onItemClickListener=AdapterView.OnItemClickListener{adapterview, view, i, l ->
            val itemSelected=adapterview.getItemAtPosition(i)
        }
            binding.btnBack.setOnClickListener{
                startActivity(Intent(this,SettingsActivity::class.java))
            }
    }

    private inner class getData(private val binding: ActivityEditProfileActifityBinding):AsyncTask<String,String,String>(){
        override fun onPreExecute() {
            super.onPreExecute()
        }

        override fun doInBackground(vararg params: String?): String {
            var result=""
            try {
                var token="bearer ${SharePref.getInstance(this@EditProfileActifity).getToken()}"
                var httpURLConnection:HttpURLConnection?=null
                var url=URL(BaseApi.BASEAPI+"api/Setting")
                httpURLConnection=url.openConnection() as HttpURLConnection
                httpURLConnection.requestMethod="GET"
                httpURLConnection.setRequestProperty("Authorization",token)

                var inputStream=httpURLConnection.inputStream
                var inputStreamReader=InputStreamReader(inputStream)
                var data=inputStreamReader.read()
                    Log.e("DataListError",data.toString())
                while (data !=-1){
                    result+=data.toChar()
                    data=inputStreamReader.read()
                }

            }catch (e:Exception){
                Log.e("Error Http","Error $e")
            }
            return result
        }

        override fun onPostExecute(result: String?) {
            super.onPostExecute(result)
            var jsonObject=JSONObject(result)
            Log.e("DataListError",jsonObject.toString())
            binding.tbName.setText(jsonObject.getString("name"))
            binding.tbUsername.setText(jsonObject.getString("username"))
            binding.tbNoidentitas.setText(jsonObject.getString("noIdentitas"))
            val alamat=jsonObject.getString("alamat")
            val phone=jsonObject.getString("phone")
            if (alamat!="null"){
                binding.tbAlamat.setText(alamat)
            }
            if (phone!="null"){
                binding.tbPhoneNumber.setText(phone)
            }
             binding.comboBoxListIden.setText(jsonObject.getString("tipeIdentitas"))
        }
    }
}