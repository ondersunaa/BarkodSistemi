using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp29.Model;

namespace WindowsFormsApp29
{
    public partial class UrunEkle : Form
    {
        public UrunEkle()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DatabaseIslem di = new DatabaseIslem();
            string sorguara = $"select *from Urunler where Adi like '%{textBox5.Text}%'";
            DataTable dt = Sorgu.SQLSorguCalistir(sorguara);
            dataGridView1.DataSource = di.UrunListe(dt);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Ürün Bilgilerini Giriniz");
            }
            else
            {
                Firma firma = new Firma();
                Urun urun = new Urun();
                Stok stok = new Stok();
                urun.Barkod = textBox1.Text;
                urun.BirimFiyat = textBox4.Text;
                urun.Stok = Convert.ToInt32(textBox3.Text);
                stok.GelisFiyati = textBox6.Text.ToString();
                stok.EklenmeTarihi = DateTime.Now.ToString("yyyy/MM/dd");
                string gelen = comboBox1.SelectedItem.ToString();
                string firmasorgu = $"select FirmaID from Firma where FirmaAdi='{gelen}'";
                DataTable dtfirma = Sorgu.SQLSorguCalistir(firmasorgu);
                foreach (DataRow item in dtfirma.Rows)
                {
                    firma.FirmaID = Convert.ToInt32(item["FirmaID"]);
                }
                string firmaekle = $"insert into Stok(EklemeTarihi, BarkodNo, GelenAdet, FirmaID, GelisFiyati) values ('{stok.EklenmeTarihi}', '{urun.Barkod}','{urun.Stok}','{firma.FirmaID}','{stok.GelisFiyati}')";
                Sorgu.SQLNonSorguCalistir(firmaekle);
                urun.UrunAdi = textBox2.Text;
                string sorgu = $"select *from Urunler where Barkod = '{urun.Barkod}'";
                DataTable dt = Sorgu.SQLSorguCalistir(sorgu);
                if (dt.Rows.Count == 0)
                {
                    string urunekle = $"insert into Urunler(Barkod, Adi, BirimFiyat,Stok) values ('{urun.Barkod}', '{urun.UrunAdi}','{urun.BirimFiyat}','{urun.Stok}')";
                    Sorgu.SQLNonSorguCalistir(urunekle);
                    MessageBox.Show("Ürün ekleme işlemi başarı ile gerçekleşti");
                }
                else
                {
                    MessageBox.Show("Ürün kaydı bulunuyor. Güncelleme işlemi yapacaksanız, güncelleme butonuna tıklayınız.");
                }

            }

        }

        private void UrunEkle_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Barkod"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["UrunAdi"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["Stok"].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells["BirimFiyat"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DatabaseIslem di = new DatabaseIslem();
            Urun urun = new Urun();
            urun.Barkod = dataGridView1.SelectedRows[0].Cells["Barkod"].Value.ToString();
            string sorgusil = $"delete from Urunler where Barkod= '{urun.Barkod}'";
            if (Sorgu.SQLNonSorguCalistir(sorgusil)>0)
            {
                MessageBox.Show($"{urun.Barkod} barkodlu ürün silinmiştir.");
                
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stok stok = new Stok();
            Firma firma = new Firma();
            Urun urun = new Urun();
            urun.Barkod = textBox1.Text;
            urun.UrunAdi = textBox2.Text;
            urun.Stok = Convert.ToInt32(textBox3.Text);
            urun.BirimFiyat = textBox4.Text;
            stok.EklenmeTarihi = DateTime.Now.ToString("yyyy/MM/dd");
            stok.GelisFiyati = textBox6.Text.ToString();
            string gelen = comboBox1.SelectedItem.ToString();
            string firmasorgu = $"select FirmaID from Firma where FirmaAdi='{gelen}'";
            DataTable dtfirma = Sorgu.SQLSorguCalistir(firmasorgu);
            foreach (DataRow item in dtfirma.Rows)
            {
                firma.FirmaID = Convert.ToInt32(item["FirmaID"]);
            }
            string firmaekle = $"insert into Stok(EklemeTarihi, BarkodNo, GelenAdet, FirmaID, GelisFiyati) values ('{stok.EklenmeTarihi}', '{urun.Barkod}','{urun.Stok}','{firma.FirmaID}','{stok.GelisFiyati}')";
            Sorgu.SQLNonSorguCalistir(firmaekle);
            string guncelle = $"update Urunler set Barkod = '{urun.Barkod}' , Adi = '{urun.UrunAdi}' , Stok = {urun.Stok} , BirimFiyat = '{urun.BirimFiyat}' where Barkod = '{urun.Barkod}'";
           if( Sorgu.SQLNonSorguCalistir(guncelle)>0)
            {
                MessageBox.Show("Güncelleme başarılı...");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();
            string sorgu = $"select FirmaAdi, FirmaID from Firma";
            DataTable dt = Sorgu.SQLSorguCalistir(sorgu);

            foreach (DataRow item in dt.Rows)
            {
                Firma firma = new Firma();
                firma.FirmaAdi = item["FirmaAdi"].ToString();
                comboBox1.Items.Add(firma.FirmaAdi);

            }
        }
    }
}
