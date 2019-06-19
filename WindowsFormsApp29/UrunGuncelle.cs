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
    public partial class UrunGuncelle : Form
    {
        public UrunGuncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            int yeniStok = Convert.ToInt32(textBox4.Text);
            string update = $"update Urunler set Stok ={yeniStok} where Barkod = '{textBox1.Text}'";
            if (Sorgu.SQLNonSorguCalistir(update) > 0)
            {
                MessageBox.Show("Stok güncellemesi başarılı");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            string sorgu = $"select Stok, Adi, BirimFiyat from Urunler where Barkod ='{textBox1.Text}'";
            DataTable dt = Sorgu.SQLSorguCalistir(sorgu);
            foreach (DataRow item in dt.Rows)
            {
                urun.Stok = Convert.ToInt32(item["Stok"]);
                urun.BirimFiyat = item["BirimFiyat"].ToString();
                urun.UrunAdi = item["Adi"].ToString();
            }
            textBox2.Text = urun.UrunAdi;
            textBox3.Text = urun.BirimFiyat;
            textBox5.Text = urun.Stok.ToString();
            
        }
    }
}
