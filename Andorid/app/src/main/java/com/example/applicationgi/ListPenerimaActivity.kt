package com.example.applicationgi

import android.content.Context
import android.content.Intent
import android.os.AsyncTask
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.renderscript.ScriptGroup.Input
import android.util.Log
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.applicationgi.Adapter.Item
import com.example.applicationgi.Adapter.ListPenerima
import com.example.applicationgi.Adapter.ListPenerimaAdapter
import com.example.applicationgi.databinding.ActivityListPenerimaBinding
import com.example.applicationgi.util.BaseApi
import com.example.applicationgi.util.SharePref
import org.json.JSONArray
import org.json.JSONObject
import java.io.InputStreamReader
import java.lang.Exception
import java.net.HttpURLConnection
import java.net.URL

class ListPenerimaActivity : AppCompatActivity() {
    private lateinit var binding:ActivityListPenerimaBinding
    private lateinit var recyclerView: RecyclerView
    private  lateinit var listPenerimaAdapter: ListPenerimaAdapter
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding= ActivityListPenerimaBinding.inflate(layoutInflater)
        setContentView(binding.root)
        supportActionBar?.hide()
        var adapter=ListPenerimaAdapter(emptyList())
        getListData(this).execute()
        recyclerView=findViewById(R.id.recyclerViewPenerima)
        recyclerView.adapter=adapter
        recyclerView.layoutManager=LinearLayoutManager(this)
        ListPenerimaAdapter(emptyList())

        binding.btnBack.setOnClickListener {
            startActivity(Intent(this,MainActivity::class.java))
        }
    }

    private inner class getListData(private val context: Context):AsyncTask<String,String,String>(){

        override fun doInBackground(vararg params: String?): String {
            var result=""
            var httpURLConnection:HttpURLConnection?=null
            val id=intent.getStringExtra("id")
            val token="bearer ${SharePref(context).getToken()}"
            try {
                val url=URL("${BaseApi.BASEAPI}Api/ListPenerima/$id")
                httpURLConnection=url.openConnection() as HttpURLConnection
                httpURLConnection.setRequestProperty("Authorization",token)
                httpURLConnection.setRequestProperty("Content-Type","application/json")
                httpURLConnection.setRequestProperty("accept","text/plain")

                var inputStream=httpURLConnection.inputStream
                var inputStreamReader=InputStreamReader(inputStream)
                var data =inputStreamReader.read()

                while (data!=-1){
                    result+=data.toChar()
                    data=inputStreamReader.read()
                }
                return result
            }catch (e:Exception){
                Log.e("Error Http","Error $e")
            }
            return result
        }

        override fun onPostExecute(result: String?) {
            super.onPostExecute(result)
            var data= mutableListOf<ListPenerima>()
            var jsonArray=JSONArray(result)
            Log.e("ListDataPenerima",result.toString())

            for (i in 0 until jsonArray.length()){
                var jsonObject=jsonArray.getJSONObject(i)
                var namaPenerima=jsonObject.getString("namaPenerima")
                var tgl_diterima=jsonObject.getString("tgl_diterima")
                data.add(ListPenerima(tgl_diterima,namaPenerima))
            }
            listPenerimaAdapter= ListPenerimaAdapter(data!!)
            recyclerView.adapter=listPenerimaAdapter
        }
    }

    override fun onBackPressed() {
        super.onBackPressed()
        startActivity(Intent(this,MainActivity::class.java))
    }
}