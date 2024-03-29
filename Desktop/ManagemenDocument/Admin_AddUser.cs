﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagemenDocument
{
    public partial class Admin_AddUser : Form
    {
        private int? level=null;
        AppDbContextDataContext context;
        public int? id { get; set; }
        public Admin_AddUser(Form mdi)
        {
            context=new AppDbContextDataContext();
            this.MdiParent= mdi;    
            InitializeComponent();
            loadautoCom();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (id==null)
            {
                if (tb_nama.Text == "" || tb_noIdentitas.Text == "" || cb_nameidentitas.Text == "" || level == null || tb_username.Text.Length == 0)
                {
                    MessageBox.Show(null, "Form belum di isi semua", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            var identity =context.tb_identitas.Where(c=>c.nameIdentitas==cb_nameidentitas.Text).FirstOrDefault();
                if (identity==null)
                {
                    MessageBox.Show(null, "Tipe Identitas tidak di temukan / atau tidak terdaftar ", "Informtaion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                tb_user user=new tb_user();
            user.name = tb_nama.Text;
            user.username=tb_username.Text;
            user.no_identitas = tb_noIdentitas.Text;
            user.id_identitas = identity.id_identitas;
            if (ck_password.Checked==true)
            {
                user.password = createSha("123456");
            }
            else
            {
                user.password = createSha(tb_password.Text);
            }
            user.verify = 0;
            user.level = (int)level;
            user.createdAt = DateTime.Now;
            context.tb_users.InsertOnSubmit(user);
            context.SubmitChanges();
            MessageBox.Show(null, "Berhasil Input data ", "Informtaion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult=DialogResult.OK;
            clearForm();
            return;
            }
            else
            {
                if ( tb_noIdentitas.Text == "" || cb_nameidentitas.Text == "" || level == null || tb_username.Text.Length == 0)
                {
                    MessageBox.Show(null, "Form belum di isi semua", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = context.tb_users.Where(u => u.id_user == id).FirstOrDefault();
                var identity = context.tb_identitas.Where(c => c.nameIdentitas == cb_nameidentitas.Text).FirstOrDefault();
                var password = context.tb_users.Where(us => us.password ==createSha(tb_password.Text)).FirstOrDefault();
                if (password!=null)
                {
                    MessageBox.Show("Password tidak boleh sama dengan yang lama", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (tb_password.Text.Length!=0)
                {
                    user.password = createSha(tb_password.Text);
                }
                user.name = tb_nama.Text;
                user.no_identitas = tb_noIdentitas.Text;
                user.id_identitas = identity.id_identitas;
                if (ck_password.Checked == true)
                {
                    user.password = createSha("123456");
                }
                else
                {
                    user.password = createSha(tb_password.Text);
                }
                user.level = (int)level;
                user.createdAt = DateTime.Now;
                context.SubmitChanges();
                MessageBox.Show(null, "Berhasil Input data ", "Informtaion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.OK;
                this.Close();
                clearForm();
            }
          
        }

        private void loadautoCom()
        {
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();


            var user = (from u in context.tb_identitas
                        select new
                        {
                            u.nameIdentitas
                        }).ToList();
            foreach (var u in user)
            {
                ac.Add(u.nameIdentitas);
            }

            cb_nameidentitas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_nameidentitas.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_nameidentitas.AutoCompleteCustomSource = ac;
        }


        private void clearForm() {
            tb_nama.Text = "";
            tb_noIdentitas.Text = "";
            cb_nameidentitas.Text = "";
            level = null;
            tb_password.Text = null;
            ck_password.Checked = false;
            logiceditrd();
        }

        private void showTotb() { 
           var data =context.tb_users.Where(d=>d.id_user==id).FirstOrDefault();
            var loyal =context.tb_identitas.Where(l=>l.id_identitas==data.id_identitas).FirstOrDefault();
            tb_nama.Text = data.name;
            tb_username.Text = data.username;
            tb_noIdentitas.Text = data.no_identitas;
            cb_nameidentitas.Text = loyal.nameIdentitas;
            level= data.level;
            logiceditrd();
        }

        private string createSha(string p) { 
            StringBuilder sb=new StringBuilder();
            using (var sha=SHA256.Create())
            {
                var baytes = sha.ComputeHash(Encoding.UTF8.GetBytes(p));
                for (int i = 0; i < baytes.Length; i++)
                {
                    sb.Append(baytes[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }

        private void Admin_AddUser_Load(object sender, EventArgs e)
        {
            logicRd();
            logiceditrd();
            if (id!=null)
            {
            showTotb();                
            }
        }
        private void logicck() {
            if (ck_password.Checked == true)
            {
                tb_password.Enabled = false;
            }
            if (ck_password.Checked == false)
            {
                tb_password.Enabled = true;
            }
        }

        private void logiceditrd() {
            if (level == 0)
            {
                rd_admin.Checked = true;
            }
            else if (level == 1)
            {
                rd_user.Checked = true;
            }
            else
            {
                rd_admin.Checked=false;
                rd_user.Checked=false;  
            }
        }

        private void logicRd() {
            if (rd_admin.Checked)
            {
                rd_user.Checked = false;
            }
            if (rd_user.Checked)
            {
                rd_admin.Checked = true;
            }                    
            

            var data =(from idn in context.tb_identitas
                       select idn).ToList();
            foreach (var idn in data)
            {
                cb_nameidentitas.Items.Add(idn.nameIdentitas);
            }
        }

        private void rd_user_CheckedChanged(object sender, EventArgs e)
        {
            level = 1;
        }

        private void rd_admin_CheckedChanged(object sender, EventArgs e)
        {
            level = 0;
        }

        private void ck_password_CheckedChanged(object sender, EventArgs e)
        {
            logicck();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
            this.Close();
        }
    }
}
