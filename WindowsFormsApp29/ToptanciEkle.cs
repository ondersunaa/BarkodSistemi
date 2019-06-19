using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp29.Model;

namespace WindowsFormsApp29
{
    public partial class ToptanciEkle : Form
    {
        public ToptanciEkle()
        {
            InitializeComponent();
        }

        private void ToptanciEkle_Load(object sender, EventArgs e)
        {
            DatabaseIslem di = new DatabaseIslem();
            dataGridView1.DataSource = di.GetListAll();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[3].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Comic Sans", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Firma frm = new Firma();
            frm.FirmaAdi = textBox2.Text;
            frm.FirmaTel = maskedTextBox1.Text;
            frm.FirmaMail = textBox3.Text;
            frm.FirmaAdres = richTextBox1.Text;
            frm.FirmaNot = richTextBox2.Text;
            string sorgu = $"insert into Firma (FirmaAdi, FirmaMail, FirmaTel, FirmaAdres , FirmaNot) values ('{frm.FirmaAdi}', '{frm.FirmaMail}','{frm.FirmaTel}', '{frm.FirmaAdres}', '{frm.FirmaNot}')";
            if (Sorgu.SQLNonSorguCalistir(sorgu) > 0)
            {
                MessageBox.Show("Firma kaydı başarılı.");
                dataGridView1.Refresh();
            }
        }
        int firmaID = 0;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Firma frm = new Firma();
            frm.FirmaTel = dataGridView1.SelectedRows[0].Cells["FirmaTel"].Value.ToString();
            string sorgu = $"delete from Firma where FirmaTel ='{frm.FirmaTel}'";
            if (Sorgu.SQLNonSorguCalistir(sorgu)>0)
            {
                MessageBox.Show("Silme işlemi başarılı.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Firma frm = new Firma();
            frm.FirmaAdi = textBox2.Text;
            frm.FirmaTel = maskedTextBox1.Text;
            frm.FirmaMail = textBox3.Text;
            frm.FirmaAdres = richTextBox1.Text;
            frm.FirmaNot = richTextBox2.Text;
            string sorgu = $"update Firma set FirmaAdi='{frm.FirmaAdi}', FirmaMail = '{frm.FirmaMail}', FirmaAdres='{frm.FirmaAdres}',FirmaNot='{frm.FirmaNot}' where FirmaTel='{frm.FirmaTel}'";
            string sorguu = $"select FirmaID from Firma where FirmaTel = '{maskedTextBox1.Text}'";
            DataTable dt = Sorgu.SQLSorguCalistir(sorguu);
            foreach (DataRow item in dt.Rows)
            {
                firmaID = Convert.ToInt32(item["FirmaID"]);
            }
            label6.Text = firmaID.ToString();
            if (Sorgu.SQLNonSorguCalistir(sorgu) > 0)
            {
                MessageBox.Show("Firma Güncelleme Başarılı");
                dataGridView1.Refresh();
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["FirmaAdi"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["FirmaMail"].Value.ToString();
            maskedTextBox1.Text = dataGridView1.SelectedRows[0].Cells["FirmaTel"].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["FirmaAdres"].Value.ToString();
            richTextBox2.Text = dataGridView1.SelectedRows[0].Cells["FirmaNot"].Value.ToString();
            
        }
    }
}
