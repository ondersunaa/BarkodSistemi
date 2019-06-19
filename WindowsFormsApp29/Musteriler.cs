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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {
            DatabaseIslem di = new DatabaseIslem();
            string sorgu = $"Select * from Musteri";
            DataTable dt = Sorgu.SQLSorguCalistir(sorgu);
            dataGridView1.DataSource = di.MusteriListe(dt);
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[3].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Comic Sans", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}
