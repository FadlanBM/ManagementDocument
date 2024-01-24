package com.example.applicationgi

import android.content.Context
import android.content.Intent
import android.os.AsyncTask
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.Menu
import android.view.MenuItem
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.AutoCompleteTextView
import android.widget.LinearLayout
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.applicationgi.Adapter.ItemAdapter
import com.example.applicationgi.Adapter.Item
import com.example.applicationgi.databinding.ActivityMainBinding
import com.example.applicationgi.util.BaseApi
import com.example.applicationgi.util.SharePref
import org.json.JSONArray
import java.io.BufferedReader
import java.io.InputStreamReader
import java.lang.Exception
import java.lang.StringBuilder
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {
    private lateinit var binding:ActivityMainBinding;
    private lateinit var itemAdapter: ItemAdapter
    private lateinit var recyclerView: RecyclerView
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding= ActivityMainBinding.inflate(layoutInflater);
        setContentView(binding.root)
        recyclerView=findViewById(R.id.recyclerView)
        itemAdapter= ItemAdapter(emptyList(),this)


        recyclerView.adapter=itemAdapter
        recyclerView.layoutManager=LinearLayoutManager(this)

        FetchDataTask().execute()

        var sf=SharePref(this)
        if (sf.getToken()==null){
            startActivity(Intent(this,LoginActivity::class.java))
        }

//        var item= arrayListOf("Show All","Selesai","Belum Selesai","Belum Selesai","Belum Selesai")
//        var autoComplete:AutoCompleteTextView=findViewById(R.id.cb_ordelist)
//        var adapter=ArrayAdapter(this,R.layout.item_text,item)
//
//
//        autoComplete.setAdapter(adapter)
//        autoComplete.onItemClickListener=AdapterView.OnItemClickListener { adapterView, view, i, l ->
//            val itemselected =adapterView.getItemAtPosition(i)
//            Toast.makeText(this,"Item : $itemselected",Toast.LENGTH_SHORT).show()
//        }

        binding.btnScanqr.setOnClickListener {
            startActivity(Intent(this,QRCodeScanActivity::class.java))
        }
    }


    private inner class FetchDataTask():AsyncTask<Void,Void,List<Item>>(){
        override fun doInBackground(vararg p0: Void?): List<Item> {
            val data= mutableListOf<Item>()
            var response=""
            try {
                val url=URL(BaseApi.BASEAPI+"api/DocList")
                val httpURLConnection=url.openConnection() as HttpURLConnection
                httpURLConnection.requestMethod="GET"
                var token="bearer ${SharePref.getInstance(this@MainActivity).getToken()}"
                Log.e("Token",token)
                httpURLConnection.setRequestProperty("Authorization",token)
                httpURLConnection.setRequestProperty("Content-Type","application/json")
                httpURLConnection.setRequestProperty("accept","text/plain")

               var inputStream=httpURLConnection.inputStream
               var inputStreamReader=InputStreamReader(inputStream)
                var datas=inputStreamReader.read()

                while (datas!=-1){
                    response+=datas.toChar()
                    datas=inputStreamReader.read()
                }

                val jsonArray=JSONArray(response)
                for (i in 0 until jsonArray.length()){
                    val jsonObject=jsonArray.getJSONObject(i)
                    val nameDoc=jsonObject.getString("nameDoc")
                    val tglagendaAwal=jsonObject.getString("tglAgendaawal")
                    val tglagendaAkhir=jsonObject.getString("tglagendaAkhir")
                    val tglDoc=jsonObject.getString("tglDoc")
                    val tglterima=jsonObject.getString("tglTerima")
                    var id=jsonObject.getString("id")
                    data.add(Item(id,nameDoc,tglagendaAwal,tglagendaAkhir,tglDoc,tglterima))
                }
                Log.e("DataTask",data.toString())
            }catch (e:Exception){
                Log.e("Error Connect Task","Error $e")
            }
            return data
        }

        override fun onPostExecute(result: List<Item>?) {
            super.onPostExecute(result)
            Log.e("DataTask",result.toString())
            val itemAdapter=ItemAdapter(result!!,this@MainActivity)
                recyclerView.adapter=itemAdapter
        }
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.cusotm_menu,menu)
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        return when(item.itemId){
            R.id.tb_logout->{
                var message=AlertDialog.Builder(this)
                message.setTitle("Warning")
                message.setMessage("Apakah anda yakin ingin logout ?")
                message.setPositiveButton("Yes"){_,_->
                    startActivity(Intent(this,LoginActivity::class.java))
                    SharePref.getInstance(this).setToken("")
                }
                message.setNegativeButton("No",null)
                message.show()
                return true
            }
            else->super.onOptionsItemSelected(item)
        }
    }


}