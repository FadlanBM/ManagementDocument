using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagemenDocument
{
    public partial class AdminEditAccunt : Form
    {
        AppDbContextDataContext context;
        public AdminEditAccunt()
        {
            context = new AppDbContextDataContext();
            InitializeComponent();
        }

        private void loadData() {

            var id = Helper.helper.id.id_user;
            var data=context.tb_users.Where(u=>u.id_user==id).FirstOrDefault();
            var identitas=context.tb_identitas.Where(ind=>ind.id_identitas==data.id_identitas).FirstOrDefault();
            tb_nama.Text = data.name;
            tb_username.Text = data.username;
            tb_noIdentitas.Text = data.no_identitas;
            cb_nameidentitas.Text = identitas.nameIdentitas;

            var dataindentitas = (from idn in context.tb_identitas
                        select idn).ToList();
            foreach (var idn in dataindentitas)
            {
                cb_nameidentitas.Items.Add(idn.nameIdentitas);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_nama.Text.Length==0||tb_noIdentitas.Text.Length==0||tb_username.Text.Length==0||cb_nameidentitas.Text==null)
            {
                MessageBox.Show("Form tidak boleh ada yang kosong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            var identitas = context.tb_identitas.Where(ind => ind.nameIdentitas == cb_nameidentitas.Text).FirstOrDefault();
            var id = Helper.helper.id.id_user;
            var data = context.tb_users.Where(u => u.id_user == id).FirstOrDefault();
            data.username = tb_username.Text;
            data.name = tb_nama.Text;
            data.no_identitas = tb_noIdentitas.Text;
            data.id_identitas = identitas.id_identitas;
            context.SubmitChanges();
            MessageBox.Show(null, "Berhasil Update data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadData();
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


        private void AdminEditAccunt_Load(object sender, EventArgs e)
        {
            loadData();
            loadautoCom();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
