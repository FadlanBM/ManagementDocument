package com.example.applicationgi

import android.content.Context
import android.content.Intent
import android.os.AsyncTask
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import com.example.applicationgi.databinding.ActivityDetailDataBinding
import com.example.applicationgi.util.BaseApi
import com.example.applicationgi.util.SharePref
import org.json.JSONObject
import java.io.InputStreamReader
import java.net.HttpURLConnection
import java.net.URL

class DetailDataActivity : AppCompatActivity() {
    private lateinit var binding:ActivityDetailDataBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding=ActivityDetailDataBinding.inflate(layoutInflater)
        setContentView(binding.root)
        supportActionBar?.hide()

        getDataDetail(this,binding).execute()

        binding.btnBack.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
        }
    }

    private inner class getDataDetail(private val context: Context,binding: ActivityDetailDataBinding):AsyncTask<String,String,String>(){
        override fun onPreExecute() {
            super.onPreExecute()
        }

        override fun doInBackground(vararg params: String?): String {
            val id=intent.getStringExtra("id")
            var result=""
            var httpURLConnection:HttpURLConnection?=null
            var token="bearer "+SharePref(context).getToken()
            Log.e("Iddetail",token.toString())
            try {
                var url=URL(BaseApi.BASEAPI+"api/QrValidation/$id")
                httpURLConnection=url.openConnection() as HttpURLConnection
                httpURLConnection.requestMethod="GET"
                httpURLConnection.setRequestProperty("Authorization",token)
                httpURLConnection.setRequestProperty("Content-Type","application/json")
                httpURLConnection.setRequestProperty("accept","text/plain")

                var inputStream=httpURLConnection.inputStream
                var inputStreamReader=InputStreamReader(inputStream)
                var data=inputStreamReader.read()

                while (data!=-1){
                    result+=data.toChar()
                    data=inputStreamReader.read()
                }

                if (httpURLConnection.responseCode==HttpURLConnection.HTTP_OK){
                return result
                }

            }catch (e:Exception){
                Log.e("Error Http","Error $e")
            }
            return ""
        }

        override fun onPostExecute(result: String?) {
            super.onPostExecute(result)
            if (result.toString()!=""){
                var jsonObject=JSONObject(result)
                binding.lbNameDoc.text=jsonObject.getString("nameDokumen")
                binding.lbAgendaDoc.text=jsonObject.getString("agendaDokumen")
                binding.lbPerihal.text=jsonObject.getString("perihalDokumen")
                binding.lbNamaPengirim.text=jsonObject.getString("pengirimDokumen")
                binding.lbUraianDoc.text=jsonObject.getString("uraianDokumen")
                binding.lbTglDiterima.text=jsonObject.getString("tglDiterima")
                binding.lbTglDoc.text=jsonObject.getString("tglDokumen")
                binding.lbTglawal.text=jsonObject.getString("tglAgendaAwal")
                binding.tbTglAkhir.text=jsonObject.getString("tglAgendaAkhir")
                Log.e("dataList",jsonObject.toString())
            }else{
                Log.e("Error Data","Data tidak ditemukan")
            }

        }
    }
    override fun onBackPressed() {
        super.onBackPressed()
        startActivity(Intent(this,MainActivity::class.java))
    }
}