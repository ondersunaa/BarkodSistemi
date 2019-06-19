using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using WindowsFormsApp29.Model;

namespace WindowsFormsApp29
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_barkod.Select();
            txt_barkod.Focus();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Ürün";
            dataGridView1.Columns[1].Name = "Birim Fiyat";
            dataGridView1.Columns[2].Name = "Adet";
            dataGridView1.Columns[3].Name = "Toplam";
            dataGridView1.Columns["Ürün"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Birim Fiyat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Adet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Toplam"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Adet"].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns["Ürün"].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns["Ürün"].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns["Adet"].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Comic Sans", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;


        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Onder"].ConnectionString);
        private void btn_clik(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            txt_adet.Text += b.Text;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            txt_adet.Clear();
        }

        private void pic_clik(object sender, EventArgs e)
        {
            txt_birimfiyat.Text = "856522555";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void stokTakibiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokTakibi stok = new StokTakibi();
            stok.Show();
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunEkle urun = new UrunEkle();
            urun.Show();
        }

        private void stokGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunGuncelle guncel = new UrunGuncelle();
            guncel.Show();
        }

        private void barkodOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarkodOlustur barkod = new BarkodOlustur();
            barkod.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void günlükSonuRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GunSonu gunSonu = new GunSonu();
            gunSonu.Show();
        }

        private void enÇokSatanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CokSatanlar coksatan = new CokSatanlar();
            coksatan.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toptancılarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Toptancilar toptanci = new Toptancilar();
            toptanci.Show();
        }

        private void yeniToptancıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToptanciEkle ekle = new ToptanciEkle();
            ekle.Show();
        }

        private void toptancıÜrünleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToptanciUrunleri urunleri = new ToptanciUrunleri();
            urunleri.Show();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yardim yard = new Yardim();
            yard.Show();
        }

        private void hızlıMenüyüYönetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txt_alinanpara.Text = "10";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txt_alinanpara.Text = "20";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txt_alinanpara.Text = "50";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txt_alinanpara.Text = "100";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (txt_alinanpara.Text != "")
            {
                txt_paraustu.Text = (Convert.ToDouble(txt_alinanpara.Text) - Convert.ToDouble(txt_anatutar.Text)).ToString();
            }

        }

        int adetToplam = 0;
        double ToplamTutar = 0;
        private void textBox5_TextChanged(object sender, EventArgs e)
       {
            int satisadet = 0 ;
            double toplami = 0;
            Urun urun = new Urun();
            urun.Barkod = txt_barkod.Text;
            string sorgux = $"select  Adi,BirimFiyat,Stok from Urunler where Barkod = '{urun.Barkod}' ";
            DataTable dt = Sorgu.SQLSorguCalistir(sorgux);

            foreach (DataRow row in dt.Rows)
            {
                urun.UrunAdi = row["Adi"].ToString();
                urun.BirimFiyat = row["BirimFiyat"].ToString();
                urun.Stok = Convert.ToInt32(row["Stok"]);

            }
           
            if (dt.Rows.Count > 0)
            {
                txt_urunismi.Text = urun.UrunAdi;
                txt_birimfiyat.Text = urun.BirimFiyat.ToString() + " " + "TL";
                string toplam = (Convert.ToInt32(txt_adet.Text) * Convert.ToDouble(urun.BirimFiyat)).ToString();
                dataGridView1.Rows.Add(urun.UrunAdi, urun.BirimFiyat, txt_adet.Text, toplam);
                adetToplam += Convert.ToInt32(txt_adet.Text);
                ToplamTutar += Convert.ToDouble(toplam);
                txt_toplamtutar.Text = ToplamTutar.ToString();
                txt_toplamurun.Text = adetToplam.ToString();
                txt_anatutar.Text = ToplamTutar.ToString();
                int yenistok = urun.Stok - Convert.ToInt32(txt_adet.Text);
                if (yenistok< 0)
                {
                    yenistok = 0;
                    MessageBox.Show("Ürün stokta gözükmüyor lütfen stok sayısını güncelleyeniz.");
                }
                string stoksorgusu = $"Update Urunler set Stok={yenistok} where Barkod={urun.Barkod}";
                Sorgu.SQLNonSorguCalistir(stoksorgusu);
                string sorguUrunSatis = $"select * from UrunSatis where BarkodNo = '{urun.Barkod}'";
                DataTable dt2 = Sorgu.SQLSorguCalistir(sorguUrunSatis);

                if (dt2.Rows.Count==0)
                {
                    string urunsatissorgu = $"insert into UrunSatis(BarkodNo,SatisMiktari,ToplamGetiri) values ('{urun.Barkod}',{Convert.ToInt32(txt_adet.Text)},'{toplam}')";
                    Sorgu.SQLNonSorguCalistir(urunsatissorgu);
                }
                else
                {
                    foreach (DataRow item in dt2.Rows)
                    {
                        satisadet = Convert.ToInt32(item["SatisMiktari"]);
                        toplami = Convert.ToDouble(item["ToplamGetiri"]);
                    }
                    string uptdatesorgu = $"update UrunSatis set SatisMiktari = '{Convert.ToInt32(txt_adet.Text)+satisadet}' , ToplamGetiri = '{Convert.ToDouble(toplam)+toplami}' where BarkodNo = '{urun.Barkod}'";
                    Sorgu.SQLSorguCalistir(uptdatesorgu);
                }
            }
            else
            {
                txt_urunismi.Text = "Barkoda Bulunamadı";
            }

        }

        private void btn_nakit_Click(object sender, EventArgs e)
        {
            //
            if (dataGridView1.Rows.Count>1)
            {
                Satis satis = new Satis();
                satis.SatisTutar = txt_anatutar.Text;
                satis.SatisTarihi = DateTime.Now.ToString("dd/MM/yyyy");
                satis.SatisTipi = 1;
                string satissorgu = $"set dateformat dmy insert into Satis(SatisTutar,SatisTarihi,SatisTipi) values ('{satis.SatisTutar}','{satis.SatisTarihi}',{satis.SatisTipi})";
                if(Sorgu.SQLNonSorguCalistir(satissorgu)>0)
                {
                    MessageBox.Show("Satış Kaydedildi");
                }

                txt_anatutar.Text = "00";
                txt_birimfiyat.Text = "00";
                txt_barkod.Text = "";
                txt_adet.Text = "1";
                txt_urunismi.Text = "Barkod Bulunamadı";
                dataGridView1.Rows.Clear();
                adetToplam = 0;
                ToplamTutar = 0;
                txt_toplamtutar.Text = "0";
                txt_toplamurun.Text = "0";

            }
            else 
            {
                MessageBox.Show("Satılacak ürün bulunamadı");
            }
            
        }

        private void txt_anatutar_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_kart_Click(object sender, EventArgs e)
        {
        
            if (dataGridView1.Rows.Count > 1)
            {
                Satis satis = new Satis();
                satis.SatisTutar = txt_anatutar.Text;
                satis.SatisTarihi = DateTime.Now.ToString("dd/MM/yyyy");
                satis.SatisTipi = 2;
                string satissorgu = $"set dateformat dmy insert into Satis(SatisTutar,SatisTarihi,SatisTipi) values ('{satis.SatisTutar}','{satis.SatisTarihi}',{satis.SatisTipi})";
                if (Sorgu.SQLNonSorguCalistir(satissorgu) > 0)
                {
                    MessageBox.Show("Satış Kaydedildi");
               
                txt_anatutar.Text = "00";
                txt_birimfiyat.Text = "00";
                txt_barkod.Text = "";
                txt_adet.Text = "1";
                txt_urunismi.Text = "Barkod Bulunamadı";
                dataGridView1.Rows.Clear();
                adetToplam = 0;
                ToplamTutar = 0;
                txt_toplamtutar.Text = "0";
                txt_toplamurun.Text = "0";
                }
                else
                {
                    MessageBox.Show("Satış kaydedilmedi. Bir sorunla karşılaşıldı.");
                }
            }
            else 
            {
                MessageBox.Show("Satılacak ürün bulunamadı");
            }
            
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Urun urun = new Urun();
                    UrunSatis satis = new UrunSatis();
                    string a = dataGridView1.Rows[i].Cells["Ürün"].Value.ToString();
                    int b = Convert.ToInt32(dataGridView1.Rows[i].Cells["Adet"].Value);
                    double birimFiyat = Convert.ToDouble(dataGridView1.Rows[i].Cells["Birim Fiyat"].Value);
                    string sorguiptal = $"select Stok, Barkod from Urunler where Adi= '{a}'";
                    DataTable dt = Sorgu.SQLSorguCalistir(sorguiptal);
                    foreach (DataRow item in dt.Rows)
                    {
                        //urun.Barkod = item["Barkod"].ToString() ;
                        urun.Stok = Convert.ToInt32(item["Stok"]);
                        urun.Barkod = item["Barkod"].ToString();
                    }
                    int yenistok = b + urun.Stok;
                    string stokekle = $"Update Urunler set Stok={yenistok} where Adi='{a}'";
                    Sorgu.SQLNonSorguCalistir(stokekle);
                    string sorgusatismik = $"select SatisMiktari, ToplamGetiri from UrunSatis where BarkodNo = '{urun.Barkod}'";
                    DataTable dtsatis = Sorgu.SQLSorguCalistir(sorgusatismik);
                    foreach (DataRow item in dtsatis.Rows)
                    {
                        satis.SatisMiktari = Convert.ToInt32(item["SatisMiktari"]);
                        satis.ToplamGetiri = item["ToplamGetiri"].ToString();
                    }
                    int yenisatismik = satis.SatisMiktari - b;
                    double yenibirimfiyat = Convert.ToDouble(satis.ToplamGetiri) - (b * birimFiyat);
                    string sorgusatis = $"update UrunSatis set SatisMiktari = '{yenisatismik}', ToplamGetiri = '{yenibirimfiyat}' where BarkodNo = '{urun.Barkod}'";
                    Sorgu.SQLSorguCalistir(sorgusatis);
                    
                }
                txt_anatutar.Text = "00";
                txt_birimfiyat.Text = "00";
                txt_barkod.Text = "";
                txt_adet.Text = "1";
                txt_urunismi.Text = "Barkod Bulunamadı";
                dataGridView1.Rows.Clear();
                adetToplam = 0;
                ToplamTutar = 0;
                txt_toplamtutar.Text = "0";
                txt_toplamurun.Text = "0";
            }
            else 
            {
                MessageBox.Show("Satış yapılmadan iptal edilemez");
            }
            
        }

        private void btn_muskayit_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.MusteriIsim = txt_musteriad.Text;
            musteri.MusteriSoyisim = txt_musterisoyad.Text;
            musteri.MusteriTel = txt_musteritel.Text;
            musteri.MusteriMail = txt_musterimail.Text;
            string musteriekle = $"insert into Musteri(MusteriIsim, MusteriSoyisim, MusteriTel, MusteriMail) values ('{musteri.MusteriIsim}','{musteri.MusteriSoyisim}','{musteri.MusteriTel}','{musteri.MusteriMail}')";
           if( Sorgu.SQLNonSorguCalistir(musteriekle)>0)
            {
                MessageBox.Show("Müşteri Kaydı Başarılı");
                txt_musteriad.Text = "";
                txt_musterimail.Text = "";
                txt_musterisoyad.Text = "";
                txt_musterimail.Text = "";
            }
            else
            {
                MessageBox.Show("Kayıt oluşturulurken hata ile karşılaşıldı.");
            }
        }

        private void müşteriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Musteriler mus = new Musteriler();
            mus.Show();
        }
    }
}
