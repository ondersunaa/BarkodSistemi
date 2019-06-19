using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp29
{
    public partial class StokTakibi : Form
    {
        public StokTakibi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseIslem di = new DatabaseIslem();
            string sorgustok = $"select * from Urunler";
            DataTable dt = Sorgu.SQLSorguCalistir(sorgustok);
            dataGridView1.DataSource = di.UrunListe(dt);

            textBox1.BackColor = Color.Black;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseIslem di = new DatabaseIslem();
            string stoksorgusu = $"select * from Urunler where Stok<25 and 0<Stok";
            DataTable dt = Sorgu.SQLSorguCalistir(stoksorgusu);
            dataGridView1.DataSource = di.UrunListe(dt);
            textBox2.BackColor = Color.Black;
            textBox1.BackColor = Color.White;
            textBox3.BackColor = Color.White;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatabaseIslem di = new DatabaseIslem();
            string stoksorgusu = $"select * from Urunler where Stok=0";
            DataTable dt = Sorgu.SQLSorguCalistir(stoksorgusu);
            dataGridView1.DataSource = di.UrunListe(dt);
            textBox3.BackColor = Color.Black;
            textBox2.BackColor = Color.White;
            textBox1.BackColor = Color.White;
        }

        private void StokTakibi_Load(object sender, EventArgs e)
        {
            DatabaseIslem di = new DatabaseIslem();
            string sorgustok = $"select * from Urunler";
            DataTable dt = Sorgu.SQLSorguCalistir(sorgustok);
            dataGridView1.DataSource = di.UrunListe(dt);
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Comic Sans", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}
