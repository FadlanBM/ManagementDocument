package com.example.applicationgi.Adapter

import android.content.Context
import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.applicationgi.DetailDataActivity
import com.example.applicationgi.ListDataActivity
import com.example.applicationgi.ListPenerimaActivity
import com.example.applicationgi.R

class ItemAdapter(private val items: List<Item>,private val context: Context):RecyclerView.Adapter<ItemAdapter.ViewHolder>(){

    class ViewHolder(itemView: View):RecyclerView.ViewHolder(itemView) {
        val nameTextView:TextView=itemView.findViewById(com.example.applicationgi.R.id.lbnameDoc)
        val tglawalView:TextView=itemView.findViewById(R.id.tgl_agendaAwal)
        val tglakhirView:TextView=itemView.findViewById(R.id.tgl_agendaAkhir)
        val tglDocView:TextView=itemView.findViewById(R.id.tgl_doc)
        val tglDiterimaView:TextView=itemView.findViewById(R.id.tgl_diterima)
        var btnDetailDoc:Button=itemView.findViewById(R.id.btn_detailDoc)
        var btn_listpenerima:TextView=itemView.findViewById(R.id.btn_listPenerima)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view=LayoutInflater.from(parent.context).inflate(com.example.applicationgi.R.layout.adapter_doc,parent,false)
        return ViewHolder(view)
    }

    override fun getItemCount(): Int {
        return items.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item=items[position]
        holder.nameTextView.text=item.nameDoc
        holder.tglawalView.text=item.tglAgendaawal
        holder.tglakhirView.text=item.tglagendaAkhir
        holder.tglDocView.text=item.tglDoc
        holder.tglDiterimaView.text=item.tglTerima
        holder.btnDetailDoc.setOnClickListener {
            val intent=Intent(context,DetailDataActivity::class.java)
            intent.putExtra("id",item.id)
            context.startActivity(intent)
        }
        holder.btn_listpenerima.setOnClickListener {
            val intent=Intent(context,ListPenerimaActivity::class.java)
            intent.putExtra("id",item.id)
            context.startActivity(intent)
        }
    }
}
