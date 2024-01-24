package com.example.applicationgi.Adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.applicationgi.R

class ListPenerimaAdapter(private var item: List<ListPenerima>):RecyclerView.Adapter<ListPenerimaAdapter.ViewHolder>() {
    class ViewHolder(view:View):RecyclerView.ViewHolder(view) {
        var tgl_penerima:TextView=itemView.findViewById(R.id.tgl_diterima_listPenerima)
        var lb_namaPenerima:TextView=itemView.findViewById(R.id.lb_namaPenerima_listPenerima)
        val penerima=itemView.resources.getString(R.string.text_penerima)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        return ViewHolder(LayoutInflater.from(parent.context).inflate(R.layout.activity_adapter_listpenerima,parent,false))
    }

    override fun getItemCount(): Int {
        return item.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item=item[position]
        holder.lb_namaPenerima.text="${holder.penerima} ${item.namaPenerima}"
        holder.tgl_penerima.text=item.tglDiterima
    }
}