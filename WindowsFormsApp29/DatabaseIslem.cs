using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp29.Model;

namespace WindowsFormsApp29
{
    class DatabaseIslem
    {
        public List<Urun> GetListAll(int adet, int toplam)
        {
            DataTable dt = Sorgu.SQLSorguCalistir("select * from Urunler");
            return UrunListe(dt);
        }
        public List<Firma> GetListAll()
        {
            DataTable dt = Sorgu.SQLSorguCalistir("select * from Firma");
            return FirmaListe(dt);
        }
        public List<Firma> FirmaListe(DataTable dt)
        {

            List<Firma> listFirma = new List<Firma>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Firma firma = new Firma();
                firma.FirmaAdi = dt.Rows[i]["FirmaAdi"].ToString();
                firma.FirmaTel = dt.Rows[i]["FirmaTel"].ToString();
                firma.FirmaMail = dt.Rows[i]["FirmaMail"].ToString();
                firma.FirmaNot = dt.Rows[i]["FirmaNot"].ToString();
                firma.FirmaAdres = dt.Rows[i]["FirmaAdres"].ToString();
                listFirma.Add(firma);
            }
            return listFirma;
        }
        public List<Musteri> MusteriListe(DataTable dt)
        {

            List<Musteri> listMusteri = new List<Musteri>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Musteri musteri = new Musteri();
                musteri.MusteriIsim = dt.Rows[i]["MusteriIsim"].ToString();
                musteri.MusteriSoyisim = dt.Rows[i]["MusteriSoyisim"].ToString();
                musteri.MusteriTel = dt.Rows[i]["MusteriTel"].ToString();
                musteri.MusteriMail = dt.Rows[i]["MusteriMail"].ToString();
                
                listMusteri.Add(musteri);
            }
            return listMusteri;
        }
        public List<Urun> UrunListe(DataTable dt)
        {

            List<Urun> listUrun = new List<Urun>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Urun m = new Urun();
                m.UrunAdi = dt.Rows[i]["Adi"].ToString();
                m.BirimFiyat = dt.Rows[i]["BirimFiyat"].ToString();
                m.Barkod = dt.Rows[i]["Barkod"].ToString();
                m.Stok = Convert.ToInt32(dt.Rows[i]["Stok"]);
                listUrun.Add(m);
            }
            return listUrun;
        }
        public List<Urun> GetListByName(string text)
        {
            DataTable dt = Sorgu.SQLSorguCalistir($"select Barkod, Adi, BirimFiyat from Urunler where Barkod = '{text}'");
            return UrunListe(dt);
        }
        public List<Satis> SatisList(DataTable dt)
        {

            List<Satis> listSatis = new List<Satis>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Satis m = new Satis();
                m.SatisTipi = Convert.ToInt32(dt.Rows[i]["SatisTipi"]);
                m.SatisTutar = dt.Rows[i]["SatisTutar"].ToString();
                m.SatisTarihi = dt.Rows[i]["SatisTarihi"].ToString();
                listSatis.Add(m);
            }
            return listSatis;
        }
    }
}
