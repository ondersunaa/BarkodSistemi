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
    public partial class CokSatanlar : Form
    {
        public CokSatanlar()
        {
            InitializeComponent();
        }

        private void CokSatanlar_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Name = "Barkod";
            dataGridView1.Columns[1].Name = "Ürün Adı";
            dataGridView1.Columns[2].Name = "Satış Adeti";
            dataGridView1.Columns[3].Name = "Toplam Getiri";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Comic Sans", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            UrunSatis satis = new UrunSatis();
            Urun urun = new Urun();
            string siralama = $"select * from UrunSatis Order By SatisMiktari DESC";
           DataTable dt = Sorgu.SQLSorguCalistir(siralama);
            foreach (DataRow item in dt.Rows)
            {
                satis.Barkod = item["BarkodNo"].ToString();
                satis.SatisMiktari = Convert.ToInt32(item["SatisMiktari"]);
                satis.ToplamGetiri = item["ToplamGetiri"].ToString();
                string urunisim = $"select Adi from Urunler where Barkod = '{satis.Barkod}'";
                DataTable dt2 = Sorgu.SQLSorguCalistir(urunisim);
                foreach (DataRow item2 in dt2.Rows)
                {
                    urun.UrunAdi = item2["Adi"].ToString();
                    dataGridView1.Rows.Add(satis.Barkod, urun.UrunAdi, satis.SatisMiktari, satis.ToplamGetiri);
                }
            }
        }
    }
}
