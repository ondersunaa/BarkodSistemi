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
    public partial class ToptanciUrunleri : Form
    {
        public ToptanciUrunleri()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ToptanciUrunleri_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Firma";
            dataGridView1.Columns[1].Name = "Geliş Fiyatı";
            dataGridView1.Columns[2].Name = "Ürün";
            dataGridView1.Columns[3].Name = "Satış Fiyatı";
            dataGridView1.Columns["Firma"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Geliş Fiyatı"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Ürün"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Satış Fiyatı"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Firma"].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns["Ürün"].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns["Ürün"].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns["Firma"].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Comic Sans", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void Ara_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Firma firma = new Firma();
            Urun urun = new Urun();
            Stok stok = new Stok();
            firma.FirmaAdi = comboBox1.SelectedItem.ToString();
            string firmasorgu = $"select FirmaID from firma where FirmaAdi ='{firma.FirmaAdi}'";
            DataTable dtfirma = Sorgu.SQLSorguCalistir(firmasorgu);
            foreach (DataRow item in dtfirma.Rows)
            {
                firma.FirmaID = Convert.ToInt32(item["FirmaID"]);
            }
            string urunsorgu = $"select BarkodNo, GelisFiyati from Stok where FirmaID = '{firma.FirmaID}'";
            
            DataTable dtbarkod = Sorgu.SQLSorguCalistir(urunsorgu);
            foreach (DataRow item in dtbarkod.Rows)
            {
                stok.GelisFiyati = item["GelisFiyati"].ToString();
                urun.Barkod = item["BarkodNo"].ToString();
                string sorgu3 = $"select Adi, BirimFiyat from Urunler where Barkod = '{urun.Barkod}'";
                DataTable dturun = Sorgu.SQLSorguCalistir(sorgu3);
                foreach (DataRow item2 in dturun.Rows)
                {
                    urun.UrunAdi = item2["Adi"].ToString();
                    urun.BirimFiyat = item2["BirimFiyat"].ToString();
                    dataGridView1.Rows.Add(firma.FirmaAdi, stok.GelisFiyati, urun.UrunAdi, urun.BirimFiyat);
                }
            }
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
